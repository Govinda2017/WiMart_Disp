namespace WIMARTS.COMMON
{
    partial class FrmHWCValues
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tNumSettingPulse = new RedRapidUI.TNumEditBox();
            this.tNumSettingTrigger = new RedRapidUI.TNumEditBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbErrorAct = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tNumPulseDelay = new RedRapidUI.TNumEditBox();
            this.tNumTriggerDelay = new RedRapidUI.TNumEditBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnReverse = new System.Windows.Forms.RadioButton();
            this.rbtnForward = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(236, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&CLOSE";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(75, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&EDIT";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tNumSettingPulse);
            this.groupBox1.Controls.Add(this.tNumSettingTrigger);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Camera Setting Mode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pulse Delay";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Trigger Delay";
            // 
            // tNumSettingPulse
            // 
            this.tNumSettingPulse.ForeColor = System.Drawing.Color.Black;
            this.tNumSettingPulse.Location = new System.Drawing.Point(302, 19);
            this.tNumSettingPulse.Name = "tNumSettingPulse";
            this.tNumSettingPulse.Size = new System.Drawing.Size(71, 23);
            this.tNumSettingPulse.TabIndex = 1;
            // 
            // tNumSettingTrigger
            // 
            this.tNumSettingTrigger.ForeColor = System.Drawing.Color.Black;
            this.tNumSettingTrigger.Location = new System.Drawing.Point(105, 19);
            this.tNumSettingTrigger.Name = "tNumSettingTrigger";
            this.tNumSettingTrigger.Size = new System.Drawing.Size(71, 23);
            this.tNumSettingTrigger.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbErrorAct);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tNumPulseDelay);
            this.groupBox2.Controls.Add(this.tNumTriggerDelay);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(385, 143);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Controller Settings";
            // 
            // cmbErrorAct
            // 
            this.cmbErrorAct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbErrorAct.FormattingEnabled = true;
            this.cmbErrorAct.Items.AddRange(new object[] {
            "No Action",
            "Stop",
            "Reverse"});
            this.cmbErrorAct.Location = new System.Drawing.Point(105, 51);
            this.cmbErrorAct.Name = "cmbErrorAct";
            this.cmbErrorAct.Size = new System.Drawing.Size(71, 22);
            this.cmbErrorAct.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Action on Error";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Pulse Delay";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trigger Delay";
            // 
            // tNumPulseDelay
            // 
            this.tNumPulseDelay.ForeColor = System.Drawing.Color.Black;
            this.tNumPulseDelay.Location = new System.Drawing.Point(302, 21);
            this.tNumPulseDelay.Name = "tNumPulseDelay";
            this.tNumPulseDelay.Size = new System.Drawing.Size(71, 23);
            this.tNumPulseDelay.TabIndex = 3;
            // 
            // tNumTriggerDelay
            // 
            this.tNumTriggerDelay.ForeColor = System.Drawing.Color.Black;
            this.tNumTriggerDelay.Location = new System.Drawing.Point(105, 21);
            this.tNumTriggerDelay.Name = "tNumTriggerDelay";
            this.tNumTriggerDelay.Size = new System.Drawing.Size(71, 23);
            this.tNumTriggerDelay.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnReverse);
            this.groupBox3.Controls.Add(this.rbtnForward);
            this.groupBox3.Location = new System.Drawing.Point(197, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 45);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Conveyor Direction";
            // 
            // rbtnReverse
            // 
            this.rbtnReverse.AutoSize = true;
            this.rbtnReverse.Checked = true;
            this.rbtnReverse.Location = new System.Drawing.Point(93, 20);
            this.rbtnReverse.Name = "rbtnReverse";
            this.rbtnReverse.Size = new System.Drawing.Size(69, 19);
            this.rbtnReverse.TabIndex = 1;
            this.rbtnReverse.TabStop = true;
            this.rbtnReverse.Text = "Reverse";
            this.rbtnReverse.UseVisualStyleBackColor = true;
            // 
            // rbtnForward
            // 
            this.rbtnForward.AutoSize = true;
            this.rbtnForward.Location = new System.Drawing.Point(16, 20);
            this.rbtnForward.Name = "rbtnForward";
            this.rbtnForward.Size = new System.Drawing.Size(71, 19);
            this.rbtnForward.TabIndex = 0;
            this.rbtnForward.Text = "Forward";
            this.rbtnForward.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(1, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Enabled = false;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Size = new System.Drawing.Size(387, 251);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 9;
            // 
            // FrmHWCValues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 258);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 9.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmHWCValues";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HW Values";
            this.Load += new System.EventHandler(this.FrmHWCValues_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private RedRapidUI.TNumEditBox tNumSettingPulse;
        private RedRapidUI.TNumEditBox tNumSettingTrigger;
        private System.Windows.Forms.GroupBox groupBox3;
        private RedRapidUI.TNumEditBox tNumPulseDelay;
        private RedRapidUI.TNumEditBox tNumTriggerDelay;
        private System.Windows.Forms.RadioButton rbtnReverse;
        private System.Windows.Forms.RadioButton rbtnForward;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbErrorAct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}