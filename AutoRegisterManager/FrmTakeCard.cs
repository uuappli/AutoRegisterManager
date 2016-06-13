using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoRegisterManager.SdkService;
using AutoRegisterManager.Common;

namespace AutoRegisterManager
{
    /// <summary>
    /// 得到用户身份证信息（发卡）
    /// </summary>
    public partial class FrmTakeCard : Form
    {
        public FrmTakeCard()
        {
            InitializeComponent();
            this.top1.timer1.Start();
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            MyAlert m = new MyAlert();
            m.alerttype = "读取身份证";
            //FrmWaitCard m = new FrmWaitCard();
            if (m.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void lblback_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTakeCard_Load(object sender, EventArgs e)
        {
          // backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //ChargeKindFacade cktype = new ChargeKindFacade();
            //DataSet cktypeds = cktype.FindAll();
            //FrmMain.fbID = cktypeds.Tables[0].Select("CHARGEKIND='普通' OR CHARGEKIND='自费'")[0]["CHARGEKINDID"].ToString();
            //IDCard ic=new IDCard ();
            //bool isopen = ic.openPort();
            //if (!isopen)
            //{
            //    MyMsg.MsgInfo("身份证读卡器端口打开失败！");
            //}
        }

        private void FrmTakeCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.top1.timer1.Stop();
        }
    }
}
