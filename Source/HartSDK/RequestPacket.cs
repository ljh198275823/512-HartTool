using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HartSDK
{
    /// <summary>
    /// 表示一个请求帧
    /// </summary>
    [Serializable]
    public class RequestPacket
    {
        #region 构造函数
        public RequestPacket()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置帧的类型,1表示长帧,0表示短帧,其它值无意义,一般来说只有命令0支持短帧
        /// </summary>
        public int LongOrShort { get; set; }
        /// <summary>
        /// 获取或设置设备地址,长帧用38位表示，短帧用4位表示
        /// </summary>
        public long Address { get; set; }
        /// <summary>
        /// 获取或设置帧的命令
        /// </summary>
        public int Command { get; set; }
        /// <summary>
        /// 获取或设置帧携带的数据内容
        /// </summary>
        public byte[] DataContent { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 返回帧的字节表示
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            List<byte> temp = new List<byte>();
            temp.Add((byte)((LongOrShort == 1 ? 0x80 : 0x00) | 0x02)); //请求帧是主-从帧
            if (LongOrShort == 1)
            {
                byte[] ba = LJH.GeneralLibrary.SEBinaryConverter.LongToBytes(Address);
                temp.AddRange(new byte[] { (byte)(0x80 | ba[4]), ba[3], ba[2], ba[1], ba[0] });
            }
            else
            {
                temp.Add((byte)(0x80 | (Address & 0x0F)));
            }
            temp.Add((byte)Command);
            temp.Add((byte)(DataContent != null && DataContent.Length > 0 ? DataContent.Length : 0)); //数据长度
            if (DataContent != null && DataContent.Length > 0) temp.AddRange(DataContent);
            temp.Add(LJH.GeneralLibrary.CRCHelper.CalCRC(temp));
            temp.InsertRange(0, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }); //5个字节的前导符
            return temp.ToArray();
        }

        public override string ToString()
        {
            byte[] data = ToBytes();
            if (data != null && data.Length > 0) return LJH.GeneralLibrary.HexStringConverter.HexToString(data, " ");
            return base.ToString();
        }
        #endregion
    }
}
