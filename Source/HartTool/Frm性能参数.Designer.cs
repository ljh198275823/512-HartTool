namespace HartTool
{
    partial class Frm性能参数
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtWriteDampValue = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbWriteTranserFunction = new System.Windows.Forms.ComboBox();
            this.cmbWriteRangeValueUnit = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.txtWriteRangeValueLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWriteRangeValueUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label32 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWriteDampValue
            // 
            this.txtWriteDampValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteDampValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteDampValue.Location = new System.Drawing.Point(107, 175);
            this.txtWriteDampValue.Name = "txtWriteDampValue";
            this.txtWriteDampValue.Size = new System.Drawing.Size(121, 26);
            this.txtWriteDampValue.TabIndex = 59;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(273, 171);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 58;
            this.button3.Text = "下载";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 35);
            this.button2.TabIndex = 57;
            this.button2.Text = "下载";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(24, 182);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 12);
            this.label35.TabIndex = 56;
            this.label35.Text = "阻尼系数(秒)";
            // 
            // cmbWriteTranserFunction
            // 
            this.cmbWriteTranserFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWriteTranserFunction.FormattingEnabled = true;
            this.cmbWriteTranserFunction.Items.AddRange(new object[] {
            "线性",
            "开方"});
            this.cmbWriteTranserFunction.Location = new System.Drawing.Point(107, 37);
            this.cmbWriteTranserFunction.Name = "cmbWriteTranserFunction";
            this.cmbWriteTranserFunction.Size = new System.Drawing.Size(121, 20);
            this.cmbWriteTranserFunction.TabIndex = 55;
            // 
            // cmbWriteRangeValueUnit
            // 
            this.cmbWriteRangeValueUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWriteRangeValueUnit.FormattingEnabled = true;
            this.cmbWriteRangeValueUnit.Items.AddRange(new object[] {
            "inH2O",
            "inHg",
            "ftH2O",
            "mmH2O",
            "mmHg",
            "psi",
            "bar",
            "mbar",
            "g/cm2",
            "kg/cm2",
            "pa",
            "kpa",
            "torr",
            "atm",
            "mpa",
            "mA",
            "%"});
            this.cmbWriteRangeValueUnit.Location = new System.Drawing.Point(107, 85);
            this.cmbWriteRangeValueUnit.Name = "cmbWriteRangeValueUnit";
            this.cmbWriteRangeValueUnit.Size = new System.Drawing.Size(121, 20);
            this.cmbWriteRangeValueUnit.TabIndex = 54;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(248, 132);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 12);
            this.label33.TabIndex = 53;
            this.label33.Text = "基本量程上限";
            // 
            // txtWriteRangeValueLower
            // 
            this.txtWriteRangeValueLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueLower.Location = new System.Drawing.Point(107, 125);
            this.txtWriteRangeValueLower.Name = "txtWriteRangeValueLower";
            this.txtWriteRangeValueLower.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueLower.TabIndex = 52;
            // 
            // txtWriteRangeValueUpper
            // 
            this.txtWriteRangeValueUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueUpper.Location = new System.Drawing.Point(331, 125);
            this.txtWriteRangeValueUpper.Name = "txtWriteRangeValueUpper";
            this.txtWriteRangeValueUpper.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueUpper.TabIndex = 51;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(24, 132);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 12);
            this.label32.TabIndex = 50;
            this.label32.Text = "基本量程下限";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 49;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(36, 88);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 12);
            this.label31.TabIndex = 48;
            this.label31.Text = "主单位设置";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(48, 41);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 47;
            this.label30.Text = "输出选择";
            // 
            // Frm性能参数
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 342);
            this.Controls.Add(this.txtWriteDampValue);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.cmbWriteTranserFunction);
            this.Controls.Add(this.cmbWriteRangeValueUnit);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtWriteRangeValueLower);
            this.Controls.Add(this.txtWriteRangeValueUpper);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Name = "Frm性能参数";
            this.Text = "Frm性能参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteDampValue;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbWriteTranserFunction;
        private System.Windows.Forms.ComboBox cmbWriteRangeValueUnit;
        private System.Windows.Forms.Label label33;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueUpper;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
    }
}