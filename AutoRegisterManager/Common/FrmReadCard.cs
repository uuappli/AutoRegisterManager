using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace AutoRegisterManager.Common
{
    public partial class FrmReadCard : Form
    {
        public bool isok = false;
        public FrmReadCard()
        {
            InitializeComponent();
            
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 99; i++)
            {
                SetValue(this.progressBar2, i);
                Thread.Sleep(10);
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // this.CloseWin(this);
        }
        private delegate void DeSetValue(BSE.Windows.Forms.ProgressBar lv,int value);
        //提示信息
        void SetValue(BSE.Windows.Forms.ProgressBar lv, int value)
        {
            if (!lv.InvokeRequired)
            {
                lv.Value = value;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DeSetValue de = SetValue;
                this.Invoke(de, lv,value);
            }
        }
        private delegate void DeCloseWin(Form lv);
        //提示信息
        void CloseWin(Form lv)
        {
            if (!lv.InvokeRequired)
            {
                isok = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // 多线程调用时，通过主线程去访问
                DeCloseWin de = CloseWin;
                this.Invoke(de, lv);
            }
        }

        private void FrmReadCard_Load(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
