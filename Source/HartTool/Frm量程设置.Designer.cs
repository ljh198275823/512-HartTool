namespace HartTool
{
    partial class Frm量程设置
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dbcTextBox1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dbcTextBox2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWriteRangeValueLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWriteRangeValueUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "DP",
            "AP",
            "GP",
            "LT"});
            this.comboBox1.Location = new System.Drawing.Point(108, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工作模式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "传感器代码";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.comboBox2.Location = new System.Drawing.Point(379, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 24);
            this.comboBox2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(549, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(296, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "使用量程下限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "使用量程上限";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(296, 87);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 12);
            this.label33.TabIndex = 80;
            this.label33.Text = "基本量程下限";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(25, 87);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 12);
            this.label32.TabIndex = 77;
            this.label32.Text = "基本量程上限";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(549, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 29);
            this.button2.TabIndex = 76;
            this.button2.Text = "下载";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(549, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 29);
            this.button3.TabIndex = 85;
            this.button3.Text = "下载";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // dbcTextBox1
            // 
            this.dbcTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox1.Location = new System.Drawing.Point(108, 128);
            this.dbcTextBox1.Name = "dbcTextBox1";
            this.dbcTextBox1.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox1.TabIndex = 83;
            // 
            // dbcTextBox2
            // 
            this.dbcTextBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox2.Location = new System.Drawing.Point(379, 128);
            this.dbcTextBox2.Name = "dbcTextBox2";
            this.dbcTextBox2.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox2.TabIndex = 82;
            // 
            // txtWriteRangeValueLower
            // 
            this.txtWriteRangeValueLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueLower.Location = new System.Drawing.Point(108, 80);
            this.txtWriteRangeValueLower.Name = "txtWriteRangeValueLower";
            this.txtWriteRangeValueLower.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueLower.TabIndex = 79;
            // 
            // txtWriteRangeValueUpper
            // 
            this.txtWriteRangeValueUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueUpper.Location = new System.Drawing.Point(379, 80);
            this.txtWriteRangeValueUpper.Name = "txtWriteRangeValueUpper";
            this.txtWriteRangeValueUpper.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueUpper.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 86;
            this.label5.Text = "单位";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 87;
            this.label6.Text = "单位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(506, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "单位";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(506, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 89;
            this.label8.Text = "单位";
            // 
            // Frm量程设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 385);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dbcTextBox1);
            this.Controls.Add(this.dbcTextBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtWriteRangeValueLower);
            this.Controls.Add(this.txtWriteRangeValueUpper);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Frm量程设置";
            this.Text = "Frm量程设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label33;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueUpper;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;

    }
}