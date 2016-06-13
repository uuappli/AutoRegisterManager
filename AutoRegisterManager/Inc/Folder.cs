using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoRegisterManager.Common;

namespace AutoRegisterManager.Inc
{
    public partial class Folder : UserControl
    {
        public Folder()
        {
            InitializeComponent();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.Hour < 12)
            {
                this.lblTIME.Text = DateTime.Now.ToShortTimeString() ;
            }
            else
            {
                this.lblTIME.Text = DateTime.Now.ToShortTimeString();
            }
        }
        //退卡
        private void label1_Click(object sender, EventArgs e)
        {
            //退卡
        }
    }
}
