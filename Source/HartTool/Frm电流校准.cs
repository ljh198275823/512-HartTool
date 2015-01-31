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
    public partial class Frm电流校准 : Form, IHartCommunication
    {
        public Frm电流校准()
        {
            InitializeComponent();
        }

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            btnFix4.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnFix20.Enabled = HartDevice != null && HartDevice.IsConnected;
            btn4.Enabled = HartDevice != null && HartDevice.IsConnected;
            btn20.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnFixedCurrent.Enabled = HartDevice != null && HartDevice.IsConnected;
        }
        #endregion

        #region 电流校调
        private void btnFix4_Click(object sender, EventArgs e)
        {
            txt20.Enabled = false;
            btn20.Enabled = false;
            bool ret = HartDevice.SetFixedCurrent((float)4.0);
            txt4.Enabled = ret;
            btn4.Enabled = ret;
            if (!ret) MessageBox.Show(HartDevice.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFix20_Click(object sender, EventArgs e)
        {
            btn4.Enabled = false;
            txt4.Enabled = false;
            bool ret = HartDevice.SetFixedCurrent((float)20.0);
            txt20.Enabled = ret;
            btn20.Enabled = ret;
            if (!ret) MessageBox.Show(HartDevice.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnFixedCurrent_Click(object sender, EventArgs e)
        {
            decimal current = txtFixedCurrent.DecimalValue;
            bool ret = HartDevice.SetFixedCurrent((float)current);
            MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            float current = -1;
            if (!float.TryParse(txt4.Text, out current) || current < 0)
            {
                MessageBox.Show("输入的电流不是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool ret = HartDevice.TrimDACZero(current);
            MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            float current = -1;
            if (!float.TryParse(txt20.Text, out current) || current < 0)
            {
                MessageBox.Show("输入的电流不是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool ret = HartDevice.TrimDACGain(current);
            MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void Frm电流校准_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (chkExitFixCurrent.Checked) HartDevice.SetFixedCurrent(0);
        }
        #endregion
    }
}
