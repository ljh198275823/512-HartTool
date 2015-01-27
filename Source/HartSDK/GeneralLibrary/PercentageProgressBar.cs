using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LJH.GeneralLibrary.WinformControl
{
    /// <summary>
    /// 表示一个显示百分比的进度条
    /// </summary>
    public partial class PercentageProgressBar : ProgressBar
    {
        #region 构造函数
        /// <summary>
        /// 表示一个显示百分比的进度条
        /// </summary>
        public PercentageProgressBar()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 表示一个显示百分比的进度条
        /// </summary>
        /// <param name="container"></param>
        public PercentageProgressBar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region DLL调用函数
        [DllImport("user32.dll ")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll ")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        #endregion

        #region 私有变量
        private Color _TextColor = System.Drawing.Color.Black;
        private Font _TextFont = new System.Drawing.Font("宋体", 9);
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置百分比颜色
        /// </summary>
        public Color TextColor
        {

            get { return _TextColor; }

            set { _TextColor = value; this.Invalidate(); }

        }
        /// <summary>
        /// 获取或设置百分比字体
        /// </summary>
        public Font TextFont
        {

            get { return _TextFont; }

            set { _TextFont = value; this.Invalidate(); }

        }
        #endregion

        #region 重写方法
        /// <summary>
        /// 处理Windows消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref   Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() == 0) return;
                using (System.Drawing.Graphics g = Graphics.FromHdc(hDC))
                {
                    SolidBrush brush = new SolidBrush(_TextColor);
                    string s = this.Maximum == 0 ? "100%" : string.Format("{0}%", this.Value * 100 / this.Maximum);
                    SizeF size = g.MeasureString(s, _TextFont);
                    float x = (this.Width - size.Width) / 2;
                    float y = (this.Height - size.Height) / 2;
                    g.DrawString(s, _TextFont, brush, x, y);
                    m.Result = IntPtr.Zero;
                    ReleaseDC(m.HWnd, hDC);
                }
            }
        }
        #endregion
    }
}
