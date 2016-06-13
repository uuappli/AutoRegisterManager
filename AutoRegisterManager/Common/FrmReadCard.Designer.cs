namespace AutoRegisterManager.Common
{
    partial class FrmReadCard
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
            this.progressBar2 = new BSE.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblMsg = new System.Windows.Forms.Label();
            this.icMsg1 = new AutoRegisterManager.Inc.IcMsg();
            this.SuspendLayout();
            // 
            // progressBar2
            // 
            this.progressBar2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(255)))));
            this.progressBar2.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.progressBar2.Location = new System.Drawing.Point(23, 167);
            this.progressBar2.Maximum = 100;
            this.progressBar2.Minimum = 0;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(734, 49);
            this.progressBar2.TabIndex = 1;
            this.progressBar2.Value = 0;
            this.progressBar2.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.White;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblMsg.Location = new System.Drawing.Point(20, 146);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(269, 18);
            this.lblMsg.TabIndex = 2;
            this.lblMsg.Text = "正在读取卡信息，请稍候 ......";
            // 
            // icMsg1
            // 
            this.icMsg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icMsg1.Location = new System.Drawing.Point(0, 0);
            this.icMsg1.Name = "icMsg1";
            this.icMsg1.Size = new System.Drawing.Size(786, 274);
            this.icMsg1.TabIndex = 0;
            // 
            // FrmReadCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 274);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.icMsg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmReadCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReadCard";
            this.Load += new System.EventHandler(this.FrmReadCard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BSE.Windows.Forms.ProgressBar progressBar2;
        public AutoRegisterManager.Inc.IcMsg icMsg1;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblMsg;
    }
}