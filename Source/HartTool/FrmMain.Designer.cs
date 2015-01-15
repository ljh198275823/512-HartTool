namespace HartTool
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbShortAddress = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCommportState = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMessage = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtDescr = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTag = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtDay = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtMonth = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtYear = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtDeviceID = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.btnRealTime = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPercentOfRange = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCurrent = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtPV = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.tmrRealTime = new System.Windows.Forms.Timer(this.components);
            this.txtUpperRange = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.txtLowRange = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.comPortComboBox1 = new LJH.GeneralLibrary.WinformControl.ComPortComboBox(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTransferFunction = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDampValue = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label23 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(191, 493);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "打开(&O)";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(290, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbShortAddress
            // 
            this.cmbShortAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbShortAddress.FormattingEnabled = true;
            this.cmbShortAddress.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.cmbShortAddress.Location = new System.Drawing.Point(484, 494);
            this.cmbShortAddress.Name = "cmbShortAddress";
            this.cmbShortAddress.Size = new System.Drawing.Size(103, 20);
            this.cmbShortAddress.TabIndex = 4;
            this.cmbShortAddress.SelectedIndexChanged += new System.EventHandler(this.cmbShortAddress_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "短帧地址";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCommportState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 526);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(730, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCommportState
            // 
            this.lblCommportState.ForeColor = System.Drawing.Color.Blue;
            this.lblCommportState.Name = "lblCommportState";
            this.lblCommportState.Size = new System.Drawing.Size(0, 17);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "量程低点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "量程高点";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "压力";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "电流";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "百分比值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(165, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "%";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 186);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 22;
            this.label12.Text = "信息(32位字符)";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessage);
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
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(10, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 216);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设备基本信息";
            // 
            // txtMessage
            // 
            this.txtMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMessage.Location = new System.Drawing.Point(119, 183);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(208, 21);
            this.txtMessage.TabIndex = 39;
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
            // txtDeviceID
            // 
            this.txtDeviceID.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDeviceID.Location = new System.Drawing.Point(119, 34);
            this.txtDeviceID.MaxValue = 2147483647;
            this.txtDeviceID.MinValue = -2147483648;
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(100, 21);
            this.txtDeviceID.TabIndex = 14;
            this.txtDeviceID.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(165, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 30;
            this.label16.Text = "单位";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(165, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 31;
            this.label20.Text = "毫安";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(193, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(29, 12);
            this.label21.TabIndex = 32;
            this.label21.Text = "单位";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(193, 106);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 33;
            this.label22.Text = "单位";
            // 
            // btnRealTime
            // 
            this.btnRealTime.Location = new System.Drawing.Point(225, 29);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(112, 89);
            this.btnRealTime.TabIndex = 36;
            this.btnRealTime.Text = "实时采集";
            this.btnRealTime.UseVisualStyleBackColor = true;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPercentOfRange);
            this.groupBox2.Controls.Add(this.txtCurrent);
            this.groupBox2.Controls.Add(this.txtPV);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnRealTime);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Location = new System.Drawing.Point(10, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 135);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时数据";
            // 
            // txtPercentOfRange
            // 
            this.txtPercentOfRange.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPercentOfRange.Location = new System.Drawing.Point(63, 94);
            this.txtPercentOfRange.Name = "txtPercentOfRange";
            this.txtPercentOfRange.Size = new System.Drawing.Size(96, 21);
            this.txtPercentOfRange.TabIndex = 39;
            // 
            // txtCurrent
            // 
            this.txtCurrent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrent.Location = new System.Drawing.Point(63, 61);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(96, 21);
            this.txtCurrent.TabIndex = 40;
            // 
            // txtPV
            // 
            this.txtPV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPV.Location = new System.Drawing.Point(63, 28);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(96, 21);
            this.txtPV.TabIndex = 38;
            // 
            // tmrRealTime
            // 
            this.tmrRealTime.Interval = 500;
            this.tmrRealTime.Tick += new System.EventHandler(this.tmrRealTime_Tick);
            // 
            // txtUpperRange
            // 
            this.txtUpperRange.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpperRange.Location = new System.Drawing.Point(87, 102);
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
            // txtLowRange
            // 
            this.txtLowRange.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLowRange.Location = new System.Drawing.Point(87, 71);
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
            // comPortComboBox1
            // 
            this.comPortComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comPortComboBox1.FormattingEnabled = true;
            this.comPortComboBox1.Location = new System.Drawing.Point(55, 494);
            this.comPortComboBox1.Name = "comPortComboBox1";
            this.comPortComboBox1.Size = new System.Drawing.Size(121, 20);
            this.comPortComboBox1.TabIndex = 0;
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
            this.groupBox3.Location = new System.Drawing.Point(382, 110);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 349);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模拟输出";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "转换函数";
            // 
            // cmbTransferFunction
            // 
            this.cmbTransferFunction.FormattingEnabled = true;
            this.cmbTransferFunction.Items.AddRange(new object[] {
            "线性",
            "开方"});
            this.cmbTransferFunction.Location = new System.Drawing.Point(87, 41);
            this.cmbTransferFunction.Name = "cmbTransferFunction";
            this.cmbTransferFunction.Size = new System.Drawing.Size(97, 20);
            this.cmbTransferFunction.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "阻尼系数";
            // 
            // txtDampValue
            // 
            this.txtDampValue.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDampValue.Location = new System.Drawing.Point(87, 135);
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
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(193, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(17, 12);
            this.label23.TabIndex = 40;
            this.label23.Text = "秒";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 548);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbShortAddress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPortComboBox1);
            this.Name = "FrmMain";
            this.Text = "Hart 工具";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.ComPortComboBox comPortComboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbShortAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblCommportState;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtDeviceID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtDay;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtMonth;
        private LJH.GeneralLibrary.WinformControl.IntergerTextBox txtYear;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtTag;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtLowRange;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtUpperRange;
        private System.Windows.Forms.Button btnRealTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer tmrRealTime;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPercentOfRange;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtCurrent;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPV;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMessage;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtDescr;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbTransferFunction;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label23;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtDampValue;
        private System.Windows.Forms.Label label6;
    }
}

