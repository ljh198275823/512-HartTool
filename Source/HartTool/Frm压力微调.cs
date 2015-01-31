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
            float lv = 0;
            if (float.TryParse(txtLower.Text, out lv))
            {
                bool ret = HartDevice.SetLowerRangeValue(_PV.UnitCode, lv);
                rdLower.Checked = !ret;
                if (ret && _ReadPV != null) _Running = false;
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
            float uv = 0;
            if (float.TryParse(txtUpper.Text, out uv))
            {
                bool ret = HartDevice.SetUpperRangeValue(_PV.UnitCode, uv);
                rdUpper.Checked = !ret;
                if (ret && _ReadPV != null) _Running = false;
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
            btnSetUpperRange.Enabled = false;
            if (_ReadPV == null)
            {
                _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                _ReadPV.IsBackground = true;
                _Running = true;
                _ReadPV.Start();
            }
        }

        private void rdUpper_CheckedChanged(object sender, EventArgs e)
        {
            btnSetUpperRange.Enabled = true;
            btnSetLowerRange.Enabled = false;
            if (_ReadPV == null)
            {
                _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                _ReadPV.IsBackground = true;
                _Running = true;
                _ReadPV.Start();
            }
        }

        private void ReadPV_Thread()
        {
            try
            {
                while (_Running)
                {
                    Thread.Sleep(AppSettings.Current.RealInterval);
                    DeviceVariable pv = HartDevice.ReadPV(false);
                    if (pv != null && _Running)
                    {
                        this.Invoke((Action)(() =>
                            {
                                _PV = pv;
                                if (rdLower.Checked)
                                {
                                    txtLower.Text = pv.Value.ToString();
                                    label1.Text = pv.UnitCode.ToString();
                                }
                                else if (rdUpper.Checked)
                                {
                                    txtUpper.Text = pv.Value.ToString();
                                    label2.Text = pv.UnitCode.ToString();
                                }
                            }
                        ));
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
                OutputInfo oi = HartDevice.ReadOutput();
                txtOutputLower.Text = oi != null ? oi.LowerRangeValue.ToString() : null;
                txtOutputUpper.Text = oi != null ? oi.UpperRangeValue.ToString() : null;
                lblPVU1.Text = oi != null ? ((UnitCode)oi.PVUnitCode).ToString() : null;
                lblPVU2.Text = oi != null ? ((UnitCode)oi.PVUnitCode).ToString() : null;
            }
        }
        #endregion

        private void btnRead_Click(object sender, EventArgs e)
        {
            ReadOutput();
        }
    }
}
