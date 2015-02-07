using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HartSDK
{
    /// <summary>
    /// 表示传感器信息
    /// </summary>
    [Serializable]
    public class SensorInfo
    {
        #region 构造函数
        public SensorInfo() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置传感器序列号
        /// </summary>
        public int SensorSN { get; set; }
        /// <summary>
        /// 获取或设置传感器计量单位码
        /// </summary>
        public UnitCode UnitCode { get; set; }
        /// <summary>
        /// 获取或设置传感器量程上限
        /// </summary>
        public float UpperLimit { get; set; }
        /// <summary>
        /// 获取或设置传感器量程下限
        /// </summary>
        public float LowerLimit { get; set; }
        /// <summary>
        /// 获取或设置传感器量程的最小跨度
        /// </summary>
        public float MinimumSpan { get; set; }
        #endregion
    }
}
