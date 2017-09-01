namespace iPRINT.MANAGER
{
    partial class FrmFailureReport
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
            this.dgvDataReport = new System.Windows.Forms.DataGridView();
            this.dgvFailedItems = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFailedItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataReport
            // 
            this.dgvDataReport.AllowUserToAddRows = false;
            this.dgvDataReport.AllowUserToDeleteRows = false;
            this.dgvDataReport.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDataReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataReport.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvDataReport.Location = new System.Drawing.Point(0, 0);
            this.dgvDataReport.Name = "dgvDataReport";
            this.dgvDataReport.ReadOnly = true;
            this.dgvDataReport.Size = new System.Drawing.Size(239, 482);
            this.dgvDataReport.TabIndex = 0;
            // 
            // dgvFailedItems
            // 
            this.dgvFailedItems.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFailedItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFailedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFailedItems.Location = new System.Drawing.Point(239, 0);
            this.dgvFailedItems.Name = "dgvFailedItems";
            this.dgvFailedItems.Size = new System.Drawing.Size(571, 482);
            this.dgvFailedItems.TabIndex = 1;
            // 
            // FrmFailureReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(810, 482);
            this.Controls.Add(this.dgvFailedItems);
            this.Controls.Add(this.dgvDataReport);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFailureReport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FIFO Failure Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmFailureReport_Load);
            this.Shown += new System.EventHandler(this.FrmFailureReport_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFailedItems)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataReport;
        private System.Windows.Forms.DataGridView dgvFailedItems;
    }
}