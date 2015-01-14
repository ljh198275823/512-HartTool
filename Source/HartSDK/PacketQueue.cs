using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HartSDK
{
    public class PacketQueue
    {
        #region 构造函数
        public PacketQueue() { }
        #endregion

        #region 私有变量
        private object _DataLocker = new object();
        private List<byte> _Data = new List<byte>();
        #endregion

        #region 公共方法
        /// <summary>
        ///在队列未尾追加数据
        /// </summary>
        /// <param name="data"></param>
        public void AppendData(IEnumerable<byte> data)
        {
            if (data != null)
            {
                lock (_DataLocker)
                {
                    _Data.AddRange(data);
                }
            }
        }

        public void Clear()
        {
            lock (_DataLocker)
            {
                _Data.Clear();
            }
        }
        /// <summary>
        /// 从数据中取出最早的一个回复帧,如果数据里面没有返回空
        /// </summary>
        /// <returns></returns>
        public ResponsePacket Dequeue()
        {
            lock (_DataLocker)
            {
                try
                {
                    while (_Data.Count > 0 && _Data[0] != 0xFF)
                    {
                        _Data.RemoveAt(0);
                    }
                    if (_Data.Count < 7) return null;
                    for (int i = 0; i < _Data.Count; i++)
                    {
                        if (_Data[i] == 0xFF && _Data[i + 1] == 0xFF && _Data[i + 2] != 0xFF) //至少两个0xFF 作为前导符
                        {
                            int dlp = i + 2 + ((_Data[i + 2] & 0x80) == 0x80 ? 5 : 1) + 1 + 1; //包中表示数据长度所在的位置
                            if (dlp < _Data.Count) //定位到数据长度字节
                            {
                                dlp += _Data[dlp] + 1;
                                if (dlp < _Data.Count) //缓存中已经包含一个包了
                                {
                                    byte[] temp = new byte[dlp - i + 1];
                                    _Data.CopyTo(i, temp, 0, temp.Length);
                                    _Data.RemoveRange(0, dlp + 1);
                                    return new ResponsePacket(temp);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return null;
        }
        #endregion
    }
}
