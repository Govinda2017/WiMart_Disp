using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using rcs.CONTROLS;
using rSys;
using System.Diagnostics;
using RedXML;
using System.Xml.Serialization;
using WIMARTS.UTIL;
using CondotCombiSys.Controls;

namespace CondotCombiSys
{
    public partial class frmPLCSettings : Form
    {
        private redTrace oTrace = new redTrace(false, "frmPLCSettings");

        CtrlPLCDeck mCtrlPLCDeck = null;
        PLCSetup mPLCSetup;

        #region FormEvent

        public frmPLCSettings(CtrlPLCDeck oCtrlPLCDeck)
        {
            InitializeComponent();
            this.mCtrlPLCDeck = oCtrlPLCDeck;
        }
        private void frmPLCExecutor_Load(object sender, EventArgs e)
        {
            mPLCSetup = PLCSetup.Read(SettingsPath.PLC_Setup);
            if (mPLCSetup == null)
                throw new Exception("Failed to read the PLC_Setup data");

            LoadPLCParameterSettings();
            SetupHMIIPParamSetActions(); 
            SetupHMIOPParamSetActions();
        }
        private void frmPLCExecutor_Shown(object sender, EventArgs e)
        {
            btnReadParameterSettings_Click(btnReadParameterSettings, null);
        }
        private void frmPLCExecutor_SizeChanged(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }
        private void frmPLCExecutor_Enter(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        private void frmPLCExecutor_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void frmPLCExecutor_FormClosed(object sender, FormClosedEventArgs e)
        {
            mCtrlPLCDeck.SkipAutoCmdTimer = false;
            mCtrlPLCDeck.ReadAllParameterSettings_InProg = false;
            mCtrlPLCDeck.HMIInputTestMode_InProg = false;
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        public void UpdatePLCLogDisplay(string LogData, int Value)
        {
            string[] logs = LogData.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (logs != null && logs.Length >= 2)
                OnAddMessage(logs[0], logs[1]);
        }

        #endregion FormEvent

        #region UIEvent_ParameterSettings

        private void LoadPLCParameterSettings()
        {
            dgvParamSettings.Rows.Clear();

            PLCRegister.SetupParamSettReg(mPLCSetup.List4PLCParameterSettings);
            foreach (PLCParameterSettings item in mPLCSetup.List4PLCParameterSettings)
            {
                AddPLCParamData2Grid(item.Component, item.Description, item.Register, item.CurValue, item.NewValue, item.Unit);
            }

            //if (mAppType == eCSPLExecMode.CSPL_800UD || mAppType == eCSPLExecMode.CSPL_800AD)
            //{
            //    AddData2Grid("Printer", "Delay", "1000", "0", "0", "mm");
            //    //AddData2Grid("Printer", "PulseonTime", "1002", "0", "0", "ms");
            //    AddData2Grid("RejectionMarker", "Delay", "1008", "0", "0", "mm");
            //}
            //else if (mAppType == eCSPLExecMode.CSPL_1070UD || mAppType == eCSPLExecMode.CSPL_2450)
            //{
            //    AddData2Grid("Recipe", "Count", "1000", "0", "0", "nos");
            //    AddData2Grid("Recipe", "Reset", "1002", "0", "0", " ");
            //}
            //AddData2Grid("Vision", "Delay", "1004", "0", "0", "mm");
            ////AddData2Grid("Vision", "PulseonTime", "1006", "0", "0", "ms");
            //AddData2Grid("RejectionMechanism", "Delay", "1012", "0", "0", "mm");
            //AddData2Grid("RejectionMechanism", "PulseonTime", "1014", "0", "0", "ms");
            //AddData2Grid("Rejectionconfirmationsensor", "OnTime", "1016", "0", "0", "ms");
            //AddData2Grid("AcceptedConfirmationSensor", "Distance", "1018", "0", "0", "mm");
            //AddData2Grid("Tolerance", "Value", "1020", "0", "0", "mm");
            //AddData2Grid("Consecutiverejection", "Quantity", "1022", "0", "0", "Nos");
            //AddData2Grid("EncoderPPR", "PPR", "1040", "0", "0", "PPR");
            //AddData2Grid("EncoderWheelCircumference", "Circumference", "1038", "0", "0", "mm");
            //AddData2Grid("ProductSensorBlockDelay", "Delay", "1044", "0", "0", "ms");
            //AddData2Grid("RejectSensorBlockDelay", "Delay", "1046", "0", "0", "ms");
            //AddData2Grid("AcceptedSensorBlockDelay", "Delay", "1048", "0", "0", "ms");
            //AddData2Grid("NoEncoderPulseDelay", "Time", "1050", "0", "0", "ms");
            //AddData2Grid("BeltLength", "Inmm", "1056", "0", "0", "mm");
        }
        void AddPLCParamData2Grid(string oComponent, string oDescription, string oRegister, string oCurValue, string oNewValue, string oUnit)
        {
            int index = dgvParamSettings.Rows.Add();
            dgvParamSettings.Rows[index].Cells["Component"].Value = oComponent;
            dgvParamSettings.Rows[index].Cells["Description"].Value = oDescription;
            dgvParamSettings.Rows[index].Cells["Register"].Value = oRegister;
            dgvParamSettings.Rows[index].Cells["CurValue"].Value = oCurValue;
            dgvParamSettings.Rows[index].Cells["NewValue"].Value = oNewValue;
            dgvParamSettings.Rows[index].Cells["Unit"].Value = oUnit;
        }

        private void btnReadParameterSettings_Click(object sender, EventArgs e)
        {
            btnReadParameterSettings.Enabled = false;
            foreach (DataGridViewRow item in dgvParamSettings.Rows)
            {
                item.Cells["CurValue"].Value = "0000";
            }
            mCtrlPLCDeck.ReadAllParameterSettings_InProg = true;
            mCtrlPLCDeck.SendData(PLCProtocol.RegisterValRead, dgvParamSettings.Rows[0].Cells["Register"].Value.ToString(), 1);
            btnReadParameterSettings.Enabled = true;
        }
        private void btnUploadSettings_Click(object sender, EventArgs e)
        {
            if (dgvParamSettings.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvSelRow = dgvParamSettings.SelectedRows[0];
                string description = Convert.ToString(dgvSelRow.Cells["Component"].Value);
                int oldVal = Convert.ToInt32(dgvSelRow.Cells["CurValue"].Value);
                int newVal = Convert.ToInt32(dgvSelRow.Cells["NewValue"].Value);
                mCtrlPLCDeck.SendData(PLCProtocol.RegisterValWrite, dgvSelRow.Cells["Register"].Value.ToString(), newVal);
            }
        }
        
        public void UpdatePLCParameterSettings(string RegisterNo, int RegisterValue)
        {
            foreach (DataGridViewRow item in dgvParamSettings.Rows)
            {
                if (item.Cells["Register"].Value.ToString() == RegisterNo)
                {
                    item.Cells["CurValue"].Value = RegisterValue.ToString().PadLeft(PLCProtocol.PLCRegValueLen, '0');
                    break;
                }
            }
        }
        
        #endregion UIEvent_ParameterSettings
        
        #region UIEvent_HMIInput

        List<HMIParamCtrlHolder> lHMIParamCtrlHolder_HMIIPParam = new List<HMIParamCtrlHolder>();

        void SetupHMIIPParamSetActions()
        {
            if (mPLCSetup == null || mPLCSetup.List4PLCHMIIPParameterSettings == null)
                return;

            HMIParamCtrlHolder oHMIParamCtrlHolder; 
            int ctrlCounter = 0;
            //foreach (PLCHMIOPParameterSettings item in mPLCSetup.List4PLCHMIIPParameterSettings)
            for (int i = mPLCSetup.List4PLCHMIIPParameterSettings.Count - 1; i >= 0; i--)
            {
                PLCHMIIPParameterSettings item = mPLCSetup.List4PLCHMIIPParameterSettings[i];

                PLCRegister.HMIInputReg = mPLCSetup.HMIInputReg;
                PLCRegister.HMIInputRegLen2Read = mPLCSetup.HMIInputRegLen2Read;

                Control oHMIPramCtrl = AddHMIIPCtrl(ctrlCounter, item.HMIOPParam_Name, item.HMIIPParam_Text);

                oHMIParamCtrlHolder = new HMIParamCtrlHolder(oHMIPramCtrl, item.HMIIPParam_ID, mPLCSetup.HMIInputReg, item.HMIIPParam_BitPosition);
                lHMIParamCtrlHolder_HMIIPParam.Add(oHMIParamCtrlHolder);
                
                ctrlCounter++;
            }
        }
        Control AddHMIIPCtrl(int ctrlCounter, string oHMIIPParam_Name, string oHMIIPParam_Text)
        {
            const int CtrlHMIParamSet_Height = 26;

            Label lblHMITIO = new Label();
            // 
            // lblHMITIO
            // 
            lblHMITIO.BackColor = System.Drawing.Color.White;
            lblHMITIO.Dock = System.Windows.Forms.DockStyle.Top;
            lblHMITIO.ForeColor = System.Drawing.Color.Black;
            lblHMITIO.Location = new System.Drawing.Point(0, (ctrlCounter * CtrlHMIParamSet_Height));
            lblHMITIO.Name = "lbl" + oHMIIPParam_Name;
            lblHMITIO.Size = new System.Drawing.Size(312, CtrlHMIParamSet_Height);
            lblHMITIO.TabIndex = 33;
            lblHMITIO.Text = oHMIIPParam_Text;
            lblHMITIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblHMITIO.Visible = false;
            
            // Add control to Parent Panel of Form
            panHMITestInput.Controls.Add(lblHMITIO);
            return lblHMITIO;
        }

        private void btnHMIInputTestMode_Click(object sender, EventArgs e)
        {
            mCtrlPLCDeck.HMIInputTestMode_InProg = !mCtrlPLCDeck.HMIInputTestMode_InProg;
            btnHMIInputTestMode.Text = (mCtrlPLCDeck.HMIInputTestMode_InProg == true ? "START" : "STOP") + " INPUT TEST";
        }

        public void UpdateHMI_InputStatus(string RegisterNo, int RegisterValue)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { UpdateHMI_InputStatus(RegisterNo, RegisterValue); }));
            }
            else
            {
                oTrace.AddTrace(redTrace.Level.Information, string.Format("UpdateHMI_InputStatus,{0},{1}", RegisterNo, RegisterValue));

                byte[] resultBin = DataConvert.IntegerBinaryConvertM0(RegisterValue, 16);
                for (int bitPos = 0; bitPos < resultBin.Length; bitPos++)
                {
                    HMIParamCtrlHolder oHMIParamCtrlHolder = lHMIParamCtrlHolder_HMIIPParam.Find(item => item.RegistorNo == RegisterNo && item.BitPosition == bitPos);
                    if (oHMIParamCtrlHolder != null)
                    {
                        oTrace.AddTrace(redTrace.Level.Information, string.Format("HMIInputReg at Position:{0},Result={1}", bitPos, resultBin[bitPos]));
                        CommonUI.UpdateErrorIndicator(oHMIParamCtrlHolder.HMIPramCtrl, resultBin[bitPos]);
                    }
                }
            }
        }

        #endregion UIEvent_HMIInput

        #region UIEvent_HMIOutput

        List<HMIParamCtrlHolder> lHMIParamCtrlHolder_HMIOPParam = new List<HMIParamCtrlHolder>();
        void SetupHMIOPParamSetActions()
        {
            if (mPLCSetup == null || mPLCSetup.List4PLCHMIOPParameterSettings == null)
                return;

            HMIParamCtrlHolder oHMIParamCtrlHolder;
            int ctrlCounter=0;
            //foreach (PLCHMIOPParameterSettings item in mPLCSetup.List4PLCHMIOPParameterSettings)
            for (int i = mPLCSetup.List4PLCHMIOPParameterSettings.Count-1; i >=0; i--)
            {
                PLCHMIOPParameterSettings item = mPLCSetup.List4PLCHMIOPParameterSettings[i];

                Control oHMIPramCtrl = AddHMIOPCtrl(ctrlCounter, item.HMIOPParam_Name, item.PLCParamCaption, item.OperBtnNameOff, item.OperBtnNameOn, item.HMIOPParam_ID);

                oHMIParamCtrlHolder = new HMIParamCtrlHolder(oHMIPramCtrl, item.HMIOPParam_ID, item.HMIOPParam_Register, item.HMIOPParam_BitPosition);
                lHMIParamCtrlHolder_HMIOPParam.Add(oHMIParamCtrlHolder);                

                ctrlCounter++;
            }
        }

        /// <summary>
        /// AddHMIOPCtrl
        /// </summary>
        /// <param name="ctrlCounter">0 based counter for number of control added for location</param>
        /// <param name="oHMIOPParam_Name"></param>
        /// <param name="oPLCParam"></param>
        /// <param name="oOperBtnNameOff"></param>
        /// <param name="oOperBtnNameOn"></param>
        /// <param name="oHMIOPParam_ID"></param>
        Control AddHMIOPCtrl(int ctrlCounter, string oHMIOPParam_Name, string oPLCParam, string oOperBtnNameOff, string oOperBtnNameOn, int oHMIOPParam_ID)
        {
            const int CtrlHMIParamSet_Height = 26;

            CtrlHMIParamSet ctrlHMIParamSet = new CtrlHMIParamSet();
            // 
            // ctrlHMIParamSet
            // 
            ctrlHMIParamSet.Dock = System.Windows.Forms.DockStyle.Top;
            ctrlHMIParamSet.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            ctrlHMIParamSet.HMIOPParam_ID = oHMIOPParam_ID;
            ctrlHMIParamSet.Location = new System.Drawing.Point(0, ctrlCounter * CtrlHMIParamSet_Height);
            ctrlHMIParamSet.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            ctrlHMIParamSet.MaximumSize = new System.Drawing.Size(0, 162);
            ctrlHMIParamSet.MinimumSize = new System.Drawing.Size(0, CtrlHMIParamSet_Height);
            ctrlHMIParamSet.Name = "ctrlHMIParamSet_" + (ctrlCounter + 1);
            ctrlHMIParamSet.OperBtnNameOff = oOperBtnNameOff;   // "OFF" / "DISABLE"
            ctrlHMIParamSet.OperBtnNameOn = oOperBtnNameOn;     // "ON"  / "ENABLE"
            ctrlHMIParamSet.PLCParamCaption = oPLCParam;               // "Printer";
            ctrlHMIParamSet.Size = new System.Drawing.Size(312, CtrlHMIParamSet_Height);
            ctrlHMIParamSet.TabIndex = 54;

            // Add control to Parent Panel of Form
            this.panHMITestOutpu.Controls.Add(ctrlHMIParamSet);
            ctrlHMIParamSet.OnParamAction += new CtrlHMIParamSet.delParamAction(ctrlHMIParamSet_OnParamAction);

            return ctrlHMIParamSet;
        }

        void ctrlHMIParamSet_OnParamAction(int HMIOPParam_ID, string PLCParamCaption, CtrlHMIParamSet.Action action2Perform)
        {
            HMIParamCtrlHolder oHMIParamCtrlHolder = lHMIParamCtrlHolder_HMIOPParam.Find(item => item.HMIParam_ID == HMIOPParam_ID);
            if (oHMIParamCtrlHolder == null)
            {
                throw new Exception("Invalid ctrlHMIParamSet_OnParamAction operation called with " + HMIOPParam_ID + " " + PLCParamCaption + " " + action2Perform);
            }
            string RegisterID = oHMIParamCtrlHolder.RegistorNo;

            int ParamValue = 0;

            bool retValue = getHMIOutPut_ParamValue(HMIOPParam_ID, action2Perform, out RegisterID, out ParamValue);
            if (retValue == true)
                if (string.IsNullOrEmpty(RegisterID) == false)
                {
                    mCtrlPLCDeck.SendData(PLCProtocol.RegisterValWrite, RegisterID, ParamValue);
                }
        }
        bool getHMIOutPut_ParamValue(int oHMIOPParam_ID, CtrlHMIParamSet.Action action, out string RegisterID, out int ParamValue)
        {
            bool retValue = false;
            RegisterID = string.Empty;
            ParamValue = 0;

            HMIParamCtrlHolder oHMIParamCtrlHolder = lHMIParamCtrlHolder_HMIOPParam.Find(item => item.HMIParam_ID == oHMIOPParam_ID);

            if (oHMIParamCtrlHolder != null)
            {
                RegisterID = oHMIParamCtrlHolder.RegistorNo;
                int bitPos = oHMIParamCtrlHolder.BitPosition;

                if (action == CtrlHMIParamSet.Action.ON)
                {
                    int[] intArray = new int[1];
                    var bitArray = new BitArray(intArray);
                    bitArray.Set(bitPos, true);
                    bitArray.CopyTo(intArray, 0);
                    ParamValue = intArray[0];
                }
                else
                    ParamValue = 0;
                return true;
            }
            return retValue;
        }

        #endregion UIEvent_HMIOutput

        #region WATCH

        int showWatch = 0;

        private void lblHMI_Input_Click(object sender, EventArgs e)
        {
            showWatch++;
            if (showWatch > 1)
            {
                panPLCWatch.Visible = true;
                panPLCWatch.BringToFront();
                showWatch = 0;
            }
            else
                panPLCWatch.Visible = false;
        }

        string concatData = string.Empty;

        private void OnAddMessage(string sMessage, string status)
        {
            if (this.InvokeRequired == true)
            {
                this.Invoke(new MethodInvoker(delegate { OnAddMessage(sMessage, status); }));
            }
            else
            {
                lblStatusMsg.Text = status;

                if (string.IsNullOrEmpty(sMessage) == true)
                    return;

                concatData = sMessage;
                //hkjhjkh

                txtICData.Text = DataConvert.DisplaybleTextValues(concatData);
                //txtICDataAscii.Text = DataConvert.DisplaybleAsciiValues(concatData);
                //txtICDataHex.Text = DataConvert.DisplaybleHexValues(concatData);

                //lblByteCounts.Text = concatData.Length.ToString();


                string data2Add = string.Empty;
                lstSentRecievedData.Items.Add(data2Add + DataConvert.DisplaybleTextValues(concatData));

                //if (chkConcatIncoming.Checked == false)
                concatData = string.Empty;
            }
        }

        private void btnShowCommand_Click(object sender, EventArgs e)
        {
            if (cmbPLCOperation.SelectedIndex < 0)
                return;
            if (cmbPLCRegister.SelectedIndex < 0 && cmbPLCRegister.SelectedItem == null && string.IsNullOrEmpty(cmbPLCRegister.Text) == true)
                return;

            string register = (cmbPLCRegister.SelectedItem != null ? cmbPLCRegister.SelectedItem.ToString() : cmbPLCRegister.Text);

            string command = mCtrlPLCDeck.SendMessageNGet(cmbPLCOperation.SelectedItem.ToString(), register, (int)nudValue.Value);
            txtCommand.Text = command;
        }
        private void btnAutoCmdTimer_Click(object sender, EventArgs e)
        {
            mCtrlPLCDeck.SkipAutoCmdTimer = !mCtrlPLCDeck.SkipAutoCmdTimer;
        }
        private void btnSendCommand_Click(object sender, EventArgs e)
        {
            if (cmbPLCOperation.SelectedIndex < 0)
                return;
            if (cmbPLCRegister.SelectedIndex < 0 && cmbPLCRegister.SelectedItem == null && string.IsNullOrEmpty(cmbPLCRegister.Text) == true)
                return;

            string register = (cmbPLCRegister.SelectedItem != null ? cmbPLCRegister.SelectedItem.ToString() : cmbPLCRegister.Text);
            mCtrlPLCDeck.SendData(cmbPLCOperation.SelectedItem.ToString(), register, (int)nudValue.Value);
                                    
        }
        private void btnClearList_Click(object sender, EventArgs e)
        {
            lstSentRecievedData.Items.Clear();
        }

        #endregion WATCH

        class HMIParamCtrlHolder
        {
            public System.Windows.Forms.Control HMIPramCtrl;
            public int HMIParam_ID;
            public string RegistorNo;
            public int BitPosition;

            public HMIParamCtrlHolder(System.Windows.Forms.Control oHMIPramCtrl, int oHMIParam_ID, string oRegistorNo, int oBitPosition)
            {
                this.HMIPramCtrl = oHMIPramCtrl;
                this.HMIParam_ID = oHMIParam_ID;
                this.RegistorNo = oRegistorNo;
                this.BitPosition = oBitPosition;
            }
        }

    }
}
