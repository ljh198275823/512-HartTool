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
        public HartSDK.HartDevice HartDevice { get; set; }

        public void ReadData()
        {
            OutputInfo oi = HartDevice.ReadOutput();
            txtOutputLower.Text = oi != null ? oi.LowerRangeValue.ToString() : null;
            txtOutputUpper.Text = oi != null ? oi.UpperRangeValue.ToString() : null;
            lblPVU1.Text = oi != null ? ((UnitCode)oi.PVUnitCode).ToString() : null;
            lblPVU2.Text = oi != null ? ((UnitCode)oi.PVUnitCode).ToString() : null;
            SensorInfo si = HartDevice.ReadPVSensor();
            txtSensorLower.Text = si != null ? si.LowerLimit.ToString() : null;
            txtSenserUpper.Text = si != null ? si.UpperLimit.ToString() : null;
            lblSU1.Text = si != null ? ((UnitCode)si.UnitCode).ToString() : null;
            lblSU2.Text = si != null ? ((UnitCode)si.UnitCode).ToString() : null;
            txtTrim4.Text = HartDevice.ReadCurrentTrim(0).ToString();
        }
        #endregion

        #region 事件处理程序
        private void txtPwd_TextChanged(object sender, EventArgs e)
        {
            btnBackToDevice.Enabled = txtPwd.Text == "5567" && HartDevice != null && HartDevice.IsConnected;
            btnBackToPC.Enabled = txtPwd.Text == "5567" && HartDevice != null && HartDevice.IsConnected;
            btnRestoreFromDecice.Enabled = txtPwd.Text == "5567" && HartDevice != null && HartDevice.IsConnected;
            btnRestoreFromPC.Enabled = txtPwd.Text == "5567" && HartDevice != null && HartDevice.IsConnected;
        }

        private void btnBackToDevice_Click(object sender, EventArgs e)
        {
            if (HartDevice == null || !HartDevice.IsConnected) return;
            bool ret = HartDevice.BackUp();
            if (ret)
            {
                MessageBox.Show("备份到设备成功");
            }
            else
            {
                MessageBox.Show(HartDevice.GetLastError(), "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestoreFromDecice_Click(object sender, EventArgs e)
        {
            if (HartDevice == null || !HartDevice.IsConnected) return;
            bool ret = HartDevice.Restore();
            if (ret)
            {
                MessageBox.Show("从设备恢复成功");
            }
            else
            {
                MessageBox.Show(HartDevice.GetLastError(), "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
