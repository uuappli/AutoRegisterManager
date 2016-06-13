namespace AutoRegisterManager
{
    partial class FrmTakeCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTakeCard));
            this.label1 = new System.Windows.Forms.Label();
            this.btnstart = new System.Windows.Forms.Button();
            this.lblback = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.top1 = new AutoRegisterManager.Inc.Top();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(198, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(628, 156);
            this.label1.TabIndex = 3;
            // 
            // btnstart
            // 
            this.btnstart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnstart.FlatAppearance.BorderSize = 0;
            this.btnstart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnstart.Image = ((System.Drawing.Image)(resources.GetObject("btnstart.Image")));
            this.btnstart.Location = new System.Drawing.Point(324, 427);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(351, 102);
            this.btnstart.TabIndex = 4;
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // lblback
            // 
            this.lblback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblback.Image = ((System.Drawing.Image)(resources.GetObject("lblback.Image")));
            this.lblback.Location = new System.Drawing.Point(-2, 63);
            this.lblback.Name = "lblback";
            this.lblback.Size = new System.Drawing.Size(110, 36);
            this.lblback.TabIndex = 5;
            this.lblback.Click += new System.EventHandler(this.lblback_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // top1
            // 
            this.top1.AutoClose = true;
            this.top1.Dock = System.Windows.Forms.DockStyle.Top;
            this.top1.Location = new System.Drawing.Point(0, 0);
            this.top1.Name = "top1";
            this.top1.Sec = 52;
            this.top1.Size = new System.Drawing.Size(1024, 37);
            this.top1.TabIndex = 0;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.DarkGray;
            this.label16.Location = new System.Drawing.Point(237, 166);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(510, 51);
            this.label16.TabIndex = 6;
            this.label16.Text = "请按照提示正确操作";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(257, 251);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 51);
            this.label2.TabIndex = 7;
            this.label2.Text = "请准备好您的二代身份证";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(257, 302);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(581, 51);
            this.label3.TabIndex = 8;
            this.label3.Text = "请准备好所需充值现金";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(345, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 102);
            this.label4.TabIndex = 17;
            // 
            // FrmTakeCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblback);
            this.Controls.Add(this.btnstart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.top1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTakeCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGetUserCard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTakeCard_FormClosing);
            this.Load += new System.EventHandler(this.FrmTakeCard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AutoRegisterManager.Inc.Top top1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.Label lblback;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

    }
}