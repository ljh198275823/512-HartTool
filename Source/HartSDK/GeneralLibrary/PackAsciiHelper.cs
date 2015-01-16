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
                byte[] temp = HexStringConverter.StringToHex(str);
                Array.Copy(temp, 0, ret, 0, temp.Length > ret.Length ? ret.Length : temp.Length);
            }
            return ret;
        }

        public static string GetString(byte[] data)
        {
            if (data != null && data.Length > 0)
            {
                return HexStringConverter.HexToString(data, string.Empty);
            }
            return null;
        }
        #endregion
    }
}
