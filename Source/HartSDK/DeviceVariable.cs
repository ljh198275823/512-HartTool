using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HartSDK
{
    /// <summary>
    /// 表示设备变量
    /// </summary>
    [Serializable]
    public class DeviceVariable
    {
        #region 构造函数
        public DeviceVariable() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置变量的计量单位码
        /// </summary>
        public UnitCode UnitCode { get; set; }
        /// <summary>
        /// 获取或设置变量的值
        /// </summary>
        public float Value { get; set; }
        #endregion
    }
}
