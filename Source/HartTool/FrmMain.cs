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
        private HartSDK.HartCommunication _HartComm = null;
        private int _ShortAddress = 0;
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
                _HartComm = new HartSDK.HartCommunication(comPortComboBox1.ComPort, 1200);
                _HartComm.Open();
                _HartComm.Debug = true;
                btnOpen.Enabled = !_HartComm.IsOpened;
                btnClose.Enabled = _HartComm.IsOpened;
                lblCommportState.Text = string.Format(_HartComm .IsOpened ?"通讯串口已打开":"通讯串口打开失败");
                lblCommportState.ForeColor = _HartComm.IsOpened ? Color.Blue : Color.Red;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (_HartComm == null || !_HartComm.IsOpened)
            {
                MessageBox.Show("通讯串口打开失败");
                return;
            }
            cmbShortAddress.Items.Clear();
            for (int i = 0; i < 1; i++)
            {
                RequestPacket p = new RequestPacket()
                {
                    LongOrShort = 0,
                    Address = i,
                    Command = 0x00,
                    DataContent = null
                };
                ResponsePacket response = _HartComm.Request(p);
                if (response != null)
                {
                    cmbShortAddress.Items.Add(i);
                    count++;
                }
            }
            MessageBox.Show(string.Format("共搜索到 {0} 个设备", count), "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
