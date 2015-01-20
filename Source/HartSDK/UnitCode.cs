using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    public enum  UnitCode
    {
        /// <summary>
        /// inH2O
        /// </summary>
        inH2O=0x01,
        /// <summary>
        /// inHg
        /// </summary>
        inHg=0x02,

        ftH2O=0x03,

        mmH2O=0x04,

        mmHg=0x05,

        psi=0x06,

        bar=0x07,

        mbar=0x08,

        gcm2=0x09,

        kgcm2=0x0A,

        Pa=0x0B,

        /// <summary>
        /// KPa
        /// </summary>
        KPa=0x0C,
        /// <summary>
        /// TORR
        /// </summary>
        torr=0x0D,
        /// <summary>
        /// ATM
        /// </summary>
        atm=0x0E,

        MPa=0x0F,

        mA=0x10,
        /// <summary>
        /// 百分比
        /// </summary>
        percent=0x11,
    }

    public class UnitCodeDescr
    {
        public static string GetDescr(UnitCode uc)
        {
            return uc.ToString();
        }
    }
}
