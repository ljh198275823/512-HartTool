using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    /// <summary>
    /// 表示一个收到的HART帧, 结构 前导字节(2字节) + 界定(1字节) + 设备地址(1或5字节) + 命令(1字节) + 数据长度(1字节) + 数据(0-n字节) + CRC(1字节)
    /// </summary>
    public class ResponsePacket
    {
        #region 构造函数
        public ResponsePacket(byte[] data)
        {
            _Data = data;
        }
        #endregion

        #region 私有变量
        private byte[] _Data = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取帧的类型,1表示长帧,0表示短帧,其它值无意义,一般来说只有命令0支持短帧
        /// </summary>
        public int LongOrShort
        {
            get
            {
                if (_Data.Length > 3) return (_Data[2] & 0x80) == 0x80 ? 1 : 0; //界定字节的最高位
                return -1;
            }
        }
        /// <summary>
        /// 获取帧的类别 1表示成组模式帧，2表示主-从帧 6表示从-主帧 ,其它值无意义
        /// </summary>
        public int PacketType
        {
            get
            {
                if (_Data.Length > 3) return (_Data[2] & 0x07); //界定字节的低三位
                return -1;
            }
        }

        /// <summary>
        /// 获取帧的设备地址,长帧用38位表示，短帧用4位表示
        /// </summary>
        public long Address
        {
            get
            {
                if (LongOrShort == 1 && _Data.Length > 8)
                {
                    byte[] temp = new byte[5] { _Data[7], _Data[6], _Data[5], _Data[4], (byte)(_Data[3] & 0x3F) };
                    return LJH.GeneralLibrary.SEBinaryConverter.BytesToLong(temp);
                }
                if (LongOrShort == 0 && _Data.Length > 4)
                {
                    return _Data[3] & 0x0F;
                }
                return -1;
            }
        }
        /// <summary>
        /// 获取设备的工作模式，1表示工作在成组模式，0表示工作在非成组模式
        /// </summary>
        public int DeviceMode
        {
            get
            {
                if (_Data.Length > 4) return (_Data[3] & 0x40) == 0x40 ? 1 : 0; //界定字节的低三位
                return -1;
            }
        }
        /// <summary>
        /// 获取帧的命令
        /// </summary>
        public int Command
        {
            get
            {
                if (LongOrShort == 1 && _Data.Length > 9)
                {
                    return _Data[8];
                }
                if (LongOrShort == 0 && _Data.Length > 5)
                {
                    return _Data[4];
                }
                return -1;
            }
        }
        /// <summary>
        /// 获取帧携带的数据内容
        /// </summary>
        public byte[] DataContent
        {
            get
            {
                int dlen = 0;
                int dp = 0;
                if (LongOrShort == 1 && _Data.Length > 10)
                {
                    dlen = _Data[9];
                    dp = 10;
                }
                if (LongOrShort == 0 && _Data.Length > 6)
                {
                    dlen = _Data[5];
                    dp = 6;
                }
                if (dlen > 0)
                {
                    byte[] ret = new byte[dlen];
                    Array.Copy(_Data, dp, ret, 0, ret.Length);
                    return ret;
                }
                return null;
            }
        }
        /// <summary>
        /// 获取设备的通讯状态
        /// </summary>
        public int CommunicationState
        {
            get
            {
                if (PacketType == 6 && DataContent != null && DataContent.Length >= 1)
                {
                    return DataContent[0];
                }
                return -1;
            }
        }
        /// <summary>
        /// 获取设备的工作状态
        /// </summary>
        public int DeviceState
        {
            get
            {
                if (PacketType == 6 && DataContent != null && DataContent.Length >= 2)
                {
                    return DataContent[1];
                }
                return -1;
            }
        }
        /// <summary>
        /// 获取帧是否有效
        /// </summary>
        public bool IsValid
        {
            get
            {
                return true;
            }
        }
        #endregion

        #region 公共方法
        public override string ToString()
        {
            return LJH.GeneralLibrary.HexStringConverter.HexToString(_Data, " ");
        }
        #endregion
    }
}
