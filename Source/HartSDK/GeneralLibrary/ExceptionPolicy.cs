
using System;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace LJH.GeneralLibrary.ExceptionHandling
{
    internal static class ExceptionPolicy
    {
        #region ��������
        /// <summary>
        /// �����쳣
        /// </summary>
        /// <param name="ex">�������쳣</param>
        /// <param name="methodName">�����쳣�ķ�����</param>
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
                          "�쳣����:" + ex.GetType().Name + "\r\n" +
                          "����ʱ��:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n" +
                          "�쳣����:" + ex.Message + "\r\n" +
                          "�쳣��ջ��\r\n" +
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
        /// �����쳣
        /// </summary>
        /// <param name="ex">�������쳣</param>
        public static void HandleException(Exception ex)
        {
            HandleException(ex, null);
        }
        #endregion 
    }
}
