using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HartTool
{
    public partial class Frm压力标定 : Form,IHartCommunication 
    {
        public Frm压力标定()
        {
            InitializeComponent();
        }

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
        }
        #endregion

        #region 压力微调
        private void btnSetPVZero_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetPVZero(CurrentDevice.LongAddress);
            MessageBox.Show(ret ? "设置成功" : HartComport.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetLowerRange_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetLowerRangeValue(CurrentDevice.LongAddress);
            MessageBox.Show(ret ? "设置成功" : HartComport.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetUpperRange_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetUpperRangeValue(CurrentDevice.LongAddress);
            MessageBox.Show(ret ? "设置成功" : HartComport.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
