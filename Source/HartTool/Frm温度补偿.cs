using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading ;
using System.Windows.Forms;
using HartSDK;

namespace HartTool
{
    public partial class Frm温度补偿 : Form,IHartCommunication 
    {
        public Frm温度补偿()
        {
            InitializeComponent();
        }

        #region 私有变量
        private byte[] _Params = new byte[] { 0x48, 0x48, 0x20, 0x04, 0x42, 0x4E };  //读取AD的参数
        private Thread _TrdReadAD = null;
        #endregion

        #region 私有方法
        private void ReadAD_Task()
        {
            try
            {
                while (true)
                {
                    if (HartDevice != null && HartDevice.IsConnected)
                    {
                        byte[] response = HartDevice.ReadCommand(0xAF, _Params);
                        if (response != null && response.Length == 14)
                        {
                            this.Invoke((Action)(() =>
                                {
                                    txtPresureAD.Text = BitConverter.ToSingle(new byte[] { response[13], response[12], response[11], response[10] }, 0).ToString ("F0");
                                    txtTempAD.Text = BitConverter.ToSingle(new byte[] { response[9], response[8], response[7], response[6] }, 0).ToString("F0");
                                }));
                        }
                    }
                }
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartDevice HartDevice { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            if(HartDevice ==null )return ;
            TemperatureCompensation tc = HartDevice.ReadTC(0);
            txtLowTempAD.Text = tc != null ? tc.TemperatureAD.ToString() : null;
            txtLowAD1.Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            txtLowAD2.Text = tc != null ? tc.UpperRangeAD.ToString() : null;

            tc = HartDevice.ReadTC(1);
            txtNormalTempAD.Text = tc != null ? tc.TemperatureAD.ToString() : null;
            txtNormalAD1.Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            txtNormalAD2.Text = tc != null ? tc.UpperRangeAD.ToString() : null;

            tc = HartDevice.ReadTC(2);
            txtHightTempAD.Text = tc != null ? tc.TemperatureAD.ToString() : null;
            txtHightAD1.Text = tc != null ? tc.LowerRangeAD.ToString() : null;
            txtHightAD2.Text = tc != null ? tc.UpperRangeAD.ToString() : null;
        }
        #endregion

        private void Frm温度补偿_Load(object sender, EventArgs e)
        {
            _TrdReadAD = new Thread(new ThreadStart(ReadAD_Task));
            _TrdReadAD.IsBackground = true;
            _TrdReadAD.Start();
        }

        private void Frm温度补偿_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_TrdReadAD != null)
            {
                _TrdReadAD.Abort();
                _TrdReadAD = null;
            }
        }


    }
}
