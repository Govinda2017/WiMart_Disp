using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace RedCommunication.TCP
{
    public sealed class TCPConn
    {
        //ComSettings _Settings;
        string ipaddress;
        int port;
        string netmask;
        string gateway;
        bool useDHCP;
        int bufferSize = 1024;
        //ComSettings _Settings;

        TcpClient simpleTcp = null;
        NetworkStream tcpStream = null;
        volatile bool _keepReading;
        int _index;

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        public delegate void StatusHandler(string param, int Index);
        public StatusHandler StatusChanged;
        

        public TCPConn(int index, string IP, int Port)
        {
            _index = index;
            ipaddress = IP;
            port = Port;
            
		}
        public void Open()
        {
            try
            {
                // Create the client and indicate the server to connect to
                simpleTcp = new TcpClient(ipaddress, (int)port);
                //simpleTcp.NoDelay = true;
                simpleTcp.ReceiveTimeout = 100;
                simpleTcp.SendTimeout = 1000;
                simpleTcp.SendBufferSize = bufferSize;
                simpleTcp.ReceiveBufferSize = bufferSize;

                // Retrieve the NetworkStream so we can do Read and Write
                tcpStream = simpleTcp.GetStream();
            }
            catch (SocketException ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                if (StatusChanged != null)
                    StatusChanged(String.Format("Unable to connect to {0}:{1}", ipaddress, port), Index);
            }
            catch (IOException ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                if (StatusChanged != null)
                    StatusChanged(String.Format("Unable to connect to {0}:{1}", ipaddress, port), Index);
            }
            // Update the status
            if (simpleTcp.Connected)
            {
                //string p = _serialPort.Parity.ToString().Substring(0, 1);   //First char
                //string h = _serialPort.Handshake.ToString();
                //if (_serialPort.Handshake == Handshake.None)
                //    h = "no handshake"; // more descriptive than "None"
                //if (StatusChanged != null)
                //    StatusChanged(String.Format("{0}: {1} bps, {2}{3}{4}, {5}",
                //    _serialPort.PortName, _serialPort.BaudRate,
                //    _serialPort.DataBits, p, (int)_serialPort.StopBits, h), Settings.Port.PortName);
            }
            else
            {
                if (StatusChanged != null)
                    StatusChanged(String.Format("Unable to connect to {0}:{1}", ipaddress, port), Index);
            }
        }
        public void Close()
        {
            if (tcpStream != null)
                tcpStream.Close();
            if (simpleTcp != null)
                simpleTcp.Close();
            if (StatusChanged != null)
                StatusChanged(String.Format("connection closed {0}:{1}", ipaddress, port), Index); 
        }
        public bool IsOpen
        {
            get
            {
                return simpleTcp != null ? simpleTcp.Connected : false;
                //return simpleTcp.Connected;
            }
        }
        public void Send(string data2Send)
        {
            string conLenSeperator = "\n" + "\n"; //[LF][LF]
            string tdata = "Content-Length: " + data2Send.Length.ToString() + conLenSeperator + data2Send;
            
            if (IsOpen)
            {
                byte[] sendBuffer = ConvertStringToBytes(tdata);
                //byte[] byteCount = ConvertStringToBytes(sendBuffer.Length.ToString() + conLenSeperator);
                //tcpStream.Write(byteCount, 0, byteCount.Length);

                // Send the actual data
                tcpStream.Write(sendBuffer, 0, sendBuffer.Length);
            }
        }
        public void SendBytes(byte[] data, int len)
        {
            if (IsOpen)
            {
                tcpStream.Write(data, 0, len);
            }
        }
        
        public byte[] Read()
        {
            byte[] buffer = new byte[bufferSize];
            if (IsOpen)
            {
                tcpStream.Read(buffer, 0, bufferSize);
            }
            return buffer;
        }
        public string  ReadString()
        {
            byte[] buffer = new byte[bufferSize];
            if (IsOpen)
            {
                try
                {
                    tcpStream.Read(buffer, 0, bufferSize);
                }
                catch (ArgumentNullException ex)
                {
                    return "";
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    return "";
                }
                catch (IOException ex)
                {
                    return "";
                }
                catch (ObjectDisposedException ex)
                {
                    return "";
                }
            }
            return ConvertBytesToString(buffer);
        }
        string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }
    }
}
