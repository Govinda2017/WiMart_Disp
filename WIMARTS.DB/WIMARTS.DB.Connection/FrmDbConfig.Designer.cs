namespace WIMARTS.DB.Connection
{
    partial class FrmDbConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDbConfig));
            this.panel15 = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.TXT_PWD = new System.Windows.Forms.TextBox();
            this.TXT_UserName = new System.Windows.Forms.TextBox();
            this.TXT_DbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.BTN_SaveHWSysConfig = new System.Windows.Forms.Button();
            this.cmbServerNames = new System.Windows.Forms.ComboBox();
            this.panel15.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel15.Controls.Add(this.cmbServerNames);
            this.panel15.Controls.Add(this.radioButton1);
            this.panel15.Controls.Add(this.TXT_PWD);
            this.panel15.Controls.Add(this.TXT_UserName);
            this.panel15.Controls.Add(this.TXT_DbName);
            this.panel15.Controls.Add(this.label1);
            this.panel15.Controls.Add(this.label47);
            this.panel15.Controls.Add(this.label50);
            this.panel15.Controls.Add(this.label49);
            this.panel15.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel15.Location = new System.Drawing.Point(5, 6);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(393, 178);
            this.panel15.TabIndex = 10;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(126, 55);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // TXT_PWD
            // 
            this.TXT_PWD.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_PWD.Location = new System.Drawing.Point(141, 120);
            this.TXT_PWD.Name = "TXT_PWD";
            this.TXT_PWD.PasswordChar = '*';
            this.TXT_PWD.Size = new System.Drawing.Size(238, 22);
            this.TXT_PWD.TabIndex = 14;
            // 
            // TXT_UserName
            // 
            this.TXT_UserName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_UserName.Location = new System.Drawing.Point(141, 85);
            this.TXT_UserName.Name = "TXT_UserName";
            this.TXT_UserName.Size = new System.Drawing.Size(238, 22);
            this.TXT_UserName.TabIndex = 13;
            // 
            // TXT_DbName
            // 
            this.TXT_DbName.Enabled = false;
            this.TXT_DbName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_DbName.Location = new System.Drawing.Point(141, 50);
            this.TXT_DbName.Name = "TXT_DbName";
            this.TXT_DbName.Size = new System.Drawing.Size(238, 22);
            this.TXT_DbName.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "DATABASE SERVER";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(16, 54);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(93, 14);
            this.label47.TabIndex = 1;
            this.label47.Text = "DATABASE NAME";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(16, 124);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(65, 14);
            this.label50.TabIndex = 7;
            this.label50.Tag = " ";
            this.label50.Text = "PASSWORD";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(16, 89);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(68, 14);
            this.label49.TabIndex = 5;
            this.label49.Text = "USER NAME";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel15);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 253);
            this.panel1.TabIndex = 14;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Controls.Add(this.button1);
            this.panel7.Controls.Add(this.BTN_SaveHWSysConfig);
            this.panel7.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(5, 190);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(393, 56);
            this.panel7.TabIndex = 50;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(226, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "E&XIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_SaveHWSysConfig
            // 
            this.BTN_SaveHWSysConfig.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SaveHWSysConfig.Location = new System.Drawing.Point(57, 11);
            this.BTN_SaveHWSysConfig.Name = "BTN_SaveHWSysConfig";
            this.BTN_SaveHWSysConfig.Size = new System.Drawing.Size(110, 35);
            this.BTN_SaveHWSysConfig.TabIndex = 15;
            this.BTN_SaveHWSysConfig.Text = "&SAVE";
            this.BTN_SaveHWSysConfig.UseVisualStyleBackColor = true;
            this.BTN_SaveHWSysConfig.Click += new System.EventHandler(this.BTN_SaveHWSysConfig_Click);
            // 
            // cmbServerNames
            // 
            this.cmbServerNames.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbServerNames.FormattingEnabled = true;
            this.cmbServerNames.Location = new System.Drawing.Point(141, 14);
            this.cmbServerNames.Name = "cmbServerNames";
            this.cmbServerNames.Size = new System.Drawing.Size(238, 22);
            this.cmbServerNames.TabIndex = 16;
            // 
            // FrmDbConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(403, 253);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDbConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATABASE CONFIGURATION";
            this.Load += new System.EventHandler(this.FrmDbConfig_Load);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BTN_SaveHWSysConfig;
        private System.Windows.Forms.TextBox TXT_PWD;
        private System.Windows.Forms.TextBox TXT_UserName;
        private System.Windows.Forms.TextBox TXT_DbName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cmbServerNames;
    }
}