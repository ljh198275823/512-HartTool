namespace HartTool
{
    partial class Frm压力标定
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
            this.btnSetUpperRange = new System.Windows.Forms.Button();
            this.btnSetLowerRange = new System.Windows.Forms.Button();
            this.btnSetPVZero = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.dbcTextBox1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dbcTextBox2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetUpperRange
            // 
            this.btnSetUpperRange.Location = new System.Drawing.Point(313, 112);
            this.btnSetUpperRange.Name = "btnSetUpperRange";
            this.btnSetUpperRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetUpperRange.TabIndex = 32;
            this.btnSetUpperRange.Text = "下载";
            this.btnSetUpperRange.UseVisualStyleBackColor = true;
            // 
            // btnSetLowerRange
            // 
            this.btnSetLowerRange.Location = new System.Drawing.Point(313, 156);
            this.btnSetLowerRange.Name = "btnSetLowerRange";
            this.btnSetLowerRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetLowerRange.TabIndex = 31;
            this.btnSetLowerRange.Text = "下载";
            this.btnSetLowerRange.UseVisualStyleBackColor = true;
            // 
            // btnSetPVZero
            // 
            this.btnSetPVZero.Location = new System.Drawing.Point(59, 34);
            this.btnSetPVZero.Name = "btnSetPVZero";
            this.btnSetPVZero.Size = new System.Drawing.Size(116, 35);
            this.btnSetPVZero.TabIndex = 30;
            this.btnSetPVZero.Text = "零点微调";
            this.btnSetPVZero.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(59, 165);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 33;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "高点微调";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(59, 121);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(71, 16);
            this.radioButton2.TabIndex = 34;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "低点微调";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // dbcTextBox1
            // 
            this.dbcTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox1.Location = new System.Drawing.Point(136, 116);
            this.dbcTextBox1.Name = "dbcTextBox1";
            this.dbcTextBox1.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox1.TabIndex = 62;
            // 
            // dbcTextBox2
            // 
            this.dbcTextBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox2.Location = new System.Drawing.Point(136, 160);
            this.dbcTextBox2.Name = "dbcTextBox2";
            this.dbcTextBox2.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox2.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "KPa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "KPa";
            // 
            // Frm压力标定
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 343);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbcTextBox2);
            this.Controls.Add(this.dbcTextBox1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.btnSetUpperRange);
            this.Controls.Add(this.btnSetLowerRange);
            this.Controls.Add(this.btnSetPVZero);
            this.Name = "Frm压力标定";
            this.Text = "压力标定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetUpperRange;
        private System.Windows.Forms.Button btnSetLowerRange;
        private System.Windows.Forms.Button btnSetPVZero;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}