using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Runtime.InteropServices;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.ExceptionHandling;

namespace HartSDK
{
    [ComVisible(true)]
    [Guid("AF24861C-1946-4220-A433-DD4997D30523")]
    [ComSourceInterfaces(typeof(IHartDevice))]
    [ClassInterface(ClassInterfaceType.None)]
    public class HartDevice : HartSDK.IHartDevice
    {
        #region 构造函数
        public HartDevice()
        {

        }

        public HartDevice(byte comport, int baud)
        {
            Comport = comport;
            Baud = baud;
        }
        #endregion

        #region 私有变量
        private HartComport _HartComport = null;
        private UniqueIdentifier _ID = null;
        private DeviceVariable _PV = null;
        private CurrentInfo _PVCurrent = null;
        private DeviceTagInfo _Tag = null;
        private string _Message = null;
        private SensorInfo _PVSensor = null;
        private OutputInfo _PVOutput = null;
        private float? _LowerCurrentTrim = null;
        private float? _PVAD = null;
        private SensorMode? _SensorMode = null;
        private SensorCode? _SensorCode = null;
        private TemperatureCompensation[] _TCS = new TemperatureCompensation[3];
        private LinearizationItem[] _LItems = new LinearizationItem[11];
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置设备的通讯串口
        /// </summary>
        public byte Comport { get; set; }
        /// <summary>
        ///获取或设置波特率
        /// </summary>
        public int Baud { get; set; }
        /// <summary>
        /// 获取或设置设备的短帧地址
        /// </summary>
        public byte PollingAddress { get; set; }
        /// <summary>
        /// 获取或设置是否连接当前设备
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return _ID != null;
            }
        }
        /// <summary>
        /// 获取或设置是否在调试模式
        /// </summary>
        public bool Debug { get; set; }
        #endregion

        #region 公共方法
        /// <summary>
        /// 连接设备
        /// </summary>
        public void Connect()
        {
            if (_HartComport == null && Comport > 0 && Baud > 0)
            {
                _HartComport = new HartComport(Comport, Baud);
                _HartComport.Debug = Debug;
            }
            if (_HartComport != null && !_HartComport.IsOpened) _HartComport.Open();
            if (_HartComport != null && _HartComport.IsOpened)
            {
                _ID = _HartComport.ReadUniqueID(PollingAddress);
            }
        }
        /// <summary>
        /// 关闭与设备的连接
        /// </summary>
        public void Close()
        {
            _ID = null;
            if (_HartComport != null && _HartComport.IsOpened) _HartComport.Close();
        }
        /// <summary>
        /// 获取最后一次操作的错误描述
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            return _HartComport.GetLastError();
        }
        #endregion

        #region 读取参数的相关方法
        /// <summary>
        /// 读取设备唯一标识
        /// </summary>
        public UniqueIdentifier ReadUniqueID(bool optical = false)
        {
            if (!optical) _ID = _HartComport.ReadUniqueID(PollingAddress);
            return _ID;
        }
        /// <summary>
        /// 读取设备的主变量
        /// </summary>
        public DeviceVariable ReadPV(bool optical = false)
        {
            if (!optical || (_PV == null && _ID != null)) _PV = _HartComport.ReadPV(_ID.LongAddress);
            return _PV;
        }
        /// <summary>
        /// 读取电流和量程百分比
        /// </summary>
        public CurrentInfo ReadCurrent(bool optical = false)
        {
            if (!optical || (_PVCurrent == null && _ID != null)) _PVCurrent = _HartComport.ReadCurrent(_ID.LongAddress);
            return _PVCurrent;
        }
        /// <summary>
        /// 读取设备标签信息
        /// </summary>
        public DeviceTagInfo ReadTag(bool optical = false)
        {
            if (!optical || (_Tag == null && _ID != null)) _Tag = _HartComport.ReadTag(_ID.LongAddress);
            return _Tag;
        }
        /// <summary>
        /// 读取设备消息
        /// </summary>
        public string ReadMessage(bool optical = false)
        {
            if (!optical || (string.IsNullOrEmpty(_Message) && _ID != null)) _Message = _HartComport.ReadMessage(_ID.LongAddress);
            return _Message;
        }
        /// <summary>
        /// 读取主变量传感器信息
        /// </summary>
        public SensorInfo ReadPVSensor(bool optical = false)
        {
            if (!optical || (_PVSensor == null && _ID != null)) _PVSensor = _HartComport.ReadPVSensor(_ID.LongAddress);
            return _PVSensor;
        }
        /// <summary>
        /// 读取模拟输出信息
        /// </summary>
        public OutputInfo ReadOutput(bool optical = false)
        {
            if (!optical || (_PVOutput == null && _ID != null)) _PVOutput = _HartComport.ReadOutput(_ID.LongAddress);
            return _PVOutput;
        }
        /// <summary>
        /// 获取信号切除量,百分比 0表示小信号切除量，1表示大20mA信号切除量
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="upperOrLower"></param>
        /// <returns></returns>
        public float ReadCurrentTrim(byte upperOrLower, bool optical = false)
        {
            if (!optical || (_ID != null && _LowerCurrentTrim == null)) _LowerCurrentTrim = _HartComport.ReadCurrentTrim(_ID.LongAddress, upperOrLower);
            return _LowerCurrentTrim != null ? _LowerCurrentTrim.Value : 0;
        }
        /// <summary>
        /// 获取设备的温度补偿参数 para为0表示低温补偿，1表示常温补偿 2表示高温补偿
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public TemperatureCompensation ReadTC(byte para, bool optical = false)
        {
            if (para >= 0 && para < _TCS.Length)
            {
                if (!optical || (_ID != null && _TCS[para] == null)) _TCS[para] = _HartComport.ReadTC(_ID.LongAddress, para);
                return _TCS[para];
            }
            return null;
        }
        /// <summary>
        /// 读取线性化参数
        /// </summary>
        public LinearizationItem ReadLinearizationItem(byte para, bool optical = false)
        {
            if (para >= 0 && para < _LItems.Length)
            {
                if (!optical || (_ID != null && _LItems[para] == null)) _LItems[para] = _HartComport.ReadLinearizationItem(_ID.LongAddress, para);
                return _LItems[para];
            }
            return null;
        }
        /// <summary>
        /// 读取主变量的AD值,小于0表示获取失败
        /// </summary>
        public float ReadPVAD(bool optical = false)
        {
            if (!optical || (_ID != null && _PVAD == null)) _PVAD = _HartComport.ReadPVAD(_ID.LongAddress);
            return _PVAD != null ? _PVAD.Value : -1;
        }

        public SensorMode? ReadSensorMode(bool optical = false)
        {
            if (!optical || (_ID != null && _SensorMode == null))
            {
                byte[] data = ReadCommand(0x80, null);
                if (data != null && data.Length == 22)
                {
                    _SensorMode = (SensorMode)data[11];
                    _SensorCode = (SensorCode)data[12];
                }
            }
            return _SensorMode;
        }

        public SensorCode? ReadSensorCode(bool optical = false)
        {
            if (!optical || (_ID != null && _SensorCode == null))
            {
                byte[] data = ReadCommand(0x80, null);
                if (data != null && data.Length == 22)
                {
                    _SensorMode = (SensorMode)data[11];
                    _SensorCode = (SensorCode)data[12];
                }
            }
            return _SensorCode;
        }
        /// <summary>
        /// 读取某个命令的返回值
        /// </summary>
        public byte[] ReadCommand(byte cmd, byte[] data)
        {
            if (_ID != null) return _HartComport.ReadCommand(_ID.LongAddress, cmd, data);
            return null;
        }
        #endregion

        #region 设置参数的相关方法
        /// <summary>
        /// 写设备的短帧地址
        /// </summary>
        public bool WritePollingAddress(byte pollingAddress)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WritePollingAddress(_ID.LongAddress, pollingAddress);
            if (ret) PollingAddress = pollingAddress;
            return ret;
        }
        /// <summary>
        /// 写消息
        /// </summary>
        public bool WriteMessage(string msg)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WriteMessage(_ID.LongAddress, msg);
            if (ret) _Message = null;
            return ret;
        }
        /// <summary>
        /// 写标签信息
        /// </summary>
        public bool WriteTag(DeviceTagInfo tag)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WriteTag(_ID.LongAddress, tag);
            if (ret) _Tag = null;
            return ret;
        }
        /// <summary>
        /// 写设备的最终装配号
        /// </summary>
        public bool WriteFinalAssemblyNumber(int assemblyNumber)
        {
            if (_ID == null) return false;
            return _HartComport.WriteFinalAssemblyNumber(_ID.LongAddress, assemblyNumber);
        }
        /// <summary>
        /// 写主变量的阻尼系数
        /// </summary>
        public bool WriteDampValue(float dampValue)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WriteDampValue(_ID.LongAddress, dampValue);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 写主变量的量程范围
        /// </summary>
        public bool WritePVRange(UnitCode unitCode, float upperRange, float lowerRange)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WritePVRange(_ID.LongAddress, unitCode, upperRange, lowerRange);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 将当前的主变量值设置成主变量的上限
        /// </summary>
        public bool SetUpperRangeValue(UnitCode uc, float uv)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.SetUpperRangeValue(_ID.LongAddress, uc, uv);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 将当前的主变量值设置成主变量的下限
        /// </summary>
        public bool SetLowerRangeValue(UnitCode uc, float lv)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.SetLowerRangeValue(_ID.LongAddress, uc, lv);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 设置固定电流输出,当传入的参数为0时表示取消固定电流输出模式
        /// </summary>
        public bool SetFixedCurrent(float current)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.SetFixedCurrent(_ID.LongAddress, current);
            if (ret) _PVCurrent = null;
            return ret;
        }
        /// <summary>
        /// 自检
        /// </summary>
        public bool SelftTest()
        {
            if (_ID == null) return false;
            return _HartComport.SelftTest(_ID.LongAddress);
        }
        /// <summary>
        /// 复位设备
        /// </summary>
        public bool Reset()
        {
            if (_ID == null) return false;
            return _HartComport.Reset(_ID.LongAddress);
        }
        /// <summary>
        /// 设置主变量零点
        /// </summary>
        public bool SetPVZero()
        {
            if (_ID == null) return false;
            return _HartComport.SetPVZero(_ID.LongAddress);
        }
        /// <summary>
        /// 设置主变量单位代码
        /// </summary>
        public bool WritePVUnit(UnitCode unitCode)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WritePVUnit(_ID.LongAddress, unitCode);
            if (ret)
            {
                _PV = null;
                _PVOutput = null;
                _PVSensor = null;
            }
            return ret;
        }
        /// <summary>
        /// 调校下限输出电流
        /// </summary>
        public bool TrimDACZero(float current)
        {
            if (_ID == null) return false;
            return _HartComport.TrimDACZero(_ID.LongAddress, current);
        }
        /// <summary>
        /// 调校上限电流
        /// </summary>
        public bool TrimDACGain(float current)
        {
            if (_ID == null) return false;
            return _HartComport.TrimDACGain(_ID.LongAddress, current);
        }
        /// <summary>
        /// 设置主变量DA输出转换函数
        /// </summary>
        public bool WriteTransferFunction(TransferFunctionCode code)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WriteTransferFunction(_ID.LongAddress, code);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 写主变量传感器序列号
        /// </summary>
        public bool WritePVSensorSN(int sn)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WritePVSensorSN(_ID.LongAddress, sn);
            if (ret) _PVSensor = null;
            return ret;
        }
        /// <summary>
        /// 写返回帧前导字符(0xFF)的个数
        /// </summary>
        public bool WriteResponsePreamblesCount(byte count)
        {
            if (_ID == null) return false;
            return _HartComport.WriteResponsePreamblesCount(_ID.LongAddress, count);
        }
        /// <summary>
        /// 设置信号量切除量
        /// </summary>
        public bool WriteCurrentTrim(byte uOrl, float percent)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WriteCurrentTrim(_ID.LongAddress, uOrl, percent);
            if (ret) _LowerCurrentTrim = null;
            return ret;
        }
        /// <summary>
        /// 设置主传感器工作模式
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="mode"></param>
        /// <param name="sensorCode"></param>
        /// <returns></returns>
        public bool WritePVSensorMode(SensorMode mode, SensorCode sensorCode)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WritePVSensorMode(_ID.LongAddress, mode, sensorCode);
            if (ret)
            {
                _SensorMode = null;
                _SensorCode = null;
                _PVOutput = null;
                _PVSensor = null;
            }
            return ret;
        }
        /// <summary>
        /// 写温度补偿参数
        /// </summary>
        public bool WriteTC(byte para, TemperatureCompensation tc)
        {
            if (_ID == null) return false;
            bool ret = _HartComport.WriteTC(_ID.LongAddress, para, tc);
            if (ret && para == 0) _TCS[0] = null;
            if (ret && para == 1) _TCS[1] = null;
            if (ret && para == 2) _TCS[2] = null;
            return ret;
        }
        /// <summary>
        /// 写线性化参数
        /// </summary>
        public bool WriteLinearizationItems(LinearizationItem[] items, byte start)
        {
            if (_ID == null) return false;
            if (items == null || items.Length == 0) return false;
            bool ret = _HartComport.WriteLinearizationItems(_ID.LongAddress, items, start);
            if (ret) _LItems = new LinearizationItem[11];
            return ret;
        }
        /// <summary>
        /// 备份参数
        /// </summary>
        /// <returns></returns>
        public bool BackUp()
        {
            if (_ID == null) return false;
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = _ID.LongAddress,
                Command = 0xC7,
                DataContent = new byte[] { 0x11, 0x53, 0x1C, 0x89 },
            };
            ResponsePacket response = _HartComport.Request(request);
            return response != null;
        }
        /// <summary>
        /// 数据初始化
        /// </summary>
        /// <returns></returns>
        public bool DataInit()
        {
            if (_ID == null) return false;
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = _ID.LongAddress,
                Command = 0xC6,
                DataContent = new byte[] { 0x4C, 0x55, 0x20, 0x10, 0x15, 0x48, 0x20, 0x10, 0x25 },
            };
            ResponsePacket response = _HartComport.Request(request);
            return response != null;
        }
        /// <summary>
        /// 从备份的数据中恢复设备的参数
        /// </summary>
        /// <returns></returns>
        public bool Restore()
        {
            if (_ID == null) return false;
            RequestPacket request = new RequestPacket()
            {
                LongOrShort = 1,
                Address = _ID.LongAddress,
                Command = 0xC7,
                DataContent = new byte[] { 0x33, 0x53, 0x1C, 0x89 },
            };
            ResponsePacket response = _HartComport.Request(request);
            return response != null;
        }
        #endregion
    }
}
