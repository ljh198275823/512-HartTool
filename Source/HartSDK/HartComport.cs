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
                _LastError = ex.Message;
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
                        int count = (int)(Math.Ceiling((double)outPut.Length / 15)) + 1; //1200bps的波特率，每100ms可以发送的最大的字符15个字符，在此基础上再加100ms等待时长
                        Thread.Sleep(count * 100);
                    }
                }
            }
            catch (Exception ex)
            {
                _LastError = ex.Message;
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
                _LastError = ex.Message;
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
            catch (ThreadAbortException)
            {
            }
            catch (Exception ex)
            {
                _LastError = ex.Message;
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
                _LastError = ex.Message;
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
                _LastError = ex.Message;
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

        #region 读取参数的相关方法
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
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 1 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 5)
            {
                ret = new DeviceVariable();
                ret.UnitCode = (UnitCode)response.DataContent[0];
                ret.Value = BitConverter.ToSingle(new byte[] { response.DataContent[4], response.DataContent[3], response.DataContent[2], response.DataContent[1] }, 0);
            }
            return ret;
        }
        /// <summary>
        /// 读取电流和量程百分比
        /// </summary>
        public CurrentInfo ReadCurrent(long longAddress)
        {
            CurrentInfo ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 2 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 8)
            {
                byte[] d = response.DataContent;
                ret = new CurrentInfo();
                ret.Current = BitConverter.ToSingle(new byte[] { d[3], d[2], d[1], d[0] }, 0);
                ret.PercentOfRange = BitConverter.ToSingle(new byte[] { d[7], d[6], d[5], d[4] }, 0);
            }
            return ret;
        }
        /// <summary>
        /// 读取设备标签信息
        /// </summary>
        public DeviceTagInfo ReadTag(long longAddress)
        {
            DeviceTagInfo ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 13 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 21)
            {
                byte[] d = response.DataContent;
                ret = new DeviceTagInfo();
                ret.Tag = PackAsciiHelper.GetString(new byte[] { d[0], d[1], d[2], d[3], d[4], d[5] });   //字节0-5
                ret.Description = PackAsciiHelper.GetString(new byte[] { d[6], d[7], d[8], d[9], d[10], d[11], d[12], d[13], d[14], d[15], d[16], d[17] }); //字节6-17
                ret.Year = 1990 + d[20];
                ret.Month = d[19];
                ret.Day = d[18];
            }
            return ret;
        }
        /// <summary>
        /// 读取设备消息
        /// </summary>
        public string ReadMessage(long longAddress)
        {
            string ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 12 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 24)
            {
                ret = PackAsciiHelper.GetString(response.DataContent);   //字节0-23
            }
            return ret;
        }
        /// <summary>
        /// 读取主变量传感器信息
        /// </summary>
        public SensorInfo ReadPVSensor(long longAddress)
        {
            SensorInfo ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 14 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 16)
            {
                byte[] d = response.DataContent;
                ret = new SensorInfo();
                ret.SensorSN = SEBinaryConverter.BytesToInt(new byte[] { d[2], d[1], d[0] });
                ret.UnitCode = (UnitCode)d[3];
                ret.UpperLimit = BitConverter.ToSingle(new byte[] { d[7], d[6], d[5], d[4] }, 0);
                ret.LowerLimit = BitConverter.ToSingle(new byte[] { d[11], d[10], d[9], d[8] }, 0);
                ret.MinimumSpan = BitConverter.ToSingle(new byte[] { d[15], d[14], d[13], d[12] }, 0);
            }
            return ret;
        }
        /// <summary>
        /// 读取模拟输出信息
        /// </summary>
        public OutputInfo ReadOutput(long longAddress)
        {
            OutputInfo ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 15 };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 17)
            {
                byte[] d = response.DataContent;
                ret = new OutputInfo();
                ret.AlarmSelectCode = d[0];
                ret.TransferFunctionCode = d[1];
                ret.PVUnitCode = (UnitCode)d[2];
                ret.UpperRangeValue = BitConverter.ToSingle(new byte[] { d[6], d[5], d[4], d[3] }, 0);
                ret.LowerRangeValue = BitConverter.ToSingle(new byte[] { d[10], d[9], d[8], d[7] }, 0);
                ret.DampingValue = BitConverter.ToSingle(new byte[] { d[14], d[13], d[12], d[11] }, 0);
                ret.WriteProtectCode = d[15];
                ret.PrivateLabelDistributorCode = d[16];
            }
            return ret;
        }
        /// <summary>
        /// 获取信号切除量,百分比 0表示小信号切除量，1表示大20mA信号切除量
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="upperOrLower"></param>
        /// <returns></returns>
        public float ReadCurrentTrim(long longAddress, byte upperOrLower)
        {
            float ret = 0;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 0xBF };
            request.DataContent = new byte[] { upperOrLower };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 4)
            {
                byte[] d = response.DataContent;
                ret = BitConverter.ToSingle(new byte[] { d[3], d[2], d[1], d[0] }, 0);
            }
            return ret;
        }
        /// <summary>
        /// 获取设备的温度补偿参数 para为0表示低温补偿，1表示常温补偿 2表示高温补偿
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public TemperatureCompensation ReadTC(long longAddress, byte para)
        {
            TemperatureCompensation ret = null;
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = 0xC3, DataContent = new byte[] { 0x4C, para }, };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null && response.DataContent.Length >= 14)
            {
                byte[] d = response.DataContent;
                ret = new TemperatureCompensation();
                ret.LowerRangeAD = BitConverter.ToSingle(new byte[] { d[5], d[4], d[3], d[2] }, 0);
                ret.UpperRangeAD = BitConverter.ToSingle(new byte[] { d[9], d[8], d[7], d[6] }, 0);
                ret.TemperatureAD  = BitConverter.ToSingle(new byte[] { d[13], d[12], d[11], d[10] }, 0);
            }
            return ret;
        }
        /// <summary>
        /// 读取某个命令的返回值
        /// </summary>
        public byte[] ReadCommand(long longAddress, byte cmd, byte[] paras)
        {
            RequestPacket request = new RequestPacket() { LongOrShort = 1, Address = longAddress, Command = cmd, DataContent = paras };
            ResponsePacket response = Request(request);
            if (response != null && response.DataContent != null)
            {
                return response.DataContent;
            }
            return null;
        }
        #endregion

        #region 设置参数的相关方法
        /// <summary>
        /// 写设备的短帧地址
        /// </summary>
        public bool WritePollingAddress(long longAddress, byte pollingAddress)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 6,
                DataContent = new byte[] { pollingAddress },
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写消息
        /// </summary>
        public bool WriteMessage(long longAddress, string msg)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 17,
                DataContent = PackAsciiHelper.GetBytes(msg, 24),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写标签信息
        /// </summary>
        public bool WriteTag(long longAddress, DeviceTagInfo tag)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 18,
            };
            List<byte> d = new List<byte>();
            d.AddRange(PackAsciiHelper.GetBytes(tag.Tag, 6));
            d.AddRange(PackAsciiHelper.GetBytes(tag.Description, 12));
            d.Add((byte)tag.Day);
            d.Add((byte)tag.Month);
            d.Add((byte)(tag.Year - 1990));
            request.DataContent = d.ToArray();
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写设备的最终装配号
        /// </summary>
        public bool WriteFinalAssemblyNumber(long longAddress, int assemblyNumber)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 19,
                DataContent = SEBinaryConverter.IntToBytes(assemblyNumber, 3).Reverse().ToArray(),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写主变量的阻尼系数
        /// </summary>
        public bool WriteDampValue(long longAddress, float dampValue)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 34,
                DataContent = BitConverter.GetBytes(dampValue).Reverse().ToArray(),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写主变量的量程范围
        /// </summary>
        public bool WritePVRange(long longAddress, UnitCode unitCode, float upperRange, float lowerRange)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 35,
            };
            List<byte> d = new List<byte>();
            d.Add((byte)unitCode);
            d.AddRange(BitConverter.GetBytes(upperRange).Reverse());
            d.AddRange(BitConverter.GetBytes(lowerRange).Reverse());
            request.DataContent = d.ToArray();
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 将当前的主变量值设置成主变量的上限
        /// </summary>
        public bool SetUpperRangeValue(long longAddress)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 36,
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 将当前的主变量值设置成主变量的下限
        /// </summary>
        public bool SetLowerRangeValue(long longAddress)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 37,
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置固定电流输出,当传入的参数为0时表示取消固定电流输出模式
        /// </summary>
        public bool SetFixedCurrent(long longAddress, float current)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 40,
                DataContent = BitConverter.GetBytes(current).Reverse().ToArray(),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 自检
        /// </summary>
        public bool SelftTest(long longAddress)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 41,
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 复位设备
        /// </summary>
        public bool Reset(long longAddress)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 42,
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置主变量零点
        /// </summary>
        public bool SetPVZero(long longAddress)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 43,
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置主变量单位代码
        /// </summary>
        public bool WritePVUnit(long longAddress, UnitCode unitCode)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 44,
                DataContent = new byte[] { (byte)unitCode },
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 调校下限输出电流
        /// </summary>
        public bool TrimDACZero(long longAddress, float current)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 45,
                DataContent = BitConverter.GetBytes(current).Reverse().ToArray(),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 调校上限电流
        /// </summary>
        public bool TrimDACGain(long longAddress, float current)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 46,
                DataContent = BitConverter.GetBytes(current).Reverse().ToArray(),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置主变量DA输出转换函数
        /// </summary>
        public bool WriteTransferFunction(long longAddress, TransferFunctionCode code)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 47,
                DataContent = new byte[] { (byte)code },
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写主变量传感器序列号
        /// </summary>
        public bool WritePVSensorSN(long longAddress, int sn)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 47,
                DataContent = SEBinaryConverter.IntToBytes(sn, 3).Reverse().ToArray(),
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 写返回帧前导字符(0xFF)的个数
        /// </summary>
        public bool WriteResponsePreamblesCount(long longAddress, byte count)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 59,
                DataContent = new byte[] { count }
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置信号量切除量
        /// </summary>
        public bool WriteCurrentTrim(long longAddress, byte uOrl, float percent)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 0xBF,
            };
            List<byte> d = new List<byte>();
            d.Add(uOrl);
            d.AddRange(BitConverter.GetBytes(percent).Reverse().ToArray());
            request.DataContent = d.ToArray();
            ResponsePacket response = Request(request);
            if (response != null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置主传感器工作模式
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="mode"></param>
        /// <param name="sensorCode"></param>
        /// <returns></returns>
        public bool WritePVSensorMode(long longAddress, SensorMode mode, SensorCode sensorCode)
        {
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = longAddress,
                Command = 0x84,
                DataContent = new byte[] { (byte)mode, (byte)sensorCode },
            };
            ResponsePacket response = Request(request);
            if (response != null)
            {

                return true;
            }
            return false;
        }
        #endregion
    }
}
