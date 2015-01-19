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
                    iHart.HartComport = HartComport;
                    iHart.CurrentDevice = CurrentDevice;
                    iHart.ReadData();
                }
                RenderForm(_ActiveForm);
            }
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
                CurrentDevice = HartComport.ReadUniqueID(_PollingAddress);
                if (_ActiveForm != null)
                {
                    IHartCommunication iHart = _ActiveForm as IHartCommunication;
                    iHart.HartComport = HartComport;
                    iHart.CurrentDevice = CurrentDevice;
                    iHart.ReadData();
                }
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
            if (HartComport != null && HartComport.IsOpened)
            {
                CurrentDevice = HartComport.ReadUniqueID(_PollingAddress);
                if (_ActiveForm != null)
                {
                    IHartCommunication iHart = _ActiveForm as IHartCommunication;
                    iHart.HartComport = HartComport;
                    iHart.CurrentDevice = CurrentDevice;
                    iHart.ReadData();
                }
            }
        }

        private void pBody_Resize(object sender, EventArgs e)
        {
            RenderForm(_ActiveForm);
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            ShowForm<Frm基本信息>();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
       
        private void btn电流校准_Click(object sender, EventArgs e)
        {
            ShowForm<Frm电流校准>();
        }

        private void btn压力微调_Click(object sender, EventArgs e)
        {
            ShowForm<Frm压力标定>();
        }

        private void btn性能参数_Click(object sender, EventArgs e)
        {
            ShowForm<Frm性能参数>();
        }

        private void btn过程量监控_Click(object sender, EventArgs e)
        {
            ShowForm<Frm过程量监控>();
        }

        private void btn仪表信息_Click(object sender, EventArgs e)
        {
            ShowForm<Frm仪表信息>();
        }

        private void btn量程设置_Click(object sender, EventArgs e)
        {
            ShowForm<Frm量程设置>();
        }

        private void btn温度补偿_Click(object sender, EventArgs e)
        {
            ShowForm<Frm温度补偿>();
        }

        private void btn多点线性化_Click(object sender, EventArgs e)
        {
            ShowForm<Frm多点线性化>();
        }
        #endregion
    }
}
