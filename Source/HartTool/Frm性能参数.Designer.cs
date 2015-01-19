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
            this.txtDampValue = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.btnWrite = new System.Windows.Forms.Button();
            this.label35 = new System.Windows.Forms.Label();
            this.cmbTranserFunction = new System.Windows.Forms.ComboBox();
            this.cmbPVUnit = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dbcTextBox1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.btnWrite.Location = new System.Drawing.Point(273, 124);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(101, 35);
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
            this.cmbPVUnit.Location = new System.Drawing.Point(107, 85);
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
            this.label1.Location = new System.Drawing.Point(36, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 60;
            this.label1.Text = "小信号切除";
            // 
            // dbcTextBox1
            // 
            this.dbcTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox1.Location = new System.Drawing.Point(107, 181);
            this.dbcTextBox1.Name = "dbcTextBox1";
            this.dbcTextBox1.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox1.TabIndex = 61;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 62;
            this.label2.Text = "%";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 35);
            this.button1.TabIndex = 63;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Frm性能参数
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 342);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dbcTextBox1);
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
            this.Load += new System.EventHandler(this.Frm性能参数_Load);
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
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}