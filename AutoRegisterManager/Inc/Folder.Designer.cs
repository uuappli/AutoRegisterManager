namespace AutoRegisterManager.Inc
{
    partial class Folder
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Folder));
            this.panel2 = new System.Windows.Forms.Panel();
            //this.axTTDriverMgr1 = new AxTTDRIVERMGRLib.AxTTDriverMgr();
            this.lblTIME = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            //((System.ComponentModel.ISupportInitialize)(this.axTTDriverMgr1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            //this.panel2.Controls.Add(this.axTTDriverMgr1);
            this.panel2.Controls.Add(this.lblTIME);
            this.panel2.Controls.Add(this.panel6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1024, 68);
            this.panel2.TabIndex = 6;
            // 
            // axTTDriverMgr1
            // 
            //this.axTTDriverMgr1.Enabled = true;
            //this.axTTDriverMgr1.Location = new System.Drawing.Point(736, 18);
            //this.axTTDriverMgr1.Name = "axTTDriverMgr1";
            //this.axTTDriverMgr1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTTDriverMgr1.OcxState")));
            //this.axTTDriverMgr1.Size = new System.Drawing.Size(100, 50);
            //this.axTTDriverMgr1.TabIndex = 3;
            //this.axTTDriverMgr1.Visible = false;
            // 
            // lblTIME
            // 
            this.lblTIME.Font = new System.Drawing.Font("黑体", 32F, System.Drawing.FontStyle.Bold);
            this.lblTIME.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(77)))), ((int)(((byte)(140)))));
            this.lblTIME.Location = new System.Drawing.Point(719, 14);
            this.lblTIME.Name = "lblTIME";
            this.lblTIME.Size = new System.Drawing.Size(279, 48);
            this.lblTIME.TabIndex = 0;
            this.lblTIME.Text = "8:30";
            this.lblTIME.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.Location = new System.Drawing.Point(12, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1000, 25);
            this.panel6.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Folder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Name = "Folder";
            this.Size = new System.Drawing.Size(1024, 68);
            this.panel2.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.axTTDriverMgr1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTIME;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Timer timer1;
        //private AxTTDRIVERMGRLib.AxTTDriverMgr axTTDriverMgr1;
    }
}
