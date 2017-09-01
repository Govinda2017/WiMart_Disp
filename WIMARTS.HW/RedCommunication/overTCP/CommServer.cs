using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RedCommunication.TCP
{
    public delegate void OnDataLOG(string log);

    /// <summary>
    /// Description: State object for reading client data asynchronously.
    /// </summary>

    public class StateObject
    {
        public bool connected = false;              // ID received flag
        public Socket workSocket = null;              // Client socket.
        public const int BufferSize = 1024;          // Size of receive buffer.
        public byte[] buffer = new byte[BufferSize];  // Receive buffer.
        public StringBuilder sb = new StringBuilder();  //Received data String.
        public string id = String.Empty;                // Host or conversation ID
        public DateTime TimeStamp;
        public string ClientAddress;
    }

    ///<summary>
    /// Description: Server is the class to control sockets  
    ///</summary>
    public class CommServer
    {
        public delegate void OnRecv(StateObject client, string Msg, SocketError code);
        public delegate void OnConnect(StateObject client, SocketError code);
        public delegate void OnClose(StateObject client, SocketError code);

        protected int portNumber;
        protected int maxSockets;
        protected int sockCount = 0;
        private int convID = 0;
        private Timer lostTimer;
        private const int numThreads = 1;
        private const int timerTimeout = 3000;
        private const int timeoutMinutes = 3;
        private bool ShuttingDown = false;
        protected string title;

        public OnRecv OnRecvEvent = null;
        public OnConnect OnConnectEvent = null;
        public OnClose OnCloseEvent = null;

        protected Hashtable connectedHT = new Hashtable();
        protected ArrayList connectedSocks;

        //Thread signal.
        private ManualResetEvent allDone = new ManualResetEvent(false);
        private Thread[] serverThread = new Thread[numThreads];
        private AutoResetEvent[] threadEnd = new AutoResetEvent[numThreads];


        public CommServer(int port, string title, string attr)
        {
            this.portNumber = port;
            this.title = title;
            this.maxSockets = 10000;
            connectedSocks = new ArrayList(this.maxSockets);
        }


        /// <summary>
        /// Description: Start the threads to listen to the port and process
        /// messages.
        /// </summary>
        public void Start()
        {
            // Clear the thread end events
            for (int lcv = 0; lcv < numThreads; lcv++)
                threadEnd[lcv] = new AutoResetEvent(false);

            ThreadStart threadStart1 = new ThreadStart(StartListening);
            serverThread[0] = new Thread(threadStart1);
            serverThread[0].IsBackground = true;
            serverThread[0].Start();

            // Create the delegate that invokes methods for the timer.
            TimerCallback timerDelegate = new TimerCallback(this.CheckSockets);
            //Create a timer that waits one minute, then invokes every 5 minutes.
            lostTimer = new Timer(timerDelegate, null, timerTimeout, timerTimeout);

        }
		public static bool IsSocketConnected(Socket socket)
        {
            bool returnValue = false;

            if (socket != null)
            {
                // Socket.Connected doesn't tell us if the socket is actually connected...
                // http://msdn2.microsoft.com/en-us/library/system.net.sockets.socket.connected.aspx

                bool disposed = false;
                bool blocking = socket.Blocking;
                
                try
                {
                    socket.Blocking = false;

                    int pollWait = 1;

                    if (socket.Poll(pollWait, SelectMode.SelectRead) && socket.Available == 0)
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }

                }
                catch (SocketException ex)
                {
                    // 10035 == WSAEWOULDBLOCK
                    if (ex.NativeErrorCode.Equals(10035))
                        returnValue = true;
                }
                catch (ObjectDisposedException)
                {
                    disposed = true;
                    returnValue = false;
                }
                finally
                {
                    if (!disposed)
                    {
                        socket.Blocking = blocking;
                    }
                }
            }
			//Console.WriteLine(returnValue.ToString());
            return returnValue;
        }
		
        /// <summary>
        /// Description: Check for dormant sockets and close them.
        /// </summary>
        /// <param name="eventState">Required parameter for a timer call back
        /// method.</param>
        ///        
        private void CheckSockets(object eventState)
        {
            lostTimer.Change(System.Threading.Timeout.Infinite,
                System.Threading.Timeout.Infinite);
            try
            {
                foreach (StateObject state in connectedSocks)
                {
                    if (state.workSocket == null 
                        || IsSocketConnected(state.workSocket) == false)
                    {    // Remove invalid state object
                        Monitor.Enter(connectedSocks);
                        if (connectedSocks.Contains(state))
                        {
                            connectedSocks.Remove(state);
                            Interlocked.Decrement(ref sockCount);
							
							if (OnCloseEvent != null)
                   				OnCloseEvent(state,SocketError.ConnectionAborted);								
                        }
                        Monitor.Exit(connectedSocks);
                    }
                    //else
                    //{
                    //    if (DateTime.Now.AddTicks(-state.TimeStamp.Ticks).Minute > timeoutMinutes)
                    //    {
                    //        RemoveSocket(state);
                    //    }
                    //}
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                lostTimer.Change(timerTimeout, timerTimeout);
            }
        }
        /// <summary>
        /// Decription: Stop the threads for the port listener.
        /// </summary>
        public void Stop()
        {
            int lcv;
            lostTimer.Dispose();
            lostTimer = null;

            for (lcv = 0; lcv < numThreads; lcv++)
            {
                if (!serverThread[lcv].IsAlive)
                    threadEnd[lcv].Set();    // Set event if thread is already dead
            }
            ShuttingDown = true;
            // Create a connection to the port to unblock the listener thread
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, this.portNumber);
            sock.Connect(endPoint);
            //sock.Close();
            sock = null;

            // Check thread end events and wait for up to 5 seconds.
            for (lcv = 0; lcv < numThreads; lcv++)
                threadEnd[lcv].WaitOne(5000, false);
        }
        /// <summary>
        /// Decription: Open a listener socket and wait for a connection.
        /// </summary>
        private void StartListening()
        {
            // Establish the local endpoint for the socket.
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, this.portNumber);
            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(1000);

                while (!ShuttingDown)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    listener.BeginAccept(new AsyncCallback(this.AcceptCallback), listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }
            }
            catch (Exception ex)
            {
                string  x = ex.Message;
                threadEnd[0].Set();
            }
        }
        /// <summary>
        /// Decription: Call back method to accept new connections.
        /// </summary>
        /// <param name="ar">Status of an asynchronous operation.</param>
        private void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();
            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            state.ClientAddress = handler.RemoteEndPoint.ToString();
            state.TimeStamp = DateTime.Now;

            try
            {
                Interlocked.Increment(ref sockCount);
                Monitor.Enter(connectedSocks);
                connectedSocks.Add(state);
                Monitor.Exit(connectedSocks);

                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(this.ReadCallback), state);
                if (sockCount > this.maxSockets)
                {
                    RemoveSocket(state);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    handler = null;
                    state = null;
                }
                StuffList(state, (++convID).ToString());
                if (OnConnectEvent != null)
                    OnConnectEvent(state, SocketError.Success);
                LogMsgs("Client " + convID.ToString() + " Connected");
                //Send(state, "HELLO^ID~" + convID.ToString());
            }
            catch (SocketException ex)
            {
                int x = ex.ErrorCode;
                RemoveSocket(state);
            }
            catch (Exception ex)
            {
                string x = ex.Message;
                RemoveSocket(state);
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
                while (content.Length>0)
                {
                    int startpos = content.IndexOf("<MSG>");
                    if (startpos == -1)
                    {
                        remain = content;
                        content = "";
                    }
                    else
                    {
                        content = content.Substring(startpos+5);
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

        /// <summary>
        /// Decription: Call back method to handle incoming data.
        /// </summary>
        /// <param name="ar">Status of an asynchronous operation.</param>
        protected void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the async state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            try
            {
                // Read data from the client socket.
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.
                    Monitor.Enter(state);
                    System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                    char[] chars = new char[bytesRead + 1];
                    int charLen = d.GetChars(state.buffer, 0, bytesRead, chars, 0);
                    System.String szData = new System.String(chars, 0, bytesRead);
                    state.sb.Append(szData);
                    Monitor.Exit(state);

                    // Check for end-of-file tag.
                    // If it is not there, read more data.
                    content = state.sb.ToString();
                    //if (content.IndexOf("&ltEOF>") > -1)
                    if (content.Length > 0) 
                    {
                        state.TimeStamp = DateTime.Now;
                        // Process the received message

                        string remain="";
                        List<string> msgs = GetAllMessages(content, ref remain);

                        foreach(string msg in msgs)
                            if (OnRecvEvent != null)
                                OnRecvEvent(state, msg, SocketError.Success);

                        // Echo the data back to the client.
                        //Send(state, "HELLO^ID~"+);
                        state.sb.Remove(0, state.sb.Length);
                        if(remain.Length>0)
                            state.sb.Append(remain);
                        
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(this.ReadCallback), state);
                    }
                }
                else
                {    // Disconnected
                    //RemoveSocket(state);
                }
            }
            catch (System.Net.Sockets.SocketException es)
            {
                if (OnCloseEvent != null)
                    OnCloseEvent(state, (SocketError)es.ErrorCode);

                if (es.ErrorCode == (int)SocketError.ConnectionReset)
                {
                    LogMsgs(string.Format("Client({0}) ID : {1} is disconnected.", state.ClientAddress, state.id));

                }
                //RemoveSocket(state);
                if (es.ErrorCode != 64 && es.ErrorCode != (int)SocketError.ConnectionReset)
                {
                    LogMsgs(string.Format("ReadCallback Socket Exception: {0}, {1}.", es.ErrorCode, es.ToString()));
                }


            }
            catch (Exception e)
            {
                if (OnCloseEvent != null)
                    OnCloseEvent(state, SocketError.Fault);

                RemoveSocket(state);
                if (e.GetType().FullName != "System.ObjectDisposedException")
                {
                    LogMsgs(string.Format("ReadCallback Exception: {0}.", e.ToString()));
                }
            }
        }
        /// <summary>
        /// Decription: Send the given data string to the given socket.
        /// </summary>
        /// <param name="sock">Socket to send data to.</param>
        /// <param name="data">The string containing the data to send.</param>
        public void Send(StateObject state, string data)
        {
            string tdata = "<MSG>" + data + "</MSG>";
            Socket sock = state.workSocket;
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.UTF8.GetBytes(tdata);

            // Begin sending the data to the remote device.
            if (byteData.Length > 0)
                sock.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(this.SendCallback), sock);
        }
       

        /// <summary>
        /// Author: Asad Aziz
        /// Decription: Call back method to handle outgoing data.
        /// </summary>
        /// <param name="ar">Status of an asynchronous operation.</param>
        protected void SendCallback(IAsyncResult ar)
        {
            // Retrieve the socket from the async state object.
            Socket handler = (Socket)ar.AsyncState;
            try
            {
                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }
        /// <summary>
        /// Description: Find on socket using the identifier as the key.
        /// </summary>
        /// <param name="id">The identifier key associated with a socket.</param>
        private Socket FindID(string id)
        {
            Socket sock = null;
            Monitor.Enter(connectedHT);
            if (connectedHT.ContainsKey(id))
                sock = (Socket)connectedHT[id];
            Monitor.Exit(connectedHT);
            return sock;
        }
        /// <summary>
        /// Author: Asad Aziz
        /// Description: Place the given socket in the connected list.
        ///
        /// Notes:
        /// 1) Get the Member ID from the command
        /// 2) Add the socket to the connected socket list with its Member ID
        /// </summary>
        /// <param name="state">The state object containing the socket info.</param>
        /// <param name="command">The XML-based message containing the ID that
        /// needs to be parsed.</param>
        /// <param name="content">Not used in the base method.</param>
        virtual protected bool StuffList(StateObject state, string command)//, ref string content)
        {
            Socket sock = state.workSocket;
            string hostID = command;// ReadXML(command, Server.msgConnect, this.connectAttr);

            if (hostID != null)
            {
                state.id = hostID;
                if (hostID == "NeedToCheckThisIF")
                {
                    LogMsgs(string.Format("Host control socket connected {0}!", this.title));
                    return true;
                }

                // Add to connected list
                Monitor.Enter(connectedHT);
                if (connectedHT.ContainsKey(hostID))
                {
                    object val = connectedHT[hostID];
                    connectedHT[hostID] = sock;
                    connectedHT.Add(sock, val);
                    LogMsgs(string.Format("Socket found in Hasttable!", this.title));
                }
                else
                {
                    connectedHT.Add(hostID, sock);
                    connectedHT.Add(sock, hostID);
                    LogMsgs(string.Format("Socket not found, adding a new socket to hashtable!", this.title));
                }
                Monitor.Exit(connectedHT);

                LogMsgs(string.Format("Socket was moved to connected {0} list!", this.title));
                return true;
            }
            return false;
        }
        /// <summary>
        /// Description: Remove the socket contained in the given state object
        /// from the connected array list and hash table, then close the socket.
        /// </summary>
        /// <param name="state">The StateObject containing the specific socket
        /// to remove from the connected array list and hash table.</param>
        virtual protected void RemoveSocket(StateObject state)
        {
            Socket sock = state.workSocket;
            Monitor.Enter(connectedSocks);
            if (connectedSocks.Contains(state))
            {
                connectedSocks.Remove(state);
                Interlocked.Decrement(ref sockCount);
            }
            Monitor.Exit(connectedSocks);
            Monitor.Enter(connectedHT);

            if ((sock != null) && (connectedHT.ContainsKey(sock)))
            {
                object sockTemp = connectedHT[sock];
                if (connectedHT.ContainsKey(sockTemp))
                {
                    if (connectedHT.ContainsKey(connectedHT[sockTemp]))
                    {
                        connectedHT.Remove(sock);
                        if (sock.Equals(connectedHT[sockTemp]))
                        {
                            connectedHT.Remove(sockTemp);
                        }
                        else
                        {
                            object val, key = sockTemp;
                            while (true)
                            {
                                val = connectedHT[key];
                                if (sock.Equals(val))
                                {
                                    connectedHT[key] = sockTemp;
                                    break;
                                }
                                else if (connectedHT.ContainsKey(val))
                                    key = val;
                                else    // The chain is broken
                                    break;
                            }
                        }
                    }
                    else
                    {
                        LogMsgs(string.Format("Socket is not in the {0}  connected hash table!", this.title));
                    }
                }
            }
            Monitor.Exit(connectedHT);

            if (sock != null)
            {
                //if (sock.Connected)
                //    sock.Shutdown(SocketShutdown.Both);
                sock.Close();
                sock = null;
                state.workSocket = null;
                state = null;

            }
        }
        public OnDataLOG DataLogRecvEvent;
        private void LogMsgs(string data)
        {
            if (DataLogRecvEvent != null)
            DataLogRecvEvent(data);
        }
    }


}
