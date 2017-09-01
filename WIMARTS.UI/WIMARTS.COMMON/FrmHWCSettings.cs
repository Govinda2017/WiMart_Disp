using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RedCommunication.SERIAL;
using WIMARTS.UTIL;

namespace WIMARTS.COMMON
{
    public partial class FrmHWCSettings : Form
    {
        public FrmHWCSettings()
        {
            InitializeComponent();
        }


        private void FrmHWCSettings_Load(object sender, EventArgs e)
        {
            BindPorts();
            LoadSettings();
        }

        private void btnPortSettings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSerialPort.Text) == true)
            {
                MessageBox.Show("SELECT COM PORT TO PROCEED", "PRINTER CONFIGURATION SETTINGS");
                return;
            }
            CommPort cm = new CommPort(SettingsPath.SettingDir, 0, cmbSerialPort.Text);
            FrmComSettings frm = new FrmComSettings(cm);
            frm.ShowDialog();
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

        private void btnHWCSettings_Click(object sender, EventArgs e)
        {
            FrmHWCValues frm = new FrmHWCValues();
            frm.ShowDialog();
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

        private void BindPorts()
        {
            string[] SerialPorts = CommPort.GetAvailablePorts();
            cmbSerialPort.Items.Clear();
            foreach (string port in SerialPorts)
                cmbSerialPort.Items.Add(port);
        }

        private void LoadSettings()
        {
            UTIL.SystemIntegrity.Globals.HWCSettings.ReadSettings();
            cmbSerialPort.SelectedItem = UTIL.SystemIntegrity.Globals.HWCSettings.SerialPort;
        }

        private void SaveSettings()
        {
            UTIL.SystemIntegrity.Globals.HWCSettings.SerialPort = Convert.ToString(cmbSerialPort.SelectedItem);
            UTIL.SystemIntegrity.Globals.HWCSettings.WriteSettings();
            MessageBox.Show("Settings Saved Successfully......");
        }
    }
}
