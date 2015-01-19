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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.dbcTextBox1 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.dbcTextBox2 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtWriteRangeValueLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWriteRangeValueUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label32 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDeviceID);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.btnWritePollingAddress);
            this.groupBox1.Controls.Add(this.txtPollingAddress);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 96);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备基本信息";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDeviceID.Location = new System.Drawing.Point(99, 28);
            this.txtDeviceID.MaxValue = 2147483647;
            this.txtDeviceID.MinValue = -2147483648;
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(208, 21);
            this.txtDeviceID.TabIndex = 43;
            this.txtDeviceID.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 42;
            this.label7.Text = "设备ID号";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(404, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 41;
            this.label34.Text = "短帧地址";
            // 
            // btnWritePollingAddress
            // 
            this.btnWritePollingAddress.Location = new System.Drawing.Point(543, 32);
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
            this.txtPollingAddress.Location = new System.Drawing.Point(463, 34);
            this.txtPollingAddress.MaxValue = 2147483647;
            this.txtPollingAddress.MinValue = -2147483648;
            this.txtPollingAddress.Name = "txtPollingAddress";
            this.txtPollingAddress.Size = new System.Drawing.Size(65, 21);
            this.txtPollingAddress.TabIndex = 39;
            this.txtPollingAddress.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 79;
            this.label3.Text = "基本量程高点";
            // 
            // dbcTextBox3
            // 
            this.dbcTextBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox3.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox3.Location = new System.Drawing.Point(103, 210);
            this.dbcTextBox3.Name = "dbcTextBox3";
            this.dbcTextBox3.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox3.TabIndex = 78;
            // 
            // dbcTextBox4
            // 
            this.dbcTextBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox4.Location = new System.Drawing.Point(327, 210);
            this.dbcTextBox4.Name = "dbcTextBox4";
            this.dbcTextBox4.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox4.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 76;
            this.label4.Text = "基本量程低点";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 75;
            this.label1.Text = "基本量程高点";
            // 
            // dbcTextBox1
            // 
            this.dbcTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox1.Location = new System.Drawing.Point(103, 161);
            this.dbcTextBox1.Name = "dbcTextBox1";
            this.dbcTextBox1.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox1.TabIndex = 74;
            // 
            // dbcTextBox2
            // 
            this.dbcTextBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbcTextBox2.ImeMode = System.Windows.Forms.ImeMode.On;
            this.dbcTextBox2.Location = new System.Drawing.Point(327, 161);
            this.dbcTextBox2.Name = "dbcTextBox2";
            this.dbcTextBox2.Size = new System.Drawing.Size(121, 26);
            this.dbcTextBox2.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 72;
            this.label2.Text = "基本量程低点";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(244, 125);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(53, 12);
            this.label33.TabIndex = 71;
            this.label33.Text = "量程高点";
            // 
            // txtWriteRangeValueLower
            // 
            this.txtWriteRangeValueLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueLower.Location = new System.Drawing.Point(103, 118);
            this.txtWriteRangeValueLower.Name = "txtWriteRangeValueLower";
            this.txtWriteRangeValueLower.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueLower.TabIndex = 70;
            // 
            // txtWriteRangeValueUpper
            // 
            this.txtWriteRangeValueUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueUpper.Location = new System.Drawing.Point(327, 118);
            this.txtWriteRangeValueUpper.Name = "txtWriteRangeValueUpper";
            this.txtWriteRangeValueUpper.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueUpper.TabIndex = 69;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(20, 125);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(53, 12);
            this.label32.TabIndex = 68;
            this.label32.Text = "量程低点";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(463, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 67;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Frm基本信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 405);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dbcTextBox3);
            this.Controls.Add(this.dbcTextBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbcTextBox1);
            this.Controls.Add(this.dbcTextBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtWriteRangeValueLower);
            this.Controls.Add(this.txtWriteRangeValueUpper);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Frm基本信息";
            this.Text = "FrmGeneralInfo";
            this.Load += new System.EventHandler(this.FrmGeneralInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox1;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox dbcTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label33;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueUpper;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button1;

    }
}