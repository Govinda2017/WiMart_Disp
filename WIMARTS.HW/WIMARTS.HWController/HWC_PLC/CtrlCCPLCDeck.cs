using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using RedCommunication;
using rSys;
using WIMARTS.UTIL;
using WIMARTS.UTIL.SystemIntegrity;
using System.Collections;

namespace rcs.CONTROLS
{
    public enum HWState
    {
        Disconnected,
        Connected,
    }

    public partial class CtrlPLCDeck : UserControl
    {
        private redTrace oTrace = new redTrace(false, "CtrlPLCDeck");
        private redTrace oTraceEj = new redTrace(true, "CtrlPLCDeck-Ej");

        #region Properties

        private HWState _PLCConStatus = HWState.Disconnected;
        public HWState ConnectionStatus
        {
            get { return _PLCConStatus; }
        }
        private HWState PLCConStatus
        {
            set
            {
                _PLCConStatus = value;
                UpdateHWCState(value);
            }
        }

        bool _ConnectionEstablished = false;
        /// <summary>
        /// This is used for checking disconnection when it happens externally
        /// This will be set true, when gets connected. And set false on connect request.
        /// </summary>
        public bool ConnectionEstablished { get { return _ConnectionEstablished; } }

        bool hasIndividualSettings = true;
        string mSettingsPath_PLC = SettingsPath.HWConfigPath_PLC;

