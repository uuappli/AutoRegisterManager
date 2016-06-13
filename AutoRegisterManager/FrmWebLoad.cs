using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoRegisterManager
{
    public partial class FrmWebLoad : Form
    {
        public FrmWebLoad()
        {
            InitializeComponent();
            this.top1.timer1.Start();
        }


        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWebLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.top1.timer1.Stop();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.top1.Sec = 60;
        }
    }
}
