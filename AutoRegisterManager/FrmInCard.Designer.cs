namespace AutoRegisterManager
{
    partial class FrmInCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInCard));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.label4 = new System.Windows.Forms.Label();
            //this.axTTDriverMgr1 = new AxTTDRIVERMGRLib.AxTTDriverMgr();
            this.myGroupBox1 = new AutoRegisterManager.Inc.MyGroupBox();
            this.folder1 = new AutoRegisterManager.Inc.Folder();
            this.top1 = new AutoRegisterManager.Inc.Top();
            //((System.ComponentModel.ISupportInitialize)(this.axTTDriverMgr1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(30, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 66);
            this.label1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(99, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(805, 282);
            this.label3.TabIndex = 3;
            // 
            // lblClose
            // 
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(12, 12);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(137, 36);
            this.lblClose.TabIndex = 6;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
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
            this.label4.TabIndex = 8;
            this.label4.Text = "正在读取卡信息，请稍候......";
            this.label4.Visible = false;
            // 
            // axTTDriverMgr1
            // 
            //this.axTTDriverMgr1.Enabled = true;
            //this.axTTDriverMgr1.Location = new System.Drawing.Point(460, 13);
            //this.axTTDriverMgr1.Name = "axTTDriverMgr1";
            //this.axTTDriverMgr1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTTDriverMgr1.OcxState")));
            //this.axTTDriverMgr1.Size = new System.Drawing.Size(100, 50);
            //this.axTTDriverMgr1.TabIndex = 7;
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
            this.myGroupBox1.TabIndex = 2;
            // 
            // folder1
            // 
            this.folder1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.folder1.Location = new System.Drawing.Point(0, 666);
            this.folder1.Name = "folder1";
            this.folder1.Size = new System.Drawing.Size(1016, 68);
            this.folder1.TabIndex = 1;
            // 
            // top1
            // 
            this.top1.AutoClose = true;
            this.top1.Dock = System.Windows.Forms.DockStyle.Top;
            this.top1.Location = new System.Drawing.Point(0, 0);
            this.top1.Name = "top1";
            this.top1.Sec = 42;
            this.top1.Size = new System.Drawing.Size(1016, 63);
            this.top1.TabIndex = 0;
            // 
            // FrmInCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1016, 734);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myGroupBox1);
            this.Controls.Add(this.folder1);
            this.Controls.Add(this.top1);
            //this.Controls.Add(this.axTTDriverMgr1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmInCard";
            this.Text = "FrmInCard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInCard_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmInCard_FormClosing);
            //((System.ComponentModel.ISupportInitialize)(this.axTTDriverMgr1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AutoRegisterManager.Inc.Folder folder1;
        private AutoRegisterManager.Inc.MyGroupBox myGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public AutoRegisterManager.Inc.Top top1;
        private System.Windows.Forms.Label lblClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        //private AxTTDRIVERMGRLib.AxTTDriverMgr axTTDriverMgr1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label label4;
    }
}