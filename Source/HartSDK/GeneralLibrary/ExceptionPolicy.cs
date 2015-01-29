
using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LJH.GeneralLibrary.ExceptionHandling
{
    public static class ExceptionPolicy
    {
        #region 公共方法
        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="ex">产生的异常</param>
        /// <param name="methodName">产生异常的方法名</param>
        public static void HandleException(Exception ex, string methodName)
        {
            try
            {
                string dir = Path.Combine(Application.StartupPath, @"TextFile");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                string message = "\r\n" +
                          "异常类型:" + ex.GetType().Name + "\r\n" +
                          "发生时间:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" +
                          "异常描述:" + ex.Message + "\r\n" +
                          "异常堆栈：\r\n" +
                          ex.StackTrace + "\r\n" +
                          "--------------------------------------------------------------------------------------------------------------------------------------------------\r\n";
                string file = Path.Combine(dir, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
                using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.Write(message);
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// 处理异常
        /// </summary>
        /// <param name="ex">产生的异常</param>
        public static void HandleException(Exception ex)
        {
            HandleException(ex, null);
        }
        #endregion 
    }
}
