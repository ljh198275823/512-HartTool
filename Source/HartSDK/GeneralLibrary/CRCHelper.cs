using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.GeneralLibrary
{
    public class CRCHelper
    {
        public static byte CalCRC(IEnumerable<byte> buffer)
        {
            byte checksum = 0;
            foreach (byte b in buffer)//从长度到数据
            {
                checksum ^= b;
            }
            return checksum;
        }
    }
}
