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
            //采用异步的方式
            Action action = delegate()
            {
                this.Invoke((Action)(() =>
                    {
                        button1.Enabled = CurrentDevice != null;
                        button3.Enabled = CurrentDevice != null;
                        if (CurrentDevice != null)
                        {
                            OutputInfo oi = HartComport.ReadOutput(CurrentDevice.LongAddress);
                            cmbPVUnit.SelectedIndex = oi != null ? (int)oi.PVUnitCode : 0;
                            txtPVLower.Text = oi != null ? oi.LowerRangeValue.ToString() : null;
                            txtPVUpper.Text = oi != null ? oi.UpperRangeValue.ToString() : null;
                            SensorInfo si = HartComport.ReadPVSensor(CurrentDevice.LongAddress);
                            txtSensorLower.Text = si != null ? si.LowerLimit.ToString() : null;
                            txtSensorUpper.Text = si != null ? si.UpperLimit.ToString() : null;
                            lblUnit1.Text = si != null ? UnitCodeDescr.GetDescr((UnitCode)si.UnitCode) : null;
                            byte[] data = HartComport.ReadCommand(CurrentDevice.LongAddress, 0x80);
                            if (data != null && data.Length == 22)
                            {
                                cmbSensorMode.SelectedIndex = data[11];
                                cmbSensorCode.SelectedIndex = data[12] >= 2 ? data[12] - 2 : -1;
                            }
                        }
                    }));
            };
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(action));
            t.IsBackground = true;
            t.Start();
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

        #region 事件处理程序
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
            if (ret)
            {
                SensorInfo si = HartComport.ReadPVSensor(CurrentDevice.LongAddress);
                txtSensorLower.Text = si != null ? si.LowerLimit.ToString() : null;
                txtSensorUpper.Text = si != null ? si.UpperLimit.ToString() : null;
            }
            else
            {
                MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            if (cmbPVUnit.SelectedIndex <= 0)
            {
                MessageBox.Show("没有选择量程单位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            float lower = 0;
            float upper = 0;
            if (!float.TryParse(txtPVLower.Text, out lower))
            {
                MessageBox.Show("量程下限不能转化成数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!float.TryParse(txtPVUpper.Text, out upper))
            {
                MessageBox.Show("量程上限不能转化成数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lower > upper)
            {
                MessageBox.Show("量程下限比上限要大", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool ret = HartComport.WritePVRange(CurrentDevice.LongAddress, (UnitCode)cmbPVUnit.SelectedIndex, lower, upper);
            if (!ret) MessageBox.Show(HartComport .GetLastError (), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
    }
}
