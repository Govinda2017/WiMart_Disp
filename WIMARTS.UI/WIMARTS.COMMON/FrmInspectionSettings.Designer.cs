namespace WIMARTS.COMMON
{
    partial class FrmInspectionSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.pnlTCP1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tNumPort1 = new RedRapidUI.TNumEditBox();
            this.txtIPAddress1 = new System.Windows.Forms.TextBox();
            this.cmbDevice1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSerialPort1 = new System.Windows.Forms.ComboBox();
            this.btnPortSettings1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitMain1 = new System.Windows.Forms.SplitContainer();
            this.rbtnSerial1 = new System.Windows.Forms.RadioButton();
            this.rbtnTCP1 = new System.Windows.Forms.RadioButton();
            this.pnlSerial1 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitMain2 = new System.Windows.Forms.SplitContainer();
            this.rbtnSerial2 = new System.Windows.Forms.RadioButton();
            this.rbtnTCP2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbDevice2 = new System.Windows.Forms.ComboBox();
            this.pnlSerial2 = new System.Windows.Forms.Panel();
            this.cmbSerialPort2 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPortSettings2 = new System.Windows.Forms.Button();
            this.pnlTCP2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tNumPort2 = new RedRapidUI.TNumEditBox();
            this.txtIPAddress2 = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlTCP1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.splitMain1.Panel1.SuspendLayout();
            this.splitMain1.Panel2.SuspendLayout();
            this.splitMain1.SuspendLayout();
            this.pnlSerial1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.splitMain2.Panel1.SuspendLayout();
            this.splitMain2.Panel2.SuspendLayout();
            this.splitMain2.SuspendLayout();
            this.pnlSerial2.SuspendLayout();
            this.pnlTCP2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(213, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 38);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "&CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MistyRose;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(46, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 38);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "&EDIT";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pnlTCP1
            // 
            this.pnlTCP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTCP1.Controls.Add(this.label3);
            this.pnlTCP1.Controls.Add(this.label2);
            this.pnlTCP1.Controls.Add(this.tNumPort1);
            this.pnlTCP1.Controls.Add(this.txtIPAddress1);
            this.pnlTCP1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTCP1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTCP1.Location = new System.Drawing.Point(0, 0);
            this.pnlTCP1.Name = "pnlTCP1";
            this.pnlTCP1.Size = new System.Drawing.Size(319, 119);
            this.pnlTCP1.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP Address";
            // 
            // tNumPort1
            // 
            this.tNumPort1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNumPort1.ForeColor = System.Drawing.Color.Black;
            this.tNumPort1.Location = new System.Drawing.Point(83, 39);
            this.tNumPort1.Name = "tNumPort1";
            this.tNumPort1.Size = new System.Drawing.Size(59, 27);
            this.tNumPort1.TabIndex = 1;
            // 
            // txtIPAddress1
            // 
            this.txtIPAddress1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress1.Location = new System.Drawing.Point(83, 11);
            this.txtIPAddress1.Name = "txtIPAddress1";
            this.txtIPAddress1.Size = new System.Drawing.Size(195, 27);
            this.txtIPAddress1.TabIndex = 0;
            // 
            // cmbDevice1
            // 
            this.cmbDevice1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevice1.FormattingEnabled = true;
            this.cmbDevice1.Location = new System.Drawing.Point(111, 3);
            this.cmbDevice1.Name = "cmbDevice1";
            this.cmbDevice1.Size = new System.Drawing.Size(195, 27);
            this.cmbDevice1.TabIndex = 14;
            this.cmbDevice1.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Device";
            // 
            // cmbSerialPort1
            // 
            this.cmbSerialPort1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSerialPort1.FormattingEnabled = true;
            this.cmbSerialPort1.Location = new System.Drawing.Point(110, 14);
            this.cmbSerialPort1.Name = "cmbSerialPort1";
            this.cmbSerialPort1.Size = new System.Drawing.Size(195, 27);
            this.cmbSerialPort1.TabIndex = 7;
            // 
            // btnPortSettings1
            // 
            this.btnPortSettings1.BackColor = System.Drawing.Color.MistyRose;
            this.btnPortSettings1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPortSettings1.FlatAppearance.BorderSize = 2;
            this.btnPortSettings1.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnPortSettings1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortSettings1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPortSettings1.Location = new System.Drawing.Point(205, 47);
            this.btnPortSettings1.Name = "btnPortSettings1";
            this.btnPortSettings1.Size = new System.Drawing.Size(100, 37);
            this.btnPortSettings1.TabIndex = 6;
            this.btnPortSettings1.Text = "&Port Settings";
            this.btnPortSettings1.UseVisualStyleBackColor = false;
            this.btnPortSettings1.Click += new System.EventHandler(this.btnPortSettings_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Serial Port";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 230);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage1.Controls.Add(this.splitMain1);
            this.tabPage1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(327, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "CAM1";
            // 
            // splitMain1
            // 
            this.splitMain1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitMain1.Location = new System.Drawing.Point(3, 3);
            this.splitMain1.Name = "splitMain1";
            this.splitMain1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain1.Panel1
            // 
            this.splitMain1.Panel1.Controls.Add(this.rbtnSerial1);
            this.splitMain1.Panel1.Controls.Add(this.rbtnTCP1);
            this.splitMain1.Panel1.Controls.Add(this.label4);
            this.splitMain1.Panel1.Controls.Add(this.cmbDevice1);
            // 
            // splitMain1.Panel2
            // 
            this.splitMain1.Panel2.Controls.Add(this.pnlSerial1);
            this.splitMain1.Panel2.Controls.Add(this.pnlTCP1);
            this.splitMain1.Size = new System.Drawing.Size(321, 192);
            this.splitMain1.SplitterDistance = 67;
            this.splitMain1.TabIndex = 0;
            // 
            // rbtnSerial1
            // 
            this.rbtnSerial1.AutoSize = true;
            this.rbtnSerial1.Checked = true;
            this.rbtnSerial1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSerial1.Location = new System.Drawing.Point(206, 36);
            this.rbtnSerial1.Name = "rbtnSerial1";
            this.rbtnSerial1.Size = new System.Drawing.Size(73, 23);
            this.rbtnSerial1.TabIndex = 17;
            this.rbtnSerial1.TabStop = true;
            this.rbtnSerial1.Text = "SERIAL";
            this.rbtnSerial1.UseVisualStyleBackColor = true;
            this.rbtnSerial1.CheckedChanged += new System.EventHandler(this.rbtnSerial1_CheckedChanged);
            // 
            // rbtnTCP1
            // 
            this.rbtnTCP1.AutoSize = true;
            this.rbtnTCP1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTCP1.Location = new System.Drawing.Point(111, 36);
            this.rbtnTCP1.Name = "rbtnTCP1";
            this.rbtnTCP1.Size = new System.Drawing.Size(52, 23);
            this.rbtnTCP1.TabIndex = 16;
            this.rbtnTCP1.Text = "TCP";
            this.rbtnTCP1.UseVisualStyleBackColor = true;
            // 
            // pnlSerial1
            // 
            this.pnlSerial1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSerial1.Controls.Add(this.cmbSerialPort1);
            this.pnlSerial1.Controls.Add(this.label1);
            this.pnlSerial1.Controls.Add(this.btnPortSettings1);
            this.pnlSerial1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSerial1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSerial1.Location = new System.Drawing.Point(0, 0);
            this.pnlSerial1.Name = "pnlSerial1";
            this.pnlSerial1.Size = new System.Drawing.Size(319, 119);
            this.pnlSerial1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage2.Controls.Add(this.splitMain2);
            this.tabPage2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(327, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "CAM2";
            // 
            // splitMain2
            // 
            this.splitMain2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitMain2.Location = new System.Drawing.Point(3, 3);
            this.splitMain2.Name = "splitMain2";
            this.splitMain2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain2.Panel1
            // 
            this.splitMain2.Panel1.Controls.Add(this.rbtnSerial2);
            this.splitMain2.Panel1.Controls.Add(this.rbtnTCP2);
            this.splitMain2.Panel1.Controls.Add(this.label5);
            this.splitMain2.Panel1.Controls.Add(this.cmbDevice2);
            // 
            // splitMain2.Panel2
            // 
            this.splitMain2.Panel2.Controls.Add(this.pnlSerial2);
            this.splitMain2.Panel2.Controls.Add(this.pnlTCP2);
            this.splitMain2.Size = new System.Drawing.Size(321, 192);
            this.splitMain2.SplitterDistance = 67;
            this.splitMain2.TabIndex = 1;
            // 
            // rbtnSerial2
            // 
            this.rbtnSerial2.AutoSize = true;
            this.rbtnSerial2.Checked = true;
            this.rbtnSerial2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSerial2.Location = new System.Drawing.Point(200, 37);
            this.rbtnSerial2.Name = "rbtnSerial2";
            this.rbtnSerial2.Size = new System.Drawing.Size(73, 23);
            this.rbtnSerial2.TabIndex = 17;
            this.rbtnSerial2.TabStop = true;
            this.rbtnSerial2.Text = "SERIAL";
            this.rbtnSerial2.UseVisualStyleBackColor = true;
            this.rbtnSerial2.CheckedChanged += new System.EventHandler(this.rbtnSerial2_CheckedChanged);
            // 
            // rbtnTCP2
            // 
            this.rbtnTCP2.AutoSize = true;
            this.rbtnTCP2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnTCP2.Location = new System.Drawing.Point(105, 37);
            this.rbtnTCP2.Name = "rbtnTCP2";
            this.rbtnTCP2.Size = new System.Drawing.Size(52, 23);
            this.rbtnTCP2.TabIndex = 16;
            this.rbtnTCP2.Text = "TCP";
            this.rbtnTCP2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "Device";
            // 
            // cmbDevice2
            // 
            this.cmbDevice2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevice2.FormattingEnabled = true;
            this.cmbDevice2.Location = new System.Drawing.Point(105, 7);
            this.cmbDevice2.Name = "cmbDevice2";
            this.cmbDevice2.Size = new System.Drawing.Size(195, 27);
            this.cmbDevice2.TabIndex = 14;
            this.cmbDevice2.SelectedIndexChanged += new System.EventHandler(this.cmbDevice2_SelectedIndexChanged);
            // 
            // pnlSerial2
            // 
            this.pnlSerial2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSerial2.Controls.Add(this.cmbSerialPort2);
            this.pnlSerial2.Controls.Add(this.label8);
            this.pnlSerial2.Controls.Add(this.btnPortSettings2);
            this.pnlSerial2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSerial2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSerial2.Location = new System.Drawing.Point(0, 0);
            this.pnlSerial2.Name = "pnlSerial2";
            this.pnlSerial2.Size = new System.Drawing.Size(319, 119);
            this.pnlSerial2.TabIndex = 13;
            // 
            // cmbSerialPort2
            // 
            this.cmbSerialPort2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSerialPort2.FormattingEnabled = true;
            this.cmbSerialPort2.Location = new System.Drawing.Point(105, 17);
            this.cmbSerialPort2.Name = "cmbSerialPort2";
            this.cmbSerialPort2.Size = new System.Drawing.Size(195, 27);
            this.cmbSerialPort2.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 19);
            this.label8.TabIndex = 5;
            this.label8.Text = "Serial Port";
            // 
            // btnPortSettings2
            // 
            this.btnPortSettings2.BackColor = System.Drawing.Color.MistyRose;
            this.btnPortSettings2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPortSettings2.FlatAppearance.BorderSize = 2;
            this.btnPortSettings2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortSettings2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPortSettings2.Location = new System.Drawing.Point(199, 50);
            this.btnPortSettings2.Name = "btnPortSettings2";
            this.btnPortSettings2.Size = new System.Drawing.Size(100, 37);
            this.btnPortSettings2.TabIndex = 6;
            this.btnPortSettings2.Text = "&Port Settings";
            this.btnPortSettings2.UseVisualStyleBackColor = false;
            this.btnPortSettings2.Click += new System.EventHandler(this.btnPortSettings2_Click);
            // 
            // pnlTCP2
            // 
            this.pnlTCP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTCP2.Controls.Add(this.label6);
            this.pnlTCP2.Controls.Add(this.label7);
            this.pnlTCP2.Controls.Add(this.tNumPort2);
            this.pnlTCP2.Controls.Add(this.txtIPAddress2);
            this.pnlTCP2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTCP2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlTCP2.Location = new System.Drawing.Point(0, 0);
            this.pnlTCP2.Name = "pnlTCP2";
            this.pnlTCP2.Size = new System.Drawing.Size(319, 119);
            this.pnlTCP2.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 19);
            this.label7.TabIndex = 7;
            this.label7.Text = "IP Address";
            // 
            // tNumPort2
            // 
            this.tNumPort2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNumPort2.ForeColor = System.Drawing.Color.Black;
            this.tNumPort2.Location = new System.Drawing.Point(83, 39);
            this.tNumPort2.Name = "tNumPort2";
            this.tNumPort2.Size = new System.Drawing.Size(59, 27);
            this.tNumPort2.TabIndex = 1;
            // 
            // txtIPAddress2
            // 
            this.txtIPAddress2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIPAddress2.Location = new System.Drawing.Point(83, 11);
            this.txtIPAddress2.Name = "txtIPAddress2";
            this.txtIPAddress2.Size = new System.Drawing.Size(195, 27);
            this.txtIPAddress2.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(335, 280);
            this.splitContainer1.SplitterDistance = 230;
            this.splitContainer1.TabIndex = 18;
            // 
            // FrmInspectionSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(335, 280);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInspectionSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inspection Settings";
            this.Load += new System.EventHandler(this.FrmInspectionSettings_Load);
            this.pnlTCP1.ResumeLayout(false);
            this.pnlTCP1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitMain1.Panel1.ResumeLayout(false);
            this.splitMain1.Panel1.PerformLayout();
            this.splitMain1.Panel2.ResumeLayout(false);
            this.splitMain1.ResumeLayout(false);
            this.pnlSerial1.ResumeLayout(false);
            this.pnlSerial1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitMain2.Panel1.ResumeLayout(false);
            this.splitMain2.Panel1.PerformLayout();
            this.splitMain2.Panel2.ResumeLayout(false);
            this.splitMain2.ResumeLayout(false);
            this.pnlSerial2.ResumeLayout(false);
            this.pnlSerial2.PerformLayout();
            this.pnlTCP2.ResumeLayout(false);
            this.pnlTCP2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel pnlTCP1;
        private RedRapidUI.TNumEditBox tNumPort1;
        private System.Windows.Forms.TextBox txtIPAddress1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDevice1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSerialPort1;
        private System.Windows.Forms.Button btnPortSettings1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitMain1;
        private System.Windows.Forms.RadioButton rbtnSerial1;
        private System.Windows.Forms.RadioButton rbtnTCP1;
        private System.Windows.Forms.Panel pnlSerial1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitMain2;
        private System.Windows.Forms.RadioButton rbtnSerial2;
        private System.Windows.Forms.RadioButton rbtnTCP2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbDevice2;
        private System.Windows.Forms.ComboBox cmbSerialPort2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPortSettings2;
        private System.Windows.Forms.Panel pnlTCP2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private RedRapidUI.TNumEditBox tNumPort2;
        private System.Windows.Forms.TextBox txtIPAddress2;
        private System.Windows.Forms.Panel pnlSerial2;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}