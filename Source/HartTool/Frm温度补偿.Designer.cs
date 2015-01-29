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
            this.btnCollect0 = new System.Windows.Forms.Button();
            this.btnWrite0 = new System.Windows.Forms.Button();
            this.btnWrite1 = new System.Windows.Forms.Button();
            this.btnCollect1 = new System.Windows.Forms.Button();
            this.btnWrite2 = new System.Windows.Forms.Button();
            this.btnCollect2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPresureAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTempAD = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtUpper2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtUpper1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtUpper0 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLow2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLow1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLow0 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTempAD2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTempAD1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTempAD0 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.btnRead2 = new System.Windows.Forms.Button();
            this.btnRead1 = new System.Windows.Forms.Button();
            this.btnRead0 = new System.Windows.Forms.Button();
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
            this.label5.Location = new System.Drawing.Point(183, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "压力零点AD";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "压力满度AD";
            // 
            // btnCollect0
            // 
            this.btnCollect0.Enabled = false;
            this.btnCollect0.Location = new System.Drawing.Point(405, 58);
            this.btnCollect0.Name = "btnCollect0";
            this.btnCollect0.Size = new System.Drawing.Size(75, 23);
            this.btnCollect0.TabIndex = 6;
            this.btnCollect0.Tag = "0";
            this.btnCollect0.Text = "采集";
            this.btnCollect0.UseVisualStyleBackColor = true;
            this.btnCollect0.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // btnWrite0
            // 
            this.btnWrite0.Location = new System.Drawing.Point(566, 58);
            this.btnWrite0.Name = "btnWrite0";
            this.btnWrite0.Size = new System.Drawing.Size(75, 23);
            this.btnWrite0.TabIndex = 7;
            this.btnWrite0.Tag = "0";
            this.btnWrite0.Text = "下载";
            this.btnWrite0.UseVisualStyleBackColor = true;
            this.btnWrite0.Click += new System.EventHandler(this.btuWrite_Click);
            // 
            // btnWrite1
            // 
            this.btnWrite1.Location = new System.Drawing.Point(566, 99);
            this.btnWrite1.Name = "btnWrite1";
            this.btnWrite1.Size = new System.Drawing.Size(75, 23);
            this.btnWrite1.TabIndex = 18;
            this.btnWrite1.Tag = "1";
            this.btnWrite1.Text = "下载";
            this.btnWrite1.UseVisualStyleBackColor = true;
            this.btnWrite1.Click += new System.EventHandler(this.btuWrite_Click);
            // 
            // btnCollect1
            // 
            this.btnCollect1.Enabled = false;
            this.btnCollect1.Location = new System.Drawing.Point(405, 99);
            this.btnCollect1.Name = "btnCollect1";
            this.btnCollect1.Size = new System.Drawing.Size(75, 23);
            this.btnCollect1.TabIndex = 17;
            this.btnCollect1.Tag = "1";
            this.btnCollect1.Text = "采集";
            this.btnCollect1.UseVisualStyleBackColor = true;
            this.btnCollect1.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // btnWrite2
            // 
            this.btnWrite2.Location = new System.Drawing.Point(566, 142);
            this.btnWrite2.Name = "btnWrite2";
            this.btnWrite2.Size = new System.Drawing.Size(75, 23);
            this.btnWrite2.TabIndex = 20;
            this.btnWrite2.Tag = "2";
            this.btnWrite2.Text = "下载";
            this.btnWrite2.UseVisualStyleBackColor = true;
            this.btnWrite2.Click += new System.EventHandler(this.btuWrite_Click);
            // 
            // btnCollect2
            // 
            this.btnCollect2.Enabled = false;
            this.btnCollect2.Location = new System.Drawing.Point(405, 142);
            this.btnCollect2.Name = "btnCollect2";
            this.btnCollect2.Size = new System.Drawing.Size(75, 23);
            this.btnCollect2.TabIndex = 19;
            this.btnCollect2.Tag = "2";
            this.btnCollect2.Text = "采集";
            this.btnCollect2.UseVisualStyleBackColor = true;
            this.btnCollect2.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(84, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 21;
            this.label7.Text = "温度AD";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 24;
            this.label8.Text = "压力AD";
            // 
            // txtPresureAD
            // 
            this.txtPresureAD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPresureAD.ForeColor = System.Drawing.Color.Red;
            this.txtPresureAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPresureAD.Location = new System.Drawing.Point(304, 194);
            this.txtPresureAD.Name = "txtPresureAD";
            this.txtPresureAD.Size = new System.Drawing.Size(100, 26);
            this.txtPresureAD.TabIndex = 23;
            // 
            // txtTempAD
            // 
            this.txtTempAD.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTempAD.ForeColor = System.Drawing.Color.Red;
            this.txtTempAD.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTempAD.Location = new System.Drawing.Point(134, 194);
            this.txtTempAD.Name = "txtTempAD";
            this.txtTempAD.Size = new System.Drawing.Size(100, 26);
            this.txtTempAD.TabIndex = 22;
            // 
            // txtUpper2
            // 
            this.txtUpper2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpper2.Location = new System.Drawing.Point(298, 143);
            this.txtUpper2.Name = "txtUpper2";
            this.txtUpper2.Size = new System.Drawing.Size(100, 21);
            this.txtUpper2.TabIndex = 16;
            this.txtUpper2.Enter += new System.EventHandler(this.txtHightTempAD_Enter);
            // 
            // txtUpper1
            // 
            this.txtUpper1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpper1.Location = new System.Drawing.Point(298, 100);
            this.txtUpper1.Name = "txtUpper1";
            this.txtUpper1.Size = new System.Drawing.Size(100, 21);
            this.txtUpper1.TabIndex = 15;
            this.txtUpper1.Enter += new System.EventHandler(this.txtNormalTempAD_Enter);
            // 
            // txtUpper0
            // 
            this.txtUpper0.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpper0.Location = new System.Drawing.Point(298, 59);
            this.txtUpper0.Name = "txtUpper0";
            this.txtUpper0.Size = new System.Drawing.Size(100, 21);
            this.txtUpper0.TabIndex = 14;
            this.txtUpper0.Enter += new System.EventHandler(this.txtLowTempAD_Enter);
            // 
            // txtLow2
            // 
            this.txtLow2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLow2.Location = new System.Drawing.Point(185, 143);
            this.txtLow2.Name = "txtLow2";
            this.txtLow2.Size = new System.Drawing.Size(100, 21);
            this.txtLow2.TabIndex = 13;
            this.txtLow2.Enter += new System.EventHandler(this.txtHightTempAD_Enter);
            // 
            // txtLow1
            // 
            this.txtLow1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLow1.Location = new System.Drawing.Point(185, 100);
            this.txtLow1.Name = "txtLow1";
            this.txtLow1.Size = new System.Drawing.Size(100, 21);
            this.txtLow1.TabIndex = 12;
            this.txtLow1.Enter += new System.EventHandler(this.txtNormalTempAD_Enter);
            // 
            // txtLow0
            // 
            this.txtLow0.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLow0.Location = new System.Drawing.Point(185, 59);
            this.txtLow0.Name = "txtLow0";
            this.txtLow0.Size = new System.Drawing.Size(100, 21);
            this.txtLow0.TabIndex = 11;
            this.txtLow0.Enter += new System.EventHandler(this.txtLowTempAD_Enter);
            // 
            // txtTempAD2
            // 
            this.txtTempAD2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTempAD2.Location = new System.Drawing.Point(74, 143);
            this.txtTempAD2.Name = "txtTempAD2";
            this.txtTempAD2.Size = new System.Drawing.Size(100, 21);
            this.txtTempAD2.TabIndex = 10;
            this.txtTempAD2.Enter += new System.EventHandler(this.txtHightTempAD_Enter);
            // 
            // txtTempAD1
            // 
            this.txtTempAD1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTempAD1.Location = new System.Drawing.Point(74, 100);
            this.txtTempAD1.Name = "txtTempAD1";
            this.txtTempAD1.Size = new System.Drawing.Size(100, 21);
            this.txtTempAD1.TabIndex = 9;
            this.txtTempAD1.Enter += new System.EventHandler(this.txtNormalTempAD_Enter);
            // 
            // txtTempAD0
            // 
            this.txtTempAD0.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTempAD0.Location = new System.Drawing.Point(74, 59);
            this.txtTempAD0.Name = "txtTempAD0";
            this.txtTempAD0.Size = new System.Drawing.Size(100, 21);
            this.txtTempAD0.TabIndex = 8;
            this.txtTempAD0.Enter += new System.EventHandler(this.txtLowTempAD_Enter);
            // 
            // btnRead2
            // 
            this.btnRead2.Enabled = false;
            this.btnRead2.Location = new System.Drawing.Point(486, 142);
            this.btnRead2.Name = "btnRead2";
            this.btnRead2.Size = new System.Drawing.Size(75, 23);
            this.btnRead2.TabIndex = 27;
            this.btnRead2.Tag = "2";
            this.btnRead2.Text = "读取参数";
            this.btnRead2.UseVisualStyleBackColor = true;
            this.btnRead2.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnRead1
            // 
            this.btnRead1.Enabled = false;
            this.btnRead1.Location = new System.Drawing.Point(486, 99);
            this.btnRead1.Name = "btnRead1";
            this.btnRead1.Size = new System.Drawing.Size(75, 23);
            this.btnRead1.TabIndex = 26;
            this.btnRead1.Tag = "1";
            this.btnRead1.Text = "读取参数";
            this.btnRead1.UseVisualStyleBackColor = true;
            this.btnRead1.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnRead0
            // 
            this.btnRead0.Enabled = false;
            this.btnRead0.Location = new System.Drawing.Point(486, 58);
            this.btnRead0.Name = "btnRead0";
            this.btnRead0.Size = new System.Drawing.Size(75, 23);
            this.btnRead0.TabIndex = 25;
            this.btnRead0.Tag = "0";
            this.btnRead0.Text = "读取参数";
            this.btnRead0.UseVisualStyleBackColor = true;
            this.btnRead0.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // Frm温度补偿
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 331);
            this.Controls.Add(this.btnRead2);
            this.Controls.Add(this.btnRead1);
            this.Controls.Add(this.btnRead0);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPresureAD);
            this.Controls.Add(this.txtTempAD);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnWrite2);
            this.Controls.Add(this.btnCollect2);
            this.Controls.Add(this.btnWrite1);
            this.Controls.Add(this.btnCollect1);
            this.Controls.Add(this.txtUpper2);
            this.Controls.Add(this.txtUpper1);
            this.Controls.Add(this.txtUpper0);
            this.Controls.Add(this.txtLow2);
            this.Controls.Add(this.txtLow1);
            this.Controls.Add(this.txtLow0);
            this.Controls.Add(this.txtTempAD2);
            this.Controls.Add(this.txtTempAD1);
            this.Controls.Add(this.txtTempAD0);
            this.Controls.Add(this.btnWrite0);
            this.Controls.Add(this.btnCollect0);
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
        private System.Windows.Forms.Button btnCollect0;
        private System.Windows.Forms.Button btnWrite0;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTempAD0;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTempAD1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTempAD2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLow2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLow1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLow0;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUpper2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUpper1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUpper0;
        private System.Windows.Forms.Button btnWrite1;
        private System.Windows.Forms.Button btnCollect1;
        private System.Windows.Forms.Button btnWrite2;
        private System.Windows.Forms.Button btnCollect2;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPresureAD;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTempAD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRead2;
        private System.Windows.Forms.Button btnRead1;
        private System.Windows.Forms.Button btnRead0;
    }
}