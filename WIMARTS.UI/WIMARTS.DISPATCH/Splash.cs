using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIMARTS.INSPECTION;
using System.Threading;
using WIMARTS.HWController;
using System.Diagnostics;
using WIMARTS.DB.BLL;
using WIMARTS.DB.BusinessObjects;
using WIMARTS.COMMON;

namespace WIMARTS.DISPATCH
{
    enum HWCheck
    {
        Controller = 0,
        Camera1 = 1,
        Camera2 = 2,
        Login = 3,
    }

    public partial class Splash : Form
    {
        UserMaster mCurUserLogged;
        int HwAccessMode = 0;
        bool HasController = true;

        private HWCheck _ConnectHW;

        internal HWCheck NextHwConnect
        {
            get { return _ConnectHW; }
            set
            {
                _ConnectHW = value;
                switch (_ConnectHW)
                {
                    case HWCheck.Controller:
                        if (HasController)
                            ConnectHWControl();
                        else
                        {
                            NextHwConnect = HWCheck.Camera1;
                        }
                        break;
                    case HWCheck.Camera1:
                        if (HwAccessMode == 0 || HwAccessMode == 1)
                        {
                            ConnectCamera1();
                        }
                        else
                        {
                            NextHwConnect = HWCheck.Camera2;
                        }
                        break;
                    case HWCheck.Camera2:
                        if (HwAccessMode == 0 || HwAccessMode == 2)
                        {
                            ConnectCamera2();
                        }
                        else
                        {
                            NextHwConnect = HWCheck.Login;
                        }
                        break;
                    case HWCheck.Login:
                        DoLogin();
                        break;
                }
            }
        }


        public Splash()
        {
            InitializeComponent();
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            UpdateStatus("Started Checking....");
            Trace.TraceInformation("{0}, Started Checking Hardware availability", DateTime.Now);
            HwAccessMode = UTIL.SystemIntegrity.Globals.AppSettings.HWMode;
            HasController = UTIL.SystemIntegrity.Globals.AppSettings.HasHwController;

            this.Text = String.Format("STARTING {0} {1}", RedAssemblyInfo.Title, RedAssemblyInfo.Version);
            LBLCompany.Text = RedAssemblyInfo.Company;
            LBLCopyRight.Text = RedAssemblyInfo.Copyright;// "Not For Commercial Usage";//AssemblyCopyright;
            AppCode app = (AppCode)RedSys.Integrity.GetAppID;
            LBLProductName.Text = Convert.ToString(app);//RedAssemblyInfo.Title + " " + RedAssemblyInfo.Version;  LBLDescription.Text = RedAssemblyInfo.Description;
            LBLDescription.Text = RedAssemblyInfo.Description;

            LBL_Today.Text = DateTime.Now.ToString("dd-MMM-yyy HH:mm");

            LBL_LicHolder.Text = "Nilons Enterprizes Pvt Ltd";// +RedSys.Integrity.GetCompName;
            PlantCode plant = (PlantCode)RedSys.Integrity.GetUnitID;

            lblPlantName.Text ="Plant: "+ Convert.ToString(plant) + ", Line: " + RedSys.Integrity.GetLineID;
        }

        private void Splash_Shown(object sender, EventArgs e)
        {
            Thread th = new Thread(StartConnection);
            th.Start();
        }

        private void StartConnection()
        {
            NextHwConnect = HWCheck.Controller;
        }

        private void DoLogin()
        {
            FrmSignIn frm = new FrmSignIn(false);
            UpdateStatus("Do Login...");
            DialogResult dlgRes = frm.ShowDialog();
            if (dlgRes == DialogResult.OK)
            {
                //to action
                mCurUserLogged = frm.userLogged;
                Proceed2Next();
                Trace.TraceInformation("{0}, User Logged In: {1}", DateTime.Now, mCurUserLogged.UserID);
            }
            else
            {
                UpdateStatus("Login Failed......");
                Trace.TraceInformation("{0}, Login Failed", DateTime.Now);
                Thread.Sleep(2000);
                System.Windows.Forms.Application.Exit();
            }
        }

