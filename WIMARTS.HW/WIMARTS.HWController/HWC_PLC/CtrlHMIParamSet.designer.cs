namespace CondotCombiSys.Controls
{
    partial class CtrlHMIParamSet
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
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.lblTestParam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOff
            // 
            this.btnOff.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOff.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOff.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOff.ForeColor = System.Drawing.Color.Black;
            this.btnOff.Location = new System.Drawing.Point(240, 0);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(80, 24);
            this.btnOff.TabIndex = 1;
            this.btnOff.Text = "OFF";
            this.btnOff.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOff.UseVisualStyleBackColor = false;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOn.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOn.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOn.ForeColor = System.Drawing.Color.Black;
            this.btnOn.Location = new System.Drawing.Point(160, 0);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(80, 24);
            this.btnOn.TabIndex = 0;
            this.btnOn.Text = "ON";
            this.btnOn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOn.UseVisualStyleBackColor = false;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // lblTestParam
            // 
            this.lblTestParam.BackColor = System.Drawing.Color.White;
            this.lblTestParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTestParam.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblTestParam.ForeColor = System.Drawing.Color.Black;
            this.lblTestParam.Location = new System.Drawing.Point(0, 0);
            this.lblTestParam.Name = "lblTestParam";
            this.lblTestParam.Size = new System.Drawing.Size(160, 24);
            this.lblTestParam.TabIndex = 2;
            this.lblTestParam.Text = "Parameter";
            this.lblTestParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CtrlHMIParamSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lblTestParam);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.btnOff);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(320, 24);
            this.Name = "CtrlHMIParamSet";
            this.Size = new System.Drawing.Size(320, 24);
            this.Load += new System.EventHandler(this.CtrlHMIParamSet_Load);
            this.Click += new System.EventHandler(this.CtrlHMIParamSet_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Label lblTestParam;


    }
}
