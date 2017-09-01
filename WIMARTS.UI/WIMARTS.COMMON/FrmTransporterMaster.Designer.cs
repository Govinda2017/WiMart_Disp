namespace WIMARTS.COMMON
{
    partial class FrmTransporterMaster
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
            this.components = new System.ComponentModel.Container();
            this.txtTransporterName = new System.Windows.Forms.TextBox();
            this.txtPhoneNum1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.redGridControl1 = new RedRapidUI.RedGridControl();
            this.PAN_RecordInfo = new System.Windows.Forms.Panel();
            this.LBL_CustName = new System.Windows.Forms.Label();
            this.LBL_Pincode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpincode = new System.Windows.Forms.TextBox();
            this.TBX_Address = new System.Windows.Forms.TextBox();
            this.LBL_Addr = new System.Windows.Forms.Label();
            this.txtEmailID1 = new System.Windows.Forms.TextBox();
            this.TXT_City = new System.Windows.Forms.TextBox();
            this.LBL_City = new System.Windows.Forms.Label();
            this.redCRUDAS1 = new RedRapidUI.RedCRUDAS();
            this.epErrors = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PAN_RecordInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTransporterName
            // 
            this.txtTransporterName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransporterName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTransporterName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransporterName.Location = new System.Drawing.Point(123, 18);
            this.txtTransporterName.MaxLength = 49;
            this.txtTransporterName.Name = "txtTransporterName";
            this.txtTransporterName.Size = new System.Drawing.Size(225, 27);
            this.txtTransporterName.TabIndex = 0;
            // 
            // txtPhoneNum1
            // 
            this.txtPhoneNum1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNum1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNum1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPhoneNum1.Location = new System.Drawing.Point(123, 53);
            this.txtPhoneNum1.MaxLength = 254;
            this.txtPhoneNum1.Name = "txtPhoneNum1";
            this.txtPhoneNum1.Size = new System.Drawing.Size(225, 27);
            this.txtPhoneNum1.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 19);
            this.label7.TabIndex = 87;
            this.label7.Text = "EmailID";
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
            this.splitContainer1.Size = new System.Drawing.Size(660, 462);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 12;
            // 
            // redGridControl1
            // 
            this.redGridControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.redGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redGridControl1.Location = new System.Drawing.Point(0, 0);
            this.redGridControl1.Name = "redGridControl1";
            this.redGridControl1.Size = new System.Drawing.Size(295, 462);
            this.redGridControl1.TabIndex = 11;
            // 
            // PAN_RecordInfo
            // 
            this.PAN_RecordInfo.BackColor = System.Drawing.Color.Transparent;
            this.PAN_RecordInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PAN_RecordInfo.Controls.Add(this.LBL_CustName);
            this.PAN_RecordInfo.Controls.Add(this.txtTransporterName);
            this.PAN_RecordInfo.Controls.Add(this.txtPhoneNum1);
            this.PAN_RecordInfo.Controls.Add(this.label7);
            this.PAN_RecordInfo.Controls.Add(this.LBL_Pincode);
            this.PAN_RecordInfo.Controls.Add(this.label3);
            this.PAN_RecordInfo.Controls.Add(this.txtpincode);
            this.PAN_RecordInfo.Controls.Add(this.TBX_Address);
            this.PAN_RecordInfo.Controls.Add(this.LBL_Addr);
            this.PAN_RecordInfo.Controls.Add(this.txtEmailID1);
            this.PAN_RecordInfo.Controls.Add(this.TXT_City);
            this.PAN_RecordInfo.Controls.Add(this.LBL_City);
            this.PAN_RecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAN_RecordInfo.Location = new System.Drawing.Point(0, 0);
            this.PAN_RecordInfo.Name = "PAN_RecordInfo";
            this.PAN_RecordInfo.Size = new System.Drawing.Size(361, 423);
            this.PAN_RecordInfo.TabIndex = 12;
            // 
            // LBL_CustName
            // 
            this.LBL_CustName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_CustName.AutoSize = true;
            this.LBL_CustName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CustName.ForeColor = System.Drawing.Color.Black;
            this.LBL_CustName.Location = new System.Drawing.Point(13, 22);
            this.LBL_CustName.Name = "LBL_CustName";
            this.LBL_CustName.Size = new System.Drawing.Size(97, 19);
            this.LBL_CustName.TabIndex = 48;
            this.LBL_CustName.Text = "Transporter*";
            // 
            // LBL_Pincode
            // 
            this.LBL_Pincode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Pincode.AutoSize = true;
            this.LBL_Pincode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Pincode.Location = new System.Drawing.Point(13, 193);
            this.LBL_Pincode.Name = "LBL_Pincode";
            this.LBL_Pincode.Size = new System.Drawing.Size(69, 19);
            this.LBL_Pincode.TabIndex = 62;
            this.LBL_Pincode.Text = "Pin Code";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 86;
            this.label3.Text = "Contact No";
            // 
            // txtpincode
            // 
            this.txtpincode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtpincode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpincode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpincode.Location = new System.Drawing.Point(123, 191);
            this.txtpincode.MaximumSize = new System.Drawing.Size(56, 22);
            this.txtpincode.MaxLength = 9;
            this.txtpincode.Name = "txtpincode";
            this.txtpincode.Size = new System.Drawing.Size(56, 27);
            this.txtpincode.TabIndex = 14;
            this.txtpincode.Text = "888888";
            // 
            // TBX_Address
            // 
            this.TBX_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBX_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBX_Address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBX_Address.Location = new System.Drawing.Point(123, 121);
            this.TBX_Address.MaxLength = 254;
            this.TBX_Address.Name = "TBX_Address";
            this.TBX_Address.Size = new System.Drawing.Size(225, 27);
            this.TBX_Address.TabIndex = 12;
            // 
            // LBL_Addr
            // 
            this.LBL_Addr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Addr.AutoSize = true;
            this.LBL_Addr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Addr.Location = new System.Drawing.Point(13, 125);
            this.LBL_Addr.Name = "LBL_Addr";
            this.LBL_Addr.Size = new System.Drawing.Size(71, 19);
            this.LBL_Addr.TabIndex = 64;
            this.LBL_Addr.Text = "Address*";
            // 
            // txtEmailID1
            // 
            this.txtEmailID1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailID1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailID1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtEmailID1.Location = new System.Drawing.Point(123, 88);
            this.txtEmailID1.MaxLength = 254;
            this.txtEmailID1.Name = "txtEmailID1";
            this.txtEmailID1.Size = new System.Drawing.Size(225, 27);
            this.txtEmailID1.TabIndex = 8;
            // 
            // TXT_City
            // 
            this.TXT_City.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_City.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_City.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_City.Location = new System.Drawing.Point(123, 156);
            this.TXT_City.MaxLength = 254;
            this.TXT_City.Name = "TXT_City";
            this.TXT_City.Size = new System.Drawing.Size(225, 27);
            this.TXT_City.TabIndex = 13;
            // 
            // LBL_City
            // 
            this.LBL_City.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_City.AutoSize = true;
            this.LBL_City.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_City.Location = new System.Drawing.Point(13, 160);
            this.LBL_City.Name = "LBL_City";
            this.LBL_City.Size = new System.Drawing.Size(43, 19);
            this.LBL_City.TabIndex = 61;
            this.LBL_City.Text = "City*";
            // 
            // redCRUDAS1
            // 
            this.redCRUDAS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.redCRUDAS1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redCRUDAS1.Location = new System.Drawing.Point(0, 423);
            this.redCRUDAS1.Name = "redCRUDAS1";
            this.redCRUDAS1.RADUI_CtrSize = new System.Drawing.Size(81, 25);
            this.redCRUDAS1.RADUI_DataGridView = null;
            this.redCRUDAS1.RADUI_DataPanel = null;
            this.redCRUDAS1.RADUI_State = RedRapidUI.RedCRUDAS.eCRUDASState.Find;
            this.redCRUDAS1.Size = new System.Drawing.Size(361, 39);
            this.redCRUDAS1.TabIndex = 16;
            this.redCRUDAS1.TotRecCount = 0;
            // 
            // epErrors
            // 
            this.epErrors.ContainerControl = this;
            // 
            // FrmTransporterMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(660, 462);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmTransporterMaster";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transporter";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTransporterMaster_Load);
            this.Shown += new System.EventHandler(this.FrmTransporterMaster_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.PAN_RecordInfo.ResumeLayout(false);
            this.PAN_RecordInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTransporterName;
        private System.Windows.Forms.TextBox txtPhoneNum1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private RedRapidUI.RedGridControl redGridControl1;
        private System.Windows.Forms.Panel PAN_RecordInfo;
        private System.Windows.Forms.Label LBL_CustName;
        private System.Windows.Forms.Label LBL_Pincode;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtpincode;
        private System.Windows.Forms.TextBox TBX_Address;
        private System.Windows.Forms.Label LBL_Addr;
        private System.Windows.Forms.TextBox txtEmailID1;
        public System.Windows.Forms.TextBox TXT_City;
        private System.Windows.Forms.Label LBL_City;
        private RedRapidUI.RedCRUDAS redCRUDAS1;
        private System.Windows.Forms.ErrorProvider epErrors;
    }
}