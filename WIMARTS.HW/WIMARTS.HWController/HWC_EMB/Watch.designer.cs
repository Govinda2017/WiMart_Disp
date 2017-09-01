namespace WIMARTS.HWController
{
    partial class Watch
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
            this.DG_View = new System.Windows.Forms.DataGridView();
            this.Num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataVal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BTN_Clear = new System.Windows.Forms.Button();
            this.TXT_SerialLog = new System.Windows.Forms.TextBox();
            this.TXT_Hex = new System.Windows.Forms.TextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.TXT_CMD2Send1 = new System.Windows.Forms.TextBox();
            this.BTN_Send1 = new System.Windows.Forms.Button();
            this.BTN_Send2 = new System.Windows.Forms.Button();
            this.TXT_CMD2Send2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.BTN_Send3 = new System.Windows.Forms.Button();
            this.TXT_CMD2Send3 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DG_View)).BeginInit();
            this.SuspendLayout();
            // 
            // DG_View
            // 
            this.DG_View.AllowUserToAddRows = false;
            this.DG_View.AllowUserToDeleteRows = false;
            this.DG_View.AllowUserToResizeRows = false;
            this.DG_View.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DG_View.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG_View.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Num,
            this.Port,
            this.Flow,
            this.DataVal,
            this.Details,
            this.Start,
            this.End});
            this.DG_View.Location = new System.Drawing.Point(0, 0);
            this.DG_View.Name = "DG_View";
            this.DG_View.RowHeadersVisible = false;
            this.DG_View.Size = new System.Drawing.Size(628, 247);
            this.DG_View.TabIndex = 0;
            // 
            // Num
            // 
            this.Num.HeaderText = "#";
            this.Num.Name = "Num";
            this.Num.Width = 25;
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.Width = 75;
            // 
            // Flow
            // 
            this.Flow.HeaderText = "Flow";
            this.Flow.Name = "Flow";
            this.Flow.Width = 75;
            // 
            // DataVal
            // 
            this.DataVal.HeaderText = "Data";
            this.DataVal.Name = "DataVal";
            // 
            // Details
            // 
            this.Details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Details.HeaderText = "Details";
            this.Details.MinimumWidth = 50;
            this.Details.Name = "Details";
            // 
            // Start
            // 
            this.Start.HeaderText = "Start";
            this.Start.Name = "Start";
            // 
            // End
            // 
            this.End.HeaderText = "End";
            this.End.Name = "End";
            // 
            // BTN_Clear
            // 
            this.BTN_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Clear.Location = new System.Drawing.Point(629, 0);
            this.BTN_Clear.Name = "BTN_Clear";
            this.BTN_Clear.Size = new System.Drawing.Size(52, 27);
            this.BTN_Clear.TabIndex = 1;
            this.BTN_Clear.Text = "&Clear";
            this.BTN_Clear.UseVisualStyleBackColor = true;
            this.BTN_Clear.Click += new System.EventHandler(this.BTN_Clear_Click);
            // 
            // TXT_SerialLog
            // 
            this.TXT_SerialLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_SerialLog.Location = new System.Drawing.Point(0, 253);
            this.TXT_SerialLog.Multiline = true;
            this.TXT_SerialLog.Name = "TXT_SerialLog";
            this.TXT_SerialLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TXT_SerialLog.Size = new System.Drawing.Size(342, 224);
            this.TXT_SerialLog.TabIndex = 2;
            // 
            // TXT_Hex
            // 
            this.TXT_Hex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_Hex.Location = new System.Drawing.Point(346, 253);
            this.TXT_Hex.Multiline = true;
            this.TXT_Hex.Name = "TXT_Hex";
            this.TXT_Hex.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TXT_Hex.Size = new System.Drawing.Size(282, 224);
            this.TXT_Hex.TabIndex = 3;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Save.Location = new System.Drawing.Point(629, 33);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(52, 27);
            this.BTN_Save.TabIndex = 4;
            this.BTN_Save.Text = "&Save";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // TXT_CMD2Send1
            // 
            this.TXT_CMD2Send1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_CMD2Send1.Location = new System.Drawing.Point(0, 483);
            this.TXT_CMD2Send1.Name = "TXT_CMD2Send1";
            this.TXT_CMD2Send1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TXT_CMD2Send1.Size = new System.Drawing.Size(628, 20);
            this.TXT_CMD2Send1.TabIndex = 5;
            // 
            // BTN_Send1
            // 
            this.BTN_Send1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Send1.Location = new System.Drawing.Point(629, 480);
            this.BTN_Send1.Name = "BTN_Send1";
            this.BTN_Send1.Size = new System.Drawing.Size(52, 27);
            this.BTN_Send1.TabIndex = 6;
            this.BTN_Send1.Text = "Send &1";
            this.BTN_Send1.UseVisualStyleBackColor = true;
            this.BTN_Send1.Click += new System.EventHandler(this.BTN_Send_Click);
            // 
            // BTN_Send2
            // 
            this.BTN_Send2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Send2.Location = new System.Drawing.Point(629, 507);
            this.BTN_Send2.Name = "BTN_Send2";
            this.BTN_Send2.Size = new System.Drawing.Size(52, 27);
            this.BTN_Send2.TabIndex = 8;
            this.BTN_Send2.Text = "Send &2";
            this.BTN_Send2.UseVisualStyleBackColor = true;
            this.BTN_Send2.Click += new System.EventHandler(this.BTN_Send_Click);
            // 
            // TXT_CMD2Send2
            // 
            this.TXT_CMD2Send2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_CMD2Send2.Location = new System.Drawing.Point(0, 510);
            this.TXT_CMD2Send2.Name = "TXT_CMD2Send2";
            this.TXT_CMD2Send2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TXT_CMD2Send2.Size = new System.Drawing.Size(628, 20);
            this.TXT_CMD2Send2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(629, 253);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 27);
            this.button1.TabIndex = 9;
            this.button1.Text = "&Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTN_Send3
            // 
            this.BTN_Send3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Send3.Location = new System.Drawing.Point(629, 534);
            this.BTN_Send3.Name = "BTN_Send3";
            this.BTN_Send3.Size = new System.Drawing.Size(52, 27);
            this.BTN_Send3.TabIndex = 11;
            this.BTN_Send3.Text = "Send &3";
            this.BTN_Send3.UseVisualStyleBackColor = true;
            this.BTN_Send3.Click += new System.EventHandler(this.BTN_Send_Click);
            // 
            // TXT_CMD2Send3
            // 
            this.TXT_CMD2Send3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_CMD2Send3.Location = new System.Drawing.Point(2, 537);
            this.TXT_CMD2Send3.Name = "TXT_CMD2Send3";
            this.TXT_CMD2Send3.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TXT_CMD2Send3.Size = new System.Drawing.Size(628, 20);
            this.TXT_CMD2Send3.TabIndex = 10;
            // 
            // Watch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 562);
            this.Controls.Add(this.BTN_Send3);
            this.Controls.Add(this.TXT_CMD2Send3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTN_Send2);
            this.Controls.Add(this.TXT_CMD2Send2);
            this.Controls.Add(this.BTN_Send1);
            this.Controls.Add(this.TXT_CMD2Send1);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_Clear);
            this.Controls.Add(this.TXT_Hex);
            this.Controls.Add(this.TXT_SerialLog);
            this.Controls.Add(this.DG_View);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Watch";
            this.Text = "Zimba Watch";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.DG_View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DG_View;
        private System.Windows.Forms.Button BTN_Clear;
        private System.Windows.Forms.TextBox TXT_SerialLog;
        private System.Windows.Forms.TextBox TXT_Hex;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.TextBox TXT_CMD2Send1;
        private System.Windows.Forms.Button BTN_Send1;
        private System.Windows.Forms.Button BTN_Send2;
        private System.Windows.Forms.TextBox TXT_CMD2Send2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flow;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataVal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Details;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn End;
        private System.Windows.Forms.Button BTN_Send3;
        private System.Windows.Forms.TextBox TXT_CMD2Send3;
    }
}