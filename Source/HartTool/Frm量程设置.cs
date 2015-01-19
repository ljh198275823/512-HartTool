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
    public partial class Frm量程设置 : Form, IHartCommunication
    {
        public Frm量程设置()
        {
            InitializeComponent();
            InitCmbSensorMode();
            InitCmbSensorCode();
        }

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            button1.Enabled = CurrentDevice != null;
            button2.Enabled = CurrentDevice != null;
            button3.Enabled = CurrentDevice != null;
            if (CurrentDevice != null)
            {
                byte[] data = HartComport.ReadCommand(CurrentDevice.LongAddress, 0x80);
                if (data != null && data.Length == 22)
                {
                    cmbSensorMode.SelectedIndex = data[11];
                    cmbSensorCode.SelectedIndex = data[12] >= 2 ? data[12] - 2 : -1;
                }
            }
        }
        #endregion

        #region 私有方法
        private void InitCmbSensorMode()
        {
            cmbSensorMode.Items.Clear();
            for (int i = 0; i < 50; i++)
            {
                if (Enum.IsDefined(typeof(HartSDK.SensorMode), i))
                {
                    cmbSensorMode.Items.Add((HartSDK.SensorMode)i);
                }
            }
        }

        private void InitCmbSensorCode()
        {
            cmbSensorCode.Items.Clear();
            for (int i = 0; i < 50; i++)
            {
                if (Enum.IsDefined(typeof(HartSDK.SensorCode), i))
                {
                    cmbSensorCode.Items.Add(HartSDK.SensorCodeDescr.GetDescr((HartSDK.SensorCode)i));
                }
            }
        }
        #endregion

        private void Frm量程设置_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            if (cmbSensorCode.SelectedIndex < 0)
            {
                MessageBox.Show("没有选择传感器代码", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbSensorMode.SelectedIndex < 0)
            {
                MessageBox.Show("没有选择工作模式", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool ret = HartComport.WritePVSensorMode(CurrentDevice.LongAddress, (SensorMode)cmbSensorMode.SelectedIndex, (SensorCode)(cmbSensorCode.SelectedIndex + 2));
            if (!ret) MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
