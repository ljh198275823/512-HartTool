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
                    Thread.Sleep(200);
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
            btnLow.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnNormal.Enabled = (HartDevice != null && HartDevice.IsConnected);
            btnHight.Enabled = (HartDevice != null && HartDevice.IsConnected);

            TemperatureCompensation tc = HartDevice.ReadTC(0);
            txtLowTempAD.Text = tc != null ? tc.TemperatureAD.ToString() : null;
            txtLowAD1.Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            txtLowAD2.Text = tc != null ? tc.UpperRangeAD.ToString() : null;

            tc = HartDevice.ReadTC(1);
            txtNormalTempAD.Text = tc != null ? tc.TemperatureAD.ToString() : null;
            txtNormalAD1.Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            txtNormalAD2.Text = tc != null ? tc.UpperRangeAD.ToString() : null;

            tc = HartDevice.ReadTC(2);
            txtHightTempAD.Text = tc != null ? tc.TemperatureAD.ToString() : null;
            txtHightAD1.Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            txtHightAD2.Text = tc != null ? tc.UpperRangeAD.ToString() : null;
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

        private void btuLow_Click(object sender, EventArgs e)
        {
            if (HartDevice == null) return;
            float tempAD = 0;
            float lowerAD = 0;
            float upperAD = 0;
            if (!float.TryParse(txtLowTempAD.Text, out tempAD))
            {
                MessageBox.Show("温度AD不能转化成数值");
                txtLowTempAD.Focus();
                return;
            }
            if (!float.TryParse(txtLowAD1.Text, out lowerAD))
            {
                MessageBox.Show("压力零点AD不能转化成数值");
                txtLowAD1.Focus();
                return;
            }
            if (!float.TryParse(txtLowAD2.Text, out upperAD))
            {
                MessageBox.Show("压力满度AD不能转化成数值");
                txtLowAD2.Focus();
                return;
            }
            TemperatureCompensation tc = new TemperatureCompensation() { TemperatureAD = tempAD, LowerRangeAD = lowerAD, UpperRangeAD = upperAD };
            bool ret = HartDevice.WriteTC(0, tc);
            if (!ret) MessageBox.Show(HartDevice.GetLastError());
        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (HartDevice == null) return;
            float tempAD = 0;
            float lowerAD = 0;
            float upperAD = 0;
            if (!float.TryParse(txtNormalTempAD.Text, out tempAD))
            {
                MessageBox.Show("温度AD不能转化成数值");
                txtNormalTempAD.Focus();
                return;
            }
            if (!float.TryParse(txtNormalAD1.Text, out lowerAD))
            {
                MessageBox.Show("压力零点AD不能转化成数值");
                txtNormalAD1.Focus();
                return;
            }
            if (!float.TryParse(txtNormalAD2.Text, out upperAD))
            {
                MessageBox.Show("压力满度AD不能转化成数值");
                txtNormalAD2.Focus();
                return;
            }
            TemperatureCompensation tc = new TemperatureCompensation() { TemperatureAD = tempAD, LowerRangeAD = lowerAD, UpperRangeAD = upperAD };
            bool ret = HartDevice.WriteTC(1, tc);
            if (!ret) MessageBox.Show(HartDevice.GetLastError());
        }

        private void btnHight_Click(object sender, EventArgs e)
        {
            if (HartDevice == null) return;
            float tempAD = 0;
            float lowerAD = 0;
            float upperAD = 0;
            if (!float.TryParse(txtHightTempAD.Text, out tempAD))
            {
                MessageBox.Show("温度AD不能转化成数值");
                txtHightTempAD.Focus();
                return;
            }
            if (!float.TryParse(txtHightAD1.Text, out lowerAD))
            {
                MessageBox.Show("压力零点AD不能转化成数值");
                txtHightAD1.Focus();
                return;
            }
            if (!float.TryParse(txtHightAD2.Text, out upperAD))
            {
                MessageBox.Show("压力满度AD不能转化成数值");
                txtHightAD2.Focus();
                return;
            }
            TemperatureCompensation tc = new TemperatureCompensation() { TemperatureAD = tempAD, LowerRangeAD = lowerAD, UpperRangeAD = upperAD };
            bool ret = HartDevice.WriteTC(2, tc);
            if (!ret) MessageBox.Show(HartDevice.GetLastError());
        }

        private void txtLowTempAD_Enter(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            _LastEnter = sender as TextBox;
        }

        private void txtNormalTempAD_Enter(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            _LastEnter = sender as TextBox;
        }

        private void txtHightTempAD_Enter(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            _LastEnter = sender as TextBox;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_LastEnter == null) return;
            if (HartDevice != null && HartDevice.IsConnected)
            {
                byte[] response = HartDevice.ReadCommand(0xAF, _Params);
                if (response != null && response.Length == 14)
                {
                    if (object.ReferenceEquals(_LastEnter, txtLowTempAD)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[9], response[8], response[7], response[6] }, 0).ToString("F0");
                    if (object.ReferenceEquals(_LastEnter, txtLowAD1)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                    if (object.ReferenceEquals(_LastEnter, txtLowAD2)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_LastEnter == null) return;
            if (HartDevice != null && HartDevice.IsConnected)
            {
                byte[] response = HartDevice.ReadCommand(0xAF, _Params);
                if (response != null && response.Length == 14)
                {
                    if (object.ReferenceEquals(_LastEnter, txtNormalTempAD)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[9], response[8], response[7], response[6] }, 0).ToString("F0");
                    if (object.ReferenceEquals(_LastEnter, txtNormalAD1)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                    if (object.ReferenceEquals(_LastEnter, txtNormalAD2)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (_LastEnter == null) return;
            if (HartDevice != null && HartDevice.IsConnected)
            {
                byte[] response = HartDevice.ReadCommand(0xAF, _Params);
                if (response != null && response.Length == 14)
                {
                    if (object.ReferenceEquals(_LastEnter, txtHightTempAD)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[9], response[8], response[7], response[6] }, 0).ToString("F0");
                    if (object.ReferenceEquals(_LastEnter, txtHightAD1)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                    if (object.ReferenceEquals(_LastEnter, txtHightAD2)) _LastEnter.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString("F0");
                }
            }
        }
        #endregion
    }
}
