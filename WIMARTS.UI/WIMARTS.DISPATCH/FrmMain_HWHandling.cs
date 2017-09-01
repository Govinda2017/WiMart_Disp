using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WIMARTS.HWController;
using WIMARTS.UTIL.SystemIntegrity;
using System.Diagnostics;

namespace WIMARTS.DISPATCH
{
    #region Class FrmMain

    public partial class FrmMain
    {
        #region Controller Handler

        private void InitController()
        {
            try
            {
                string SerialPort = UTIL.SystemIntegrity.Globals.HWCSettings.SerialPort;
                mHWControl = new HWControl(SerialPort);
                mHWControl.OnHWControllerFeedback += new EventHandler(mHWControl_OnHWControllerFeedback);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void ConnectController()
        {
            try
            {
            if (HasController == true && mHWControl != null)
            {
                mHWControl.Connect();
            }
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
            if (HasController == true && mHWControl.IsConnected() == true)
            {
                mHWControl.Disconnect();
            }
        }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        #endregion Controller Handler

        #region Data Handler

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

                //Application Commands
                case ControllerEVENTS.ASTARTINSP:
                    m_AppMode = AppMode.Online;
                    break;
                case ControllerEVENTS.ASTOPINSP:
                    m_AppMode = AppMode.Offline;
                    break;
                case ControllerEVENTS.ACAMRESPONSE:
                    break;

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
                default:
                    break;
            }
            Trace.TraceInformation("{0}, Data Received: {1}", DateTime.Now, data);
        }

        #endregion Data Handler

        #region Trigger Handler

        private void OnButtonPress()
        {
            if (ManualMode == false && m_AppMode == AppMode.Error)
            {
                if (HasController == true)
                {
                    mHWControl.ASTARTINSP();
                    RetryCounts++;
                }
                else
                    m_AppMode = AppMode.Online;
            }
            else if (ManualMode == true && m_AppMode == AppMode.ConveyorStop)
            {
                if (HasController == true)
                {
                    mHWControl.TSTARTCONV(1);//Hard coded.. wromg in controller need to change
                    RetryCounts++;
                }
                else
                    m_AppMode = AppMode.ConveyorStart;
            }
        }

        private void EnqueTrigger(string strNo)
        {
            int no = 0;
            Int32.TryParse(strNo, out no);
            Sensor1Count = no;
            TriggerQueue.Enqueue(no);
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

    #endregion Class FrmMain
}