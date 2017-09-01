namespace WIMARTS.COMMON
{
    partial class FrmCustomerMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomerMaster));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.redGridControl1 = new RedRapidUI.RedGridControl();
            this.PAN_RecordInfo = new System.Windows.Forms.Panel();
            this.LBL_CustName = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.LBL_AddInfo = new System.Windows.Forms.Label();
            this.txtAdditionalInfo = new System.Windows.Forms.TextBox();
            this.LBL_Pincode = new System.Windows.Forms.Label();
            this.txtpincode = new System.Windows.Forms.TextBox();
            this.LBL_Addr = new System.Windows.Forms.Label();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.LBL_City = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TXT_City = new System.Windows.Forms.TextBox();
            this.txtEmailID1 = new System.Windows.Forms.TextBox();
            this.TBX_Address = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPhoneNum1 = new System.Windows.Forms.TextBox();
            this.redCRUDAS1 = new RedRapidUI.RedCRUDAS();
            this.epErrors = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.PAN_RecordInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epErrors)).BeginInit();
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
            this.splitContainer1.Size = new System.Drawing.Size(797, 541);
            this.splitContainer1.SplitterDistance = 357;
            this.splitContainer1.TabIndex = 11;
            // 
            // redGridControl1
            // 
            this.redGridControl1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.redGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.redGridControl1.Location = new System.Drawing.Point(0, 0);
            this.redGridControl1.Name = "redGridControl1";
            this.redGridControl1.Size = new System.Drawing.Size(357, 541);
            this.redGridControl1.TabIndex = 11;
            // 
            // PAN_RecordInfo
            // 
            this.PAN_RecordInfo.BackColor = System.Drawing.Color.Transparent;
            this.PAN_RecordInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PAN_RecordInfo.Controls.Add(this.LBL_CustName);
            this.PAN_RecordInfo.Controls.Add(this.txtCustName);
            this.PAN_RecordInfo.Controls.Add(this.LBL_AddInfo);
            this.PAN_RecordInfo.Controls.Add(this.txtPhoneNum1);
            this.PAN_RecordInfo.Controls.Add(this.txtAdditionalInfo);
            this.PAN_RecordInfo.Controls.Add(this.label7);
            this.PAN_RecordInfo.Controls.Add(this.LBL_Pincode);
            this.PAN_RecordInfo.Controls.Add(this.label3);
            this.PAN_RecordInfo.Controls.Add(this.txtpincode);
            this.PAN_RecordInfo.Controls.Add(this.TBX_Address);
            this.PAN_RecordInfo.Controls.Add(this.LBL_Addr);
            this.PAN_RecordInfo.Controls.Add(this.txtEmailID1);
            this.PAN_RecordInfo.Controls.Add(this.txtWebsite);
            this.PAN_RecordInfo.Controls.Add(this.TXT_City);
            this.PAN_RecordInfo.Controls.Add(this.LBL_City);
            this.PAN_RecordInfo.Controls.Add(this.label10);
            this.PAN_RecordInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PAN_RecordInfo.Location = new System.Drawing.Point(0, 0);
            this.PAN_RecordInfo.Name = "PAN_RecordInfo";
            this.PAN_RecordInfo.Size = new System.Drawing.Size(436, 502);
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
            this.LBL_CustName.Size = new System.Drawing.Size(82, 19);
            this.LBL_CustName.TabIndex = 48;
            this.LBL_CustName.Text = "Customer*";
            // 
            // txtCustName
            // 
            this.txtCustName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustName.Location = new System.Drawing.Point(123, 18);
            this.txtCustName.MaxLength = 49;
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(300, 27);
            this.txtCustName.TabIndex = 0;
            this.txtCustName.Validating += new System.ComponentModel.CancelEventHandler(this.txtCustName_Validating);
            // 
            // LBL_AddInfo
            // 
            this.LBL_AddInfo.AutoSize = true;
            this.LBL_AddInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_AddInfo.Location = new System.Drawing.Point(13, 262);
            this.LBL_AddInfo.Name = "LBL_AddInfo";
            this.LBL_AddInfo.Size = new System.Drawing.Size(67, 19);
            this.LBL_AddInfo.TabIndex = 56;
            this.LBL_AddInfo.Text = "Remarks";
            // 
            // txtAdditionalInfo
            // 
            this.txtAdditionalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdditionalInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdditionalInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalInfo.Location = new System.Drawing.Point(123, 258);
            this.txtAdditionalInfo.MaxLength = 254;
            this.txtAdditionalInfo.Name = "txtAdditionalInfo";
            this.txtAdditionalInfo.Size = new System.Drawing.Size(300, 27);
            this.txtAdditionalInfo.TabIndex = 11;
            // 
            // LBL_Pincode
            // 
            this.LBL_Pincode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Pincode.AutoSize = true;
            this.LBL_Pincode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Pincode.Location = new System.Drawing.Point(13, 230);
            this.LBL_Pincode.Name = "LBL_Pincode";
            this.LBL_Pincode.Size = new System.Drawing.Size(69, 19);
            this.LBL_Pincode.TabIndex = 62;
            this.LBL_Pincode.Text = "Pin Code";
            // 
            // txtpincode
            // 
            this.txtpincode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtpincode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtpincode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpincode.Location = new System.Drawing.Point(123, 228);
            this.txtpincode.MaximumSize = new System.Drawing.Size(56, 22);
            this.txtpincode.MaxLength = 9;
            this.txtpincode.Name = "txtpincode";
            this.txtpincode.Size = new System.Drawing.Size(56, 22);
            this.txtpincode.TabIndex = 14;
            this.txtpincode.Text = "888888";
            // 
            // LBL_Addr
            // 
            this.LBL_Addr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Addr.AutoSize = true;
            this.LBL_Addr.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Addr.Location = new System.Drawing.Point(13, 162);
            this.LBL_Addr.Name = "LBL_Addr";
            this.LBL_Addr.Size = new System.Drawing.Size(71, 19);
            this.LBL_Addr.TabIndex = 64;
            this.LBL_Addr.Text = "Address*";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWebsite.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebsite.Location = new System.Drawing.Point(123, 123);
            this.txtWebsite.MaxLength = 254;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(300, 27);
            this.txtWebsite.TabIndex = 10;
            // 
            // LBL_City
            // 
            this.LBL_City.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_City.AutoSize = true;
            this.LBL_City.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_City.Location = new System.Drawing.Point(13, 197);
            this.LBL_City.Name = "LBL_City";
            this.LBL_City.Size = new System.Drawing.Size(43, 19);
            this.LBL_City.TabIndex = 61;
            this.LBL_City.Text = "City*";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 19);
            this.label10.TabIndex = 93;
            this.label10.Text = "Website";
            // 
            // TXT_City
            // 
            this.TXT_City.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_City.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TXT_City.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_City.Location = new System.Drawing.Point(123, 193);
            this.TXT_City.MaxLength = 254;
            this.TXT_City.Name = "TXT_City";
            this.TXT_City.Size = new System.Drawing.Size(300, 27);
            this.TXT_City.TabIndex = 13;
            this.TXT_City.Validating += new System.ComponentModel.CancelEventHandler(this.TXT_City_Validating);
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
            this.txtEmailID1.Size = new System.Drawing.Size(300, 27);
            this.txtEmailID1.TabIndex = 8;
            // 
            // TBX_Address
            // 
            this.TBX_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TBX_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TBX_Address.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBX_Address.Location = new System.Drawing.Point(123, 158);
            this.TBX_Address.MaxLength = 254;
            this.TBX_Address.Name = "TBX_Address";
            this.TBX_Address.Size = new System.Drawing.Size(300, 27);
            this.TBX_Address.TabIndex = 12;
            this.TBX_Address.Validating += new System.ComponentModel.CancelEventHandler(this.TBX_Address_Validating);
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
            this.txtPhoneNum1.Size = new System.Drawing.Size(300, 27);
            this.txtPhoneNum1.TabIndex = 6;
            // 
            // redCRUDAS1
            // 
            this.redCRUDAS1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.redCRUDAS1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.redCRUDAS1.Location = new System.Drawing.Point(0, 502);
            this.redCRUDAS1.Name = "redCRUDAS1";
            this.redCRUDAS1.RADUI_CtrSize = new System.Drawing.Size(81, 25);
            this.redCRUDAS1.RADUI_DataGridView = null;
            this.redCRUDAS1.RADUI_DataPanel = null;
            this.redCRUDAS1.RADUI_State = RedRapidUI.RedCRUDAS.eCRUDASState.Find;
            this.redCRUDAS1.Size = new System.Drawing.Size(436, 39);
            this.redCRUDAS1.TabIndex = 16;
            this.redCRUDAS1.TotRecCount = 0;
            // 
            // epErrors
            // 
            this.epErrors.ContainerControl = this;
            // 
            // FrmCustomerMaster
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(797, 541);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCustomerMaster";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCustomerMaster_FormClosing);
            this.Load += new System.EventHandler(this.FrmCustomerMaster_Load);
            this.Shown += new System.EventHandler(this.FrmCustomerMaster_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.PAN_RecordInfo.ResumeLayout(false);
            this.PAN_RecordInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       private System.Windows.Forms.SplitContainer splitContainer1;
       private RedRapidUI.RedGridControl redGridControl1;
       private System.Windows.Forms.Panel PAN_RecordInfo;
       private System.Windows.Forms.TextBox TBX_Address;
       public System.Windows.Forms.TextBox TXT_City;
       private System.Windows.Forms.Label LBL_City;
       private System.Windows.Forms.Label LBL_Addr;
       public System.Windows.Forms.TextBox txtpincode;
       private System.Windows.Forms.Label LBL_Pincode;
       private System.Windows.Forms.TextBox txtAdditionalInfo;
       private System.Windows.Forms.Label LBL_AddInfo;
       private System.Windows.Forms.TextBox txtCustName;
       private System.Windows.Forms.Label LBL_CustName;
       private RedRapidUI.RedCRUDAS redCRUDAS1;
       private System.Windows.Forms.TextBox txtWebsite;
       private System.Windows.Forms.Label label10;
       private System.Windows.Forms.TextBox txtEmailID1;
       private System.Windows.Forms.TextBox txtPhoneNum1;
       private System.Windows.Forms.Label label7;
       private System.Windows.Forms.Label label3;
       private System.Windows.Forms.ErrorProvider epErrors;
    }
}

