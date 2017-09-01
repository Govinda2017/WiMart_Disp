namespace WIMARTS.COMMON
{
    partial class FrmJobReport
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
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnSummaryProd = new System.Windows.Forms.Button();
            this.btnInspDetails = new System.Windows.Forms.Button();
            this.pnlLines = new System.Windows.Forms.Panel();
            this.cmbLineNo = new System.Windows.Forms.ComboBox();
            this.cmbApplication = new System.Windows.Forms.ComboBox();
            this.cmbWise = new System.Windows.Forms.ComboBox();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.pnlLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd-MM-yyyy";
            this.dtpToDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(104, 37);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(126, 27);
            this.dtpToDate.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd-MM-yyyy";
            this.dtpFromDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(104, 9);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(126, 27);
            this.dtpFromDate.TabIndex = 0;
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // btnSummaryProd
            // 
            this.btnSummaryProd.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSummaryProd.FlatAppearance.BorderSize = 2;
            this.btnSummaryProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummaryProd.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummaryProd.Location = new System.Drawing.Point(361, 172);
            this.btnSummaryProd.Name = "btnSummaryProd";
            this.btnSummaryProd.Size = new System.Drawing.Size(122, 66);
            this.btnSummaryProd.TabIndex = 20;
            this.btnSummaryProd.Text = "Summary";
            this.btnSummaryProd.UseVisualStyleBackColor = false;
            this.btnSummaryProd.Click += new System.EventHandler(this.btnSummaryProd_Click);
            // 
            // btnInspDetails
            // 
            this.btnInspDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnInspDetails.FlatAppearance.BorderSize = 2;
            this.btnInspDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInspDetails.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInspDetails.Location = new System.Drawing.Point(361, 82);
            this.btnInspDetails.Name = "btnInspDetails";
            this.btnInspDetails.Size = new System.Drawing.Size(122, 81);
            this.btnInspDetails.TabIndex = 21;
            this.btnInspDetails.Text = "Production Detailed Report";
            this.btnInspDetails.UseVisualStyleBackColor = false;
            this.btnInspDetails.Click += new System.EventHandler(this.btnInspDetails_Click);
            // 
            // pnlLines
            // 
            this.pnlLines.Controls.Add(this.cmbLineNo);
            this.pnlLines.Location = new System.Drawing.Point(28, 148);
            this.pnlLines.Name = "pnlLines";
            this.pnlLines.Size = new System.Drawing.Size(327, 31);
            this.pnlLines.TabIndex = 26;
            this.pnlLines.Visible = false;
            // 
            // cmbLineNo
            // 
            this.cmbLineNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLineNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLineNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLineNo.FormattingEnabled = true;
            this.cmbLineNo.Items.AddRange(new object[] {
            "All",
            "Dock 1",
            "Dock 2",
            "Dock 3",
            "Dock 4"});
            this.cmbLineNo.Location = new System.Drawing.Point(0, 0);
            this.cmbLineNo.Name = "cmbLineNo";
            this.cmbLineNo.Size = new System.Drawing.Size(327, 27);
            this.cmbLineNo.TabIndex = 31;
            // 
            // cmbApplication
            // 
            this.cmbApplication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApplication.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApplication.FormattingEnabled = true;
            this.cmbApplication.Items.AddRange(new object[] {
            "Print",
            "Production",
            "Dispatch"});
            this.cmbApplication.Location = new System.Drawing.Point(28, 82);
            this.cmbApplication.Name = "cmbApplication";
            this.cmbApplication.Size = new System.Drawing.Size(327, 27);
            this.cmbApplication.TabIndex = 27;
            this.cmbApplication.SelectedIndexChanged += new System.EventHandler(this.cmbApplication_SelectedIndexChanged);
            // 
            // cmbWise
            // 
            this.cmbWise.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWise.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWise.FormattingEnabled = true;
            this.cmbWise.Items.AddRange(new object[] {
            "Product",
            "Batch"});
            this.cmbWise.Location = new System.Drawing.Point(28, 115);
            this.cmbWise.Name = "cmbWise";
            this.cmbWise.Size = new System.Drawing.Size(327, 27);
            this.cmbWise.TabIndex = 28;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.FlatAppearance.BorderSize = 2;
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintReport.Location = new System.Drawing.Point(246, 196);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(109, 42);
            this.btnPrintReport.TabIndex = 29;
            this.btnPrintReport.Text = "PRINT";
            this.btnPrintReport.UseVisualStyleBackColor = true;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click);
            // 
            // FrmJobReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1025, 646);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.cmbWise);
            this.Controls.Add(this.cmbApplication);
            this.Controls.Add(this.pnlLines);
            this.Controls.Add(this.btnInspDetails);
            this.Controls.Add(this.btnSummaryProd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpFromDate);
            this.Controls.Add(this.dtpToDate);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmJobReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Job Reports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmJobReports_Load);
            this.Shown += new System.EventHandler(this.FrmJobReports_Shown);
            this.pnlLines.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnSummaryProd;
        private System.Windows.Forms.Button btnInspDetails;
        private System.Windows.Forms.Panel pnlLines;
        private System.Windows.Forms.ComboBox cmbApplication;
        private System.Windows.Forms.ComboBox cmbWise;
        private System.Windows.Forms.Button btnPrintReport;
        private System.Windows.Forms.ComboBox cmbLineNo;
    }
}