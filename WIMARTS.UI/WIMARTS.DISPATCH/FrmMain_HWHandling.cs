using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WIMARTS.HWController;
using WIMARTS.UTIL.SystemIntegrity;
using System.Diagnostics;
using rcs.CONTROLS;
using WIMARTS.UTIL;
using rSys;
using CondotCombiSys;

namespace WIMARTS.DISPATCH
{
    public partial class FrmMain
    {
        #region Controller Handler

        private void InitController()
        {
            try
            {
                //string SerialPort = UTIL.SystemIntegrity.Globals.HWCSettings.SerialPort;
                //mHWControl = new HWControl(SerialPort);
                //mHWControl.OnHWControllerFeedback += new EventHandler(mHWControl_OnHWControllerFeedback);

                ctrlPLCDeck1.OnDataFromPLC += new EventHandler(ctrlPLCDeck1_OnDataFromPLC);
                PLCSetup mPLCSetup = PLCSetup.Read(SettingsPath.PLC_Setup);
                if (mPLCSetup == null)
                    throw new Exception("Failed to read the PLC_Setup data");
                PLCRegister.Setup_PLCSettings(mPLCSetup);

                ctrlPLCDeck1.InitializeData(true, SettingsPath.HWConfigPath_PLC);
                //ctrlPLCErrorStatus1.InitializeData(bllMgr, mUserLogged, mPLCSetup.List4PLCAlarmSettings, mPLCSetup.AlarmErrorReg);

            }
            catch (Exception ex)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("{0},{1}", ex.Message, ex.StackTrace));
            }
        }

        private void ConnectController()
        {
            try
            {
                //if (HasController == true && mHWControl != null)
                //{
                //    mHWControl.Connect();
                //}
                if (HasController == true && ctrlPLCDeck1.ConnectionStatus == HWState.Disconnected)
                    ctrlPLCDeck1.PerformConnect();
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void DisconnectController()
        {
            try
            {
                //if (HasController == true && mHWControl.IsConnected() == true)
                //{
                //    mHWControl.Disconnect();
                //}
                if (HasController == true && ctrlPLCDeck1.ConnectionStatus == HWState.Connected)
                    ctrlPLCDeck1.PerformDisconnect();
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        #endregion Controller Handler

        #region Data Handler

        frmPLCSettings mfrmPLCExecutor = null;

        private void ctrlPLCDeck1_OnDataFromPLC(object sender, EventArgs e)
        {
            try
            {
                RedEventArgs args = (RedEventArgs)e;
                switch (args.action)
                {
                    #region CONNECTION STATUS
                    case PLCnRUN_if.RunAction.plc_CONNECTED:
                        //flpMachineOperation.Enabled = true;
                        break;
                    case PLCnRUN_if.RunAction.plc_DISCONNECTED:
                        //flpMachineOperation.Enabled = false;
                        //if (AllowCloseMe == false)
                        {
                            if (ctrlPLCDeck1.ConnectionEstablished == true)
                            {
                                UpdateText(lblStatusBar, "HWC Connection got Terminated...");
                                //ctrlSplashBox1.SplashMessage = "HWC Connection Terminated";
                                //ctrlSplashBox1.SplashStart = true;
                            }
                        }
                        break;
                    #endregion CONNECTION STATUS
                    #region HWC FEEDBACK STATUS
                    case PLCnRUN_if.RunAction.plc_FBUpdate_CamSenserCount:
                        EnqueTrigger((int)args.RegisterValue);
                        break;
                    case PLCnRUN_if.RunAction.plc_FBUpdate_SoftUpdateCount:
                        break;
                    case PLCnRUN_if.RunAction.plc_FBUpdate_EjeSenserCount:
                        CheckSensor2Trigger((int)args.RegisterValue);
                        break;
                    case PLCnRUN_if.RunAction.plc_FBUpdate_MachineStatus:
                        int MachineStatus =(int) args.RegisterValue;
                        if (m_AppMode == AppMode.Online && MachineStatus == 2)
                        {
                            m_AppMode = AppMode.Error;
                        }
                        else if (m_AppMode == AppMode.Error && MachineStatus == 1)
                        {
                            if (ManualMode == false && m_AppMode == AppMode.Error)
                            {
                                m_AppMode = AppMode.Online;
                            }
                            else if (ManualMode == true && m_AppMode == AppMode.ConveyorStop)
                            {
                                if (HasController == true)
                                {
                                    //mHWControl.TSTARTCONV(1);//Hard coded.. wromg in controller need to change
                                    //RetryCounts++;
                                    ctrlPLCDeck1.PerformMachineOperation(PLCnRUN_if.RunAction.plc_ConveyorFreeMove);
                                    m_AppMode = AppMode.ConveyorStart;
                                }
                                else
                                    m_AppMode = AppMode.ConveyorStart;
                            }
                        }
                        break;
                    case PLCnRUN_if.RunAction.plc_FBUpdate_InputStatus:

                        break;
                    case PLCnRUN_if.RunAction.plc_FBUpdate_OutputStatus:

                        break;

                    #endregion HWC FEEDBACK STATUS
                    #region CONVEYOR OPERATIONS
                    case PLCnRUN_if.RunAction.plc_ConveyorStart:
                    case PLCnRUN_if.RunAction.plc_ConveyorStop:
                    case PLCnRUN_if.RunAction.plc_ConveyorClear:
                    case PLCnRUN_if.RunAction.plc_ConveyorFreeMove:
                        ProcessConveyorSignal(args.action);
                        break;
                    #endregion CONVEYOR OPERATIONS
                    #region SETTINGS & INPUT/OUTPUT OPERATIONS
                    case PLCnRUN_if.RunAction.plc_DataUpdate:
                        //TBD: This should be called via Event and not direcly...
                        if (mfrmPLCExecutor != null)
                            mfrmPLCExecutor.UpdatePLCParameterSettings(args.RegisterNo, (int)args.RegisterValue);
                        break;
                    case PLCnRUN_if.RunAction.plc_HMIInputStatusUpdate:
                        //TBD: This should be called via Event and not direcly...
                        if (mfrmPLCExecutor != null)
                            mfrmPLCExecutor.UpdateHMI_InputStatus(args.RegisterNo, (int)args.RegisterValue);
                        break;

                    case PLCnRUN_if.RunAction.plc_LogDisplay:
                        //TBD: This should be called via Event and not direcly...
                        if (mfrmPLCExecutor != null)
                            mfrmPLCExecutor.UpdatePLCLogDisplay(args.RegisterNo, (int)args.RegisterValue);
                        break;
                    //case PLCnRUN_if.RunAction.plc_TillDateCount:
                    //    if (OnMachineCountChange != null)
                    //    {
                    //        ulong machineCount = (ulong)args.RegisterValue;
                    //        OnMachineCountChange(machineCount);
                    //    }
                    //    break;
                    #endregion SETTINGS & INPUT/OUTPUT OPERATIONS
                }
            }
            catch (Exception ex)
            {
                oTrace.AddTrace(redTrace.Level.Error, string.Format("Data From PLC,{0},{1}", ex.Message, ex.StackTrace));
            }
        }

        private void ProcessConveyorSignal(PLCnRUN_if.RunAction runAction)
        {
            if (runAction == PLCnRUN_if.RunAction.plc_ConveyorStop && ManualMode == false)
            {
                 m_AppMode = AppMode.Offline;
            }
            else if (runAction == PLCnRUN_if.RunAction.plc_ConveyorStop && ManualMode == true)
            {
                m_AppMode = AppMode.ConveyorStop;
            }
            else if (runAction == PLCnRUN_if.RunAction.plc_ConveyorClear && m_AppMode == AppMode.Start)
            {
                m_AppMode = AppMode.ReadyMode;
            }
            else if (runAction == PLCnRUN_if.RunAction.plc_ConveyorStart)
            {
                m_AppMode = AppMode.Online;
            }
            else if (runAction == PLCnRUN_if.RunAction.plc_ConveyorFreeMove)
            {
                m_AppMode = AppMode.ConveyorStart;
            }

            
        }
        /*
        private void mHWControl_OnHWControllerFeedback(object sender, EventArgs e)
        {
            Thread th = new Thread(() => OnHWControllerFeedback(sender, e));
            th.Start();
        }
        private void OnHWControllerFeedback(object sender, EventArgs e)
        {
            RetryCounts = 0;
            ControllerArgs EArgs = (ControllerArgs)(e);
            string data = EArgs.data;
            switch (EArgs.rcvdEvents)
            {
                #region Controller Setting command Response events
                //Setting Command
                case ControllerEVENTS.DRESET:
                    m_AppMode = AppMode.SettingMode;//if required
                    break;
                case ControllerEVENTS.DMODESTART:
                    Thread.Sleep(500);
                    mHWControl.DCAMTRIGGER(mHwcValues.CamTriggerDelay);
                    RetryCounts++;
                    break;
                case ControllerEVENTS.DCAMTRIGGER:
                    if (ValidateHwValues(data, mHwcValues.CamTriggerDelay) == true)
                    {
                        mHWControl.DCAMPULSE(mHwcValues.CamPulseDelay);
                        RetryCounts++;
                    }
                    else
                    {
                        StartApplication();
                        //RedMessageBox.Show("Hardware Controller values are not set properly.\nRestart the System", "WIMARTS", RedMessageBox.RedMessageBoxButtons.OK, 0);
                    }
                    break;
                case ControllerEVENTS.DCAMPULSE:
                    if (ValidateHwValues(data, mHwcValues.CamPulseDelay) == true)
                    {
                        mHWControl.DCONDIR(mHwcValues.ConveyorDirection);
                        RetryCounts++;
                    }
                    else
                    {
                        StartApplication();
                        //  RedMessageBox.Show("Hardware Controller values are not set properly.\nRestart the System", "WIMARTS", RedMessageBox.RedMessageBoxButtons.OK, 0);
                    }
                    break;
                case ControllerEVENTS.DCONDIR:
                    if (ValidateHwValues(data, mHwcValues.ConveyorDirection) == true)
                    {
                        mHWControl.DERRACT(mHwcValues.ErrorAction);
                        RetryCounts++;
                    }
                    else
                    {
                        StartApplication();
                        //  RedMessageBox.Show("Hardware Controller values are not set properly.\nRestart the System", "WIMARTS", RedMessageBox.RedMessageBoxButtons.OK, 0);
                    }
                    break;
                case ControllerEVENTS.DERRACT:
                    if (ValidateHwValues(data, mHwcValues.ErrorAction) == true)
                    {
                        m_AppMode = AppMode.ReadyMode;
                        //mHWControl.CURRENTMODEEXIT();
                        //RetryCounts++;
                    }
                    else
                    {
                        StartApplication();
                        //  RedMessageBox.Show("Hardware Controller values are not set properly.\nRestart the System", "WIMARTS", RedMessageBox.RedMessageBoxButtons.OK, 0);
                    }
                    break;

                #endregion Controller Setting command Response events

                #region CONTROLLER RESPONSES FOR HW ACTIONS
                //HW Command
                ///
                case ControllerEVENTS.CCAMTRIGGER:
                    EnqueTrigger(data);
                    break;
                case ControllerEVENTS.CEJTRIGGER:
                    CheckSensor2Trigger(data);
                    break;
                case ControllerEVENTS.CERRORSTOPINDIC:
                    m_AppMode = AppMode.Error;
                    break;
                case ControllerEVENTS.CSTARTBTNPRESS:
                    OnButtonPress();
                    break;

                #endregion CONTROLLER RESPONSES FOR HW ACTIONS

                #region CONTROLLER RESPONSES FOR USER ACTIONS
                //Application Commands
                case ControllerEVENTS.ASTARTINSP:
                    m_AppMode = AppMode.Online;
                    break;
                case ControllerEVENTS.ASTOPINSP:
                    m_AppMode = AppMode.Offline;
                    break;
                case ControllerEVENTS.ACAMRESPONSE:
                    break;

                #endregion CONTROLLER RESPONSES FOR USER ACTIONS

                #region CONTROLLER RESPONSES FOR OTHER 
                //Test Mode APp Commands
                case ControllerEVENTS.TMODESTART:
                    break;
                case ControllerEVENTS.TCAM:
                    break;
                case ControllerEVENTS.TCAMTRIGGER:
                    break;
                case ControllerEVENTS.TCAMPULSE:
                    break;
                case ControllerEVENTS.TCAMSTART:
                    break;
                case ControllerEVENTS.TCAMSTOP:
                    break;
                case ControllerEVENTS.TSTARTCONV:
                    m_AppMode = AppMode.ConveyorStart;
                    break;
                case ControllerEVENTS.TSTOPCONV:
                    m_AppMode = AppMode.ConveyorStop;
                    break;
                case ControllerEVENTS.TSTARTBUZZ:
                    break;
                case ControllerEVENTS.TSTOPBUZZ:
                    break;
                case ControllerEVENTS.TBTCTETON:
                    break;
                case ControllerEVENTS.CURRENTMODEEXIT:
                    break;

                #endregion CONTROLLER RESPONSES FOR OTHER
                
                default:
                    break;
            }
            Trace.TraceInformation("{0}, Data Received: {1}", DateTime.Now, data);
        }
        //*/
        #endregion Data Handler

        #region Trigger Handler

        /// <summary>
        /// THis will be called when user will press the Controller Button to Reset Error...
        /// </summary>
        private void OnButtonPress()//PTV
        {
            if (ManualMode == false && m_AppMode == AppMode.Error)
            {
                if (HasController == true)
                {
                    //mHWControl.ASTARTINSP();
                    //RetryCounts++;
                }
                else
                    m_AppMode = AppMode.Online;
            }
            else if (ManualMode == true && m_AppMode == AppMode.ConveyorStop)
            {
                if (HasController == true)
                {
                    //mHWControl.TSTARTCONV(1);//Hard coded.. wromg in controller need to change
                    //RetryCounts++;
                }
                else
                    m_AppMode = AppMode.ConveyorStart;
            }
        }

        private void EnqueTrigger(string strTriggerNumber)
        {
            int TriggerNumber = 0;
            Int32.TryParse(strTriggerNumber, out TriggerNumber);
            EnqueTrigger(TriggerNumber);
        }
        private void EnqueTrigger(int TriggerNumber)
        {
            Sensor1Count = TriggerNumber;
            TriggerQueue.Enqueue(TriggerNumber);
        }

        private int DequeTrigger()
        {
            int no = 0;
            if (TriggerQueue.Count > 0)
                no = TriggerQueue.Dequeue();
            return no;
        }

        #endregion Trigger Handler

    }

}