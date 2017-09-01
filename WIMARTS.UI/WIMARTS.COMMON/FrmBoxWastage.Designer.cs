namespace WIMARTS.COMMON
{
    partial class FrmBoxWastage
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
            this.lblStatusBar = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAltScanned = new System.Windows.Forms.TextBox();
            this.txtAltUID = new System.Windows.Forms.TextBox();
            this.btnIndicator = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtScannedData = new System.Windows.Forms.TextBox();
            this.txtUID = new System.Windows.Forms.TextBox();
            this.dgScannedData = new System.Windows.Forms.DataGridView();
            this.SrNoColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCodeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlternateBoxIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgScannedData)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblStatusBar);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtAltScanned);
            this.splitContainer1.Panel1.Controls.Add(this.txtAltUID);
            this.splitContainer1.Panel1.Controls.Add(this.btnIndicator);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtScannedData);
            this.splitContainer1.Panel1.Controls.Add(this.txtUID);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgScannedData);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Size = new System.Drawing.Size(1018, 461);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.BackColor = System.Drawing.Color.White;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBar.Location = new System.Drawing.Point(0, 124);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(1018, 27);
            this.lblStatusBar.TabIndex = 10;
            this.lblStatusBar.Text = "Enter UID or Scan 2D Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(568, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "ALTERNATE UID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "WASTED UID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(412, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 59);
            this.label3.TabIndex = 7;
            this.label3.Text = ">>";
            // 
            // txtAltScanned
            // 
            this.txtAltScanned.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltScanned.Enabled = false;
            this.txtAltScanned.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtAltScanned.Location = new System.Drawing.Point(490, 61);
            this.txtAltScanned.Multiline = true;
            this.txtAltScanned.Name = "txtAltScanned";
            this.txtAltScanned.Size = new System.Drawing.Size(294, 43);
            this.txtAltScanned.TabIndex = 6;
            this.txtAltScanned.TextChanged += new System.EventHandler(this.txtAltScanned_TextChanged);
            // 
            // txtAltUID
            // 
            this.txtAltUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAltUID.Enabled = false;
            this.txtAltUID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtAltUID.Location = new System.Drawing.Point(490, 30);
            this.txtAltUID.Multiline = true;
            this.txtAltUID.Name = "txtAltUID";
            this.txtAltUID.Size = new System.Drawing.Size(294, 25);
            this.txtAltUID.TabIndex = 5;
            this.txtAltUID.TextChanged += new System.EventHandler(this.txtAltUID_TextChanged);
            // 
            // btnIndicator
            // 
            this.btnIndicator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIndicator.Location = new System.Drawing.Point(790, 28);
            this.btnIndicator.Name = "btnIndicator";
            this.btnIndicator.Size = new System.Drawing.Size(105, 76);
            this.btnIndicator.TabIndex = 4;
            this.btnIndicator.Text = "STATUS";
            this.btnIndicator.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "SCAN CODE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "ENTER UID";
            // 
            // txtScannedData
            // 
            this.txtScannedData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScannedData.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtScannedData.Location = new System.Drawing.Point(118, 61);
            this.txtScannedData.Multiline = true;
            this.txtScannedData.Name = "txtScannedData";
            this.txtScannedData.Size = new System.Drawing.Size(289, 43);
            this.txtScannedData.TabIndex = 1;
            this.txtScannedData.TextChanged += new System.EventHandler(this.txtScannedData_TextChanged);
            // 
            // txtUID
            // 
            this.txtUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.txtUID.Location = new System.Drawing.Point(118, 30);
            this.txtUID.Multiline = true;
            this.txtUID.Name = "txtUID";
            this.txtUID.Size = new System.Drawing.Size(289, 25);
            this.txtUID.TabIndex = 0;
            this.txtUID.TextChanged += new System.EventHandler(this.txtUID_TextChanged);
            // 
            // dgScannedData
            // 
            this.dgScannedData.AllowUserToAddRows = false;
            this.dgScannedData.AllowUserToDeleteRows = false;
            this.dgScannedData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgScannedData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgScannedData.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgScannedData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgScannedData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgScannedData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SrNoColumn,
            this.ProductCodeColumn,
            this.BatchNameColumn,
            this.UIDColumn,
            this.AlternateBoxIDColumn,
            this.DateColumn});
            this.dgScannedData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgScannedData.Location = new System.Drawing.Point(0, 0);
            this.dgScannedData.MultiSelect = false;
            this.dgScannedData.Name = "dgScannedData";
            this.dgScannedData.ReadOnly = true;
            this.dgScannedData.RowHeadersVisible = false;
            this.dgScannedData.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgScannedData.RowTemplate.Height = 30;
            this.dgScannedData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgScannedData.Size = new System.Drawing.Size(1018, 306);
            this.dgScannedData.TabIndex = 1;
            // 
            // SrNoColumn
            // 
            this.SrNoColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SrNoColumn.HeaderText = "SrNo";
            this.SrNoColumn.MinimumWidth = 30;
            this.SrNoColumn.Name = "SrNoColumn";
            this.SrNoColumn.ReadOnly = true;
            this.SrNoColumn.Width = 64;
            // 
            // ProductCodeColumn
            // 
            this.ProductCodeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProductCodeColumn.HeaderText = "Product Code";
            this.ProductCodeColumn.Name = "ProductCodeColumn";
            this.ProductCodeColumn.ReadOnly = true;
            this.ProductCodeColumn.Width = 110;
            // 
            // BatchNameColumn
            // 
            this.BatchNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BatchNameColumn.HeaderText = "Batch";
            this.BatchNameColumn.Name = "BatchNameColumn";
            this.BatchNameColumn.ReadOnly = true;
            this.BatchNameColumn.Width = 71;
            // 
            // UIDColumn
            // 
            this.UIDColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UIDColumn.HeaderText = "Box ID";
            this.UIDColumn.Name = "UIDColumn";
            this.UIDColumn.ReadOnly = true;
            // 
            // AlternateBoxIDColumn
            // 
            this.AlternateBoxIDColumn.HeaderText = "Alternate Box ID";
            this.AlternateBoxIDColumn.Name = "AlternateBoxIDColumn";
            this.AlternateBoxIDColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            this.DateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Width = 65;
            // 
            // FrmBoxWastage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1018, 461);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmBoxWastage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Box Wastage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgScannedData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtScannedData;
        private System.Windows.Forms.TextBox txtUID;
        private System.Windows.Forms.Button btnIndicator;
        private System.Windows.Forms.DataGridView dgScannedData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAltScanned;
        private System.Windows.Forms.TextBox txtAltUID;
        private System.Windows.Forms.Label lblStatusBar;
        private System.Windows.Forms.DataGridViewTextBoxColumn SrNoColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCodeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlternateBoxIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
    }
}