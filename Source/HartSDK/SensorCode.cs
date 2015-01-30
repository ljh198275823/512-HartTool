using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    public enum SensorCode
    {
        _2 = 2,
        _3 = 3,
        _4 = 4,
        _5 = 5,
        _6 = 6,
        _7 = 7,
        _8 = 8,
        _9 = 9,
        _0 = 10,
        _NC = 11,
        _默认增溢 = 12,
        _1倍增溢 = 13,
        _2倍增溢 = 14,
        _4倍增溢 = 15,
        _8倍增溢 = 16,
        _16倍增溢 = 17,
        _32倍增溢 = 18,
    }

    public class SensorCodeDescr
    {
        public static string GetDescr(SensorCode sc)
        {
            return sc.ToString().Substring(1);
        }
    }
}


