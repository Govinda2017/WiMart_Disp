namespace Red.CamInterface
{
    partial class FrmDataManManager
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
            this.PNL_ConnectToReader = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.setHeartBeatIntButton = new System.Windows.Forms.Button();
            this.heartbeatIntervalComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.responseLabel = new System.Windows.Forms.Label();
            this.Grp_SendDMCCCmd = new System.Windows.Forms.GroupBox();
            this.SendCommandButton = new System.Windows.Forms.Button();
            this.commandComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.loadConfigButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            this.connectGroupBox = new System.Windows.Forms.GroupBox();
            this.systemListBox = new System.Windows.Forms.ListBox();
            this.detectSystemsButton = new System.Windows.Forms.Button();
            this.Pnl_Botton = new System.Windows.Forms.Panel();
            this.Btn_SystemSettings = new Red.Controls.Buttons.RedGlowButton();
            this.Btn_SymbologySetting = new Red.Controls.Buttons.RedGlowButton();
            this.Btn_LightAndCameraSetting = new Red.Controls.Buttons.RedGlowButton();
            this.Btn_ResultDisplay = new Red.Controls.Buttons.RedGlowButton();
            this.Pnl_ResultDisplay = new System.Windows.Forms.Panel();
            this.responseGroupBox = new System.Windows.Forms.GroupBox();
            this.LST_RESULT = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.liveDisplayCheckBox = new System.Windows.Forms.CheckBox();
            this.imageGroupBox = new System.Windows.Forms.GroupBox();
            this.lastImagePictureBox = new System.Windows.Forms.PictureBox();
            this.PNL_LightCameraSetting = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Pnl_MaxExposure = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.Cmb_MaximumExposure = new System.Windows.Forms.ComboBox();
            this.Pnl_Exposure = new System.Windows.Forms.Panel();
            this.Pnl_ManualExposure = new System.Windows.Forms.Panel();
            this.Grp_ManualExp = new System.Windows.Forms.GroupBox();
            this.CMB_Exposure = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TXT_ManualExposure = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Track_ManualExposure = new System.Windows.Forms.TrackBar();
            this.Opt_ManualExposure = new System.Windows.Forms.RadioButton();
            this.Pnl_AutomaticExposure = new System.Windows.Forms.Panel();
            this.Grp_AutomaticExp = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TXT_AutomaticExpVal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Track_TargetBrightness = new System.Windows.Forms.TrackBar();
            this.Opt_AutomaticExposure = new System.Windows.Forms.RadioButton();
            this.Pnl_Interval = new System.Windows.Forms.Panel();
            this.Track_Interval = new System.Windows.Forms.TrackBar();
            this.lblInterval = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TXT_Interval = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.Pnl_Timeout = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.TXT_Timeout = new System.Windows.Forms.TextBox();
            this.CMB_TRIGGERTYPE = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Pnl_SymbologySetting = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.GRP_Postal = new System.Windows.Forms.GroupBox();
            this.GRP_StateCode = new System.Windows.Forms.GroupBox();
            this.CHK_IntelligentMailBarcode = new System.Windows.Forms.CheckBox();
            this.CHK_UPC = new System.Windows.Forms.CheckBox();
            this.CHK_AustaliaPost = new System.Windows.Forms.CheckBox();
            this.CHK_JapanPost = new System.Windows.Forms.CheckBox();
            this.CHK_Planet = new System.Windows.Forms.CheckBox();
            this.CHK_Postnet = new System.Windows.Forms.CheckBox();
            this.GRP_Stacked = new System.Windows.Forms.GroupBox();
            this.CHK_EANUCCComposite = new System.Windows.Forms.CheckBox();
            this.CHK_Databar = new System.Windows.Forms.CheckBox();
            this.CHK_MicroPDF417 = new System.Windows.Forms.CheckBox();
            this.CHK_PDF417 = new System.Windows.Forms.CheckBox();
            this.GRP_1D = new System.Windows.Forms.GroupBox();
            this.CHK_Codebar = new System.Windows.Forms.CheckBox();
            this.CHK_Code93 = new System.Windows.Forms.CheckBox();
            this.CHK_UPCEAN = new System.Windows.Forms.CheckBox();
            this.CHK_Pharmacode = new System.Windows.Forms.CheckBox();
            this.CHK_Interleaved2of5 = new System.Windows.Forms.CheckBox();
            this.CHK_Code39 = new System.Windows.Forms.CheckBox();
            this.CHK_Code128 = new System.Windows.Forms.CheckBox();
            this.GRP_2D = new System.Windows.Forms.GroupBox();
            this.GRP_Algorithm = new System.Windows.Forms.GroupBox();
            this.OPT_IDQuick = new System.Windows.Forms.RadioButton();
            this.OPT_IDMAX = new System.Windows.Forms.RadioButton();
            this.CHK_QRCode = new System.Windows.Forms.CheckBox();
            this.CHK_Datamatrix = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PNL_SETNOOFCode = new System.Windows.Forms.Panel();
            this.Num_NoOfCodes = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.NUM_1DStackedPostalNoOfCode = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.NUM_QRNoOfCode = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.NUM_DatamatrixNoOfCode = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.CHK_PartialResult = new System.Windows.Forms.CheckBox();
            this.GRP_SortingPriority = new System.Windows.Forms.GroupBox();
            this.Btn_Down = new Red.Controls.Buttons.RedGlowButton();
            this.Btn_Reverse = new Red.Controls.Buttons.RedGlowButton();
            this.BTN_Up = new Red.Controls.Buttons.RedGlowButton();
            this.LSTPriority = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.PNL_SystemSetting = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.TXT_DeviceName = new System.Windows.Forms.TextBox();
            this.TAB_SystemSetting = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.GRP_3secondButtonpress = new System.Windows.Forms.GroupBox();
            this.Chk_OptimizeBrightness3 = new System.Windows.Forms.CheckBox();
            this.Chk_TrainCode3 = new System.Windows.Forms.CheckBox();
            this.Chk_SetMatchString3 = new System.Windows.Forms.CheckBox();
            this.Chk_DisableReaderButton = new System.Windows.Forms.CheckBox();
            this.GRP_InputLine1Action = new System.Windows.Forms.GroupBox();
            this.Chk_OptimizeBrightness1 = new System.Windows.Forms.CheckBox();
            this.Chk_TrainCode1 = new System.Windows.Forms.CheckBox();
            this.Chk_SetMatchString1 = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PNLActionLine1 = new System.Windows.Forms.Panel();
            this.OPT_ActionClosed1 = new System.Windows.Forms.RadioButton();
            this.Chk_EventRead1 = new System.Windows.Forms.CheckBox();
            this.TXT_Pulsewidth1 = new System.Windows.Forms.TextBox();
            this.Chk_EventNoRead1 = new System.Windows.Forms.CheckBox();
            this.OPT_ActionOpen1 = new System.Windows.Forms.RadioButton();
            this.Chk_EventValidationFailure1 = new System.Windows.Forms.CheckBox();
            this.Chk_BufferOverflow1 = new System.Windows.Forms.CheckBox();
            this.Chk_TriggerOverrun1 = new System.Windows.Forms.CheckBox();
            this.Chk_Ouput1 = new System.Windows.Forms.CheckBox();
            this.label30 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PNLActionLine0 = new System.Windows.Forms.Panel();
            this.OPT_ActionClosed0 = new System.Windows.Forms.RadioButton();
            this.Chk_EventRead0 = new System.Windows.Forms.CheckBox();
            this.OPT_ActionOpen0 = new System.Windows.Forms.RadioButton();
            this.Chk_EventNoRead0 = new System.Windows.Forms.CheckBox();
            this.TXT_Pulsewidth0 = new System.Windows.Forms.TextBox();
            this.Chk_EventValidationFailure0 = new System.Windows.Forms.CheckBox();
            this.Chk_BufferOverflow0 = new System.Windows.Forms.CheckBox();
            this.Chk_TriggerOverrun0 = new System.Windows.Forms.CheckBox();
            this.Chkoutput0 = new System.Windows.Forms.CheckBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.TXT_NoReadOutput = new System.Windows.Forms.TextBox();
            this.CHk_EnableBeeper = new System.Windows.Forms.CheckBox();
            this.checkBox22 = new System.Windows.Forms.CheckBox();
            this.label28 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.PNl_Main = new System.Windows.Forms.Panel();
            this.BTn_Close = new Red.Controls.Buttons.RedGlowButton();
            this.BTN_ConnectToReader = new Red.Controls.Buttons.RedGlowButton();
            this.PNL_ConnectToReader.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Grp_SendDMCCCmd.SuspendLayout();
            this.panel2.SuspendLayout();
            this.connectGroupBox.SuspendLayout();
            this.Pnl_Botton.SuspendLayout();
            this.Pnl_ResultDisplay.SuspendLayout();
            this.responseGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.imageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lastImagePictureBox)).BeginInit();
            this.PNL_LightCameraSetting.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Pnl_MaxExposure.SuspendLayout();
            this.Pnl_Exposure.SuspendLayout();
            this.Pnl_ManualExposure.SuspendLayout();
            this.Grp_ManualExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_ManualExposure)).BeginInit();
            this.Pnl_AutomaticExposure.SuspendLayout();
            this.Grp_AutomaticExp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_TargetBrightness)).BeginInit();
            this.Pnl_Interval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_Interval)).BeginInit();
            this.Pnl_Timeout.SuspendLayout();
            this.Pnl_SymbologySetting.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.GRP_Postal.SuspendLayout();
            this.GRP_StateCode.SuspendLayout();
            this.GRP_Stacked.SuspendLayout();
            this.GRP_1D.SuspendLayout();
            this.GRP_2D.SuspendLayout();
            this.GRP_Algorithm.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.PNL_SETNOOFCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_NoOfCodes)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_1DStackedPostalNoOfCode)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_QRNoOfCode)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_DatamatrixNoOfCode)).BeginInit();
            this.GRP_SortingPriority.SuspendLayout();
            this.PNL_SystemSetting.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.TAB_SystemSetting.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.GRP_3secondButtonpress.SuspendLayout();
            this.GRP_InputLine1Action.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.PNLActionLine1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.PNLActionLine0.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.PNl_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // PNL_ConnectToReader
            // 
            this.PNL_ConnectToReader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PNL_ConnectToReader.Controls.Add(this.groupBox4);
            this.PNL_ConnectToReader.Controls.Add(this.groupBox1);
            this.PNL_ConnectToReader.Controls.Add(this.Grp_SendDMCCCmd);
            this.PNL_ConnectToReader.Controls.Add(this.panel2);
            this.PNL_ConnectToReader.Controls.Add(this.loadConfigButton);
            this.PNL_ConnectToReader.Controls.Add(this.ConnectButton);
            this.PNL_ConnectToReader.Controls.Add(this.DisconnectButton);
            this.PNL_ConnectToReader.Controls.Add(this.connectGroupBox);
            this.PNL_ConnectToReader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_ConnectToReader.Location = new System.Drawing.Point(0, 0);
            this.PNL_ConnectToReader.Name = "PNL_ConnectToReader";
            this.PNL_ConnectToReader.Size = new System.Drawing.Size(572, 533);
            this.PNL_ConnectToReader.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.setHeartBeatIntButton);
            this.groupBox4.Controls.Add(this.heartbeatIntervalComboBox);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 406);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(520, 42);
            this.groupBox4.TabIndex = 32;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Heartbeat";
            // 
            // setHeartBeatIntButton
            // 
            this.setHeartBeatIntButton.Enabled = false;
            this.setHeartBeatIntButton.Location = new System.Drawing.Point(331, 10);
            this.setHeartBeatIntButton.Name = "setHeartBeatIntButton";
            this.setHeartBeatIntButton.Size = new System.Drawing.Size(75, 23);
            this.setHeartBeatIntButton.TabIndex = 2;
            this.setHeartBeatIntButton.Text = "Set";
            this.setHeartBeatIntButton.UseVisualStyleBackColor = true;
            this.setHeartBeatIntButton.Click += new System.EventHandler(this.setHeartBeatIntButton_Click);
            // 
            // heartbeatIntervalComboBox
            // 
            this.heartbeatIntervalComboBox.Enabled = false;
            this.heartbeatIntervalComboBox.FormattingEnabled = true;
            this.heartbeatIntervalComboBox.Items.AddRange(new object[] {
            "0",
            "1",
            "5",
            "10"});
            this.heartbeatIntervalComboBox.Location = new System.Drawing.Point(226, 12);
            this.heartbeatIntervalComboBox.Name = "heartbeatIntervalComboBox";
            this.heartbeatIntervalComboBox.Size = new System.Drawing.Size(99, 21);
            this.heartbeatIntervalComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Interval (seconds)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.responseLabel);
            this.groupBox1.Location = new System.Drawing.Point(292, 461);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 44);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Response from device";
            // 
            // responseLabel
            // 
            this.responseLabel.AutoSize = true;
            this.responseLabel.Location = new System.Drawing.Point(6, 11);
            this.responseLabel.Name = "responseLabel";
            this.responseLabel.Size = new System.Drawing.Size(92, 13);
            this.responseLabel.TabIndex = 5;
            this.responseLabel.Text = "No responses yet.";
            // 
            // Grp_SendDMCCCmd
            // 
            this.Grp_SendDMCCCmd.Controls.Add(this.SendCommandButton);
            this.Grp_SendDMCCCmd.Controls.Add(this.commandComboBox);
            this.Grp_SendDMCCCmd.Enabled = false;
            this.Grp_SendDMCCCmd.Location = new System.Drawing.Point(3, 461);
            this.Grp_SendDMCCCmd.Name = "Grp_SendDMCCCmd";
            this.Grp_SendDMCCCmd.Size = new System.Drawing.Size(283, 44);
            this.Grp_SendDMCCCmd.TabIndex = 31;
            this.Grp_SendDMCCCmd.TabStop = false;
            this.Grp_SendDMCCCmd.Text = "Send DMCC to device";
            // 
            // SendCommandButton
            // 
            this.SendCommandButton.Location = new System.Drawing.Point(200, 15);
            this.SendCommandButton.Name = "SendCommandButton";
            this.SendCommandButton.Size = new System.Drawing.Size(75, 23);
            this.SendCommandButton.TabIndex = 1;
            this.SendCommandButton.Text = "Send";
            this.SendCommandButton.UseVisualStyleBackColor = true;
            this.SendCommandButton.Click += new System.EventHandler(this.SendCommandButton_Click);
            // 
            // commandComboBox
            // 
            this.commandComboBox.FormattingEnabled = true;
            this.commandComboBox.Items.AddRange(new object[] {
            "||>GET DEVICE.TYPE",
            "||>GET DEVICE.SERIAL-NUMBER",
            "||>GET DEVICE.NAME",
            "||>TRIGGER ON",
            "||>TRIGGER OFF",
            "||>BEEP 3 2",
            "||>GET RESULT",
            "||>GET TRIGGER.TYPE",
            "||>GET CAMERA.EXPOSURE"});
            this.commandComboBox.Location = new System.Drawing.Point(6, 17);
            this.commandComboBox.Name = "commandComboBox";
            this.commandComboBox.Size = new System.Drawing.Size(188, 21);
            this.commandComboBox.TabIndex = 3;
            this.commandComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandComboBox_KeyDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addressTextBox);
            this.panel2.Controls.Add(this.connectionStatusLabel);
            this.panel2.Location = new System.Drawing.Point(13, 320);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(513, 43);
            this.panel2.TabIndex = 30;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(139, 12);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(100, 20);
            this.addressTextBox.TabIndex = 28;
            this.addressTextBox.Text = "Enter IP or \"COMx\"";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Location = new System.Drawing.Point(263, 16);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(78, 13);
            this.connectionStatusLabel.TabIndex = 27;
            this.connectionStatusLabel.Text = "Not connected";
            // 
            // loadConfigButton
            // 
            this.loadConfigButton.Enabled = false;
            this.loadConfigButton.Location = new System.Drawing.Point(344, 369);
            this.loadConfigButton.Name = "loadConfigButton";
            this.loadConfigButton.Size = new System.Drawing.Size(100, 23);
            this.loadConfigButton.TabIndex = 29;
            this.loadConfigButton.Text = "Load config";
            this.loadConfigButton.UseVisualStyleBackColor = true;
            this.loadConfigButton.Click += new System.EventHandler(this.loadConfigButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(98, 369);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(100, 23);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(222, 369);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(100, 23);
            this.DisconnectButton.TabIndex = 11;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // connectGroupBox
            // 
            this.connectGroupBox.Controls.Add(this.systemListBox);
            this.connectGroupBox.Controls.Add(this.detectSystemsButton);
            this.connectGroupBox.Location = new System.Drawing.Point(13, 3);
            this.connectGroupBox.Name = "connectGroupBox";
            this.connectGroupBox.Size = new System.Drawing.Size(513, 307);
            this.connectGroupBox.TabIndex = 9;
            this.connectGroupBox.TabStop = false;
            this.connectGroupBox.Text = "Detected devices";
            // 
            // systemListBox
            // 
            this.systemListBox.FormattingEnabled = true;
            this.systemListBox.Location = new System.Drawing.Point(12, 54);
            this.systemListBox.Name = "systemListBox";
            this.systemListBox.Size = new System.Drawing.Size(488, 238);
            this.systemListBox.TabIndex = 24;
            // 
            // detectSystemsButton
            // 
            this.detectSystemsButton.Location = new System.Drawing.Point(206, 19);
            this.detectSystemsButton.Name = "detectSystemsButton";
            this.detectSystemsButton.Size = new System.Drawing.Size(100, 23);
            this.detectSystemsButton.TabIndex = 31;
            this.detectSystemsButton.Text = "Detect devices";
            this.detectSystemsButton.UseVisualStyleBackColor = true;
            this.detectSystemsButton.Click += new System.EventHandler(this.detectSystemsButton_Click);
            // 
            // Pnl_Botton
            // 
            this.Pnl_Botton.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Pnl_Botton.Controls.Add(this.Btn_SystemSettings);
            this.Pnl_Botton.Controls.Add(this.Btn_SymbologySetting);
            this.Pnl_Botton.Controls.Add(this.Btn_LightAndCameraSetting);
            this.Pnl_Botton.Controls.Add(this.Btn_ResultDisplay);
            this.Pnl_Botton.Enabled = false;
            this.Pnl_Botton.Location = new System.Drawing.Point(9, 58);
            this.Pnl_Botton.Name = "Pnl_Botton";
            this.Pnl_Botton.Size = new System.Drawing.Size(220, 431);
            this.Pnl_Botton.TabIndex = 7;
            // 
            // Btn_SystemSettings
            // 
            this.Btn_SystemSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Btn_SystemSettings.BaseColor = System.Drawing.Color.White;
            this.Btn_SystemSettings.ButtonText = "System Settings";
            this.Btn_SystemSettings.CornerRadius = 0;
            this.Btn_SystemSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_SystemSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_SystemSettings.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SystemSettings.Location = new System.Drawing.Point(0, 117);
            this.Btn_SystemSettings.Name = "Btn_SystemSettings";
            this.Btn_SystemSettings.Size = new System.Drawing.Size(216, 39);
            this.Btn_SystemSettings.TabIndex = 20;
            this.Btn_SystemSettings.Click += new System.EventHandler(this.Btn_SystemSettings_Click);
            // 
            // Btn_SymbologySetting
            // 
            this.Btn_SymbologySetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Btn_SymbologySetting.BaseColor = System.Drawing.Color.White;
            this.Btn_SymbologySetting.ButtonText = "Symbology Settings";
            this.Btn_SymbologySetting.CornerRadius = 0;
            this.Btn_SymbologySetting.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_SymbologySetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_SymbologySetting.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SymbologySetting.Location = new System.Drawing.Point(0, 78);
            this.Btn_SymbologySetting.Name = "Btn_SymbologySetting";
            this.Btn_SymbologySetting.Size = new System.Drawing.Size(216, 39);
            this.Btn_SymbologySetting.TabIndex = 19;
            this.Btn_SymbologySetting.Click += new System.EventHandler(this.Btn_SymbologySetting_Click);
            // 
            // Btn_LightAndCameraSetting
            // 
            this.Btn_LightAndCameraSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Btn_LightAndCameraSetting.BaseColor = System.Drawing.Color.White;
            this.Btn_LightAndCameraSetting.ButtonText = "Light & Camera Settings";
            this.Btn_LightAndCameraSetting.CornerRadius = 0;
            this.Btn_LightAndCameraSetting.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_LightAndCameraSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_LightAndCameraSetting.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LightAndCameraSetting.Location = new System.Drawing.Point(0, 39);
            this.Btn_LightAndCameraSetting.Name = "Btn_LightAndCameraSetting";
            this.Btn_LightAndCameraSetting.Size = new System.Drawing.Size(216, 39);
            this.Btn_LightAndCameraSetting.TabIndex = 18;
            this.Btn_LightAndCameraSetting.Click += new System.EventHandler(this.Btn_LightAndCameraSetting_Click);
            // 
            // Btn_ResultDisplay
            // 
            this.Btn_ResultDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Btn_ResultDisplay.BaseColor = System.Drawing.Color.White;
            this.Btn_ResultDisplay.ButtonText = "Result Display";
            this.Btn_ResultDisplay.CornerRadius = 0;
            this.Btn_ResultDisplay.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_ResultDisplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_ResultDisplay.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ResultDisplay.Location = new System.Drawing.Point(0, 0);
            this.Btn_ResultDisplay.Name = "Btn_ResultDisplay";
            this.Btn_ResultDisplay.Size = new System.Drawing.Size(216, 39);
            this.Btn_ResultDisplay.TabIndex = 17;
            this.Btn_ResultDisplay.Click += new System.EventHandler(this.Btn_ResultDisplay_Click);
            // 
            // Pnl_ResultDisplay
            // 
            this.Pnl_ResultDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pnl_ResultDisplay.Controls.Add(this.responseGroupBox);
            this.Pnl_ResultDisplay.Controls.Add(this.label5);
            this.Pnl_ResultDisplay.Controls.Add(this.label4);
            this.Pnl_ResultDisplay.Controls.Add(this.label3);
            this.Pnl_ResultDisplay.Controls.Add(this.label2);
            this.Pnl_ResultDisplay.Controls.Add(this.groupBox2);
            this.Pnl_ResultDisplay.Controls.Add(this.imageGroupBox);
            this.Pnl_ResultDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_ResultDisplay.Location = new System.Drawing.Point(0, 0);
            this.Pnl_ResultDisplay.Name = "Pnl_ResultDisplay";
            this.Pnl_ResultDisplay.Size = new System.Drawing.Size(572, 533);
            this.Pnl_ResultDisplay.TabIndex = 0;
            this.Pnl_ResultDisplay.Visible = false;
            // 
            // responseGroupBox
            // 
            this.responseGroupBox.Controls.Add(this.LST_RESULT);
            this.responseGroupBox.Location = new System.Drawing.Point(13, 302);
            this.responseGroupBox.Name = "responseGroupBox";
            this.responseGroupBox.Size = new System.Drawing.Size(510, 199);
            this.responseGroupBox.TabIndex = 38;
            this.responseGroupBox.TabStop = false;
            this.responseGroupBox.Text = "Response from device";
            // 
            // LST_RESULT
            // 
            this.LST_RESULT.FormattingEnabled = true;
            this.LST_RESULT.HorizontalScrollbar = true;
            this.LST_RESULT.Location = new System.Drawing.Point(5, 18);
            this.LST_RESULT.Name = "LST_RESULT";
            this.LST_RESULT.ScrollAlwaysVisible = true;
            this.LST_RESULT.Size = new System.Drawing.Size(501, 173);
            this.LST_RESULT.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Img Rcvd Count:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Data Scan Count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "Data Scan Count:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Image Update Time";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.liveDisplayCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(342, 253);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(87, 42);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Live display";
            // 
            // liveDisplayCheckBox
            // 
            this.liveDisplayCheckBox.AutoSize = true;
            this.liveDisplayCheckBox.Enabled = false;
            this.liveDisplayCheckBox.Location = new System.Drawing.Point(12, 19);
            this.liveDisplayCheckBox.Name = "liveDisplayCheckBox";
            this.liveDisplayCheckBox.Size = new System.Drawing.Size(65, 17);
            this.liveDisplayCheckBox.TabIndex = 25;
            this.liveDisplayCheckBox.Text = "On / Off";
            this.liveDisplayCheckBox.UseVisualStyleBackColor = true;
            // 
            // imageGroupBox
            // 
            this.imageGroupBox.Controls.Add(this.lastImagePictureBox);
            this.imageGroupBox.Location = new System.Drawing.Point(13, 7);
            this.imageGroupBox.Name = "imageGroupBox";
            this.imageGroupBox.Size = new System.Drawing.Size(513, 238);
            this.imageGroupBox.TabIndex = 32;
            this.imageGroupBox.TabStop = false;
            this.imageGroupBox.Text = "Last read image";
            // 
            // lastImagePictureBox
            // 
            this.lastImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lastImagePictureBox.Location = new System.Drawing.Point(73, 15);
            this.lastImagePictureBox.Name = "lastImagePictureBox";
            this.lastImagePictureBox.Size = new System.Drawing.Size(333, 213);
            this.lastImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lastImagePictureBox.TabIndex = 7;
            this.lastImagePictureBox.TabStop = false;
            this.lastImagePictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.lastImagePictureBox_Paint);
            // 
            // PNL_LightCameraSetting
            // 
            this.PNL_LightCameraSetting.Controls.Add(this.label18);
            this.PNL_LightCameraSetting.Controls.Add(this.panel1);
            this.PNL_LightCameraSetting.Controls.Add(this.CMB_TRIGGERTYPE);
            this.PNL_LightCameraSetting.Controls.Add(this.label6);
            this.PNL_LightCameraSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_LightCameraSetting.Location = new System.Drawing.Point(0, 0);
            this.PNL_LightCameraSetting.Name = "PNL_LightCameraSetting";
            this.PNL_LightCameraSetting.Size = new System.Drawing.Size(572, 533);
            this.PNL_LightCameraSetting.TabIndex = 39;
            this.PNL_LightCameraSetting.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(156, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(225, 20);
            this.label18.TabIndex = 15;
            this.label18.Text = "Light And Camera Settings";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Pnl_MaxExposure);
            this.panel1.Controls.Add(this.Pnl_Exposure);
            this.panel1.Controls.Add(this.Pnl_Interval);
            this.panel1.Controls.Add(this.Pnl_Timeout);
            this.panel1.Location = new System.Drawing.Point(29, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 391);
            this.panel1.TabIndex = 14;
            // 
            // Pnl_MaxExposure
            // 
            this.Pnl_MaxExposure.Controls.Add(this.label14);
            this.Pnl_MaxExposure.Controls.Add(this.Cmb_MaximumExposure);
            this.Pnl_MaxExposure.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_MaxExposure.Location = new System.Drawing.Point(0, 327);
            this.Pnl_MaxExposure.Name = "Pnl_MaxExposure";
            this.Pnl_MaxExposure.Size = new System.Drawing.Size(476, 63);
            this.Pnl_MaxExposure.TabIndex = 18;
            this.Pnl_MaxExposure.Visible = false;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(111, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 29);
            this.label14.TabIndex = 13;
            this.label14.Text = "Maximum Exposure";
            this.label14.Visible = false;
            // 
            // Cmb_MaximumExposure
            // 
            this.Cmb_MaximumExposure.FormattingEnabled = true;
            this.Cmb_MaximumExposure.Items.AddRange(new object[] {
            "1/1000",
            "1/750",
            "1/500",
            "1/300",
            "1/250",
            "1/200",
            "1/150",
            "1/125",
            "1/100",
            "1/75",
            "1/50",
            "1/40"});
            this.Cmb_MaximumExposure.Location = new System.Drawing.Point(210, 23);
            this.Cmb_MaximumExposure.Name = "Cmb_MaximumExposure";
            this.Cmb_MaximumExposure.Size = new System.Drawing.Size(124, 21);
            this.Cmb_MaximumExposure.TabIndex = 13;
            this.Cmb_MaximumExposure.Visible = false;
            this.Cmb_MaximumExposure.SelectionChangeCommitted += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // Pnl_Exposure
            // 
            this.Pnl_Exposure.Controls.Add(this.Pnl_ManualExposure);
            this.Pnl_Exposure.Controls.Add(this.Pnl_AutomaticExposure);
            this.Pnl_Exposure.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Exposure.Location = new System.Drawing.Point(0, 107);
            this.Pnl_Exposure.Name = "Pnl_Exposure";
            this.Pnl_Exposure.Size = new System.Drawing.Size(476, 220);
            this.Pnl_Exposure.TabIndex = 17;
            this.Pnl_Exposure.Visible = false;
            // 
            // Pnl_ManualExposure
            // 
            this.Pnl_ManualExposure.Controls.Add(this.Grp_ManualExp);
            this.Pnl_ManualExposure.Controls.Add(this.Opt_ManualExposure);
            this.Pnl_ManualExposure.Location = new System.Drawing.Point(33, 90);
            this.Pnl_ManualExposure.Name = "Pnl_ManualExposure";
            this.Pnl_ManualExposure.Size = new System.Drawing.Size(422, 123);
            this.Pnl_ManualExposure.TabIndex = 15;
            // 
            // Grp_ManualExp
            // 
            this.Grp_ManualExp.Controls.Add(this.CMB_Exposure);
            this.Grp_ManualExp.Controls.Add(this.label13);
            this.Grp_ManualExp.Controls.Add(this.label10);
            this.Grp_ManualExp.Controls.Add(this.label11);
            this.Grp_ManualExp.Controls.Add(this.TXT_ManualExposure);
            this.Grp_ManualExp.Controls.Add(this.label12);
            this.Grp_ManualExp.Controls.Add(this.Track_ManualExposure);
            this.Grp_ManualExp.Enabled = false;
            this.Grp_ManualExp.Location = new System.Drawing.Point(73, 6);
            this.Grp_ManualExp.Name = "Grp_ManualExp";
            this.Grp_ManualExp.Size = new System.Drawing.Size(278, 107);
            this.Grp_ManualExp.TabIndex = 12;
            this.Grp_ManualExp.TabStop = false;
            this.Grp_ManualExp.Text = "Manual Exposure";
            // 
            // CMB_Exposure
            // 
            this.CMB_Exposure.FormattingEnabled = true;
            this.CMB_Exposure.Items.AddRange(new object[] {
            "1/10000",
            "1/7500",
            "1/5000",
            "1/4000",
            "1/3000",
            "1/2500",
            "1/2000",
            "1/1500",
            "1/1250",
            "1/1000",
            "1/750",
            "1/500",
            "1/300",
            "1/250",
            "1/200",
            "1/150",
            "1/125",
            "1/100",
            "1/75",
            "1/50",
            "1/40"});
            this.CMB_Exposure.Location = new System.Drawing.Point(96, 76);
            this.CMB_Exposure.Name = "CMB_Exposure";
            this.CMB_Exposure.Size = new System.Drawing.Size(124, 21);
            this.CMB_Exposure.TabIndex = 12;
            this.CMB_Exposure.SelectionChangeCommitted += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 24);
            this.label13.TabIndex = 10;
            this.label13.Text = "Exposure";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(187, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 19);
            this.label10.TabIndex = 9;
            this.label10.Text = "High";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(91, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 19);
            this.label11.TabIndex = 7;
            this.label11.Text = "Low";
            // 
            // TXT_ManualExposure
            // 
            this.TXT_ManualExposure.Location = new System.Drawing.Point(224, 20);
            this.TXT_ManualExposure.Name = "TXT_ManualExposure";
            this.TXT_ManualExposure.Size = new System.Drawing.Size(47, 20);
            this.TXT_ManualExposure.TabIndex = 8;
            this.TXT_ManualExposure.TextChanged += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 27);
            this.label12.TabIndex = 7;
            this.label12.Text = "Gain";
            // 
            // Track_ManualExposure
            // 
            this.Track_ManualExposure.AutoSize = false;
            this.Track_ManualExposure.Location = new System.Drawing.Point(87, 17);
            this.Track_ManualExposure.Maximum = 60;
            this.Track_ManualExposure.Minimum = 4;
            this.Track_ManualExposure.Name = "Track_ManualExposure";
            this.Track_ManualExposure.Size = new System.Drawing.Size(134, 23);
            this.Track_ManualExposure.TabIndex = 4;
            this.Track_ManualExposure.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Track_ManualExposure.Value = 4;
            this.Track_ManualExposure.Scroll += new System.EventHandler(this.Track_ManualExposure_Scroll);
            // 
            // Opt_ManualExposure
            // 
            this.Opt_ManualExposure.AutoSize = true;
            this.Opt_ManualExposure.Location = new System.Drawing.Point(42, 30);
            this.Opt_ManualExposure.Name = "Opt_ManualExposure";
            this.Opt_ManualExposure.Size = new System.Drawing.Size(14, 13);
            this.Opt_ManualExposure.TabIndex = 13;
            this.Opt_ManualExposure.TabStop = true;
            this.Opt_ManualExposure.UseVisualStyleBackColor = true;
            this.Opt_ManualExposure.CheckedChanged += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // Pnl_AutomaticExposure
            // 
            this.Pnl_AutomaticExposure.Controls.Add(this.Grp_AutomaticExp);
            this.Pnl_AutomaticExposure.Controls.Add(this.Opt_AutomaticExposure);
            this.Pnl_AutomaticExposure.Location = new System.Drawing.Point(33, 5);
            this.Pnl_AutomaticExposure.Name = "Pnl_AutomaticExposure";
            this.Pnl_AutomaticExposure.Size = new System.Drawing.Size(422, 83);
            this.Pnl_AutomaticExposure.TabIndex = 14;
            // 
            // Grp_AutomaticExp
            // 
            this.Grp_AutomaticExp.Controls.Add(this.label9);
            this.Grp_AutomaticExp.Controls.Add(this.label8);
            this.Grp_AutomaticExp.Controls.Add(this.TXT_AutomaticExpVal);
            this.Grp_AutomaticExp.Controls.Add(this.label7);
            this.Grp_AutomaticExp.Controls.Add(this.Track_TargetBrightness);
            this.Grp_AutomaticExp.Enabled = false;
            this.Grp_AutomaticExp.Location = new System.Drawing.Point(74, 7);
            this.Grp_AutomaticExp.Name = "Grp_AutomaticExp";
            this.Grp_AutomaticExp.Size = new System.Drawing.Size(278, 68);
            this.Grp_AutomaticExp.TabIndex = 6;
            this.Grp_AutomaticExp.TabStop = false;
            this.Grp_AutomaticExp.Text = "Automatic Exposure";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(192, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "255";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(92, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "0";
            // 
            // TXT_AutomaticExpVal
            // 
            this.TXT_AutomaticExpVal.Location = new System.Drawing.Point(225, 20);
            this.TXT_AutomaticExpVal.Name = "TXT_AutomaticExpVal";
            this.TXT_AutomaticExpVal.Size = new System.Drawing.Size(47, 20);
            this.TXT_AutomaticExpVal.TabIndex = 8;
            this.TXT_AutomaticExpVal.TextChanged += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 36);
            this.label7.TabIndex = 7;
            this.label7.Text = "Target Brightness";
            // 
            // Track_TargetBrightness
            // 
            this.Track_TargetBrightness.AutoSize = false;
            this.Track_TargetBrightness.Location = new System.Drawing.Point(88, 17);
            this.Track_TargetBrightness.Maximum = 255;
            this.Track_TargetBrightness.Name = "Track_TargetBrightness";
            this.Track_TargetBrightness.Size = new System.Drawing.Size(134, 23);
            this.Track_TargetBrightness.TabIndex = 4;
            this.Track_TargetBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Track_TargetBrightness.Scroll += new System.EventHandler(this.Track_TargetBrightness_Scroll);
            // 
            // Opt_AutomaticExposure
            // 
            this.Opt_AutomaticExposure.AutoSize = true;
            this.Opt_AutomaticExposure.Location = new System.Drawing.Point(42, 13);
            this.Opt_AutomaticExposure.Name = "Opt_AutomaticExposure";
            this.Opt_AutomaticExposure.Size = new System.Drawing.Size(14, 13);
            this.Opt_AutomaticExposure.TabIndex = 5;
            this.Opt_AutomaticExposure.TabStop = true;
            this.Opt_AutomaticExposure.UseVisualStyleBackColor = true;
            this.Opt_AutomaticExposure.CheckedChanged += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // Pnl_Interval
            // 
            this.Pnl_Interval.Controls.Add(this.Track_Interval);
            this.Pnl_Interval.Controls.Add(this.lblInterval);
            this.Pnl_Interval.Controls.Add(this.label16);
            this.Pnl_Interval.Controls.Add(this.TXT_Interval);
            this.Pnl_Interval.Controls.Add(this.label17);
            this.Pnl_Interval.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Interval.Location = new System.Drawing.Point(0, 46);
            this.Pnl_Interval.Name = "Pnl_Interval";
            this.Pnl_Interval.Size = new System.Drawing.Size(476, 61);
            this.Pnl_Interval.TabIndex = 16;
            this.Pnl_Interval.Visible = false;
            // 
            // Track_Interval
            // 
            this.Track_Interval.AutoSize = false;
            this.Track_Interval.Location = new System.Drawing.Point(220, 7);
            this.Track_Interval.Maximum = 1000;
            this.Track_Interval.Minimum = 200;
            this.Track_Interval.Name = "Track_Interval";
            this.Track_Interval.Size = new System.Drawing.Size(127, 23);
            this.Track_Interval.TabIndex = 10;
            this.Track_Interval.TickStyle = System.Windows.Forms.TickStyle.None;
            this.Track_Interval.Value = 200;
            this.Track_Interval.Scroll += new System.EventHandler(this.Track_Interval_Scroll);
            // 
            // lblInterval
            // 
            this.lblInterval.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterval.Location = new System.Drawing.Point(110, 11);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(83, 21);
            this.lblInterval.TabIndex = 11;
            this.lblInterval.Text = "Interval[ms]";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(315, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 21);
            this.label16.TabIndex = 14;
            this.label16.Text = "1000";
            // 
            // TXT_Interval
            // 
            this.TXT_Interval.Location = new System.Drawing.Point(353, 10);
            this.TXT_Interval.Name = "TXT_Interval";
            this.TXT_Interval.Size = new System.Drawing.Size(47, 20);
            this.TXT_Interval.TabIndex = 13;
            this.TXT_Interval.TextChanged += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(226, 36);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 21);
            this.label17.TabIndex = 12;
            this.label17.Text = "200";
            // 
            // Pnl_Timeout
            // 
            this.Pnl_Timeout.Controls.Add(this.label15);
            this.Pnl_Timeout.Controls.Add(this.TXT_Timeout);
            this.Pnl_Timeout.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_Timeout.Location = new System.Drawing.Point(0, 0);
            this.Pnl_Timeout.Name = "Pnl_Timeout";
            this.Pnl_Timeout.Size = new System.Drawing.Size(476, 46);
            this.Pnl_Timeout.TabIndex = 15;
            this.Pnl_Timeout.Visible = false;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(110, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 23);
            this.label15.TabIndex = 10;
            this.label15.Text = "Timeout[ms]";
            // 
            // TXT_Timeout
            // 
            this.TXT_Timeout.Location = new System.Drawing.Point(224, 10);
            this.TXT_Timeout.Name = "TXT_Timeout";
            this.TXT_Timeout.Size = new System.Drawing.Size(81, 20);
            this.TXT_Timeout.TabIndex = 10;
            this.TXT_Timeout.Text = "2000";
            this.TXT_Timeout.TextChanged += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // CMB_TRIGGERTYPE
            // 
            this.CMB_TRIGGERTYPE.FormattingEnabled = true;
            this.CMB_TRIGGERTYPE.Items.AddRange(new object[] {
            "Single(external)",
            "Presentation(internal)",
            "Manual(button)",
            "Self(internal)"});
            this.CMB_TRIGGERTYPE.Location = new System.Drawing.Point(250, 60);
            this.CMB_TRIGGERTYPE.Name = "CMB_TRIGGERTYPE";
            this.CMB_TRIGGERTYPE.Size = new System.Drawing.Size(149, 21);
            this.CMB_TRIGGERTYPE.TabIndex = 3;
            this.CMB_TRIGGERTYPE.SelectionChangeCommitted += new System.EventHandler(this.LightCameraChangedEvent);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(138, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "TRIGGER TYPE";
            // 
            // Pnl_SymbologySetting
            // 
            this.Pnl_SymbologySetting.Controls.Add(this.tabControl1);
            this.Pnl_SymbologySetting.Controls.Add(this.label19);
            this.Pnl_SymbologySetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Pnl_SymbologySetting.Location = new System.Drawing.Point(0, 0);
            this.Pnl_SymbologySetting.Name = "Pnl_SymbologySetting";
            this.Pnl_SymbologySetting.Size = new System.Drawing.Size(572, 533);
            this.Pnl_SymbologySetting.TabIndex = 40;
            this.Pnl_SymbologySetting.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(8, 26);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 479);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.GRP_Postal);
            this.tabPage1.Controls.Add(this.GRP_Stacked);
            this.tabPage1.Controls.Add(this.GRP_1D);
            this.tabPage1.Controls.Add(this.GRP_2D);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // GRP_Postal
            // 
            this.GRP_Postal.Controls.Add(this.GRP_StateCode);
            this.GRP_Postal.Controls.Add(this.CHK_Planet);
            this.GRP_Postal.Controls.Add(this.CHK_Postnet);
            this.GRP_Postal.Location = new System.Drawing.Point(14, 334);
            this.GRP_Postal.Name = "GRP_Postal";
            this.GRP_Postal.Size = new System.Drawing.Size(484, 96);
            this.GRP_Postal.TabIndex = 10;
            this.GRP_Postal.TabStop = false;
            this.GRP_Postal.Text = "Postal";
            // 
            // GRP_StateCode
            // 
            this.GRP_StateCode.Controls.Add(this.CHK_IntelligentMailBarcode);
            this.GRP_StateCode.Controls.Add(this.CHK_UPC);
            this.GRP_StateCode.Controls.Add(this.CHK_AustaliaPost);
            this.GRP_StateCode.Controls.Add(this.CHK_JapanPost);
            this.GRP_StateCode.Location = new System.Drawing.Point(214, 16);
            this.GRP_StateCode.Name = "GRP_StateCode";
            this.GRP_StateCode.Size = new System.Drawing.Size(264, 72);
            this.GRP_StateCode.TabIndex = 11;
            this.GRP_StateCode.TabStop = false;
            this.GRP_StateCode.Text = "Stae Code";
            // 
            // CHK_IntelligentMailBarcode
            // 
            this.CHK_IntelligentMailBarcode.AutoSize = true;
            this.CHK_IntelligentMailBarcode.Location = new System.Drawing.Point(124, 41);
            this.CHK_IntelligentMailBarcode.Name = "CHK_IntelligentMailBarcode";
            this.CHK_IntelligentMailBarcode.Size = new System.Drawing.Size(136, 17);
            this.CHK_IntelligentMailBarcode.TabIndex = 8;
            this.CHK_IntelligentMailBarcode.Text = "Intelligent Mail Barcode";
            this.CHK_IntelligentMailBarcode.UseVisualStyleBackColor = true;
            this.CHK_IntelligentMailBarcode.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_UPC
            // 
            this.CHK_UPC.AutoSize = true;
            this.CHK_UPC.Location = new System.Drawing.Point(124, 19);
            this.CHK_UPC.Name = "CHK_UPC";
            this.CHK_UPC.Size = new System.Drawing.Size(48, 17);
            this.CHK_UPC.TabIndex = 7;
            this.CHK_UPC.Text = "UPC";
            this.CHK_UPC.UseVisualStyleBackColor = true;
            this.CHK_UPC.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_AustaliaPost
            // 
            this.CHK_AustaliaPost.AutoSize = true;
            this.CHK_AustaliaPost.Location = new System.Drawing.Point(24, 39);
            this.CHK_AustaliaPost.Name = "CHK_AustaliaPost";
            this.CHK_AustaliaPost.Size = new System.Drawing.Size(90, 17);
            this.CHK_AustaliaPost.TabIndex = 4;
            this.CHK_AustaliaPost.Text = "Australia Post";
            this.CHK_AustaliaPost.UseVisualStyleBackColor = true;
            this.CHK_AustaliaPost.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_JapanPost
            // 
            this.CHK_JapanPost.AutoSize = true;
            this.CHK_JapanPost.Location = new System.Drawing.Point(24, 16);
            this.CHK_JapanPost.Name = "CHK_JapanPost";
            this.CHK_JapanPost.Size = new System.Drawing.Size(79, 17);
            this.CHK_JapanPost.TabIndex = 3;
            this.CHK_JapanPost.Text = "Japan Post";
            this.CHK_JapanPost.UseVisualStyleBackColor = true;
            this.CHK_JapanPost.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Planet
            // 
            this.CHK_Planet.AutoSize = true;
            this.CHK_Planet.Location = new System.Drawing.Point(24, 57);
            this.CHK_Planet.Name = "CHK_Planet";
            this.CHK_Planet.Size = new System.Drawing.Size(68, 17);
            this.CHK_Planet.TabIndex = 4;
            this.CHK_Planet.Text = "PLANET";
            this.CHK_Planet.UseVisualStyleBackColor = true;
            this.CHK_Planet.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Postnet
            // 
            this.CHK_Postnet.AutoSize = true;
            this.CHK_Postnet.Location = new System.Drawing.Point(24, 26);
            this.CHK_Postnet.Name = "CHK_Postnet";
            this.CHK_Postnet.Size = new System.Drawing.Size(77, 17);
            this.CHK_Postnet.TabIndex = 3;
            this.CHK_Postnet.Text = "POSTNET";
            this.CHK_Postnet.UseVisualStyleBackColor = true;
            this.CHK_Postnet.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // GRP_Stacked
            // 
            this.GRP_Stacked.Controls.Add(this.CHK_EANUCCComposite);
            this.GRP_Stacked.Controls.Add(this.CHK_Databar);
            this.GRP_Stacked.Controls.Add(this.CHK_MicroPDF417);
            this.GRP_Stacked.Controls.Add(this.CHK_PDF417);
            this.GRP_Stacked.Location = new System.Drawing.Point(14, 250);
            this.GRP_Stacked.Name = "GRP_Stacked";
            this.GRP_Stacked.Size = new System.Drawing.Size(484, 68);
            this.GRP_Stacked.TabIndex = 9;
            this.GRP_Stacked.TabStop = false;
            this.GRP_Stacked.Text = "Stacked";
            // 
            // CHK_EANUCCComposite
            // 
            this.CHK_EANUCCComposite.AutoSize = true;
            this.CHK_EANUCCComposite.Location = new System.Drawing.Point(214, 39);
            this.CHK_EANUCCComposite.Name = "CHK_EANUCCComposite";
            this.CHK_EANUCCComposite.Size = new System.Drawing.Size(125, 17);
            this.CHK_EANUCCComposite.TabIndex = 8;
            this.CHK_EANUCCComposite.Text = "EAN.UCC Composite";
            this.CHK_EANUCCComposite.UseVisualStyleBackColor = true;
            this.CHK_EANUCCComposite.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Databar
            // 
            this.CHK_Databar.AutoSize = true;
            this.CHK_Databar.Location = new System.Drawing.Point(214, 14);
            this.CHK_Databar.Name = "CHK_Databar";
            this.CHK_Databar.Size = new System.Drawing.Size(64, 17);
            this.CHK_Databar.TabIndex = 7;
            this.CHK_Databar.Text = "Databar";
            this.CHK_Databar.UseVisualStyleBackColor = true;
            this.CHK_Databar.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_MicroPDF417
            // 
            this.CHK_MicroPDF417.AutoSize = true;
            this.CHK_MicroPDF417.Location = new System.Drawing.Point(24, 39);
            this.CHK_MicroPDF417.Name = "CHK_MicroPDF417";
            this.CHK_MicroPDF417.Size = new System.Drawing.Size(94, 17);
            this.CHK_MicroPDF417.TabIndex = 4;
            this.CHK_MicroPDF417.Text = "Micro PDF417";
            this.CHK_MicroPDF417.UseVisualStyleBackColor = true;
            this.CHK_MicroPDF417.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_PDF417
            // 
            this.CHK_PDF417.AutoSize = true;
            this.CHK_PDF417.Location = new System.Drawing.Point(24, 16);
            this.CHK_PDF417.Name = "CHK_PDF417";
            this.CHK_PDF417.Size = new System.Drawing.Size(65, 17);
            this.CHK_PDF417.TabIndex = 3;
            this.CHK_PDF417.Text = "PDF417";
            this.CHK_PDF417.UseVisualStyleBackColor = true;
            this.CHK_PDF417.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // GRP_1D
            // 
            this.GRP_1D.Controls.Add(this.CHK_Codebar);
            this.GRP_1D.Controls.Add(this.CHK_Code93);
            this.GRP_1D.Controls.Add(this.CHK_UPCEAN);
            this.GRP_1D.Controls.Add(this.CHK_Pharmacode);
            this.GRP_1D.Controls.Add(this.CHK_Interleaved2of5);
            this.GRP_1D.Controls.Add(this.CHK_Code39);
            this.GRP_1D.Controls.Add(this.CHK_Code128);
            this.GRP_1D.Location = new System.Drawing.Point(14, 114);
            this.GRP_1D.Name = "GRP_1D";
            this.GRP_1D.Size = new System.Drawing.Size(484, 120);
            this.GRP_1D.TabIndex = 1;
            this.GRP_1D.TabStop = false;
            this.GRP_1D.Text = "1D";
            // 
            // CHK_Codebar
            // 
            this.CHK_Codebar.AutoSize = true;
            this.CHK_Codebar.Location = new System.Drawing.Point(214, 66);
            this.CHK_Codebar.Name = "CHK_Codebar";
            this.CHK_Codebar.Size = new System.Drawing.Size(66, 17);
            this.CHK_Codebar.TabIndex = 9;
            this.CHK_Codebar.Text = "Codebar";
            this.CHK_Codebar.UseVisualStyleBackColor = true;
            this.CHK_Codebar.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Code93
            // 
            this.CHK_Code93.AutoSize = true;
            this.CHK_Code93.Location = new System.Drawing.Point(214, 39);
            this.CHK_Code93.Name = "CHK_Code93";
            this.CHK_Code93.Size = new System.Drawing.Size(66, 17);
            this.CHK_Code93.TabIndex = 8;
            this.CHK_Code93.Text = "Code 93";
            this.CHK_Code93.UseVisualStyleBackColor = true;
            this.CHK_Code93.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_UPCEAN
            // 
            this.CHK_UPCEAN.AutoSize = true;
            this.CHK_UPCEAN.Location = new System.Drawing.Point(214, 16);
            this.CHK_UPCEAN.Name = "CHK_UPCEAN";
            this.CHK_UPCEAN.Size = new System.Drawing.Size(75, 17);
            this.CHK_UPCEAN.TabIndex = 7;
            this.CHK_UPCEAN.Text = "UPC/EAN";
            this.CHK_UPCEAN.UseVisualStyleBackColor = true;
            this.CHK_UPCEAN.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Pharmacode
            // 
            this.CHK_Pharmacode.AutoSize = true;
            this.CHK_Pharmacode.Location = new System.Drawing.Point(24, 96);
            this.CHK_Pharmacode.Name = "CHK_Pharmacode";
            this.CHK_Pharmacode.Size = new System.Drawing.Size(86, 17);
            this.CHK_Pharmacode.TabIndex = 6;
            this.CHK_Pharmacode.Text = "Pharmacode";
            this.CHK_Pharmacode.UseVisualStyleBackColor = true;
            this.CHK_Pharmacode.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Interleaved2of5
            // 
            this.CHK_Interleaved2of5.AutoSize = true;
            this.CHK_Interleaved2of5.Location = new System.Drawing.Point(24, 67);
            this.CHK_Interleaved2of5.Name = "CHK_Interleaved2of5";
            this.CHK_Interleaved2of5.Size = new System.Drawing.Size(109, 17);
            this.CHK_Interleaved2of5.TabIndex = 5;
            this.CHK_Interleaved2of5.Text = "Interleaved 2 of 5";
            this.CHK_Interleaved2of5.UseVisualStyleBackColor = true;
            this.CHK_Interleaved2of5.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Code39
            // 
            this.CHK_Code39.AutoSize = true;
            this.CHK_Code39.Location = new System.Drawing.Point(24, 39);
            this.CHK_Code39.Name = "CHK_Code39";
            this.CHK_Code39.Size = new System.Drawing.Size(66, 17);
            this.CHK_Code39.TabIndex = 4;
            this.CHK_Code39.Text = "Code 39";
            this.CHK_Code39.UseVisualStyleBackColor = true;
            this.CHK_Code39.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Code128
            // 
            this.CHK_Code128.AutoSize = true;
            this.CHK_Code128.Location = new System.Drawing.Point(24, 16);
            this.CHK_Code128.Name = "CHK_Code128";
            this.CHK_Code128.Size = new System.Drawing.Size(69, 17);
            this.CHK_Code128.TabIndex = 3;
            this.CHK_Code128.Text = "Code128";
            this.CHK_Code128.UseVisualStyleBackColor = true;
            this.CHK_Code128.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // GRP_2D
            // 
            this.GRP_2D.Controls.Add(this.GRP_Algorithm);
            this.GRP_2D.Controls.Add(this.CHK_QRCode);
            this.GRP_2D.Controls.Add(this.CHK_Datamatrix);
            this.GRP_2D.Location = new System.Drawing.Point(14, 14);
            this.GRP_2D.Name = "GRP_2D";
            this.GRP_2D.Size = new System.Drawing.Size(484, 84);
            this.GRP_2D.TabIndex = 0;
            this.GRP_2D.TabStop = false;
            this.GRP_2D.Text = "2D";
            // 
            // GRP_Algorithm
            // 
            this.GRP_Algorithm.Controls.Add(this.OPT_IDQuick);
            this.GRP_Algorithm.Controls.Add(this.OPT_IDMAX);
            this.GRP_Algorithm.Location = new System.Drawing.Point(214, 8);
            this.GRP_Algorithm.Name = "GRP_Algorithm";
            this.GRP_Algorithm.Size = new System.Drawing.Size(223, 68);
            this.GRP_Algorithm.TabIndex = 2;
            this.GRP_Algorithm.TabStop = false;
            this.GRP_Algorithm.Text = "Algorithm";
            // 
            // OPT_IDQuick
            // 
            this.OPT_IDQuick.AutoSize = true;
            this.OPT_IDQuick.Location = new System.Drawing.Point(17, 41);
            this.OPT_IDQuick.Name = "OPT_IDQuick";
            this.OPT_IDQuick.Size = new System.Drawing.Size(67, 17);
            this.OPT_IDQuick.TabIndex = 1;
            this.OPT_IDQuick.TabStop = true;
            this.OPT_IDQuick.Text = "ID Quick";
            this.OPT_IDQuick.UseVisualStyleBackColor = true;
            this.OPT_IDQuick.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // OPT_IDMAX
            // 
            this.OPT_IDMAX.AutoSize = true;
            this.OPT_IDMAX.Location = new System.Drawing.Point(17, 19);
            this.OPT_IDMAX.Name = "OPT_IDMAX";
            this.OPT_IDMAX.Size = new System.Drawing.Size(59, 17);
            this.OPT_IDMAX.TabIndex = 0;
            this.OPT_IDMAX.TabStop = true;
            this.OPT_IDMAX.Text = "ID Max";
            this.OPT_IDMAX.UseVisualStyleBackColor = true;
            this.OPT_IDMAX.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_QRCode
            // 
            this.CHK_QRCode.AutoSize = true;
            this.CHK_QRCode.Location = new System.Drawing.Point(24, 49);
            this.CHK_QRCode.Name = "CHK_QRCode";
            this.CHK_QRCode.Size = new System.Drawing.Size(70, 17);
            this.CHK_QRCode.TabIndex = 1;
            this.CHK_QRCode.Text = "QR Code";
            this.CHK_QRCode.UseVisualStyleBackColor = true;
            this.CHK_QRCode.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // CHK_Datamatrix
            // 
            this.CHK_Datamatrix.AutoSize = true;
            this.CHK_Datamatrix.Location = new System.Drawing.Point(24, 27);
            this.CHK_Datamatrix.Name = "CHK_Datamatrix";
            this.CHK_Datamatrix.Size = new System.Drawing.Size(80, 17);
            this.CHK_Datamatrix.TabIndex = 0;
            this.CHK_Datamatrix.Text = "Data Matrix";
            this.CHK_Datamatrix.UseVisualStyleBackColor = true;
            this.CHK_Datamatrix.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.PNL_SETNOOFCode);
            this.tabPage2.Controls.Add(this.GRP_SortingPriority);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Multicode";
            // 
            // PNL_SETNOOFCode
            // 
            this.PNL_SETNOOFCode.Controls.Add(this.Num_NoOfCodes);
            this.PNL_SETNOOFCode.Controls.Add(this.label20);
            this.PNL_SETNOOFCode.Controls.Add(this.groupBox7);
            this.PNL_SETNOOFCode.Controls.Add(this.groupBox6);
            this.PNL_SETNOOFCode.Controls.Add(this.groupBox3);
            this.PNL_SETNOOFCode.Controls.Add(this.CHK_PartialResult);
            this.PNL_SETNOOFCode.Enabled = false;
            this.PNL_SETNOOFCode.Location = new System.Drawing.Point(3, 1);
            this.PNL_SETNOOFCode.Name = "PNL_SETNOOFCode";
            this.PNL_SETNOOFCode.Size = new System.Drawing.Size(506, 304);
            this.PNL_SETNOOFCode.TabIndex = 12;
            // 
            // Num_NoOfCodes
            // 
            this.Num_NoOfCodes.Location = new System.Drawing.Point(250, 3);
            this.Num_NoOfCodes.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.Num_NoOfCodes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_NoOfCodes.Name = "Num_NoOfCodes";
            this.Num_NoOfCodes.Size = new System.Drawing.Size(120, 20);
            this.Num_NoOfCodes.TabIndex = 10;
            this.Num_NoOfCodes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Num_NoOfCodes.ValueChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(135, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Number Of Codes";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.NUM_1DStackedPostalNoOfCode);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Location = new System.Drawing.Point(71, 223);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(362, 68);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "1D/Stacked/Postal";
            // 
            // NUM_1DStackedPostalNoOfCode
            // 
            this.NUM_1DStackedPostalNoOfCode.Location = new System.Drawing.Point(199, 24);
            this.NUM_1DStackedPostalNoOfCode.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NUM_1DStackedPostalNoOfCode.Name = "NUM_1DStackedPostalNoOfCode";
            this.NUM_1DStackedPostalNoOfCode.Size = new System.Drawing.Size(91, 20);
            this.NUM_1DStackedPostalNoOfCode.TabIndex = 10;
            this.NUM_1DStackedPostalNoOfCode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_1DStackedPostalNoOfCode.ValueChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(73, 28);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(117, 13);
            this.label23.TabIndex = 9;
            this.label23.Text = "Max. Number Of Codes";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.NUM_QRNoOfCode);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Location = new System.Drawing.Point(71, 145);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(362, 68);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "QR Code";
            // 
            // NUM_QRNoOfCode
            // 
            this.NUM_QRNoOfCode.Location = new System.Drawing.Point(199, 24);
            this.NUM_QRNoOfCode.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NUM_QRNoOfCode.Name = "NUM_QRNoOfCode";
            this.NUM_QRNoOfCode.Size = new System.Drawing.Size(91, 20);
            this.NUM_QRNoOfCode.TabIndex = 8;
            this.NUM_QRNoOfCode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_QRNoOfCode.ValueChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(73, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(117, 13);
            this.label22.TabIndex = 7;
            this.label22.Text = "Max. Number Of Codes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.NUM_DatamatrixNoOfCode);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Location = new System.Drawing.Point(71, 67);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(362, 68);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data Matrix";
            // 
            // NUM_DatamatrixNoOfCode
            // 
            this.NUM_DatamatrixNoOfCode.Location = new System.Drawing.Point(199, 24);
            this.NUM_DatamatrixNoOfCode.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NUM_DatamatrixNoOfCode.Name = "NUM_DatamatrixNoOfCode";
            this.NUM_DatamatrixNoOfCode.Size = new System.Drawing.Size(91, 20);
            this.NUM_DatamatrixNoOfCode.TabIndex = 6;
            this.NUM_DatamatrixNoOfCode.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUM_DatamatrixNoOfCode.ValueChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(73, 28);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(117, 13);
            this.label21.TabIndex = 5;
            this.label21.Text = "Max. Number Of Codes";
            // 
            // CHK_PartialResult
            // 
            this.CHK_PartialResult.AutoSize = true;
            this.CHK_PartialResult.Location = new System.Drawing.Point(138, 42);
            this.CHK_PartialResult.Name = "CHK_PartialResult";
            this.CHK_PartialResult.Size = new System.Drawing.Size(116, 17);
            this.CHK_PartialResult.TabIndex = 5;
            this.CHK_PartialResult.Text = "Allow Partial Result";
            this.CHK_PartialResult.UseVisualStyleBackColor = true;
            this.CHK_PartialResult.CheckedChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // GRP_SortingPriority
            // 
            this.GRP_SortingPriority.Controls.Add(this.Btn_Down);
            this.GRP_SortingPriority.Controls.Add(this.Btn_Reverse);
            this.GRP_SortingPriority.Controls.Add(this.BTN_Up);
            this.GRP_SortingPriority.Controls.Add(this.LSTPriority);
            this.GRP_SortingPriority.Location = new System.Drawing.Point(74, 308);
            this.GRP_SortingPriority.Name = "GRP_SortingPriority";
            this.GRP_SortingPriority.Size = new System.Drawing.Size(362, 135);
            this.GRP_SortingPriority.TabIndex = 11;
            this.GRP_SortingPriority.TabStop = false;
            this.GRP_SortingPriority.Text = "Sorting Priority";
            // 
            // Btn_Down
            // 
            this.Btn_Down.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Btn_Down.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(199)))));
            this.Btn_Down.ButtonText = "Down";
            this.Btn_Down.CornerRadius = 0;
            this.Btn_Down.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_Down.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Down.Location = new System.Drawing.Point(261, 90);
            this.Btn_Down.Name = "Btn_Down";
            this.Btn_Down.Size = new System.Drawing.Size(79, 36);
            this.Btn_Down.TabIndex = 92;
            this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
            // 
            // Btn_Reverse
            // 
            this.Btn_Reverse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Btn_Reverse.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(199)))));
            this.Btn_Reverse.ButtonText = "Reverse";
            this.Btn_Reverse.CornerRadius = 0;
            this.Btn_Reverse.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Btn_Reverse.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Reverse.Location = new System.Drawing.Point(261, 52);
            this.Btn_Reverse.Name = "Btn_Reverse";
            this.Btn_Reverse.Size = new System.Drawing.Size(79, 36);
            this.Btn_Reverse.TabIndex = 91;
            this.Btn_Reverse.Click += new System.EventHandler(this.Btn_Reverse_Click);
            // 
            // BTN_Up
            // 
            this.BTN_Up.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.BTN_Up.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(89)))), ((int)(((byte)(199)))));
            this.BTN_Up.ButtonText = "Up";
            this.BTN_Up.CornerRadius = 0;
            this.BTN_Up.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_Up.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Up.Location = new System.Drawing.Point(261, 14);
            this.BTN_Up.Name = "BTN_Up";
            this.BTN_Up.Size = new System.Drawing.Size(79, 36);
            this.BTN_Up.TabIndex = 90;
            this.BTN_Up.Click += new System.EventHandler(this.BTN_Up_Click);
            // 
            // LSTPriority
            // 
            this.LSTPriority.FormattingEnabled = true;
            this.LSTPriority.Location = new System.Drawing.Point(10, 15);
            this.LSTPriority.Name = "LSTPriority";
            this.LSTPriority.Size = new System.Drawing.Size(242, 108);
            this.LSTPriority.TabIndex = 0;
            this.LSTPriority.SelectedIndexChanged += new System.EventHandler(this.SendCmd_SymbologyChangedEvent);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(185, 4);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(167, 20);
            this.label19.TabIndex = 15;
            this.label19.Text = "Symbology Settings";
            // 
            // PNL_SystemSetting
            // 
            this.PNL_SystemSetting.Controls.Add(this.groupBox8);
            this.PNL_SystemSetting.Controls.Add(this.TAB_SystemSetting);
            this.PNL_SystemSetting.Controls.Add(this.label28);
            this.PNL_SystemSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_SystemSetting.Location = new System.Drawing.Point(0, 0);
            this.PNL_SystemSetting.Name = "PNL_SystemSetting";
            this.PNL_SystemSetting.Size = new System.Drawing.Size(572, 533);
            this.PNL_SystemSetting.TabIndex = 41;
            this.PNL_SystemSetting.Visible = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.TXT_DeviceName);
            this.groupBox8.Location = new System.Drawing.Point(306, 30);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(212, 53);
            this.groupBox8.TabIndex = 7;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Device Name";
            // 
            // TXT_DeviceName
            // 
            this.TXT_DeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DeviceName.Location = new System.Drawing.Point(13, 21);
            this.TXT_DeviceName.Multiline = true;
            this.TXT_DeviceName.Name = "TXT_DeviceName";
            this.TXT_DeviceName.Size = new System.Drawing.Size(186, 20);
            this.TXT_DeviceName.TabIndex = 0;
            this.TXT_DeviceName.TextChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // TAB_SystemSetting
            // 
            this.TAB_SystemSetting.Controls.Add(this.tabPage3);
            this.TAB_SystemSetting.Controls.Add(this.tabPage4);
            this.TAB_SystemSetting.Location = new System.Drawing.Point(8, 86);
            this.TAB_SystemSetting.Name = "TAB_SystemSetting";
            this.TAB_SystemSetting.SelectedIndex = 0;
            this.TAB_SystemSetting.Size = new System.Drawing.Size(520, 415);
            this.TAB_SystemSetting.TabIndex = 16;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.GRP_3secondButtonpress);
            this.tabPage3.Controls.Add(this.Chk_DisableReaderButton);
            this.tabPage3.Controls.Add(this.GRP_InputLine1Action);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(512, 389);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Inputs";
            // 
            // GRP_3secondButtonpress
            // 
            this.GRP_3secondButtonpress.Controls.Add(this.Chk_OptimizeBrightness3);
            this.GRP_3secondButtonpress.Controls.Add(this.Chk_TrainCode3);
            this.GRP_3secondButtonpress.Controls.Add(this.Chk_SetMatchString3);
            this.GRP_3secondButtonpress.Location = new System.Drawing.Point(13, 144);
            this.GRP_3secondButtonpress.Name = "GRP_3secondButtonpress";
            this.GRP_3secondButtonpress.Size = new System.Drawing.Size(484, 120);
            this.GRP_3secondButtonpress.TabIndex = 1;
            this.GRP_3secondButtonpress.TabStop = false;
            this.GRP_3secondButtonpress.Text = "3 second button press action";
            // 
            // Chk_OptimizeBrightness3
            // 
            this.Chk_OptimizeBrightness3.AutoSize = true;
            this.Chk_OptimizeBrightness3.Location = new System.Drawing.Point(26, 55);
            this.Chk_OptimizeBrightness3.Name = "Chk_OptimizeBrightness3";
            this.Chk_OptimizeBrightness3.Size = new System.Drawing.Size(118, 17);
            this.Chk_OptimizeBrightness3.TabIndex = 5;
            this.Chk_OptimizeBrightness3.Text = "Optimize Brightness";
            this.Chk_OptimizeBrightness3.UseVisualStyleBackColor = true;
            this.Chk_OptimizeBrightness3.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_TrainCode3
            // 
            this.Chk_TrainCode3.AutoSize = true;
            this.Chk_TrainCode3.Location = new System.Drawing.Point(26, 33);
            this.Chk_TrainCode3.Name = "Chk_TrainCode3";
            this.Chk_TrainCode3.Size = new System.Drawing.Size(78, 17);
            this.Chk_TrainCode3.TabIndex = 4;
            this.Chk_TrainCode3.Text = "Train Code";
            this.Chk_TrainCode3.UseVisualStyleBackColor = true;
            this.Chk_TrainCode3.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_SetMatchString3
            // 
            this.Chk_SetMatchString3.AutoSize = true;
            this.Chk_SetMatchString3.Location = new System.Drawing.Point(26, 78);
            this.Chk_SetMatchString3.Name = "Chk_SetMatchString3";
            this.Chk_SetMatchString3.Size = new System.Drawing.Size(105, 17);
            this.Chk_SetMatchString3.TabIndex = 6;
            this.Chk_SetMatchString3.Text = "Set Match String";
            this.Chk_SetMatchString3.UseVisualStyleBackColor = true;
            this.Chk_SetMatchString3.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_DisableReaderButton
            // 
            this.Chk_DisableReaderButton.AutoSize = true;
            this.Chk_DisableReaderButton.Location = new System.Drawing.Point(13, 287);
            this.Chk_DisableReaderButton.Name = "Chk_DisableReaderButton";
            this.Chk_DisableReaderButton.Size = new System.Drawing.Size(133, 17);
            this.Chk_DisableReaderButton.TabIndex = 3;
            this.Chk_DisableReaderButton.Text = "Disable Reader Button";
            this.Chk_DisableReaderButton.UseVisualStyleBackColor = true;
            this.Chk_DisableReaderButton.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // GRP_InputLine1Action
            // 
            this.GRP_InputLine1Action.Controls.Add(this.Chk_OptimizeBrightness1);
            this.GRP_InputLine1Action.Controls.Add(this.Chk_TrainCode1);
            this.GRP_InputLine1Action.Controls.Add(this.Chk_SetMatchString1);
            this.GRP_InputLine1Action.Location = new System.Drawing.Point(13, 14);
            this.GRP_InputLine1Action.Name = "GRP_InputLine1Action";
            this.GRP_InputLine1Action.Size = new System.Drawing.Size(484, 107);
            this.GRP_InputLine1Action.TabIndex = 0;
            this.GRP_InputLine1Action.TabStop = false;
            this.GRP_InputLine1Action.Text = "Input line 1 action";
            // 
            // Chk_OptimizeBrightness1
            // 
            this.Chk_OptimizeBrightness1.AutoSize = true;
            this.Chk_OptimizeBrightness1.Location = new System.Drawing.Point(26, 49);
            this.Chk_OptimizeBrightness1.Name = "Chk_OptimizeBrightness1";
            this.Chk_OptimizeBrightness1.Size = new System.Drawing.Size(118, 17);
            this.Chk_OptimizeBrightness1.TabIndex = 1;
            this.Chk_OptimizeBrightness1.Text = "Optimize Brightness";
            this.Chk_OptimizeBrightness1.UseVisualStyleBackColor = true;
            this.Chk_OptimizeBrightness1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_TrainCode1
            // 
            this.Chk_TrainCode1.AutoSize = true;
            this.Chk_TrainCode1.Location = new System.Drawing.Point(26, 27);
            this.Chk_TrainCode1.Name = "Chk_TrainCode1";
            this.Chk_TrainCode1.Size = new System.Drawing.Size(78, 17);
            this.Chk_TrainCode1.TabIndex = 0;
            this.Chk_TrainCode1.Text = "Train Code";
            this.Chk_TrainCode1.UseVisualStyleBackColor = true;
            this.Chk_TrainCode1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_SetMatchString1
            // 
            this.Chk_SetMatchString1.AutoSize = true;
            this.Chk_SetMatchString1.Location = new System.Drawing.Point(26, 72);
            this.Chk_SetMatchString1.Name = "Chk_SetMatchString1";
            this.Chk_SetMatchString1.Size = new System.Drawing.Size(105, 17);
            this.Chk_SetMatchString1.TabIndex = 3;
            this.Chk_SetMatchString1.Text = "Set Match String";
            this.Chk_SetMatchString1.UseVisualStyleBackColor = true;
            this.Chk_SetMatchString1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Controls.Add(this.label39);
            this.tabPage4.Controls.Add(this.label38);
            this.tabPage4.Controls.Add(this.label37);
            this.tabPage4.Controls.Add(this.label36);
            this.tabPage4.Controls.Add(this.label35);
            this.tabPage4.Controls.Add(this.label34);
            this.tabPage4.Controls.Add(this.label33);
            this.tabPage4.Controls.Add(this.label32);
            this.tabPage4.Controls.Add(this.label31);
            this.tabPage4.Controls.Add(this.panel5);
            this.tabPage4.Controls.Add(this.panel4);
            this.tabPage4.Controls.Add(this.label27);
            this.tabPage4.Controls.Add(this.label26);
            this.tabPage4.Controls.Add(this.label25);
            this.tabPage4.Controls.Add(this.label24);
            this.tabPage4.Controls.Add(this.TXT_NoReadOutput);
            this.tabPage4.Controls.Add(this.CHk_EnableBeeper);
            this.tabPage4.Controls.Add(this.checkBox22);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(512, 389);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Outputs";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(27, 275);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(83, 13);
            this.label39.TabIndex = 19;
            this.label39.Text = "Pulse Width[ms]";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(27, 254);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(39, 13);
            this.label38.TabIndex = 18;
            this.label38.Text = "Closed";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(27, 235);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(33, 13);
            this.label37.TabIndex = 17;
            this.label37.Text = "Open";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(24, 191);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(80, 13);
            this.label36.TabIndex = 16;
            this.label36.Text = "Buffer Overflow";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(25, 167);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(81, 13);
            this.label35.TabIndex = 15;
            this.label35.Text = "Trigger Overrun";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(24, 143);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(87, 13);
            this.label34.TabIndex = 14;
            this.label34.Text = "Validation Failure";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(24, 119);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(50, 13);
            this.label33.TabIndex = 13;
            this.label33.Text = "No Read";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(24, 95);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(33, 13);
            this.label32.TabIndex = 12;
            this.label32.Text = "Read";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(24, 39);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(81, 32);
            this.label31.TabIndex = 11;
            this.label31.Text = "Reserved for Ext. Illumination";
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.PNLActionLine1);
            this.panel5.Controls.Add(this.Chk_Ouput1);
            this.panel5.Controls.Add(this.label30);
            this.panel5.Location = new System.Drawing.Point(159, 8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(43, 287);
            this.panel5.TabIndex = 10;
            // 
            // PNLActionLine1
            // 
            this.PNLActionLine1.Controls.Add(this.OPT_ActionClosed1);
            this.PNLActionLine1.Controls.Add(this.Chk_EventRead1);
            this.PNLActionLine1.Controls.Add(this.TXT_Pulsewidth1);
            this.PNLActionLine1.Controls.Add(this.Chk_EventNoRead1);
            this.PNLActionLine1.Controls.Add(this.OPT_ActionOpen1);
            this.PNLActionLine1.Controls.Add(this.Chk_EventValidationFailure1);
            this.PNLActionLine1.Controls.Add(this.Chk_BufferOverflow1);
            this.PNLActionLine1.Controls.Add(this.Chk_TriggerOverrun1);
            this.PNLActionLine1.Location = new System.Drawing.Point(1, 81);
            this.PNLActionLine1.Name = "PNLActionLine1";
            this.PNLActionLine1.Size = new System.Drawing.Size(38, 206);
            this.PNLActionLine1.TabIndex = 20;
            // 
            // OPT_ActionClosed1
            // 
            this.OPT_ActionClosed1.AutoSize = true;
            this.OPT_ActionClosed1.Location = new System.Drawing.Point(10, 164);
            this.OPT_ActionClosed1.Name = "OPT_ActionClosed1";
            this.OPT_ActionClosed1.Size = new System.Drawing.Size(14, 13);
            this.OPT_ActionClosed1.TabIndex = 24;
            this.OPT_ActionClosed1.TabStop = true;
            this.OPT_ActionClosed1.UseVisualStyleBackColor = true;
            this.OPT_ActionClosed1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_EventRead1
            // 
            this.Chk_EventRead1.AutoSize = true;
            this.Chk_EventRead1.Location = new System.Drawing.Point(13, 3);
            this.Chk_EventRead1.Name = "Chk_EventRead1";
            this.Chk_EventRead1.Size = new System.Drawing.Size(15, 14);
            this.Chk_EventRead1.TabIndex = 17;
            this.Chk_EventRead1.UseVisualStyleBackColor = true;
            this.Chk_EventRead1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // TXT_Pulsewidth1
            // 
            this.TXT_Pulsewidth1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Pulsewidth1.Location = new System.Drawing.Point(2, 181);
            this.TXT_Pulsewidth1.Name = "TXT_Pulsewidth1";
            this.TXT_Pulsewidth1.Size = new System.Drawing.Size(34, 22);
            this.TXT_Pulsewidth1.TabIndex = 21;
            this.TXT_Pulsewidth1.TextChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_EventNoRead1
            // 
            this.Chk_EventNoRead1.AutoSize = true;
            this.Chk_EventNoRead1.Location = new System.Drawing.Point(13, 27);
            this.Chk_EventNoRead1.Name = "Chk_EventNoRead1";
            this.Chk_EventNoRead1.Size = new System.Drawing.Size(15, 14);
            this.Chk_EventNoRead1.TabIndex = 18;
            this.Chk_EventNoRead1.UseVisualStyleBackColor = true;
            this.Chk_EventNoRead1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // OPT_ActionOpen1
            // 
            this.OPT_ActionOpen1.AutoSize = true;
            this.OPT_ActionOpen1.Location = new System.Drawing.Point(10, 143);
            this.OPT_ActionOpen1.Name = "OPT_ActionOpen1";
            this.OPT_ActionOpen1.Size = new System.Drawing.Size(14, 13);
            this.OPT_ActionOpen1.TabIndex = 23;
            this.OPT_ActionOpen1.TabStop = true;
            this.OPT_ActionOpen1.UseVisualStyleBackColor = true;
            this.OPT_ActionOpen1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_EventValidationFailure1
            // 
            this.Chk_EventValidationFailure1.AutoSize = true;
            this.Chk_EventValidationFailure1.Location = new System.Drawing.Point(13, 51);
            this.Chk_EventValidationFailure1.Name = "Chk_EventValidationFailure1";
            this.Chk_EventValidationFailure1.Size = new System.Drawing.Size(15, 14);
            this.Chk_EventValidationFailure1.TabIndex = 19;
            this.Chk_EventValidationFailure1.UseVisualStyleBackColor = true;
            this.Chk_EventValidationFailure1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_BufferOverflow1
            // 
            this.Chk_BufferOverflow1.AutoSize = true;
            this.Chk_BufferOverflow1.Location = new System.Drawing.Point(13, 99);
            this.Chk_BufferOverflow1.Name = "Chk_BufferOverflow1";
            this.Chk_BufferOverflow1.Size = new System.Drawing.Size(15, 14);
            this.Chk_BufferOverflow1.TabIndex = 21;
            this.Chk_BufferOverflow1.UseVisualStyleBackColor = true;
            this.Chk_BufferOverflow1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_TriggerOverrun1
            // 
            this.Chk_TriggerOverrun1.AutoSize = true;
            this.Chk_TriggerOverrun1.Location = new System.Drawing.Point(13, 75);
            this.Chk_TriggerOverrun1.Name = "Chk_TriggerOverrun1";
            this.Chk_TriggerOverrun1.Size = new System.Drawing.Size(15, 14);
            this.Chk_TriggerOverrun1.TabIndex = 20;
            this.Chk_TriggerOverrun1.UseVisualStyleBackColor = true;
            this.Chk_TriggerOverrun1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_Ouput1
            // 
            this.Chk_Ouput1.AutoSize = true;
            this.Chk_Ouput1.Location = new System.Drawing.Point(13, 29);
            this.Chk_Ouput1.Name = "Chk_Ouput1";
            this.Chk_Ouput1.Size = new System.Drawing.Size(15, 14);
            this.Chk_Ouput1.TabIndex = 12;
            this.Chk_Ouput1.UseVisualStyleBackColor = true;
            this.Chk_Ouput1.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(15, 6);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(13, 13);
            this.label30.TabIndex = 12;
            this.label30.Text = "1";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.PNLActionLine0);
            this.panel4.Controls.Add(this.Chkoutput0);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Location = new System.Drawing.Point(117, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(43, 287);
            this.panel4.TabIndex = 9;
            // 
            // PNLActionLine0
            // 
            this.PNLActionLine0.Controls.Add(this.OPT_ActionClosed0);
            this.PNLActionLine0.Controls.Add(this.Chk_EventRead0);
            this.PNLActionLine0.Controls.Add(this.OPT_ActionOpen0);
            this.PNLActionLine0.Controls.Add(this.Chk_EventNoRead0);
            this.PNLActionLine0.Controls.Add(this.TXT_Pulsewidth0);
            this.PNLActionLine0.Controls.Add(this.Chk_EventValidationFailure0);
            this.PNLActionLine0.Controls.Add(this.Chk_BufferOverflow0);
            this.PNLActionLine0.Controls.Add(this.Chk_TriggerOverrun0);
            this.PNLActionLine0.Location = new System.Drawing.Point(1, 81);
            this.PNLActionLine0.Name = "PNLActionLine0";
            this.PNLActionLine0.Size = new System.Drawing.Size(38, 206);
            this.PNLActionLine0.TabIndex = 25;
            // 
            // OPT_ActionClosed0
            // 
            this.OPT_ActionClosed0.AutoSize = true;
            this.OPT_ActionClosed0.Location = new System.Drawing.Point(12, 164);
            this.OPT_ActionClosed0.Name = "OPT_ActionClosed0";
            this.OPT_ActionClosed0.Size = new System.Drawing.Size(14, 13);
            this.OPT_ActionClosed0.TabIndex = 22;
            this.OPT_ActionClosed0.TabStop = true;
            this.OPT_ActionClosed0.UseVisualStyleBackColor = true;
            this.OPT_ActionClosed0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_EventRead0
            // 
            this.Chk_EventRead0.AutoSize = true;
            this.Chk_EventRead0.Location = new System.Drawing.Point(12, 3);
            this.Chk_EventRead0.Name = "Chk_EventRead0";
            this.Chk_EventRead0.Size = new System.Drawing.Size(15, 14);
            this.Chk_EventRead0.TabIndex = 12;
            this.Chk_EventRead0.UseVisualStyleBackColor = true;
            this.Chk_EventRead0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // OPT_ActionOpen0
            // 
            this.OPT_ActionOpen0.AutoSize = true;
            this.OPT_ActionOpen0.Location = new System.Drawing.Point(12, 143);
            this.OPT_ActionOpen0.Name = "OPT_ActionOpen0";
            this.OPT_ActionOpen0.Size = new System.Drawing.Size(14, 13);
            this.OPT_ActionOpen0.TabIndex = 21;
            this.OPT_ActionOpen0.TabStop = true;
            this.OPT_ActionOpen0.UseVisualStyleBackColor = true;
            this.OPT_ActionOpen0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_EventNoRead0
            // 
            this.Chk_EventNoRead0.AutoSize = true;
            this.Chk_EventNoRead0.Location = new System.Drawing.Point(12, 27);
            this.Chk_EventNoRead0.Name = "Chk_EventNoRead0";
            this.Chk_EventNoRead0.Size = new System.Drawing.Size(15, 14);
            this.Chk_EventNoRead0.TabIndex = 13;
            this.Chk_EventNoRead0.UseVisualStyleBackColor = true;
            this.Chk_EventNoRead0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // TXT_Pulsewidth0
            // 
            this.TXT_Pulsewidth0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Pulsewidth0.Location = new System.Drawing.Point(2, 181);
            this.TXT_Pulsewidth0.Name = "TXT_Pulsewidth0";
            this.TXT_Pulsewidth0.Size = new System.Drawing.Size(34, 22);
            this.TXT_Pulsewidth0.TabIndex = 20;
            this.TXT_Pulsewidth0.TextChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_EventValidationFailure0
            // 
            this.Chk_EventValidationFailure0.AutoSize = true;
            this.Chk_EventValidationFailure0.Location = new System.Drawing.Point(12, 51);
            this.Chk_EventValidationFailure0.Name = "Chk_EventValidationFailure0";
            this.Chk_EventValidationFailure0.Size = new System.Drawing.Size(15, 14);
            this.Chk_EventValidationFailure0.TabIndex = 14;
            this.Chk_EventValidationFailure0.UseVisualStyleBackColor = true;
            this.Chk_EventValidationFailure0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_BufferOverflow0
            // 
            this.Chk_BufferOverflow0.AutoSize = true;
            this.Chk_BufferOverflow0.Location = new System.Drawing.Point(12, 99);
            this.Chk_BufferOverflow0.Name = "Chk_BufferOverflow0";
            this.Chk_BufferOverflow0.Size = new System.Drawing.Size(15, 14);
            this.Chk_BufferOverflow0.TabIndex = 16;
            this.Chk_BufferOverflow0.UseVisualStyleBackColor = true;
            this.Chk_BufferOverflow0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chk_TriggerOverrun0
            // 
            this.Chk_TriggerOverrun0.AutoSize = true;
            this.Chk_TriggerOverrun0.Location = new System.Drawing.Point(12, 75);
            this.Chk_TriggerOverrun0.Name = "Chk_TriggerOverrun0";
            this.Chk_TriggerOverrun0.Size = new System.Drawing.Size(15, 14);
            this.Chk_TriggerOverrun0.TabIndex = 15;
            this.Chk_TriggerOverrun0.UseVisualStyleBackColor = true;
            this.Chk_TriggerOverrun0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // Chkoutput0
            // 
            this.Chkoutput0.AutoSize = true;
            this.Chkoutput0.Location = new System.Drawing.Point(14, 29);
            this.Chkoutput0.Name = "Chkoutput0";
            this.Chkoutput0.Size = new System.Drawing.Size(15, 14);
            this.Chkoutput0.TabIndex = 11;
            this.Chkoutput0.UseVisualStyleBackColor = true;
            this.Chkoutput0.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(15, 6);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 13);
            this.label29.TabIndex = 11;
            this.label29.Text = "0";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(27, 215);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(43, 13);
            this.label27.TabIndex = 8;
            this.label27.Text = "Action";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(24, 73);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 13);
            this.label26.TabIndex = 7;
            this.label26.Text = "Events";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(24, 17);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 13);
            this.label25.TabIndex = 6;
            this.label25.Text = " Output";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(27, 337);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(118, 13);
            this.label24.TabIndex = 5;
            this.label24.Text = " No-Read Output String";
            // 
            // TXT_NoReadOutput
            // 
            this.TXT_NoReadOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_NoReadOutput.Location = new System.Drawing.Point(27, 360);
            this.TXT_NoReadOutput.Multiline = true;
            this.TXT_NoReadOutput.Name = "TXT_NoReadOutput";
            this.TXT_NoReadOutput.Size = new System.Drawing.Size(186, 20);
            this.TXT_NoReadOutput.TabIndex = 1;
            this.TXT_NoReadOutput.TextChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // CHk_EnableBeeper
            // 
            this.CHk_EnableBeeper.AutoSize = true;
            this.CHk_EnableBeeper.Location = new System.Drawing.Point(27, 313);
            this.CHk_EnableBeeper.Name = "CHk_EnableBeeper";
            this.CHk_EnableBeeper.Size = new System.Drawing.Size(174, 17);
            this.CHk_EnableBeeper.TabIndex = 4;
            this.CHk_EnableBeeper.Text = "Enable Beeper On  Good Read";
            this.CHk_EnableBeeper.UseVisualStyleBackColor = true;
            this.CHk_EnableBeeper.CheckedChanged += new System.EventHandler(this.SendCmd_SystemSettingChangedEvent);
            // 
            // checkBox22
            // 
            this.checkBox22.AutoSize = true;
            this.checkBox22.Enabled = false;
            this.checkBox22.Location = new System.Drawing.Point(171, 402);
            this.checkBox22.Name = "checkBox22";
            this.checkBox22.Size = new System.Drawing.Size(116, 17);
            this.checkBox22.TabIndex = 0;
            this.checkBox22.Text = "Allow Partial Result";
            this.checkBox22.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(216, 4);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(140, 20);
            this.label28.TabIndex = 15;
            this.label28.Text = "System Settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Location = new System.Drawing.Point(214, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(223, 68);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Algorithm";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 41);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ID Quick";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "ID Max";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(70, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "QR Code";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(24, 27);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Data Matrix";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // PNl_Main
            // 
            this.PNl_Main.Controls.Add(this.PNL_SystemSetting);
            this.PNl_Main.Controls.Add(this.PNL_LightCameraSetting);
            this.PNl_Main.Controls.Add(this.Pnl_SymbologySetting);
            this.PNl_Main.Controls.Add(this.PNL_ConnectToReader);
            this.PNl_Main.Controls.Add(this.Pnl_ResultDisplay);
            this.PNl_Main.Location = new System.Drawing.Point(233, 1);
            this.PNl_Main.Name = "PNl_Main";
            this.PNl_Main.Size = new System.Drawing.Size(572, 533);
            this.PNl_Main.TabIndex = 42;
            // 
            // BTn_Close
            // 
            this.BTn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BTn_Close.BaseColor = System.Drawing.Color.White;
            this.BTn_Close.ButtonText = "Close";
            this.BTn_Close.CornerRadius = 0;
            this.BTn_Close.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTn_Close.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTn_Close.Location = new System.Drawing.Point(9, 495);
            this.BTn_Close.Name = "BTn_Close";
            this.BTn_Close.Size = new System.Drawing.Size(215, 39);
            this.BTn_Close.TabIndex = 17;
            this.BTn_Close.Click += new System.EventHandler(this.BTn_Close_Click);
            // 
            // BTN_ConnectToReader
            // 
            this.BTN_ConnectToReader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BTN_ConnectToReader.BaseColor = System.Drawing.Color.White;
            this.BTN_ConnectToReader.ButtonText = "Connect To Reader";
            this.BTN_ConnectToReader.CornerRadius = 0;
            this.BTN_ConnectToReader.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BTN_ConnectToReader.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ConnectToReader.Location = new System.Drawing.Point(12, 12);
            this.BTN_ConnectToReader.Name = "BTN_ConnectToReader";
            this.BTN_ConnectToReader.Size = new System.Drawing.Size(215, 39);
            this.BTN_ConnectToReader.TabIndex = 16;
            this.BTN_ConnectToReader.Click += new System.EventHandler(this.BTN_ConnectToReader_Click);
            // 
            // FrmDataManManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 537);
            this.Controls.Add(this.PNl_Main);
            this.Controls.Add(this.BTn_Close);
            this.Controls.Add(this.BTN_ConnectToReader);
            this.Controls.Add(this.Pnl_Botton);
            this.Name = "FrmDataManManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDataManReader";
            this.PNL_ConnectToReader.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Grp_SendDMCCCmd.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.connectGroupBox.ResumeLayout(false);
            this.Pnl_Botton.ResumeLayout(false);
            this.Pnl_ResultDisplay.ResumeLayout(false);
            this.Pnl_ResultDisplay.PerformLayout();
            this.responseGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.imageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lastImagePictureBox)).EndInit();
            this.PNL_LightCameraSetting.ResumeLayout(false);
            this.PNL_LightCameraSetting.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.Pnl_MaxExposure.ResumeLayout(false);
            this.Pnl_Exposure.ResumeLayout(false);
            this.Pnl_ManualExposure.ResumeLayout(false);
            this.Pnl_ManualExposure.PerformLayout();
            this.Grp_ManualExp.ResumeLayout(false);
            this.Grp_ManualExp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_ManualExposure)).EndInit();
            this.Pnl_AutomaticExposure.ResumeLayout(false);
            this.Pnl_AutomaticExposure.PerformLayout();
            this.Grp_AutomaticExp.ResumeLayout(false);
            this.Grp_AutomaticExp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_TargetBrightness)).EndInit();
            this.Pnl_Interval.ResumeLayout(false);
            this.Pnl_Interval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_Interval)).EndInit();
            this.Pnl_Timeout.ResumeLayout(false);
            this.Pnl_Timeout.PerformLayout();
            this.Pnl_SymbologySetting.ResumeLayout(false);
            this.Pnl_SymbologySetting.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.GRP_Postal.ResumeLayout(false);
            this.GRP_Postal.PerformLayout();
            this.GRP_StateCode.ResumeLayout(false);
            this.GRP_StateCode.PerformLayout();
            this.GRP_Stacked.ResumeLayout(false);
            this.GRP_Stacked.PerformLayout();
            this.GRP_1D.ResumeLayout(false);
            this.GRP_1D.PerformLayout();
            this.GRP_2D.ResumeLayout(false);
            this.GRP_2D.PerformLayout();
            this.GRP_Algorithm.ResumeLayout(false);
            this.GRP_Algorithm.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.PNL_SETNOOFCode.ResumeLayout(false);
            this.PNL_SETNOOFCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Num_NoOfCodes)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_1DStackedPostalNoOfCode)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_QRNoOfCode)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUM_DatamatrixNoOfCode)).EndInit();
            this.GRP_SortingPriority.ResumeLayout(false);
            this.PNL_SystemSetting.ResumeLayout(false);
            this.PNL_SystemSetting.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.TAB_SystemSetting.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.GRP_3secondButtonpress.ResumeLayout(false);
            this.GRP_3secondButtonpress.PerformLayout();
            this.GRP_InputLine1Action.ResumeLayout(false);
            this.GRP_InputLine1Action.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.PNLActionLine1.ResumeLayout(false);
            this.PNLActionLine1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.PNLActionLine0.ResumeLayout(false);
            this.PNLActionLine0.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.PNl_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PNL_ConnectToReader;
        private System.Windows.Forms.Panel Pnl_Botton;
        private System.Windows.Forms.GroupBox connectGroupBox;
        private System.Windows.Forms.ListBox systemListBox;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label connectionStatusLabel;
        private System.Windows.Forms.Button loadConfigButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button detectSystemsButton;
        private System.Windows.Forms.Panel Pnl_ResultDisplay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox liveDisplayCheckBox;
        private System.Windows.Forms.GroupBox imageGroupBox;
        private System.Windows.Forms.PictureBox lastImagePictureBox;
        private Red.Controls.Buttons.RedGlowButton BTN_ConnectToReader;
        private Red.Controls.Buttons.RedGlowButton Btn_ResultDisplay;
        private System.Windows.Forms.GroupBox responseGroupBox;
        private System.Windows.Forms.ListBox LST_RESULT;
        private System.Windows.Forms.GroupBox Grp_SendDMCCCmd;
        private System.Windows.Forms.Button SendCommandButton;
        private System.Windows.Forms.ComboBox commandComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label responseLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Red.Controls.Buttons.RedGlowButton BTn_Close;
        private Red.Controls.Buttons.RedGlowButton Btn_LightAndCameraSetting;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button setHeartBeatIntButton;
        private System.Windows.Forms.ComboBox heartbeatIntervalComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PNL_LightCameraSetting;
        private System.Windows.Forms.ComboBox CMB_TRIGGERTYPE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox Grp_AutomaticExp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton Opt_AutomaticExposure;
        private System.Windows.Forms.TextBox TXT_AutomaticExpVal;
        private System.Windows.Forms.TrackBar Track_TargetBrightness;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox Cmb_MaximumExposure;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TXT_Timeout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TXT_Interval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TrackBar Track_Interval;
        private System.Windows.Forms.Panel Pnl_Timeout;
        private System.Windows.Forms.Panel Pnl_Interval;
        private System.Windows.Forms.Panel Pnl_Exposure;
        private System.Windows.Forms.GroupBox Grp_ManualExp;
        private System.Windows.Forms.ComboBox CMB_Exposure;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TXT_ManualExposure;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar Track_ManualExposure;
        private System.Windows.Forms.RadioButton Opt_ManualExposure;
        private System.Windows.Forms.Panel Pnl_MaxExposure;
        private System.Windows.Forms.Panel Pnl_ManualExposure;
        private System.Windows.Forms.Panel Pnl_AutomaticExposure;
        private Red.Controls.Buttons.RedGlowButton Btn_SymbologySetting;
        private System.Windows.Forms.Panel Pnl_SymbologySetting;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox GRP_1D;
        private System.Windows.Forms.CheckBox CHK_Code93;
        private System.Windows.Forms.CheckBox CHK_UPCEAN;
        private System.Windows.Forms.CheckBox CHK_Pharmacode;
        private System.Windows.Forms.CheckBox CHK_Interleaved2of5;
        private System.Windows.Forms.CheckBox CHK_Code39;
        private System.Windows.Forms.CheckBox CHK_Code128;
        private System.Windows.Forms.GroupBox GRP_2D;
        private System.Windows.Forms.GroupBox GRP_Algorithm;
        private System.Windows.Forms.RadioButton OPT_IDQuick;
        private System.Windows.Forms.RadioButton OPT_IDMAX;
        private System.Windows.Forms.CheckBox CHK_QRCode;
        private System.Windows.Forms.CheckBox CHK_Datamatrix;
        private System.Windows.Forms.GroupBox GRP_Postal;
        private System.Windows.Forms.GroupBox GRP_StateCode;
        private System.Windows.Forms.CheckBox CHK_IntelligentMailBarcode;
        private System.Windows.Forms.CheckBox CHK_UPC;
        private System.Windows.Forms.CheckBox CHK_AustaliaPost;
        private System.Windows.Forms.CheckBox CHK_JapanPost;
        private System.Windows.Forms.CheckBox CHK_Planet;
        private System.Windows.Forms.CheckBox CHK_Postnet;
        private System.Windows.Forms.GroupBox GRP_Stacked;
        private System.Windows.Forms.CheckBox CHK_EANUCCComposite;
        private System.Windows.Forms.CheckBox CHK_Databar;
        private System.Windows.Forms.CheckBox CHK_MicroPDF417;
        private System.Windows.Forms.CheckBox CHK_PDF417;
        private System.Windows.Forms.CheckBox CHK_Codebar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox GRP_SortingPriority;
        private System.Windows.Forms.ListBox LSTPriority;
        private Red.Controls.Buttons.RedGlowButton BTN_Up;
        private Red.Controls.Buttons.RedGlowButton Btn_Down;
        private Red.Controls.Buttons.RedGlowButton Btn_Reverse;
        private System.Windows.Forms.Label label18;
        private Red.Controls.Buttons.RedGlowButton Btn_SystemSettings;
        private System.Windows.Forms.Panel PNL_SystemSetting;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TabControl TAB_SystemSetting;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox Chk_DisableReaderButton;
        private System.Windows.Forms.GroupBox GRP_3secondButtonpress;
        private System.Windows.Forms.CheckBox Chk_SetMatchString1;
        private System.Windows.Forms.GroupBox GRP_InputLine1Action;
        private System.Windows.Forms.CheckBox Chk_OptimizeBrightness1;
        private System.Windows.Forms.CheckBox Chk_TrainCode1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox checkBox22;
        private System.Windows.Forms.CheckBox Chk_OptimizeBrightness3;
        private System.Windows.Forms.CheckBox Chk_TrainCode3;
        private System.Windows.Forms.CheckBox Chk_SetMatchString3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox TXT_DeviceName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox TXT_NoReadOutput;
        private System.Windows.Forms.CheckBox CHk_EnableBeeper;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.CheckBox Chk_Ouput1;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox Chkoutput0;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.CheckBox Chk_BufferOverflow1;
        private System.Windows.Forms.CheckBox Chk_TriggerOverrun1;
        private System.Windows.Forms.CheckBox Chk_EventValidationFailure1;
        private System.Windows.Forms.CheckBox Chk_EventRead1;
        private System.Windows.Forms.CheckBox Chk_EventNoRead1;
        private System.Windows.Forms.CheckBox Chk_BufferOverflow0;
        private System.Windows.Forms.CheckBox Chk_TriggerOverrun0;
        private System.Windows.Forms.CheckBox Chk_EventValidationFailure0;
        private System.Windows.Forms.CheckBox Chk_EventNoRead0;
        private System.Windows.Forms.CheckBox Chk_EventRead0;
        private System.Windows.Forms.RadioButton OPT_ActionOpen0;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox TXT_Pulsewidth1;
        private System.Windows.Forms.TextBox TXT_Pulsewidth0;
        private System.Windows.Forms.RadioButton OPT_ActionClosed1;
        private System.Windows.Forms.RadioButton OPT_ActionOpen1;
        private System.Windows.Forms.RadioButton OPT_ActionClosed0;
        private System.Windows.Forms.Panel PNl_Main;
        private System.Windows.Forms.Panel PNL_SETNOOFCode;
        private System.Windows.Forms.NumericUpDown Num_NoOfCodes;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.NumericUpDown NUM_1DStackedPostalNoOfCode;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown NUM_QRNoOfCode;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown NUM_DatamatrixNoOfCode;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox CHK_PartialResult;
        private System.Windows.Forms.Panel PNLActionLine1;
        private System.Windows.Forms.Panel PNLActionLine0;
    }
}