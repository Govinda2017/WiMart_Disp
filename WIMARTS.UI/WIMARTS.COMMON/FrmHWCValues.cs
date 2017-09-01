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
    public partial class FrmHWCValues : Form
    {
        UTIL.SystemIntegrity.Globals.HWCValues mHWValues;

        public FrmHWCValues()
        {
            InitializeComponent();
        }

        private void FrmHWCValues_Load(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "&EDIT")
            {
                splitContainer1.Panel1.Enabled = true;
                btnSave.Text = "&SAVE";
                btnCancel.Text = "&CANCEL";
            }
            else
            {
                splitContainer1.Panel1.Enabled = false;
                btnSave.Text = "&EDIT";
                btnCancel.Text = "&CLOSE";
                SaveSettings();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "&CLOSE")
            {
                this.Close();
            }
            else
            {
                splitContainer1.Panel1.Enabled = false;
                btnSave.Text = "&EDIT";
                btnCancel.Text = "&CLOSE";
            }
        }
        private void LoadSettings()
        {
            mHWValues = UTIL.SystemIntegrity.Globals.HWCSettings.ReadValues();
            tNumSettingTrigger.Text = Convert.ToString(mHWValues.SettingsTriggerDelay);
            tNumSettingPulse.Text = Convert.ToString(mHWValues.SettingsPulseDelay);
            tNumTriggerDelay.Text = Convert.ToString(mHWValues.CamTriggerDelay);
            tNumPulseDelay.Text = Convert.ToString(mHWValues.CamPulseDelay);
            bool convDir = Convert.ToBoolean(mHWValues.ConveyorDirection);
            rbtnReverse.Checked = convDir;
            cmbErrorAct.SelectedIndex = mHWValues.ErrorAction;
        }

        private void SaveSettings()
        {
            mHWValues.SettingsTriggerDelay = Convert.ToInt32(tNumSettingTrigger.Text);
            mHWValues.SettingsPulseDelay = Convert.ToInt32(tNumSettingPulse.Text);
            mHWValues.CamTriggerDelay = Convert.ToInt32(tNumTriggerDelay.Text);
            mHWValues.CamPulseDelay = Convert.ToInt32(tNumPulseDelay.Text);
            mHWValues.ConveyorDirection = Convert.ToInt32(rbtnReverse.Checked);
            mHWValues.ErrorAction = cmbErrorAct.SelectedIndex;
            UTIL.SystemIntegrity.Globals.HWCSettings.WriteValues(mHWValues);
            MessageBox.Show("Settings Saved Successfully......");
        }
    }
}