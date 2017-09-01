namespace WIMARTS.REPORTS
{
    partial class FrmReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_ExportWord = new System.Windows.Forms.Button();
            this.Btn_ExportMail = new System.Windows.Forms.Button();
            this.BTN_ExportXLS = new System.Windows.Forms.Button();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.BTN_ExportPDF = new System.Windows.Forms.Button();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Gray;
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(892, 541);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTN_ExportWord);
            this.panel1.Controls.Add(this.Btn_ExportMail);
            this.panel1.Controls.Add(this.BTN_ExportXLS);
            this.panel1.Controls.Add(this.BTN_Close);
            this.panel1.Controls.Add(this.BTN_ExportPDF);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(167, 541);
            this.panel1.TabIndex = 20;
            // 
            // BTN_ExportWord
            // 
            this.BTN_ExportWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_ExportWord.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ExportWord.Location = new System.Drawing.Point(13, 96);
            this.BTN_ExportWord.Name = "BTN_ExportWord";
            this.BTN_ExportWord.Size = new System.Drawing.Size(142, 39);
            this.BTN_ExportWord.TabIndex = 31;
            this.BTN_ExportWord.Text = "Export To  Word";
            this.BTN_ExportWord.UseVisualStyleBackColor = false;
            this.BTN_ExportWord.Click += new System.EventHandler(this.BTN_ExportWord_Click);
            // 
            // Btn_ExportMail
            // 
            this.Btn_ExportMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Btn_ExportMail.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ExportMail.Location = new System.Drawing.Point(13, 138);
            this.Btn_ExportMail.Name = "Btn_ExportMail";
            this.Btn_ExportMail.Size = new System.Drawing.Size(142, 39);
            this.Btn_ExportMail.TabIndex = 29;
            this.Btn_ExportMail.Text = "Attach  to Mail";
            this.Btn_ExportMail.UseVisualStyleBackColor = false;
            this.Btn_ExportMail.Click += new System.EventHandler(this.Btn_ExportMail_Click);
            // 
            // BTN_ExportXLS
            // 
            this.BTN_ExportXLS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_ExportXLS.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ExportXLS.Location = new System.Drawing.Point(13, 54);
            this.BTN_ExportXLS.Name = "BTN_ExportXLS";
            this.BTN_ExportXLS.Size = new System.Drawing.Size(142, 39);
            this.BTN_ExportXLS.TabIndex = 22;
            this.BTN_ExportXLS.Text = "Export To  Excel";
            this.BTN_ExportXLS.UseVisualStyleBackColor = false;
            this.BTN_ExportXLS.Click += new System.EventHandler(this.BTN_ExportXLS_Click);
            // 
            // BTN_Close
            // 
            this.BTN_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_Close.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Close.Location = new System.Drawing.Point(13, 180);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(142, 39);
            this.BTN_Close.TabIndex = 20;
            this.BTN_Close.Text = "Close";
            this.BTN_Close.UseVisualStyleBackColor = false;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // BTN_ExportPDF
            // 
            this.BTN_ExportPDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.BTN_ExportPDF.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_ExportPDF.Location = new System.Drawing.Point(13, 12);
            this.BTN_ExportPDF.Name = "BTN_ExportPDF";
            this.BTN_ExportPDF.Size = new System.Drawing.Size(142, 39);
            this.BTN_ExportPDF.TabIndex = 21;
            this.BTN_ExportPDF.Text = "Export To PDF";
            this.BTN_ExportPDF.UseVisualStyleBackColor = false;
            this.BTN_ExportPDF.Click += new System.EventHandler(this.BTN_Export_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.ShowExportButton = false;
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.ShowParameterPanelButton = false;
            this.crystalReportViewer1.ShowPrintButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(721, 541);
            this.crystalReportViewer1.TabIndex = 1;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // FrmReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(892, 541);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmReport";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Display";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BTN_ExportXLS;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Button BTN_ExportPDF;
        private System.Windows.Forms.Button Btn_ExportMail;
        private System.Windows.Forms.Button BTN_ExportWord;
    }
}