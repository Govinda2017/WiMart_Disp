namespace WIMARTS.MANAGER
{
    partial class FrmMDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mASTERSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserMaster = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmWIMARTSerSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.inspectionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dispatchMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxWastageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxWastageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.transporterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mASTERSToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.dispatchToolStripMenuItem,
            this.boxWastageToolStripMenuItem,
            this.reportToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mASTERSToolStripMenuItem
            // 
            this.mASTERSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUserMaster,
            this.tsmWIMARTSerSetting,
            this.inspectionSettingsToolStripMenuItem,
            this.applicationSettingsToolStripMenuItem});
            this.mASTERSToolStripMenuItem.Name = "mASTERSToolStripMenuItem";
            this.mASTERSToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.mASTERSToolStripMenuItem.Text = "&Settings";
            // 
            // tsmiUserMaster
            // 
            this.tsmiUserMaster.Name = "tsmiUserMaster";
            this.tsmiUserMaster.Size = new System.Drawing.Size(180, 22);
            this.tsmiUserMaster.Text = "&Users";
            this.tsmiUserMaster.Click += new System.EventHandler(this.tsmiUserMaster_Click);
            // 
            // tsmWIMARTSerSetting
            // 
            this.tsmWIMARTSerSetting.Name = "tsmWIMARTSerSetting";
            this.tsmWIMARTSerSetting.Size = new System.Drawing.Size(180, 22);
            this.tsmWIMARTSerSetting.Text = "&HWC Settings";
            this.tsmWIMARTSerSetting.Click += new System.EventHandler(this.tsmWIMARTSerSetting_Click);
            // 
            // inspectionSettingsToolStripMenuItem
            // 
            this.inspectionSettingsToolStripMenuItem.Name = "inspectionSettingsToolStripMenuItem";
            this.inspectionSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.inspectionSettingsToolStripMenuItem.Text = "&Inspection Settings";
            this.inspectionSettingsToolStripMenuItem.Click += new System.EventHandler(this.inspectionSettingsToolStripMenuItem_Click);
            // 
            // applicationSettingsToolStripMenuItem
            // 
            this.applicationSettingsToolStripMenuItem.Name = "applicationSettingsToolStripMenuItem";
            this.applicationSettingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.applicationSettingsToolStripMenuItem.Text = "&Application Settings";
            this.applicationSettingsToolStripMenuItem.Click += new System.EventHandler(this.applicationSettingsToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.companyToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.transporterToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "&Master";
            // 
            // companyToolStripMenuItem
            // 
            this.companyToolStripMenuItem.Name = "companyToolStripMenuItem";
            this.companyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.companyToolStripMenuItem.Text = "&Company";
            this.companyToolStripMenuItem.Click += new System.EventHandler(this.companyToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customerToolStripMenuItem.Text = "C&ustomer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // dispatchToolStripMenuItem
            // 
            this.dispatchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dispatchMasterToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.pickListToolStripMenuItem});
            this.dispatchToolStripMenuItem.Name = "dispatchToolStripMenuItem";
            this.dispatchToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.dispatchToolStripMenuItem.Text = "&Dispatch";
            // 
            // dispatchMasterToolStripMenuItem
            // 
            this.dispatchMasterToolStripMenuItem.Name = "dispatchMasterToolStripMenuItem";
            this.dispatchMasterToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.dispatchMasterToolStripMenuItem.Text = "&Add";
            this.dispatchMasterToolStripMenuItem.Click += new System.EventHandler(this.dispatchMasterToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // pickListToolStripMenuItem
            // 
            this.pickListToolStripMenuItem.Name = "pickListToolStripMenuItem";
            this.pickListToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.pickListToolStripMenuItem.Text = "&Pick List";
            this.pickListToolStripMenuItem.Click += new System.EventHandler(this.pickListToolStripMenuItem_Click);
            // 
            // boxWastageToolStripMenuItem
            // 
            this.boxWastageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxWastageToolStripMenuItem1});
            this.boxWastageToolStripMenuItem.Name = "boxWastageToolStripMenuItem";
            this.boxWastageToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.boxWastageToolStripMenuItem.Text = "&Wastage";
            // 
            // boxWastageToolStripMenuItem1
            // 
            this.boxWastageToolStripMenuItem1.Name = "boxWastageToolStripMenuItem1";
            this.boxWastageToolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.boxWastageToolStripMenuItem1.Text = "Box &Wastage";
            this.boxWastageToolStripMenuItem1.Click += new System.EventHandler(this.boxWastageToolStripMenuItem1_Click);
            // 
            // reportToolStripMenuItem1
            // 
            this.reportToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem2});
            this.reportToolStripMenuItem1.Name = "reportToolStripMenuItem1";
            this.reportToolStripMenuItem1.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem1.Text = "&Report";
            // 
            // reportToolStripMenuItem2
            // 
            this.reportToolStripMenuItem2.Name = "reportToolStripMenuItem2";
            this.reportToolStripMenuItem2.Size = new System.Drawing.Size(109, 22);
            this.reportToolStripMenuItem2.Text = "&Report";
            this.reportToolStripMenuItem2.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // transporterToolStripMenuItem
            // 
            this.transporterToolStripMenuItem.Name = "transporterToolStripMenuItem";
            this.transporterToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.transporterToolStripMenuItem.Text = "Transporter";
            this.transporterToolStripMenuItem.Click += new System.EventHandler(this.transporterToolStripMenuItem_Click);
            // 
            // FrmMDI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(885, 499);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMDI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MANAGER";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMDI_Load);
            this.Shown += new System.EventHandler(this.MdiManager_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mASTERSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserMaster;
        private System.Windows.Forms.ToolStripMenuItem tsmWIMARTSerSetting;
        private System.Windows.Forms.ToolStripMenuItem inspectionSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dispatchMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem boxWastageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxWastageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transporterToolStripMenuItem;
    }
}