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
    public partial class Frm其它 : Form,IHartCommunication 
    {
        public Frm其它()
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
    }
}
