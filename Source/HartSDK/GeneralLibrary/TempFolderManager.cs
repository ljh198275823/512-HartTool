using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace LJH.GeneralLibrary
{
    /// <summary>
    /// 一个管理停车场临时文件目录的管理器
    /// </summary>
    internal class TempFolderManager
    {
        private static string _dic;

        static TempFolderManager()
        {
            _dic = Path.Combine(Application.StartupPath, "TempFiles");
            if (!Directory.Exists(_dic))
            {
                Directory.CreateDirectory(_dic);
            }

            //定时删除临时文件
            Thread t = new Thread(DeleteTempFilesThread);
            t.IsBackground = true;
            t.Start();
        }

        /// <summary>
        /// 获取当前的临时文件目录
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentFolder()
        {
            string dir = Path.Combine(_dic, DateTime.Now.ToString("yyyy-MM-dd"));
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }


        private static void DeleteTempFilesThread()
        {
            while (true)
            {
                try
                {
                    //每隔一个小时把临时文件夹删除
                    string[] dirs = Directory.GetDirectories(_dic);
                    foreach (string dir in dirs)
                    {
                        try
                        {
                            if (dir != Path.Combine(_dic, DateTime.Now.ToString("yyyy-MM-dd")))
                            {
                                Directory.Delete(dir, true);
                            }
                            else
                            {
                                string[] files = Directory.GetFiles(dir);
                                foreach (string file in files)
                                {
                                    try
                                    {
                                        DateTime dt = File.GetLastWriteTime(file);
                                        TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - dt.Ticks);
                                        if (ts.TotalMinutes > 30) File.Delete(file);
                                    }
                                    catch (IOException ex)
                                    {
                                    }
                                    catch (Exception ex)
                                    {
                                        LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                                    }
                                }
                            }
                        }
                        catch (IOException ex)
                        {
                        }
                        catch (Exception ex)
                        {
                            LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                        }
                    }
                }
                catch (IOException ex)
                {
                }
                catch (Exception ex)
                {
                    LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                }
                Thread.Sleep(60 * 60 * 1000);
            }
        }
    }
}
