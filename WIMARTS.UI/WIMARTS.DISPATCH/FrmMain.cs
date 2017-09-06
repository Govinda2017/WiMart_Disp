using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIMARTS.INSPECTION;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;
using System.Threading;
using WIMARTS.CODEMGR;
using WIMARTS.UTIL;
using WIMARTS.HWController;
using WIMARTS.UTIL.SystemIntegrity;
using System.Diagnostics;
using rSys;
using CondotCombiSys;

namespace WIMARTS.DISPATCH
{
    #region Appmodes
    public enum AppMode
    {
        Start,
        StandBy,
        ReadyMode,
        Error,
        LoadJob,
        Online,
        Offline,
        ConveyorStart,
        ConveyorStop,
        ExitJob,
        ExitApp,
    }

    #endregion Appmodes

    public partial class FrmMain : Form
    {
        private redTrace oTrace = new redTrace(true, "WIMARTS_DISP_MAIN");

        #region Properties

        private BLLManager bllMgr;
        private UserMaster mCurUserLogged;

        private bool HasController = true;
        //private HWControl mHWControl;
        //private Globals.HWCValues mHwcValues;

        private IRedInspection mInspectDev1;
        private IRedInspection mInspectDev2;

        private int HwAccessMode = 0;
        private bool _ManualMode = false;

        /// <summary>
        /// This will be used when, Only valid FG Code will be used for checking.
        /// No UID Tracing and other parameters.
        /// </summary>
        private bool AllowFreeFlowDispatch = false;

        /// <summary>
        /// True: This will verify that, dispatch FG Code must belongs to the laoded DGN. 
        /// If FG code is not in Dispatch Pick list will be rejected.
        /// </summary>
        private bool AllowOnlyScheduleDispatch = true;

        /// <summary>
        /// True: System has to Verify that; UID must be verified by Production/Inward System.
        /// Non verified UIDs will be rejected.
        /// False: System will verify for UID is non dispatched in earlier GDN.
        /// </summary>
        private bool AllowOnlyProductionVerified = true;

        private int DispatchDaysLimit = 1;
        private int _RetryCounts = 0;

        public int RetryCounts
        {
            get { return _RetryCounts; }
            set
            {
                _RetryCounts = value;
                if (_RetryCounts > 5)
                {
                    DialogResult dr = RedMessageBox.Show("Error in communication with hardware...\nDo you want to Retry or Exit?\nPress OK to Retry or Cancel to Exit.", "wimaRts", RedMessageBox.RedMessageBoxButtons.OKCancel, 0);
                    if (dr == DialogResult.OK)
                    {
                        _RetryCounts = 1;
                        StartApplication();
                    }
                    else
                    {
                        m_AppMode = AppMode.ExitApp;
                    }
                }
            }
        }

        public bool ManualMode
        {
            get { return _ManualMode; }
            set
            {
                _ManualMode = value;
                HideControls(btnCamIndicator, !_ManualMode);
                HideControls(btnScanIndicator, _ManualMode);
                if (_ManualMode == true)
                {
                    SetController(true);
                    InitCam2();
                    mInspectDev1 = null;
                    UpdateText(btnMode, "S&CANNER");
                }
                else
                {
                    SetController(false);
                    InitCam1();
                    mInspectDev2 = null;
                    UpdateText(btnMode, "&CAMERA");
                }
            }
        }

        private void SetController(bool IsManual)
        {
            if (HasController == true)
            {
                if (IsManual == true)
                {
                    /// Set Conveyor in Transport Mode
                    //mHWControl.TMODESTART();                    
                    //RetryCounts++;
                }
                else
                {
                    /// Set Conveyor in Inspection Mode
                    //mHWControl.CURRENTMODEEXIT();
                    //RetryCounts++;
                }
            }
        }

