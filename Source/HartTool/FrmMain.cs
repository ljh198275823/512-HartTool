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
        private HartSDK.HartDevice HartDevice = null;
        private Form _ActiveForm = null;
        #endregion

        #region 私有方法
        private void RenderForm(Form frm)
        {
            if (frm == null) return;
            frm.Size = new Size(this.pBody.Size.Width, this.pBody.Height);
            SetParent(frm.Handle, this.pBody.Handle);
            frm.Show();
        }

        private void ShowForm<T>() where T : Form
        {
            if (_ActiveForm != null && !(_ActiveForm is T))
            {
                _ActiveForm.Close();
                _ActiveForm = null;
            }
            if (_ActiveForm == null)
            {
                T instance = Activator.CreateInstance(typeof(T)) as T;
                instance.TopLevel = false;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.ShowInTaskbar = false;
                instance.StartPosition = FormStartPosition.Manual;
                _ActiveForm = instance;
                IHartCommunication iHart = _ActiveForm as IHartCommunication;
                if (iHart != null)
                {
                    iHart.HartDevice = HartDevice;
                    iHart.ReadData();
                }
                RenderForm(_ActiveForm);
            }
        }

        private void HightLightButton(Button btn)
        {
            foreach (Control ctrl in pCommand.Controls)
            {
                if (ctrl is Button && !object.ReferenceEquals(ctrl, btn))
                {
                    ctrl.BackColor = SystemColors.Control;
                    ctrl.ForeColor = Color.Black;
                }
            }
            btn.BackColor = Color.Blue;
            btn.ForeColor = Color.White;
        }

        private void OpenDevice()
        {
            HartSDK.UniqueIdentifier did = null;
            if (HartDevice != null && HartDevice.IsConnected) did = HartDevice.ReadUniqueID();
            txtDeviceID.IntergerValue = did != null ? did.DeviceID : 0;
            btnWritePollingAddress.Enabled = HartDevice != null && HartDevice.IsConnected;
            btnWritePollingAddress.Enabled = HartDevice != null && HartDevice.IsConnected;
            foreach (Control ctrl in pCommand.Controls)
            {
                if (ctrl is Button) ctrl.Enabled = HartDevice != null && HartDevice.IsConnected;
            }
            if (_ActiveForm != null)
            {
                IHartCommunication iHart = _ActiveForm as IHartCommunication;
                iHart.HartDevice = HartDevice;
                iHart.ReadData();
            }
        }
        #endregion

        #region 事件处理
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" [{0}]", Application.ProductVersion);
            comPortComboBox1.Init();
            cmbShortAddress.SelectedIndex = 0;

            float f = BitConverter.ToSingle(new byte[] {0x00,0x00,0xA0,0x41 }, 0);
            float f1 = BitConverter.ToSingle(new byte[] { 0x00, 0xbd, 0x27, 0x47 }, 0);
            Console.WriteLine(f);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (HartDevice != null) HartDevice.Close();
            if (comPortComboBox1.ComPort > 0)
            {
                HartDevice = new HartSDK.HartDevice(comPortComboBox1.ComPort, 1200);
                HartDevice.PollingAddress = (byte)cmbShortAddress.SelectedIndex;
                HartDevice.Connect();
                lblCommportState.Text = string.Format(HartDevice.IsConnected ? "设备已经连接" : "设备连接失败");
                lblCommportState.ForeColor = HartDevice.IsConnected ? Color.Blue : Color.Red;
                statusStrip1.Refresh();
                btnOpen.Enabled = !HartDevice.IsConnected;
                btnClose.Enabled = HartDevice.IsConnected;
                OpenDevice();
            }
            else
            {
                MessageBox.Show("请先设置通讯串口");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (HartDevice != null) HartDevice.Close();
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            lblCommportState.Text = string.Empty;
        }

        private void btnWritePollingAddress_Click(object sender, EventArgs e)
        {
            if (HartDevice  == null || !HartDevice .IsConnected ) return;
            if (txtPollingAddress.IntergerValue >= 0 && txtPollingAddress.IntergerValue <= 15)
            {
                bool ret = HartDevice.WritePollingAddress((byte)txtPollingAddress.IntergerValue);
                if (ret)
                {
                    cmbShortAddress.SelectedIndex = HartDevice.PollingAddress;
                }
                else
                {
                    MessageBox.Show(HartDevice.GetLastError(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("短帧地址只能设置在0-15之间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pBody_Resize(object sender, EventArgs e)
        {
            RenderForm(_ActiveForm);
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            ShowForm<Frm基本信息>();
            HightLightButton(btnGeneral);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn电流校准_Click(object sender, EventArgs e)
        {
            ShowForm<Frm电流校准>();
            HightLightButton(btn电流校准);
        }

        private void btn压力微调_Click(object sender, EventArgs e)
        {
            ShowForm<Frm压力微调>();
            HightLightButton(btn压力微调);
        }

        private void btn性能参数_Click(object sender, EventArgs e)
        {
            ShowForm<Frm性能参数>();
            HightLightButton(btn性能参数);
        }

        private void btn过程量监控_Click(object sender, EventArgs e)
        {
            ShowForm<Frm过程量监控>();
            HightLightButton(btn过程量监控);
        }

        private void btn仪表信息_Click(object sender, EventArgs e)
        {
            ShowForm<Frm仪表信息>();
            HightLightButton(btn仪表信息);
        }

        private void btn量程设置_Click(object sender, EventArgs e)
        {
            ShowForm<Frm量程设置>();
            HightLightButton(btn量程设置);
        }

        private void btn温度补偿_Click(object sender, EventArgs e)
        {
            ShowForm<Frm温度补偿>();
            HightLightButton(btn温度补偿);
        }

        private void btn多点线性化_Click(object sender, EventArgs e)
        {
            ShowForm<Frm多点线性化>();
            HightLightButton(btn多点线性化);
        }
        #endregion
    }
}
