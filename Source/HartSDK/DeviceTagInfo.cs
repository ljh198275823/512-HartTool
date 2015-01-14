using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    /// <summary>
    /// 表示设备的标签信息
    /// </summary>
    [Serializable]
    public class DeviceTagInfo
    {
        #region 构造函数
        public DeviceTagInfo() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置标答值
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 获取或设置描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 获取或设置日期
        /// </summary>
        public DateTime Date { get; set; }
        #endregion
    }
}
