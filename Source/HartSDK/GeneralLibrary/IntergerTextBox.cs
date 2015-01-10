using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LJH.GeneralLibrary.WinformControl
{
    public partial class IntergerTextBox :TextBox 
    {
        #region 构造函数
        public IntergerTextBox()
        {
            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
            Init();
        }

        public IntergerTextBox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.ImeMode = ImeMode.OnHalf;
            Init();
        }
        #endregion

        #region 私有方法
        private string _PreText; //用于保存输入框内容改变之前的输入框中的内容

        private void Init()
        {
            this.Text = "0";
            this._PreText = "0";
            this.MinValue = int.MinValue;
            this.MaxValue = int.MaxValue;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置可以输入的最小值
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// 获取或设置可以输入的最大值
        /// </summary>
        public int MaxValue { get; set; }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int IntergerValue
        {
            get
            {
                string txt;
                int val;
                txt = this.Text.Trim();
                if (txt.Length > 0 && int.TryParse(txt, out val))
                {
                    return val;
                }
                return 0;
            }
            set
            {
                this.Text = value.ToString();
            }
        }
        #endregion

        #region 重写基类方法
        protected override void OnTextChanged(EventArgs e)
        {
            string text = StringHelper.ToDBC(this.Text);
            int position = this.SelectionStart;
            if (!string.IsNullOrEmpty(text.Trim()))
            {
                if (text.Trim() == "-")
                {
                    if (this.MinValue >= 0)
                    {
                        this.Text = _PreText;
                        this.SelectionStart = this.Text.Length;
                        return;
                    }
                }
                else
                {
                    int value;
                    if (!int.TryParse(text, out value))
                    {
                        this.Text = _PreText;
                        this.SelectionStart = this.Text.Length;
                        return;
                    }
                    else
                    {
                        if (value > MaxValue || value < MinValue)
                        {
                            this.Text = _PreText;
                            this.SelectionStart = this.Text.Length;
                            return;
                        }
                    }
                }
            }
            this.Text = text;
            _PreText = this.Text;
            this.SelectionStart = position;
            base.OnTextChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            if (this.Text.Trim().Length > 0)
            {
                this.SelectionStart = 0;
                this.SelectionLength = this.Text.Length;
            }
            base.OnEnter(e);
        }
        #endregion
    }
}
