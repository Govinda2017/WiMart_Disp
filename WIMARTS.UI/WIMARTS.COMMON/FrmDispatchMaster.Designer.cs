namespace WIMARTS.COMMON
{
    partial class FrmDispatchMaster
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.redGridControl1 = new RedRapidUI.RedGridControl();
            this.PAN_RecordInfo = new System.Windows.Forms.Panel();
            this.splitDetails = new System.Windows.Forms.SplitContainer();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtpDispatchDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.numGoodQty = new System.Windows.Forms.NumericUpDown();
            this.numBadQty = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtGDN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.txtDriverName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDispDetails = new System.Windows.Forms.DataGridView();
            this.DDDispDetailsIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDSrNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDProductCodeColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.DDProductNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDProductGivenQtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDProductMinQtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDProductMaxQtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDProductDispatchedQtyColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DDProductRemarksColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoadDL = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.numMaximumQty = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numMinimumQty = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDetailsRemarks = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numDetailsQty = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbProductName = new System.Windows.Forms.ComboBox();
            this.cmbProductCode = new System.Windows.Forms.ComboBox();
            this.btnDeleteDetails = new System.Windows.Forms.Button();
            this.btnAddDetails = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.redCRUDAS1 = new RedRapidUI.RedCRUDAS();
            this.cmbTransporter = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PAN_RecordInfo.SuspendLayout();
            this.splitDetails.Panel1.SuspendLayout();
            this.splitDetails.Panel2.SuspendLayout();
            this.splitDetails.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoodQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBadQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispDetails)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDetailsQty)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.redGridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PAN_RecordInfo);
            this.splitContainer1.Size = new System.Drawing.Size(1026, 556);
            this.splitContainer1.SplitterDistance = 210;
            this.splitContainer1.TabIndex = 0;
            // 
            // redGridControl1
            // 
            this.redGridControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.redGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redGridControl1.Location = new System.Drawing.Point(0, 0);
            this.redGridControl1.Name = "redGridControl1";
            this.redGridControl1.Size = new System.Drawing.Size(210, 556);
            this.redGridControl1.TabIndex = 0;
            // 
            // PAN_RecordInfo
            // 
            this.PAN_RecordInfo.Controls.Add(this.splitDetails);
            this.PAN_RecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAN_RecordInfo.Location = new System.Drawing.Point(0, 0);
            this.PAN_RecordInfo.Name = "PAN_RecordInfo";
            this.PAN_RecordInfo.Size = new System.Drawing.Size(812, 556);
            this.PAN_RecordInfo.TabIndex = 1;
            // 
            // splitDetails
            // 
            this.splitDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitDetails.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitDetails.Location = new System.Drawing.Point(0, 0);
            this.splitDetails.Name = "splitDetails";
            // 
            // splitDetails.Panel1
            // 
            this.splitDetails.Panel1.Controls.Add(this.cmbTransporter);
            this.splitDetails.Panel1.Controls.Add(this.label18);
            this.splitDetails.Panel1.Controls.Add(this.cmbCustomer);
            this.splitDetails.Panel1.Controls.Add(this.label15);
            this.splitDetails.Panel1.Controls.Add(this.dtpDispatchDate);
            this.splitDetails.Panel1.Controls.Add(this.label11);
            this.splitDetails.Panel1.Controls.Add(this.pnlStatus);
            this.splitDetails.Panel1.Controls.Add(this.label4);
            this.splitDetails.Panel1.Controls.Add(this.txtRemarks);
            this.splitDetails.Panel1.Controls.Add(this.txtGDN);
            this.splitDetails.Panel1.Controls.Add(this.label3);
            this.splitDetails.Panel1.Controls.Add(this.txtVehicleNo);
            this.splitDetails.Panel1.Controls.Add(this.txtDriverName);
            this.splitDetails.Panel1.Controls.Add(this.label1);
            this.splitDetails.Panel1.Controls.Add(this.label2);
            // 
            // splitDetails.Panel2
            // 
            this.splitDetails.Panel2.Controls.Add(this.dgvDispDetails);
            this.splitDetails.Panel2.Controls.Add(this.txtTotalQty);
            this.splitDetails.Panel2.Controls.Add(this.panel1);
            this.splitDetails.Panel2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitDetails.Size = new System.Drawing.Size(812, 556);
            this.splitDetails.SplitterDistance = 371;
            this.splitDetails.TabIndex = 0;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCustomer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Items.AddRange(new object[] {
            "CREATED",
            "RUNNING",
            "ABONDEN",
            "COMPLETED"});
            this.cmbCustomer.Location = new System.Drawing.Point(129, 47);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(226, 27);
            this.cmbCustomer.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 50);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 19);
            this.label15.TabIndex = 30;
            this.label15.Text = "Customer";
            // 
            // dtpDispatchDate
            // 
            this.dtpDispatchDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDispatchDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDispatchDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDispatchDate.Location = new System.Drawing.Point(129, 174);
            this.dtpDispatchDate.Name = "dtpDispatchDate";
            this.dtpDispatchDate.Size = new System.Drawing.Size(121, 27);
            this.dtpDispatchDate.TabIndex = 4;
            this.dtpDispatchDate.Value = new System.DateTime(2015, 8, 19, 10, 1, 23, 0);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 19);
            this.label11.TabIndex = 28;
            this.label11.Text = "Dispatch Date";
            // 
            // pnlStatus
            // 
            this.pnlStatus.Controls.Add(this.dtpEndDate);
            this.pnlStatus.Controls.Add(this.label17);
            this.pnlStatus.Controls.Add(this.dtpStartDate);
            this.pnlStatus.Controls.Add(this.label16);
            this.pnlStatus.Controls.Add(this.cmbStatus);
            this.pnlStatus.Controls.Add(this.label12);
            this.pnlStatus.Controls.Add(this.numGoodQty);
            this.pnlStatus.Controls.Add(this.numBadQty);
            this.pnlStatus.Controls.Add(this.label10);
            this.pnlStatus.Controls.Add(this.label9);
            this.pnlStatus.Location = new System.Drawing.Point(5, 321);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(364, 192);
            this.pnlStatus.TabIndex = 27;
            this.pnlStatus.Visible = false;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MM-yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(128, 75);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(124, 27);
            this.dtpEndDate.TabIndex = 33;
            this.dtpEndDate.TabStop = false;
            this.dtpEndDate.Value = new System.DateTime(2015, 8, 19, 10, 1, 23, 0);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 79);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 19);
            this.label17.TabIndex = 32;
            this.label17.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MM-yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(128, 43);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(124, 27);
            this.dtpStartDate.TabIndex = 31;
            this.dtpStartDate.TabStop = false;
            this.dtpStartDate.Value = new System.DateTime(2015, 8, 19, 10, 1, 23, 0);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(12, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 19);
            this.label16.TabIndex = 30;
            this.label16.Text = "Start Date";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "CREATED",
            "RUNNING",
            "ABONDEN",
            "COMPLETED"});
            this.cmbStatus.Location = new System.Drawing.Point(128, 11);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(226, 27);
            this.cmbStatus.TabIndex = 27;
            this.cmbStatus.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 19);
            this.label12.TabIndex = 26;
            this.label12.Text = "Status";
            // 
            // numGoodQty
            // 
            this.numGoodQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numGoodQty.Location = new System.Drawing.Point(128, 107);
            this.numGoodQty.Name = "numGoodQty";
            this.numGoodQty.Size = new System.Drawing.Size(124, 27);
            this.numGoodQty.TabIndex = 19;
            this.numGoodQty.TabStop = false;
            // 
            // numBadQty
            // 
            this.numBadQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numBadQty.Location = new System.Drawing.Point(128, 139);
            this.numBadQty.Name = "numBadQty";
            this.numBadQty.Size = new System.Drawing.Size(124, 27);
            this.numBadQty.TabIndex = 20;
            this.numBadQty.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 19);
            this.label10.TabIndex = 24;
            this.label10.Text = "Rejected Qty";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 19);
            this.label9.TabIndex = 23;
            this.label9.Text = "Accepted Qty";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 18;
            this.label4.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(129, 205);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.ReadOnly = true;
            this.txtRemarks.Size = new System.Drawing.Size(226, 98);
            this.txtRemarks.TabIndex = 5;
            // 
            // txtGDN
            // 
            this.txtGDN.BackColor = System.Drawing.Color.White;
            this.txtGDN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGDN.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGDN.Location = new System.Drawing.Point(129, 16);
            this.txtGDN.Name = "txtGDN";
            this.txtGDN.ReadOnly = true;
            this.txtGDN.Size = new System.Drawing.Size(226, 27);
            this.txtGDN.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Driver Name";
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.BackColor = System.Drawing.Color.White;
            this.txtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVehicleNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleNo.Location = new System.Drawing.Point(129, 112);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.ReadOnly = true;
            this.txtVehicleNo.Size = new System.Drawing.Size(226, 27);
            this.txtVehicleNo.TabIndex = 2;
            // 
            // txtDriverName
            // 
            this.txtDriverName.BackColor = System.Drawing.Color.White;
            this.txtDriverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDriverName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverName.Location = new System.Drawing.Point(129, 143);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.ReadOnly = true;
            this.txtDriverName.Size = new System.Drawing.Size(226, 27);
            this.txtDriverName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Dispatch No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Vehicle No";
            // 
            // dgvDispDetails
            // 
            this.dgvDispDetails.AllowUserToAddRows = false;
            this.dgvDispDetails.AllowUserToDeleteRows = false;
            this.dgvDispDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDispDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDispDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDispDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDispDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDispDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DDDispDetailsIDColumn,
            this.DDSrNoColumn,
            this.DDProductCodeColumn,
            this.DDProductNameColumn,
            this.DDProductGivenQtyColumn,
            this.DDProductMinQtyColumn,
            this.DDProductMaxQtyColumn,
            this.DDProductDispatchedQtyColumn,
            this.DDProductRemarksColumn});
            this.dgvDispDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDispDetails.Location = new System.Drawing.Point(0, 210);
            this.dgvDispDetails.MultiSelect = false;
            this.dgvDispDetails.Name = "dgvDispDetails";
            this.dgvDispDetails.ReadOnly = true;
            this.dgvDispDetails.RowHeadersVisible = false;
            this.dgvDispDetails.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDispDetails.RowTemplate.Height = 20;
            this.dgvDispDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvDispDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDispDetails.Size = new System.Drawing.Size(435, 317);
            this.dgvDispDetails.TabIndex = 9;
            this.dgvDispDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispDetails_CellClick);
            this.dgvDispDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDispDetails_CellValueChanged);
            this.dgvDispDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDispDetails_DataError);
            // 
            // DDDispDetailsIDColumn
            // 
            this.DDDispDetailsIDColumn.HeaderText = "DispDetailsID";
            this.DDDispDetailsIDColumn.Name = "DDDispDetailsIDColumn";
            this.DDDispDetailsIDColumn.ReadOnly = true;
            this.DDDispDetailsIDColumn.Visible = false;
            // 
            // DDSrNoColumn
            // 
            this.DDSrNoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DDSrNoColumn.HeaderText = "Sr#";
            this.DDSrNoColumn.MinimumWidth = 30;
            this.DDSrNoColumn.Name = "DDSrNoColumn";
            this.DDSrNoColumn.ReadOnly = true;
            this.DDSrNoColumn.Width = 48;
            // 
            // DDProductCodeColumn
            // 
            this.DDProductCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DDProductCodeColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.DDProductCodeColumn.HeaderText = "Product Code";
            this.DDProductCodeColumn.Name = "DDProductCodeColumn";
            this.DDProductCodeColumn.ReadOnly = true;
            this.DDProductCodeColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DDProductCodeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DDProductCodeColumn.Width = 94;
            // 
            // DDProductNameColumn
            // 
            this.DDProductNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DDProductNameColumn.HeaderText = "Product";
            this.DDProductNameColumn.Name = "DDProductNameColumn";
            this.DDProductNameColumn.ReadOnly = true;
            this.DDProductNameColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DDProductNameColumn.Width = 72;
            // 
            // DDProductGivenQtyColumn
            // 
            this.DDProductGivenQtyColumn.HeaderText = "Given Quantity";
            this.DDProductGivenQtyColumn.Name = "DDProductGivenQtyColumn";
            this.DDProductGivenQtyColumn.ReadOnly = true;
            // 
            // DDProductMinQtyColumn
            // 
            this.DDProductMinQtyColumn.HeaderText = "Minimum Quantity";
            this.DDProductMinQtyColumn.Name = "DDProductMinQtyColumn";
            this.DDProductMinQtyColumn.ReadOnly = true;
            // 
            // DDProductMaxQtyColumn
            // 
            this.DDProductMaxQtyColumn.HeaderText = "Maximum Quantity";
            this.DDProductMaxQtyColumn.Name = "DDProductMaxQtyColumn";
            this.DDProductMaxQtyColumn.ReadOnly = true;
            // 
            // DDProductDispatchedQtyColumn
            // 
            this.DDProductDispatchedQtyColumn.HeaderText = "Dispatched Qty";
            this.DDProductDispatchedQtyColumn.Name = "DDProductDispatchedQtyColumn";
            this.DDProductDispatchedQtyColumn.ReadOnly = true;
            // 
            // DDProductRemarksColumn
            // 
            this.DDProductRemarksColumn.HeaderText = "Remarks";
            this.DDProductRemarksColumn.Name = "DDProductRemarksColumn";
            this.DDProductRemarksColumn.ReadOnly = true;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.BackColor = System.Drawing.Color.White;
            this.txtTotalQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalQty.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTotalQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalQty.Location = new System.Drawing.Point(0, 527);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Size = new System.Drawing.Size(435, 27);
            this.txtTotalQty.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoadDL);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.numMaximumQty);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.numMinimumQty);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtDetailsRemarks);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.numDetailsQty);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cmbProductName);
            this.panel1.Controls.Add(this.cmbProductCode);
            this.panel1.Controls.Add(this.btnDeleteDetails);
            this.panel1.Controls.Add(this.btnAddDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(435, 210);
            this.panel1.TabIndex = 10;
            // 
            // btnLoadDL
            // 
            this.btnLoadDL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadDL.FlatAppearance.BorderSize = 2;
            this.btnLoadDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDL.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDL.Location = new System.Drawing.Point(353, 121);
            this.btnLoadDL.Name = "btnLoadDL";
            this.btnLoadDL.Size = new System.Drawing.Size(75, 73);
            this.btnLoadDL.TabIndex = 23;
            this.btnLoadDL.Text = "&Load From Excel";
            this.btnLoadDL.UseVisualStyleBackColor = true;
            this.btnLoadDL.Click += new System.EventHandler(this.btnLoadDL_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.FlatAppearance.BorderSize = 2;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(353, 46);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 31);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // numMaximumQty
            // 
            this.numMaximumQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMaximumQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMaximumQty.Location = new System.Drawing.Point(121, 136);
            this.numMaximumQty.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numMaximumQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMaximumQty.Name = "numMaximumQty";
            this.numMaximumQty.Size = new System.Drawing.Size(122, 27);
            this.numMaximumQty.TabIndex = 10;
            this.numMaximumQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 19);
            this.label14.TabIndex = 22;
            this.label14.Text = "Max. Qty";
            // 
            // numMinimumQty
            // 
            this.numMinimumQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numMinimumQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMinimumQty.Location = new System.Drawing.Point(121, 105);
            this.numMinimumQty.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numMinimumQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinimumQty.Name = "numMinimumQty";
            this.numMinimumQty.Size = new System.Drawing.Size(122, 27);
            this.numMinimumQty.TabIndex = 9;
            this.numMinimumQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 19);
            this.label13.TabIndex = 20;
            this.label13.Text = "Min. Qty";
            // 
            // txtDetailsRemarks
            // 
            this.txtDetailsRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDetailsRemarks.BackColor = System.Drawing.Color.White;
            this.txtDetailsRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetailsRemarks.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetailsRemarks.Location = new System.Drawing.Point(121, 167);
            this.txtDetailsRemarks.Name = "txtDetailsRemarks";
            this.txtDetailsRemarks.Size = new System.Drawing.Size(222, 27);
            this.txtDetailsRemarks.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.TabIndex = 8;
            this.label8.Text = "Remarks";
            // 
            // numDetailsQty
            // 
            this.numDetailsQty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numDetailsQty.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDetailsQty.Location = new System.Drawing.Point(121, 74);
            this.numDetailsQty.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.numDetailsQty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDetailsQty.Name = "numDetailsQty";
            this.numDetailsQty.Size = new System.Drawing.Size(122, 27);
            this.numDetailsQty.TabIndex = 8;
            this.numDetailsQty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDetailsQty.ValueChanged += new System.EventHandler(this.numDetailsQty_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 19);
            this.label7.TabIndex = 6;
            this.label7.Text = "Quantity";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 19);
            this.label6.TabIndex = 5;
            this.label6.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "Product Code";
            // 
            // cmbProductName
            // 
            this.cmbProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProductName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductName.FormattingEnabled = true;
            this.cmbProductName.Location = new System.Drawing.Point(121, 43);
            this.cmbProductName.Name = "cmbProductName";
            this.cmbProductName.Size = new System.Drawing.Size(222, 27);
            this.cmbProductName.TabIndex = 7;
            // 
            // cmbProductCode
            // 
            this.cmbProductCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProductCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProductCode.FormattingEnabled = true;
            this.cmbProductCode.Location = new System.Drawing.Point(121, 12);
            this.cmbProductCode.Name = "cmbProductCode";
            this.cmbProductCode.Size = new System.Drawing.Size(222, 27);
            this.cmbProductCode.TabIndex = 6;
            // 
            // btnDeleteDetails
            // 
            this.btnDeleteDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDetails.FlatAppearance.BorderSize = 2;
            this.btnDeleteDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteDetails.Location = new System.Drawing.Point(353, 84);
            this.btnDeleteDetails.Name = "btnDeleteDetails";
            this.btnDeleteDetails.Size = new System.Drawing.Size(75, 31);
            this.btnDeleteDetails.TabIndex = 14;
            this.btnDeleteDetails.Text = "&Delete";
            this.btnDeleteDetails.UseVisualStyleBackColor = true;
            this.btnDeleteDetails.Click += new System.EventHandler(this.btnDeleteDetails_Click);
            // 
            // btnAddDetails
            // 
            this.btnAddDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDetails.FlatAppearance.BorderSize = 2;
            this.btnAddDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDetails.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDetails.Location = new System.Drawing.Point(353, 8);
            this.btnAddDetails.Name = "btnAddDetails";
            this.btnAddDetails.Size = new System.Drawing.Size(75, 31);
            this.btnAddDetails.TabIndex = 12;
            this.btnAddDetails.Text = "&Add";
            this.btnAddDetails.UseVisualStyleBackColor = true;
            this.btnAddDetails.Click += new System.EventHandler(this.btnAddDetails_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "DispDetailsID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.HeaderText = "Sr#";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 30;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn3.HeaderText = "Product Code";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Product";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.HeaderText = "Given Quantity";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.HeaderText = "Dispatched Qty";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 38;
            // 
            // redCRUDAS1
            // 
            this.redCRUDAS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.redCRUDAS1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redCRUDAS1.Location = new System.Drawing.Point(0, 556);
            this.redCRUDAS1.Name = "redCRUDAS1";
            this.redCRUDAS1.RADUI_CtrSize = new System.Drawing.Size(81, 25);
            this.redCRUDAS1.RADUI_DataGridView = null;
            this.redCRUDAS1.RADUI_DataPanel = null;
            this.redCRUDAS1.RADUI_State = RedRapidUI.RedCRUDAS.eCRUDASState.Find;
            this.redCRUDAS1.Size = new System.Drawing.Size(1026, 56);
            this.redCRUDAS1.TabIndex = 1;
            this.redCRUDAS1.TotRecCount = 0;
            // 
            // cmbTransporter
            // 
            this.cmbTransporter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTransporter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTransporter.FormattingEnabled = true;
            this.cmbTransporter.Items.AddRange(new object[] {
            "CREATED",
            "RUNNING",
            "ABONDEN",
            "COMPLETED"});
            this.cmbTransporter.Location = new System.Drawing.Point(129, 80);
            this.cmbTransporter.Name = "cmbTransporter";
            this.cmbTransporter.Size = new System.Drawing.Size(226, 27);
            this.cmbTransporter.TabIndex = 31;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(12, 83);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 19);
            this.label18.TabIndex = 32;
            this.label18.Text = "Transporter";
            // 
            // FrmDispatchMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1026, 612);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.redCRUDAS1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmDispatchMaster";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatch Master";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDispatchMaster_Load);
            this.Shown += new System.EventHandler(this.FrmDispatchMaster_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.PAN_RecordInfo.ResumeLayout(false);
            this.splitDetails.Panel1.ResumeLayout(false);
            this.splitDetails.Panel1.PerformLayout();
            this.splitDetails.Panel2.ResumeLayout(false);
            this.splitDetails.Panel2.PerformLayout();
            this.splitDetails.ResumeLayout(false);
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoodQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBadQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDispDetails)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaximumQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinimumQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDetailsQty)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RedRapidUI.RedGridControl redGridControl1;
        private System.Windows.Forms.Panel PAN_RecordInfo;
        private System.Windows.Forms.SplitContainer splitDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.TextBox txtDriverName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDispDetails;
        private System.Windows.Forms.TextBox txtGDN;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeleteDetails;
        private System.Windows.Forms.Button btnAddDetails;
        private System.Windows.Forms.ComboBox cmbProductName;
        private System.Windows.Forms.ComboBox cmbProductCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numDetailsQty;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDetailsRemarks;
        private System.Windows.Forms.NumericUpDown numBadQty;
        private System.Windows.Forms.NumericUpDown numGoodQty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.NumericUpDown numMaximumQty;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numMinimumQty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtpDispatchDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private RedRapidUI.RedCRUDAS redCRUDAS1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDDispDetailsIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDSrNoColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DDProductCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDProductNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDProductGivenQtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDProductMinQtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDProductMaxQtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDProductDispatchedQtyColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DDProductRemarksColumn;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnLoadDL;
        private System.Windows.Forms.ComboBox cmbTransporter;
        private System.Windows.Forms.Label label18;
    }
}