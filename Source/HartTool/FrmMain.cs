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
        [System.Runtime.InteropServices.DllImport("user32")]
        private extern static long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private HartSDK.HartComport HartComport = null;
        private int _PollingAddress = 0;
        private UniqueIdentifier CurrentDevice = null;

        private List<Form> _openedForms = new List<Form>();
        private Form _ActiveForm = null;
        #endregion

        #region 私有方法
        private void ReadDevice()
        {
            CurrentDevice = null;
            if (HartComport != null && HartComport.IsOpened && int.TryParse(cmbShortAddress.Text, out _PollingAddress))
            {
                CurrentDevice = HartComport.ReadUniqueID(_PollingAddress);
                txtDeviceID.IntergerValue = CurrentDevice != null ? CurrentDevice.DeviceID : 0;
                txtPollingAddress.IntergerValue = _PollingAddress;
                if (CurrentDevice != null)
                {
                    foreach (Form frm in _openedForms)
                    {
                        if (frm is IHartCommunication)
                        {
                            IHartCommunication iHart = frm as IHartCommunication;
                            iHart.HartComport = HartComport;
                            iHart.CurrentDevice = CurrentDevice;
                        }
                    }
                    DeviceTagInfo tag = HartComport.ReadTag(CurrentDevice.LongAddress);
                    txtTag.Text = tag != null ? tag.Tag : string.Empty;
                    txtDescr.Text = tag != null ? tag.Description : string.Empty;
                    txtYear.IntergerValue = tag != null ? tag.Year : 0;
                    txtMonth.IntergerValue = tag != null ? tag.Month : 0;
                    txtDay.IntergerValue = tag != null ? tag.Day : 0;
                    OutputInfo oi = HartComport.ReadOutput(CurrentDevice.LongAddress);
                    txtLowRange.DecimalValue = (decimal)(oi != null ? oi.LowerRangeValue : 0);
                    txtUpperRange.DecimalValue = (decimal)(oi != null ? oi.UpperRangeValue : 0);
                    txtDampValue.DecimalValue = (decimal)(oi != null ? oi.DampingValue : 0);
                }
            }
        }

        private void RenderForm(Form frm)
        {
            if (frm == null) return;
            frm.Size = new Size(this.pBody.Size.Width, this.pBody.Height);
            SetParent(frm.Handle, this.pBody.Handle);
            frm.Show();
        }

        private T AddForm<T>() where T : Form
        {
            T instance = null;
            foreach (Form f in _openedForms)
            {
                if (f.GetType() == typeof(T))
                {
                    instance = f as T;
                    break;
                }
            }
            if (instance == null)
            {
                instance = Activator.CreateInstance(typeof(T)) as T;
                instance.TopLevel = false;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.ShowInTaskbar = false;
                instance.StartPosition = FormStartPosition.Manual;
                _openedForms.Add(instance);
            }
            Form frm = instance as Form;
            _ActiveForm = frm;
            RenderForm(frm);
            return instance;
        }
        #endregion

        #region 事件处理
        private void FrmMain_Load(object sender, EventArgs e)
        {
            comPortComboBox1.Init();
            cmbShortAddress.Text = _PollingAddress.ToString();
            btnGeneral.PerformClick();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (HartComport != null) HartComport.Close();
            if (comPortComboBox1.ComPort > 0)
            {
                HartComport = new HartSDK.HartComport(comPortComboBox1.ComPort, 1200);
                HartComport.Open();
                HartComport.Debug = true;
                btnOpen.Enabled = !HartComport.IsOpened;
                btnClose.Enabled = HartComport.IsOpened;
                lblCommportState.Text = string.Format(HartComport.IsOpened ? "通讯串口已打开" : "通讯串口打开失败");
                lblCommportState.ForeColor = HartComport.IsOpened ? Color.Blue : Color.Red;
                statusStrip1.Refresh();
                ReadDevice();
            }
            else
            {
                MessageBox.Show("请先设置通讯串口");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HartComport != null) HartComport.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            lblCommportState.Text = string.Empty;
        }

        private void cmbShortAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadDevice();
        }
        #endregion

        

        #region 电流校调
        private void btnFixedCurrent_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            decimal current = txtFixedCurrent.DecimalValue;
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartComport.SetFixedCurrent(CurrentDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "设置固定电流成功" : HartComport.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn4_N_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt4_N.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartComport.TrimDACZero(CurrentDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : HartComport.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn4_H_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt4_H.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartComport.TrimDACZero(CurrentDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : HartComport.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn20_N_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt20_N.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartComport.TrimDACGain(CurrentDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : HartComport.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn20_H_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            decimal current = -1;
            if (!decimal.TryParse(txt20_H.Text, out current))
            {
                MessageBox.Show("输入的电流不能是有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (current == 0 || (current >= 4 && current <= 20))
            {
                bool ret = HartComport.TrimDACGain(CurrentDevice.LongAddress, (float)current);
                txtLastError_Current.Text = ret ? "校调成功" : HartComport.GetLastError();
            }
            else
            {
                MessageBox.Show("输入的固定电流不正确", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 压力微调
        private void btnSetPVZero_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetPVZero(CurrentDevice.LongAddress);
            txtMsg_压力微调.Text = ret ? "设置成功" : HartComport.GetLastError();
        }

        private void btnSetLowerRange_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetLowerRangeValue(CurrentDevice.LongAddress);
            txtMsg_压力微调.Text = ret ? "设置成功" : HartComport.GetLastError();
        }

        private void btnSetUpperRange_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            bool ret = HartComport.SetUpperRangeValue(CurrentDevice.LongAddress);
            txtMsg_压力微调.Text = ret ? "设置成功" : HartComport.GetLastError();
        }
        #endregion

        #region 其它
        private void btnReadMsg_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            string msg = HartComport.ReadMessage(CurrentDevice.LongAddress);
            txtMessage.Text = !string.IsNullOrEmpty(msg) ? msg : HartComport.GetLastError();
        }

        private void btnWriteMsg_Click(object sender, EventArgs e)
        {
            if (CurrentDevice == null) return;
            HartComport.WriteMessage(CurrentDevice.LongAddress, txtMessage.Text.Trim());
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

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            AddForm<FrmGeneralInfo>();
        }

        private void pBody_Resize(object sender, EventArgs e)
        {
            RenderForm(_ActiveForm);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