        private string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                _DisplayName = value;
                label1.Text = _DisplayName;
            }
        }

        #endregion Properties

        #region EVENTS & CALLS

        //public delegate bool delPLC(string deviceName);
        //public event delPLC OnClickDevice;

        event EventHandler RSysFeedbackEvent;
        public event EventHandler OnDataFromPLC
        {
            add
            {
                if (RSysFeedbackEvent != null)
                {
                    lock (RSysFeedbackEvent)
                    {
                        RSysFeedbackEvent += value;
                    }
                }
                else
                {
                    RSysFeedbackEvent = new EventHandler(value);
                }
            }
            remove
            {
                if (RSysFeedbackEvent != null)
                {
                    lock (RSysFeedbackEvent)
                    {
                        RSysFeedbackEvent -= value;
                    }
                }
            }
        }
        private void SendCommand2RUN(PLCnRUN_if.RunAction action2Send, string RegisterNo, long RegisterValue)
        {
            EventHandler handler = RSysFeedbackEvent;
            if (handler != null)
            {
                RedEventArgs args = new RedEventArgs();
                args.action = action2Send;
                args.RegisterNo = RegisterNo;
                args.RegisterValue = RegisterValue;

                handler(this, args);
            }
        }

        //public delegate void delPrinterEvent(string deviceName, PrinterActivity Activity);

        /// <summary>
        /// This will be set to true only from Test Mode. Auto Cmd Read must be always on in Production Run
        /// </summary>
        public bool SkipAutoCmdTimer = false;
        /// <summary>
        /// This will be set true from Settings only. This will be set true whenn there is reading of all data in progress.
        /// Means, there is no prodction happening...
        /// </summary>
        public bool ReadAllParameterSettings_InProg = false;
        /// <summary>
        /// This will be set true when, User wants to perform the Test input mode operation. 
        /// When this will be set true, ERROR conditions will not be read.
        /// </summary>
        public bool HMIInputTestMode_InProg = false;

        public void PerformConnect()
        {
            Connect_HWC();
        }
        public void PerformDisconnect()
        {
            DisConnect_HWC();
        }

        public void PerformMachineOperation(PLCnRUN_if.RunAction machineAction)
        {
            switch (machineAction)
            {
                case PLCnRUN_if.RunAction.plc_ConveyorStart:
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_START);
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_Default);
                    oTrace.AddTrace(redTrace.Level.Information, "PerformMachineOperation:ConveyorStart");
                    break;
                case PLCnRUN_if.RunAction.plc_ConveyorStop:
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_STOP);
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_Default);
                    oTrace.AddTrace(redTrace.Level.Information, "PerformMachineOperation:ConveyorStop");
                    break;
                case PLCnRUN_if.RunAction.plc_ConveyorClear:
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_CLEAR);
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_Default);
                    oTrace.AddTrace(redTrace.Level.Information, "PerformMachineOperation:ConveyorClearBelt");
                    break;
                case PLCnRUN_if.RunAction.plc_ConveyorFreeMove:
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_FREEMOVE);
                    SendData(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Conveyor, PLCRegister.Oper_Conveyor_Default);
                    oTrace.AddTrace(redTrace.Level.Information, "PerformMachineOperation:ConveyorFreeMove");
                    break;
            }
        }

        public void PerformRejectionOperation(bool isAccepted)
        {
            if (isAccepted == true)
            {
                oTraceEj.AddTrace(redTrace.Level.Information, "PerformEjectionOperation:Accepted=true");
                mHWController.SendMessage2Ejector(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Ejection, PLCRegister.Oper_Ejection_PASS);
                mHWController.SendMessage2Ejector(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Ejection, PLCRegister.Oper_Ejection_DEFAULT);
            }
            else
            if (isAccepted == false)
            {
                oTraceEj.AddTrace(redTrace.Level.Information, "PerformEjectionOperation:Rejected");
                mHWController.SendMessage2Ejector(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Ejection, PLCRegister.Oper_Ejection_FAIL);
                mHWController.SendMessage2Ejector(PLCProtocol.RegisterValWrite, PLCRegister.Oper_Ejection, PLCRegister.Oper_Ejection_DEFAULT);
            }
        }

        public void SendData(string cmParamType, string RegisterID, int ParamValueDecimal)
        {
            if (mHWController != null && mHWController.IsHWCConnected() == true)
                mHWController.SendMessage(cmParamType, RegisterID, ParamValueDecimal);
        }
        public void SendData(string cmParamType, string RegisterID, int ParamValueDecimal, bool oRDRegsCountReadAsSingle)
        {
            if (mHWController != null && mHWController.IsHWCConnected() == true)
                mHWController.SendMessage(cmParamType, RegisterID, ParamValueDecimal, oRDRegsCountReadAsSingle);
        }
        public string SendMessageNGet(string RegOperationType, string RegisterID, int ParamValueDecimal)
        {
            string command = string.Empty;
            if (mHWController != null && mHWController.IsHWCConnected() == true)
                command = mHWController.GetSendMessage(RegOperationType, RegisterID, ParamValueDecimal);
            return command;
        }

        #endregion EVENTS & CALLS

        #region Control UI

        public CtrlPLCDeck()
        {
            InitializeComponent();
            label1.Text = string.Empty;
        }
        public void InitializeData(bool hasIndividualSettings, string oSettingsPath_PLC)
        {
            this.hasIndividualSettings = hasIndividualSettings;
            this.mSettingsPath_PLC = oSettingsPath_PLC;
        }
        private void CtrlPLCDeck_Load(object sender, EventArgs e)
        {
            InitTimer(1);
        }
        private void CtrlPLCDeck_Click(object sender, EventArgs e)
        {

        }

        private void UpdateStatusBar(string msg)
        {
            try
            {
                //CommonUI.ControlTextInTh(lblStatus, msg);
            }
            catch (Exception ex)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},{1}{2}", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
        private void UpdateHWCState(HWState st)
        {
            if (this.Parent == null) return;
            if (pbConnectionState.InvokeRequired == true)
            {
                pbConnectionState.Invoke(new MethodInvoker(delegate { UpdateHWCState(st); }));
            }
            else
            {
                switch (st)
                {
                    case HWState.Disconnected:
                        oTrace.AddTrace(redTrace.Level.Information, "HWState:Disconnected");
                        pbConnectionState.Image = WIMARTS.HWController.Properties.Resources.ConnectionNO;
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_DISCONNECTED, string.Empty, -1);
                        break;
                    case HWState.Connected:
                        _ConnectionEstablished = true;
                        pbConnectionState.Image = WIMARTS.HWController.Properties.Resources.ConnectionGO;
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_CONNECTED, string.Empty, -1);
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion Control UI

        #region __INCOMING_DATA_HANDLING__

        HWSettings mHWConSett = null;
        PLCHWController mHWController = null;

        private void Connect_HWC()
        {
            _ConnectionEstablished = false;
            bool result = LoadHWController();
            if (result == false)
            {
                Application.Exit();
                return;
            }

            mHWController.OnHWCFeedback += new EventHandler(hwc_OnHWCFeedback);
            if (mHWController.Connect() == false)
            {
                PLCConStatus = HWState.Disconnected;
                MessageBox.Show("FAILED TO CONNECT CONTROLLER. \r\nCHECK CONTROLLER IS CONNECTED and POWER IS ON.", "ERROR!!!", MessageBoxButtons.OK, 0);
            }
        }
        private void DisConnect_HWC()
        {
            if (mHWController != null && mHWController.IsHWCConnected() == true)
            {
                mHWController.DisConnect();

            }
            mHWController = null;
            PLCConStatus = HWState.Disconnected;
            _ConnectionEstablished = false;
        }

        private bool LoadHWController()
        {
            string configFilePath = mSettingsPath_PLC;
            if (File.Exists(configFilePath) == false)
            {
                MessageBox.Show("Machine Settings are not Configured. Kindly configure Machine Communication", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            mHWConSett = HWSettings.Read(configFilePath);
            
            UpdateUIandDATA();

            RCUtils.CONNECTAS oCONNECTAS = RCUtils.CONNECTAS.SERIAL_COM;
            if (mHWConSett.Communication == "TCP")
                oCONNECTAS = RCUtils.CONNECTAS.TCP_IP;
            else
                oCONNECTAS = RCUtils.CONNECTAS.SERIAL_COM;

            mHWController = new PLCHWController(oCONNECTAS, mHWConSett.ConnectAddress, mHWConSett.PrimaryPort);
            if (mHWController == null)
            {
                MessageBox.Show("Failed to Initialise the Controller. Kindly configure Controller Properly", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            IsSubscribed = false;

            return true;
        }
        private void UpdateUIandDATA()
        {
            if (mHWConSett != null)
            {
                string tooltipMsg = mHWConSett.HWDeviceName + Environment.NewLine;
                tooltipMsg += mHWConSett.Communication + Environment.NewLine;
                tooltipMsg += mHWConSett.ConnectAddress;
                if (mHWConSett.Communication == "TCP")
                    tooltipMsg += "  " + mHWConSett.PrimaryPort;

                CommonUI.SetTooltip(this.pbConnectionState, tooltipMsg);
            }
        }

        bool IsSubscribed = false;

        private void hwc_OnHWCFeedback(object sender, EventArgs e)
        {
            Thread th = new Thread(() => OnHWCFeedback(sender, e));
            th.Start();
        }
        private void OnHWCFeedback(object sender, EventArgs e)
        {
            PLCHWController.hwcFBArgs pArgs = (PLCHWController.hwcFBArgs)e;

            if (pArgs.hwState == HWState.Connected)
            {
                PLCConStatus = HWState.Connected;
            }
            else if (pArgs.hwState == HWState.Disconnected)
            {
                PLCConStatus = HWState.Disconnected;
                IsSubscribed = false;
            }
            //OnAddMessage(pArgs.icBuffer, pArgs.StatusMessage);
            SendCommand2RUN(PLCnRUN_if.RunAction.plc_LogDisplay, pArgs.icBuffer + "|" + pArgs.StatusMessage, 0);

            if (pArgs.RegReadValues != null)
            {
                oTrace.AddTrace(redTrace.Level.Information, "OnHWCFeedback: " + pArgs.StatusMessage + "  " + pArgs.icBuffer + " RegReadValues.Count: " + pArgs.RegReadValues.Count);
                ProcessIncomingRegValues(pArgs.RegReadValues);
            }
            if (IsSubscribed == false)
            {
                IsSubscribed = true;

                Thread.Sleep(150);//This is to make sure that, commands send earlier should get processed...
                TimerActionReadFeedbackError(true);//TBV
            }
        }

        private void ProcessIncomingRegValues(List<RegWithValue> lstRegReadValues)
        {
            foreach (RegWithValue item in lstRegReadValues)
            {
                oTrace.AddTrace(redTrace.Level.Information, "ProcessIncomingRegValues:item" + item.RegisterID + " " + item.RegisterValue);
                
                #region FEEDBACK REGISTER DATA HANDLING
                if (PLCRegister.FBRegister_CamSenserCount.Equals(item.RegisterID) == true)
                {
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_FBUpdate_CamSenserCount, item.RegisterID, item.RegisterValue);
                }
                else if (PLCRegister.FBRegister_SoftUpdateCount.Equals(item.RegisterID) == true)
                {
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_FBUpdate_SoftUpdateCount, item.RegisterID, item.RegisterValue);
                }
                else if (PLCRegister.FBRegister_EjeSenserCount.Equals(item.RegisterID) == true)
                {
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_FBUpdate_EjeSenserCount, item.RegisterID, item.RegisterValue);
                }
                else if (PLCRegister.FBRegister_MachineStatus.Equals(item.RegisterID) == true)
                {
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_FBUpdate_MachineStatus, item.RegisterID, item.RegisterValue);
                }
                else if (PLCRegister.FBRegister_InputStatus.Equals(item.RegisterID) == true)
                {
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_FBUpdate_InputStatus, item.RegisterID, item.RegisterValue);
                }
                else if (PLCRegister.FBRegister_OutputStatus.Equals(item.RegisterID) == true)
                {
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_FBUpdate_OutputStatus, item.RegisterID, item.RegisterValue);
                }
                #endregion FEEDBACK REGISTER DATA HANDLING
                #region SETTINGS REGISTER DATA HANDLING
                else if (PLCRegister.IsParameterSettingReg(item.RegisterID) == true)
                {
                    oTrace.AddTrace(redTrace.Level.Information, "ProcessIncomingRegValues: IsParameterSettingReg " + item.RegisterID + "  " + item.RegisterValue);
                    if (ReadAllParameterSettings_InProg == true)
                    {
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_DataUpdate, item.RegisterID, item.RegisterValue);
                        //UpdatePLCParameterSettings(item.RegisterID, item.RegisterValue);
                        string registerID = PLCRegister.GetNextParameterSettingReg(item.RegisterID);
                        if (string.IsNullOrEmpty(registerID) == false)
                            SendData(PLCProtocol.RegisterValRead, registerID, 1);
                        else
                            ReadAllParameterSettings_InProg = false;
                    }
                    else
                    {
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_DataUpdate, item.RegisterID, item.RegisterValue);
                        //UpdatePLCParameterSettings(item.RegisterID, item.RegisterValue);
                    }
                }
                #endregion SETTINGS REGISTER DATA HANDLING
                #region CONVEYOR OPERATION REGISTER DATA HANDLING
                else if (PLCRegister.Oper_Conveyor.Equals(item.RegisterID) == true)
                {
                    oTrace.AddTrace(redTrace.Level.Information, "ProcessIncomingRegValues: Oper_Conveyor " + item.RegisterID + "  " + item.RegisterValue);
                    if (item.RegisterValue == PLCRegister.Oper_Conveyor_START)
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_ConveyorStart, item.RegisterID, item.RegisterValue);
                    else if (item.RegisterValue == PLCRegister.Oper_Conveyor_STOP)
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_ConveyorStop, item.RegisterID, item.RegisterValue);
                    else if (item.RegisterValue == PLCRegister.Oper_Conveyor_CLEAR)
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_ConveyorClear, item.RegisterID, item.RegisterValue);
                    else if (item.RegisterValue == PLCRegister.Oper_Conveyor_FREEMOVE)
                        SendCommand2RUN(PLCnRUN_if.RunAction.plc_ConveyorFreeMove, item.RegisterID, item.RegisterValue);
                }
                #endregion CONVEYOR OPERATION REGISTER DATA HANDLING
                #region InputOutput REGISTER DATA HANDLING
                else if (PLCRegister.IsHMIInputReg(item.RegisterID) == true)
                {
                    oTrace.AddTrace(redTrace.Level.Information, "ProcessIncomingRegValues: IsHMIInputReg " + item.RegisterID + "  " + item.RegisterValue);
                    SendCommand2RUN(PLCnRUN_if.RunAction.plc_HMIInputStatusUpdate, item.RegisterID, item.RegisterValue);
                }                
                #endregion InputOutput REGISTER DATA HANDLING
            }
        }

        #endregion __INCOMING_DATA_HANDLING__

        #region TIMER_BASED_DATA_READING

        System.Timers.Timer timerHWsCheck;
        bool hasTimerStarted = false;

        void InitTimer(int timeInSec)
        {
            timerHWsCheck = new System.Timers.Timer();
            timerHWsCheck.Interval = timeInSec * 1000;
            timerHWsCheck.Elapsed += new System.Timers.ElapsedEventHandler(timerHWsCheck_Elapsed);
            timerHWsCheck.AutoReset = false;
        }
        void TimerActionReadFeedbackError(bool PerformStart)
        {
            if (PerformStart == true)
            {
                if (hasTimerStarted == true)
                    return;

                timerHWsCheck.Start();
                hasTimerStarted = true;
            }
            else
            {
                timerHWsCheck.Stop();
                hasTimerStarted = false;
            }
        }
        void timerHWsCheck_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (mHWController == null || mHWController.IsHWCConnected() == false)
                return;

            if (ReadAllParameterSettings_InProg == false && SkipAutoCmdTimer == false)
            {
                //Sending Command to Get Error Status
                if (HMIInputTestMode_InProg == false)
                    SendData(PLCProtocol.RegisterValRead, PLCRegister.FeedbackErrorReg, PLCRegister.FeedbackErrorRegLen2Read);
                else if (HMIInputTestMode_InProg == true)
                    SendData(PLCProtocol.RegisterValRead, PLCRegister.HMIInputReg, PLCRegister.HMIInputRegLen2Read);
            }
            if (hasTimerStarted == true)
                timerHWsCheck.Start();
        }

        #endregion TIMER_BASED_DATA_READING

    }
}