        #region HWControl

        private HWControl mHWControl;

        private void ConnectHWControl()
        {
            string SerialPort = UTIL.SystemIntegrity.Globals.HWCSettings.SerialPort;
            mHWControl = new HWControl(SerialPort);
            if (mHWControl != null)
            {
                UpdateStatus("Connecting Controller....");
                mHWControl.Connect();
                Thread.Sleep(100); 
                if (mHWControl.IsConnected() == true)
                {
                    UpdateProgressBar(50);
                    OnUpdateMessage(statusDGid++, "VERIFICATION - CONTROLLER", "FINISHED");
                    Trace.TraceInformation("{0}, HW Controller Connected, ComPort:{1}", DateTime.Now, SerialPort);
                     NextHwConnect = HWCheck.Camera1;
                }
                else
                {
                    OnUpdateMessage(statusDGid++, "VERIFICATION - CONTROLLER", "FAILED");
                    UpdateStatus("HW Controller not found...");
                    Trace.TraceInformation("{0}, HW Controller not found, Check ComPort:{1}", DateTime.Now, SerialPort);
                }
            }
            else
            {
                OnUpdateMessage(statusDGid++, "VERIFICATION - CONTROLLER", "FAILED");
                UpdateStatus("HW Controller not found...");
                Trace.TraceInformation("{0}, HW Controller not found, Check ComPort:{1}", DateTime.Now, SerialPort);
            }          
              
        }

        #endregion HWControl

        #region Camera

        private IRedInspection mInspectDev1;
        private IRedInspection mInspectDev2;

        private void ConnectCamera1()
        {
            string deviceName = UTIL.SystemIntegrity.Globals.InspectionSettings1.DeviceName;
            string IPAddress = UTIL.SystemIntegrity.Globals.InspectionSettings1.Address;
            int Port = UTIL.SystemIntegrity.Globals.InspectionSettings1.Port;

            mInspectDev1 = AccessInspectionDevice.LoadIredInspection(deviceName, IPAddress, Port);

            if (mInspectDev1 != null)
            {
                UpdateStatus("Connecting " + deviceName + "...");
                mInspectDev1.Connect();
                Thread.Sleep(200);
                UpdateProgressBar(60);
                if (mInspectDev1.IsConnected() == true)
                {
                    OnUpdateMessage(statusDGid++, "VERIFICATION - CAMERA (" + deviceName+")", "FINISHED");
                    Trace.TraceInformation("{0}, Device 1 {1} Connected, IP:{2}, Port:{3}", DateTime.Now, deviceName, IPAddress, Port);
                    NextHwConnect = HWCheck.Camera2;                 
                }
                else
                {
                    OnUpdateMessage(statusDGid++, "VERIFICATION - CAMERA (" + deviceName + ")", "FAILED");
                    UpdateStatus(deviceName + " Not Found......");
                    Trace.TraceInformation("{0}, Device 1 {1} Not Found, Check IP:{2}, Port:{3}", DateTime.Now, deviceName, IPAddress, Port);
                }
            }
        }

        private void ConnectCamera2()
        {
            string deviceName = UTIL.SystemIntegrity.Globals.InspectionSettings2.DeviceName;
            string IPAddress = UTIL.SystemIntegrity.Globals.InspectionSettings2.Address;
            int Port = UTIL.SystemIntegrity.Globals.InspectionSettings2.Port;

            mInspectDev2 = AccessInspectionDevice.LoadIredInspection(deviceName, IPAddress, Port);

            if (mInspectDev2 != null)
            {
                UpdateStatus("Connecting " + deviceName + "...");
                mInspectDev2.Connect();
                Thread.Sleep(200);
                UpdateProgressBar(90);
                if (mInspectDev2.IsConnected() == true)
                {
                    OnUpdateMessage(statusDGid++, "VERIFICATION - CAMERA (" + deviceName + ")", "FINISHED");
                    Trace.TraceInformation("{0}, Device 2 {1} Connected, IP:{2}, Port:{3}", DateTime.Now, deviceName, IPAddress, Port);
                    NextHwConnect = HWCheck.Login;
                
                }
                else
                {
                    OnUpdateMessage(statusDGid++, "VERIFICATION - CAMERA (" + deviceName + ")", "FAILED");
                    UpdateStatus(deviceName + " Not Found......");
                    Trace.TraceInformation("{0}, Device 2 {1} Not Found, Check IP:{2}, Port:{3}", DateTime.Now, deviceName, IPAddress, Port);
                }
            }
        }

