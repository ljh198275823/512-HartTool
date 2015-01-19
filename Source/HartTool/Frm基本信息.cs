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
    public partial class Frm基本信息 : Form, IHartCommunication
    {
        #region 构造函数
        public Frm基本信息()
        {
            InitializeComponent();
        }
        #endregion

        #region 实现接口 IHartCommunication
        public HartSDK.HartComport HartComport { get; set; }

        public HartSDK.UniqueIdentifier CurrentDevice { get; set; }

        public void ReadData()
        {
            if (CurrentDevice != null)
            {
                OutputInfo oi = HartComport.ReadOutput(CurrentDevice.LongAddress);
                txtOutputLower.Text = oi != null ? oi.LowerRangeValue.ToString() : null;
                txtOutputUpper.Text = oi != null ? oi.UpperRangeValue.ToString() : null;
                lblPVU1.Text = oi != null ? ((UnitCode)oi.PVUnitCode).ToString() : null;
                lblPVU2.Text = oi != null ? ((UnitCode)oi.PVUnitCode).ToString() : null;
                SensorInfo si = HartComport.ReadPVSensor(CurrentDevice.LongAddress);
                txtSensorLower.Text = si != null ? si.LowerLimit.ToString() : null;
                txtSenserUpper.Text = si != null ? si.UpperLimit.ToString() : null;
                lblSU1.Text = si != null ? ((UnitCode)si.UnitCode).ToString() : null;
                lblSU2.Text = si != null ? ((UnitCode)si.UnitCode).ToString() : null;
                txtTrim4.Text = HartComport.ReadCurrentTrim(CurrentDevice.LongAddress, 0).ToString();
                //txtTrim20.Text = HartComport.ReadCurrentTrim(CurrentDevice.LongAddress, 1).ToString();
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmGeneralInfo_Load(object sender, EventArgs e)
        {
            ReadData();
        }
        #endregion
    }
}
