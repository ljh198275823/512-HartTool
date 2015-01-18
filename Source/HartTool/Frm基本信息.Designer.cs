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
            this.label34 = new System.Windows.Forms.Label();
            this.btnWritePollingAddress = new System.Windows.Forms.Button();
            this.txtPollingAddress = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtDescr = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTag = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtDay = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtMonth = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtYear = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDeviceID = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label19 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDampValue = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTransferFunction = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUpperRange = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label21 = new System.Windows.Forms.Label();
            this.txtLowRange = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.btnWritePollingAddress);
            this.groupBox1.Controls.Add(this.txtPollingAddress);
            this.groupBox1.Controls.Add(this.txtDescr);
            this.groupBox1.Controls.Add(this.txtTag);
            this.groupBox1.Controls.Add(this.txtDay);
            this.groupBox1.Controls.Add(this.txtMonth);
            this.groupBox1.Controls.Add(this.txtYear);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtDeviceID);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(706, 216);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备基本信息";
            // 
            // label34
            // 
            this.label34.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(404, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(53, 12);
            this.label34.TabIndex = 41;
            this.label34.Text = "短帧地址";
            // 
            // btnWritePollingAddress
            // 
            this.btnWritePollingAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // txtDescr
            // 
            this.txtDescr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDescr.Location = new System.Drawing.Point(119, 108);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(208, 21);
            this.txtDescr.TabIndex = 38;
            // 
            // txtTag
            // 
            this.txtTag.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTag.Location = new System.Drawing.Point(119, 65);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(208, 21);
            this.txtTag.TabIndex = 29;
            // 
            // txtDay
            // 
            this.txtDay.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDay.Location = new System.Drawing.Point(274, 145);
            this.txtDay.MaxValue = 2147483647;
            this.txtDay.MinValue = -2147483648;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(43, 21);
            this.txtDay.TabIndex = 28;
            this.txtDay.Text = "0";
            // 
            // txtMonth
            // 
            this.txtMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMonth.Location = new System.Drawing.Point(208, 145);
            this.txtMonth.MaxValue = 2147483647;
            this.txtMonth.MinValue = -2147483648;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(43, 21);
            this.txtMonth.TabIndex = 27;
            this.txtMonth.Text = "0";
            // 
            // txtYear
            // 
            this.txtYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtYear.Location = new System.Drawing.Point(119, 145);
            this.txtYear.MaxValue = 2147483647;
            this.txtYear.MinValue = -2147483648;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(65, 21);
            this.txtYear.TabIndex = 26;
            this.txtYear.Text = "0";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 12);
            this.label15.TabIndex = 19;
            this.label15.Text = "工位号(8位字符)";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(320, 149);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "日";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(17, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 20;
            this.label14.Text = "描述(16位字符)";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(254, 149);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 24;
            this.label18.Text = "月";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(77, 149);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "日期";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDeviceID.Location = new System.Drawing.Point(119, 34);
            this.txtDeviceID.MaxValue = 2147483647;
            this.txtDeviceID.MinValue = -2147483648;
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(208, 21);
            this.txtDeviceID.TabIndex = 14;
            this.txtDeviceID.Text = "0";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(185, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 23;
            this.label19.Text = "年";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "设备ID号";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.txtDampValue);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.cmbTransferFunction);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtUpperRange);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.txtLowRange);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Location = new System.Drawing.Point(383, 226);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 177);
            this.groupBox3.TabIndex = 44;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "性能参数";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(193, 123);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 40;
            this.label23.Text = "秒";
            // 
            // txtDampValue
            // 
            this.txtDampValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDampValue.Location = new System.Drawing.Point(87, 119);
            this.txtDampValue.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtDampValue.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtDampValue.Name = "txtDampValue";
            this.txtDampValue.PointCount = -1;
            this.txtDampValue.Size = new System.Drawing.Size(97, 21);
            this.txtDampValue.TabIndex = 39;
            this.txtDampValue.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "阻尼系数";
            // 
            // cmbTransferFunction
            // 
            this.cmbTransferFunction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransferFunction.FormattingEnabled = true;
            this.cmbTransferFunction.Items.AddRange(new object[] {
            "线性",
            "开方"});
            this.cmbTransferFunction.Location = new System.Drawing.Point(87, 25);
            this.cmbTransferFunction.Name = "cmbTransferFunction";
            this.cmbTransferFunction.Size = new System.Drawing.Size(97, 20);
            this.cmbTransferFunction.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "转换函数";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "量程低点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "量程高点";
            // 
            // txtUpperRange
            // 
            this.txtUpperRange.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpperRange.Location = new System.Drawing.Point(87, 86);
            this.txtUpperRange.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtUpperRange.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtUpperRange.Name = "txtUpperRange";
            this.txtUpperRange.PointCount = -1;
            this.txtUpperRange.Size = new System.Drawing.Size(97, 21);
            this.txtUpperRange.TabIndex = 35;
            this.txtUpperRange.Text = "0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(193, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 32;
            this.label21.Text = "单位";
            // 
            // txtLowRange
            // 
            this.txtLowRange.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLowRange.Location = new System.Drawing.Point(87, 55);
            this.txtLowRange.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtLowRange.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtLowRange.Name = "txtLowRange";
            this.txtLowRange.PointCount = -1;
            this.txtLowRange.Size = new System.Drawing.Size(97, 21);
            this.txtLowRange.TabIndex = 34;
            this.txtLowRange.Text = "0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(193, 90);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 33;
            this.label22.Text = "单位";
            // 
            // Frm基本信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 405);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "Frm基本信息";
            this.Text = "FrmGeneralInfo";
            this.Load += new System.EventHandler(this.FrmGeneralInfo_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button btnWritePollingAddress;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtPollingAddress;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtDescr;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTag;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtDay;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtMonth;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtYear;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label13;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtDeviceID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label23;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtDampValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTransferFunction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtUpperRange;
        private System.Windows.Forms.Label label21;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtLowRange;
        private System.Windows.Forms.Label label22;

    }
}