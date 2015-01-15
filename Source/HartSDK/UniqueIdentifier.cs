using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    /// <summary>
    /// 表示设备的唯一标识符,由制造商ID，设备类型和设备的编号构成设备的唯一标识
    /// </summary>
    [Serializable]
    public class UniqueIdentifier
    {
        #region 构造函数
        public UniqueIdentifier() { }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置设备制造商ID
        /// </summary>
        public byte ManufactureID { get; set; }
        /// <summary>
        /// 获取或设置设备的制造商类型
        /// </summary>
        public byte ManufactureDeviceType { get; set; }
        /// <summary>
        /// 设备的编号
        /// </summary>
        public int DeviceID { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 获取设备的长地址
        /// </summary>
        public long LongAddress
        {
            get
            {
                long ret = ManufactureID & 0x3F;
                ret = ret << 32;
                ret += (long)ManufactureDeviceType << 24;
                ret += DeviceID;
                return ret;
            }
        }
        #endregion
    }
}
