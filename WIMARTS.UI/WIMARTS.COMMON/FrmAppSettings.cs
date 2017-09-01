using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WIMARTS.COMMON
{
    public partial class FrmAppSettings : Form
    {
        public FrmAppSettings()
        {
            InitializeComponent();
        }

        private void FrmAppSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (btnClose.Text == "&CLOSE")
            {
                this.Close();
              //  btnClose.Text = "&CANCEL";
            }
            else
            {
                LoadData();
                splitContainer1.Panel1.Enabled = false;
                btnClose.Text = "&CLOSE";
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&EDIT")
            {
                splitContainer1.Panel1.Enabled = true;
                btnEdit.Text = "&SAVE";
                btnClose.Text = "&CANCEL";
            }
            else
            {
                SaveData();
                splitContainer1.Panel1.Enabled = false;
                btnEdit.Text = "&EDIT";
            }
        }

        private void LoadData()
        {
            UTIL.SystemIntegrity.Globals.AppSettings.ReadSettings();

            chkbStrictDisp.Checked = UTIL.SystemIntegrity.Globals.AppSettings.AllowOnlyScheduleDispatch;
            chkProductionVerified.Checked = UTIL.SystemIntegrity.Globals.AppSettings.AllowOnlyProductionVerified;
            chkFreeFlowDispatch.Checked = UTIL.SystemIntegrity.Globals.AppSettings.AllowFreeFlowDispatch;

            chkbHwCtrlr.Checked = UTIL.SystemIntegrity.Globals.AppSettings.HasHwController;
           // txtBatchName.Text = UTIL.SystemIntegrity.Globals.AppSettings.BatchNameFormat;
            cmbHwMode.SelectedIndex = UTIL.SystemIntegrity.Globals.AppSettings.HWMode;
            numDispDayLimit.Value = UTIL.SystemIntegrity.Globals.AppSettings.DispatchDaysLimit;
        }

        private void SaveData()
        {
            UTIL.SystemIntegrity.Globals.AppSettings.AllowOnlyScheduleDispatch = chkbStrictDisp.Checked;
            UTIL.SystemIntegrity.Globals.AppSettings.AllowOnlyProductionVerified = chkProductionVerified.Checked;
            UTIL.SystemIntegrity.Globals.AppSettings.AllowFreeFlowDispatch = chkFreeFlowDispatch.Checked;

            UTIL.SystemIntegrity.Globals.AppSettings.HasHwController = chkbHwCtrlr.Checked;
         //   UTIL.SystemIntegrity.Globals.AppSettings.BatchNameFormat = txtBatchName.Text;
            UTIL.SystemIntegrity.Globals.AppSettings.HWMode = cmbHwMode.SelectedIndex;
            UTIL.SystemIntegrity.Globals.AppSettings.DispatchDaysLimit = Convert.ToInt32(numDispDayLimit.Value);
            UTIL.SystemIntegrity.Globals.AppSettings.WriteSettings();
            MessageBox.Show("Settings Saved Successfully");
        }
    
    }
}
