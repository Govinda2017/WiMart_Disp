namespace WIMARTS.COMMON
{
    partial class FrmUserManager
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
            this.PAN_RecordInfo = new System.Windows.Forms.Panel();
            this.CHK_Active = new System.Windows.Forms.CheckBox();
            this.TXT_ConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.TXT_UserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CMB_Roles = new System.Windows.Forms.ComboBox();
            this.redCRUDAS1 = new RedRapidUI.RedCRUDAS();
            this.redGridControl1 = new RedRapidUI.RedGridControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.PAN_RecordInfo.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PAN_RecordInfo
            // 
            this.PAN_RecordInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PAN_RecordInfo.Controls.Add(this.CHK_Active);
            this.PAN_RecordInfo.Controls.Add(this.TXT_ConfirmPassword);
            this.PAN_RecordInfo.Controls.Add(this.label4);
            this.PAN_RecordInfo.Controls.Add(this.label3);
            this.PAN_RecordInfo.Controls.Add(this.TXT_Password);
            this.PAN_RecordInfo.Controls.Add(this.TXT_UserName);
            this.PAN_RecordInfo.Controls.Add(this.label1);
            this.PAN_RecordInfo.Controls.Add(this.label2);
            this.PAN_RecordInfo.Controls.Add(this.CMB_Roles);
            this.PAN_RecordInfo.Location = new System.Drawing.Point(0, 0);
            this.PAN_RecordInfo.Name = "PAN_RecordInfo";
            this.PAN_RecordInfo.Size = new System.Drawing.Size(502, 321);
            this.PAN_RecordInfo.TabIndex = 2;
            // 
            // CHK_Active
            // 
            this.CHK_Active.AutoSize = true;
            this.CHK_Active.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_Active.Location = new System.Drawing.Point(399, 8);
            this.CHK_Active.Name = "CHK_Active";
            this.CHK_Active.Size = new System.Drawing.Size(70, 23);
            this.CHK_Active.TabIndex = 26;
            this.CHK_Active.Text = "Active";
            this.CHK_Active.UseVisualStyleBackColor = true;
            this.CHK_Active.CheckedChanged += new System.EventHandler(this.TrackChange_NewEdit);
            // 
            // TXT_ConfirmPassword
            // 
            this.TXT_ConfirmPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_ConfirmPassword.Location = new System.Drawing.Point(162, 113);
            this.TXT_ConfirmPassword.Name = "TXT_ConfirmPassword";
            this.TXT_ConfirmPassword.PasswordChar = '*';
            this.TXT_ConfirmPassword.ReadOnly = true;
            this.TXT_ConfirmPassword.Size = new System.Drawing.Size(231, 27);
            this.TXT_ConfirmPassword.TabIndex = 15;
            this.TXT_ConfirmPassword.TextChanged += new System.EventHandler(this.TrackChange_NewEdit);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "Confirm Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            // 
            // TXT_Password
            // 
            this.TXT_Password.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Password.Location = new System.Drawing.Point(162, 77);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.PasswordChar = '*';
            this.TXT_Password.ReadOnly = true;
            this.TXT_Password.Size = new System.Drawing.Size(231, 27);
            this.TXT_Password.TabIndex = 13;
            this.TXT_Password.TextChanged += new System.EventHandler(this.TrackChange_NewEdit);
            // 
            // TXT_UserName
            // 
            this.TXT_UserName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_UserName.Location = new System.Drawing.Point(162, 41);
            this.TXT_UserName.Name = "TXT_UserName";
            this.TXT_UserName.ReadOnly = true;
            this.TXT_UserName.Size = new System.Drawing.Size(231, 27);
            this.TXT_UserName.TabIndex = 11;
            this.TXT_UserName.TextChanged += new System.EventHandler(this.TrackChange_NewEdit);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "User Role";
            // 
            // CMB_Roles
            // 
            this.CMB_Roles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_Roles.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMB_Roles.FormattingEnabled = true;
            this.CMB_Roles.Location = new System.Drawing.Point(162, 6);
            this.CMB_Roles.Name = "CMB_Roles";
            this.CMB_Roles.Size = new System.Drawing.Size(231, 27);
            this.CMB_Roles.TabIndex = 10;
            this.CMB_Roles.SelectedIndexChanged += new System.EventHandler(this.CMB_Roles_SelectedIndexChanged);
            // 
            // redCRUDAS1
            // 
            this.redCRUDAS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.redCRUDAS1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redCRUDAS1.Location = new System.Drawing.Point(0, 320);
            this.redCRUDAS1.Name = "redCRUDAS1";
            this.redCRUDAS1.RADUI_CtrSize = new System.Drawing.Size(81, 25);
            this.redCRUDAS1.RADUI_DataGridView = this.redGridControl1;
            this.redCRUDAS1.RADUI_DataPanel = this.PAN_RecordInfo;
            this.redCRUDAS1.RADUI_State = RedRapidUI.RedCRUDAS.eCRUDASState.Find;
            this.redCRUDAS1.Size = new System.Drawing.Size(502, 43);
            this.redCRUDAS1.TabIndex = 1;
            this.redCRUDAS1.TotRecCount = 0;
            // 
            // redGridControl1
            // 
            this.redGridControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.redGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redGridControl1.Location = new System.Drawing.Point(0, 0);
            this.redGridControl1.Name = "redGridControl1";
            this.redGridControl1.Size = new System.Drawing.Size(253, 363);
            this.redGridControl1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            this.splitContainer1.Panel2.Controls.Add(this.redCRUDAS1);
            this.splitContainer1.Size = new System.Drawing.Size(759, 363);
            this.splitContainer1.SplitterDistance = 253;
            this.splitContainer1.TabIndex = 3;
            // 
            // FrmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(759, 363);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmUserManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Manager";
            this.Load += new System.EventHandler(this.FrmUserManager_Load);
            this.Shown += new System.EventHandler(this.FrmUserManager_Shown);
            this.PAN_RecordInfo.ResumeLayout(false);
            this.PAN_RecordInfo.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RedRapidUI.RedGridControl redGridControl1;
        private RedRapidUI.RedCRUDAS redCRUDAS1;
        private System.Windows.Forms.Panel PAN_RecordInfo;
        private System.Windows.Forms.TextBox TXT_ConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.TextBox TXT_UserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CMB_Roles;
        private System.Windows.Forms.CheckBox CHK_Active;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}