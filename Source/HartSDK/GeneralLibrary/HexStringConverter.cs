using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.GeneralLibrary
{
    /// <summary>
    /// 十六进制字符串与字节组之间的转换器
    /// </summary>
    public class HexStringConverter
    {
        #region 十六进制字节组处理函数
        /// <summary>
        /// 字符串转字节组
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StringToHex(string str)
        {
            str = str.Replace(" ", "");
            if (str.Length % 2 != 0)
            {
                str = "0" + str;
            }
            List<string> strarr = new List<string>();
            for (int i = 0; i < str.Length / 2; i++)
            {
                strarr.Add(str.Substring(i * 2, 2));
            }

            List<byte> bytearr = new List<byte>();

            foreach (string tempstr in strarr)
            {
                bytearr.Add(Convert.ToByte(Convert.ToInt32(tempstr.ToString(), 16)));
            }

            return bytearr.ToArray();
        }

        /// <summary>
        /// 字节组转十六进制字符串
        /// </summary>
        /// <param name="hexs"></param>
        /// <returns></returns>
        public static string HexToString(byte[] hexs, string split)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte hex in hexs)
            {
                if (!string.IsNullOrEmpty(split))
                {
                    sb.Append(hex.ToString("X2") + split);
                }
                else
                {
                    sb.Append(hex.ToString("X2"));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 十六进制字节组比较
        /// </summary>
        /// <param name="bytes1"></param>
        /// <param name="bytes2"></param>
        /// <returns></returns>
        public static bool HexEquals(byte[] bytes1, byte[] bytes2)
        {
            if (bytes1.Length != bytes2.Length)
            {
                return false;
            }
            for (int i = 0; i < bytes1.Length; i++)
            {
                if (bytes1[i] != bytes2[i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
