using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoRegisterManager.Common
{
    public class MyMsg
    {
        public static void MsgInfo(string msg)
        {
            MyAlert m = new MyAlert();
            m.alerttype = "信息";
            m.Msg = msg;
            m.ShowDialog();
            
        }
    }
}
