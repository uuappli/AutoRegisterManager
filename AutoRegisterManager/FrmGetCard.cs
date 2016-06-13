using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoRegisterManager.Common;
using AutoRegisterManager.SdkService;
using System.Threading;

namespace AutoRegisterManager
{
    /// <summary>
    /// 取卡
    /// </summary>
    public partial class FrmGetCard : Form
    {
        public FrmGetCard()
        {
            InitializeComponent();
            this.top1.timer1.Start();
        }

        private void lblback_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Init()
        {
            this.lblage.Text = SkyComm.getage(FrmMain.userInfo.Birthday);
            //this.lblBirthday.Text  = FrmMain.userInfo.Birthday;
            this.lblCardNo.Text = FrmMain.userInfo.Number;
            this.lblName.Text = FrmMain.userInfo.Name;
            this.lblSex.Text = FrmMain.userInfo.Sex;
        }
        //取卡
        private void btnqk_Click(object sender, EventArgs e)
        {
            //D1000Card d1000=new D1000Card ();
            //if (!d1000.sendcmd("FC7"))
            //{
            //this.DialogResult = DialogResult.OK;
            //}
            while (backgroundWorker1.IsBusy)
            {
                Thread.Sleep(100);
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void FrmGetCard_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Msgvisable(this.lblMsg, true);
            PutCardUniversal pc = new PutCardUniversal();
            int i = pc.OutCardD1000(0, 0, FrmMain.userInfo, 0);
            if (i == -1)
            {
                //退卡
                this.Close();
            }

            SkyComm skyComm = new SkyComm();
            DataSet parInfo = skyComm.QueryPatInfo(FrmMain.cardInfoStruct.CardNo);
            if (parInfo.Tables[0].Rows.Count <= 0)
            {
                e.Result = "失败";
                MyMsg.MsgInfo("卡号无效！ 卡号：" + FrmMain.cardInfoStruct.CardNo);
                this.Close();
            }

            FrmMain.patientInfoData = parInfo;
            FrmMain.cardBlance = Convert.ToDecimal(FrmMain.patientInfoData.Tables[0].Rows[0]["LeftJinE"]);

            MyAlert m = new MyAlert();
            m.alerttype = "开始充值";
            if (m.ShowDialog() == DialogResult.OK)
            {
                parInfo = skyComm.QueryPatInfo(FrmMain.cardInfoStruct.CardNo);
                if (parInfo.Tables[0].Rows.Count <= 0)
                {
                    e.Result = "失败";
                    MyMsg.MsgInfo("卡号无效！ 卡号：" + FrmMain.cardInfoStruct.CardNo);
                    this.Close();
                }

                FrmMain.patientInfoData = parInfo;
                FrmMain.cardBlance = Convert.ToDecimal(FrmMain.patientInfoData.Tables[0].Rows[0]["LeftJinE"]);

                FrmRecharge fr = new FrmRecharge();
                fr.ShowDialog();
            }
            else
            {
                //退卡
                this.Close();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Msgvisable(this.lblMsg, false);
            this.DialogResult = DialogResult.OK;
        }
        #region 线程提示区
        private delegate void Demsgvisable(Label lv, bool isvisable);
        //提示信息
        void Msgvisable(Label lv, bool isvisable)
        {
            if (!lv.InvokeRequired)
            {
                this.btnqk.Enabled = !isvisable;
                lv.Visible = isvisable;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                Demsgvisable de = Msgvisable;
                this.Invoke(de, lv, isvisable);
            }
        }
        #endregion

        private void FrmGetCard_Paint(object sender, PaintEventArgs e)
        {
            this.top1.Sec = 60;
        }

        private void FrmGetCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.top1.timer1.Stop();
        }

        
    }
}
