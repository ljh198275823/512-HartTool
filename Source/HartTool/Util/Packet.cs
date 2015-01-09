using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.HartTool.Util
{
    public class Packet
    {
        #region 构造函数
        public Packet(byte[] data)
        {
            _Data = data;
        }
        #endregion

        private byte[] _Data = null;

        #region 公共属性
        public int LongOrShort
        {
            get
            {
                return 0;
            }
        }

        public int PacketType
        {
            get
            {
                return 0;
            }
        }

        public long Address
        {
            get
            {
                return 0;
            }
        }

        public int HostMode
        {
            get
            {
                return 0;
            }
        }

        public int Command
        {
            get
            {
                return 0;
            }
        }

        public byte[] Data
        {
            get
            {
                return null;
            }
        }

        public int CommunicationState
        {
            get
            {
                return 0;
            }
        }

        public int DeviceMode
        {
            get
            {
                return 0;
            }
        }

        public int DeviceState
        {
            get
            {
                return 0;
            }
        }
        #endregion
    }
}