        private AppMode _AppMode;
        public AppMode m_AppMode
        {
            get { return _AppMode; }
            set
            {
                _AppMode = value;
                UpdateText(lblapmode, _AppMode.ToString());
                switch (_AppMode)
                {
                    case AppMode.Start:
                        {
                            LoadDispatchMaster();

                            UpdateStatusColor(ctrlPLCDeck1, false);
                            UpdateStatusColor(btnCamIndicator, false);
                            UpdateStatusColor(btnScanIndicator, false);

                            TriggerQueue = new Queue<int>();
                            EnableControl(btnStartInsp, false);
                            EnableControl(btnStopInsp, true);
                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, false);
                            EnableControl(cmbDispMaster, false);
                            EnableControl(btnMode, true);
                            UpdateText(btnStopInsp, "EXI&T");
                            UpdateText(txtStartedAt, "");
                            GoodCount = TotalBadCount = 0;
                            UpdateText(lblStatusBar, "SYSTEM STARTED...");
                            ConnectController();
                            Thread.Sleep(500);
                            StartApplication();
                            Trace.TraceInformation("{0}, System Started", DateTime.Now);
                        }
                        break;
                    case AppMode.StandBy:
                        {
                            if (CheckForDataRecovery() == false)
                            {
                                m_AppMode = AppMode.StandBy;
                            }
                            else
                            {
                                if (ManualMode == false)
                                {
                                    mInspectDev1.Init();
                                    mInspectDev1.SubScribeDevice();
                                }
                                TriggerQueue = new Queue<int>();
                                UpdateText(btnStopInsp, "EXI&T");
                                EnableControl(btnStartInsp, true);
                                EnableControl(btnStopInsp, true);
                                EnableControl(btnSettings, true);
                                EnableControl(btnMode, true);
                                UpdateText(txtStartedAt, "");
                                EnableControl(cmbDispMaster, true);
                                GoodCount = TotalBadCount = 0;
                                Sens1TotalCount = Sens2TotalCount = 0;
                                UpdateText(lblStatusBar, "SYSTEM IS IN STANDBY MODE...");
                                UpdateText(lblScanStatus, "");
                                UpdateText(lblSensor1Count, "0");
                                UpdateText(lblSensor2Count, "0");
                                UpdateStatusColor(ctrlPLCDeck1, true);
                                UpdateStatusColor(lblStatusBar, true);
                                UpdateStatusColor(lblScanStatus, true);
                                Trace.TraceInformation("{0}, System is in Standby", DateTime.Now);
                            }
                        }
                        break;
                    case AppMode.ReadyMode:
                        {
                            if (HasController == true)
                            {
                                //mHWControl.CURRENTMODEEXIT();
                                //RetryCounts++;

                            }
                            ManualMode = !(HwAccessMode == 0 || HwAccessMode == 1);

                            TriggerQueue = new Queue<int>();
                            UpdateText(btnStartInsp, "&START JOB");
                            UpdateText(btnStopInsp, "&EXIT JOB");
                            EnableControl(cmbDispMaster, true);
                            EnableControl(btnStartInsp, true);
                            EnableControl(btnStopInsp, true);
                            EnableControl(btnSettings, true);
                            EnableControl(btnMode, true);
                            UpdateText(lblStatusBar, "SYSTEM IS READY...");
                            UpdateStatusColor(ctrlPLCDeck1, true);
                            UpdateStatusColor(lblStatusBar, true);
                            Trace.TraceInformation("{0}, System is in Ready mode", DateTime.Now);
                        }
                        break;
                    case AppMode.Error:
                        {
                            if (HasController == true)
                            {
                                //mHWControl.StopBuzzer();
                                //RetryCounts++;
                            }
                            DisconnectCam1();
                            EnableControl(btnStartInsp, true);
                            EnableControl(btnStopInsp, false);
                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, true);
                            UpdateText(lblStatusBar, "SYSTEM IS IN ERROR, PLEASE CLICK START...");
                            UpdateStatusColor(lblStatusBar, false);
                            // UpdateStatusColor(lblScanStatus, false);
                            Trace.TraceInformation("{0}, System is in Error", DateTime.Now);
                        }
                        break;
                    case AppMode.LoadJob:
                        {
                            TriggerQueue = new Queue<int>();
                            if (mJobMaster.StartedAt.HasValue == false)
                                UpdateJobMasterStatus(Convert.ToInt32(BLLManager.MasterStatus.Running), DateTime.Now, null);
                            else
                                UpdateJobMasterStatus(Convert.ToInt32(BLLManager.MasterStatus.Running), null, null);
                            UpdateText(txtStartedAt, DateTime.Now.ToString("dd-MMMM-yyyy HH:mm:ss"));
                            EnableControl(cmbDispMaster, false);
                            EnableControl(btnStopInsp, true);
                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, true);
                            TotalBadCount = 0;
                            UpdateText(btnStartInsp, "&START");
                            UpdateText(btnStopInsp, "&EXIT JOB");

                            UpdateText(lblStatusBar, "JOB LOADED SUCCESSFULLY, PLEASE CLICK START...");
                            UpdateStatusColor(lblStatusBar, true);
                            UpdateStatusColor(lblScanStatus, true);
                            Trace.TraceInformation("{0}, Job Loaded Successfully: {1}", DateTime.Now, mJobMaster.GDN);
                        }
                        break;
                    case AppMode.Online:
                        {
                            ConnectCam1();
                            TriggerQueue = new Queue<int>();
                            UpdateText(btnStopInsp, "S&TOP");
                            EnableControl(cmbDispMaster, false);
                            EnableControl(btnStartInsp, false);
                            EnableControl(btnStopInsp, true);

                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, false);
                            UpdateStatusColor(btnCamIndicator, true);
                            UpdateText(lblStatusBar, "SYSTEM IS ONLINE...");
                            UpdateText(lblScanStatus, "");
                            UpdateStatusColor(lblStatusBar, true);
                            UpdateStatusColor(lblScanStatus, true);
                            Trace.TraceInformation("{0}, System is Online", DateTime.Now);
                        }
                        break;
                    case AppMode.Offline:
                        {
                            DisconnectCam1();
                            UpdateText(btnStartInsp, "&START");
                            UpdateText(btnStopInsp, "&EXIT JOB");
                            //UpdateText(btnStopInsp, "EXI&T");
                            EnableControl(cmbDispMaster, false);
                            EnableControl(btnStartInsp, true);
                            EnableControl(btnStopInsp, true);
                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, true);
                            UpdateStatusColor(btnCamIndicator, false);
                            UpdateText(lblStatusBar, "SYSTEM IS OFFLINE...");
                            UpdateText(txtScannedData, "");
                            UpdateStatusColor(lblStatusBar, false);
                            //   UpdateStatusColor(lblScanStatus, false);
                            Trace.TraceInformation("{0}, System is Offline", DateTime.Now);
                        }
                        break;
                    case AppMode.ConveyorStart:
                        {
                            ConnectCam2();
                            TriggerQueue = new Queue<int>();
                            UpdateText(btnStopInsp, "S&TOP");
                            EnableControl(btnStartInsp, false);
                            EnableControl(btnStopInsp, true);
                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, false);
                            UpdateStatusColor(btnScanIndicator, true);
                            UpdateText(lblStatusBar, "SYSTEM IS ONLINE...");
                            UpdateText(lblScanStatus, "");
                            UpdateStatusColor(lblStatusBar, true);
                            UpdateStatusColor(lblScanStatus, true);
                            Trace.TraceInformation("{0}, Conveyor Started", DateTime.Now);
                        }
                        break;
                    case AppMode.ConveyorStop:
                        {
                            DisconnectCam2();
                            UpdateText(btnStartInsp, "&START");
                            UpdateText(btnStopInsp, "&EXIT JOB");
                            //UpdateText(btnStopInsp, "EXI&T");
                            EnableControl(btnStartInsp, true);
                            EnableControl(btnStopInsp, true);
                            EnableControl(btnSettings, false);
                            EnableControl(btnMode, true);
                            UpdateStatusColor(btnScanIndicator, false);
                            UpdateText(lblStatusBar, "SYSTEM IS OFFLINE...");
                            UpdateText(txtScannedData, "");
                            UpdateStatusColor(lblStatusBar, false);
                            // UpdateStatusColor(lblScanStatus, false);
                            Trace.TraceInformation("{0}, Conveyor Stopped", DateTime.Now);
                        }
                        break;
                    case AppMode.ExitJob:
                        {
                            mLstUIDsInJob.Clear();

                            ExitJob();
                            LoadDispatchMaster();
                            TriggerQueue = new Queue<int>();
                            UpdateText(txtStartedAt, "");
                            EnableControl(cmbDispMaster, true);
                            EnableControl(btnSettings, true);
                            EnableControl(btnMode, true);
                            GoodCount = TotalBadCount = 0;
                            UpdateText(btnStartInsp, "&START JOB");
                            UpdateText(btnStopInsp, "EXI&T");
                            UpdateText(lblStatusBar, "SYSTEM IS IN STANDBY MODE...");
                            UpdateText(lblScanStatus, "");
                            UpdateText(txtScannedData, "");
                            UpdateStatusColor(lblStatusBar, true);
                            UpdateStatusColor(lblScanStatus, true);
                            Trace.TraceInformation("{0}, Job unloaded", DateTime.Now);
                        }
                        break;
                    case AppMode.ExitApp:
                        DisconnectController();
                        UpdateStatusColor(ctrlPLCDeck1, true);
                        Trace.TraceInformation("{0}, System exited", DateTime.Now);
                        ExitApplication();
                        break;
                    default:
                        break;
                }
            }
        }

        private int _GoodCount;
        public int GoodCount
        {
            get { return _GoodCount; }
            set
            {
                _GoodCount = value;
                UpdateCounts(txtGoodQty, _GoodCount);
            }
        }

        private int _TotalBadCount;
        public int TotalBadCount
        {
            get { return _TotalBadCount; }
            set
            {
                _TotalBadCount = value;
                UpdateCounts(txtBadQty, _TotalBadCount);
            }
        }

        private int _Sensor1Count;
        public int Sensor1Count
        {
            get { return _Sensor1Count; }
            set
            {
                _Sensor1Count = value;
                Sens1TotalCount++;
                UpdateText(lblSensor1Count, _Sensor1Count.ToString());
            }
        }

        private int _Sensor2Count;
        public int Sensor2Count
        {
            get { return _Sensor2Count; }
            set
            {
                _Sensor2Count = value;
                Sens2TotalCount++;
                UpdateText(lblSensor2Count, _Sensor2Count.ToString());
            }
        }

        private int _Sens1TotalCount;
        public int Sens1TotalCount
        {
            get { return _Sens1TotalCount; }
            set { _Sens1TotalCount = value; }
        }

        private int _Sens2TotalCount;
        public int Sens2TotalCount
        {
            get { return _Sens2TotalCount; }
            set { _Sens2TotalCount = value; }
        }
        private Queue<int> TriggerQueue;

        private DispatchMaster mJobMaster;
        private List<DispatchMaster> lstDispatchMasters;
        private List<DispatchDetails> lstDispDetails;

        /// <summary>
        /// mLstUIDsInJob is used to store the UID scanned and processed in currrent job.
        /// When Job is Reloaded, this need to be loaded from DB
        /// </summary>
        private List<string> mLstUIDsInJob = new List<string>();

        private decimal TotalQuantity = 0;

        #endregion Properties

        #region UI Operations

        public FrmMain(UserMaster oCurUserLogged)//, HWControl oHWControl, IRedInspection oInspectDev)
        {
            InitializeComponent();
            lblLicHolder.Text = RedSys.Integrity.GetCompName;

            bllMgr = new BLLManager();
            mCurUserLogged = oCurUserLogged;
            mJobMaster = new DispatchMaster();
            lstDispatchMasters = new List<DispatchMaster>();
            lstDispDetails = new List<DispatchDetails>();

            HasController = UTIL.SystemIntegrity.Globals.AppSettings.HasHwController;

            //mHwcValues = Globals.HWCSettings.ReadValues();

            HwAccessMode = UTIL.SystemIntegrity.Globals.AppSettings.HWMode;

            AllowFreeFlowDispatch = UTIL.SystemIntegrity.Globals.AppSettings.AllowFreeFlowDispatch;
            AllowOnlyScheduleDispatch = UTIL.SystemIntegrity.Globals.AppSettings.AllowOnlyScheduleDispatch;
            AllowOnlyProductionVerified = UTIL.SystemIntegrity.Globals.AppSettings.AllowOnlyProductionVerified;

            DispatchDaysLimit = UTIL.SystemIntegrity.Globals.AppSettings.DispatchDaysLimit;
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            BindDetails();
            InitController();

            ManualMode = !(HwAccessMode == 0 || HwAccessMode == 1);

            m_AppMode = AppMode.Start;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //   ExitApplication();
        }

        private void cmbiDspMaster_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDispatchData();
        }

        private void dgvDispDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void btnStartInsp_Click(object sender, EventArgs e)
        {
            StartClicked();
        }

        private void btnStopInsp_Click(object sender, EventArgs e)
        {
            ExitClicked();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            /// Call here PLC Settings Form
            /// 
            mfrmPLCExecutor = new frmPLCSettings(ctrlPLCDeck1);
            mfrmPLCExecutor.ShowDialog();
            mfrmPLCExecutor = null;

        }

        private void txtScannedData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtScannedData.Text.EndsWith("\n"))
                {
                    string dataCode = txtScannedData.Text = txtScannedData.Text.Replace("\n", "");
                    dataCode = dataCode.Replace("\r", "");
                    if (m_AppMode == AppMode.ConveyorStart || (m_AppMode == AppMode.Online && TriggerQueue.Count > 0))
                    {
                        ProcessInspectedData(dataCode);
                    }
                    Trace.TraceInformation("{0}, Data Scanned: {1}", DateTime.Now, dataCode);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError("{0}, Error:{1}, {2}", DateTime.Now, ex.Message, ex.StackTrace);
            }
        }

        private void btnMode_Click(object sender, EventArgs e)
        {
            if (HwAccessMode == 0)
                ManualMode = !ManualMode;
        }

        #endregion UI Operations

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDispatchMaster();
        }
    }


    //private enum DispatchMode
    //{
    //    Free = 0,
    //    Controlled = 1,
    //}

}