using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace RedCommunication.TCP
{
    public class TCP4Condot
    {
        private Socket m_sock;						// Server connection
        private byte[] m_byBuff = new byte[1024];	// Recieved data buffer
                
        public delegate void OnReceiveDelegate(int id, string msg);
        public delegate void OnConnectDelegate(int id, bool bSuccess);
        public delegate void OnDisconnectDelegate(int id);

        public OnReceiveDelegate OnReceive;
        public OnConnectDelegate OnConnect;
        public OnDisconnectDelegate OnDisconnect;

        public TCP4Condot(OnConnectDelegate OnConnect, 
			OnDisconnectDelegate OnDisconnect,
			OnReceiveDelegate OnReceive)
		{
			// copy the delegates
			this.OnReceive = OnReceive;
			this.OnConnect = OnConnect;
			this.OnDisconnect = OnDisconnect;
		}

        public bool IsConnected
        {
            get { return (m_sock == null ? false : m_sock.Connected); }
        }
        
        public int Connect(string hostName, int serviceport)
        {
            if (IsConnected)
                return -1; //'no need to do anything once connected

            try
            {
                // Close the socket if it is still open
                if (m_sock != null && m_sock.Connected)
                {
                    //m_sock.Shutdown(SocketShutdown.Both);
                    System.Threading.Thread.Sleep(10);
                    m_sock.Close();
                }

                // Create the socket object
                m_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Define the Server address and port
                IPEndPoint epServer = new IPEndPoint(IPAddress.Parse(hostName), serviceport);

                // Connect to the server blocking method and setup callback for recieved data
                // m_sock.Connect( epServer );
                // SetupRecieveCallback( m_sock );

                // Connect to server non-Blocking method
                m_sock.Blocking = false;
                AsyncCallback onconnect = new AsyncCallback(OnConnectMsg);
                m_sock.BeginConnect(epServer, onconnect, m_sock);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return 1;
        }
        public void Disconnect()
        {
            if (m_sock != null && m_sock.Connected)
            {
                m_sock.Shutdown(SocketShutdown.Both);
                m_sock.Disconnect(true); 
                m_sock.Close();
                
                if (OnDisconnect != null)
                    OnDisconnect(1);
            }
        }

        public void SendMessage(string message)
        {
            // Check we are connected
            if (m_sock == null || !m_sock.Connected)
            {
                return;
            }
            // Read the message from the text box and send it
            try
            {
                // Convert to byte array and send.
                Byte[] byteDateLine = Encoding.ASCII.GetBytes(message.ToCharArray());
                m_sock.Send(byteDateLine, byteDateLine.Length, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private void OnConnectMsg(IAsyncResult ar)
        {
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;

            // Check if we were sucessfull
            try
            {
                if (sock.Connected)
                {
                    SetupRecieveCallback(sock);
                    if (OnConnect != null)
                    {
                        OnConnect(1, true);
                    }
                }
                else
                {
                    if (OnConnect != null)
                    {
                        OnConnect(1, false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Setup the callback for recieved data and loss of conneciton
        /// </summary>
        private void SetupRecieveCallback(Socket sock)
        {
            try
            {
                AsyncCallback recieveData = new AsyncCallback(OnRecievedData);
                sock.BeginReceive(m_byBuff, 0, m_byBuff.Length, SocketFlags.None, recieveData, sock);
            }
            catch (Exception ex)
            {
                //MessageBox.Show( this, ex.Message, "Setup Recieve Callback failed!" );
            }
        }
        /// <summary>
        /// Get the new data and send it out to all other connections. 
        /// Note: If not data was recieved the connection has probably 
        /// died.
        /// </summary>
        /// <param name="ar"></param>
        private void OnRecievedData(IAsyncResult ar)
        {
            if (m_sock == null || !m_sock.Connected)
            {
                return;
            }
            // Socket was the passed in object
            Socket sock = (Socket)ar.AsyncState;

            // Check if we got any data
            try
            {
                int nBytesRec = sock.EndReceive(ar);
                if (nBytesRec > 0)
                {
                    // Wrote the data to the List
                    string sRecieved = Encoding.ASCII.GetString(m_byBuff, 0, nBytesRec);

                    if (OnReceive != null)
                    {
                        OnReceive(1, sRecieved);
                    }
                    // If the connection is still usable restablish the callback
                    SetupRecieveCallback(sock);
                }
                else
                {
                    // If no data was recieved then the connection is probably dead
                    Trace.TraceError("Client {0}, disconnected", sock.RemoteEndPoint);
                    //sock.Shutdown(SocketShutdown.Both);
                    sock.Close();
                }
            }
            catch (SocketException ex)
            {
                Trace.TraceError("OnRecievedData{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                if (OnDisconnect != null)
                    OnDisconnect(1);
            }
            catch (Exception ex)
            {
                Trace.TraceError("OnRecievedData{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                //throw ex;
            }
        }
    }
}