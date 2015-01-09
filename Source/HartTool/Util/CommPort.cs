using System;
using System.Windows .Forms ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading ;
using System.IO.Ports;

namespace LJH.HartTool.Util
{
    public delegate void DataArrivedDelegate(object sender, byte[] data);

    /// <summary>
    /// 串口操作
    /// </summary>
    public class CommPort
    {
        #region 构造方法
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="portNum">串口号</param>
        /// <param name="baud">波特率</param>
        public CommPort(byte portNum, int baud)
        {
            _PortName = "COM" + portNum;
            InitCommPort(_PortName, baud);
        }

        public CommPort(string portName, int baud)
        {
            _PortName = portName;
            InitCommPort(_PortName, baud);
        }
        #endregion

        #region 成员变量
        private SerialPort _Port;
        private string _PortName;
        private Thread _ReadDataTread = null;
        #endregion 成员变量

        #region 属性
        /// <summary>
        /// 获取串口当前是否打开
        /// </summary>
        public bool PortOpened
        {
            get
            {
                return _Port.IsOpen;
            }
        }
        /// <summary>
        /// 获取串口号
        /// </summary>
        public byte Port
        {
            get
            {
                string temp = _PortName.Replace("COM", string.Empty);
                byte ret = 0;
                if (byte.TryParse(temp, out ret)) return ret;
                return ret;
            }
        }
        /// <summary>
        /// 获取或设置串口的波特率
        /// </summary>
        public int BaudRate
        {
            get { return _Port.BaudRate; }
            set { _Port.BaudRate = value; }
        }
        /// <summary>
        /// 获取或设置一个值，该值在串行通信过程中启用数据终端就绪 (DTR) 信号。
        /// </summary>
        public bool DtrEnable
        {
            get
            {
                return _Port.DtrEnable;
            }
            set
            {
                _Port.DtrEnable = value;
            }
        }
        #endregion 属性

        #region 事件
        /// <summary>
        /// 数据到达事件（串口接收到数据后触发此事件将数据提供给上层应用）
        /// </summary>
        public event DataArrivedDelegate OnDataArrivedEvent;
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
                        byte[] _buffer = new byte[_Port.BytesToRead];
                        _Port.Read(_buffer, 0, _buffer.Length);
                        if (this.OnDataArrivedEvent != null)
                        {
                            this.OnDataArrivedEvent(this, _buffer);
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
                if (this.PortOpened)
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
