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
    public partial class Frm基本信息 : Form, IHartCommunication
    {
        #region 构造函数
        public Frm基本信息()
        {
            InitializeComponent();
        }
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            txtDeviceID.IntergerValue = CurrentDevice != null ? CurrentDevice.DeviceID : 0;
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
        #endregion

        #region 事件处理程序
        private void FrmGeneralInfo_Load(object sender, EventArgs e)
        {
            ReadData();
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
