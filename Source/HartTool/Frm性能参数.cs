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
    public partial class Frm性能参数 : Form, IHartCommunication
    {
        public Frm性能参数()
        {
            InitializeComponent();
        }

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            if (CurrentDevice == null) return;
            OutputInfo oi = HartComport.ReadOutput(CurrentDevice.LongAddress);
            if (oi != null)
            {
                cmbTranserFunction.SelectedIndex = oi.TransferFunctionCode;
                txtDampValue.Text = oi.DampingValue.ToString();
                cmbPVUnit.SelectedIndex = oi.PVUnitCode;
            }
        }
        #endregion

        private bool CheckInput()
        {
            if (cmbTranserFunction.SelectedIndex < 0)
            {
                MessageBox.Show("没有指定输出函数");
                return false;
            }
            if (cmbPVUnit.SelectedIndex <= 0)
            {
                MessageBox.Show("没有指定显示单位");
                return false;
            }
            decimal damp = 0;
            if (!decimal.TryParse(txtDampValue.Text, out damp))
            {
                MessageBox.Show("输入的阻尼系数不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            if (!CheckInput()) return;
            bool ret = false;

            TransferFunctionCode tc = (TransferFunctionCode)cmbTranserFunction.SelectedIndex;
            ret = HartComport.WriteTransferFunction(CurrentDevice.LongAddress, tc);
            if (!ret) MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            UnitCode pvUnit = (UnitCode)cmbPVUnit.SelectedIndex;
            ret = HartComport.WritePVUnit(CurrentDevice.LongAddress, pvUnit);
            if (!ret) MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

            decimal damp = 0;
            decimal.TryParse(txtDampValue.Text, out damp);
            ret = HartComport.WriteDampValue(CurrentDevice.LongAddress, (float)damp);
            if (!ret)
            {
                MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm性能参数_Load(object sender, EventArgs e)
        {
            ReadData();
        }
    }
}
