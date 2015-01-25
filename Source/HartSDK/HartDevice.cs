using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.ExceptionHandling;

namespace HartSDK
{
    public class HartDevice
    {
        #region 构造函数
        public HartDevice()
        {

        }

        public HartDevice(byte comport, int baud)
        {
            HartComport = new HartSDK.HartComport(comport, baud);
        }
        #endregion

        #region 私有变量
        private UniqueIdentifier _ID = null;
        private DeviceVariable _PV = null;
        private CurrentInfo _PVCurrent = null;
        private DeviceTagInfo _Tag = null;
        private string _Message = null;
        private SensorInfo _PVSensor = null;
        private OutputInfo _PVOutput = null;
        private float? _LowerCurrentTrim = null;
        private TemperatureCompensation _LowTemp = null;
        private TemperatureCompensation _NormalTemp = null;
        private TemperatureCompensation _HightTemp = null;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置设备的通讯串口
        /// </summary>
        public HartComport HartComport { get; set; }
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
        #endregion

        #region 公共方法
        /// <summary>
        /// 连接设备
        /// </summary>
        public void Connect()
        {
            if (HartComport != null && !HartComport.IsOpened) HartComport.Open();
            if (HartComport != null && HartComport.IsOpened)
            {
                _ID = HartComport.ReadUniqueID(PollingAddress);
            }
        }
        /// <summary>
        /// 关闭与设备的连接
        /// </summary>
        public void Close()
        {
            _ID = null;
            if (HartComport != null && HartComport.IsOpened) HartComport.Close();
        }
        /// <summary>
        /// 获取最后一次操作的错误描述
        /// </summary>
        /// <returns></returns>
        public string GetLastError()
        {
            return HartComport.GetLastError();
        }
        #endregion

