using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.GeneralLibrary
{
    public class PackAsciiHelper
    {
        #region 静态方法
        public static byte[] GetBytes(string str, int count)
        {
            byte[] ret = new byte[count];
            if (!string.IsNullOrEmpty(str))
            {
                byte[] temp = ASCIIEncoding.ASCII.GetBytes(str);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in temp)
                {
                    sb.Append(Convert.ToString(b, 2).PadLeft (8,'0').Substring(2));
                }
                for (int i = 0; i < count; i++)
                {
                    if (sb.ToString().Length >= 8)
                    {
                        string bs = sb.ToString().Substring(0, 8);
                        sb.Remove(0, 8);
                        ret[i] = Convert.ToByte(bs, 2);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return ret;
        }

        public static string GetString(byte[] data)
        {
            if (data != null && data.Length > 0)
            {
                List<byte> temp = new List<byte>();
                StringBuilder sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(Convert.ToString(b, 2).PadLeft (8,'0'));
                }
                while (sb.ToString().Length >= 6)
                {
                    string bs = "00" + sb.ToString().Substring(0, 6);
                    sb.Remove(0, 6);
                    byte b = Convert.ToByte(bs, 2);
                    if (b < 0x20) b += 0x40;
                    temp.Add(b);
                }
                return ASCIIEncoding.ASCII.GetString(temp.ToArray());
            }
            return null;
        }
        #endregion
    }
}
