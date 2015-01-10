using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HartTool.Util;

namespace HartTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!SingleInstance.ExistsProcess())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form frm = new FrmMain();
                Application.Run(frm);
            }
            else
            {
                SingleInstance.ShowSingleProcess();
            }
        }
    }
}
