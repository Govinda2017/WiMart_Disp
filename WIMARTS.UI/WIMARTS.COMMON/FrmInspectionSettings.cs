using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WIMARTS.INSPECTION;
using RedCommunication.SERIAL;
using WIMARTS.UTIL;

namespace WIMARTS.COMMON
{
    public partial class FrmInspectionSettings : Form
    {
        List<string> lstDevice;

        public FrmInspectionSettings()
        {
            InitializeComponent();
        }

        private void FrmInspectionSettings_Load(object sender, EventArgs e)
        {
            BindPorts();
            BindDevices();
            LoadSettings();
        }

        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbDevice1.SelectedIndex > 0)
            //    pnlTCP1.Visible = true;
            //else
            //    pnlTCP1.Visible = false;
        }

        private void cmbDevice2_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void BindDevices()
        {
            lstDevice = AccessInspectionDevice.GetDevices();
            foreach (string item in lstDevice)
            {
                cmbDevice1.Items.Add(item);
                cmbDevice2.Items.Add(item);
            }
        }

        private void LoadSettings()
        {
            UTIL.SystemIntegrity.Globals.InspectionSettings1.ReadSettings();
            cmbDevice1.SelectedItem = UTIL.SystemIntegrity.Globals.InspectionSettings1.DeviceName;
            rbtnSerial1.Checked = UTIL.SystemIntegrity.Globals.InspectionSettings1.IsSerial;
            if (rbtnSerial1.Checked == true)
                cmbSerialPort1.Text = UTIL.SystemIntegrity.Globals.InspectionSettings1.Address;
            else
                txtIPAddress1.Text = UTIL.SystemIntegrity.Globals.InspectionSettings1.Address;
            tNumPort1.Text = Convert.ToString(UTIL.SystemIntegrity.Globals.InspectionSettings1.Port);
          
            cmbDevice2.SelectedItem = UTIL.SystemIntegrity.Globals.InspectionSettings2.DeviceName;
            rbtnSerial2.Checked = UTIL.SystemIntegrity.Globals.InspectionSettings2.IsSerial;
            if (rbtnSerial2.Checked == true)
                cmbSerialPort2.Text = UTIL.SystemIntegrity.Globals.InspectionSettings2.Address;
            else
                txtIPAddress2.Text = UTIL.SystemIntegrity.Globals.InspectionSettings2.Address;
            tNumPort2.Text = Convert.ToString(UTIL.SystemIntegrity.Globals.InspectionSettings2.Port);
          }

        private void SaveSettings()
        {
            UTIL.SystemIntegrity.Globals.InspectionSettings1.DeviceName = Convert.ToString(cmbDevice1.SelectedItem);
            UTIL.SystemIntegrity.Globals.InspectionSettings1.IsSerial = rbtnSerial1.Checked;
            if (rbtnSerial1.Checked == true)
                UTIL.SystemIntegrity.Globals.InspectionSettings1.Address = cmbSerialPort1.Text;
            else
                UTIL.SystemIntegrity.Globals.InspectionSettings1.Address = txtIPAddress1.Text;
            UTIL.SystemIntegrity.Globals.InspectionSettings1.Port = Convert.ToInt32(tNumPort1.Text);
            UTIL.SystemIntegrity.Globals.InspectionSettings1.WriteSettings();

            UTIL.SystemIntegrity.Globals.InspectionSettings2.DeviceName = Convert.ToString(cmbDevice2.SelectedItem);
            UTIL.SystemIntegrity.Globals.InspectionSettings2.IsSerial = rbtnSerial2.Checked;
            if (rbtnSerial2.Checked == true)
                UTIL.SystemIntegrity.Globals.InspectionSettings2.Address = cmbSerialPort2.Text;
            else
                UTIL.SystemIntegrity.Globals.InspectionSettings2.Address = txtIPAddress2.Text;
            UTIL.SystemIntegrity.Globals.InspectionSettings2.Port = Convert.ToInt32(tNumPort2.Text);
            UTIL.SystemIntegrity.Globals.InspectionSettings2.WriteSettings();

            MessageBox.Show("Settings Saved Successfully......");

        }

        private void btnPortSettings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSerialPort1.Text) == true)
            {
                MessageBox.Show("SELECT COM PORT TO PROCEED", "PRINTER CONFIGURATION SETTINGS");
                return;
            }
            CommPort cm = new CommPort(SettingsPath.SettingDir, 0, cmbSerialPort1.Text);
            FrmComSettings frm = new FrmComSettings(cm);
            frm.ShowDialog();
        }

        private void BindPorts()
        {
            string[] SerialPorts = CommPort.GetAvailablePorts();
            cmbSerialPort1.Items.Clear();
            foreach (string port in SerialPorts)
                cmbSerialPort1.Items.Add(port);

            cmbSerialPort2.Items.Clear();
            foreach (string port in SerialPorts)
                cmbSerialPort2.Items.Add(port);
        }

        private void btnPortSettings2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbSerialPort2.Text) == true)
            {
                MessageBox.Show("SELECT COM PORT TO PROCEED", "PRINTER CONFIGURATION SETTINGS");
                return;
            }
            CommPort cm = new CommPort(SettingsPath.SettingDir, 0, cmbSerialPort2.Text);
            FrmComSettings frm = new FrmComSettings(cm);
            frm.ShowDialog();
        }

        private void rbtnSerial2_CheckedChanged(object sender, EventArgs e)
        {
            rbtnTCP2.Checked = pnlTCP2.Visible = !rbtnSerial2.Checked;
            pnlSerial2.Visible = rbtnSerial2.Checked;
        }

        private void rbtnSerial1_CheckedChanged(object sender, EventArgs e)
        {
            rbtnTCP1.Checked = pnlTCP1.Visible = !rbtnSerial1.Checked;
            pnlSerial1.Visible = rbtnSerial1.Checked;
        }
    }
}