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
    public partial class Frm性能参数 : Form,IHartCommunication 
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
        }
        #endregion


        #region 性能参数
        private void btnWriteTransferFunction_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            if (cmbWriteTranserFunction.SelectedIndex >= 0)
            {
                TransferFunctionCode tc = (TransferFunctionCode)cmbWriteTranserFunction.SelectedIndex;
                bool ret = HartComport.WriteTransferFunction(CurrentDevice.LongAddress, tc);
                if (!ret)
                {
                    MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnWriteDampValue_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            decimal damp = 0;
            if (decimal.TryParse(txtWriteDampValue.Text, out damp))
            {
                bool ret = HartComport.WriteDampValue(CurrentDevice.LongAddress, (float)damp);
                if (!ret)
                {
                    MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("输入的阻尼系数不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWriteRangeValue_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            if (cmbWriteRangeValueUnit.SelectedIndex <= 0)
            {
                MessageBox.Show("没有选择主单位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal lowerRange = 0;
            decimal upperRange = 0;
            if (!decimal.TryParse(txtWriteRangeValueLower.Text, out lowerRange))
            {
                MessageBox.Show("基本量程下限不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtWriteRangeValueUpper.Text, out upperRange))
            {
                MessageBox.Show("基本量程上限不是有效的数值", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool ret = HartComport.WriteRangeValue(CurrentDevice.LongAddress, (byte)cmbWriteRangeValueUnit.SelectedIndex,
                (float)lowerRange, (float)upperRange);
            if (!ret)
            {
                MessageBox.Show(HartComport.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
