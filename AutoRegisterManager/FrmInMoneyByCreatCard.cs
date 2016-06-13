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
using AutoRegisterManager.SDK;
using AutoRegisterManager.SdkService;
using System.Threading;

namespace AutoRegisterManager
{
    public partial class FrmInMoneyByCreatCard : Form
    {
        public DataSet cardSavingData;
        Money money = new Money();
        public FrmInMoneyByCreatCard()
        {
            InitializeComponent();
            //axTTDriverMgr1.SetLogPath(Application.StartupPath + "\\LogFile\\money.log", 6);
        }
       public  int sum = 0;//读入钱数

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.icMsg1.timer1.Stop();
            this.timer1.Stop();
            money.CloseInit();
            this.DialogResult = DialogResult.Cancel;
        }
        //确认
        private void lblOK_Click(object sender, EventArgs e)
        {
            MyAlert m = new MyAlert();
            m.alerttype = "确认取消";
            m.Msg = String.Format("本次充值金额：{0}元\n请核对您的充值金额是否正确？",sum.ToString ());
            if (m.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.timer1.Stop();
            try
            {
                backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                SkynetMessage.MsgInfo(ex.Message);
                return;
            }
            //调用充值业务
        }
        private void Save()
        {
            //CardSavingFacade eCardSavingFacade = new CardSavingFacade();
            //string modetype = "现金";
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0].BeginEdit();
            ////卡号
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_CARDID] = FrmMain.cardInfoStruct.CardNo;
            ////充值时间
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_OPERATETIME] = DateTime.Now;
            //////操作员
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_OPERATOR] = SysOperatorInfo.OperatorID;
            //////充值类型
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_SAVINGMODE] = 1;
            //////Add money
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_ADDMONEY] = Convert.ToDecimal(sum);
            ////业务类型
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_BUSSNESSTYPE] = "充值";
            ////支付方式
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_MODETYPE] = modetype;
            ////单位
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_UNIT] = "";
            ////支票号
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0][CardAuthorizationData.T_CARD_AUTHORIZATION_CHECKLOT] = "";
            //FrmMain.eCardAuthorizationData.Tables["T_CARD_AUTHORIZATION"].Rows[0].EndEdit();
            //1.在中间层更新余额信息
            //2.在中间层插入充值表信息
             //cardSavingData = eCardSavingFacade.insertEntity(FrmMain.eCardAuthorizationData);

             //CardAuthorizationFacade ar = new CardAuthorizationFacade();
             //FrmMain.cardBlance = ar.FindCardBalance(FrmMain.patientInfoData.Tables[0].Rows[0]["DIAGNOSEID"].ToString());
            FrmMain.cardBlance = sum;
            //SkyComm skyComm = new SkyComm();
            //int i = skyComm.SaveRecharge();
            //if (i != 0)
            //{ 
            //}



        }
        private void FrmInMoney_Load(object sender, EventArgs e)
        {
            try
            {
                string port = SkyComm.getvalue("钞箱Port");
                cardSavingData = new DataSet();
                this.lblClose.Visible = true;
                this.lblOK.Visible = false;
                sum = 0;
                money.init(Convert.ToInt32(port), 3);
                #region 纸币器开始接收纸币模块
                //打开验钞 等待纸币进入
                this.timer1.Start();
            }
            catch (Exception ex)
            {

                MyMsg.MsgInfo(ex.Message);
            }
            #endregion
        }
 

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (backgroundWorker1.IsBusy)
            {
                Thread.Sleep(100);
                return;
            }
            backgroundWorker1.RunWorkerAsync(); 
     
        }

        private void FrmInMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timer1.Stop();
            this.icMsg1.timer1.Stop();
            money.CloseInit();
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            this.LableEnable(lblOK, true);
            this.LableVisable(label2, false);
            this.Save();
          
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region 打印小票模块
            //Print cp = new Print();
            //cp.PrintReport(cardSavingData, FrmMain.patientInfoData.Tables[0].Rows[0]["PATIENTNAME"].ToString(), sum.ToString());
            #endregion

            this.LableEnable(lblOK, true);
            this.LableVisable(label2, false);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 打印自助挂号
        /// </summary>
        //private void PrintReport(DataSet ds,string name,string sum)
        //{
        //    ds.WriteXml(Application.StartupPath + @"\\ReportXml\\自助充值" + name + ds.Tables[0].Rows[0]["TRANSACTION_ID"].ToString() + ".xml");
        //    string path = Application.StartupPath + @"\\Reports\\自助充值.rmf";

        //    if (System.IO.File.Exists(path) == false)
        //    {
        //        //SkynetMessage.MsgError("自助充值票据不存在,请查证!");
        //        return;
        //    }

        //    //引用 RM.ReportEngine.dll
        //    RMReportEngine.RMReport rmReport1 = new RMReportEngine.RMReport();

        //    FrmMain frm = new FrmMain();
        //    rmReport1.Init(frm, RMReportEngine.RMReportType.rmrtReport);
        //    rmReport1.AddDataSet(ds.Tables[0], "report");
        //    rmReport1.AddVariable("姓名", name, true);
        //    rmReport1.AddVariable("充值金额", sum, true);
        //    rmReport1.AddVariable("卡余额", FrmMain.cardBlance.ToString(), true);


        //    rmReport1.LoadFromFile(path);

        //    rmReport1.ShowPrintDialog = false;
        //    rmReport1.ShowProgress = false;
        //    rmReport1.ThreadPrepareReport = false;
        //    //rmReport1.ShowReport();
        //    rmReport1.PrintReport();
        //    rmReport1.Destroy();
        //}
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
                this.Invoke(de,lv, isvisable);
            }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
           
            int iMoney =  money.poll();//读取纸币面额

            if (iMoney < 0)
            {
                //int errorNum = axTTDriverMgr1.GetDeviceStatus(TTDeviceMgr.DT_MONEY);
                //SkynetMessage.MsgInfo(TTDeviceMgr.GetStatusInfo(errorNum) + ",错误代码：" + errorNum.ToString());
                //return;
            }
            else if(iMoney >0)
            {
                //axTTDriverMgr1.WriteToFile(Application.StartupPath + "\\LogFile\\money.log", "【" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "】诊疗号【" + FrmMain.patientInfoData.Tables[0].Rows[0]["DIAGNOSEID"].ToString() + "】充值：" + iMoney + "元");
                sum =sum +iMoney;
                this.icMsg1.timer1.Stop();
                this.lblClose.Visible = false;
                this.lblOK.Location = new Point(568, 182);
                this.lblOK.Visible = true;
                this.label1.Text = string.Format("已读入金额：{0}元", sum);
                lblOK.Enabled = true;
                lblOK.Visible = true;
               
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
