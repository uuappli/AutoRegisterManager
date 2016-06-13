using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoRegisterManager.Inc
{
    public partial class Top : UserControl
    {
        private bool autoClose;
        //是否自动关闭
        public bool AutoClose
        {
            get { return autoClose; }
            set { autoClose = value; }
        }
        private int sec;
        //自动关闭时间
        public int Sec
        {
            get { return sec; }
            set { sec = value; }
        }
        public Top()
        {
            InitializeComponent();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                this.timer1.Stop();
                this.ParentForm.Close();
            }
            this.lblWaitTime.Text = sec.ToString();
            sec = sec - 1;
        }

        private void Top_Load(object sender, EventArgs e)
        {
            if (AutoClose)
            {
                this.lblWaitTime.Visible = true;
            }
            sec = sec - 1;
        }

    }
}
