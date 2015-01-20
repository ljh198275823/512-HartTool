﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using HartSDK;

namespace HartTool
{
    public partial class Frm压力微调 : Form, IHartCommunication
    {
        public Frm压力微调()
        {
            InitializeComponent();
        }

        #region t私有变量
        private Thread _ReadPV = null;
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            btnSetPVZero.Enabled = CurrentDevice != null;
            rdLower.Enabled = CurrentDevice != null;
            rdUpper.Enabled = CurrentDevice != null;
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
            rdLower.Checked = !ret;
            if (ret && _ReadPV != null)
            {
                _ReadPV.Abort();
                _ReadPV = null;
            }
            MessageBox.Show(ret ? "设置成功" : HartComport.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetUpperRange_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetUpperRangeValue(CurrentDevice.LongAddress);
            rdUpper.Checked = !ret;
            if (ret && _ReadPV != null)
            {
                _ReadPV.Abort();
                _ReadPV = null;
            }
            MessageBox.Show(ret ? "设置成功" : HartComport.GetLastError(), "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rdLower_CheckedChanged(object sender, EventArgs e)
        {
            btnSetLowerRange.Enabled = true;
            if (_ReadPV == null)
            {
                _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                _ReadPV.IsBackground = true;
                _ReadPV.Start();
            }
        }

        private void rdUpper_CheckedChanged(object sender, EventArgs e)
        {
            btnSetUpperRange.Enabled = true;
            if (_ReadPV == null)
            {
                _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                _ReadPV.IsBackground = true;
                _ReadPV.Start();
            }
        }

        private void ReadPV_Thread()
        {
            try
            {
                while (true)
                {
                    if (CurrentDevice != null)
                    {
                        DeviceVariable pv = HartComport.ReadPV(CurrentDevice.LongAddress);
                        if (pv != null)
                        {
                            this.Invoke((Action)(() =>
                                {
                                    if (rdLower.Checked) txtLower.Text = pv.Value.ToString();
                                    if (rdUpper.Checked) txtUpper.Text = pv.Value.ToString();
                                }
                            ));
                        }
                    }
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
