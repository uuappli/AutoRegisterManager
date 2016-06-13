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
    public partial class FrmChildAlert : Form
    {
        public FrmChildAlert()
        {
            InitializeComponent();
        }

        private void lblCancle_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmChildAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.icMsg1.timer1.Stop();
        }
    }
}
