using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    /// <summary>
    /// 表示设备的模拟输出信息
    /// </summary>
    [Serializable]
    public class OutputInfo
    {
        #region 构造函数
        public OutputInfo() { }
        #endregion

        #region 公共属性
        public byte AlarmSelectCode { get; set; }
        /// <summary>
        /// 获取或设置数模转换函数编号，用于将主变量转成模拟电流输出,比如线性，开方等
        /// </summary>
        public byte TransferFunctionCode { get; set; }
        /// <summary>
        /// 获取或设置主变量的计量单位码
        /// </summary>
        public UnitCode PVUnitCode { get; set; }
        /// <summary>
        /// 获取或设置高点值
        /// </summary>
        public float UpperRangeValue { get; set; }
        /// <summary>
        /// 获取或设置低点值
        /// </summary>
        public float LowerRangeValue { get; set; }
        /// <summary>
        /// 获取或设置阻尼值(秒)
        /// </summary>
        public float DampingValue { get; set; }
        /// <summary>
        /// 获取或设置写保护码
        /// </summary>
        public byte WriteProtectCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public byte PrivateLabelDistributorCode { get; set; }
        #endregion
    }
}
