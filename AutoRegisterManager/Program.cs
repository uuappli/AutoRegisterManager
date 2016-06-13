using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AutoRegisterManager.Common;

namespace AutoRegisterManager
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //System.Runtime.Remoting.RemotingConfiguration.Configure("AutoRegisterManager.exe.config", false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
