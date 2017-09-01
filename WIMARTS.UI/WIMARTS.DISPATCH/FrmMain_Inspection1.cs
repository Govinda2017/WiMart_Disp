using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIMARTS.UTIL;
using WIMARTS.CODEMGR;
using System.Windows.Forms;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.INSPECTION;
using System.Threading;
using System.Diagnostics;

namespace WIMARTS.DISPATCH
{
    #region Class FrmMain
    
    public partial class FrmMain
    {
        #region Camera Handler
        private void InitCam1()
        {
            string deviceName = UTIL.SystemIntegrity.Globals.InspectionSettings1.DeviceName;
            string IPAddress = UTIL.SystemIntegrity.Globals.InspectionSettings1.Address;
            int Port = UTIL.SystemIntegrity.Globals.InspectionSettings1.Port;
            mInspectDev1 = null;
            mInspectDev1 = AccessInspectionDevice.LoadIredInspection(deviceName, IPAddress, Port);
            mInspectDev1.OnInspectionFeedback += new EventHandler(iInspect1_OnInspectionFeedback);
        }

        private void ConnectCam1()
        {
            try
            {
                if (mInspectDev1 != null)
                {
                    mInspectDev1.Connect();
                    Trace.TraceInformation("{0}, Camera 1 connected..", DateTime.Now);
                }
                UpdateStatusColor(btnCamIndicator, true);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void DisconnectCam1()
        {
            try
            {
                if (mInspectDev1 != null && mInspectDev1.IsConnected() == true)
                {
                    mInspectDev1.Disconnect();
                    UpdateStatusColor(btnCamIndicator, false);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        #endregion Camera Handler

        #region Data Handler

        private void iInspect1_OnInspectionFeedback(object sender, EventArgs e)
        {
            Thread th = new Thread(() => HandleInspectedData2(sender, e));
            th.Start();
        }

        private void HandleInspectedData1(object sender, EventArgs e)
        {
            try
            {
                InspectionArgs rcvDEvent = (InspectionArgs)e;
                switch (rcvDEvent.rcvdEvent)
                {
                    case InspectionEVENTS.Connected:
                        break;
                    case InspectionEVENTS.ResultArrived:
                        UpdateText(txtScannedData, rcvDEvent.Result);
                        // UpdateImageResult(rcvDEvent.ImageResult);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        #endregion Data Handler
    }

    #endregion Class FrmMain
}