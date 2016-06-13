using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRegisterManager.SDK;
using System.Windows.Forms;
using System.Data;
using Skynet.Framework.Common;

namespace AutoRegisterManager.SdkService
{
    /// <summary>
    /// 热敏打印机
    /// 作者：田虎
    /// DATE：2012-03-20
    /// </summary>
    public class Print
    {
        /// <summary>
        /// 打印机初始化
        /// </summary>
        /// <param name="port">端口</param>
        /// <returns></returns>
        public bool InitPrint()
        {
            short a = DPrinter.ComInit(Convert.ToChar(3));
            if (a != 0)
            {
                return false;
            }
            short init = DPrinter.InitPrinter();
            if (init != 0)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="value">打印内容</param>
        /// <param name="type">打印设置</param>
        public void PrintContent(string value, int mode, char fontsize,bool  ismiddile)
        {
            
            try
            {

                DPrinter.PrintMode(mode);
                DPrinter.SetFontSize(fontsize);
                DPrinter.SetLMargin(50, 0);
                if (ismiddile)
                {
                    DPrinter.JustMode((char)1);
                }
                else
                {
                    DPrinter.JustMode((char)0);
                }
                short print = DPrinter.Sprint((char)0, (char)0, value);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 切纸
        /// </summary>
        public void cutPage()
        {
            int cut = DPrinter.CutPaper((char)1);
        }
        public void PrintReport(string name, string sum)
        {
            InitPrint();
            DPrinter.LineFeed();
            PrintContent("齐都医院收款凭证", 0, (char)1, true);
            PrintContent("----------------------------------------------------", 11, (char)0, false);
            PrintContent("姓  名：" + name + " ", 0, (char)0, false);
            PrintContent("充值金额：" + sum + "元 ", 0, (char)0, false); ;
            PrintContent("卡余额：" + FrmMain.cardBlance.ToString() + "元 ", 0, (char)0, false);
            PrintContent("证件号码：" + FrmMain.patientInfoData.Tables[0].Rows[0]["ShenFenZheng"] == null ? "" : FrmMain.patientInfoData.Tables[0].Rows[0]["ShenFenZheng"].ToString(), 0, (char)0, false);
            PrintContent("充值类型：现金 ", 0, (char)0, false);

            PrintContent("卡  号：" + FrmMain.cardInfoStruct.CardNo + " ", 0, (char)0, false);
            PrintContent("充值日期：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), 0, (char)0, false);
            PrintContent("----------------------------------------------------", 11, (char)0, false);
            PrintContent("提示：请妥善保管本凭证！", 0, (char)0, false);
            DPrinter.LineFeed();
            this.cutPage();
          
        }
    }
}
