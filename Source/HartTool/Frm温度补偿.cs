using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading ;
using System.Windows.Forms;
using HartSDK;

namespace HartTool
{
    public partial class Frm温度补偿 : Form, IHartCommunication
    {
        public Frm温度补偿()
        {
            InitializeComponent();
        }

        #region 私有变量
        private byte[] _Params = new byte[] { 0x48, 0x48, 0x20, 0x04, 0x42, 0x4E };  //读取AD的参数
        private Thread _TrdReadAD = null;

        private TextBox _LastEnter = null;
        #endregion

        #region 私有方法
        private void ReadAD_Task()
        {
            try
            {
                while (true)
                {
                    if (HartDevice != null && HartDevice.IsConnected)
                    {
                        byte[] response = HartDevice.ReadCommand(0xAF, _Params);
                        if (response != null && response.Length == 14)
                        {
                            this.Invoke((Action)(() =>
                                {
                                    txtPresureAD.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                                    txtTempAD.Text = BitConverter.ToSingle(new byte[] { response[9], response[8], response[7], response[6] }, 0).ToString("F0");
                                }));
                        }
                    }
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            if (HartDevice == null || !HartDevice.IsConnected) return;
            btnRead0.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnRead1.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnRead2.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnWrite0.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnWrite1.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnWrite2.Enabled = (HartDevice != null && HartDevice.IsConnected);

            btnRead0.PerformClick();
            btnRead1.PerformClick();
            btnRead2.PerformClick();
        }
        #endregion

        #region 事件处理程序
        private void Frm温度补偿_Load(object sender, EventArgs e)
        {
            _TrdReadAD = new Thread(new ThreadStart(ReadAD_Task));
            _TrdReadAD.IsBackground = true;
            _TrdReadAD.Start();
        }

        private void Frm温度补偿_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_TrdReadAD != null)
            {
                _TrdReadAD.Abort();
                _TrdReadAD = null;
            }
        }

        private void txtLowTempAD_Enter(object sender, EventArgs e)
        {
            btnCollect0.Enabled = true;
            btnCollect1.Enabled = false;
            btnCollect2.Enabled = false;
            _LastEnter = sender as TextBox;
        }

        private void txtNormalTempAD_Enter(object sender, EventArgs e)
        {
            btnCollect0.Enabled = false;
            btnCollect1.Enabled = true;
            btnCollect2.Enabled = false;
            _LastEnter = sender as TextBox;
        }

        private void txtHightTempAD_Enter(object sender, EventArgs e)
        {
            btnCollect0.Enabled = false;
            btnCollect1.Enabled = false;
            btnCollect2.Enabled = true;
            _LastEnter = sender as TextBox;
        }

        private void btnCollect_Click(object sender, EventArgs e)
        {
            if (_LastEnter == null) return;
            object tag = (sender as Control).Tag;
            if (tag == null) return;
            if (HartDevice != null && HartDevice.IsConnected)
            {
                byte[] response = HartDevice.ReadCommand(0xAF, _Params);
                if (response != null && response.Length == 14)
                {
                    if (object.ReferenceEquals(_LastEnter, this.Controls["txtTempAD" + tag.ToString()]))
                    {
                        _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[9], response[8], response[7], response[6] }, 0).ToString("F0");
                        _LastEnter = (this.Controls["txtLow" + tag.ToString()] as TextBox);
                        _LastEnter.Focus();
                    }
                    if (object.ReferenceEquals(_LastEnter, this.Controls["txtLow" + tag.ToString()]))
                    {
                        _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                        _LastEnter = this.Controls["txtUpper" + tag.ToString()] as TextBox;
                        _LastEnter.Focus();
                    }
                    if (object.ReferenceEquals(_LastEnter, this.Controls["txtUpper" + tag.ToString()]))
                    {
                        _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                        byte temp = byte.Parse(tag.ToString());
                        if (temp < 2) //如果没有到未尾
                        {
                            temp++;
                            _LastEnter = this.Controls["txtTempAD" + temp.ToString()] as TextBox;
                            _LastEnter.Focus();
                        }
                    }
                }
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (HartDevice == null) return;
            object tag = (sender as Control).Tag;
            if (tag == null) return;
            TemperatureCompensation tc = HartDevice.ReadTC(byte.Parse(tag.ToString()));
            (this.Controls["txtTempAD" + tag.ToString()] as TextBox).Text = tc != null ? tc.TemperatureAD.ToString() : null;
            (this.Controls["txtLow" + tag.ToString()] as TextBox).Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            (this.Controls["txtUpper" + tag.ToString()] as TextBox).Text = tc != null ? tc.UpperRangeAD.ToString() : null;
        }

        private void btuWrite_Click(object sender, EventArgs e)
        {
            if (HartDevice == null) return;
            object tag = (sender as Control).Tag;
            if (tag == null) return;
            float tempAD = 0;
            float lowerAD = 0;
            float upperAD = 0;
            if (!float.TryParse((this.Controls["txtTempAD" + tag.ToString()] as TextBox).Text, out tempAD))
            {
                MessageBox.Show("温度AD不能转化成数值");
                txtTempAD0.Focus();
                return;
            }
            if (!float.TryParse((this.Controls["txtLow" + tag.ToString()] as TextBox).Text, out lowerAD))
            {
                MessageBox.Show("压力零点AD不能转化成数值");
                txtLow0.Focus();
                return;
            }
            if (!float.TryParse((this.Controls["txtUpper" + tag.ToString()] as TextBox).Text, out upperAD))
            {
                MessageBox.Show("压力满度AD不能转化成数值");
                txtUpper0.Focus();
                return;
            }
            TemperatureCompensation tc = new TemperatureCompensation() { TemperatureAD = tempAD, LowerRangeAD = lowerAD, UpperRangeAD = upperAD };
            bool ret = HartDevice.WriteTC(byte.Parse(tag.ToString()), tc);
            MessageBox.Show(ret ? "下载成功" : HartDevice.GetLastError(), "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
