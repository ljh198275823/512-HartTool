namespace HartTool
{
    partial class Frm特性输出
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
            this.txtDampValue = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.btnWrite = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbTranserFunction = new System.Windows.Forms.ComboBox();
            this.cmbPVUnit = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTrim4 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDampValue
            // 
            this.txtDampValue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDampValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDampValue.Location = new System.Drawing.Point(107, 128);
            this.txtDampValue.Name = "txtDampValue";
            this.txtDampValue.Size = new System.Drawing.Size(121, 26);
            this.txtDampValue.TabIndex = 59;
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(273, 128);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(101, 26);
            this.btnWrite.TabIndex = 58;
            this.btnWrite.Text = "下载";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(24, 135);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(77, 12);
            this.label35.TabIndex = 56;
            this.label35.Text = "阻尼系数(秒)";
            // 
            // cmbTranserFunction
            // 
            this.cmbTranserFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranserFunction.FormattingEnabled = true;
            this.cmbTranserFunction.Items.AddRange(new object[] {
            "线性",
            "开方"});
            this.cmbTranserFunction.Location = new System.Drawing.Point(107, 37);
            this.cmbTranserFunction.Name = "cmbTranserFunction";
            this.cmbTranserFunction.Size = new System.Drawing.Size(121, 20);
            this.cmbTranserFunction.TabIndex = 55;
            // 
            // cmbPVUnit
            // 
            this.cmbPVUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPVUnit.FormattingEnabled = true;
            this.cmbPVUnit.Items.AddRange(new object[] {
            "",
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
            this.cmbPVUnit.Location = new System.Drawing.Point(107, 84);
            this.cmbPVUnit.Name = "cmbPVUnit";
            this.cmbPVUnit.Size = new System.Drawing.Size(121, 20);
            this.cmbPVUnit.TabIndex = 54;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(36, 88);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(65, 12);
            this.label31.TabIndex = 48;
            this.label31.Text = "主显示单位";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "小信号切除";
            // 
            // txtTrim4
            // 
            this.txtTrim4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTrim4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTrim4.Location = new System.Drawing.Point(107, 174);
            this.txtTrim4.Name = "txtTrim4";
            this.txtTrim4.Size = new System.Drawing.Size(121, 26);
            this.txtTrim4.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "%";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 26);
            this.button1.TabIndex = 63;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(273, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 26);
            this.button2.TabIndex = 64;
            this.button2.Text = "下载";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(273, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(101, 26);
            this.button3.TabIndex = 65;
            this.button3.Text = "下载";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Frm性能参数
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 342);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTrim4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDampValue);
            this.Controls.Add(this.btnWrite);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.cmbTranserFunction);
            this.Controls.Add(this.cmbPVUnit);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label30);
            this.Name = "Frm性能参数";
            this.Text = "Frm性能参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtDampValue;
        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cmbTranserFunction;
        private System.Windows.Forms.ComboBox cmbPVUnit;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTrim4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}