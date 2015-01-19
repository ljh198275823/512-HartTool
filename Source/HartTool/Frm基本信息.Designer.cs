namespace HartTool
{
    partial class Frm基本信息
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
            this.txtDeviceID = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnWritePollingAddress = new System.Windows.Forms.Button();
            this.txtPollingAddress = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dbcTextBox3 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dbcTextBox4 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSensorLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtSenserUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtOutputLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtOutputUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label32 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDeviceID.Location = new System.Drawing.Point(103, 25);
            this.txtDeviceID.MaxValue = 2147483647;
            this.txtDeviceID.MinValue = -2147483648;
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(121, 21);
            this.txtDeviceID.TabIndex = 43;
            this.txtDeviceID.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "设备ID号";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(301, 28);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 41;
            this.label34.Text = "短帧地址";
            // 
            // btnWritePollingAddress
            // 
            this.btnWritePollingAddress.Location = new System.Drawing.Point(518, 23);
            this.btnWritePollingAddress.Name = "btnWritePollingAddress";
            this.btnWritePollingAddress.Size = new System.Drawing.Size(75, 23);
            this.btnWritePollingAddress.TabIndex = 40;
            this.btnWritePollingAddress.Text = "修改短帧地址";
            this.btnWritePollingAddress.UseVisualStyleBackColor = true;
            this.btnWritePollingAddress.Click += new System.EventHandler(this.btnWritePollingAddress_Click);
            // 
            // txtPollingAddress
            // 
            this.txtPollingAddress.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPollingAddress.Location = new System.Drawing.Point(360, 25);
            this.txtPollingAddress.MaxValue = 2147483647;
            this.txtPollingAddress.MinValue = -2147483648;
            this.txtPollingAddress.Name = "txtPollingAddress";
            this.txtPollingAddress.Size = new System.Drawing.Size(121, 21);
            this.txtPollingAddress.TabIndex = 39;
            this.txtPollingAddress.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "20mA切除";
            // 
            // dbcTextBox3
            // 
            this.dbcTextBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox3.Location = new System.Drawing.Point(103, 156);
            this.dbcTextBox3.Name = "dbcTextBox3";
            this.dbcTextBox3.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox3.TabIndex = 78;
            // 
            // dbcTextBox4
            // 
            this.dbcTextBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox4.Location = new System.Drawing.Point(360, 156);
            this.dbcTextBox4.Name = "dbcTextBox4";
            this.dbcTextBox4.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox4.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 76;
            this.label4.Text = "小信号切除";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "基本量程高点";
            // 
            // txtSensorLower
            // 
            this.txtSensorLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSensorLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSensorLower.Location = new System.Drawing.Point(103, 107);
            this.txtSensorLower.Name = "txtSensorLower";
            this.txtSensorLower.Size = new System.Drawing.Size(121, 26);
            this.txtSensorLower.TabIndex = 74;
            // 
            // txtSenserUpper
            // 
            this.txtSenserUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSenserUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSenserUpper.Location = new System.Drawing.Point(360, 107);
            this.txtSenserUpper.Name = "txtSenserUpper";
            this.txtSenserUpper.Size = new System.Drawing.Size(121, 26);
            this.txtSenserUpper.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 72;
            this.label2.Text = "基本量程低点";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(301, 71);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 12);
            this.label33.TabIndex = 71;
            this.label33.Text = "量程高点";
            // 
            // txtOutputLower
            // 
            this.txtOutputLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutputLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOutputLower.Location = new System.Drawing.Point(103, 64);
            this.txtOutputLower.Name = "txtOutputLower";
            this.txtOutputLower.Size = new System.Drawing.Size(121, 26);
            this.txtOutputLower.TabIndex = 70;
            // 
            // txtOutputUpper
            // 
            this.txtOutputUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOutputUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtOutputUpper.Location = new System.Drawing.Point(360, 64);
            this.txtOutputUpper.Name = "txtOutputUpper";
            this.txtOutputUpper.Size = new System.Drawing.Size(121, 26);
            this.txtOutputUpper.TabIndex = 69;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(44, 71);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 68;
            this.label32.Text = "量程低点";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 80;
            this.label5.Text = "%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(487, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 81;
            this.label6.Text = "%";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(487, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 82;
            this.label8.Text = "单位";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(230, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 83;
            this.label9.Text = "单位";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(487, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 84;
            this.label10.Text = "单位";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(230, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 85;
            this.label11.Text = "单位";
            // 
            // Frm基本信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 405);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.btnWritePollingAddress);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.txtPollingAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dbcTextBox3);
            this.Controls.Add(this.dbcTextBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSensorLower);
            this.Controls.Add(this.txtSenserUpper);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtOutputLower);
            this.Controls.Add(this.txtOutputUpper);
            this.Controls.Add(this.label32);
            this.Name = "Frm基本信息";
            this.Text = "FrmGeneralInfo";
            this.Load += new System.EventHandler(this.FrmGeneralInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnWritePollingAddress;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtPollingAddress;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtDeviceID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSensorLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSenserUpper;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label33;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtOutputLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtOutputUpper;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;

    }
}