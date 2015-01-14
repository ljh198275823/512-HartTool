using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    /// <summary>
    /// 表示设备的电流和量程百分比
    /// </summary>
    [Serializable]
    public class CurrentInfo
    {
        #region 构造函数
        public CurrentInfo() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置电流大小(毫安)
        /// </summary>
        public float Current { get; set; }
        /// <summary>
        /// 获取或设置量程的百分比
        /// </summary>
        public float PercentOfRange { get; set; }
        #endregion
    }
}
