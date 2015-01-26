using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    /// <summary>
    /// 表示线性化参数
    /// </summary>
    public class LinearizationItem
    {
        #region 构造函数
        public LinearizationItem()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置传感器值
        /// </summary>
        public float SensorValue { get; set; }
        /// <summary>
        /// 获取或设置传感器AD值
        /// </summary>
        public float SensorAD { get; set; }
        #endregion
    }
}
