using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using RedCommunication;
using RedCommunication.SERIAL;
using RedCommunication.TCP;
using rSys;
using RedXML;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Drawing;

namespace rcs.CONTROLS
{
    public class PLCHWController
    {
        private redTrace oTrace = new redTrace(false, "PLCHWController");

        #region PRIVATE MEMBERS


        #endregion PRIVATE MEMBERS

        #region PLC HANDLING & COMMUNICATION

        PLCProtocol oProto = new PLCProtocol("00");

        private RCUtils.CONNECTAS mCONNECTas = RCUtils.CONNECTAS.SERIAL_COM;
        private string mPRIMARYaddress = string.Empty;
        private int mSECONDARYaddress = 399;

        public PLCHWController(RCUtils.CONNECTAS oCONNECTAS, string oPRIMARYaddress, int oSECONDARYaddress)
        {
            ConstructorCode(oCONNECTAS, oPRIMARYaddress, oSECONDARYaddress);
        }
        public PLCHWController(string CONNECTAS, string oPRIMARYaddress, int oSECONDARYaddress)
        {
            ConstructorCode(CONNECTAS, oPRIMARYaddress, oSECONDARYaddress);
        }
        void ConstructorCode(string CONNECTAS, string oPRIMARYaddress, int oSECONDARYaddress)
        {
            RCUtils.CONNECTAS oCONNECTAS = RCUtils.CONNECTAS.SERIAL_COM;
            if (CONNECTAS == "TCP")
                oCONNECTAS = RCUtils.CONNECTAS.TCP_IP;
            else
                oCONNECTAS = RCUtils.CONNECTAS.SERIAL_COM;
            ConstructorCode(oCONNECTAS, oPRIMARYaddress, oSECONDARYaddress);
        }
        void ConstructorCode(RCUtils.CONNECTAS oCONNECTAS, string oPRIMARYaddress, int oSECONDARYaddress)
        {
            InitTimer(PLCRegister.MsgSendGap);

            oTrace.AddTrace(redTrace.Level.Information, string.Format("Ejection Config @ {0}, Fail: {1}, Pass: {2} with Gap: {3} ", PLCRegister.Oper_Ejection, PLCRegister.Oper_Ejection_FAIL, PLCRegister.Oper_Ejection_PASS, PLCRegister.MsgSendGap));

            mCONNECTas = oCONNECTAS;
            mPRIMARYaddress = oPRIMARYaddress;
            mSECONDARYaddress = oSECONDARYaddress;

            if (mCONNECTas == RCUtils.CONNECTAS.SERIAL_COM)
            {
                com = new CommPort("PCH.UTIL.SettingsPath.SettingDir", 1, mPRIMARYaddress);
                com.DataReceivedBytes += new CommPort.EventHandlerBytes(OnComDataReceiveB);//TBD: Test & Move this line after con creation ... post com = new CommPort(
            }
            else if (mCONNECTas == RCUtils.CONNECTAS.TCP_IP)
            {
                socketMgrData = new TCPClLibAsynch(new TCPClLibAsynch.OnConnectDelegate(OnHandleInitiateConnection), new TCPClLibAsynch.OnDisconnectDelegate(OnHandleDisconnect), new TCPClLibAsynch.OnReceiveStringDelegate(OnHandleInput));
                socketMgrData.ConnectorName = "PLCHWController";
            }
            else
            {
                throw new Exception("Invalid Connection Type Provided as " + mCONNECTas.ToString());
            }
        }

        #region __SERIAL_COM_CONNECTION__

        private CommPort com;

        void OnComDataReceiveB(byte[] buffer, int bufLen, string PortName, int index)
        {
            if (bufLen < 1)
                return;
            /*
            string bufRcv = string.Empty;
            for (int i = 0; i < bufLen; i++)
            {
                bufRcv += String.Format("{0:X2} ", buffer[i]);
            }
            //oTrace.AddTrace(redTrace.Level.Information, string.Format("DATA from HWC CountRCVD: {0} {1:X2} {2:X2} {3:X2} {4:X2} {5:X2}", count, buffer[0], buffer[1], buffer[2], buffer[3], buffer[4]);
            oTrace.AddTrace(redTrace.Level.Information,string.Format("DATA from HWC CountRCVD:{0} Data: {1}", bufLen, bufRcv));
            //*/

            string DataRcvd = System.Text.Encoding.Default.GetString(buffer, 0, bufLen);
            HandleInput(DataRcvd);
        }

        #endregion __SERIAL_COM_CONNECTION__

        #region __TCP_IP_CONNECTION__

        private TCPClLibAsynch socketMgrData;

        protected delegate void HandleInitiateConnectionDelegate(int id, bool bSuccess);
        protected delegate void HandleDisconnectDelegate(int id);
        protected delegate void HandleInputDelegate(int id, string msg);

        protected void OnHandleInitiateConnection(int id, bool bSuccess)
        {
            oTrace.AddTrace(redTrace.Level.Information, string.Format("{0},HandleInitiateConnection called for ID={1} bSuccess={2}", DateTime.Now.ToString(), id, bSuccess));
            if (bSuccess == true)
                HWCFeedback(HWState.Connected, "Connected", null);
            else
                HWCFeedback(HWState.Disconnected, "Failed to Connect", null);
        }
        protected void OnHandleDisconnect(int id)
        {
            oTrace.AddTrace(redTrace.Level.Information, string.Format("{0},HandleDisconnect called for ID={1}{2}", DateTime.Now.ToString(), id, ""));
            HWCFeedback(HWState.Disconnected, "Disconneced", null);
        }
        protected void OnHandleInput(int id, string DataRcvd)
        {
            if (string.IsNullOrEmpty(DataRcvd) == true || DataRcvd.Length < 1)
                return;
            //byte[] bDataRcvd = System.Text.Encoding.Default.GetBytes(DataRcvd.ToCharArray());
            //int dataLen = DataRcvd.Length;

            HandleInput(DataRcvd);
        }

        #endregion __TCP_IP_CONNECTION__

        #region INCOMING DATA MANAGEMENT

        private StringBuilder sbIncomingBuf = new StringBuilder();
        private List<string> IncomingBuffList = new List<string>();

