using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace RedCommunication.TCP
{
    public class TCPClLibAsynch
    {
        public string ConnectorName { get; set; }

        const int BuffSize = 1024;
        public int Index { get; private set; }
        private TcpClient tcpClient = null;
        private NetworkStream tcpStream = null;

        private byte[] m_byBuff = new byte[BuffSize];	// Recieved data buffer

        public delegate void OnReceiveBytesDelegate(int id,byte[] buffer, int count);
        public delegate void OnReceiveStringDelegate(int id, string msg);
        public delegate void OnConnectDelegate(int id, bool bSuccess);
        public delegate void OnDisconnectDelegate(int id);

        public OnReceiveBytesDelegate OnReceiveBytes;
        public OnReceiveStringDelegate OnReceiveString;
        public OnConnectDelegate OnConnect;
        public OnDisconnectDelegate OnDisconnect;

        public TCPClLibAsynch(OnConnectDelegate OnConnect,
            OnDisconnectDelegate OnDisconnect,
            OnReceiveStringDelegate OnReceive)
        {
            // copy the delegates
            this.OnReceiveString = OnReceive;
            this.OnConnect = OnConnect;
            this.OnDisconnect = OnDisconnect;

            this.tcpClient = new TcpClient();
            //this.tcpClient.NoDelay = true;
            //this.tcpClient.ReceiveTimeout = 100;
            //this.tcpClient.SendTimeout = 1000;
            this.tcpClient.SendBufferSize = BuffSize;
            this.tcpClient.ReceiveBufferSize = BuffSize;
        }

        public TCPClLibAsynch(OnConnectDelegate OnConnect,
            OnDisconnectDelegate OnDisconnect,
            OnReceiveBytesDelegate OnReceive)
        {
            // copy the delegates
            this.OnReceiveBytes = OnReceive;
            this.OnConnect = OnConnect;
            this.OnDisconnect = OnDisconnect;

            this.tcpClient = new TcpClient();
            //this.tcpClient.NoDelay = true;
            //this.tcpClient.ReceiveTimeout = 100;
            //this.tcpClient.SendTimeout = 1000;
            this.tcpClient.SendBufferSize = BuffSize;
            this.tcpClient.ReceiveBufferSize = BuffSize;
        }

        public bool IsConnected
        {
            get { return this.tcpClient != null ? this.tcpClient.Connected : false; }
        }

        public int Connect(string hostName, int serviceport)
        {
            if (this.IsConnected)
                return -1; //'no need to do anything once connected

            try
            {
                if (!this.IsConnected)
                {
                    //this.tcpClient.Connect(this.Server, this.Port);
                    this.tcpClient.BeginConnect(hostName, serviceport, new AsyncCallback(OnConnectMsg), tcpClient);
                }
            }
         
            catch (SocketException ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                if (OnConnect != null)
                    OnConnect(Index, false);
            }
            catch (IOException ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                if (OnConnect != null)
                    OnConnect(Index, false);
            }
            return Index;
        }
        public void Disconnect()
        {
            if (this.tcpClient != null && this.tcpClient.Connected)
            {
                this.tcpClient.Close();
                if (tcpStream != null)
                    tcpStream.Close();
                tcpStream = null;
                if (OnDisconnect != null)
                    OnDisconnect(Index);
            }
        }

        public bool SendMessage(string message)
        {
            if (string.IsNullOrEmpty(message) == true)
            {
                //throw new ArgumentException("Expected StringMessage");
                return false;
            }

            if (!this.IsConnected)// Check! I am connected
                return false;

            byte[] sendBuffer = ConvertStringToBytes(message);
            tcpStream.Write(sendBuffer, 0, sendBuffer.Length);

            //using (NetworkStream ns = this.tcpClient.GetStream())
            //{
            //    using (StreamWriter sw = new StreamWriter(ns))
            //    {
            //        sw.Write(message);
            //    }
            //}
            return true;
        }
        public bool SendMessage(byte[] message, int msgLen)
        {
            if (message == null || msgLen <= 0)
            {
                //throw new ArgumentException("Expected StringMessage");
                return false;
            }

            if (!this.IsConnected)// Check! I am connected
                return false;

            tcpStream.Write(message, 0, msgLen);
            return true;
        }

        private void OnConnectMsg(IAsyncResult ar)
        {
            if (ar != null)
            {
                try
                {
                    if (this.IsConnected)
                    {
                        tcpStream = tcpClient.GetStream();
                        //tcpClient.Client.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, new AsyncCallback(OnDataReceive), m_byBuff);
                        tcpClient.Client.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.Partial, new AsyncCallback(OnDataReceive), m_byBuff);
                        if (OnConnect != null)
                            OnConnect(Index, true);
                    }
                    else
                    {
                        if (OnConnect != null)
                            OnConnect(Index, false);
                    }
                }
                catch (Exception ex)
                {
                    //throw ex;
                    Trace.TraceError("{0}, OnConnectMsg(...), {1}", DateTime.Now.ToString(), ex.ToString());
                }
            }
        }
        private void OnDataReceive(IAsyncResult ar)
        {
            if (ar != null)
            {
                try
                {   // Socket was the passed in object
                    //Socket sock = (Socket)ar.AsyncState;
                    if (this.IsConnected)
                    {
                        int nBytesRec = tcpClient.Client.EndReceive(ar);
                        if (nBytesRec > 0)
                        {
                            if (OnReceiveBytes != null)
                            {
                                OnReceiveBytes(Index, m_byBuff, nBytesRec);
                            }
                            else if (OnReceiveString != null)
                            {
                                string sRecieved = Encoding.UTF8.GetString(m_byBuff, 0, nBytesRec);
                                OnReceiveString(Index, sRecieved);
                            }
                            //tcpClient.Client.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, new AsyncCallback(OnDataReceive), m_byBuff);
                            tcpClient.Client.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.Partial, new AsyncCallback(OnDataReceive), m_byBuff);
                        }
                        else
                        {
                            // If no data was recieved then the connection is probably dead
                            Trace.TraceError("No data!, Client {0} @ {1} disconnected", ConnectorName, tcpClient.Client.RemoteEndPoint);
                            if (OnDisconnect != null)
                                OnDisconnect(Index);

                            tcpClient.Close();
                        }
                    }
                }
                catch (SocketException ex)
                {
                    Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                    if (OnDisconnect != null)
                        OnDisconnect(Index);
                }
                catch (Exception ex)
                {
                    Trace.TraceError("{0},No data!, Client {1} disconnected, {2}", DateTime.Now.ToString(), ConnectorName, ex.ToString());
                }
            }
        }

        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.UTF8.GetBytes(str);
        }
    }
}