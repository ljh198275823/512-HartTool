﻿using System;
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

    /// <summary>
    /// 表示HART 通讯串口
    /// </summary>
    public class HartComport
    {
        #region 构造方法
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="portNum">串口号</param>
        /// <param name="baud">波特率</param>
        public HartComport(byte portNum, int baud)
        {
            _PortName = "COM" + portNum;
            InitCommPort(_PortName, baud);
        }

        public HartComport(string portName, int baud)
        {
            _PortName = portName;
            InitCommPort(_PortName, baud);
        }
        #endregion

        #region 成员变量
        private SerialPort _Port;
        private object _PortLocker = new object();
        private string _PortName;
        private Thread _ReadDataTread = null;

        private PacketQueue _Buffer = new PacketQueue();

        private object _CommandLocker = new object();
        private AutoResetEvent _DeviceResponsed = new AutoResetEvent(false);
        private ResponsePacket _ResponsePacket = null;
        private RequestPacket _RequestPakcet = null;

        private string _LastError;
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
        private void InitCommPort(string portName, int baud)
        {
            try
            {
                _Port = new SerialPort(portName, baud, Parity.Odd);
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }

        private void SendData(byte[] outPut)
        {
            try
            {
                lock (_PortLocker)
                {
                    _Port.RtsEnable = true;
                    if (this.IsOpened)
                    {
                        if (Debug) LJH.GeneralLibrary.LOG.FileLog.Log("串口通讯", "发送数据:" + HexStringConverter.HexToString(outPut, " "));
                        _Port.Write(outPut, 0, outPut.Length);
                        //Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
        }

        private byte[] ReadData()
        {
            try
            {
                lock (_PortLocker)
                {
                    _Port.RtsEnable = false;
                    _Port.DtrEnable = true;
                    if (_Port.BytesToRead > 0)
                    {
                        byte[] data = new byte[_Port.BytesToRead];
                        _Port.Read(data, 0, data.Length);
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionPolicy.HandleException(ex);
            }
            return null;
        }

        private void ReadDataTask()
        {
            try
            {
                while (true)
                {
                    byte[] data = ReadData(); //从串口中读取数据
                    if (data != null && data.Length > 0)
                    {
                        _Buffer.AppendData(data);
                        if (Debug) LJH.GeneralLibrary.LOG.FileLog.Log("串口通讯", "收到数据:" + HexStringConverter.HexToString(data, " "));
                        ResponsePacket p = _Buffer.Dequeue();
                        while (p != null)
                        {
                            if (p.PacketType == 0x01) //成组包,从设备主动上传的包
                            {
                                OnPacketArrived(p);
                            }
                            else if (p.PacketType == 0x06) //从主包,从设备回复主设备
                            {
                                if (_RequestPakcet != null && _RequestPakcet.Command == p.Command && _RequestPakcet.Address == p.Address)
                                {
                                    _ResponsePacket = p;
                                    _DeviceResponsed.Set(); //通知设备有回复
                                }
                            }
                            p = _Buffer.Dequeue();
                        }
                        Thread.Sleep(100);
                    }
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
                byte[] cmd = packet.ToBytes();
                if (cmd != null && cmd.Length > 0)
                {
                    _DeviceResponsed.Reset();
                    _RequestPakcet = packet;
                    _ResponsePacket = null;
                    _Buffer.Clear();
                    SendData(cmd);
                    if (_DeviceResponsed.WaitOne(timeout))
                    {
                        if (_ResponsePacket.ResponseOk)
                        {
                            ret = _ResponsePacket;
                            _LastError = string.Empty;
                        }
                        else
                        {
                            _LastError = string.Format("通讯状态:{0} 设备状态:{1}", _ResponsePacket.CommunicationError_Str(), _ResponsePacket.DeviceStatus_Str());
                        }
                    }
                    else
                    {
                        _LastError = "设备没有回复";
                    }
                }
            }
            return ret;
        }
        /// <summary>
        /// 获取最后一次操作的错误描述
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            return _LastError;
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
        /// 读取电流和量程百分比
        /// </summary>
        public CurrentInfo ReadCurrent(long longAddress)
        {
            CurrentInfo ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 0x02 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 8)
            {
                byte[] d = response.DataContent;
                ret = new CurrentInfo();
                ret.Current = BitConverter.ToSingle(new byte[] { d[0], d[1], d[2], d[3] }, 0);
                ret.PercentOfRange = BitConverter.ToSingle(new byte[] { d[4], d[5], d[6], d[7] }, 0);
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
