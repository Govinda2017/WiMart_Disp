using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace RedCommunication.SERIAL
{
    public partial class FrmComSettings : Form
    {
        CommPort comport;
        public FrmComSettings(CommPort port)
        {
            comport = port;
            InitializeComponent();
            int found = 0;

            string SerialPorts = CommPort.GetAvailablePorts();
            string[] portList = SerialPorts.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            
            for (int i=0; i<portList.Length; ++i)
            {
                string name = portList[i];
                if (string.IsNullOrEmpty(name) == false) 
                comboBox1.Items.Add(name);
                if (name == comport.Settings.Port.PortName)
                    found = i;
            }
            if (portList.Length > 0)
                comboBox1.SelectedIndex = found;

            Int32[] baudRates = {
                100,300,600,1200,2400,4800,9600,14400,19200,
                38400,56000,57600,115200,128000,256000,0
            };
            found = 0;
            for (int i=0; baudRates[i] != 0; ++i)
            {
                comboBox2.Items.Add(baudRates[i].ToString());
                if (baudRates[i] == comport.Settings.Port.BaudRate)
                    found = i;
            }
            comboBox2.SelectedIndex = found;

            comboBox3.Items.Add("5");
            comboBox3.Items.Add("6");
            comboBox3.Items.Add("7");
            comboBox3.Items.Add("8");
            comboBox3.SelectedIndex = comport.Settings.Port.DataBits - 5;

            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                comboBox4.Items.Add(s);
            }
            comboBox4.SelectedIndex = (int)comport.Settings.Port.Parity;

            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                comboBox5.Items.Add(s);
            }
            comboBox5.SelectedIndex = (int)comport.Settings.Port.StopBits;

            foreach (string s in Enum.GetNames(typeof(Handshake)))
            {
                comboBox6.Items.Add(s);
            }
            comboBox6.SelectedIndex = (int)comport.Settings.Port.Handshake;

            switch (comport.Settings.Option.AppendToSend)
            {
                case AppendType.AppendNothing:
                    radioButton1.Checked = true;
                    break;
                case AppendType.AppendCR:
                    radioButton2.Checked = true;
                    break;
                case AppendType.AppendLF:
                    radioButton3.Checked = true;
                    break;
                case AppendType.AppendCRLF:
                    radioButton4.Checked = true;
                    break;
            }

            checkBox1.Checked = comport.Settings.Option.HexOutput;
            checkBox2.Checked = comport.Settings.Option.MonoFont;
            checkBox3.Checked = comport.Settings.Option.LocalEcho;
            checkBox4.Checked = comport.Settings.Option.StayOnTop;
			checkBox5.Checked = comport.Settings.Option.FilterUseCase;

			textBox1.Text = comport.Settings.Option.LogFileName;
		}

		// OK
		private void button1_Click(object sender, EventArgs e)
		{
            comport.Settings.Port.PortName = comboBox1.Text;
            comport.Settings.Port.BaudRate = Int32.Parse(comboBox2.Text);
            comport.Settings.Port.DataBits = comboBox3.SelectedIndex + 5;
            comport.Settings.Port.Parity = (Parity)comboBox4.SelectedIndex;
            comport.Settings.Port.StopBits = (StopBits)comboBox5.SelectedIndex;
            comport.Settings.Port.Handshake = (Handshake)comboBox6.SelectedIndex;

			if (radioButton2.Checked)
                comport.Settings.Option.AppendToSend = AppendType.AppendCR;
			else if (radioButton3.Checked)
                comport.Settings.Option.AppendToSend = AppendType.AppendLF;
			else if (radioButton4.Checked)
                comport.Settings.Option.AppendToSend = AppendType.AppendCRLF;
			else
                comport.Settings.Option.AppendToSend = AppendType.AppendNothing;

            comport.Settings.Option.HexOutput = checkBox1.Checked;
            comport.Settings.Option.MonoFont = checkBox2.Checked;
            comport.Settings.Option.LocalEcho = checkBox3.Checked;
            comport.Settings.Option.StayOnTop = checkBox4.Checked;
            comport.Settings.Option.FilterUseCase = checkBox5.Checked;

            comport.Settings.Option.LogFileName = textBox1.Text;
            comport.Open();
            comport.Settings.Write();

			Close();
		}

		// Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

		private void button3_Click(object sender, EventArgs e)
        {
            comport.Settings.Option.LogFileName = "";

            SaveFileDialog fileDialog1 = new SaveFileDialog();

            fileDialog1.Title = "Save Log As";
            fileDialog1.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*";
            fileDialog1.FilterIndex = 2;
            fileDialog1.RestoreDirectory = true;
			fileDialog1.FileName = comport.Settings.Option.LogFileName;

            if (fileDialog1.ShowDialog() == DialogResult.OK)
            {
				textBox1.Text = fileDialog1.FileName;
				if (File.Exists(textBox1.Text))
					File.Delete(textBox1.Text);
			}
            else
            {
				textBox1.Text = "";
            }
        }
    }
}