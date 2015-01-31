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
    public partial class Frm仪表信息 : Form, IHartCommunication
    {
        public Frm仪表信息()
        {
            InitializeComponent();
        }

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public void ReadData()
        {
            btnDownloadTag.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnDownloadMsg.Enabled = HartDevice != null && HartDevice.IsConnected;
            if (HartDevice != null && HartDevice.IsConnected)
            {
                DeviceTagInfo tag = HartDevice.ReadTag();
                txtTag.Text = tag != null ? tag.Tag : string.Empty;
                txtDescr.Text = tag != null ? tag.Description : string.Empty;
                txtYear.IntergerValue = tag != null ? tag.Year : 0;
                txtMonth.IntergerValue = tag != null ? tag.Month : 0;
                txtDay.IntergerValue = tag != null ? tag.Day : 0;
                OutputInfo oi = HartDevice.ReadOutput();
                txtMessage.Text = HartDevice.ReadMessage();
            }
        }
        #endregion

        private void btnDownloadTag_Click(object sender, EventArgs e)
        {
            DeviceTagInfo tag = new DeviceTagInfo();
            tag.Tag = txtTag.Text;
            tag.Description = txtDescr.Text;
            tag.Year = txtYear.IntergerValue;
            tag.Month = txtMonth.IntergerValue;
            tag.Day = txtDay.IntergerValue;
            bool ret = HartDevice.WriteTag(tag);
            MessageBox.Show(ret ? "下载成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDownloadMsg_Click(object sender, EventArgs e)
        {
            bool ret = HartDevice.WriteMessage(txtMessage.Text);
            MessageBox.Show(ret ? "下载成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
