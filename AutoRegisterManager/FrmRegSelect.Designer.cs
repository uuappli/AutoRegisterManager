namespace AutoRegisterManager
{
    partial class FrmRegSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegSelect));
            this.label1 = new System.Windows.Forms.Label();
            this.lblOffice = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegPt = new System.Windows.Forms.Label();
            this.btnRegZj = new System.Windows.Forms.Label();
            this.icMsg1 = new AutoRegisterManager.Inc.IcMsg();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(128, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 48);
            this.label1.TabIndex = 1;
            // 
            // lblOffice
            // 
            this.lblOffice.AutoSize = true;
            this.lblOffice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(76)))), ((int)(((byte)(140)))));
            this.lblOffice.Font = new System.Drawing.Font("宋体", 29F, System.Drawing.FontStyle.Bold);
            this.lblOffice.ForeColor = System.Drawing.Color.White;
            this.lblOffice.Location = new System.Drawing.Point(25, 36);
            this.lblOffice.Name = "lblOffice";
            this.lblOffice.Size = new System.Drawing.Size(97, 39);
            this.lblOffice.TabIndex = 2;
            this.lblOffice.Text = "儿科";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("宋体", 29F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.LimeGreen;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(35, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(263, 31);
            this.label4.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("宋体", 29F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.LimeGreen;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(472, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(289, 31);
            this.label5.TabIndex = 2;
            // 
            // btnRegPt
            // 
            this.btnRegPt.BackColor = System.Drawing.Color.White;
            this.btnRegPt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegPt.Font = new System.Drawing.Font("宋体", 29F, System.Drawing.FontStyle.Bold);
            this.btnRegPt.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnRegPt.Image = ((System.Drawing.Image)(resources.GetObject("btnRegPt.Image")));
            this.btnRegPt.Location = new System.Drawing.Point(72, 186);
            this.btnRegPt.Name = "btnRegPt";
            this.btnRegPt.Size = new System.Drawing.Size(186, 52);
            this.btnRegPt.TabIndex = 2;
            this.btnRegPt.Click += new System.EventHandler(this.btnRegPt_Click);
            // 
            // btnRegZj
            // 
            this.btnRegZj.BackColor = System.Drawing.Color.White;
            this.btnRegZj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegZj.Font = new System.Drawing.Font("宋体", 29F, System.Drawing.FontStyle.Bold);
            this.btnRegZj.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnRegZj.Image = ((System.Drawing.Image)(resources.GetObject("btnRegZj.Image")));
            this.btnRegZj.Location = new System.Drawing.Point(517, 186);
            this.btnRegZj.Name = "btnRegZj";
            this.btnRegZj.Size = new System.Drawing.Size(189, 52);
            this.btnRegZj.TabIndex = 2;
            this.btnRegZj.Click += new System.EventHandler(this.btnRegZj_Click);
            // 
            // icMsg1
            // 
            this.icMsg1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.icMsg1.Location = new System.Drawing.Point(0, 0);
            this.icMsg1.Name = "icMsg1";
            this.icMsg1.Size = new System.Drawing.Size(786, 274);
            this.icMsg1.TabIndex = 0;
            this.icMsg1.Load += new System.EventHandler(this.icMsg1_Load);
            // 
            // FrmRegSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 274);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnRegZj);
            this.Controls.Add(this.btnRegPt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblOffice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.icMsg1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRegSelect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegSelect_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label btnRegPt;
        private System.Windows.Forms.Label btnRegZj;
        public System.Windows.Forms.Label lblOffice;
        public AutoRegisterManager.Inc.IcMsg icMsg1;
    }
}