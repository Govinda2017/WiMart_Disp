namespace WIMARTS.DISPATCH
{
    partial class Splash
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splash));
            this.btnExit = new System.Windows.Forms.Button();
            this.DG_CheckList = new System.Windows.Forms.DataGridView();
            this.StatusIcon = new System.Windows.Forms.DataGridViewImageColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LBLCopyRight = new System.Windows.Forms.Label();
            this.LBLCompany = new System.Windows.Forms.Label();
            this.LBLDescription = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LBL_LicHolder = new System.Windows.Forms.Label();
            this.LBLProductName = new System.Windows.Forms.Label();
            this.LBL_Today = new System.Windows.Forms.Label();
            this.lblPlantName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatusBar = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DG_CheckList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.FlatAppearance.BorderSize = 2;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(995, 1);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(27, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // DG_CheckList
            // 
            this.DG_CheckList.AllowUserToAddRows = false;
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.Moccasin;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_CheckList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle19;
            this.DG_CheckList.BackgroundColor = System.Drawing.Color.White;
            this.DG_CheckList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_CheckList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DG_CheckList.ColumnHeadersHeight = 30;
            this.DG_CheckList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DG_CheckList.ColumnHeadersVisible = false;
            this.DG_CheckList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StatusIcon,
            this.Description,
            this.Status});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DG_CheckList.DefaultCellStyle = dataGridViewCellStyle22;
            this.DG_CheckList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_CheckList.Location = new System.Drawing.Point(9, 498);
            this.DG_CheckList.Name = "DG_CheckList";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DG_CheckList.RowHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.DG_CheckList.RowHeadersVisible = false;
            this.DG_CheckList.RowHeadersWidth = 40;
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_CheckList.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.DG_CheckList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.DG_CheckList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DG_CheckList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DG_CheckList.RowTemplate.Height = 40;
            this.DG_CheckList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DG_CheckList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DG_CheckList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG_CheckList.ShowCellErrors = false;
            this.DG_CheckList.ShowCellToolTips = false;
            this.DG_CheckList.ShowEditingIcon = false;
            this.DG_CheckList.ShowRowErrors = false;
            this.DG_CheckList.Size = new System.Drawing.Size(492, 161);
            this.DG_CheckList.StandardTab = true;
            this.DG_CheckList.TabIndex = 25;
            this.DG_CheckList.TabStop = false;
            // 
            // StatusIcon
            // 
            this.StatusIcon.HeaderText = "";
            this.StatusIcon.Name = "StatusIcon";
            this.StatusIcon.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.StatusIcon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.StatusIcon.Width = 35;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.DefaultCellStyle = dataGridViewCellStyle21;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.Width = 120;
            // 
            // LBLCopyRight
            // 
            this.LBLCopyRight.BackColor = System.Drawing.Color.White;
            this.LBLCopyRight.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCopyRight.ForeColor = System.Drawing.Color.DarkRed;
            this.LBLCopyRight.Location = new System.Drawing.Point(507, 590);
            this.LBLCopyRight.Name = "LBLCopyRight";
            this.LBLCopyRight.Size = new System.Drawing.Size(428, 34);
            this.LBLCopyRight.TabIndex = 28;
            this.LBLCopyRight.Text = "CR";
            // 
            // LBLCompany
            // 
            this.LBLCompany.BackColor = System.Drawing.Color.White;
            this.LBLCompany.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLCompany.ForeColor = System.Drawing.Color.DarkRed;
            this.LBLCompany.Location = new System.Drawing.Point(507, 544);
            this.LBLCompany.Name = "LBLCompany";
            this.LBLCompany.Size = new System.Drawing.Size(428, 34);
            this.LBLCompany.TabIndex = 27;
            this.LBLCompany.Text = "Company";
            // 
            // LBLDescription
            // 
            this.LBLDescription.BackColor = System.Drawing.Color.White;
            this.LBLDescription.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDescription.ForeColor = System.Drawing.Color.DarkRed;
            this.LBLDescription.Location = new System.Drawing.Point(507, 498);
            this.LBLDescription.Name = "LBLDescription";
            this.LBLDescription.Size = new System.Drawing.Size(428, 34);
            this.LBLDescription.TabIndex = 26;
            this.LBLDescription.Text = "Product Description";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(3, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(960, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "SYSTEM LICENSED TO";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBL_LicHolder
            // 
            this.LBL_LicHolder.BackColor = System.Drawing.Color.White;
            this.LBL_LicHolder.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_LicHolder.ForeColor = System.Drawing.Color.Red;
            this.LBL_LicHolder.Location = new System.Drawing.Point(4, 133);
            this.LBL_LicHolder.Name = "LBL_LicHolder";
            this.LBL_LicHolder.Size = new System.Drawing.Size(960, 48);
            this.LBL_LicHolder.TabIndex = 34;
            this.LBL_LicHolder.Text = "Client Name";
            this.LBL_LicHolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBLProductName
            // 
            this.LBLProductName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LBLProductName.BackColor = System.Drawing.Color.White;
            this.LBLProductName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLProductName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.LBLProductName.Location = new System.Drawing.Point(670, 65);
            this.LBLProductName.Name = "LBLProductName";
            this.LBLProductName.Size = new System.Drawing.Size(221, 37);
            this.LBLProductName.TabIndex = 33;
            this.LBLProductName.Text = "Product Name && Version";
            this.LBLProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LBL_Today
            // 
            this.LBL_Today.BackColor = System.Drawing.Color.White;
            this.LBL_Today.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Today.ForeColor = System.Drawing.Color.Black;
            this.LBL_Today.Location = new System.Drawing.Point(4, 216);
            this.LBL_Today.Name = "LBL_Today";
            this.LBL_Today.Size = new System.Drawing.Size(960, 26);
            this.LBL_Today.TabIndex = 36;
            this.LBL_Today.Text = "Today\'s Date";
            this.LBL_Today.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LBL_Today.Visible = false;
            // 
            // lblPlantName
            // 
            this.lblPlantName.BackColor = System.Drawing.Color.White;
            this.lblPlantName.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlantName.ForeColor = System.Drawing.Color.Red;
            this.lblPlantName.Location = new System.Drawing.Point(4, 181);
            this.lblPlantName.Name = "lblPlantName";
            this.lblPlantName.Size = new System.Drawing.Size(958, 35);
            this.lblPlantName.TabIndex = 37;
            this.lblPlantName.Text = "Plant && Line Name";
            this.lblPlantName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(342, 248);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(283, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.LBLProductName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.DG_CheckList);
            this.panel1.Controls.Add(this.LBLCopyRight);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LBLCompany);
            this.panel1.Controls.Add(this.LBLDescription);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblPlantName);
            this.panel1.Controls.Add(this.LBL_LicHolder);
            this.panel1.Controls.Add(this.LBL_Today);
            this.panel1.Location = new System.Drawing.Point(29, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 675);
            this.panel1.TabIndex = 39;
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusBar.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusBar.Location = new System.Drawing.Point(0, 709);
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(1024, 41);
            this.lblStatusBar.TabIndex = 40;
            this.lblStatusBar.Text = "Redivivus Technologies Private Limited";
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(273, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 98);
            this.label1.TabIndex = 39;
            this.label1.Text = "w!maRts";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Splash
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(179)))), ((int)(((byte)(204)))));
            this.ClientSize = new System.Drawing.Size(1024, 750);
            this.Controls.Add(this.lblStatusBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Splash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "wimaRts";
            this.Load += new System.EventHandler(this.Splash_Load);
            this.Shown += new System.EventHandler(this.Splash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.DG_CheckList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView DG_CheckList;
        private System.Windows.Forms.DataGridViewImageColumn StatusIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Label LBLCopyRight;
        private System.Windows.Forms.Label LBLCompany;
        private System.Windows.Forms.Label LBLDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LBL_LicHolder;
        private System.Windows.Forms.Label LBLProductName;
        private System.Windows.Forms.Label LBL_Today;
        private System.Windows.Forms.Label lblPlantName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatusBar;
        private System.Windows.Forms.Label label1;

    }
}