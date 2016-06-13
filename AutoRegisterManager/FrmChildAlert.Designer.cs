namespace AutoRegisterManager
{
    partial class FrmChildAlert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChildAlert));
            this.lblCancle = new System.Windows.Forms.Label();
            this.icMsg1 = new AutoRegisterManager.Inc.IcMsg();
            this.SuspendLayout();
            // 
            // lblCancle
            // 
            this.lblCancle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCancle.Image = ((System.Drawing.Image)(resources.GetObject("lblCancle.Image")));
            this.lblCancle.Location = new System.Drawing.Point(584, 201);
            this.lblCancle.Name = "lblCancle";
            this.lblCancle.Size = new System.Drawing.Size(190, 53);
            this.lblCancle.TabIndex = 2;
            this.lblCancle.Click += new System.EventHandler(this.lblCancle_Click);
            // 
            // icMsg1
            // 
            this.icMsg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icMsg1.Location = new System.Drawing.Point(0, 0);
            this.icMsg1.Name = "icMsg1";
            this.icMsg1.Size = new System.Drawing.Size(786, 274);
            this.icMsg1.TabIndex = 0;
            // 
            // FrmChildAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 274);
            this.Controls.Add(this.lblCancle);
            this.Controls.Add(this.icMsg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChildAlert";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChildAlert";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmChildAlert_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCancle;
        public AutoRegisterManager.Inc.IcMsg icMsg1;


    }
}