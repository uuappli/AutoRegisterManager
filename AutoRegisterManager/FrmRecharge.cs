using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skynet.Framework.Common;
using AutoRegisterManager.Common;
using AutoRegisterManager.SdkService;

namespace AutoRegisterManager
{
    /// <summary>
    /// 充值界面
    /// </summary>
    public partial class FrmRecharge : Form
    {
        
        public FrmRecharge()
        {
            InitializeComponent();
            this.top1.timer1.Start();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //开始充值
        private void lblOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FrmMain.cardInfoStruct.CardNo))
            {
                MyMsg.MsgInfo("请刷卡进入！");
                this.Close();
                return;
            }
            if (backgroundWorker1.IsBusy)
            {
                SkynetMessage.MsgInfo("业务处理中，请稍候。。。");
                return;
            }
            //ReckonAccountTimeFacade reckonAccountsTimeFacade = new ReckonAccountTimeFacade();
            //DateTime accountTime = reckonAccountsTimeFacade.GetEndTime(SysOperatorInfo.OperatorID, "门诊");
            //if (DateTime.Now < accountTime)
            //{
            //    SkynetMessage.MsgInfo("该时间段已经结帐，不能办理预交金业务，请重试！");
            //    return;
            //}
            //if (FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows.Count <= 0)
            //{
            //    SkynetMessage.MsgInfo("此操作没有找到所要充值的卡信息!");
            //    return;
            //}
            MyAlert m = new MyAlert();
            m.alerttype = "开始充值";
            if (m.ShowDialog() == DialogResult.OK)
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                //退卡
                this.Close();
            }
        }
        //充值记录
        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void label3_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(FrmMain.cardInfoStruct.CardNo))
            {
                MyMsg.MsgInfo("请插入您的就诊卡");
                this.Close();
                return;
            }
            Label lb = sender as Label;
            FrmRechargeRecord fc = new FrmRechargeRecord();
            //  fc.lblName.Text = dt.Rows[0]["DoctorName"].ToString();
            Point p = lb.PointToScreen(e.Location);
            if (p.X - fc.Width < 0)
            {
                fc.Location = new Point(0, p.Y);
            }
            else
            {
                fc.Location = new Point(p.X - fc.Width, p.Y);
            }
            fc.ShowDialog();
        }

        private void FrmRecharge_Load(object sender, EventArgs e)
        {
            if (FrmMain.patientInfoData != null && FrmMain.patientInfoData.Tables[0].Rows.Count > 0)
            {
                this.lblName.Text = FrmMain.patientInfoData.Tables[0].Rows[0]["XingMing"] == null ? "" : FrmMain.patientInfoData.Tables[0].Rows[0]["XingMing"].ToString();
                this.lblAge.Text = "";// FrmMain.patientInfoData.Tables[0].Rows[0]["AGE"] == null ? "" : FrmMain.patientInfoData.Tables[0].Rows[0]["AGE"].ToString();
                this.lblcardNo.Text = FrmMain.patientInfoData.Tables[0].Rows[0]["ShenFenZheng"] == null ? "" : FrmMain.patientInfoData.Tables[0].Rows[0]["ShenFenZheng"].ToString();
                this.lblMoney.Text = FrmMain.patientInfoData.Tables[0].Rows[0]["LeftJinE"] == null ? "" : FrmMain.patientInfoData.Tables[0].Rows[0]["LeftJinE"].ToString();
            }
            else
            {
                SkynetMessage.MsgInfo("病人信息不存在！");
                this.Close();
                return;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.LableEnable(lblOk, false);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.LableEnable(lblOk, true);
            this.LableText(lblMoney, FrmMain.cardBlance.ToString());
        }
        //消费明细
        private void lblXf_MouseClick(object sender, MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(FrmMain.cardInfoStruct.CardNo))
            {
                MyMsg.MsgInfo("请插入您的就诊卡");
                this.Close();
                return;
            }
            Label lb = sender as Label;
            FrmRechargeDetail fc = new FrmRechargeDetail();
            //  fc.lblName.Text = dt.Rows[0]["DoctorName"].ToString();
            Point p = lb.PointToScreen(e.Location);
            fc.Location = new Point(p.X - fc.Width, p.Y);
            fc.ShowDialog();
        }

        private void lblXf_Click(object sender, EventArgs e)
        {

        }
        #region 线程提示区
        private delegate void DLableEnable(Label lv, bool isenable);
        //Lable Enable设置
        void LableEnable(Label lv, bool isenable)
        {
            if (!lv.InvokeRequired)
            {
                lv.Enabled = isenable;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DLableEnable de = LableEnable;
                this.Invoke(de, lv, isenable);
            }
        }
        //Lable Visable设置
        private delegate void DLableVisable(Label lv, bool isvisable);
        void LableVisable(Label lv, bool isvisable)
        {
            if (!lv.InvokeRequired)
            {
                lv.Visible = isvisable;
            }
            else
            {
                DLableVisable de = LableVisable;
                this.Invoke(de, lv, isvisable);
            }
        }
        //Lable Text 设置
        private delegate void DLableText(Label lv, string text);
        void LableText(Label lv, string text)
        {
            if (!lv.InvokeRequired)
            {
                lv.Text = text;
            }
            else
            {
                DLableVisable de = LableVisable;
                this.Invoke(de, lv, text);
            }
        }
        #endregion

        private void FrmRecharge_Paint(object sender, PaintEventArgs e)
        {
            this.top1.Sec = 60;
        }

        private void FrmRecharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.top1.timer1.Stop();
        }


    }
}
