using System;
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
    public partial class Frm过程量监控 : Form,IHartCommunication 
    {
        public Frm过程量监控()
        {
            InitializeComponent();
        }

        #region 私有变量
        private bool _Running = false;
        private Thread _ReadPV = null;
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public void ReadData()
        {
        }
        #endregion

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            if (_ReadPV != null)
            {
                _Running = false;
                btnRealTime.Text = "实时采集";
            }
            else
            {
                if (HartDevice != null && HartDevice.IsConnected)
                {
                    _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                    _ReadPV.IsBackground = true;
                    _Running = true;
                    _ReadPV.Start();
                    btnRealTime.Text = "停止采集";
                }
            }
        }

        private void ReadPV_Thread()
        {
            try
            {
                while (_Running )
                {
                    if (HartDevice == null || !HartDevice.IsConnected)
                    {
                        this.Invoke((Action)(() => { btnRealTime.Text = "实时采集"; }));
                        _ReadPV = null;
                        return;
                    }
                    DeviceVariable pv = HartDevice.ReadPV(false);
                    CurrentInfo ci = HartDevice.ReadCurrent(false);
                    Action a = delegate()
                    {
                        if (pv != null)
                        {
                            lblPVUnit.Text = pv != null ? UnitCodeDescr.GetDescr(pv.UnitCode) : null;
                            txtPV.Text = pv != null ? pv.Value.ToString() : string.Empty;
                        }
                        if (ci != null)
                        {
                            txtCurrent.Text = ci != null ? ci.Current.ToString() : string.Empty;
                            txtPercentOfRange.Text = ci != null ? ci.PercentOfRange.ToString() : string.Empty;
                        }
                    };
                    this.Invoke(a);
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {

            }
            finally
            {
                _ReadPV = null;
            }
        }

        private void Frm过程量监控_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_ReadPV != null) _Running = false;
        }
    }
}
