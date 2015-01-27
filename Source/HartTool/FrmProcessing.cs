using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HartTool
{
    public partial class FrmProcessing : Form
    {
        public FrmProcessing()
        {
            InitializeComponent();
        }

        private DateTime _dt = DateTime.Now;

        public void ShowProgress(string message, decimal completeRation)
        {
            try
            {
                Action action = delegate()
                {
                    this.label1.Text = message;
                    this.progressBar1.Value = (int)(completeRation * 100);
                    if (completeRation == 1)
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                };
                if (this.InvokeRequired)
                {
                    this.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch
            {
            }
        }

        private void FrmProcessing_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 1000;
            this.timer1.Enabled = true;
            _dt = DateTime.Now;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(DateTime.Now.Ticks - _dt.Ticks);
            this.Text = string.Format("用时 {0}分{1}秒", (int)(ts.TotalSeconds / 60), (int)(ts.TotalSeconds % 60));
        }

        private void FrmProcessing_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Enabled = false;
        }
    }
}
