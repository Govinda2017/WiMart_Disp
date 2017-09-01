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

        private void InitCam2()
        {
            string deviceName = UTIL.SystemIntegrity.Globals.InspectionSettings2.DeviceName;
            string IPAddress = UTIL.SystemIntegrity.Globals.InspectionSettings2.Address;
            int Port = UTIL.SystemIntegrity.Globals.InspectionSettings2.Port;
            mInspectDev2 = null;
            mInspectDev2 = AccessInspectionDevice.LoadIredInspection(deviceName, IPAddress, Port);
            mInspectDev2.OnInspectionFeedback += new EventHandler(iInspect2_OnInspectionFeedback);
            Trace.TraceInformation("{0}, Camera 2 Initialised..", DateTime.Now);
        }

        private void ConnectCam2()
        {
            try
            {
                if (mInspectDev2 != null)
                {
                    mInspectDev2.Connect();
                    Trace.TraceInformation("{0}, Camera 2 connected..", DateTime.Now);
                }
                UpdateStatusColor(btnScanIndicator, true);
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void DisconnectCam2()
        {
            try
            {
                if (mInspectDev2 != null && mInspectDev2.IsConnected() == true)
                {
                    mInspectDev2.Disconnect();
                    UpdateStatusColor(btnScanIndicator, false);
                    Trace.TraceInformation("{0}, Camera 2 Disconnected..", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        #endregion Camera Handler

        #region Data Handler

        private void iInspect2_OnInspectionFeedback(object sender, EventArgs e)
        {
            Thread th = new Thread(() => HandleInspectedData2(sender, e));
            th.Start();
        }

        private void HandleInspectedData2(object sender, EventArgs e)
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