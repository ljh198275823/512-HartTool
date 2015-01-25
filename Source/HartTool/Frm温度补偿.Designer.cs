namespace HartTool
{
    partial class Frm温度补偿
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPresureAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTempAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtHightAD2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtNormalAD2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLowAD2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtHightAD1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtNormalAD1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLowAD1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtHightTempAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtNormalTempAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLowTempAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "低温";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "高温";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "常温";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "温度AD值";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "压力零点AD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(334, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "压力满度AD";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "采集";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "下载";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(555, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "下载";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(456, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "采集";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(555, 142);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "下载";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(456, 142);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 19;
            this.button6.Text = "采集";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "温度AD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "压力AD";
            // 
            // txtPresureAD
            // 
            this.txtPresureAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPresureAD.Location = new System.Drawing.Point(304, 194);
            this.txtPresureAD.Name = "txtPresureAD";
            this.txtPresureAD.Size = new System.Drawing.Size(100, 21);
            this.txtPresureAD.TabIndex = 23;
            // 
            // txtTempAD
            // 
            this.txtTempAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTempAD.Location = new System.Drawing.Point(134, 194);
            this.txtTempAD.Name = "txtTempAD";
            this.txtTempAD.Size = new System.Drawing.Size(100, 21);
            this.txtTempAD.TabIndex = 22;
            // 
            // txtHightAD2
            // 
            this.txtHightAD2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtHightAD2.Location = new System.Drawing.Point(336, 143);
            this.txtHightAD2.Name = "txtHightAD2";
            this.txtHightAD2.Size = new System.Drawing.Size(100, 21);
            this.txtHightAD2.TabIndex = 16;
            // 
            // txtNormalAD2
            // 
            this.txtNormalAD2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNormalAD2.Location = new System.Drawing.Point(336, 100);
            this.txtNormalAD2.Name = "txtNormalAD2";
            this.txtNormalAD2.Size = new System.Drawing.Size(100, 21);
            this.txtNormalAD2.TabIndex = 15;
            // 
            // txtLowAD2
            // 
            this.txtLowAD2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLowAD2.Location = new System.Drawing.Point(336, 59);
            this.txtLowAD2.Name = "txtLowAD2";
            this.txtLowAD2.Size = new System.Drawing.Size(100, 21);
            this.txtLowAD2.TabIndex = 14;
            // 
            // txtHightAD1
            // 
            this.txtHightAD1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtHightAD1.Location = new System.Drawing.Point(210, 143);
            this.txtHightAD1.Name = "txtHightAD1";
            this.txtHightAD1.Size = new System.Drawing.Size(100, 21);
            this.txtHightAD1.TabIndex = 13;
            // 
            // txtNormalAD1
            // 
            this.txtNormalAD1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNormalAD1.Location = new System.Drawing.Point(210, 100);
            this.txtNormalAD1.Name = "txtNormalAD1";
            this.txtNormalAD1.Size = new System.Drawing.Size(100, 21);
            this.txtNormalAD1.TabIndex = 12;
            // 
            // txtLowAD1
            // 
            this.txtLowAD1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLowAD1.Location = new System.Drawing.Point(210, 59);
            this.txtLowAD1.Name = "txtLowAD1";
            this.txtLowAD1.Size = new System.Drawing.Size(100, 21);
            this.txtLowAD1.TabIndex = 11;
            // 
            // txtHightTempAD
            // 
            this.txtHightTempAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtHightTempAD.Location = new System.Drawing.Point(74, 143);
            this.txtHightTempAD.Name = "txtHightTempAD";
            this.txtHightTempAD.Size = new System.Drawing.Size(100, 21);
            this.txtHightTempAD.TabIndex = 10;
            // 
            // txtNormalTempAD
            // 
            this.txtNormalTempAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtNormalTempAD.Location = new System.Drawing.Point(74, 100);
            this.txtNormalTempAD.Name = "txtNormalTempAD";
            this.txtNormalTempAD.Size = new System.Drawing.Size(100, 21);
            this.txtNormalTempAD.TabIndex = 9;
            // 
            // txtLowTempAD
            // 
            this.txtLowTempAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLowTempAD.Location = new System.Drawing.Point(74, 59);
            this.txtLowTempAD.Name = "txtLowTempAD";
            this.txtLowTempAD.Size = new System.Drawing.Size(100, 21);
            this.txtLowTempAD.TabIndex = 8;
            // 
            // Frm温度补偿
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 331);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPresureAD);
            this.Controls.Add(this.txtTempAD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txtHightAD2);
            this.Controls.Add(this.txtNormalAD2);
            this.Controls.Add(this.txtLowAD2);
            this.Controls.Add(this.txtHightAD1);
            this.Controls.Add(this.txtNormalAD1);
            this.Controls.Add(this.txtLowAD1);
            this.Controls.Add(this.txtHightTempAD);
            this.Controls.Add(this.txtNormalTempAD);
            this.Controls.Add(this.txtLowTempAD);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Frm温度补偿";
            this.Text = "Frm温度补偿";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm温度补偿_FormClosed);
            this.Load += new System.EventHandler(this.Frm温度补偿_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLowTempAD;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtNormalTempAD;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtHightTempAD;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtHightAD1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtNormalAD1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLowAD1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtHightAD2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtNormalAD2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLowAD2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPresureAD;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTempAD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}