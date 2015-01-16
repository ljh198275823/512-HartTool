﻿using System;
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
                if (_CurDevice != null)
                {
                    DeviceTagInfo tag = _HartComm.ReadTag(_CurDevice.LongAddress);
                    txtTag.Text = tag != null ? tag.Tag : string.Empty;
                    txtDescr.Text = tag != null ? tag.Description : string.Empty;
                    txtYear.IntergerValue = tag != null ? tag.Year : 0;
                    txtMonth.IntergerValue = tag != null ? tag.Month : 0;
                    txtDay.IntergerValue = tag != null ? tag.Day : 0;
                    string msg = _HartComm.ReadMessage(_CurDevice.LongAddress);
                    txtMessage.Text = !string.IsNullOrEmpty(msg) ? msg : _HartComm.GetLastError();
                    OutputInfo oi = _HartComm.ReadOutput(_CurDevice.LongAddress);
                    txtLowRange.DecimalValue = (decimal)(oi != null ? oi.LowerRangeValue : 0);
                    txtUpperRange.DecimalValue = (decimal)(oi != null ? oi.UpperRangeValue : 0);
                    txtDampValue.DecimalValue = (decimal)(oi != null ? oi.DampingValue : 0);
                }
            }
        }
        #endregion

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
    }
}
