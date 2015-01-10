using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.GeneralLibrary
{
    /// <summary>
    /// BCD格式的转换器
    /// </summary>
    internal class BCDConverter
    {
        /// <summary>
        /// 这个函数主要是把两位的整数（0-99）转换成一个BCD表示，刚好一个字节
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte IntToBCD(int val)
        {
            if (val >= 0 && val <= 99)
            {
                int h = val / 10;
                int l = val % 10;
                return (byte)((h << 4) + l);
            }
            else
            {
                throw new InvalidOperationException("IntToBCD 不接受超过100的整数作为参数");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int BCDtoInt(byte val)
        {
            return (val >> 4) * 10 + (val & 0x0f);
        }
    }
}