        private void HandleInput(string msg)
        {
            sbIncomingBuf.Append(msg);
            String dataRcvd = String.Empty;
            dataRcvd = sbIncomingBuf.ToString();

            if (dataRcvd.Length > 0)
            {
                bool hasValidData = false;
                //oTrace.AddTrace(redTrace.Level.Information, string.Format("{0},HandleInput Input Buffer:{1}", DateTime.Now.ToString(), msg));
                string remain = "";
                GetAllMessages(dataRcvd, ref remain);
                foreach (string buff in IncomingBuffList)
                {
                    string buf2Process = oProto.GetValidBuffer(buff);
                    if (string.IsNullOrEmpty(buf2Process) == true)
                    {
                        HWCFeedback(HWState.Connected, "INVALID PLC DATA RECEIVE", buff);
                        break; ;
                    }
                    HandleIncomingData(buf2Process);
                    hasValidData = true;
                }
                if (hasValidData == false)
                    HWCFeedback(HWState.Connected, "INVALID PLC DATA RECEIVE", dataRcvd);

                IncomingBuffList.Clear();
                sbIncomingBuf.Remove(0, sbIncomingBuf.Length);
                if (remain.Length > 0)
                    sbIncomingBuf.Append(remain);
            }
        }
        void GetAllMessages(string content, ref string remain)
        {
            if (content.Length < oProto.MinMessageLength)
            {
                remain = content;
            }
            else
            {
                while (content.Length >= oProto.MinMessageLength)
                {
                    int startpos = content.IndexOf(oProto.SoH);
                    int endpos = content.IndexOf(oProto.EoH);

                    ///As both are -1 means invalid buffer has reached, clear it....
                    if (startpos == -1 && endpos == -1)
                    {
                        remain = content = string.Empty;
                        continue;
                    }
                    if (startpos == -1 && endpos >= 0)
                    {///Means Wrong Buffer.....Truncate till endpos and revalidate
                        content = content.Substring(endpos + oProto.EoH.Length);
                        continue;
                    }
                    if (startpos == -1)
                    {
                        remain = content;
                        content = "";
                    }
                    else
                    {
                        if (endpos == -1)
                        {
                            remain = content;
                            content = "";
                        }
                        else if (endpos == 0)
                        {
                            content = content.Substring(oProto.EoH.Length);
                            continue;
                        }
                        else
                        {
                            int bufLen = endpos - startpos;
                            if (bufLen < 0)
                            {
                                content = content.Substring(endpos + oProto.EoH.Length);
                            }
                            else if (bufLen < 3)
                            {
                                remain = content;
                                content = string.Empty;
                            }
                            else
                            {
                                string msgData = content.Substring(startpos, bufLen);
                                IncomingBuffList.Add(msgData);
                                content = content.Substring(startpos + bufLen + oProto.EoH.Length);
                            }
                        }
                    }
                }
            }
        }
        void HandleIncomingData(string buf2Process)
        {
            oTrace.AddTrace(redTrace.Level.Information, string.Format("{0},HandleIncomingData: {1}", DateTime.Now.ToString(), buf2Process));
            //"@00RD0000450000006455*"

            int bufLenProcessed = oProto.SoH.Length;
            string icPLCNo = buf2Process.Substring(bufLenProcessed, oProto.PLCNo.Length); bufLenProcessed += oProto.PLCNo.Length;
            string icRegOperType = buf2Process.Substring(bufLenProcessed, PLCProtocol.RegParamTypeLen); bufLenProcessed += PLCProtocol.RegParamTypeLen;
            string PLCResp = buf2Process.Substring(bufLenProcessed, PLCProtocol.PLCCmdExecRespLen); bufLenProcessed += PLCProtocol.PLCCmdExecRespLen;

            if (icPLCNo.Equals(oProto.PLCNo) == false)
            {
                HWCFeedback(HWState.Connected, "INVALID PLC Resp", buf2Process);
            }
            else if (icRegOperType.Equals(LastSendData2PLC.PLCRegOperationType) == false)
            {
                HWCFeedback(HWState.Connected, "WRONG PLC Operation Received", buf2Process);
            }
            else if (PLCResp == PLCProtocol.PLCRespCode_SUCCESS)
            {
                if (LastSendData2PLC.PLCRegOperationType == PLCProtocol.RegisterValRead)
                {
                    int remnLen = buf2Process.Length - bufLenProcessed - (PLCProtocol.BufferCheckSumLen + oProto.EoHPrefix.Length);
                    string icRegValues = buf2Process.Substring(bufLenProcessed, remnLen);
                    if (icRegValues.Length != LastSendData2PLC.RDRegsCount * PLCProtocol.PLCRegValueLen)
                    {
                        HWCFeedback(HWState.Connected, "WRONG VALUES RECEIVED FROM PLC", buf2Process);
                    }
                    else
                    {
                        List<RegWithValue> readValues = new List<RegWithValue>();
                        int nLastSendRegister = Convert.ToInt32(LastSendData2PLC.RegisterID);
                        bool bRDRegsCountReadAsSingle = LastSendData2PLC.RDRegsCountReadAsSingle;
                        if (bRDRegsCountReadAsSingle == true)
                        {
                            string Register = (nLastSendRegister).ToString().PadLeft(PLCProtocol.PLCRegValueLen, '0');
                            string regVal = icRegValues;

                            RegWithValue oRegWithValue = new RegWithValue(Register, regVal);
                            readValues.Add(oRegWithValue);
                        }
                        else
                        {
                            for (int i = 0; i < LastSendData2PLC.RDRegsCount; i++)
                            {
                                string Register = (nLastSendRegister + i).ToString().PadLeft(PLCProtocol.PLCRegValueLen, '0');
                                string regVal = icRegValues.Substring(i * PLCProtocol.PLCRegValueLen, PLCProtocol.PLCRegValueLen);

                                RegWithValue oRegWithValue = new RegWithValue(Register, regVal);
                                readValues.Add(oRegWithValue);
                            }
                        }
                        HWCFeedback(HWState.Connected, "Read Success", readValues, buf2Process);
                    }
                }
                else if (LastSendData2PLC.PLCRegOperationType == PLCProtocol.RegisterValWrite)
                {
                    List<RegWithValue> writeValues = new List<RegWithValue>();
                    int nLastSendRegister = Convert.ToInt32(LastSendData2PLC.RegisterID);
                    for (int i = 0; i < LastSendData2PLC.RDRegsCount; i++)
                    {
                        string Register = (nLastSendRegister + i).ToString().PadLeft(PLCProtocol.PLCRegValueLen, '0');
                        string regVal = LastSendData2PLC.RegisterValue.ToString("0000");

                        RegWithValue oRegWithValue = new RegWithValue(Register, regVal);
                        writeValues.Add(oRegWithValue);
                    }
                    HWCFeedback(HWState.Connected, "Write Success", writeValues, buf2Process);
                }
            }
            else
            {
                HWCFeedback(HWState.Connected, PLCResp, buf2Process);
            }

        }

        #endregion INCOMING DATA MANAGEMENT

        #region OUTGOING DATA MANAGEMENT