        #region 读取参数的相关方法
        /// <summary>
        /// 读取设备唯一标识
        /// </summary>
        public UniqueIdentifier ReadUniqueID(bool optical = true)
        {
            if (!optical) _ID = HartComport.ReadUniqueID(PollingAddress);
            return _ID;
        }
        /// <summary>
        /// 读取设备的主变量
        /// </summary>
        public DeviceVariable ReadPV(bool optical = true)
        {
            if (!optical || (_PV == null && _ID != null)) _PV = HartComport.ReadPV(_ID.LongAddress);
            return _PV;
        }
        /// <summary>
        /// 读取电流和量程百分比
        /// </summary>
        public CurrentInfo ReadCurrent(bool optical = true)
        {
            if (!optical || (_PVCurrent == null && _ID != null)) _PVCurrent = HartComport.ReadCurrent(_ID.LongAddress);
            return _PVCurrent;
        }
        /// <summary>
        /// 读取设备标签信息
        /// </summary>
        public DeviceTagInfo ReadTag(bool optical = true)
        {
            if (!optical || (_Tag == null && _ID != null)) _Tag = HartComport.ReadTag(_ID.LongAddress);
            return _Tag;
        }
        /// <summary>
        /// 读取设备消息
        /// </summary>
        public string ReadMessage(bool optical = true)
        {
            if (!optical || (string.IsNullOrEmpty(_Message) && _ID != null)) _Message = HartComport.ReadMessage(_ID.LongAddress);
            return _Message;
        }
        /// <summary>
        /// 读取主变量传感器信息
        /// </summary>
        public SensorInfo ReadPVSensor(bool optical = true)
        {
            if (!optical || (_PVSensor == null && _ID != null)) _PVSensor = HartComport.ReadPVSensor(_ID.LongAddress);
            return _PVSensor;
        }
        /// <summary>
        /// 读取模拟输出信息
        /// </summary>
        public OutputInfo ReadOutput(bool optical = true)
        {
            if (!optical || (_PVOutput == null && _ID != null)) _PVOutput = HartComport.ReadOutput(_ID.LongAddress);
            return _PVOutput;
        }
        /// <summary>
        /// 获取信号切除量,百分比 0表示小信号切除量，1表示大20mA信号切除量
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="upperOrLower"></param>
        /// <returns></returns>
        public float ReadCurrentTrim(byte upperOrLower, bool optical = true)
        {
            if (!optical || (_ID != null && _LowerCurrentTrim == null)) _LowerCurrentTrim = HartComport.ReadCurrentTrim(_ID.LongAddress, upperOrLower);
            return _LowerCurrentTrim != null ? _LowerCurrentTrim.Value : 0;
        }
        /// <summary>
        /// 获取设备的温度补偿参数 para为0表示低温补偿，1表示常温补偿 2表示高温补偿
        /// </summary>
        /// <param name="longAddress"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public TemperatureCompensation ReadTC(byte para, bool optical = true)
        {
            if (para == 0)
            {
                if (!optical || (_ID != null && _LowTemp == null)) _LowTemp = HartComport.ReadTC(_ID.LongAddress, para);
                return _LowTemp;
            }
            else if (para == 1)
            {
                if (!optical || (_ID != null && _NormalTemp == null)) _NormalTemp = HartComport.ReadTC(_ID.LongAddress, para);
                return _NormalTemp;
            }
            else if (para == 2)
            {
                if (!optical || (_ID != null && _HightTemp == null)) _HightTemp = HartComport.ReadTC(_ID.LongAddress, para);
                return _HightTemp ;
            }
            return null;
        }
        /// <summary>
        /// 读取某个命令的返回值
        /// </summary>
        public byte[] ReadCommand(byte cmd, byte[] data)
        {
            if (_ID != null) return HartComport.ReadCommand(_ID.LongAddress, cmd, data);
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
            bool ret = HartComport.WritePollingAddress(_ID.LongAddress, pollingAddress);
            if (ret) PollingAddress = pollingAddress;
            return ret;
        }
        /// <summary>
        /// 写消息
        /// </summary>
        public bool WriteMessage(string msg)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WriteMessage(_ID.LongAddress, msg);
            _Message = null;
            return ret;
        }
        /// <summary>
        /// 写标签信息
        /// </summary>
        public bool WriteTag(DeviceTagInfo tag)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WriteTag(_ID.LongAddress, tag);
            if (ret) _Tag = null;
            return ret;
        }
        /// <summary>
        /// 写设备的最终装配号
        /// </summary>
        public bool WriteFinalAssemblyNumber(int assemblyNumber)
        {
            if (_ID == null) return false;
            return HartComport.WriteFinalAssemblyNumber(_ID.LongAddress, assemblyNumber);
        }
        /// <summary>
        /// 写主变量的阻尼系数
        /// </summary>
        public bool WriteDampValue(float dampValue)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WriteDampValue(_ID.LongAddress, dampValue);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 写主变量的量程范围
        /// </summary>
        public bool WritePVRange(UnitCode unitCode, float upperRange, float lowerRange)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WritePVRange(_ID.LongAddress, unitCode, upperRange, lowerRange);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 将当前的主变量值设置成主变量的上限
        /// </summary>
        public bool SetUpperRangeValue()
        {
            if (_ID == null) return false;
            bool ret = HartComport.SetUpperRangeValue(_ID.LongAddress);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 将当前的主变量值设置成主变量的下限
        /// </summary>
        public bool SetLowerRangeValue()
        {
            if (_ID == null) return false;
            bool ret= HartComport.SetLowerRangeValue(_ID.LongAddress);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 设置固定电流输出,当传入的参数为0时表示取消固定电流输出模式
        /// </summary>
        public bool SetFixedCurrent(float current)
        {
            if (_ID == null) return false;
            bool ret= HartComport.SetFixedCurrent(_ID.LongAddress, current);
            if (ret) _PVCurrent = null;
            return ret;
        }
        /// <summary>
        /// 自检
        /// </summary>
        public bool SelftTest()
        {
            if (_ID == null) return false;
            return HartComport.SelftTest(_ID.LongAddress);
        }
        /// <summary>
        /// 复位设备
        /// </summary>
        public bool Reset()
        {
            if (_ID == null) return false;
            return HartComport.Reset(_ID.LongAddress);
        }
        /// <summary>
        /// 设置主变量零点
        /// </summary>
        public bool SetPVZero()
        {
            if (_ID == null) return false;
            return HartComport.SetPVZero(_ID.LongAddress);
        }
        /// <summary>
        /// 设置主变量单位代码
        /// </summary>
        public bool WritePVUnit(UnitCode unitCode)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WritePVUnit(_ID.LongAddress, unitCode);
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
            return HartComport.TrimDACZero(_ID.LongAddress, current);
        }
        /// <summary>
        /// 调校上限电流
        /// </summary>
        public bool TrimDACGain(float current)
        {
            if (_ID == null) return false;
            return HartComport.TrimDACGain(_ID.LongAddress, current);
        }
        /// <summary>
        /// 设置主变量DA输出转换函数
        /// </summary>
        public bool WriteTransferFunction(TransferFunctionCode code)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WriteTransferFunction(_ID.LongAddress, code);
            if (ret) _PVOutput = null;
            return ret;
        }
        /// <summary>
        /// 写主变量传感器序列号
        /// </summary>
        public bool WritePVSensorSN(int sn)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WritePVSensorSN(_ID.LongAddress, sn);
            if (ret) _PVSensor = null;
            return ret;
        }
        /// <summary>
        /// 写返回帧前导字符(0xFF)的个数
        /// </summary>
        public bool WriteResponsePreamblesCount(byte count)
        {
            if (_ID == null) return false;
            return HartComport.WriteResponsePreamblesCount(_ID.LongAddress, count);
        }
        /// <summary>
        /// 设置信号量切除量
        /// </summary>
        public bool WriteCurrentTrim(byte uOrl, float percent)
        {
            if (_ID == null) return false;
            bool ret= HartComport.WriteCurrentTrim(_ID.LongAddress, uOrl, percent);
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
            bool ret= HartComport.WritePVSensorMode(_ID.LongAddress, mode, sensorCode);
            if (ret)
            {
                _PVOutput = null;
                _PVSensor = null;
            }
            return ret;
        }
        #endregion
    }
}
