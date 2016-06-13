using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoRegisterManager.Common;
using CardInterface.D3_DLL;
using AutoRegisterManager.SdkService;

namespace AutoRegisterManager
{
    public partial class FrmInCardM100Send : Form
    {
        DC_D3 dd = new DC_D3();
        MyAlert m = new MyAlert();
        M100ReadCard m100ReadCard = new M100ReadCard();
        M100ICReadCard m100ICReadCard = new M100ICReadCard();
        int times = 0;

        public FrmInCardM100Send()
        {
            InitializeComponent();
        }

        private void FrmInCardUniversal_Load(object sender, EventArgs e)
        {
            FrmMain.patientInfoData = new DataSet();
            FrmMain.cardData = new DataSet();
            FrmMain.cardBlance = 0;
            if (this.top1.AutoClose)
            {
                this.top1.timer1.Start();
            }
            #region 读卡器读卡
            //此处写读卡器读卡代码
            timer1.Start();
            timer2.Start();
            #endregion
        }

        private void FrmInCardUniversal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.top1.timer1.Stop();
            this.timer1.Stop();
        }

        private void closePort()
        {
            FrmMain.cardInfoStruct.CardNo = string.Empty;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Msgvisable(this.label4, true);

                //CardRead cardUtility = new CardRead(this);
                //SkyComm skyComm = new SkyComm();
                //DataSet parInfo = skyComm.QueryPatInfo(FrmMain.cardInfoStruct.CardNo);
                //if (parInfo.Tables[0].Rows.Count <= 0)
                //{
                //    e.Result = "失败";
                //    MyMsg.MsgInfo("卡号无效！ 卡号：" + FrmMain.cardInfoStruct.CardNo);
                //    closePort();
                //    return;
                //}

                //FrmMain.patientInfoData = parInfo;
                //FrmMain.cardBlance = Convert.ToDecimal(FrmMain.patientInfoData.Tables[0].Rows[0]["LeftJinE"]);



                //FrmMain.eCardAuthorizationData = (CardAuthorizationData)ar.SelectPatientAndCardInfoByCardID(FrmMain.cardInfoStruct.CardNo);
                //if (FrmMain.eCardAuthorizationData.Tables[0].Rows.Count == 0)
                //{
                //    e.Result = "失败";
                //    MyMsg.MsgInfo("卡号无效！ 卡号：" + FrmMain.cardInfoStruct.CardNo);

                //    closePort();
                //    return;
                //}
                //string CardID = FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_CARDID].ToString();
                //if (!string.IsNullOrEmpty(CardID))
                //{
                //    if (Convert.ToInt32(FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_CIRCUIT_STATE]) == 1)
                //    {
                //        e.Result = "失败";
                //        MyMsg.MsgInfo("此卡已挂失不能使用！");
                //        closePort();
                //        return;
                //    }
                //    if (Convert.ToInt32(FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_CIRCUIT_STATE]) == 2)
                //    {
                //        e.Result = "失败";
                //        MyMsg.MsgInfo("此卡已注销不能使用！");
                //        closePort();
                //        return;
                //    }
                //    //DataSet dsType = new CardTypesFacade().FindByPrimaryKey(FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0]["TYPEID"].ToString());
                //    if (dsType.Tables[0].Rows[0]["IS_FEECHARGING_CARD"].ToString() == "1")
                //    {
                //        e.Result = "失败";
                //        MyMsg.MsgInfo("此卡为不储值卡,不能使用!");
                //        closePort();
                //        return;
                //    }
                //}
                //else
                //{
                //    e.Result = "失败";
                //    MyMsg.MsgInfo("此卡信息不存在！");
                //    closePort();
                //    return;
                //}
                //if (FrmMain.patientInfoData == null || FrmMain.patientInfoData.Tables[0].Rows.Count <= 0)
                //{
                //    MyMsg.MsgInfo("读取病人信息失败！");
                //    closePort();
                //    e.Result = "失败";
                //    return;
                //}

            }
            catch (Exception ex)
            {

                MyMsg.MsgInfo(ex.Message);
                closePort();
                e.Result = "失败";
                return;

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result != null && e.Result.Equals("失败"))
            {
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            //while (!backgroundWorker2.IsBusy)
            //{
            //    Thread.Sleep(10);
            //}
            // m.Close();
            Msgvisable(this.label4, false);
            this.DialogResult = DialogResult.OK;
        }

        int incardcount = 3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            string cardid = string.Empty;
            string cardType = SkyComm.getvalue("卡类型");
            //if (cardType == "磁条卡")
            //{
            cardid = m100ReadCard.ReadCard();
            //}
            //else if (cardType == "IC卡")
            //{
            //    cardid = m100ICReadCard.ReadCard();
            //}

            if (cardid == string.Empty)
            {
                this.Close();
            }

            //MessageBox.Show("卡号： " + cardid);
            FrmMain.cardInfoStruct.CardNo = cardid;
            //FrmMain.cardInfoStruct.CardNo = "002000000024153734";
            if (FrmMain.cardInfoStruct.CardNo != string.Empty && FrmMain.cardInfoStruct.CardNo.Length >= 6)
            {
                //MyMsg.MsgInfo(FrmMain.cardInfoStruct.CardNo);
                //FrmMain.cardInfoStruct.CardNo = "002000000024153734";// "001000776394154179";
                backgroundWorker1.RunWorkerAsync();
                //FrmMain.cardInfoStruct.CardNo = aa;
                timer1.Stop();
                this.top1.timer1.Stop();
            }
            else
            {
                if (incardcount > 0)
                {
                    MyMsg.MsgInfo("卡片无效，请确认插入方向后重试！");
                    incardcount--;
                    timer1.Start();
                }
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            m.alerttype = "WaitReadCard";
            if (m.ShowDialog() == DialogResult.OK)
            {
                e.Result = "成功";
            }
            else
            {
                e.Result = "失败";
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.ToString() == "成功")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        #region 线程提示区
        private delegate void Demsgvisable(Label lv, bool isvisable);
        //提示信息
        void Msgvisable(Label lv, bool isvisable)
        {
            if (!lv.InvokeRequired)
            {
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

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            times ++;
            if (times == 30000)
            {
                this.Close();
            }
        }

        private void top1_Load(object sender, EventArgs e)
        {

        }

    
    }
}
