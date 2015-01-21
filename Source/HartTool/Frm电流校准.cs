﻿using System;
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
            btnFixedCurrent.Enabled = HartDevice != null && HartDevice.IsConnected;
        }
        #endregion

        #region 电流校调
        private void btnFix4_Click(object sender, EventArgs e)
        {
            if (HartDevice != null && HartDevice.IsConnected) return;
            bool ret = HartDevice.SetFixedCurrent( (float)4.0);
            txt4.Enabled = ret;
            btn4.Enabled = ret;
            if (!ret)
            {
                MessageBox.Show(HartDevice.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFix20_Click(object sender, EventArgs e)
        {
            if (HartDevice != null && HartDevice.IsConnected) return;
            bool ret = HartDevice.SetFixedCurrent( (float)20.0);
            txt20.Enabled = ret;
            btn20.Enabled = ret;
            if (!ret)
            {
                MessageBox.Show(HartDevice.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFixedCurrent_Click(object sender, EventArgs e)
        {
            if (HartDevice != null && HartDevice.IsConnected) return;
            decimal current = txtFixedCurrent.DecimalValue;
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartDevice.SetFixedCurrent( (float)current);
                MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (HartDevice != null && HartDevice.IsConnected) return;
            decimal current = -1;
            if (!decimal.TryParse(txt4.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartDevice.TrimDACZero( (float)current);
                MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            if (HartDevice != null && HartDevice.IsConnected) return;
            decimal current = -1;
            if (!decimal.TryParse(txt20.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartDevice.TrimDACGain( (float)current);
                MessageBox.Show(ret ? "设置成功" : HartDevice.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
