using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LJH.GeneralLibrary.WinformControl
{
    public partial class ComPortComboBox : ComboBox
    {
        public ComPortComboBox()
        {
            InitializeComponent();
        }

        public ComPortComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public void Init()
        {
            this.Items.Clear();
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Items.Add(string.Empty);
            for (int i = 1; i < 21; i++)
            {
                this.Items.Add("COM" + i.ToString());
            }
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public byte ComPort
        {
            get
            {
                byte value = 0;
                if (!string.IsNullOrEmpty(this.Text))
                {
                    string comVal = this.Text.Substring(3);
                    byte.TryParse(comVal, out value);
                }
                return value;
            }
            set
            {
                foreach (object o in this.Items)
                {
                    if (o.ToString() == "COM" + value)
                    {
                        this.SelectedItem = o;
                    }
                }
            }
        }
    }
}
