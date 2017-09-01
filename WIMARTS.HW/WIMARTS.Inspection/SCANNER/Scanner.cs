using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedCommunication;
using RedCommunication.SERIAL;
using System.Diagnostics;

namespace WIMARTS.INSPECTION
{
    public class Scanner : IRedInspection
    {
       
        private CommPort com;
        string PortName = "";
        public string deviceName
        {
            get { return "Scanner"; }
        }

        public Scanner(string oPortName)
        { 
            PortName = oPortName;
            com = new CommPort(WIMARTS.UTIL.SettingsPath.SettingDir, 1, oPortName);
            com.DataReceived += new CommPort.EventHandler(OnComDataReceived);
        }

        public void Init()
        {           
        }

        public void SetSymbology(List<UTIL.TemplateFields> templateScema)
        {           
        }

        public bool Connect()
        {
            bool res = false;
            try
            {
                if (com != null && com.IsOpen == false)
                {
                    com.Open();
                    res = true;
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public bool Disconnect()
        {
            bool res = true;
            try
            {
                if (com != null && com.IsOpen == true)
                    com.Close();
                //ComWatch.Close();
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public bool IsConnected()
        {
            if (com != null)
                return com.IsOpen;
            else
                return false;
        }

        public string SendCmd(string command)
        {
            bool res = true;
            try
            {
                // System.Threading.Thread.Sleep(100);
                if (com != null && com.IsOpen == true)
                    com.SendBytes(command);
                Trace.TraceInformation("{0}, Data sent from Application: {1}", DateTime.Now, command);

            }
            catch
            {
                res = false;
            }
            return command;
        }

        byte[] bufferStack = new byte[1024];
        int bufferStackCnt = 0;

        void OnComDataReceived(string DataRcvd, string PortName, int index)
        {
            try
            {
                if (DataRcvd.Length < 1)
                    return;
                Trace.TraceInformation("{0}, Data received from Scanner: {1}", DateTime.Now, DataRcvd);
                if (DataRcvd.EndsWith("\r") == true)
                {
                    InspectionArgs Args = new InspectionArgs();
                    Args.Result = DataRcvd + "\n";
                    Args.ImageResult = new System.Drawing.Bitmap(100, 100);
                    Args.rcvdEvent = InspectionEVENTS.ResultArrived;
                    InspectionFeedback(Args);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Data receiving error: {1}", DateTime.Now, ex.Message);
            }
        }
        //void OnComDataReceived(byte[] buffer, int count, string PortName, int index)
        //{
        //    try
        //    {
        //        if (count < 1)
        //            return;
        //        string bufRcv = string.Empty; ;
        //        for (int i = 0; i < count; i++)
        //        {
        //            bufRcv += String.Format("{0:X2} ", buffer[i]);
        //        }

        //        for (int i = 0; i < count; i++)
        //        {
        //            //if (buffer[i] == 0x23)//#
        //            //{
        //            //    bufferStackCnt = 0;
        //            //    bufferStack[bufferStackCnt++] = buffer[i];
        //            //    continue;
        //            //}
        //            if (buffer[i] == 0x0D)//$
        //            {
        //                string buff = System.Text.Encoding.ASCII.GetString(bufferStack, 0, bufferStackCnt);
        //                Trace.TraceInformation("{0}, Data received from Scanner: {1}", DateTime.Now, buff);
        //                if (buff.Length > 2)
        //                {

        //                }
        //                bufferStackCnt = 0;
        //                continue;
        //            }
        //            bufferStack[bufferStackCnt] = buffer[i];
        //            bufferStackCnt++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Trace.TraceError("{0}, Data receiving error: {1}", DateTime.Now, ex.Message);
        //    }
        //}

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

        public System.Drawing.Image GetBitMap()
        {
            System.Drawing.Image img = new System.Drawing.Bitmap(100, 100);
            return img;
        }

        public void SubScribeDevice()
        {
            
        }

        public void DeSubScribeDevice()
        {
        }
    }
}
