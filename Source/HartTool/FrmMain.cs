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
        private int _ShortAddress = 0;
        private UniqueIdentifier _CurUI = null;
        #endregion

        #region 私有方法
        private void ReadDevice()
        {
            _CurUI = null;
            if (_HartComm != null && _HartComm.IsOpened && int.TryParse(cmbShortAddress.Text, out _ShortAddress))
            {
                _CurUI = _HartComm.ReadUniqueID(_ShortAddress);
                txtDeviceID.IntergerValue = _CurUI != null ? _CurUI.DeviceID : 0;
                if (_CurUI != null)
                {
                    DeviceTagInfo tag = _HartComm.ReadTag(_CurUI.LongAddress);
                    txtTag.Text = tag != null ? tag.Tag : string.Empty;
                    txtDescr.Text = tag != null ? tag.Description : string.Empty;
                    txtYear.IntergerValue = tag != null ? tag.Date.Year : 0;
                    txtMonth.IntergerValue = tag != null ? tag.Date.Month : 0;
                    txtDay.IntergerValue = tag != null ? tag.Date.Day : 0;
                    txtMessage.Text = _HartComm.ReadMessage(_CurUI.LongAddress);
                }
            }
        }
        #endregion

        private void FrmMain_Load(object sender, EventArgs e)
        {
            comPortComboBox1.Init();
            cmbShortAddress.Text = _ShortAddress.ToString();
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
                if (_CurUI != null)
                {
                    tmrRealTime.Enabled = true;
                    btnRealTime.Text = "停止采集";
                }
            }
        }

        private void tmrRealTime_Tick(object sender, EventArgs e)
        {
            if (_CurUI == null) return;
            DeviceVariable pv = _HartComm.ReadPV(_CurUI.LongAddress);
            txtPV.Text = pv != null ? pv.Value.ToString() : string.Empty;
            CurrentInfo ci = _HartComm.ReadCurrent(_CurUI.LongAddress);
            txtCurrent.Text = ci != null ? ci.Current.ToString() : string.Empty;
            txtPercentOfRange.Text = ci != null ? ci.PercentOfRange.ToString() : string.Empty;
        }
    }
}
