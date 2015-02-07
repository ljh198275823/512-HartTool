using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HartSDK
{
    /// <summary>
    /// 表示温度补偿参数
    /// </summary>
    [Serializable]
    public class TemperatureCompensation
    {
        #region 构造函数
        public TemperatureCompensation()
        {
        }
        #endregion

        #region 公共属性
        public float TemperatureAD { get; set; }

        public float LowerRangeAD { get; set; }

        public float UpperRangeAD { get; set; }
        #endregion
    }
}
