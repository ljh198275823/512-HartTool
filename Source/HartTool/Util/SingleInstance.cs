using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LJH.HartTool.Util
{
    /// <summary>
    /// 这个类用于控制应用程序一次只有一个实例运行
    /// </summary>
    public class SingleInstance
    {
        #region 私有变量
        private const int SW_SHOWNORMAL = 1;//正常显示窗口
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_SHOWNOACTIVATE = 4;
        private const int SW_RESTORE = 9;
        private const int SW_SHOWDEFAULT = 10;
        private static Mutex mutex = null;
        #endregion

        #region 库函数
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(System.IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(System.IntPtr hWnd);
        #endregion

        #region 私有方法
        private static void HandleRunningInstance(Process instance, int show)
        {
            ShowWindowAsync(instance.MainWindowHandle, show);  //调用api函数，
            SetForegroundWindow(instance.MainWindowHandle); //将窗口放置最前端
        }

        private static bool CreateMutex(string name)
        {
            bool result = false;
            mutex = new Mutex(true, name, out result);
            return result;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 操作系统上是否存在此应用程序的进程
        /// </summary>
        /// <returns></returns>
        public static bool ExistsProcess()
        {
            return !CreateMutex(Assembly.GetEntryAssembly().FullName);
        }

        /// <summary>
        /// 连接到打开的应用程序进程
        /// </summary>
        public static void ShowSingleProcess()
        {
            ShowSingleProcess(1);
        }

        /// <summary>
        /// 连接到打开的应用程的进程
        /// </summary>
        public static void ShowSingleProcess(int Show)
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            //遍历与当前进程名称相同的进程列表  
            foreach (Process process in processes)
            {
                //如果实例已经存在则忽略当前进程  
                if (process.Id != current.Id)
                {
                    HandleRunningInstance(process, Show);
                }
            }
        }
        #endregion
    }
}