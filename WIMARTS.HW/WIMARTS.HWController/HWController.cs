using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RedCommunication.SERIAL;
using System.Diagnostics;


namespace WIMARTS.HWController
{
    //public delegate void HandleDataReceived(string sNewMessage);

    public partial class HWControl
    {
        private CommPort com;
        private Watch ComWatch;

        public HWControl(string PortName)
        {
            com = new CommPort(WIMARTS.UTIL.SettingsPath.SettingDir, 1, PortName);

            //r
            //ComWatch = new Watch();
            //ComWatch.OnSendDataReq += new Watch.SendDataReqHandler(OnSendDataReqCB);
            //ComWatch.Show();
        }

        public bool Connect()
        {
            bool res = false;
            try
            {
                if (com != null && com.IsOpen == false)
                {
                    com.Open();
                    com.DataReceivedBytes += new CommPort.EventHandlerBytes(OnComDataReceived);
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

        internal bool SendCommand(string command)
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
            return res;
        }
        byte[] bufferStack = new byte[1024];
        int bufferStackCnt = 0;

        void OnComDataReceived(byte[] buffer, int count, string PortName, int index)
        {
            try
            {
                if (count < 1)
                    return;
                string bufRcv = string.Empty; ;
                for (int i = 0; i < count; i++)
                {
                    bufRcv += String.Format("{0:X2} ", buffer[i]);
                }

                for (int i = 0; i < count; i++)
                {
                    if (buffer[i] == 0xFE)//#
                    {
                        bufferStackCnt = 0;
                        bufferStack[bufferStackCnt++] = buffer[i];
                        continue;
                    }
                    if (buffer[i] == 0xFF)//$
                    {
                        int cmdType = Convert.ToInt32(bufferStack[bufferStackCnt - 2]);// IntVal(bufferStack[bufferStackCnt - 2].ToString());
                        int buff = Convert.ToInt32(bufferStack[bufferStackCnt - 1]);//IntVal(buffer[2].ToString());
                        //Setting Command
                        if (cmdType == 1)
                            PrinterFeedback(ControllerEVENTS.DRESET, buff.ToString());
                        else if (cmdType == 2)
                            PrinterFeedback(ControllerEVENTS.DMODESTART, buff.ToString());
                        else if (cmdType == 3)
                            PrinterFeedback(ControllerEVENTS.DCAMTRIGGER, buff.ToString());
                        else if (cmdType == 4)
                            PrinterFeedback(ControllerEVENTS.DCAMPULSE, buff.ToString());
                        else if (cmdType == 5)
                            PrinterFeedback(ControllerEVENTS.DCONDIR, buff.ToString());
                        else if (cmdType == 6)
                            PrinterFeedback(ControllerEVENTS.DERRACT, buff.ToString());

                        //HW Commands
                        else if (cmdType == 21)
                            PrinterFeedback(ControllerEVENTS.CCAMTRIGGER, buff.ToString());
                        else if (cmdType == 22)
                            PrinterFeedback(ControllerEVENTS.CEJTRIGGER, buff.ToString());
                        else if (cmdType == 23)
                            PrinterFeedback(ControllerEVENTS.CERRORSTOPINDIC, buff.ToString());
                        else if (cmdType == 24)
                            PrinterFeedback(ControllerEVENTS.CSTARTBTNPRESS, buff.ToString());

                        //Application Commands
                        else if (cmdType == 41)
                            PrinterFeedback(ControllerEVENTS.ASTARTINSP, buff.ToString());
                        else if (cmdType == 42)
                            PrinterFeedback(ControllerEVENTS.ASTOPINSP, buff.ToString());
                        else if (cmdType == 43)
                            PrinterFeedback(ControllerEVENTS.ACAMRESPONSE, buff.ToString());

                    //App Test Mode
                        else if (cmdType == 61)
                            PrinterFeedback(ControllerEVENTS.TMODESTART, buff.ToString());
                        else if (cmdType == 62)
                            PrinterFeedback(ControllerEVENTS.TCAMTRIGGER, buff.ToString());
                        else if (cmdType == 63)
                            PrinterFeedback(ControllerEVENTS.TCAMPULSE, buff.ToString());
                        else if (cmdType == 64)
                            PrinterFeedback(ControllerEVENTS.TCAMSTART, buff.ToString());
                        else if (cmdType == 65)
                            PrinterFeedback(ControllerEVENTS.TCAMSTOP, buff.ToString());
                        else if (cmdType == 66)
                            PrinterFeedback(ControllerEVENTS.TSTARTCONV, buff.ToString());
                        else if (cmdType == 67)
                            PrinterFeedback(ControllerEVENTS.TSTOPCONV, buff.ToString());
                        else if (cmdType == 68)
                            PrinterFeedback(ControllerEVENTS.TSTARTBUZZ, buff.ToString());
                        else if (cmdType == 69)
                            PrinterFeedback(ControllerEVENTS.TSTOPBUZZ, buff.ToString());
                        else if (cmdType == 70)
                            PrinterFeedback(ControllerEVENTS.TBTCTETON, buff.ToString());
                        else if (cmdType == 100)
                            PrinterFeedback(ControllerEVENTS.TMODESTART, buff.ToString());

                        bufferStackCnt = 0;
                        continue;
                    }
                    bufferStack[bufferStackCnt] = buffer[i];
                    bufferStackCnt++;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Data receiving error: {1}", DateTime.Now, ex.Message);
            }
        }

        private event EventHandler _HWControllerFeedbackEvent;
        public event EventHandler OnHWControllerFeedback
        {
            add
            {
                if (_HWControllerFeedbackEvent != null)
                {
                    lock (_HWControllerFeedbackEvent)
                    {
                        _HWControllerFeedbackEvent += value;
                    }
                }
                else
                {
                    _HWControllerFeedbackEvent = new EventHandler(value);
                }
            }
            remove
            {
                if (_HWControllerFeedbackEvent != null)
                {
                    lock (_HWControllerFeedbackEvent)
                    {
                        _HWControllerFeedbackEvent -= value;
                    }
                }
            }
        }

        public void PrinterFeedback(ControllerEVENTS e, string data)
        {
            EventHandler handler = _HWControllerFeedbackEvent;
            if (handler != null)
            {
                ControllerArgs CtrlEvents = new ControllerArgs();
                CtrlEvents.rcvdEvents = e;
                CtrlEvents.data = data;
                handler(this, CtrlEvents);
            }
        }

        #region COMMANDS
        /// <summary>
        /// Data Setting Commands
        /// </summary>
        #region Data Setting Commands
        public void DRESET()
        {
            string cmd = HWCommands.SHT + HWCommands.DRESET + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void DMODESTART()
        {
            string cmd = HWCommands.SHT + HWCommands.DMODESTART + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }

        public void DCAMTRIGGER(int Value)
        {
            string cmd = HWCommands.SHT + HWCommands.DCAMTRIGGER + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void DCAMPULSE(int Value)
        {
            string cmd = HWCommands.SHT + HWCommands.DCAMPULSE + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void DCONDIR(int Value)
        {
            string cmd = HWCommands.SHT + HWCommands.DCONDIR + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void DERRACT(int Value)
        {
            string cmd = HWCommands.SHT + HWCommands.DERRACT + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        #endregion Data Setting Commands

        /// <summary>
        /// Application Commands
        /// </summary>
        #region Application Commands
        public void ASTARTINSP()
        {
            string cmd = HWCommands.SHT + HWCommands.ASTARTINSP + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void ASTOPINSP()
        {
            string cmd = HWCommands.SHT + HWCommands.ASTOPINSP + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void ACAMRESPONSE(int Value, bool IsGood)//IsGood =0/1
        {
            string cmd = string.Empty;
            if (IsGood == true)
            {
                Value += 80;
                cmd = HWCommands.SHT + HWCommands.ACAMRESPONSE + "$" + Value + HWCommands.EHT;
            }
            else
            {
                cmd = HWCommands.SHT + HWCommands.ACAMRESPONSE + "$0" + Value + HWCommands.EHT;
            }
            SendCommand(cmd);
        }
        #endregion Application Commands

        /// <summary>
        /// Application Test Mode Commands
        /// </summary>
        /// <param name="Value"></param>
        /// <returns></returns>
        #region App Test Mode
        public void TMODESTART()
        {
            string cmd = HWCommands.SHT + HWCommands.TMODESTART + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TCAMTRIGGER(int Value)
        {
            string cmd = HWCommands.SHT + HWCommands.TCAMTRIGGER + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TCAMPULSE(int Value)
        {
            string cmd = HWCommands.SHT + HWCommands.TCAMPULSE + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TCAMSTART()
        {
            string cmd = HWCommands.SHT + HWCommands.TCAMSTART + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TCAMSTOP()
        {
            string cmd = HWCommands.SHT + HWCommands.TCAMSTOP + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TSTARTCONV(int Value)//value:direction
        {
            string cmd = HWCommands.SHT + HWCommands.TSTARTCONV + HexVal(Value) + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TSTOPCONV()
        {
            string cmd = HWCommands.SHT + HWCommands.TSTOPCONV + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TSTARTBUZZ()
        {
            string cmd = HWCommands.SHT + HWCommands.TSTARTBUZZ + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TSTOPBUZZ()
        {
            string cmd = HWCommands.SHT + HWCommands.TSTOPBUZZ + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }
        public void TBTCTETON()
        {
            string cmd = HWCommands.SHT + HWCommands.TBTCTETON + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }

        #endregion App Test Mode
        public void CURRENTMODEEXIT()
        {
            string cmd = HWCommands.SHT + HWCommands.CURRENTMODEEXIT + "$00" + HWCommands.EHT;
            SendCommand(cmd);
        }


        private string HexVal(int Value)
        {
            string retVal = string.Empty;
            byte[] bt = new byte[1];

            string HxStr = string.Format("{0:X}", Value);
            if (HxStr.Length < 2)
                HxStr = "0" + HxStr;
            retVal = "$" + HxStr;
            return retVal;
        }
        private int IntVal(string Value)
        {
            int intAgain = int.Parse(Value, System.Globalization.NumberStyles.HexNumber);
            return intAgain;
        }
        #endregion COMMANDS

        #region Watch
        private void OnSendDataReqCB(string data2Send)
        {
            SENDnUPDATEcmd(data2Send, "Data Request");
        }

        private bool SENDnUPDATEcmd(string cmdvalue, string cmd)
        {
            try
            {
                if (com.IsOpen == true)
                {
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    long start = DateTime.Now.Ticks;
                    // com.Send(cmdvalue);
                    long end = DateTime.Now.Ticks;
                    sw.Stop();
                    long endMs = sw.ElapsedMilliseconds;// iPeT.SysConfig.Utils.GetTimeDiff_US(sw);
                    if (ComWatch != null && ComWatch.Visible == true)
                    {
                        ComWatch.UpdatePerform(com.Name, "OUT-" + endMs, cmdvalue, cmd, start, end);
                    }
                    return true;
                }
                else
                {
                    if (ComWatch != null && ComWatch.Visible == true)
                    {
                        ComWatch.UpdatePerform(com.Name + "-CLOSE", "OUT", cmdvalue, cmd, 0, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1}{2}{3}", DateTime.Now.ToString(), " CMD = " + cmd + " Port = " + com.Settings.Port.PortName, ex.Message, ex.StackTrace);
            }
            return false;
        }
        #endregion Watch
    }
    public class ControllerArgs : EventArgs
    {
        public ControllerEVENTS rcvdEvents;
        public string data;
    }
    public enum ControllerEVENTS
    {
        //Controller Setting command Response events
        DRESET,
        DMODESTART,
        DCAMTRIGGER,
        DCAMPULSE,
        DCONDIR,
        DERRACT,

        //Controller Response events
        CCAMTRIGGER,
        CEJTRIGGER,
        CERRORSTOPINDIC,
        CSTARTBTNPRESS,

        //Application command response events
        ASTARTINSP,
        ASTOPINSP,
        ACAMRESPONSE,

        //Test Mode command Responses
        TMODESTART,
        TCAM,
        TCAMTRIGGER,
        TCAMPULSE,
        TCAMSTART,
        TCAMSTOP,
        TSTARTCONV,
        TSTOPCONV,
        TSTARTBUZZ,
        TSTOPBUZZ,
        TBTCTETON,

        CURRENTMODEEXIT,
    }
}