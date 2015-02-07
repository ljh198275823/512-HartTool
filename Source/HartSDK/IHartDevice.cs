using System;
using System.Runtime.InteropServices;

namespace HartSDK
{
    [ComVisible(true)]
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    [Guid("5E725A01-E006-47EB-A65A-DD3ED9646C05")]
    public  interface IHartDevice
    {
        #region 属性
        /// <summary>
        /// 获取或设置设备的通讯串口
        /// </summary>
        byte Comport { get; set; }
        /// <summary>
        ///获取或设置波特率
        /// </summary>
        int Baud { get; set; }
        /// <summary>
        /// 获取或设置设备的短帧地址
        /// </summary>
        byte PollingAddress { get; set; }
        /// <summary>
        /// 获取或设置是否连接当前设备
        /// </summary>
        bool IsConnected{get;}
        /// <summary>
        /// 获取或设置是否在调试模式
        /// </summary>
        bool Debug { get; set; }
        #endregion

        #region 方法
        bool BackUp();
        void Close();
        void Connect();
        bool DataInit();
        string GetLastError();
        byte[] ReadCommand(byte cmd, byte[] data);
        CurrentInfo ReadCurrent(bool optical = false);
        float ReadCurrentTrim(byte upperOrLower, bool optical = false);
        LinearizationItem ReadLinearizationItem(byte para, bool optical = false);
        string ReadMessage(bool optical = false);
        OutputInfo ReadOutput(bool optical = false);
        DeviceVariable ReadPV(bool optical = false);
        float ReadPVAD(bool optical = false);
        SensorInfo ReadPVSensor(bool optical = false);
        SensorCode? ReadSensorCode(bool optical = false);
        SensorMode? ReadSensorMode(bool optical = false);
        DeviceTagInfo ReadTag(bool optical = false);
        TemperatureCompensation ReadTC(byte para, bool optical = false);
        UniqueIdentifier ReadUniqueID(bool optical = false);

        bool Reset();
        bool Restore();
        bool SelftTest();
        bool SetFixedCurrent(float current);
        bool SetLowerRangeValue(UnitCode uc, float lv);
        bool SetPVZero();
        bool SetUpperRangeValue(UnitCode uc, float uv);
        bool TrimDACGain(float current);
        bool TrimDACZero(float current);
        bool WriteCurrentTrim(byte uOrl, float percent);
        bool WriteDampValue(float dampValue);
        bool WriteFinalAssemblyNumber(int assemblyNumber);
        bool WriteLinearizationItems(LinearizationItem[] items, byte start);
        bool WriteMessage(string msg);
        bool WritePollingAddress(byte pollingAddress);
        bool WritePVRange(UnitCode unitCode, float upperRange, float lowerRange);
        bool WritePVSensorMode(SensorMode mode, SensorCode sensorCode);
        bool WritePVSensorSN(int sn);
        bool WritePVUnit(UnitCode unitCode);
        bool WriteResponsePreamblesCount(byte count);
        bool WriteTag(DeviceTagInfo tag);
        bool WriteTC(byte para, TemperatureCompensation tc);
        bool WriteTransferFunction(TransferFunctionCode code);
        #endregion
    }
}
