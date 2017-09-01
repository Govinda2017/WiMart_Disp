namespace WIMARTS.UTIL
{
    partial class RedMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RedMessageBox));
            this.BTN_Panel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.HeaderMessage = new System.Windows.Forms.Label();
            this.TBLLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.TabelPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Header = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TBLLayoutPanel.SuspendLayout();
            this.TabelPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Panel
            // 
            this.BTN_Panel.BackColor = System.Drawing.Color.Transparent;
            this.BTN_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BTN_Panel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.BTN_Panel.Location = new System.Drawing.Point(3, 215);
            this.BTN_Panel.Name = "BTN_Panel";
            this.BTN_Panel.Size = new System.Drawing.Size(583, 44);
            this.BTN_Panel.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 58);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // HeaderMessage
            // 
            this.HeaderMessage.AutoSize = true;
            this.HeaderMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeaderMessage.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HeaderMessage.Location = new System.Drawing.Point(82, 10);
            this.HeaderMessage.Margin = new System.Windows.Forms.Padding(10);
            this.HeaderMessage.Name = "HeaderMessage";
            this.HeaderMessage.Size = new System.Drawing.Size(491, 146);
            this.HeaderMessage.TabIndex = 2;
            this.HeaderMessage.Text = "Dialog message.";
            // 
            // TBLLayoutPanel
            // 
            this.TBLLayoutPanel.AutoSize = true;
            this.TBLLayoutPanel.BackColor = System.Drawing.Color.PowderBlue;
            this.TBLLayoutPanel.ColumnCount = 2;
            this.TBLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 72F));
            this.TBLLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TBLLayoutPanel.Controls.Add(this.pictureBox1, 0, 0);
            this.TBLLayoutPanel.Controls.Add(this.HeaderMessage, 1, 0);
            this.TBLLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TBLLayoutPanel.Location = new System.Drawing.Point(3, 43);
            this.TBLLayoutPanel.Name = "TBLLayoutPanel";
            this.TBLLayoutPanel.RowCount = 1;
            this.TBLLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TBLLayoutPanel.Size = new System.Drawing.Size(583, 166);
            this.TBLLayoutPanel.TabIndex = 1;
            // 
            // TabelPanel
            // 
            this.TabelPanel.AutoSize = true;
            this.TabelPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.TabelPanel.ColumnCount = 1;
            this.TabelPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TabelPanel.Controls.Add(this.TBLLayoutPanel, 0, 1);
            this.TabelPanel.Controls.Add(this.BTN_Panel, 0, 2);
            this.TabelPanel.Controls.Add(this.Header, 0, 0);
            this.TabelPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabelPanel.Location = new System.Drawing.Point(0, 0);
            this.TabelPanel.Name = "TabelPanel";
            this.TabelPanel.RowCount = 3;
            this.TabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.TabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TabelPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TabelPanel.Size = new System.Drawing.Size(589, 262);
            this.TabelPanel.TabIndex = 7;
            // 
            // Header
            // 
            this.Header.AutoSize = true;
            this.Header.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Header.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.Header.Location = new System.Drawing.Point(3, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(583, 40);
            this.Header.TabIndex = 4;
            this.Header.Text = "label1";
            this.Header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RedMessageBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(589, 262);
            this.Controls.Add(this.TabelPanel);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RedMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog Box";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TBLLayoutPanel.ResumeLayout(false);
            this.TBLLayoutPanel.PerformLayout();
            this.TabelPanel.ResumeLayout(false);
            this.TabelPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel BTN_Panel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label HeaderMessage;
        private System.Windows.Forms.TableLayoutPanel TBLLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel TabelPanel;
        private System.Windows.Forms.Label Header;
    }
}