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
    public partial class FrmInfoAlert : Form
    {
        int sec = 30;
        public FrmInfoAlert()
        {
            InitializeComponent();
          
            timer1.Start();
        }

        private void lblOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sec == 0)
            {
                this.timer1.Stop();
                this.DialogResult = DialogResult.OK;
            }
            this.lblWaitTime.Text = sec.ToString();
            sec = sec - 1;
        }
    }
}
