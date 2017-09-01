namespace WIMARTS.COMMON
{
    partial class FrmCompanyMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompanyMaster));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.redGridControl1 = new RedRapidUI.RedGridControl();
            this.PAN_RecordInfo = new System.Windows.Forms.Panel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TBX_Address = new System.Windows.Forms.TextBox();
            this.TXT_City = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpincode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddInfo = new System.Windows.Forms.TextBox();
            this.lblAddInfo = new System.Windows.Forms.Label();
            this.txtCompname = new System.Windows.Forms.TextBox();
            this.lblCompName = new System.Windows.Forms.Label();
            this.redCRUDAS1 = new RedRapidUI.RedCRUDAS();
            this.ofdImage = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PAN_RecordInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(932, 541);
            this.splitContainer1.SplitterDistance = 413;
            this.splitContainer1.TabIndex = 23;
            // 
            // redGridControl1
            // 
            this.redGridControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.redGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redGridControl1.Location = new System.Drawing.Point(0, 0);
            this.redGridControl1.Name = "redGridControl1";
            this.redGridControl1.Size = new System.Drawing.Size(413, 541);
            this.redGridControl1.TabIndex = 23;
            // 
            // PAN_RecordInfo
            // 
            this.PAN_RecordInfo.BackColor = System.Drawing.SystemColors.Control;
            this.PAN_RecordInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PAN_RecordInfo.Controls.Add(this.pbLogo);
            this.PAN_RecordInfo.Controls.Add(this.txtWebsite);
            this.PAN_RecordInfo.Controls.Add(this.label10);
            this.PAN_RecordInfo.Controls.Add(this.txtEmailID);
            this.PAN_RecordInfo.Controls.Add(this.label9);
            this.PAN_RecordInfo.Controls.Add(this.txtPhoneNum);
            this.PAN_RecordInfo.Controls.Add(this.label7);
            this.PAN_RecordInfo.Controls.Add(this.TBX_Address);
            this.PAN_RecordInfo.Controls.Add(this.TXT_City);
            this.PAN_RecordInfo.Controls.Add(this.label2);
            this.PAN_RecordInfo.Controls.Add(this.label4);
            this.PAN_RecordInfo.Controls.Add(this.txtpincode);
            this.PAN_RecordInfo.Controls.Add(this.label5);
            this.PAN_RecordInfo.Controls.Add(this.txtAddInfo);
            this.PAN_RecordInfo.Controls.Add(this.lblAddInfo);
            this.PAN_RecordInfo.Controls.Add(this.txtCompname);
            this.PAN_RecordInfo.Controls.Add(this.lblCompName);
            this.PAN_RecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAN_RecordInfo.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PAN_RecordInfo.Location = new System.Drawing.Point(0, 0);
            this.PAN_RecordInfo.Name = "PAN_RecordInfo";
            this.PAN_RecordInfo.Size = new System.Drawing.Size(515, 504);
            this.PAN_RecordInfo.TabIndex = 25;
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbLogo.Location = new System.Drawing.Point(402, 8);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(102, 116);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 110;
            this.pbLogo.TabStop = false;
            this.pbLogo.DoubleClick += new System.EventHandler(this.pbLogo_DoubleClick);
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWebsite.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebsite.Location = new System.Drawing.Point(117, 104);
            this.txtWebsite.MaxLength = 254;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.ReadOnly = true;
            this.txtWebsite.Size = new System.Drawing.Size(278, 27);
            this.txtWebsite.TabIndex = 102;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 19);
            this.label10.TabIndex = 103;
            this.label10.Text = "Website";
            // 
            // txtEmailID
            // 
            this.txtEmailID.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailID.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtEmailID.Location = new System.Drawing.Point(117, 72);
            this.txtEmailID.MaxLength = 254;
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.ReadOnly = true;
            this.txtEmailID.Size = new System.Drawing.Size(278, 27);
            this.txtEmailID.TabIndex = 98;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 19);
            this.label9.TabIndex = 100;
            this.label9.Text = "Phone No.";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNum.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNum.Location = new System.Drawing.Point(117, 40);
            this.txtPhoneNum.MaxLength = 254;
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.ReadOnly = true;
            this.txtPhoneNum.Size = new System.Drawing.Size(278, 27);
            this.txtPhoneNum.TabIndex = 95;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 97;
            this.label7.Text = "EmailID";
            // 
            // TBX_Address
            // 
            this.TBX_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBX_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBX_Address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBX_Address.Location = new System.Drawing.Point(117, 136);
            this.TBX_Address.MaxLength = 1000000000;
            this.TBX_Address.Name = "TBX_Address";
            this.TBX_Address.ReadOnly = true;
            this.TBX_Address.Size = new System.Drawing.Size(387, 27);
            this.TBX_Address.TabIndex = 4;
            // 
            // TXT_City
            // 
            this.TXT_City.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_City.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_City.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_City.Location = new System.Drawing.Point(117, 168);
            this.TXT_City.MaxLength = 254;
            this.TXT_City.Name = "TXT_City";
            this.TXT_City.ReadOnly = true;
            this.TXT_City.Size = new System.Drawing.Size(387, 27);
            this.TXT_City.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 19);
            this.label2.TabIndex = 75;
            this.label2.Text = "City";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 19);
            this.label4.TabIndex = 77;
            this.label4.Text = "Address";
            // 
            // txtpincode
            // 
            this.txtpincode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtpincode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpincode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpincode.Location = new System.Drawing.Point(117, 200);
            this.txtpincode.MaximumSize = new System.Drawing.Size(56, 22);
            this.txtpincode.MaxLength = 9;
            this.txtpincode.Name = "txtpincode";
            this.txtpincode.ReadOnly = true;
            this.txtpincode.Size = new System.Drawing.Size(56, 22);
            this.txtpincode.TabIndex = 6;
            this.txtpincode.Text = "888888";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 76;
            this.label5.Text = "Pin Code";
            // 
            // txtAddInfo
            // 
            this.txtAddInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddInfo.Location = new System.Drawing.Point(117, 227);
            this.txtAddInfo.MaxLength = 999999999;
            this.txtAddInfo.Name = "txtAddInfo";
            this.txtAddInfo.ReadOnly = true;
            this.txtAddInfo.Size = new System.Drawing.Size(387, 27);
            this.txtAddInfo.TabIndex = 7;
            // 
            // lblAddInfo
            // 
            this.lblAddInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAddInfo.AutoSize = true;
            this.lblAddInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddInfo.Location = new System.Drawing.Point(14, 231);
            this.lblAddInfo.Name = "lblAddInfo";
            this.lblAddInfo.Size = new System.Drawing.Size(67, 19);
            this.lblAddInfo.TabIndex = 24;
            this.lblAddInfo.Text = "Remarks";
            // 
            // txtCompname
            // 
            this.txtCompname.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompname.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompname.Location = new System.Drawing.Point(117, 8);
            this.txtCompname.MaxLength = 1000000000;
            this.txtCompname.Name = "txtCompname";
            this.txtCompname.ReadOnly = true;
            this.txtCompname.Size = new System.Drawing.Size(279, 27);
            this.txtCompname.TabIndex = 0;
            // 
            // lblCompName
            // 
            this.lblCompName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompName.AutoSize = true;
            this.lblCompName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompName.Location = new System.Drawing.Point(14, 12);
            this.lblCompName.Name = "lblCompName";
            this.lblCompName.Size = new System.Drawing.Size(49, 19);
            this.lblCompName.TabIndex = 12;
            this.lblCompName.Text = "Name";
            // 
            // redCRUDAS1
            // 
            this.redCRUDAS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.redCRUDAS1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redCRUDAS1.Location = new System.Drawing.Point(0, 504);
            this.redCRUDAS1.Name = "redCRUDAS1";
            this.redCRUDAS1.RADUI_CtrSize = new System.Drawing.Size(81, 25);
            this.redCRUDAS1.RADUI_DataGridView = null;
            this.redCRUDAS1.RADUI_DataPanel = this.PAN_RecordInfo;
            this.redCRUDAS1.RADUI_State = RedRapidUI.RedCRUDAS.eCRUDASState.Find;
            this.redCRUDAS1.Size = new System.Drawing.Size(515, 37);
            this.redCRUDAS1.TabIndex = 8;
            this.redCRUDAS1.TotRecCount = 0;
            // 
            // FrmCompanyMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(932, 541);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCompanyMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCompanyMaster_FormClosing);
            this.Load += new System.EventHandler(this.FrmCompanyMaster_Load);
            this.Shown += new System.EventHandler(this.FrmCompanyMaster_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.PAN_RecordInfo.ResumeLayout(false);
            this.PAN_RecordInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private RedRapidUI.RedGridControl redGridControl1;
        private System.Windows.Forms.Panel PAN_RecordInfo;
        private System.Windows.Forms.TextBox txtAddInfo;
        private System.Windows.Forms.Label lblAddInfo;
        private System.Windows.Forms.TextBox txtCompname;
        private System.Windows.Forms.Label lblCompName;
        private RedRapidUI.RedCRUDAS redCRUDAS1;
        private System.Windows.Forms.TextBox TBX_Address;
        public System.Windows.Forms.TextBox TXT_City;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtpincode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.OpenFileDialog ofdImage;



    }
}