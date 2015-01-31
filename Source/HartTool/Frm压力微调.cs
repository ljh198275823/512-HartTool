using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HartSDK;

namespace HartTool
{
    public partial class Frm压力微调 : Form, IHartCommunication
    {
        public Frm压力微调()
        {
            InitializeComponent();
        }

        #region 私有变量
        private bool _Running = false;
        private Thread _ReadPV = null;
        private DeviceVariable _PV = null;
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public void ReadData()
        {
            btnSetPVZero.Enabled = HartDevice != null && HartDevice.IsConnected;
            rdLower.Enabled = HartDevice != null && HartDevice.IsConnected;
            rdUpper.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnSetLowerRange.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnSetUpperRange.Enabled = HartDevice != null && HartDevice.IsConnected;
            ReadOutput();
        }
        #endregion

        #region 压力微调
        private void btnSetPVZero_Click(object sender, EventArgs e)
        {
            bool ret = HartDevice.SetPVZero();
            MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetLowerRange_Click(object sender, EventArgs e)
        {
            if (_PV == null) return;
            float lv = 0;
            if (float.TryParse(txtLower.Text, out lv))
            {
                bool ret = HartDevice.SetLowerRangeValue(_PV.UnitCode, lv);
                rdLower.Checked = !ret;
                MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadOutput();
            }
            else
            {
                MessageBox.Show("低点压力不能转化成数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetUpperRange_Click(object sender, EventArgs e)
        {
            if (_PV == null) return;
            float uv = 0;
            if (float.TryParse(txtUpper.Text, out uv))
            {
                bool ret = HartDevice.SetUpperRangeValue(_PV.UnitCode, uv);
                rdUpper.Checked = !ret;
                MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadOutput();
            }
            else
            {
                MessageBox.Show("高点压力不能转化成数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdLower_CheckedChanged(object sender, EventArgs e)
        {
            btnSetLowerRange.Enabled = true;
            button1.Enabled = true;
            btnSetUpperRange.Enabled = false;
            button2.Enabled = false;
        }

        private void rdUpper_CheckedChanged(object sender, EventArgs e)
        {
            btnSetUpperRange.Enabled = true;
            button2.Enabled = true;
            btnSetLowerRange.Enabled = false;
            button1.Enabled = false;
        }

        private void ReadPV_Thread()
        {
            try
            {
                while (_Running)
                {
                    Thread.Sleep(AppSettings.Current.RealInterval);
                    if (HartDevice != null && HartDevice.IsConnected)
                    {
                        DeviceVariable pv = HartDevice.ReadPV(false);
                        if (pv != null && _Running)
                        {
                            this.Invoke((Action)(() =>
                                {
                                    _PV = pv;
                                    txtReal.Text = pv.Value.ToString();
                                }
                            ));
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
            finally
            {
                _ReadPV = null;
            }
        }

        private void Frm压力微调_FormClosed(object sender, FormClosedEventArgs e)
        {
            _Running = false;
        }

        private void ReadOutput()
        {
            if (HartDevice != null && HartDevice.IsConnected)
            {
                byte[] data = HartDevice.ReadCommand(0x80, null);
                if (data != null && data.Length == 22)
                {
                    txtUpper.Text = BitConverter.ToSingle(new byte[] { data[17], data[16], data[15], data[14] }, 0).ToString();
                    txtLower.Text = BitConverter.ToSingle(new byte[] { data[21], data[20], data[19], data[18] }, 0).ToString();
                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DeviceVariable pv = HartDevice.ReadPV(false);
            if (pv != null)
            {
                txtLower.Text = pv.Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeviceVariable pv = HartDevice.ReadPV(false);
            if (pv != null)
            {
                txtUpper.Text = pv.Value.ToString();
            }
        }

        private void Frm压力微调_Load(object sender, EventArgs e)
        {
            if (_ReadPV == null)
            {
                _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                _ReadPV.IsBackground = true;
                _Running = true;
                _ReadPV.Start();
            }
        }
    }
}
