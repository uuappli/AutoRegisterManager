using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Skynet.Framework.Common;

namespace AutoRegisterManager.Common
{
    public class ComPrint
    {
        //AxTTDriverMgr ax;
        public ComPrint()
        {
            //this.ax = atm;
            #region 打开打印端口
            //int i = atm.OpenDriver(TTDeviceMgr.DT_RPPRINT, "COM6", Application.StartupPath + "\\dll\\TTReceiptPrinter.dll", "");
            //if (i != 0)
            //{
            //    int errorNum = atm.GetDeviceStatus(TTDeviceMgr.DT_RPPRINT);
            //    MyMsg.MsgInfo(TTDeviceMgr.GetStatusInfo(errorNum) + ",错误代码：" + errorNum.ToString());
            //    return;
            //}
            #endregion
        }
       
        public void printInfo(DataSet ds, string name,string doctorName,string officeName,string regmoney)
        {
            string worktype = string.Empty;
            if (DateTime.Now.Hour < 12)
            {
                worktype = "上午";
            }
            else
            {
                worktype = "下午";
            }
            //SchedulFacade facade = new SchedulFacade();
            //DataSet dszs = facade.QueryPatientInfo(ds.Tables[0].Rows[0]["REGISTERID"].ToString ());
            //ax.RPPrintText("陕西省妇幼保健院\n");
            //ax.RPPrintText("   分诊挂号凭证 \n");
            //ax.RPPrintText("---------------------------------------\n");
            //ax.RPPrintText("姓  名： ");
            //ax.RPPrintText(name + "\n");
            //ax.RPPrintText("医  师： ");
            //ax.RPPrintText(doctorName + "\n");
            //ax.RPPrintText("科  室： ");
            //ax.RPPrintText(dszs.Tables[0].Rows[0]["EXAMINENAME"].ToString () + "\n");
            //ax.RPPrintText("挂号费： ");
            //ax.RPPrintText(regmoney + "元\n");
            //ax.RPPrintText("操作员： ");
            //ax.RPPrintText(SysOperatorInfo.OperatorName + "\n");
            //ax.RPPrintText("排队号： "  );
            //ax.RPPrintText(ds.Tables[0].Rows[0]["WORKTYPE"] == null ? "" : ds.Tables[0].Rows[0]["WORKTYPE"].ToString()+"：" );
            //ax.RPPrintText( ds.Tables[0].Rows[0]["QUEUEID"] == null ? "" : dszs.Tables[0].Rows[0]["QUEUEID"].ToString() + "\n");
            //ax.RPPrintText("挂号日期： ");
            //ax.RPPrintText(DateTime .Now .ToString()+ "\n");
            //ax.RPPrintText("挂号号： ");
            //ax.RPPrintText(ds.Tables[0].Rows[0]["REGISTERID"].ToString() + "\n");
            //ax.RPPrintText("---------------------------------------\n");
            //ax.RPPrintEnter();
            //ax.RPPrintEnter();
            //ax.RPPrintEnter();
            //ax.RPPrintEnter();
            //ax.RPCutPaper(0);
           
          


        }
        public void ClosePrint()
        {
            #region 关闭打印端口
            //int i = ax.CloseDriver(TTDeviceMgr.DT_RPPRINT);
            //if (i != 0)
            //{
            //    MessageBox.Show("关闭端口失败 错误码：" + ax.GetDeviceStatus(TTDeviceMgr.DT_RPPRINT).ToString());
            //    return;
            //}
            #endregion
        }

        public void PrintReport(DataSet ds,string name,string sum)
        {

            //ax.RPPrintText("陕西省妇幼保健院\n");
            //ax.RPPrintText("---------------------------------------\n");
            //ax.RPPrintText("收据号： ");
            //ax.RPPrintText(ds.Tables [0].Rows[0]["TRANSACTION_ID"].ToString ()+"\n");
            //ax.RPPrintText("姓  名： ");
            //ax.RPPrintText(name + "\n");
            //ax.RPPrintText("充值金额： ");
            //ax.RPPrintText(sum + "元\n");
            //ax.RPPrintText("卡余额： ");
            //ax.RPPrintText(FrmMain.cardBlance.ToString () + "元\n");

            //ax.RPPrintText("证件号码： ");
            //ax.RPPrintText(FrmMain.patientInfoData.Tables[0].Rows[0]["IDENTITYCARD"] == null ? "" : FrmMain.patientInfoData.Tables[0].Rows[0]["IDENTITYCARD"].ToString() + "\n");
            //ax.RPPrintText("操作员： ");
            //ax.RPPrintText(SysOperatorInfo.OperatorName + "\n");
            //ax.RPPrintText("充值类型： ");
            //ax.RPPrintText( "现金\n");
            
            //ax.RPPrintText("卡票号： ");
            //ax.RPPrintText(ds.Tables[0].Rows[0]["CHECKLOT"].ToString() + "\n");
            //ax.RPPrintText("充值日期： ");
            //ax.RPPrintText(DateTime.Now.ToString ()+"\n");
            //ax.RPPrintText("---------------------------------------\n");
            //ax.RPPrintText("提示：此小票作为退卡凭证，请妥善保管！\n\n\n ");
            //ax.RPPrintEnter();
            //ax.RPPrintEnter();
            //ax.RPPrintText(" \n");
            //ax.RPCutPaper(0);


            //ds.WriteXml(Application.StartupPath + @" \\ReportXml\\充值发票.xml");
            ////引用 RM.ReportEngine.dll
            //RMReportEngine.RMReport rmReport1 = new RMReportEngine.RMReport();
            //rmReport1.Init(f, RMReportEngine.RMReportType.rmrtReport);
            //rmReport1.AddDataSet(ds.Tables[0], "report1");
            ////rmReport1.AddVariable("医院名称", SysOperatorInfo.CustomerName,true);
            ////rmReport1.AddVariable("StartDate", txtStartDate.Text + " " + txtStartTime.Text, true);
            ////rmReport1.AddVariable("EndDate", txtEndDate.Text + " " + txtEndTime.Text, true);
            ////rmReport1.AddVariable("DATE", DateTime.Now.ToString(), true);
            ////rmReport1.AddVariable("操作员", SysOperatorInfo.OperatorID, true);
            ////rmReport1.AddVariable("操作员代码", SysOperatorInfo.OperatorCode, true);
            ////dialog.Caption = "准备报表...";
            //string path = Application.StartupPath + @" \\Reports\\充值票据.rmf";

            //if (System.IO.File.Exists(path) == false)
            //{
            //    SkynetMessage.MsgError("出充值票据不存在,请查证!");
            //    rmReport1.Destroy();
            //    //dialog.Close();
            //    return;
            //}
            //rmReport1.LoadFromFile(path);
            //rmReport1.PrintReport();
            //rmReport1.Destroy();
            //rmReport1.Dispose();
        }

        //rmReport1.ThreadPrepareReport = true;
        //rmReport1.ShowReport();
        //rmReport1.Destroy();
        //rmReport1.Dispose();

    }
}