        PLCSendData LastSendData2PLC = new PLCSendData();
        private void SendMessage2HWC(string msg2send)
        {
            if ((IsHWCConnected() == true) && msg2send != null)
            {
                int len = 0;
                byte[] data = DataHelper.RawToByte(msg2send, out len);

                if (mCONNECTas == RCUtils.CONNECTAS.SERIAL_COM)
                {
                    com.SendBytes(data, len);
                }
                else if (mCONNECTas == RCUtils.CONNECTAS.TCP_IP)
                {
                    socketMgrData.SendMessage(data, len);
                }
                else
                {
                    throw new Exception("Invalid Connection Type Provided as " + mCONNECTas.ToString());
                }
                string bufSent = string.Empty;
                /*
                for (int i = 0; i < len; i++)
                {
                    bufSent += String.Format("{0:X2} ", data[i]);
                }                
                oTrace.AddTrace(redTrace.Level.Information, string.Format("Sent Data : {0}", bufSent));
                /*/
                oTrace.AddTrace(redTrace.Level.Information, string.Format("{0}Sent Data : {1}", DateTime.Now.ToString(), msg2send));
                //*/
            }
        }

        Queue<PLCSendData> qMsgs4Ejection = new Queue<PLCSendData>();
        Queue<PLCSendData> qMsgs2Send = new Queue<PLCSendData>();
        void QueueInMessage(bool isEjectionSignal, PLCSendData oData2PLC)
        {
            if (isEjectionSignal == true)
                qMsgs4Ejection.Enqueue(oData2PLC);
            else
                qMsgs2Send.Enqueue(oData2PLC);

            TimerAction();
        }

        private System.Timers.Timer timerSend;
        bool hasTimerStarted = false;

        void InitTimer(int timeInMiliSec)
        {
            timerSend = new System.Timers.Timer();
            timerSend.Interval = timeInMiliSec;
            timerSend.Elapsed += new System.Timers.ElapsedEventHandler(timerSend_Elapsed);
            timerSend.AutoReset = false;
        }
        void TimerAction()
        {
            if (hasTimerStarted == false)
            {
                timerSend.Start();
                hasTimerStarted = true;
            }
        }
        void timerSend_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PLCSendData msg2Send = null;
            if (qMsgs4Ejection.Count > 0)
            {
                msg2Send = qMsgs4Ejection.Dequeue();
            }
            else if (qMsgs2Send.Count > 0)
            {
                msg2Send = qMsgs2Send.Dequeue();
            }

            if (msg2Send != null)
            {
                LastSendData2PLC = msg2Send;

                string commandBuf = oProto.GetMsgBuffer(msg2Send.PLCRegOperationType, msg2Send.RegisterID, msg2Send.RegisterValue);
                SendMessage2HWC(commandBuf);
            }

            if (qMsgs2Send.Count > 0)
                timerSend.Start();
            else
                hasTimerStarted = false;
        }

        #endregion OUTGOING DATA MANAGEMENT

        #endregion PLC HANDLING & COMMUNICATION

        #region IRedHWC Members

