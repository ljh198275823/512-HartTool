using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

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
        /// 获取或设置标答值(8字符)
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// 获取或设置描述 (16字符)
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 获取或设置日期的年份
        /// </summary>
        public int  Year { get; set; }
        /// <summary>
        /// 获取或设置日期的月份
        /// </summary>
        public int Month { get; set; }
        /// <summary>
        /// 获取或设置日期的天数部分
        /// </summary>
        public int Day { get; set; }
        #endregion
    }
}
