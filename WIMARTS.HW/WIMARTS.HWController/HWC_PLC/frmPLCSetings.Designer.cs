namespace CondotCombiSys
{
    partial class frmPLCSettings
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panPLCWatch = new System.Windows.Forms.Panel();
            this.btnAutoCmdTimer = new System.Windows.Forms.Button();
            this.nudValue = new System.Windows.Forms.NumericUpDown();
            this.btnClearList = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStatusMsg = new System.Windows.Forms.Label();
            this.btnShowCommand = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbPLCRegister = new System.Windows.Forms.ComboBox();
            this.cmbPLCOperation = new System.Windows.Forms.ComboBox();
            this.txtPLCNo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.lstSentRecievedData = new System.Windows.Forms.ListBox();
            this.txtICData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ePanMainCupHolder = new System.Windows.Forms.Panel();
            this.Closebutton = new System.Windows.Forms.Button();
            this.panPLCParameters = new System.Windows.Forms.Panel();
            this.dgvParamSettings = new System.Windows.Forms.DataGridView();
            this.Component = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Register = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NewValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ctrlCCSUI_TopIcon_HMIParamSettings = new System.Windows.Forms.Label();
            this.btnUploadSettings = new System.Windows.Forms.Button();
            this.btnReadParameterSettings = new System.Windows.Forms.Button();
            this.panHMITest = new System.Windows.Forms.Panel();
            this.panHMITestOutpu = new System.Windows.Forms.Panel();
            this.lblHMI_Output = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panHMITestInput = new System.Windows.Forms.Panel();
            this.btnHMIInputTestMode = new System.Windows.Forms.Button();
            this.lblHMI_Input = new System.Windows.Forms.Label();
            this.panPLCWatch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).BeginInit();
            this.ePanMainCupHolder.SuspendLayout();
            this.panPLCParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamSettings)).BeginInit();
            this.panel3.SuspendLayout();
            this.panHMITest.SuspendLayout();
            this.panHMITestInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // panPLCWatch
            // 
            this.panPLCWatch.Controls.Add(this.btnAutoCmdTimer);
            this.panPLCWatch.Controls.Add(this.nudValue);
            this.panPLCWatch.Controls.Add(this.btnClearList);
            this.panPLCWatch.Controls.Add(this.label4);
            this.panPLCWatch.Controls.Add(this.lblStatusMsg);
            this.panPLCWatch.Controls.Add(this.btnShowCommand);
            this.panPLCWatch.Controls.Add(this.label20);
            this.panPLCWatch.Controls.Add(this.label19);
            this.panPLCWatch.Controls.Add(this.cmbPLCRegister);
            this.panPLCWatch.Controls.Add(this.cmbPLCOperation);
            this.panPLCWatch.Controls.Add(this.txtPLCNo);
            this.panPLCWatch.Controls.Add(this.label18);
            this.panPLCWatch.Controls.Add(this.lstSentRecievedData);
            this.panPLCWatch.Controls.Add(this.txtICData);
            this.panPLCWatch.Controls.Add(this.label2);
            this.panPLCWatch.Controls.Add(this.btnSendCommand);
            this.panPLCWatch.Controls.Add(this.txtCommand);
            this.panPLCWatch.Controls.Add(this.label1);
            this.panPLCWatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPLCWatch.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panPLCWatch.Location = new System.Drawing.Point(0, 0);
            this.panPLCWatch.MaximumSize = new System.Drawing.Size(300, 1098);
            this.panPLCWatch.Name = "panPLCWatch";
            this.panPLCWatch.Size = new System.Drawing.Size(300, 670);
            this.panPLCWatch.TabIndex = 50;
            this.panPLCWatch.Visible = false;
            // 
            // btnAutoCmdTimer
            // 
            this.btnAutoCmdTimer.Location = new System.Drawing.Point(104, 55);
            this.btnAutoCmdTimer.Name = "btnAutoCmdTimer";
            this.btnAutoCmdTimer.Size = new System.Drawing.Size(89, 62);
            this.btnAutoCmdTimer.TabIndex = 49;
            this.btnAutoCmdTimer.Text = "Start/Stop AutoCmd Timer";
            this.btnAutoCmdTimer.UseVisualStyleBackColor = true;
            this.btnAutoCmdTimer.Click += new System.EventHandler(this.btnAutoCmdTimer_Click);
            // 
            // nudValue
            // 
            this.nudValue.Location = new System.Drawing.Point(172, 27);
            this.nudValue.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudValue.Name = "nudValue";
            this.nudValue.Size = new System.Drawing.Size(53, 23);
            this.nudValue.TabIndex = 48;
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(76, 619);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(132, 25);
            this.btnClearList.TabIndex = 47;
            this.btnClearList.Text = "Clear List";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 46;
            this.label4.Text = "Status";
            // 
            // lblStatusMsg
            // 
            this.lblStatusMsg.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblStatusMsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatusMsg.ForeColor = System.Drawing.Color.Black;
            this.lblStatusMsg.Location = new System.Drawing.Point(7, 270);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(276, 31);
            this.lblStatusMsg.TabIndex = 1;
            this.lblStatusMsg.Text = "Status";
            this.lblStatusMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnShowCommand
            // 
            this.btnShowCommand.Location = new System.Drawing.Point(7, 55);
            this.btnShowCommand.Name = "btnShowCommand";
            this.btnShowCommand.Size = new System.Drawing.Size(89, 62);
            this.btnShowCommand.TabIndex = 23;
            this.btnShowCommand.Text = "Show Command";
            this.btnShowCommand.UseVisualStyleBackColor = true;
            this.btnShowCommand.Click += new System.EventHandler(this.btnShowCommand_Click);
            // 
            // label20
            // 
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(250, 27);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(41, 25);
            this.label20.TabIndex = 22;
            this.label20.Text = "*<CR>";
            // 
            // label19
            // 
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(226, 27);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 25);
            this.label19.TabIndex = 21;
            this.label19.Text = "XX";
            // 
            // cmbPLCRegister
            // 
            this.cmbPLCRegister.FormattingEnabled = true;
            this.cmbPLCRegister.Items.AddRange(new object[] {
            "1000",
            "1002",
            "1004",
            "1006",
            "1008",
            "1010",
            "1012",
            "1014",
            "1016",
            "1018",
            "1020",
            "1022",
            "1024",
            "1038",
            "1040",
            "1042",
            "1044",
            "1046",
            "1048",
            "1050",
            "1052",
            "1054",
            "1056",
            "1060",
            "1062",
            "1064",
            "1066",
            "1068",
            "1070",
            "1071",
            "1072",
            "1073",
            "1074",
            "1075",
            "1076",
            "1077",
            "1078",
            "1079",
            "1080",
            "1090",
            "1250",
            "0900",
            "0901",
            "0905",
            "0906",
            "0910",
            "0911",
            "0920",
            "0950",
            "0955"});
            this.cmbPLCRegister.Location = new System.Drawing.Point(100, 27);
            this.cmbPLCRegister.Name = "cmbPLCRegister";
            this.cmbPLCRegister.Size = new System.Drawing.Size(71, 23);
            this.cmbPLCRegister.TabIndex = 19;
            // 
            // cmbPLCOperation
            // 
            this.cmbPLCOperation.FormattingEnabled = true;
            this.cmbPLCOperation.Items.AddRange(new object[] {
            "RD",
            "WD"});
            this.cmbPLCOperation.Location = new System.Drawing.Point(48, 27);
            this.cmbPLCOperation.Name = "cmbPLCOperation";
            this.cmbPLCOperation.Size = new System.Drawing.Size(51, 23);
            this.cmbPLCOperation.TabIndex = 18;
            // 
            // txtPLCNo
            // 
            this.txtPLCNo.Location = new System.Drawing.Point(26, 27);
            this.txtPLCNo.MaxLength = 2;
            this.txtPLCNo.Name = "txtPLCNo";
            this.txtPLCNo.Size = new System.Drawing.Size(21, 23);
            this.txtPLCNo.TabIndex = 17;
            this.txtPLCNo.Text = "00";
            // 
            // label18
            // 
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Location = new System.Drawing.Point(7, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 25);
            this.label18.TabIndex = 16;
            this.label18.Text = "@";
            // 
            // lstSentRecievedData
            // 
            this.lstSentRecievedData.IntegralHeight = false;
            this.lstSentRecievedData.ItemHeight = 15;
            this.lstSentRecievedData.Location = new System.Drawing.Point(7, 303);
            this.lstSentRecievedData.Name = "lstSentRecievedData";
            this.lstSentRecievedData.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstSentRecievedData.Size = new System.Drawing.Size(276, 313);
            this.lstSentRecievedData.TabIndex = 14;
            // 
            // txtICData
            // 
            this.txtICData.Location = new System.Drawing.Point(7, 174);
            this.txtICData.Multiline = true;
            this.txtICData.Name = "txtICData";
            this.txtICData.Size = new System.Drawing.Size(276, 76);
            this.txtICData.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Received Data";
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.Location = new System.Drawing.Point(201, 55);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(89, 62);
            this.btnSendCommand.TabIndex = 2;
            this.btnSendCommand.Text = "Send Command";
            this.btnSendCommand.UseVisualStyleBackColor = true;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCommand
            // 
            this.txtCommand.Location = new System.Drawing.Point(7, 123);
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(276, 23);
            this.txtCommand.TabIndex = 1;
            this.txtCommand.Text = "@00WD1020012556*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Command 2 Send";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Component";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Register";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Prev Value";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "NewValue";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Unit";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // ePanMainCupHolder
            // 
            this.ePanMainCupHolder.Controls.Add(this.Closebutton);
            this.ePanMainCupHolder.Controls.Add(this.panPLCParameters);
            this.ePanMainCupHolder.Controls.Add(this.panHMITest);
            this.ePanMainCupHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ePanMainCupHolder.Location = new System.Drawing.Point(0, 0);
            this.ePanMainCupHolder.Name = "ePanMainCupHolder";
            this.ePanMainCupHolder.Padding = new System.Windows.Forms.Padding(4);
            this.ePanMainCupHolder.Size = new System.Drawing.Size(1194, 670);
            this.ePanMainCupHolder.TabIndex = 51;
            // 
            // Closebutton
            // 
            this.Closebutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Closebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Closebutton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Closebutton.ForeColor = System.Drawing.Color.White;
            this.Closebutton.Location = new System.Drawing.Point(1165, 33);
            this.Closebutton.Name = "Closebutton";
            this.Closebutton.Size = new System.Drawing.Size(27, 18);
            this.Closebutton.TabIndex = 62;
            this.Closebutton.Text = "X";
            this.Closebutton.UseVisualStyleBackColor = true;
            this.Closebutton.Click += new System.EventHandler(this.Closebutton_Click);
            // 
            // panPLCParameters
            // 
            this.panPLCParameters.BackColor = System.Drawing.Color.Transparent;
            this.panPLCParameters.Controls.Add(this.dgvParamSettings);
            this.panPLCParameters.Controls.Add(this.panel3);
            this.panPLCParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPLCParameters.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.panPLCParameters.Location = new System.Drawing.Point(4, 4);
            this.panPLCParameters.Name = "panPLCParameters";
            this.panPLCParameters.Size = new System.Drawing.Size(828, 662);
            this.panPLCParameters.TabIndex = 61;
            // 
            // dgvParamSettings
            // 
            this.dgvParamSettings.AllowUserToAddRows = false;
            this.dgvParamSettings.AllowUserToDeleteRows = false;
            this.dgvParamSettings.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvParamSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Component,
            this.Description,
            this.Register,
            this.CurValue,
            this.NewValue,
            this.Unit});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParamSettings.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParamSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParamSettings.Location = new System.Drawing.Point(0, 47);
            this.dgvParamSettings.MultiSelect = false;
            this.dgvParamSettings.Name = "dgvParamSettings";
            this.dgvParamSettings.RowHeadersWidth = 20;
            this.dgvParamSettings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParamSettings.Size = new System.Drawing.Size(828, 615);
            this.dgvParamSettings.TabIndex = 0;
            // 
            // Component
            // 
            this.Component.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Component.HeaderText = "Component";
            this.Component.Name = "Component";
            this.Component.ReadOnly = true;
            this.Component.Width = 127;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Register
            // 
            this.Register.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Register.HeaderText = "Register";
            this.Register.Name = "Register";
            this.Register.ReadOnly = true;
            this.Register.Width = 102;
            // 
            // CurValue
            // 
            this.CurValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.CurValue.HeaderText = "Current Value";
            this.CurValue.Name = "CurValue";
            this.CurValue.ReadOnly = true;
            this.CurValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CurValue.Width = 125;
            // 
            // NewValue
            // 
            this.NewValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NewValue.HeaderText = "New Value";
            this.NewValue.Name = "NewValue";
            this.NewValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NewValue.Width = 120;
            // 
            // Unit
            // 
            this.Unit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Unit.Width = 50;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ctrlCCSUI_TopIcon_HMIParamSettings);
            this.panel3.Controls.Add(this.btnUploadSettings);
            this.panel3.Controls.Add(this.btnReadParameterSettings);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(828, 47);
            this.panel3.TabIndex = 4;
            // 
            // ctrlCCSUI_TopIcon_HMIParamSettings
            // 
            this.ctrlCCSUI_TopIcon_HMIParamSettings.BackColor = System.Drawing.Color.White;
            this.ctrlCCSUI_TopIcon_HMIParamSettings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlCCSUI_TopIcon_HMIParamSettings.Location = new System.Drawing.Point(5, 8);
            this.ctrlCCSUI_TopIcon_HMIParamSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctrlCCSUI_TopIcon_HMIParamSettings.MinimumSize = new System.Drawing.Size(120, 26);
            this.ctrlCCSUI_TopIcon_HMIParamSettings.Name = "ctrlCCSUI_TopIcon_HMIParamSettings";
            this.ctrlCCSUI_TopIcon_HMIParamSettings.Size = new System.Drawing.Size(283, 31);
            this.ctrlCCSUI_TopIcon_HMIParamSettings.TabIndex = 59;
            this.ctrlCCSUI_TopIcon_HMIParamSettings.Text = "HWC Parameters Settings";
            this.ctrlCCSUI_TopIcon_HMIParamSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUploadSettings
            // 
            this.btnUploadSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUploadSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnUploadSettings.FlatAppearance.BorderSize = 2;
            this.btnUploadSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUploadSettings.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadSettings.ForeColor = System.Drawing.Color.Black;
            this.btnUploadSettings.Location = new System.Drawing.Point(596, 4);
            this.btnUploadSettings.Name = "btnUploadSettings";
            this.btnUploadSettings.Size = new System.Drawing.Size(172, 39);
            this.btnUploadSettings.TabIndex = 10;
            this.btnUploadSettings.Text = "UPLOAD VALUE";
            this.btnUploadSettings.UseVisualStyleBackColor = true;
            this.btnUploadSettings.Click += new System.EventHandler(this.btnUploadSettings_Click);
            // 
            // btnReadParameterSettings
            // 
            this.btnReadParameterSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadParameterSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReadParameterSettings.FlatAppearance.BorderSize = 2;
            this.btnReadParameterSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReadParameterSettings.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadParameterSettings.ForeColor = System.Drawing.Color.Black;
            this.btnReadParameterSettings.Location = new System.Drawing.Point(418, 4);
            this.btnReadParameterSettings.Name = "btnReadParameterSettings";
            this.btnReadParameterSettings.Size = new System.Drawing.Size(172, 39);
            this.btnReadParameterSettings.TabIndex = 9;
            this.btnReadParameterSettings.Text = "READ VALUE";
            this.btnReadParameterSettings.UseVisualStyleBackColor = true;
            this.btnReadParameterSettings.Click += new System.EventHandler(this.btnReadParameterSettings_Click);
            // 
            // panHMITest
            // 
            this.panHMITest.BackColor = System.Drawing.Color.Transparent;
            this.panHMITest.Controls.Add(this.panHMITestOutpu);
            this.panHMITest.Controls.Add(this.lblHMI_Output);
            this.panHMITest.Controls.Add(this.label3);
            this.panHMITest.Controls.Add(this.panHMITestInput);
            this.panHMITest.Controls.Add(this.lblHMI_Input);
            this.panHMITest.Dock = System.Windows.Forms.DockStyle.Right;
            this.panHMITest.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.panHMITest.Location = new System.Drawing.Point(832, 4);
            this.panHMITest.Name = "panHMITest";
            this.panHMITest.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.panHMITest.Size = new System.Drawing.Size(358, 662);
            this.panHMITest.TabIndex = 60;
            // 
            // panHMITestOutpu
            // 
            this.panHMITestOutpu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panHMITestOutpu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHMITestOutpu.Location = new System.Drawing.Point(10, 320);
            this.panHMITestOutpu.Name = "panHMITestOutpu";
            this.panHMITestOutpu.Size = new System.Drawing.Size(348, 334);
            this.panHMITestOutpu.TabIndex = 60;
            // 
            // lblHMI_Output
            // 
            this.lblHMI_Output.AutoSize = true;
            this.lblHMI_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHMI_Output.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHMI_Output.Location = new System.Drawing.Point(10, 295);
            this.lblHMI_Output.Name = "lblHMI_Output";
            this.lblHMI_Output.Size = new System.Drawing.Size(163, 25);
            this.lblHMI_Output.TabIndex = 52;
            this.lblHMI_Output.Text = "Output Device Test";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(10, 272);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 23);
            this.label3.TabIndex = 62;
            // 
            // panHMITestInput
            // 
            this.panHMITestInput.BackColor = System.Drawing.Color.White;
            this.panHMITestInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panHMITestInput.Controls.Add(this.btnHMIInputTestMode);
            this.panHMITestInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panHMITestInput.Location = new System.Drawing.Point(10, 25);
            this.panHMITestInput.Name = "panHMITestInput";
            this.panHMITestInput.Size = new System.Drawing.Size(348, 247);
            this.panHMITestInput.TabIndex = 61;
            // 
            // btnHMIInputTestMode
            // 
            this.btnHMIInputTestMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHMIInputTestMode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHMIInputTestMode.FlatAppearance.BorderSize = 2;
            this.btnHMIInputTestMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHMIInputTestMode.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHMIInputTestMode.ForeColor = System.Drawing.Color.Black;
            this.btnHMIInputTestMode.Location = new System.Drawing.Point(103, 202);
            this.btnHMIInputTestMode.Name = "btnHMIInputTestMode";
            this.btnHMIInputTestMode.Size = new System.Drawing.Size(172, 39);
            this.btnHMIInputTestMode.TabIndex = 55;
            this.btnHMIInputTestMode.Text = "START INPUT TEST";
            this.btnHMIInputTestMode.UseVisualStyleBackColor = false;
            this.btnHMIInputTestMode.Click += new System.EventHandler(this.btnHMIInputTestMode_Click);
            // 
            // lblHMI_Input
            // 
            this.lblHMI_Input.AutoSize = true;
            this.lblHMI_Input.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHMI_Input.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHMI_Input.Location = new System.Drawing.Point(10, 0);
            this.lblHMI_Input.Name = "lblHMI_Input";
            this.lblHMI_Input.Size = new System.Drawing.Size(148, 25);
            this.lblHMI_Input.TabIndex = 51;
            this.lblHMI_Input.Text = "Input Device Test";
            this.lblHMI_Input.Click += new System.EventHandler(this.lblHMI_Input_Click);
            // 
            // frmPLCSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1194, 670);
            this.Controls.Add(this.ePanMainCupHolder);
            this.Controls.Add(this.panPLCWatch);
            this.Font = new System.Drawing.Font("Calibri", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPLCSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Machine Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPLCExecutor_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPLCExecutor_FormClosed);
            this.Load += new System.EventHandler(this.frmPLCExecutor_Load);
            this.Shown += new System.EventHandler(this.frmPLCExecutor_Shown);
            this.SizeChanged += new System.EventHandler(this.frmPLCExecutor_SizeChanged);
            this.Enter += new System.EventHandler(this.frmPLCExecutor_Enter);
            this.panPLCWatch.ResumeLayout(false);
            this.panPLCWatch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudValue)).EndInit();
            this.ePanMainCupHolder.ResumeLayout(false);
            this.panPLCParameters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamSettings)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panHMITest.ResumeLayout(false);
            this.panHMITest.PerformLayout();
            this.panHMITestInput.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panPLCWatch;
        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtICData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSentRecievedData;
        private System.Windows.Forms.TextBox txtPLCNo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbPLCOperation;
        private System.Windows.Forms.ComboBox cmbPLCRegister;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnShowCommand;
        private System.Windows.Forms.DataGridView dgvParamSettings;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblStatusMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHMI_Output;
        private System.Windows.Forms.Label lblHMI_Input;
        private System.Windows.Forms.Panel panHMITestOutpu;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.NumericUpDown nudValue;
        private System.Windows.Forms.Panel panHMITestInput;
        private System.Windows.Forms.Panel ePanMainCupHolder;
        private System.Windows.Forms.Button btnReadParameterSettings;
        private System.Windows.Forms.Button btnUploadSettings;
        private System.Windows.Forms.Button btnHMIInputTestMode;
        private System.Windows.Forms.Panel panHMITest;
        private System.Windows.Forms.Panel panPLCParameters;
        private System.Windows.Forms.Label ctrlCCSUI_TopIcon_HMIParamSettings;
        public System.Windows.Forms.Button Closebutton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAutoCmdTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Component;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Register;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn NewValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
    }
}