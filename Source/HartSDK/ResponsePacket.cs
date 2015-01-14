using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{

    /// <summary>
    /// 表示一个返回帧
    /// </summary>
    // 结构 前导字节(2字节) + 界定(1字节) + 设备地址(1或5字节) + 命令(1字节) + 数据长度(1字节) + 数据(0-n字节) + CRC(1字节)
    // 前导符：设备回复此帧时可能在通讯上有超过两个字节的前导帧，但这里为了简便管理，统一取两个字节
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
                if (LongOrShort == 1 && _Data.Length > 12)
                {
                    dlen = _Data[9] - 2; //数据部分的前两个字节有其它用途
                    dp = 12;
                }
                if (LongOrShort == 0 && _Data.Length > 8)
                {
                    dlen = _Data[5] - 2; //数据部分的前两个字节有其它用途
                    dp = 8;
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
        public byte CommunicationState
        {
            get
            {
                if (LongOrShort == 1 && _Data.Length > 10) return _Data[10];
                if (LongOrShort == 0 && _Data.Length > 6) return _Data[6];
                return 0;
            }
        }
        /// <summary>
        /// 获取设备的工作状态
        /// </summary>
        public byte DeviceState
        {
            get
            {
                if (LongOrShort == 1 && _Data.Length > 11) return _Data[11];
                if (LongOrShort == 0 && _Data.Length > 7) return _Data[7];
                return 0;
            }
        }
        /// <summary>
        /// 获取帧是否有效
        /// </summary>
        public bool IsValid
        {
            get
            {
                byte[] temp = new byte[_Data.Length - 3]; //去掉前导两个0xFF 0xFF 和未尾的CRC
                //计算CRC
                Array.Copy(_Data, 2, temp, 0, temp.Length);
                byte crc = LJH.GeneralLibrary.CRCHelper.CalCRC(temp);
                if (crc != _Data[_Data.Length - 1]) return false;

                return true;
            }
        }
        /// <summary>
        /// 获取返回是否正常，即返回帧提示通讯和设备都正常
        /// </summary>
        public bool ResponseOk
        {
            get
            {
                return CommunicationState == 0x00 && DeviceState == 0x00;
            }
        }
        #endregion

        #region 公共方法
        public override string ToString()
        {
            return LJH.GeneralLibrary.HexStringConverter.HexToString(_Data, " ");
        }
        /// <summary>
        /// 获取通讯错误的字符描述
        /// </summary>
        /// <returns></returns>
        public string CommunicationError_Str()
        {
            byte b = CommunicationState;
            if (b == 0) return "Ok";
            if (b == 0xC0) return "Parity error";
            if (b == 0xA0) return "Overrun error";
            if (b == 0x90) return "Framing error";
            if (b == 0x88) return "Checksum error";
            if (b == 0x84) return "0 reserved";
            if (b == 0x82) return "Rx buffer overflow";
            if (b == 0x81) return "Overflow";
            if ((b & 0x80) == 0x00)
            {
                b = (byte)(b & 0x7F);
                if (b == 0x01) return "Undefined";
                if (b == 0x02) return "Invalid selection";
                if (b == 0x03) return "Passed parameter too large";
                if (b == 0x04) return "Passed parameter too small";
                if (b == 0x05) return "Too few data bytes received";
                if (b == 0x07) return "In write-protect mode";
                if (b >= 8 && b <= 15) return "Multiple meanings";
                if (b == 16) return "Access restricted";
                if (b == 28) return "Multiple meanings";
                if (b == 32) return "Device is busy";
                if (b == 64) return "Command not implemented";
            }
            return "未知错误";
        }
        /// <summary>
        /// 设备状态的文字描述
        /// </summary>
        /// <returns></returns>
        public string DeviceStatus_Str()
        {
            if (CommunicationState != 0x00) return "通讯错误，状态未知";
            string ret = string.Empty;
            byte b = DeviceState;
            if ((b & 0x80) == 0x80) ret += "Field device malfunction" + ",";
            if ((b & 0x40) == 0x40) ret += "Configuration changed" + ",";
            if ((b & 0x20) == 0x20) ret += "Cold start" + ",";
            if ((b & 0x10) == 0x10) ret += "More status available" + ",";
            if ((b & 0x08) == 0x08) ret += "Analog output current fixed" + ",";
            if ((b & 0x04) == 0x04) ret += "Analog output saturated" + ",";
            if ((b & 0x02) == 0x02) ret += "Nonprimary variable out of limits" + ",";
            if ((b & 0x01) == 0x01) ret += "Primary variable out of limits" + ",";
            if (string.IsNullOrEmpty(ret)) return "设备正常";
            return ret.Substring(0, ret.Length - 1);
        }
        #endregion
    }
}
