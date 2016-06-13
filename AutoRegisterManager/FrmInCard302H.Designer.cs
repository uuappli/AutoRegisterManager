namespace AutoRegisterManager
{
    partial class FrmInCard302H
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInCard302H));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.lblClose = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txtInputCard = new System.Windows.Forms.TextBox();
            this.folder1 = new AutoRegisterManager.Inc.Folder();
            this.top1 = new AutoRegisterManager.Inc.Top();
            this.myGroupBox1 = new AutoRegisterManager.Inc.MyGroupBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("黑体", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(75, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(594, 40);
            this.label4.TabIndex = 15;
            this.label4.Text = "正在读取卡信息，请稍候......";
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(30, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 66);
            this.label1.TabIndex = 12;
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(12, 12);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(137, 36);
            this.lblClose.TabIndex = 14;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(99, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(805, 282);
            this.label3.TabIndex = 13;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // txtInputCard
            // 
            this.txtInputCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInputCard.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtInputCard.ForeColor = System.Drawing.Color.Red;
            this.txtInputCard.Location = new System.Drawing.Point(-1, -1);
            this.txtInputCard.MaxLength = 50;
            this.txtInputCard.Multiline = true;
            this.txtInputCard.Name = "txtInputCard";
            this.txtInputCard.PasswordChar = '*';
            this.txtInputCard.Size = new System.Drawing.Size(0, 0);
            this.txtInputCard.TabIndex = 16;
            this.txtInputCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInputCard_KeyPress);
            // 
            // folder1
            // 
            this.folder1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.folder1.Location = new System.Drawing.Point(0, 628);
            this.folder1.Name = "folder1";
            this.folder1.Size = new System.Drawing.Size(1000, 68);
            this.folder1.TabIndex = 10;
            // 
            // top1
            // 
            this.top1.AutoClose = true;
            this.top1.Dock = System.Windows.Forms.DockStyle.Top;
            this.top1.Location = new System.Drawing.Point(0, 0);
            this.top1.Name = "top1";
            this.top1.Sec = 29;
            this.top1.Size = new System.Drawing.Size(1000, 63);
            this.top1.TabIndex = 9;
            // 
            // myGroupBox1
            // 
            this.myGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.myGroupBox1.Location = new System.Drawing.Point(48, 129);
            this.myGroupBox1.Name = "myGroupBox1";
            this.myGroupBox1.Size = new System.Drawing.Size(921, 531);
            this.myGroupBox1.TabIndex = 11;
            // 
            // FrmInCardUniversal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 696);
            this.Controls.Add(this.txtInputCard);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.folder1);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.top1);
            this.Controls.Add(this.myGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInCardUniversal";
            this.Text = "FrmInCardUniversal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInCardUniversal_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmInCardUniversal_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private AutoRegisterManager.Inc.Folder folder1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private AutoRegisterManager.Inc.MyGroupBox myGroupBox1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public AutoRegisterManager.Inc.Top top1;
        private System.Windows.Forms.TextBox txtInputCard;

    }
}