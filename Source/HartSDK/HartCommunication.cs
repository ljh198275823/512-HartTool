using System;
using System.Windows .Forms ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading ;
using System.IO.Ports;
using LJH.GeneralLibrary.ExceptionHandling;

namespace HartSDK
{
    public delegate void PacketArrivedDelegate(object sender, ResponsePacket p);

    public class HartCommunication
    {
        #region 构造方法
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="portNum">串口号</param>
        /// <param name="baud">波特率</param>
        public HartCommunication(byte portNum, int baud)
        {
            _PortName = "COM" + portNum;
            InitCommPort(_PortName, baud);
        }

        public HartCommunication(string portName, int baud)
        {
            _PortName = portName;
            InitCommPort(_PortName, baud);
        }
        #endregion

        #region 成员变量
        private SerialPort _Port;
        private string _PortName;
        private Thread _ReadDataTread = null;

        private object _DataLocker = new object();
        private List<byte> _Buffer = new List<byte>();
        #endregion 成员变量

        #region 属性
        /// <summary>
        /// 获取串口当前是否打开
        /// </summary>
        public bool IsOpened
        {
            get
            {
                return _Port.IsOpen;
            }
        }

        /// <summary>
        /// 获取或设置是否进入调试模式
        /// </summary>
        public bool Debug { get; set; }
        #endregion 属性

        #region 事件
        /// <summary>
        /// 数据到达事件（串口接收到数据后触发此事件将数据提供给上层应用）
        /// </summary>
        public event PacketArrivedDelegate PacketArrived;

        protected virtual void OnPacketArrived(ResponsePacket p)
        {
            if (this.PacketArrived != null) this.PacketArrived(this, p);
        }
        #endregion 事件

        #region 私有方法
        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <param name="_portNum">端口号</param>
        /// <param name="_settings">通信参数</param>
        /// <param name="_rThreshold">触发事件阀值</param>
        private void InitCommPort(string portName, int baud)
        {
            try
            {
                _Port = new SerialPort(portName, baud);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }

        private void ReadDataTask()
        {
            try
            {
                while (true)
                {
                    if (_Port.BytesToRead > 0)
                    {
                        lock (_DataLocker)
                        {
                            byte[] data = new byte[_Port.BytesToRead];
                            _Port.Read(data, 0, data.Length);
                            _Buffer.AddRange(data);
                        }
                        ResponsePacket p = GetAPacket();
                        while (p != null)
                        {
                            if (p.PacketType == 0x01) //成组包,从设备主动上传的包
                            {
                                OnPacketArrived(p);
                            }
                            else if (p.PacketType == 0x06) //从主包,从设备回复主设备
                            {

                            }
                            p = GetAPacket();
                        }
                    }
                    Thread.Sleep(50);
                }
            }
            catch (ThreadAbortException ex)
            {
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }

        private ResponsePacket GetAPacket()
        {
            lock (_DataLocker)
            {
                if (_Buffer.Count < 7) return null;
                for (int i = 0; i < _Buffer.Count; i++)
                {
                    if (_Buffer[i] == 0xFF && _Buffer[i + 1] == 0xFF && _Buffer[i + 2] != 0xFF) //至少两个0xFF 作为前导符
                    {
                        int dlp = i + 2 + ((_Buffer[i + 1] & 0x80) == 0x80 ? 5 : 1) + 1 + 1; //包中表示数据长度所在的位置
                        if (dlp < _Buffer.Count) //定位到数据长度字节
                        {
                            dlp += _Buffer[dlp] + 1;
                            if (dlp < _Buffer.Count) //缓存中已经包含一个包了
                            {
                                byte[] temp = new byte[dlp - i + 1];
                                _Buffer.CopyTo(i, temp, 0, temp.Length);
                                _Buffer.RemoveRange(0, dlp + 1);
                                return new ResponsePacket(temp);
                                break;
                            }
                        }
                    }
                }
            }
            return null;
        }
        #endregion 私有方法

        #region 公开方法
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <returns></returns>
        public void Open()
        {
            try
            {
                if (!this._Port.IsOpen)
                {
                    _Port.Open();
                    if (_Port.IsOpen)
                    {
                        _ReadDataTread = new Thread(new ThreadStart(ReadDataTask));
                        _ReadDataTread.IsBackground = true;
                        _ReadDataTread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        public void Close()
        {
            try
            {
                _Port.Close();
                if (_ReadDataTread != null)
                {
                    _ReadDataTread.Abort();
                    _ReadDataTread = null;
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }

        /// <summary>
        /// 将输出缓冲区中的数据发送出去
        /// </summary>
        public void SendData(byte[] outPut)
        {
            try
            {
                if (this.IsOpened)
                {
                    _Port.Write(outPut, 0, outPut.Length);
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }
        #endregion 公开方法
    }
}
