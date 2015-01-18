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
        private Thread _ReadPV = null;
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
        }
        #endregion

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            if (_ReadPV != null)
            {
                _ReadPV.Abort();
                _ReadPV = null;
                btnRealTime.Text = "实时采集";
            }
            else
            {
                if (CurrentDevice != null)
                {
                    _ReadPV = new Thread(new ThreadStart(ReadPV_Thread));
                    _ReadPV.IsBackground = true;
                    _ReadPV.Start();
                    btnRealTime.Text = "停止采集";
                }
            }
        }

        private void ReadPV_Thread()
        {
            try
            {
                while (true)
                {
                    if (CurrentDevice == null)
                    {
                        this.Invoke((Action)(() => { btnRealTime.Text = "实时采集"; }));
                        _ReadPV = null;
                        return;
                    }
                    DeviceVariable pv = HartComport.ReadPV(CurrentDevice.LongAddress);
                    Action a = delegate()
                    {
                        txtPV.Text = pv != null ? pv.Value.ToString() : string.Empty;
                        CurrentInfo ci = HartComport.ReadCurrent(CurrentDevice.LongAddress);
                        txtCurrent.Text = ci != null ? ci.Current.ToString() : string.Empty;
                        txtPercentOfRange.Text = ci != null ? ci.PercentOfRange.ToString() : string.Empty;
                    };
                    this.Invoke(a);
                    Thread.Sleep(200);
                }
            }
            catch (ThreadAbortException ex)
            {
            }
            catch (Exception ex)
            {

            }
        }

        private void Frm过程量监控_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_ReadPV != null)
            {
                _ReadPV.Abort();
                _ReadPV = null;
            }
        }
    }
}
