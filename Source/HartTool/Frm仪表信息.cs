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
            DeviceTagInfo tag = HartDevice.ReadTag();
            txtTag.Text = tag != null ? tag.Tag : string.Empty;
            txtDescr.Text = tag != null ? tag.Description : string.Empty;
            txtYear.IntergerValue = tag != null ? tag.Year : 0;
            txtMonth.IntergerValue = tag != null ? tag.Month : 0;
            txtDay.IntergerValue = tag != null ? tag.Day : 0;
            OutputInfo oi = HartDevice.ReadOutput();
            txtMessage.Text = HartDevice.ReadMessage();
        }
        #endregion
    }
}
