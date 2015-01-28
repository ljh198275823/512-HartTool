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

        #region 公共方法
        public static void FillHeaderAndTail(List<LinearizationItem> lis)
        {
            int minAD = 0;
            int maxAD = 70000;
            float k = (lis[lis.Count - 1].SensorValue - lis[0].SensorValue) / (lis[lis.Count - 1].SensorAD - lis[0].SensorAD);  //计算斜率
            LinearizationItem header = new LinearizationItem();
            header.SensorAD = minAD;
            header.SensorValue = lis[0].SensorValue - k * (lis[0].SensorAD - minAD);
            lis.Insert(0, header);

            LinearizationItem tail = new LinearizationItem();
            tail.SensorAD = maxAD;
            tail.SensorValue = lis[lis.Count - 1].SensorValue + k * (maxAD - lis[lis.Count - 1].SensorAD);
            lis.Add(tail);
            if (lis.Count % 2 == 1) lis.Add(tail); //凑成偶数,因为下发时两个两个下发
        }
        #endregion
    }
}
