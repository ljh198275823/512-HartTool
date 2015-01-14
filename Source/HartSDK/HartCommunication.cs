using System;
using System.Windows .Forms ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading ;
using System.IO.Ports;
using LJH.GeneralLibrary;
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

        private PacketQueue _Buffer = new PacketQueue();

        private object _CommandLocker = new object();
        private AutoResetEvent _DeviceResponsed = new AutoResetEvent(false);
        private ResponsePacket _ResponsePacket = null;
        private RequestPacket _RequestPakcet = null;
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

        /// <summary>
        /// 将输出缓冲区中的数据发送出去
        /// </summary>
        private void SendData(byte[] outPut)
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

        private void ReadDataTask()
        {
            try
            {
                while (true)
                {
                    if (_Port.BytesToRead > 0)
                    {
                        byte[] data = new byte[_Port.BytesToRead];
                        _Port.Read(data, 0, data.Length);
                        _Buffer.AppendData(data);
                    }
                    ResponsePacket p = _Buffer.Dequeue();
                    while (p != null)
                    {
                        if (p.PacketType == 0x01) //成组包,从设备主动上传的包
                        {
                            OnPacketArrived(p);
                        }
                        else if (p.PacketType == 0x06) //从主包,从设备回复主设备
                        {
                            if (_RequestPakcet != null && _RequestPakcet.Command == p.Command)
                            {
                                _ResponsePacket = p;
                                _DeviceResponsed.Set(); //通知设备有回复
                            }
                        }
                        p = _Buffer.Dequeue();
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
        /// 请求数据
        /// </summary>
        /// <param name="packet"></param>
        /// <returns></returns>
        public ResponsePacket Request(RequestPacket packet, int timeout = 2000)
        {
            ResponsePacket ret = null;
            lock (_CommandLocker)
            {
                _DeviceResponsed.Reset();
                _RequestPakcet = packet;
                _ResponsePacket = null;
                byte[] cmd = _RequestPakcet.ToBytes();
                if (cmd != null && cmd.Length > 0 && IsOpened)
                {
                    SendData(cmd);
                    if (_DeviceResponsed.WaitOne(timeout))
                    {
                        ret = _ResponsePacket;
                    }
                }
            }
            _RequestPakcet = null;
            return ret;
        }
        #endregion

        #region 设备参数获取和设置相关方法
        /// <summary>
        /// 读取设备唯一标识
        /// </summary>
        public UniqueIdentifier ReadUniqueID(int shortAddress)
        {
            UniqueIdentifier ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 0, Address = shortAddress, Command = 0x00 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 12)
            {
                ret = new UniqueIdentifier();
                ret.ManufactureID = response.DataContent[1];
                ret.ManufactureDeviceType = response.DataContent[2];
                ret.DeviceID = LJH.GeneralLibrary.SEBinaryConverter.BytesToInt(new byte[] { response.DataContent[11], response.DataContent[10], response.DataContent[9] });
            }
            return ret;
        }
        /// <summary>
        /// 读取设备的主变量
        /// </summary>
        public DeviceVariable ReadPV(long longAddress)
        {
            DeviceVariable ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 0x01 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 5)
            {
                ret = new DeviceVariable();
                ret.UnitCode = response.DataContent[0];
                ret.Value = BitConverter.ToSingle(new byte[] { response.DataContent[1], response.DataContent[2], response.DataContent[3], response.DataContent[4] }, 0);
            }
            return ret;
        }
        /// <summary>
        /// 读取设备标签信息
        /// </summary>
        public DeviceTagInfo ReadTag(long longAddress)
        {
            DeviceTagInfo ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 0x01 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 21)
            {
                byte[] d = response.DataContent;
                ret = new DeviceTagInfo();
                ret.Tag = HexStringConverter.HexToString(new byte[] { d[0], d[1], d[2], d[3], d[4], d[5] }, string.Empty);   //字节0-5
                ret.Description = HexStringConverter.HexToString(new byte[] { d[6], d[7], d[8], d[9], d[10], d[11], d[12], d[13], d[14], d[15], d[16], d[17] }, string.Empty); //字节6-17
                ret.Date = new DateTime(1990 + d[20], d[19], d[18]);
            }
            return ret;
        }
        /// <summary>
        /// 读取设备消息
        /// </summary>
        public string ReadMessage(long longAddress)
        {
            string ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 0x01 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 24)
            {
                ret = HexStringConverter.HexToString(response.DataContent, string.Empty);   //字节0-23
            }
            return ret;
        }
        #endregion
    }
}
