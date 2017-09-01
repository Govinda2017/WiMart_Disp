using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedCommunication;
using RedCommunication.TCP;
using System.Diagnostics;
using WIMARTS.UTIL;

namespace WIMARTS.INSPECTION
{
    public class Baumer : IRedInspection
    {
        string Address = "192.168.0.10";int Port = 9876;

        private TCPClLibAsynch socketMgrData;

        private static List<string> sensorHost;

        Object UIdispOb = null;

        static bool HasSubscribed = false;

        protected delegate void HandleInitiateConnectionDelegate(int id, bool bSuccess);
        protected delegate void HandleDisconnectDelegate(int id);
        protected delegate void HandleInputDelegate(int id, string msg);

        protected void HandleInitiateConnection(int id, bool bSuccess)
        {
        
            Trace.TraceInformation("{0},HandleInitiateConnection called for ID={1} bSuccess={2}", DateTime.Now.ToString(), id, bSuccess);
          
        }
        protected void HandleDisconnect(int id)
        {
            Trace.TraceInformation("{0},HandleDisconnect called for ID={1}{2}", DateTime.Now.ToString(), id, "");
            // Here Connection disconnected with ID will receive... Need to Pass this to UI Thread
        }
        protected void HandleInput(int id, string DataRcvd)
        {
            if (DataRcvd.Length < 1)
                return;
            InspectionArgs Args = new InspectionArgs();
            //In case if data is not scanned, so camera returns the |'| only.. if it is scanned then it will return only data..
            Trace.TraceInformation("{0}, {1}, Data Received from Camera: {2}", DateTime.Now, DateTime.Now.Ticks, DataRcvd);
            List<string> msgsList = GetAllMessages(DataRcvd);
         
            if (msgsList.Count > 0)
            {
                DataRcvd = DataRcvd.Replace("|'|", "");
                DataRcvd = DataRcvd.Replace("\r", "");
                Args.Result = DataRcvd + "\n";
                Args.ImageResult = new System.Drawing.Bitmap(100, 100);
                Args.rcvdEvent = InspectionEVENTS.ResultArrived;
                InspectionFeedback(Args);
            }


            //if (DataRcvd.StartsWith("|'|") == true && DataRcvd.EndsWith("\r") == true)
            //{
            //    DataRcvd = DataRcvd.Replace("|'|", "");
            //    DataRcvd = DataRcvd.Replace("\r", "");
            //    Args.Result = DataRcvd + "\n";
            //    Args.ImageResult = new System.Drawing.Bitmap(100, 100);
            //    Args.rcvdEvent = InspectionEVENTS.ResultArrived;
            //    InspectionFeedback(Args);
            //}
        }

        private List<string> GetAllMessages(string content)
        {
            List<string> msgsList = new List<string>();

            string[] messages = content.Split(new string[] { "\r" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string msg in messages)
            {
                //  Trace.TraceInformation("{0},Camera Data received {1}", DateTime.Now.ToString(), msg);
                if (string.IsNullOrEmpty(msg) == false && msg.StartsWith("|'|") == true)
                {
                    msgsList.Add(msg);
                }
            }

            return msgsList;
        }

        public string deviceName
        {
            get { return "Baumer"; }
        }

        public Baumer(string oAddress, int oPort)
        {
            //_DeviceDetails = Insp;
            Address = oAddress; Port = oPort;
            socketMgrData = new TCPClLibAsynch(new TCPClLibAsynch.OnConnectDelegate(HandleInitiateConnection), new TCPClLibAsynch.OnDisconnectDelegate(HandleDisconnect), new TCPClLibAsynch.OnReceiveStringDelegate(HandleInput));
       
        }

        public void Init()
        {
            //LoadScene(1);
        }

        public bool Connect()
        {
            bool res = false;
            if (socketMgrData != null)
            {
                int socID = -1;
                if (socketMgrData.IsConnected == false)
                {
                    socketMgrData = new TCPClLibAsynch(new TCPClLibAsynch.OnConnectDelegate(HandleInitiateConnection), new TCPClLibAsynch.OnDisconnectDelegate(HandleDisconnect), new TCPClLibAsynch.OnReceiveStringDelegate(HandleInput));

                    socID = socketMgrData.Connect(Address, Port);
                }
                if (socID != -1)
                    res = true;
               // LoadScene(1);//Temporary default 1
                InspectionArgs Args = new InspectionArgs();
                Args.rcvdEvent = InspectionEVENTS.Connected;
                InspectionFeedback(Args);
            }
            return res;
        }

        public bool Disconnect()
        {
            bool res = false;
            if (socketMgrData != null)
            {
                socketMgrData.Disconnect();
                res = true;
            }
            return res;
        }

        public void SubScribeDevice()
        {
            HasSubscribed = true;           
        }

        public void DeSubScribeDevice()
        {
          
        }               

        public string SENDcmd(string DataToSend)
        {
            if (socketMgrData != null && socketMgrData.IsConnected == true)
            {
                int len = 0;
                byte[] data = DataHelper.RawToByte(DataToSend, out len);
                socketMgrData.SendMessage(data, len);
                Trace.TraceInformation("{0}, Data sent to Camera: {1}", DateTime.Now, DataToSend);
            }
            return DataToSend;
        }

        public void Init(object ImgDisp, object UI_dispOb)
        {
            UIdispOb = UI_dispOb;
        }

        public List<string> GetDevices()
        {
            List<string> lDevice = new List<string>();
            lDevice.Add("Baumer");
            return lDevice;
        }

        public string[] GetJFileList()
        {
            string[] rr = new string[2];
            rr[0] = "0";
            return rr;
        }      

     
     
        public void SoftTrigger()
        {
            
        }

        public bool IsConnected()
        {
            return socketMgrData.IsConnected;
        }

        public bool IsLiveMode()
        {
            return socketMgrData.IsConnected;
        }

        public string GetActiveJobFile()
        {           
            return "0";
        }

        #region EVENT_HANDLING
        public event EventHandler OnInspectionFeedback;
        event EventHandler IRedInspection.OnInspectionFeedback
        {
            add
            {
                if (OnInspectionFeedback != null)
                {
                    lock (OnInspectionFeedback)
                    {
                        OnInspectionFeedback += value;
                    }
                }
                else
                {
                    OnInspectionFeedback = new EventHandler(value);
                }
            }
            remove
            {
                if (OnInspectionFeedback != null)
                {
                    lock (OnInspectionFeedback)
                    {
                        OnInspectionFeedback -= value;
                    }
                }
            }
        }

        public void InspectionFeedback(InspectionArgs Args)
        {
            EventHandler handler = OnInspectionFeedback;

            if (handler != null)
            {
                handler(this, Args);
            }
        }
        public void InspectionFeedback(InspectionEVENTS rcvdEvent, string Result)
        {
            EventHandler handler = OnInspectionFeedback;
            if (handler != null)
            {
                InspectionArgs cmd = new InspectionArgs();
                cmd.rcvdEvent = rcvdEvent;
                cmd.Result = Result;
                cmd.ImageResult = new System.Drawing.Bitmap(100, 100);
                handler(this, cmd);
            }
        }
        #endregion END_EVENT_HANDLING
    }
}
