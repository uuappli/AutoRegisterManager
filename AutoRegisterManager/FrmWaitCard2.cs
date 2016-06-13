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
using SystemFramework.IDCard;
namespace AutoRegisterManager
{
    //等待读取身份证信息
    public partial class FrmWaitCard2 : Form
    {
        private IDCardInfo idinfo = null;
        int sec = 30;
        public FrmWaitCard2()
        {
            InitializeComponent();
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
                    this.DialogResult = DialogResult.Cancel;
                }
                this.lblWaitTime.Text = sec.ToString();
                sec = sec - 1;
                if (idinfo != null)
                {
                    FrmMain.userInfo = idinfo;
                    if (FrmMain.userInfo != null)
                    {
                        timer1.Stop();
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Stop();
                MyMsg.MsgInfo(ex.Message);
               
            }
                
               
        }

        private void FrmWaitCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadIDCard.Instance.OnReadedInfo -= readIDCrad_OnReadedInfo;
            ReadIDCard.Instance.OnReadError -= readIDCrad_OnReadError;
            if (!ReadIDCard.Instance.IsRegister)
            {
                ReadIDCard.Instance.Over();
            }
        }

        private void FrmWaitCard2_Load(object sender, EventArgs e)
        {
            //读取二代身份证信息  
            ReadIDCard.Instance.OnReadedInfo += new EventHandler<ReadEventArgs>(readIDCrad_OnReadedInfo);
            ReadIDCard.Instance.OnReadError += new EventHandler<ReadErrorEventArgs>(readIDCrad_OnReadError);
            if (!ReadIDCard.Instance.IsRun)
            {
                ReadIDCard.Instance.Start(ReadType.读基本信息);
            }
        }

        private void readIDCrad_OnReadedInfo(object sender, ReadEventArgs e)
        {
            idinfo = new IDCardInfo();
            idinfo.Name = e.NewHuman.Name;

            idinfo.Address = e.NewHuman.Address;
            idinfo.Sex = e.NewHuman.Gender;
            idinfo.Birthday = e.NewHuman.BirthDay.ToString("yyyy-MM-dd");
            idinfo.Signdate = e.NewHuman.InceptDate;
            idinfo.Number = e.NewHuman.IDCardNo;
            idinfo.Name = e.NewHuman.Name;
            idinfo.People = e.NewHuman.Nation;
            idinfo.ValidDate = e.NewHuman.ExpireDate;
              


        }

        private void readIDCrad_OnReadError(object sender, ReadErrorEventArgs e)
        {

            MessageBox.Show(e.Error, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
