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
    //选择挂号
    public partial class FrmRegSelect : Form
    {
        public int resutType = 0;
        public FrmRegSelect()
        {
            InitializeComponent();
            resutType = 0;
        }

        private void FrmRegSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            this.DialogResult = DialogResult.OK;
        }
        //专家号
        private void btnRegZj_Click(object sender, EventArgs e)
        {
            resutType = 2;
            this.DialogResult = DialogResult.OK;
        }

        private void icMsg1_Load(object sender, EventArgs e)
        {
            this.label1.Location = new Point(this.label1.Location.X + (this.lblOffice.Width - 97), this.label1.Location.Y);
        }

        private void btnRegPt_Click(object sender, EventArgs e)
        {
            resutType = 1;
            this.DialogResult = DialogResult.OK;
        }
    }
}