        public bool Connect()
        {
            bool res = false;
            try
            {
                oTrace.AddTrace(redTrace.Level.Information, string.Format("{0}, Connecting to {1} at {2} {3}", DateTime.Now.ToString(), mCONNECTas, mPRIMARYaddress, mSECONDARYaddress));
                if (mCONNECTas == RCUtils.CONNECTAS.SERIAL_COM)
                {
                    if (com != null && com.IsOpen == false)
                    {
                        com.Open();
                        //com.DataReceivedBytes += new CommPort.EventHandlerBytes(OnComDataReceiveB);//TBD: Test & Move this line after con creation ... post com = new CommPort(
                        if (IsHWCConnected() == true)
                            HWCFeedback(HWState.Connected, "Connected", null);
                        else
                            HWCFeedback(HWState.Disconnected, "Failed to Connect", null);

                        res = true;
                    }
                }
                else if (mCONNECTas == RCUtils.CONNECTAS.TCP_IP)
                {
                    if (socketMgrData != null)
                    {
                        int socID = -1;
                        if (socketMgrData.IsConnected == false)
                        {
                            socID = socketMgrData.Connect(mPRIMARYaddress, mSECONDARYaddress);
                        }
                        if (socID != -1)
                            res = true;
                    }
                }
                else
                {
                    throw new Exception("Invalid Connection Type Provided as " + mCONNECTas.ToString());
                }
            }
            catch (ObjectDisposedException ex)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                res = false;
            }
            catch (SocketException ex)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                res = false;
            }
            catch (Exception ex)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                res = false;
            }
            return res;
        }
        public bool DisConnect()
        {
            bool res = true;
            try
            {
                if (mCONNECTas == RCUtils.CONNECTAS.SERIAL_COM)
                {
                    if (com != null && com.IsOpen == true)
                        com.Close();
                    HWCFeedback(HWState.Disconnected, "Disconnected", null);
                }
                else if (mCONNECTas == RCUtils.CONNECTAS.TCP_IP)
                {
                    if (socketMgrData != null)
                        socketMgrData.Disconnect();
                }
                else
                {
                    throw new Exception("Invalid Connection Type Provided as " + mCONNECTas.ToString());
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public bool IsHWCConnected()
        {
            if (mCONNECTas == RCUtils.CONNECTAS.SERIAL_COM)
            {
                if (com == null)
                    return false;
                return com.IsOpen;
            }
            else if (mCONNECTas == RCUtils.CONNECTAS.TCP_IP)
            {
                if (socketMgrData == null)
                    return false;
                return socketMgrData.IsConnected;
            }
            else
            {
                throw new Exception("Invalid Connection Type Provided as " + mCONNECTas.ToString());
            }
        }

        public string GetSendMessage(string RegOperationType, string RegisterID, int ParamValueDecimal)
        {
            string commandBuf = oProto.GetMsgBuffer(RegOperationType, RegisterID, ParamValueDecimal);
            return commandBuf;
        }
        public bool SendMessage2Ejector(string RegOperationType, string RegisterID, int ParamValueDecimal)
        {
            bool res = false;

            if (IsHWCConnected() == true)
            {
                PLCSendData data2PLC = new PLCSendData(RegOperationType, RegisterID, ParamValueDecimal);
                QueueInMessage(true, data2PLC);
                res = true;
            }
            return res;
        }
        public bool SendMessage(string RegOperationType, string RegisterID, int ParamValueDecimal)
        {
            bool res = false;

            if (IsHWCConnected() == true)
            {
                PLCSendData data2PLC = new PLCSendData(RegOperationType, RegisterID, ParamValueDecimal);
                QueueInMessage(false, data2PLC);
                res = true;
            }
            return res;
        }
        public bool SendMessage(string RegOperationType, string RegisterID, int ParamValueDecimal, bool oRDRegsCountReadAsSingle)
        {
            bool res = false;

            if (IsHWCConnected() == true)
            {
                PLCSendData data2PLC = new PLCSendData(RegOperationType, RegisterID, ParamValueDecimal, oRDRegsCountReadAsSingle);
                QueueInMessage(false, data2PLC);
                res = true;
            }
            return res;
        }
        public bool SendMessage(string RegOperationType, string RegisterID, int ParamValueDecimal, out string commandBuf)
        {
            bool res = false;
            commandBuf = oProto.GetMsgBuffer(RegOperationType, RegisterID, ParamValueDecimal);
            if (IsHWCConnected() == true)
            {
                PLCSendData data2PLC = new PLCSendData(RegOperationType, RegisterID, ParamValueDecimal);
                QueueInMessage(false, data2PLC);
                res = true;
            }
            return res;
        }

        // Create an event from interface event
        event EventHandler HWCFeedbackEvent;
        public event EventHandler OnHWCFeedback
        {
            add
            {
                if (HWCFeedbackEvent != null)
                {
                    lock (HWCFeedbackEvent)
                    {
                        HWCFeedbackEvent += value;
                    }
                }
                else
                {
                    HWCFeedbackEvent = new EventHandler(value);
                }
            }
            remove
            {
                if (HWCFeedbackEvent != null)
                {
                    lock (HWCFeedbackEvent)
                    {
                        HWCFeedbackEvent -= value;
                    }
                }
            }
        }
        private void HWCFeedback(HWState rcvdEvent, string StatusMessage, string Msg)
        {
            EventHandler handler = HWCFeedbackEvent;
            if (handler != null)
            {
                hwcFBArgs cmd = new hwcFBArgs();
                cmd.hwState = rcvdEvent;
                cmd.StatusMessage = StatusMessage;
                cmd.RegReadValues = null;
                cmd.icBuffer = Msg;

                handler(this, cmd);
            }
        }
        private void HWCFeedback(HWState rcvdEvent, string StatusMessage, List<RegWithValue> readValues, string Msg)
        {
            EventHandler handler = HWCFeedbackEvent;
            if (handler != null)
            {
                hwcFBArgs cmd = new hwcFBArgs();
                cmd.hwState = rcvdEvent;
                cmd.StatusMessage = StatusMessage;
                cmd.RegReadValues = readValues;
                cmd.icBuffer = Msg;

                handler(this, cmd);
            }
        }

        #endregion IRedHWC Members

        public class hwcFBArgs : EventArgs
        {
            public string SystemID;

            public HWState hwState;
            public string StatusMessage;
            public List<RegWithValue> RegReadValues;
            public string icBuffer;
        }

    }

    public class PLCSendData
    {
        public string PLCRegOperationType = "";
        public string RegisterID = "";
        public int RegisterValue = 0;
        public int RDRegsCount = 1;//To get no of regiser to read in one command
        public bool RDRegsCountReadAsSingle = false; //This will be set true, when data from PLC will be multibyte as, in case of plc_TillDateCount

        public PLCSendData()
        {

        }
        public PLCSendData(string oPLCRegOperationType, string oRegisterID, int oRegisterValue)
        {
            this.PLCRegOperationType = oPLCRegOperationType;
            this.RegisterID = oRegisterID;
            if (oPLCRegOperationType == PLCProtocol.RegisterValRead)
                this.RDRegsCount = oRegisterValue;
            else
                this.RDRegsCount = 1;

            this.RegisterValue = oRegisterValue;
            this.RDRegsCountReadAsSingle = false;
        }
        public PLCSendData(string oPLCRegOperationType, string oRegisterID, int oRegisterValue, bool oRDRegsCountReadAsSingle)
        {
            this.PLCRegOperationType = oPLCRegOperationType;
            this.RegisterID = oRegisterID;
            this.RDRegsCount = this.RegisterValue = oRegisterValue;
            this.RDRegsCountReadAsSingle = oRDRegsCountReadAsSingle;
        }
    }

    public class RegWithValue
    {
        public string RegisterID = "0000";
        public long RegisterValue = 0;

        public RegWithValue(string oRegisterID, string oRegisterValue)
        {
            this.RegisterID = oRegisterID;

            if (oRegisterValue.Length > 4)
            {
                long nRegisterValue = 0;

                RedCommunication.DataHelper.TryConvertFromHexStr(oRegisterValue, ref nRegisterValue, true);
                this.RegisterValue = nRegisterValue;
            }
            else if (oRegisterValue.Length > 0)
            {
                Int32 nRegisterValue = 0;
                RedCommunication.DataHelper.TryConvertFromHexStr(oRegisterValue, ref nRegisterValue);
                this.RegisterValue = nRegisterValue;
            }
            else
                this.RegisterValue = 0;
        }
    }

    public static class PLCRegister
    {
        public static int MsgSendGap = 50;

        public static string Oper_Ejection = "1006";
        public static int Oper_Ejection_DEFAULT = 0;
        public static int Oper_Ejection_PASS = 1;
        public static int Oper_Ejection_FAIL = 2;
        
        public static string Oper_Conveyor = "1000";
        public static int Oper_Conveyor_Default = 0;
        public static int Oper_Conveyor_START = 1;
        public static int Oper_Conveyor_STOP = 2;
        public static int Oper_Conveyor_CLEAR = 3;
        public static int Oper_Conveyor_FREEMOVE = 4;

        ///HMI I/O TEST
        public static string HMIInputReg = "1070";
        public static int HMIInputRegLen2Read = 2;
        public static bool IsHMIInputReg(string register)
        {
            return (HMIInputReg == register);
        }

        ///HWC Feedback/Alarm/Error List Registers
        public static string FeedbackErrorReg = "1019";
        public static int FeedbackErrorRegLen2Read = 6;

        public static string FBRegister_CamSenserCount = "1019";
        public static string FBRegister_SoftUpdateCount = "1020"; 
        public static string FBRegister_EjeSenserCount = "1021";
        public static string FBRegister_MachineStatus = "1022";
        public static string FBRegister_InputStatus = "1023";
        public static string FBRegister_OutputStatus = "1024";

        /// Generic Software Specific Errors to be logged as Alarm
        public const int ErrorListBit_AllErrorCleared = 1000;
        public const int ErrorListBit_CommunicationError = 1001;

        ///Parameter Setings Registers
        static List<string> ParamSettReg = new List<string>();
        public static void SetupParamSettReg(List<PLCParameterSettings> lstPLCParameterSettings)
        {
            ParamSettReg = new List<string>();
            foreach (PLCParameterSettings item in lstPLCParameterSettings)
            {
                if (string.IsNullOrEmpty(item.Register.Trim()) == false)
                    ParamSettReg.Add(item.Register);
            }
        }

        public static bool IsParameterSettingReg(string register)
        {
            //return Array.Exists(ParamSettReg, item=>item == register);
            return ParamSettReg.Exists(item => item == register);
        }
        public static string GetNextParameterSettingReg(string register)
        {
            //int curIndex = Array.IndexOf(ParamSettReg, register);            
            int curIndex = ParamSettReg.FindIndex(item => item == register);
            if (curIndex < 0 || curIndex + 1 >= ParamSettReg.Count)
                return string.Empty;
            else
                return ParamSettReg[curIndex + 1];
        }

        public static void Setup_PLCSettings(PLCSetup oPLCSetup)
        {
            if (PLCRegister.MsgSendGap < 25)
            {
                throw new ArgumentOutOfRangeException("MsgSendGap", PLCRegister.MsgSendGap, "PLC consecutive message Gap set is less than threshold limit");
                return;
            }

            MsgSendGap = oPLCSetup.PLCExecutionSettings.MsgSendGap;

            Oper_Ejection = oPLCSetup.PLCExecutionSettings.Reg_Ejection;
            Oper_Ejection_DEFAULT = oPLCSetup.PLCExecutionSettings.Oper_Ejection_DEFAULT;
            Oper_Ejection_PASS = oPLCSetup.PLCExecutionSettings.Oper_Ejection_PASS;
            Oper_Ejection_FAIL = oPLCSetup.PLCExecutionSettings.Oper_Ejection_FAIL;

            Oper_Conveyor = oPLCSetup.PLCExecutionSettings.Reg_Conveyor;
            Oper_Conveyor_Default = oPLCSetup.PLCExecutionSettings.Oper_Conveyor_Default;
            Oper_Conveyor_START = oPLCSetup.PLCExecutionSettings.Oper_Conveyor_START;
            Oper_Conveyor_STOP = oPLCSetup.PLCExecutionSettings.Oper_Conveyor_STOP;
            Oper_Conveyor_CLEAR = oPLCSetup.PLCExecutionSettings.Oper_Conveyor_CLEAR;
            Oper_Conveyor_FREEMOVE = oPLCSetup.PLCExecutionSettings.Oper_Conveyor_FREEMOVE;

            FeedbackErrorReg = oPLCSetup.FeedbackErrorReg;
            FeedbackErrorRegLen2Read = oPLCSetup.FeedbackErrorRegLen2Read;

            FBRegister_CamSenserCount = oPLCSetup.FBRegister_CamSenserCount;
            FBRegister_SoftUpdateCount = oPLCSetup.FBRegister_SoftUpdateCount;
            FBRegister_EjeSenserCount = oPLCSetup.FBRegister_EjeSenserCount;
            FBRegister_MachineStatus = oPLCSetup.FBRegister_MachineStatus;
            FBRegister_InputStatus = oPLCSetup.FBRegister_InputStatus;
            FBRegister_OutputStatus = oPLCSetup.FBRegister_OutputStatus;
            
        }
    }

    public class PLCProtocol
    {
        private redTrace oTrace = new redTrace(false, "PLCProtocol");

        private string _PLCNo = "00";
        public string PLCNo
        {
            get { return _PLCNo; }
        }

        public int MinMessageLength = 7;

        public string SoH = "@";
        public string EoH = '\x0D'.ToString();
        public string EoHPrefix = "*";
        public string SEP = "";

        public const int RegParamTypeLen = 2; //RD, WD
        public const int PLCCmdExecRespLen = 2; //00, 15        
        public const int PLCRegValueLen = 4;    //"0000"
        public const int BufferCheckSumLen = 2;


        public const string RegisterValRead = "RD";
        public const string RegisterValWrite = "WD";

        public const string PLCRespCode_SUCCESS = "00";
        public const string PLCRespCode_ERROR1 = "13";
        public const string PLCRespCode_ERROR2 = "14";
        public const string PLCRespCode_ERROR3 = "15";

        public string OPEN = "01";
        public string CLOSE = "00";

        public PLCProtocol(string oPLCNo)
        {
            if (string.IsNullOrEmpty(oPLCNo) == true || oPLCNo.Length != 2)
                throw new ArgumentException();
            _PLCNo = oPLCNo;
        }


        internal string GetMsg(int oController, bool open)
        {
            return SoH + oController.ToString().PadLeft(2, '0') + SEP +
                (open == true ? OPEN : CLOSE) + EoH;
        }
        internal string GetValidBuffer(string buffer)
        {
            string outBuff = string.Empty;

            ///In case if there are multiple SoH available, move to last SoH
            int lastposSoH = buffer.LastIndexOf(this.SoH);

            if (lastposSoH < 0)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},Buffer received without SoH:{1}", DateTime.Now.ToString(), this.SoH));
                return string.Empty;
            }
            else if (lastposSoH == 0)
            {
                outBuff = buffer;
            }
            else if (lastposSoH > 0)
            {
                outBuff = buffer.Substring(lastposSoH);
            }
            else
            {
                throw new NotImplementedException();
            }
            ///Check if there is EoHPrefix char available. Also if there are multiple EoHPrefix, use first to proceed
            int posEoHPrefix = outBuff.IndexOf(this.EoHPrefix);
            if (posEoHPrefix < 0)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},Buffer received without EoHPrefix:{1}", DateTime.Now.ToString(), this.EoHPrefix));
                return string.Empty;
            }
            else if (outBuff.Length > posEoHPrefix + this.EoHPrefix.Length)
            {
                outBuff = outBuff.Substring(0, posEoHPrefix + this.EoHPrefix.Length);
            }
            return outBuff;
        }

        internal string GetMsgBuffer(string cmParamType, string RegisterID, int ParamValueDecimal)
        {
            string ParamValue = string.Empty;

            string command = string.Empty;
            command += this.SoH;
            command += this.PLCNo;
            command += cmParamType;
            command += RegisterID;
            if (cmParamType == PLCProtocol.RegisterValWrite)
                ParamValue = DataConvert.IntegerHexConvert(ParamValueDecimal, 4);
            else
                ParamValue = ParamValueDecimal.ToString("0000");
            command += ParamValue;
            command += RedCommunication.DataHelper.RBexorCheckSum(command);
            command += this.EoHPrefix + this.EoH;

            return command;
        }
    }

    public class PLCSetup
    {
        public PLCSetup() { }

        #region PLC_EXECUTION_Settings

        PLCExecutionSettings _PLCExecutionSettings = new PLCExecutionSettings();
        public PLCExecutionSettings PLCExecutionSettings
        {
            get { return _PLCExecutionSettings; }
            set { _PLCExecutionSettings = value; }
        }

        #endregion PLC_EXECUTION_Settings

        #region PLC_PARAMETER_Settings

        List<PLCParameterSettings> _List4PLCParameterSettings = new List<PLCParameterSettings>();
        public List<PLCParameterSettings> List4PLCParameterSettings
        {
            get { return _List4PLCParameterSettings; }
            set { _List4PLCParameterSettings = value; }
        }

        #endregion PLC_PARAMETER_Settings

        #region HMI_OUTPUT_Settings

        List<PLCHMIOPParameterSettings> _List4PLCHMIOPParameterSettings = new List<PLCHMIOPParameterSettings>();
        public List<PLCHMIOPParameterSettings> List4PLCHMIOPParameterSettings
        {
            get { return _List4PLCHMIOPParameterSettings; }
            set { _List4PLCHMIOPParameterSettings = value; }
        }

        #endregion HMI_OUTPUT_Settings

        #region HMI_INPUT_Settings

        string _HMIInputReg = "1070";
        public string HMIInputReg
        {
            get { return _HMIInputReg; }
            set { _HMIInputReg = value; }
        }

        int _HMIInputRegLen2Read = 2;
        public int HMIInputRegLen2Read
        {
            get { return _HMIInputRegLen2Read; }
            set { _HMIInputRegLen2Read = value; }
        }

        List<PLCHMIIPParameterSettings> _List4PLCHMIIPParameterSettings = new List<PLCHMIIPParameterSettings>();
        public List<PLCHMIIPParameterSettings> List4PLCHMIIPParameterSettings
        {
            get { return _List4PLCHMIIPParameterSettings; }
            set { _List4PLCHMIIPParameterSettings = value; }
        }

        #endregion HMI_INPUT_Settings

        #region Feedback_Alarm_Error_Settings

        string _FeedbackErrorReg = "1020";
        public string FeedbackErrorReg
        {
            get { return _FeedbackErrorReg; }
            set { _FeedbackErrorReg = value; }
        }

        int _FeedbackErrorRegLen2Read = 5;
        public int FeedbackErrorRegLen2Read
        {
            get { return _FeedbackErrorRegLen2Read; }
            set { _FeedbackErrorRegLen2Read = value; }
        }

        string _FBRegister_CamSenserCount = "1019";
        public string FBRegister_CamSenserCount
        {
            get { return _FBRegister_CamSenserCount; }
            set { _FBRegister_CamSenserCount = value; }
        }

        string _FBRegister_SoftUpdateCount = "1020";
        public string FBRegister_SoftUpdateCount
        {
            get { return _FBRegister_SoftUpdateCount; }
            set { _FBRegister_SoftUpdateCount = value; }
        }

        string _FBRegister_EjeSenserCount = "1021";
        public string FBRegister_EjeSenserCount
        {
            get { return _FBRegister_EjeSenserCount; }
            set { _FBRegister_EjeSenserCount = value; }
        }

        string _FBRegister_MachineStatus = "1022";
        public string FBRegister_MachineStatus
        {
            get { return _FBRegister_MachineStatus; }
            set { _FBRegister_MachineStatus = value; }
        }

        string _FBRegister_InputStatus = "1023";
        public string FBRegister_InputStatus
        {
            get { return _FBRegister_InputStatus; }
            set { _FBRegister_InputStatus = value; }
        }

        string _FBRegister_OutputStatus = "1024";
        public string FBRegister_OutputStatus
        {
            get { return _FBRegister_OutputStatus; }
            set { _FBRegister_OutputStatus = value; }
        }

        List<PLCAlarmSettings> _List4PLCAlarmSettings = new List<PLCAlarmSettings>();
        public List<PLCAlarmSettings> List4PLCAlarmSettings
        {
            get { return _List4PLCAlarmSettings; }
            set { _List4PLCAlarmSettings = value; }
        }

        #endregion Feedback_Alarm_Error_Settings

        public static PLCSetup Read(string filePath)
        {
            try
            {
                PLCSetup oPLCSetup;

                if (!System.IO.File.Exists(filePath))
                {
                    oPLCSetup = CreateDefault();
                    GenericXmlSerializer<PLCSetup>.Serialize(oPLCSetup, filePath);
                }
                else
                    oPLCSetup = GenericXmlSerializer<PLCSetup>.Deserialize(filePath);

                return oPLCSetup;
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0},{1},{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace);
            }
            return null;
        }
        private static PLCSetup CreateDefault()
        {
            PLCSetup oPLCSetup = new PLCSetup();

            oPLCSetup.PLCExecutionSettings = PLCExecutionSettings.CreateDefault();
            oPLCSetup.List4PLCParameterSettings = PLCParameterSettings.CreateDefault();
            oPLCSetup.List4PLCHMIOPParameterSettings = PLCHMIOPParameterSettings.CreateDefault();
            oPLCSetup.List4PLCHMIIPParameterSettings = PLCHMIIPParameterSettings.CreateDefault();
            oPLCSetup.List4PLCAlarmSettings = PLCAlarmSettings.CreateDefault();

            return oPLCSetup;
        }
        public static bool Write(PLCSetup oPLCSetup, string filePath)
        {
            GenericXmlSerializer<PLCSetup>.Serialize(oPLCSetup, filePath);
            return true;
        }
    }
    public class PLCParameterSettings
    {
        string _Component;
        public string Component
        {
            get { return _Component; }
            set { _Component = value; }
        }

        string _Description;
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        string _Register;
        public string Register
        {
            get { return _Register; }
            set { _Register = value; }
        }

        [XmlIgnore]
        string _CurValue;
        public string CurValue
        {
            get { return _CurValue; }
            set { _CurValue = value; }
        }

        [XmlIgnore]
        string _NewValue;
        public string NewValue
        {
            get { return _NewValue; }
            set { _NewValue = value; }
        }

        string _Unit;
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public PLCParameterSettings()
        {

        }
        public PLCParameterSettings(string oComponent, string oDescription, string oRegister, string oCurValue, string oNewValue, string oUnit)
        {
            this.Component = oComponent;
            this.Description = oDescription;
            this.Register = oRegister;
            this.CurValue = oCurValue;
            this.NewValue = oNewValue;
            this.Unit = oUnit;
        }

        internal static List<PLCParameterSettings> CreateDefault()
        {
            List<PLCParameterSettings> lstPLCParameterSettings = new List<PLCParameterSettings>();
            PLCParameterSettings oPLCParameterSettings;

            oPLCParameterSettings = new PLCParameterSettings("Printer", "Delay", "1000", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("Printer", "PulseonTime", "1002", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("Vision", "Delay", "1004", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("Vision", "PulseonTime", "1006", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("RejectionMarker", "Delay", "1008", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("RejectionMechanism", "Delay", "1012", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("RejectionMechanism", "PulseonTime", "1014", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("Rejectionconfirmationsensor", "OnTime", "1016", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("AcceptedConfirmationSensor", "Distance", "1018", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("Tolerance", "Value", "1020", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("Consecutiverejection", "Quantity", "1022", "0", "0", "Nos");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("EncoderPPR", "PPR", "1040", "0", "0", "PPR");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("EncoderWheelCircumference", "Circumference", "1038", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("ProductSensorBlockDelay", "Delay", "1044", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("RejectSensorBlockDelay", "Delay", "1046", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("AcceptedSensorBlockDelay", "Delay", "1048", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("NoEncoderPulseDelay", "Time", "1050", "0", "0", "ms");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            oPLCParameterSettings = new PLCParameterSettings("BeltLength", "Inmm", "1056", "0", "0", "mm");
            lstPLCParameterSettings.Add(oPLCParameterSettings);

            return lstPLCParameterSettings;
        }
    }
    public class PLCHMIOPParameterSettings
    {
        string _HMIOPParam_Name;
        public string HMIOPParam_Name
        {
            get { return _HMIOPParam_Name; }
            set { _HMIOPParam_Name = value; }
        }

        string _PLCParamCaption;
        public string PLCParamCaption
        {
            get { return _PLCParamCaption; }
            set { _PLCParamCaption = value; }
        }

        string _OperBtnNameOn;
        public string OperBtnNameOn
        {
            get { return _OperBtnNameOn; }
            set { _OperBtnNameOn = value; }
        }

        string _OperBtnNameOff;
        public string OperBtnNameOff
        {
            get { return _OperBtnNameOff; }
            set { _OperBtnNameOff = value; }
        }

        int _HMIOPParam_ID;
        public int HMIOPParam_ID
        {
            get { return _HMIOPParam_ID; }
            set { _HMIOPParam_ID = value; }
        }

        string _HMIOPParam_Register;
        public string HMIOPParam_Register
        {
            get { return _HMIOPParam_Register; }
            set { _HMIOPParam_Register = value; }
        }

        int _HMIOPParam_BitPosition;
        public int HMIOPParam_BitPosition
        {
            get { return _HMIOPParam_BitPosition; }
            set { _HMIOPParam_BitPosition = value; }
        }

        bool _RequiredInAutoTest = false;
        public bool RequiredInAutoTest
        {
            get { return _RequiredInAutoTest; }
            set { _RequiredInAutoTest = value; }
        }

        public PLCHMIOPParameterSettings()
        {

        }
        private PLCHMIOPParameterSettings(string _HMIOPParam_Name, string _PLCParamCaption, string _OperBtnNameOn, string _OperBtnNameOff, int _HMIOPParam_ID, string _HMIOPParam_Register, int _HMIOPParam_BitPosition)
        {
            this.HMIOPParam_Name = _HMIOPParam_Name;
            this.PLCParamCaption = _PLCParamCaption;
            this.OperBtnNameOn = _OperBtnNameOn;
            this.OperBtnNameOff = _OperBtnNameOff;
            this.HMIOPParam_ID = _HMIOPParam_ID;
            this.HMIOPParam_Register = _HMIOPParam_Register;
            this.HMIOPParam_BitPosition = _HMIOPParam_BitPosition;
        }

        internal static List<PLCHMIOPParameterSettings> CreateDefault()
        {
            int _HMIOPParam_ID = 0;
            List<PLCHMIOPParameterSettings> lstPLCHMIOPParameterSettings = new List<PLCHMIOPParameterSettings>();
            PLCHMIOPParameterSettings oPLCHMIOPParameterSettings;

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("Printer", "Printer", "ON", "OFF", _HMIOPParam_ID++, "1072", 1);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("Camera", "Camera", "ON", "OFF", _HMIOPParam_ID++, "1072", 2);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("RejectionMarker", "RejectionMarker", "ON", "OFF", _HMIOPParam_ID++, "1072", 3);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("Rejection", "Rejection", "ON", "OFF", _HMIOPParam_ID++, "1072", 4);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("BeaconRED", "BeaconRED", "ON", "OFF", _HMIOPParam_ID++, "1072", 5);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("BeaconGREEN", "BeaconGREEN", "ON", "OFF", _HMIOPParam_ID++, "1072", 6);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("Downstream", "Downstream", "ENABLE", "DISABLE", _HMIOPParam_ID++, "1072", 7);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("Upstream", "Upstream", "ENABLE", "DISABLE", _HMIOPParam_ID++, "1072", 8);
            lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            //oPLCHMIOPParameterSettings = new PLCHMIOPParameterSettings("", "", "ON", "OFF", _HMIOPParam_ID++, "1072", );
            //lstPLCHMIOPParameterSettings.Add(oPLCHMIOPParameterSettings);

            return lstPLCHMIOPParameterSettings;
        }
    }
    public class PLCHMIIPParameterSettings
    {
        string _HMIOPParam_Name;
        public string HMIOPParam_Name
        {
            get { return _HMIOPParam_Name; }
            set { _HMIOPParam_Name = value; }
        }

        string _HMIIPParam_Text;
        public string HMIIPParam_Text
        {
            get { return _HMIIPParam_Text; }
            set { _HMIIPParam_Text = value; }
        }

        int _HMIIPParam_ID;
        public int HMIIPParam_ID
        {
            get { return _HMIIPParam_ID; }
            set { _HMIIPParam_ID = value; }
        }

        int _HMIIPParam_BitPosition;
        public int HMIIPParam_BitPosition
        {
            get { return _HMIIPParam_BitPosition; }
            set { _HMIIPParam_BitPosition = value; }
        }

        public PLCHMIIPParameterSettings()
        {

        }
        PLCHMIIPParameterSettings(string oHMIOPParam_Name, string oHMIIPParam_Text, int oHMIIPParam_ID, int oHMIIPParam_BitPosition)
        {
            this.HMIOPParam_Name = oHMIOPParam_Name;
            this.HMIIPParam_Text = oHMIIPParam_Text;
            this.HMIIPParam_ID = oHMIIPParam_ID;
            this.HMIIPParam_BitPosition = oHMIIPParam_BitPosition;
        }
        internal static List<PLCHMIIPParameterSettings> CreateDefault()
        {
            int _HMIIPParam_ID = 0;
            List<PLCHMIIPParameterSettings> lstPLCHMIIPParameterSettings = new List<PLCHMIIPParameterSettings>();
            PLCHMIIPParameterSettings oPLCHMIIPParameterSettings;

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("Upstream", "Upstream", _HMIIPParam_ID++, 1);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("Downstream", "Downstream", _HMIIPParam_ID++, 2);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("SafetySensor", "SafetySensor", _HMIIPParam_ID++, 6);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("ProductSensor", "ProductSensor", _HMIIPParam_ID++, 3);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("LowAirPressure", "LowAirPressure", _HMIIPParam_ID++, 7);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("RejectionConfirmationSensor", "RejectionConfirmationSensor", _HMIIPParam_ID++, 10);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("AcceptedConfirmationSensor ", "AcceptedConfirmationSensor ", _HMIIPParam_ID++, 11);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("DriveFailure", "DriveFailure", _HMIIPParam_ID++, 0);
            lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            //oPLCHMIIPParameterSettings = new PLCHMIIPParameterSettings("", "", _HMIIPParam_ID++, );
            //lstPLCHMIIPParameterSettings.Add(oPLCHMIIPParameterSettings);

            return lstPLCHMIIPParameterSettings;
        }
    }
    public class PLCAlarmSettings
    {
        string _PLCAlarmError_Name;
        public string PLCAlarmError_Name
        {
            get { return _PLCAlarmError_Name; }
            set { _PLCAlarmError_Name = value; }
        }

        string _PLCAlarmError_Text;
        public string PLCAlarmError_Text
        {
            get { return _PLCAlarmError_Text; }
            set { _PLCAlarmError_Text = value; }
        }

        string _ForeColor = "Red";
        public string ForeColor
        {
            get { return _ForeColor; }
            set { _ForeColor = value; }
        }

        //int _PLCAlarmError_ID;

        int _PLCAlarmError_BitPosition;
        public int PLCAlarmError_BitPosition
        {
            get { return _PLCAlarmError_BitPosition; }
            set { _PLCAlarmError_BitPosition = value; }
        }

        public PLCAlarmSettings()
        {

        }
        public PLCAlarmSettings(string oPLCAlarmError_Name, string oPLCAlarmError_Text, string oForeColor, int oPLCAlarmError_BitPosition)
        {
            this.PLCAlarmError_Name = oPLCAlarmError_Name;
            this.PLCAlarmError_Text = oPLCAlarmError_Text;
            this.ForeColor = oForeColor;
            this.PLCAlarmError_BitPosition = oPLCAlarmError_BitPosition;
        }

        internal static List<PLCAlarmSettings> CreateDefault()
        {
            List<PLCAlarmSettings> lstPLCAlarmSettings = new List<PLCAlarmSettings>();
            PLCAlarmSettings oPLCAlarmSettings;

            oPLCAlarmSettings = new PLCAlarmSettings("SafetyDoorOpen", "SafetyDoorOpen", "Red", 0);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("LowAirPressure", "LowAirPressure", "Red", 1);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("Emergency", "Emergency", "Red", 2);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("ConsecutivRejection", "ConsecutivRejection", "Red", 3);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("NoEncoderPulse", "NoEncoderPulse", "Red", 4);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("RejectionBinSensoBlock", "RejectionBinSensoBlock", "Red", 5);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("AcceptedSensorBlock", "AcceptedSensorBlock", "Red", 6);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("ProductSensorBlock", "ProductSensorBlock", "Red", 7);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("RejectionFailed", "RejectionFailed", "Red", 8);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("QueueMissing", "QueueMissing", "Red", 9);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("DriveFailure", "DriveFailure", "Red", 10);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("UpstreamSignal", "UpstreamSignal", "Red", 11);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("DownStreamSignal", "DownStreamSignal", "Red", 12);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("PrinterInkLow", "PrinterInkLow", "Red", 13);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            oPLCAlarmSettings = new PLCAlarmSettings("CrossMarkPrinterInkLow", "CrossMarkPrinterInkLow", "Blue", 14);
            lstPLCAlarmSettings.Add(oPLCAlarmSettings);

            return lstPLCAlarmSettings;
        }
    }
    public class PLCExecutionSettings
    {
        private int _MsgSendGap = 50;
        public int MsgSendGap
        {
            get { return _MsgSendGap; }
            set { _MsgSendGap = value; }
        }

        string _Reg_Ejection = "1006";
        public string Reg_Ejection
        {
            get { return _Reg_Ejection; }
            set { _Reg_Ejection = value; }
        }

        int _Oper_Ejection_DEFAULT = 0;
        public int Oper_Ejection_DEFAULT
        {
            get { return _Oper_Ejection_DEFAULT; }
            set { _Oper_Ejection_DEFAULT = value; }
        }

        int _Oper_Ejection_PASS = 1;
        public int Oper_Ejection_PASS
        {
            get { return _Oper_Ejection_PASS; }
            set { _Oper_Ejection_PASS = value; }
        }

        int _Oper_Ejection_FAIL = 2;
        public int Oper_Ejection_FAIL
        {
            get { return _Oper_Ejection_FAIL; }
            set { _Oper_Ejection_FAIL = value; }
        }

        
        string _Reg_Conveyor = "1000";
        public string Reg_Conveyor
        {
            get { return _Reg_Conveyor; }
            set { _Reg_Conveyor = value; }
        }

        int _Oper_Conveyor_Default = 0;
        public int Oper_Conveyor_Default
        {
            get { return _Oper_Conveyor_Default; }
            set { _Oper_Conveyor_Default = value; }
        }

        int _Oper_Conveyor_START = 1;
        public int Oper_Conveyor_START
        {
            get { return _Oper_Conveyor_START; }
            set { _Oper_Conveyor_START = value; }
        }

        int _Oper_Conveyor_STOP = 2;
        public int Oper_Conveyor_STOP
        {
            get { return _Oper_Conveyor_STOP; }
            set { _Oper_Conveyor_STOP = value; }
        }

        int _Oper_Conveyor_CLEAR = 3;
        public int Oper_Conveyor_CLEAR
        {
            get { return _Oper_Conveyor_CLEAR; }
            set { _Oper_Conveyor_CLEAR = value; }
        }

        int _Oper_Conveyor_FREEMOVE = 4;
        public int Oper_Conveyor_FREEMOVE
        {
            get { return _Oper_Conveyor_FREEMOVE; }
            set { _Oper_Conveyor_FREEMOVE = value; }
        }

        public PLCExecutionSettings()
        {

        }

        internal static PLCExecutionSettings CreateDefault()
        {
            PLCExecutionSettings oPLCExecutionSettings = new PLCExecutionSettings();

            return oPLCExecutionSettings;
        }
    }


    //public enum ePLC_HMIIPParams
    //{
    //    ProductSensor = 3,
    //    RejectionConfirmationSensor = 10,
    //    AcceptedConfirmationSensor = 11,
    //    SafetySensor = 6,
    //    LowAirPressure = 7,
    //    Downstream = 2,
    //    Upstream = 1,
    //    DriveFailure = 0,
    //}
    //public enum ePLC_HMIOPParams
    //{
    //    Printer,
    //    Camera,
    //    RejectionMarker,
    //    Rejection,
    //    BeaconRED,
    //    BeaconGREEN,
    //    Downstream,
    //    Upstream,
    //}

}