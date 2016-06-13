using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CardInterface;
using Skynet.Data;
using Skynet.Framework.Common;
using Skynet.ExceptionManagement;
using System.Xml;
using AutoRegisterManager.Common;
using Skynet.LoggingService;
using AutoRegisterManager.SdkService;
using System.Diagnostics;
using System.Media;

namespace AutoRegisterManager
{
    public partial class FrmMain : Form
    {
        public static DataSet patientInfoData=new DataSet ();
        public static CardInformationStruct cardInfoStruct = new CardInformationStruct();
        public static DataSet cardData = new DataSet();
        public static DataSet doctorData = new DataSet();
        public static DataSet RegType = new DataSet();
        public static IDCardInfo userInfo = new IDCardInfo();
        public static Decimal cardBlance = 0;
        public static string fbID = string.Empty;//费用类别（发卡用）
        private int cxenable = 0;

        public FrmMain()
        {
            InitializeComponent();

            timer1.Start();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            showweb(1);
        }
        //自助充值
        private void label13_Click(object sender, EventArgs e)
        {
            string cardtype = SkyComm.getvalue("读卡器类型");
            if (cardtype == "302H")
            {
                FrmInCard302H fi = new FrmInCard302H();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync("充值");
                }
                else
                {
                    return;
                }
            }
            else if (cardtype == "M100")
            {
                FrmInCardM100 fi = new FrmInCardM100();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync("充值");
                }
                else
                {
                    return;
                }
            }
            else
            {
                FrmInCardUniversal fi = new FrmInCardUniversal();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync("充值");
                }
                else
                {
                    return;
                }
            }
        }
        //自助挂号
        private void lblguahao_Click(object sender, EventArgs e)
        {
            string cardtype = SkyComm.getvalue("读卡器类型");
            if (cardtype == "302H")
            {
                FrmInCard302H fi = new FrmInCard302H();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync("挂号");
                }
                else
                {
                    return;
                }
            }
            else if (cardtype == "M100")
            {
                FrmInCardM100 fi = new FrmInCardM100();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync("挂号");
                }
                else
                {
                    return;
                }
            }
            else
            {
                FrmInCardUniversal fi = new FrmInCardUniversal();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker1.RunWorkerAsync("挂号");
                }
                else
                {
                    return;
                }
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.Equals("挂号"))
            {
                e.Result = "挂号";
            }
            else if (e.Argument.Equals("充值"))
            {
                e.Result = "充值";
            }
            else if (e.Argument.Equals("读证"))
            {
                e.Result = "读证";
            }
            else if (e.Argument.Equals("发卡"))
            {
                e.Result = "发卡";
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result.Equals("挂号"))
            {
                //FrmOfficeList fz = new FrmOfficeList();
                //ShowWin(fz);
            }
            else if (e.Result.Equals("充值"))
            {
                FrmRecharge fr = new FrmRecharge();
                ShowWin(fr);
            }
            else if (e.Result.Equals("读证"))
            {
           
                FrmTakeCard fc = new FrmTakeCard();
                ShowWin(fc);
            }
            else if (e.Result.Equals("发卡"))
            {
                FrmGetCard fc = new FrmGetCard();
                ShowWin(fc);
            }
        }
        private delegate void DeShowWin(Form lv);
        //提示信息
        void ShowWin(Form lv)
        {
            if (!lv.InvokeRequired)
            {
                if (lv.Name == "FrmTakeCard")
                {
                    if (lv.ShowDialog() == DialogResult.OK)
                    {
                        backgroundWorker1.RunWorkerAsync("发卡");
                    }
                }
                else
                {
                    lv.ShowDialog();
                }
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DeShowWin de = ShowWin;
                this.Invoke(de, lv);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            showweb(2);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //patientInfoData = new PatientInfoData();
            SkyComm.Init();
        }
        
       

        private void label8_Click(object sender, EventArgs e)
        {
            showweb(6);
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void showweb(int index)
        {
            FrmWebLoad frmWebLoad = new FrmWebLoad();
            switch (index)
            {
                case 1:
                    {
                        frmWebLoad.webBrowser1.Url = new Uri(SkyComm.getvalue("yygk"));
                        break;
                    }
                case 2:
                    {
                        frmWebLoad.webBrowser1.Url = new Uri(SkyComm.getvalue("jzzn"));
                        break;
                    }
                case 3:
                    {
                        frmWebLoad.webBrowser1.Url = new Uri(SkyComm.getvalue("zjjs"));
                        break;
                    }
                case 4:
                    {
                        frmWebLoad.webBrowser1.Url = new Uri(SkyComm.getvalue("ksjs"));
                        break;
                    }
                case 5:
                    {
                        frmWebLoad.webBrowser1.Url = new Uri(SkyComm.getvalue("ywgk"));
                        break;
                    }
                case 6:
                    {
                        frmWebLoad.webBrowser1.Url = new Uri(SkyComm.getvalue("ylcs"));
                        break;
                    }
            }
            frmWebLoad.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            showweb(3);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            showweb(4);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            showweb(5);
        }
        //发卡
        private void lblFk_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync("读证");

        }

        private void label19_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            string cardtype = SkyComm.getvalue("读卡器类型");
            if (cardtype == "302H")
            {
                FrmInCard302H fi = new FrmInCard302H();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    //backgroundWorker1.RunWorkerAsync("完成");
                }
                else
                {
                    return;
                }
            }
            else if (cardtype == "M100")
            {
                FrmInCardM100 fi = new FrmInCardM100();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    ////backgroundWorker1.RunWorkerAsync("完成");
                }
                else
                {
                    return;
                }
            }
            else
            {
                FrmInCardUniversal fi = new FrmInCardUniversal();
                if (fi.ShowDialog() == DialogResult.OK)
                {
                    //backgroundWorker1.RunWorkerAsync("完成");
                }
                else
                {
                    return;
                }
            }

            cxenable = 0;
            label1.Enabled = false;

            try
            {
                Process p = Process.Start(Application.StartupPath + @"\\Feelmanager.exe", FrmMain.cardInfoStruct.CardNo);
                //SoundPlayer soundPlayer = new SoundPlayer(Application.StartupPath + @"\\Sound\\医卡通.wav");
                //soundPlayer.Play();
                //p.WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //Process p = Process.Start(Application.StartupPath + @"\\Feelmanager.exe");
            //SoundPlayer soundPlayer = new SoundPlayer(Application.StartupPath + @"\\Sound\\医卡通.wav");
            //soundPlayer.Play();
            //p.WaitForExit();


            //label1.Enabled = true;
            //string cardtype = SkyComm.getvalue("读卡器类型");
            //if (cardtype == "302H")
            //{
            //    FrmInCard302H fi = new FrmInCard302H();
            //    if (fi.ShowDialog() == DialogResult.OK)
            //    {
            //        backgroundWorker1.RunWorkerAsync("充值");
            //    }
            //}
            //else if (cardtype == "M100")
            //{
            //    FrmInCardM100 fi = new FrmInCardM100();
            //    if (fi.ShowDialog() == DialogResult.OK)
            //    {
            //        backgroundWorker1.RunWorkerAsync("充值");
            //    }
            //}
            //else
            //{
            //    FrmInCardUniversal fi = new FrmInCardUniversal();
            //    if (fi.ShowDialog() == DialogResult.OK)
            //    {
            //        backgroundWorker1.RunWorkerAsync("充值");
            //    }
            //}
        }

        private void label3_Click_1(object sender, EventArgs e)
        {
            FrmCardSummary frm = new FrmCardSummary();
            frm.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cxenable ++;
            if (cxenable == 5)
            {
                cxenable = 0;
                label1.Enabled = true;
            }
        }

    }
}
