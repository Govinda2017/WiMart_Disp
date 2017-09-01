using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace RedCommunication.TCP
{
    public class CommClient
    {

        public delegate void OnRecv(string text,int clientId ,SocketError code);
        public delegate void OnConnect(string ConnectMsg, SocketError code);
        public delegate void OnClose(string CloseMsg, int clientId, SocketError code);

        IAsyncResult m_result;
        private AsyncCallback   m_pfnCallBack;
        private Socket          m_clientSocket;
        public  OnRecv          OnRecvEvent=null;
        public  OnConnect       OnConnectEvent=null;
        public  OnClose         OnCloseEvent=null;
        private StringBuilder sb = new StringBuilder();
        private int m_Id = 0;

        public int ID
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public bool IsOpen  //Connected
        {
            get { return m_clientSocket!= null ? m_clientSocket.Connected:false; }
        }

        public bool  Connect(string IP, string Port)
        {
            try
            {
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Cet the remote IP address
                IPAddress ip = IPAddress.Parse(IP);
                int iPortNo = System.Convert.ToInt16(Port);
                // Create the end point 
                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                // Connect to the remote host
                m_clientSocket.Connect(ipEnd);
                if (m_clientSocket.Connected)
                {
                    //Wait for data asynchronously
                 
                    if (OnConnectEvent != null)
                        OnConnectEvent("Connected to host " + ip + ":" + Port, SocketError.Success);
                    WaitForData();
                }
                return true; 
            }
            catch(SocketException ex)
            {
                int x = ex.ErrorCode;
              // MessageBox.Show("Server is not available", "Connect", MessageBoxButtons.OK , MessageBoxIcon.Information) ;
               return false; 
            }
        }
        public void Close()
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }
        }
        public int SendEncodingCL(String strData)
        {
            string conLenSeperator = "\n" + "\n"; //[LF][LF]

            string tdata = "Content-Length: " + strData.Length.ToString() + conLenSeperator + strData;
            int size = 0;
            try
            {
                Object objData = tdata;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                if (m_clientSocket != null && m_clientSocket.Connected == true)
                    size = m_clientSocket.Send(byData);
                return size;
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                return size;
            }
        }
        public int SendEncodingProtoStart(String strData)
        {
            int size = 0;
            try
            {
                Object objData = strData;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                byte[] sendData = new byte[byData.Length + 3];
                sendData[0] = 0x02;
                for (int i = 0; i < byData.Length; i++)
                {
                    sendData[i+1] = byData[i];
                }
                sendData[byData.Length + 1] = 0x03;
                sendData[byData.Length + 2] = 0x0a;

                if (m_clientSocket != null && m_clientSocket.Connected == true)
                    size = m_clientSocket.Send(byData);
                return size;
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                return size;
            }
        }
        public int SendPlain(String strData)
        {
            int size = 0;
            try
            {
                Object objData = strData;
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                if (m_clientSocket != null && m_clientSocket.Connected == true)
                    size = m_clientSocket.Send(byData);
                return size;
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                return size;
            }
        }

        private void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "WaitForData", MessageBoxButtons.OK);
                m_clientSocket.Close();
                if (OnCloseEvent != null)
                    OnCloseEvent("Connection To server closed", m_Id, (SocketError)se.ErrorCode);

            }

        }
        List<string> GetAllMessages(string content, ref string remain)
        {
            List<string> msgs = new List<string>();

            if (content.StartsWith("<") == false || content.Length < 5)
            {
                msgs.Add(content);
            }
            else
            {
                while (content.Length > 0)
                {
                    int startpos = content.IndexOf("<MSG>");
                    if (startpos == -1)
                    {
                        remain = content;
                        content = "";
                    }
                    else
                    {
                        content = content.Substring(startpos + 5);
                        int endpos = content.IndexOf("</MSG>");
                        if (endpos == -1)
                        {
                            remain = content;
                            content = "";
                        }
                        else
                        {
                            string msg = content.Substring(0, endpos);
                            msgs.Add(msg);
                            content = content.Substring(endpos);
                        }
                    }
                }
            }
            return msgs;
        }
        private void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars, 0, iRx);
                //sb.Append(szData);
                //String content = String.Empty;

                //content = sb.ToString();

                //if (content.Length > 0)
                if (szData.Length > 0)
                {
                    //string remain = "";
                    //List<string> msgs = GetAllMessages(content, ref remain);
                    //foreach (string msg in msgs)
                        if (OnRecvEvent != null)
                            OnRecvEvent(szData, m_Id, SocketError.Success);
                    //sb.Remove(0, sb.Length);
                    //if (remain.Length > 0)
                    //    sb.Append(remain);
                }
                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message, "OnDataReceived", MessageBoxButtons.OK);
                m_clientSocket.Close();
                if (OnCloseEvent != null)
                    OnCloseEvent("Connection To server closed", m_Id, (SocketError)se.ErrorCode);

            }
        }
    }    
    public class SocketPacket
    {
        public System.Net.Sockets.Socket thisSocket;
        public byte[] dataBuffer = new byte[1024];
    }

}
