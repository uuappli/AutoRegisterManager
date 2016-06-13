using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AutoRegisterManager.Common;

namespace AutoRegisterManager
{
    //充值记录
    public partial class FrmRechargeRecord : Form
    {
        DataTable  ds = new DataTable ();
        private int startIndex = 0;
        public FrmRechargeRecord()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dataBind()
        {
           DataTable  dt = ds.Clone();
            dt.Clear();
            for (int i = 0; i < 12; i++)
            {
                if (startIndex > ds.Rows.Count - 1)
                {
                    startIndex++;
                    continue;
                }
                dt.ImportRow(ds.Rows[startIndex]);
                startIndex++;
            }
            this.gridControl1.DataSource = dt;
            if (startIndex % 12> 0)
            {
                this.lblNowPage.Text = String.Format("第{0}页", (startIndex / 12) + 1);
            }
            else
            {
                this.lblNowPage.Text = String.Format("第{0}页", startIndex / 12);
            }
            if (ds.Rows.Count % 12 > 0)
            {
                this.lblAllPage.Text = String.Format("（共{0}页）", (ds.Rows.Count / 12) + 1);
            }
            else
            {
                this.lblAllPage.Text = String.Format("（共{0}页）", ds.Rows.Count / 12);
            }

        }
        //充值记录数据准备
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            this.isShowlbl(this.lblMsg, true);
            //CardSavingFacade cardsavingfacade=new CardSavingFacade ();
            //this.cardsavingdata = (CardSavingData)cardsavingfacade.FindCardMoneyByCardID(FrmMain.cardInfoStruct.CardNo);
        }
        private delegate void DeisShowlbl(Label lv, bool isok);
        //提示信息
        void isShowlbl(Label lv, bool isok)
        {
            if (!lv.InvokeRequired)
            {
                lv.Visible = isok;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DeisShowlbl de = isShowlbl;
                this.Invoke(de,lv,isok );
            }
        }
        private void FrmRechargeRecord_Load(object sender, EventArgs e)
        {
            //cardsavingdata = new CardSavingData();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //if (this.cardsavingdata == null || this.cardsavingdata.Tables["T_CARD_SAVING"].Rows.Count <= 0)
                //{
                //    MessageBox.Show("没有数据");
                //    this.lblMsg.Visible = false;
                //    return;
                //}
                //this.gridControl1.DataSource = this.cardsavingdata.Tables["T_CARD_SAVING"].DefaultView;
                rowFilter(-1);
                this.isShowlbl(this.lblMsg, false );
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message );
            }
        }
        //三个月内
        private void lbl3m_Click(object sender, EventArgs e)
        {
            rowFilter(-3);
        }
        //一个月内
        private void lbl1m_Click(object sender, EventArgs e)
        {
            rowFilter(-1);

        }
        //半年内
        private void lbl6m_Click(object sender, EventArgs e)
        {
            rowFilter(-6);
        }
        private void  rowFilter(int month)
        {
            startIndex = 0;
            //this.cardsavingdata.Tables["T_CARD_SAVING"].DefaultView.RowFilter = "ADDMONEYDATE>'" + Convert.ToDateTime(DateTime.Now.AddMonths(month).ToShortDateString()) + "' AND BUSINESSTYPE='充值'";
            //ds= this.cardsavingdata.Tables["T_CARD_SAVING"].DefaultView.ToTable();
            dataBind();
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (startIndex > ds.Rows.Count - 1)
            {
                MyMsg.MsgInfo("已经是最后一页了！");
                return;
            }
            dataBind();
        }

        private void btnBeforePage_Click(object sender, EventArgs e)
        {
            if (startIndex - 24 < 0)
            {
                MyMsg.MsgInfo("已经是第一页了！");
                return;
            }
            startIndex = startIndex - 24;
            dataBind();
        }
    }
}
