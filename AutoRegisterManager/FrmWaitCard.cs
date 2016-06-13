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
    //等待读取身份证信息
    public partial class FrmWaitCard : Form
    {
        IDCard ic=new IDCard ();
        int sec = 30;
        public FrmWaitCard()
        {
            InitializeComponent();
            if (!ic.openPort())
            {
                return ;
            }
            timer1.Start();
        }

        private void lblcancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (sec == 0)
                {
                    this.timer1.Stop();
                    this.DialogResult = DialogResult.OK;
                }
                this.lblWaitTime.Text = sec.ToString();
                sec = sec - 1;

                FrmMain.userInfo = ic.ReadIDCard();
                if (FrmMain.userInfo != null)
                {
                    timer1.Stop();
                    ic.ClosePort();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                ic.ClosePort();
                timer1.Stop();
                MyMsg.MsgInfo(ex.Message);
               
            }
                
               
        }

        private void FrmWaitCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            ic.ClosePort();
        }
        //public IDCardInfo getUserInfo()
        //{
        //    IDCardInfo userinfo = new IDCardInfo();
        //    userinfo.Address = "陕西省渭南市临渭区崇宁镇";
        //    userinfo.Birthday = "1990-12-23";
        //    userinfo.Name = "张广放";
        //    userinfo.Number = "610502198603303515";
        //    userinfo.People = "汉族";
        //    userinfo.Sex = "男";
        //    return userinfo;
        //}
    }
}
