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
    public partial class FrmGeneralInfo : Form, IHartCommunication
    {
        #region 构造函数
        public FrmGeneralInfo()
        {
            InitializeComponent();
        }
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }
        #endregion


        private void FrmGeneralInfo_Load(object sender, EventArgs e)
        {
            if (CurrentDevice != null)
            {
                DeviceTagInfo tag = HartComport.ReadTag(CurrentDevice.LongAddress);
                txtTag.Text = tag != null ? tag.Tag : string.Empty;
                txtDescr.Text = tag != null ? tag.Description : string.Empty;
                txtYear.IntergerValue = tag != null ? tag.Year : 0;
                txtMonth.IntergerValue = tag != null ? tag.Month : 0;
                txtDay.IntergerValue = tag != null ? tag.Day : 0;
                OutputInfo oi = HartComport.ReadOutput(CurrentDevice.LongAddress);
                txtLowRange.DecimalValue = (decimal)(oi != null ? oi.LowerRangeValue : 0);
                txtUpperRange.DecimalValue = (decimal)(oi != null ? oi.UpperRangeValue : 0);
                txtDampValue.DecimalValue = (decimal)(oi != null ? oi.DampingValue : 0);
            }
        }

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
                if (CurrentDevice != null)
                {
                    tmrRealTime.Enabled = true;
                    btnRealTime.Text = "停止采集";
                }
            }
        }

        private void tmrRealTime_Tick(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            DeviceVariable pv = HartComport.ReadPV(CurrentDevice.LongAddress);
            txtPV.Text = pv != null ? pv.Value.ToString() : string.Empty;
            CurrentInfo ci = HartComport.ReadCurrent(CurrentDevice.LongAddress);
            txtCurrent.Text = ci != null ? ci.Current.ToString() : string.Empty;
            txtPercentOfRange.Text = ci != null ? ci.PercentOfRange.ToString() : string.Empty;
        }

        private void btnWritePollingAddress_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            if (txtPollingAddress.IntergerValue >= 0 && txtPollingAddress.IntergerValue <= 15)
            {
                bool ret = HartComport.WritePollingAddress(CurrentDevice.LongAddress, (byte)txtPollingAddress.IntergerValue);
                if (!ret)
                {
                    MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("短帧地址只能设置在0-15之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
