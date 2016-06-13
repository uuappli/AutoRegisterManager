using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using AutoRegisterManager.Common;
using AutoRegisterManager.SdkService;
using System.Media;

namespace AutoRegisterManager
{
    public partial class MyAlert : Form
    {
        FrmReadCard fr = new FrmReadCard();
        public string alerttype = string.Empty;
        public int PtMoney = 0;//普通号
        public int ZjMoney = 0;//专家号
        public string OfficeName = "";
        public string Msg = "";
        public int RegRs = 0;//挂号选择返回值 0，关闭 1，普通号，2，专家号
        public decimal sumChargeMoney = 0;
        
        public MyAlert()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
          
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(100);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (alerttype == "FrmChildAlert")
            {
                FrmChildAlert fc = new FrmChildAlert();
                fc.TopMost = true;
                fc.ShowDialog();
                if (fc.DialogResult == DialogResult.Cancel)
                {
                    CloseWin(this,true );
                    fc.icMsg1.timer1.Stop();
                }
            }
            else if (alerttype == "WaitReadCard")
            {
                fr = new FrmReadCard();
                fr.TopMost = true;
                fr.ShowDialog();
                if (fr.DialogResult == DialogResult.OK)
                {
                    CloseWin(this,true );
                    fr.icMsg1.timer1.Stop();
                }
            }
            else if (alerttype == "开始充值")
            {
                AddMoney();
            }
            else if (alerttype == "选择挂号")
            {
                FrmRegSelect frm = new FrmRegSelect();
                frm.icMsg1.timer1.Start();
                frm.TopMost = true;
                frm.lblOffice.Text  = OfficeName;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    RegRs = frm.resutType;
                    CloseWin(this,true );
                    frm.icMsg1.timer1.Stop();
                }
            }
            else if (alerttype == "确认取消")
            {
                FrmYesNoAlert frm = new FrmYesNoAlert ();
                frm.TopMost = true;
                frm.lblMsg.Text = Msg;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    CloseWin(this, true);
                }
                else
                {
                    CloseWin(this, false );
                }
            }
            else if (alerttype == "信息")
            {
                FrmInfoAlert frm = new FrmInfoAlert();
                frm.TopMost = true;
               
                frm.lblMsg.Text = Msg;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    CloseWin(this, true);
                }

            }
            else if (alerttype == "读取身份证")
            {
                FrmWaitCard2 frm = new FrmWaitCard2();
                frm.TopMost = true;

                SoundPlayer soundPlayer = new SoundPlayer(Application.StartupPath + @"\\Sound\\身份证.wav");
                soundPlayer.Play();

                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    CloseWin(this, true);
                }
                else
                {
                    CloseWin(this, false);
                }

            }
            else if (alerttype == "发卡充值")
            {
                AddMoneyByCreatCard();
            }
            
        }
        //充值
        private void AddMoney()
        {
            FrmInMoney frm = new FrmInMoney();
            frm.icMsg1.timer1.Start();
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                frm.icMsg1.timer1.Stop();

                #region 打印小票模块
                //PrintReport(frm.cardSavingData, FrmMain.patientInfoData.Tables[0].Rows[0]["XingMing"].ToString(), frm.sum.ToString());

                Print cp = new Print();
                cp.PrintReport(FrmMain.patientInfoData.Tables[0].Rows[0]["XingMing"].ToString(), frm.sum.ToString());
                #endregion

                FrmInMoneyMsg fmm = new FrmInMoneyMsg();
                fmm.lblMoney.Text = frm.sum.ToString();
                if (fmm.ShowDialog() == DialogResult.OK)
                {
                    this.AddMoney();
                   
                }
                else
                {
                    CloseWin(this, true);
                }

            }
            else
            {
                CloseWin(this, false);
                frm.icMsg1.timer1.Stop();
            }
        }

        //发卡时充值充值
        private void AddMoneyByCreatCard()
        {
            FrmInMoneyByCreatCard frm = new FrmInMoneyByCreatCard();
            frm.icMsg1.timer1.Start();
            frm.TopMost = true;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                frm.icMsg1.timer1.Stop();

                #region 打印小票模块
                //PrintReport(frm.cardSavingData, FrmMain.patientInfoData.Tables[0].Rows[0]["XingMing"].ToString(), frm.sum.ToString());

                Print cp = new Print();
                cp.PrintReport(FrmMain.patientInfoData.Tables[0].Rows[0]["XingMing"].ToString(), frm.sum.ToString());
                #endregion

                FrmInMoneyMsg fmm = new FrmInMoneyMsg();
                fmm.lblMoney.Text = frm.sum.ToString();
                sumChargeMoney = sumChargeMoney + frm.sum;
                if (fmm.ShowDialog() == DialogResult.OK)
                {
                    this.AddMoneyByCreatCard();

                }
                else
                {
                    CloseWin(this, true);
                }

            }
            else
            {
                CloseWin(this, false);
                frm.icMsg1.timer1.Stop();
            }
        }

        /// <summary>
        /// 打印自助充值
        /// </summary>
        private void PrintReport(DataSet ds, string name, string sum)
        {
            ds.WriteXml(Application.StartupPath + @"\\ReportXml\\自助充值" + name + ds.Tables[0].Rows[0]["TRANSACTION_ID"].ToString() + ".xml");
            string path = Application.StartupPath + @"\\Reports\\自助充值.rmf";

            if (System.IO.File.Exists(path) == false)
            {
                //MyMsg.MsgInfo("自助充值票据不存在,请联系管理员!");
                return;
            }

            //引用 RM.ReportEngine.dll
            RMReportEngine.RMReport rmReport1 = new RMReportEngine.RMReport();

            //FrmMain frm = new FrmMain();
            rmReport1.Init(this, RMReportEngine.RMReportType.rmrtReport);
            rmReport1.AddDataSet(ds.Tables[0], "report");
            rmReport1.AddVariable("姓名", name, true);
            rmReport1.AddVariable("充值金额", sum, true);
            rmReport1.AddVariable("卡余额", FrmMain.cardBlance.ToString(), true);

            rmReport1.LoadFromFile(path);

            rmReport1.ShowPrintDialog = false;
            rmReport1.ShowProgress = false;
            rmReport1.ThreadPrepareReport = false;
            //rmReport1.ShowReport();
            rmReport1.PrintReport();
            rmReport1.Destroy();
        }

        private delegate void DeCloseWin(Form lv,bool isok);
        //提示信息
        void CloseWin(Form lv,bool  isok)
        {
            if (!lv.InvokeRequired)
            {
                if (isok)
                {
                    lv.DialogResult = DialogResult.OK;
                }
                else
                {
                    lv.DialogResult = DialogResult.Cancel;
                }
                
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DeCloseWin de = CloseWin;
                this.Invoke(de, lv);
            }
        }

        private void MyAlert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alerttype == "WaitReadCard")
            {
                fr.icMsg1.timer1.Stop();
                fr.Close();
            }
        }

        private void MyAlert_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
