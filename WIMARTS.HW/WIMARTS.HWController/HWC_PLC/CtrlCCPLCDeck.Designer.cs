﻿namespace rcs.CONTROLS
{
    partial class CtrlPLCDeck
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlPLCDeck));
            this.pbConnectionState = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectionState)).BeginInit();
            this.SuspendLayout();
            // 
            // pbConnectionState
            // 
            this.pbConnectionState.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbConnectionState.Image = ((System.Drawing.Image)(resources.GetObject("pbConnectionState.Image")));
            this.pbConnectionState.Location = new System.Drawing.Point(35, 0);
            this.pbConnectionState.Name = "pbConnectionState";
            this.pbConnectionState.Size = new System.Drawing.Size(32, 28);
            this.pbConnectionState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbConnectionState.TabIndex = 14;
            this.pbConnectionState.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "HWC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CtrlPLCDeck
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbConnectionState);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(400, 150);
            this.Name = "CtrlPLCDeck";
            this.Size = new System.Drawing.Size(67, 28);
            this.Load += new System.EventHandler(this.CtrlPLCDeck_Load);
            this.Click += new System.EventHandler(this.CtrlPLCDeck_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pbConnectionState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbConnectionState;
        private System.Windows.Forms.Label label1;

    }
}
