using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace RedCommunication.SERIAL
{
    /// <summary> CommPort class creates a singleton instance
    /// of SerialPort (System.IO.Ports) </summary>
    /// <remarks> When ready, you open the port.
    ///   <code>
    ///   CommPort com = CommPort.Instance;
    ///   com.StatusChanged += OnStatusChanged;
    ///   com.DataReceived += OnDataReceived;
    ///   com.Open();
    ///   </code>
    ///   Notice that delegates are used to handle status and data events.
    ///   When settings are changed, you close and reopen the port.
    ///   <code>
    ///   CommPort com = CommPort.Instance;
    ///   com.Close();
    ///   com.PortName = "COM4";
    ///   com.Open();
    ///   </code>
    /// </remarks>
    public sealed class CommPort
    {
        SerialPort _serialPort;
        Thread _readThread;
        volatile bool _keepReading;
        ComSettings _Settings;
        int _index;
        string lineEnding = "";

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public ComSettings Settings
        {
            get { return _Settings; }
            set { _Settings = value; }
        }
        public string Name
        {
            get { return _serialPort.PortName; }
        }
        public CommPort()
        {
            _serialPort = new SerialPort();
            _readThread = null;
            _keepReading = false;
            _Settings = new ComSettings();
            _index = 0;
        }
        public CommPort(int index, string PortName)
        {
            _serialPort = new SerialPort(PortName);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.ReadTimeout = 100;
            _serialPort.WriteTimeout = 1000;
            _readThread = null;
            _keepReading = false;
            _Settings = new ComSettings(PortName, true);
            _index = index;
        }
        public CommPort(string settingDir, int index, string PortName)
        {
            _serialPort = new SerialPort(PortName);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.ReadTimeout = 100;
            _serialPort.WriteTimeout = 1000;
            _readThread = null;
            _keepReading = false;
            _Settings = new ComSettings(PortName, true);
            _index = index;
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort.IsOpen == false)
                return;
            byte[] readBuffer = new byte[_serialPort.ReadBufferSize + 1];
            try
            {
                // If there are bytes available on the serial port,
                // Read returns up to "count" bytes, but will not block (wait)
                // for the remaining bytes. If there are no bytes available
                // on the serial port, Read will block until at least one byte
                // is available on the port, up until the ReadTimeout milliseconds
                // have elapsed, at which time a TimeoutException will be thrown.
                int count = _serialPort.Read(readBuffer, 0, _serialPort.ReadBufferSize);
                
                //Trace.TraceInformation("_serialPort_DataReceived {0} {1} {2:X2} {3:X2}", DateTime.Now.ToString(), count, readBuffer[0], readBuffer[1]);

                if (DataReceived != null)
                {
                    String SerialIn = System.Text.Encoding.ASCII.GetString(readBuffer, 0, count);
                    DataReceived(SerialIn, Settings.Port.PortName, Index);
                }
                if (DataReceivedBytes != null)
                    DataReceivedBytes(readBuffer, count, Settings.Port.PortName, Index);
            }
            catch (TimeoutException) { }
        }
        public delegate void EventHandler(string param, string PortName, int index);
        public delegate void EventHandlerBytes(byte[] buffer, int count, string PortName, int index);
        public delegate void StatusHandler(string param, string PortName);
        public StatusHandler StatusChanged;
        public EventHandler DataReceived;
        public EventHandlerBytes DataReceivedBytes;

        private void StartReading()
        {
            if (!_keepReading)
            {
                _keepReading = true;
            }
        }
        private void StopReading()
        {
            try
            {
                if (_keepReading)
                {
                    _keepReading = false;
                    if (_readThread != null)
                        _readThread.Join();	//block until exits
                    _readThread = null;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }

        }
        /// <summary> Get the data and pass it on. </summary>
        private void ReadPort()
        {
            while (_keepReading)
            {
                if (_serialPort.IsOpen)
                {
                    byte[] readBuffer = new byte[_serialPort.ReadBufferSize + 1];
                    try
                    {
                        // If there are bytes available on the serial port,
                        // Read returns up to "count" bytes, but will not block (wait)
                        // for the remaining bytes. If there are no bytes available
                        // on the serial port, Read will block until at least one byte
                        // is available on the port, up until the ReadTimeout milliseconds
                        // have elapsed, at which time a TimeoutException will be thrown.
                        int count = _serialPort.Read(readBuffer, 0, _serialPort.ReadBufferSize);
                        String SerialIn = System.Text.Encoding.ASCII.GetString(readBuffer, 0, count);
                        if (DataReceived != null) 
                            DataReceived(SerialIn, Settings.Port.PortName, Index);
                    }
                    catch (TimeoutException)
                    {

                    }
                }
                else
                {
                    TimeSpan waitTime = new TimeSpan(0, 0, 0, 0, 50);
                    Thread.Sleep(waitTime);
                }
            }
        }
        private bool IsPortPresent(string PortName)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string p in ports)
            {
                if (p.ToLower() == PortName.ToLower())
                    return true;
            }
            return false;
        }
        /// <summary> Open the serial port with current settings. </summary>
        public void Open()
        {
            Close();

            try
            {
                _serialPort.PortName = Settings.Port.PortName;
                _serialPort.BaudRate = Settings.Port.BaudRate;
                _serialPort.Parity = Settings.Port.Parity;
                _serialPort.DataBits = Settings.Port.DataBits;
                _serialPort.StopBits = Settings.Port.StopBits;
                _serialPort.Handshake = Settings.Port.Handshake;

                // Set the read/write timeouts
                _serialPort.ReadTimeout = 100;
                _serialPort.WriteTimeout = 1000;
                try
                {
                    if (IsPortPresent(Settings.Port.PortName) == true)
                        _serialPort.Open();
                }
                catch (IOException ex)
                {
                    Trace.TraceError("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
                }
                StartReading();
            }
            catch (IOException)
            {
                if (StatusChanged != null)
                    StatusChanged(String.Format("{0} does not exist", Settings.Port.PortName), Settings.Port.PortName);
            }
            catch (UnauthorizedAccessException)
            {
                if (StatusChanged != null)
                    StatusChanged(String.Format("{0} already in use", Settings.Port.PortName), Settings.Port.PortName);
            }
            catch (Exception ex)
            {
                if (StatusChanged != null)
                    StatusChanged(String.Format("{0}", ex.ToString()), Settings.Port.PortName);
            }

            // Update the status
            if (_serialPort.IsOpen)
            {
                string p = _serialPort.Parity.ToString().Substring(0, 1);   //First char
                string h = _serialPort.Handshake.ToString();
                if (_serialPort.Handshake == Handshake.None)
                    h = "no handshake"; // more descriptive than "None"
                if (StatusChanged != null)
                    StatusChanged(String.Format("{0}: {1} bps, {2}{3}{4}, {5}",
                    _serialPort.PortName, _serialPort.BaudRate,
                    _serialPort.DataBits, p, (int)_serialPort.StopBits, h), Settings.Port.PortName);

                switch (Settings.Option.AppendToSend)
                {
                    case AppendType.AppendCR:
                        lineEnding = "\r"; break;
                    case AppendType.AppendLF:
                        lineEnding = "\n"; break;
                    case AppendType.AppendCRLF:
                        lineEnding = "\r\n"; break;
                }
            }
            else
            {
                if (StatusChanged != null)
                    StatusChanged(String.Format("{0} already in use", Settings.Port.PortName), Settings.Port.PortName);
            }
        }
        /// <summary> Close the serial port. </summary>
        public void Close()
        {
            StopReading();
            _serialPort.Close();
            if (StatusChanged != null)
                StatusChanged("connection closed", Settings.Port.PortName);
        }
        /// <summary> Get the status of the serial port. </summary>
        public bool IsOpen
        {
            get
            {
                return _serialPort.IsOpen;
            }
        }
        /// <summary> Get a list of the available ports. Already opened ports
        /// are not returend. </summary>
        public static string[] GetAvailablePorts()
        {
            return SerialPort.GetPortNames();
        }
        /// <summary>Send data to the serial port after appending line ending. </summary>
        /// <param name="data">An string containing the data to send. </param>
        public void Send(string data)
        {
            if (IsOpen)
            {
                _serialPort.Write(data + lineEnding);
            }
        }
        public void SendBytes(byte[] data, int len)
        {
            if (IsOpen)
            {
                _serialPort.Write(data, 0, len);
            }
        }
        public void SendBytes(string data)
        {
            if (IsOpen)
            {
                if (data == null)
                {
                    throw new System.ArgumentException("Null Parameter Passed", "Data can not be null");
                }
                int len = 0;
                byte[] bdata = DataHelper.RawToByte(data, out len);
                _serialPort.Write(bdata, 0, len);
            }
        }
    }
}