        #endregion Camera

        #region DisconnectHWs()

        private void DisconectHWs()
        {
            if (mHWControl != null && mHWControl.IsConnected() == true)
            {
                mHWControl.Disconnect(); mHWControl = null;
                Trace.TraceInformation("{0}, HW Controller Disconnected", DateTime.Now);
            }
            Thread.Sleep(50);
            if (mInspectDev1 != null && mInspectDev1.IsConnected() == true)
            {
                mInspectDev1.Disconnect(); mInspectDev1 = null;
                Trace.TraceInformation("{0}, Inspection Device 1 Disconnected", DateTime.Now);
            }
            Thread.Sleep(50);
            if (mInspectDev2 != null && mInspectDev2.IsConnected() == true)
            {
                mInspectDev2.Disconnect(); mInspectDev2 = null;
                Trace.TraceInformation("{0}, Inspection Device 2 Disconnected", DateTime.Now);
            }
        }
        #endregion DisconnectHWs()

        #region OpenAPP

        private void Proceed2Next()
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { Proceed2Next(); }));
            }
            else
            {
                DisconectHWs();
                UpdateStatus("Completed Checking....");
                Trace.TraceInformation("{0}, Completed Hardware Checking", DateTime.Now);
                UpdateProgressBar(100);
                Thread th = new Thread(LaunchApplication);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
                //  Thread.Sleep(550);

            }
        }

        private void LaunchApplication()
        {
            Application.Run(new FrmMain(mCurUserLogged));
        }

        #endregion OpenAPP

        private void UpdateStatus(string Message)
        {
            if (lblStatusBar.InvokeRequired == true)
            {
                lblStatusBar.Invoke(new MethodInvoker(delegate { UpdateStatus(Message); }));
            }
            else
            {
                lblStatusBar.Text = Message;
            }
        }

        private void UpdateProgressBar(int Value)
        {
            //if (progressBar1.InvokeRequired == true)
            //{
            //    progressBar1.Invoke(new MethodInvoker(delegate { UpdateProgressBar(Value); }));
            //}
            //else
            //{
            //    progressBar1.Value = Value;
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public delegate void UpdateMessage(int id, string Message, string status);
      
        private int statusDGid = 0;
        public void OnUpdateMessage(int id, string Message, string status)
        {
            if (DG_CheckList.InvokeRequired == true)
            {
                UpdateMessage d = new UpdateMessage(OnUpdateMessage);
                this.Invoke(d, new object[] { id, Message, status });
            }
            else
            {
                if (id + 1 < DG_CheckList.Rows.Count)
                {
                    DG_CheckList[1, id].Value = Message;
                    DG_CheckList[2, id].Value = status;
                }
                else
                {
                    DG_CheckList.Rows.Add(null, Message, status);
                }

                Trace.TraceInformation("{0},{1} {2}", DateTime.Now.ToString(), Message, status);
            }
            switch (status)
            {
                case "ERROR":
                case "FAILED":
                    DG_CheckList[0, id].Value = WIMARTS.DISPATCH.Properties.Resources.Error;
                    break;
                default:
                    DG_CheckList[0, id].Value = WIMARTS.DISPATCH.Properties.Resources.check;
                    break;
            }
            Application.DoEvents();
        }
    }
}