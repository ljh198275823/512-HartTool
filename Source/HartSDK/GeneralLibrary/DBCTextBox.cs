using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;

namespace LJH.GeneralLibrary.WinformControl
{
    /// <summary>
    /// 表示半角输入框，所有输入的字符串都会转换成半角字符串
    /// </summary>
    public partial class DBCTextBox : TextBox 
    {
        public DBCTextBox()
        {
            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
        }

        public DBCTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
        }

        #region 重写基类方法
        protected override void OnTextChanged(EventArgs e)
        {
            int p = this.SelectionStart;
            this.Text = StringHelper.ToDBC(this.Text);
            this.SelectionStart = p;
            base.OnTextChanged(e);
        }
        #endregion
    }
}
