namespace WIMARTS.COMMON
{
    partial class FrmHWCSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPortSettings = new System.Windows.Forms.Button();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.btnHWCSettings = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial Port";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MistyRose;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(49, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 34);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "&EDIT";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.MistyRose;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(210, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "&CLOSE";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPortSettings
            // 
            this.btnPortSettings.BackColor = System.Drawing.Color.MistyRose;
            this.btnPortSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnPortSettings.FlatAppearance.BorderSize = 2;
            this.btnPortSettings.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnPortSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPortSettings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPortSettings.Location = new System.Drawing.Point(209, 47);
            this.btnPortSettings.Name = "btnPortSettings";
            this.btnPortSettings.Size = new System.Drawing.Size(102, 34);
            this.btnPortSettings.TabIndex = 3;
            this.btnPortSettings.Text = "&Port Settings";
            this.btnPortSettings.UseVisualStyleBackColor = false;
            this.btnPortSettings.Click += new System.EventHandler(this.btnPortSettings_Click);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(116, 12);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(195, 27);
            this.cmbSerialPort.TabIndex = 4;
            // 
            // btnHWCSettings
            // 
            this.btnHWCSettings.BackColor = System.Drawing.Color.MistyRose;
            this.btnHWCSettings.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnHWCSettings.FlatAppearance.BorderSize = 2;
            this.btnHWCSettings.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightCoral;
            this.btnHWCSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHWCSettings.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHWCSettings.Location = new System.Drawing.Point(116, 87);
            this.btnHWCSettings.Name = "btnHWCSettings";
            this.btnHWCSettings.Size = new System.Drawing.Size(195, 34);
            this.btnHWCSettings.TabIndex = 5;
            this.btnHWCSettings.Text = "Hardware Settings";
            this.btnHWCSettings.UseVisualStyleBackColor = false;
            this.btnHWCSettings.Click += new System.EventHandler(this.btnHWCSettings_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.btnHWCSettings);
            this.splitContainer1.Panel1.Controls.Add(this.btnPortSettings);
            this.splitContainer1.Panel1.Controls.Add(this.cmbSerialPort);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(335, 280);
            this.splitContainer1.SplitterDistance = 222;
            this.splitContainer1.TabIndex = 6;
            // 
            // FrmHWCSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(335, 280);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmHWCSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HW Controller";
            this.Load += new System.EventHandler(this.FrmHWCSettings_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnPortSettings;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Button btnHWCSettings;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}