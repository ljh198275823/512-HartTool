using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HartSDK;

namespace HartTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private HartSDK.HartComport _HartComm = null;
        private int _PollingAddress = 0;
        private UniqueIdentifier _CurDevice = null;
        #endregion

        #region 私有方法
        private void ReadDevice()
        {
            _CurDevice = null;
            if (_HartComm != null && _HartComm.IsOpened && int.TryParse(cmbShortAddress.Text, out _PollingAddress))
            {
                _CurDevice = _HartComm.ReadUniqueID(_PollingAddress);
                txtDeviceID.IntergerValue = _CurDevice != null ? _CurDevice.DeviceID : 0;
                txtPollingAddress.IntergerValue = _PollingAddress;
                if (_CurDevice != null)
                {
                    DeviceTagInfo tag = _HartComm.ReadTag(_CurDevice.LongAddress);
                    txtTag.Text = tag != null ? tag.Tag : string.Empty;
                    txtDescr.Text = tag != null ? tag.Description : string.Empty;
                    txtYear.IntergerValue = tag != null ? tag.Year : 0;
                    txtMonth.IntergerValue = tag != null ? tag.Month : 0;
                    txtDay.IntergerValue = tag != null ? tag.Day : 0;
                    OutputInfo oi = _HartComm.ReadOutput(_CurDevice.LongAddress);
                    txtLowRange.DecimalValue = (decimal)(oi != null ? oi.LowerRangeValue : 0);
                    txtUpperRange.DecimalValue = (decimal)(oi != null ? oi.UpperRangeValue : 0);
                    txtDampValue.DecimalValue = (decimal)(oi != null ? oi.DampingValue : 0);
                }
            }
        }
        #endregion

        #region 事件处理
        private void FrmMain_Load(object sender, EventArgs e)
        {
            comPortComboBox1.Init();
            cmbShortAddress.Text = _PollingAddress.ToString();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (_HartComm != null) _HartComm.Close();
            if (comPortComboBox1.ComPort > 0)
            {
                _HartComm = new HartSDK.HartComport(comPortComboBox1.ComPort, 1200);
                _HartComm.Open();
                _HartComm.Debug = true;
                btnOpen.Enabled = !_HartComm.IsOpened;
                btnClose.Enabled = _HartComm.IsOpened;
                lblCommportState.Text = string.Format(_HartComm.IsOpened ? "通讯串口已打开" : "通讯串口打开失败");
                lblCommportState.ForeColor = _HartComm.IsOpened ? Color.Blue : Color.Red;
                statusStrip1.Refresh();
                ReadDevice();
            }
            else
            {
                MessageBox.Show("请先设置通讯串口");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_HartComm != null) _HartComm.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            lblCommportState.Text = string.Empty;
        }

        private void cmbShortAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadDevice();
        }
        #endregion

        #region 基本信息
        private void btnRealTime_Click(object sender, EventArgs e)
        {
            if (tmrRealTime.Enabled)
            {
                tmrRealTime.Enabled = false;
                btnRealTime.Text = "实时采集";
            }
            else
            {
                if (_CurDevice != null)
                {
                    tmrRealTime.Enabled = true;
                    btnRealTime.Text = "停止采集";
                }
            }
        }

        private void tmrRealTime_Tick(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            DeviceVariable pv = _HartComm.ReadPV(_CurDevice.LongAddress);
            txtPV.Text = pv != null ? pv.Value.ToString() : string.Empty;
            CurrentInfo ci = _HartComm.ReadCurrent(_CurDevice.LongAddress);
            txtCurrent.Text = ci != null ? ci.Current.ToString() : string.Empty;
            txtPercentOfRange.Text = ci != null ? ci.PercentOfRange.ToString() : string.Empty;
        }

        private void btnWritePollingAddress_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            if (txtPollingAddress.IntergerValue >= 0 && txtPollingAddress.IntergerValue <= 15)
            {
                bool ret = _HartComm.WritePollingAddress(_CurDevice.LongAddress, (byte)txtPollingAddress.IntergerValue);
                if (!ret)
                {
                    MessageBox.Show(_HartComm.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("短帧地址只能设置在0-15之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 电流校调
        private void btnFixedCurrent_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            decimal current = txtFixedCurrent.DecimalValue;
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = _HartComm.SetFixedCurrent(_CurDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "设置固定电流成功" : _HartComm.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn4_N_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt4_N.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = _HartComm.TrimDACZero(_CurDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : _HartComm.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn4_H_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt4_H.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = _HartComm.TrimDACZero(_CurDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : _HartComm.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn20_N_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt20_N.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = _HartComm.TrimDACGain(_CurDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : _HartComm.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn20_H_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt20_H.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = _HartComm.TrimDACGain(_CurDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : _HartComm.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 压力微调
        private void btnSetPVZero_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            bool ret = _HartComm.SetPVZero(_CurDevice.LongAddress);
            txtMsg_压力微调.Text = ret ? "设置成功" : _HartComm.GetLastError();
        }

        private void btnSetLowerRange_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            bool ret = _HartComm.SetLowerRangeValue(_CurDevice.LongAddress);
            txtMsg_压力微调.Text = ret ? "设置成功" : _HartComm.GetLastError();
        }

        private void btnSetUpperRange_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            bool ret = _HartComm.SetUpperRangeValue(_CurDevice.LongAddress);
            txtMsg_压力微调.Text = ret ? "设置成功" : _HartComm.GetLastError();
        }
        #endregion

        #region 其它
        private void btnReadMsg_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            string msg = _HartComm.ReadMessage(_CurDevice.LongAddress);
            txtMessage.Text = !string.IsNullOrEmpty(msg) ? msg : _HartComm.GetLastError();
        }

        private void btnWriteMsg_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            _HartComm.WriteMessage(_CurDevice.LongAddress, txtMessage.Text.Trim());
        }
        #endregion

        #region 性能参数
        private void btnWriteTransferFunction_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            if (cmbWriteTranserFunction.SelectedIndex >= 0)
            {
                TransferFunctionCode tc = (TransferFunctionCode)cmbWriteTranserFunction.SelectedIndex;
                bool ret = _HartComm.WriteTransferFunction(_CurDevice.LongAddress, tc);
                if (!ret)
                {
                    MessageBox.Show(_HartComm.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnWriteDampValue_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            decimal damp = 0;
            if (decimal.TryParse(txtWriteDampValue.Text, out damp))
            {
                bool ret = _HartComm.WriteDampValue(_CurDevice.LongAddress, (float)damp);
                if (!ret)
                {
                    MessageBox.Show(_HartComm.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("输入的阻尼系数不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWriteRangeValue_Click(object sender, EventArgs e)
        {
            if (_CurDevice == null) return;
            if (cmbWriteRangeValueUnit.SelectedIndex <= 0)
            {
                MessageBox.Show("没有选择主单位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal lowerRange = 0;
            decimal upperRange = 0;
            if (!decimal.TryParse(txtWriteRangeValueLower.Text, out lowerRange))
            {
                MessageBox.Show("基本量程下限不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtWriteRangeValueUpper.Text, out upperRange))
            {
                MessageBox.Show("基本量程上限不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool ret = _HartComm.WriteRangeValue(_CurDevice.LongAddress, (byte)cmbWriteRangeValueUnit.SelectedIndex,
                (float)lowerRange, (float)upperRange);
            if (!ret)
            {
                MessageBox.Show(_HartComm.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
