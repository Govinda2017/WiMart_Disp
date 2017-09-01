namespace WIMARTS.COMMON
{
    partial class FrmAppSettings
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
            this.chkProductionVerified = new System.Windows.Forms.CheckBox();
            this.chkbHwCtrlr = new System.Windows.Forms.CheckBox();
            this.cmbHwMode = new System.Windows.Forms.ComboBox();
            this.numDispDayLimit = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkbStrictDisp = new System.Windows.Forms.CheckBox();
            this.chkFreeFlowDispatch = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDispDayLimit)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkProductionVerified
            // 
            this.chkProductionVerified.AutoSize = true;
            this.chkProductionVerified.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProductionVerified.Location = new System.Drawing.Point(330, 59);
            this.chkProductionVerified.Name = "chkProductionVerified";
            this.chkProductionVerified.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkProductionVerified.Size = new System.Drawing.Size(15, 14);
            this.chkProductionVerified.TabIndex = 0;
            this.chkProductionVerified.UseVisualStyleBackColor = true;
            // 
            // chkbHwCtrlr
            // 
            this.chkbHwCtrlr.AutoSize = true;
            this.chkbHwCtrlr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbHwCtrlr.Location = new System.Drawing.Point(330, 133);
            this.chkbHwCtrlr.Name = "chkbHwCtrlr";
            this.chkbHwCtrlr.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkbHwCtrlr.Size = new System.Drawing.Size(15, 14);
            this.chkbHwCtrlr.TabIndex = 1;
            this.chkbHwCtrlr.UseVisualStyleBackColor = true;
            // 
            // cmbHwMode
            // 
            this.cmbHwMode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHwMode.FormattingEnabled = true;
            this.cmbHwMode.Items.AddRange(new object[] {
            "Both (Camera & Scanner)",
            "Camera",
            "Scanner"});
            this.cmbHwMode.Location = new System.Drawing.Point(172, 164);
            this.cmbHwMode.Name = "cmbHwMode";
            this.cmbHwMode.Size = new System.Drawing.Size(173, 27);
            this.cmbHwMode.TabIndex = 3;
            // 
            // numDispDayLimit
            // 
            this.numDispDayLimit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numDispDayLimit.Location = new System.Drawing.Point(172, 201);
            this.numDispDayLimit.Name = "numDispDayLimit";
            this.numDispDayLimit.Size = new System.Drawing.Size(173, 27);
            this.numDispDayLimit.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hardware Mode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Dispatch Days Limit";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.MistyRose;
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEdit.FlatAppearance.BorderSize = 2;
            this.btnEdit.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(66, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 36);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "&EDIT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.MistyRose;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 2;
            this.btnClose.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(211, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 36);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&CLOSE";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.chkFreeFlowDispatch);
            this.splitContainer1.Panel1.Controls.Add(this.chkbStrictDisp);
            this.splitContainer1.Panel1.Controls.Add(this.chkProductionVerified);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.chkbHwCtrlr);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbHwMode);
            this.splitContainer1.Panel1.Controls.Add(this.numDispDayLimit);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Size = new System.Drawing.Size(370, 314);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 10;
            // 
            // chkbStrictDisp
            // 
            this.chkbStrictDisp.AutoSize = true;
            this.chkbStrictDisp.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbStrictDisp.Location = new System.Drawing.Point(330, 22);
            this.chkbStrictDisp.Name = "chkbStrictDisp";
            this.chkbStrictDisp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkbStrictDisp.Size = new System.Drawing.Size(15, 14);
            this.chkbStrictDisp.TabIndex = 8;
            this.chkbStrictDisp.UseVisualStyleBackColor = true;
            // 
            // chkFreeFlowDispatch
            // 
            this.chkFreeFlowDispatch.AutoSize = true;
            this.chkFreeFlowDispatch.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFreeFlowDispatch.Location = new System.Drawing.Point(330, 96);
            this.chkFreeFlowDispatch.Name = "chkFreeFlowDispatch";
            this.chkFreeFlowDispatch.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkFreeFlowDispatch.Size = new System.Drawing.Size(15, 14);
            this.chkFreeFlowDispatch.TabIndex = 9;
            this.chkFreeFlowDispatch.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Allow Only Production/Inward Verified";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(213, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Allow Only Schedule Dispatch";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 19);
            this.label5.TabIndex = 13;
            this.label5.Text = "Allow Free Flow Dispatch";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "HW Controller";
            // 
            // FrmAppSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(370, 314);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAppSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dispatch Settings";
            this.Load += new System.EventHandler(this.FrmAppSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDispDayLimit)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkProductionVerified;
        private System.Windows.Forms.CheckBox chkbHwCtrlr;
        private System.Windows.Forms.ComboBox cmbHwMode;
        private System.Windows.Forms.NumericUpDown numDispDayLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkbStrictDisp;
        private System.Windows.Forms.CheckBox chkFreeFlowDispatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}