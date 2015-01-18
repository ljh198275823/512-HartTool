﻿namespace HartTool
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
            this.comPortComboBox1 = new LJH.GeneralLibrary.WinformControl.ComPortComboBox(this.components);
            this.pBody = new System.Windows.Forms.Panel();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn量程设置 = new System.Windows.Forms.Button();
            this.btn仪表信息 = new System.Windows.Forms.Button();
            this.btn过程量监控 = new System.Windows.Forms.Button();
            this.btn压力微调 = new System.Windows.Forms.Button();
            this.btn性能参数 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn电流校准 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(8, 441);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "串口号";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Location = new System.Drawing.Point(191, 436);
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
            this.btnClose.Location = new System.Drawing.Point(290, 436);
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
            this.cmbShortAddress.Location = new System.Drawing.Point(484, 437);
            this.cmbShortAddress.Name = "cmbShortAddress";
            this.cmbShortAddress.Size = new System.Drawing.Size(103, 20);
            this.cmbShortAddress.TabIndex = 4;
            this.cmbShortAddress.SelectedIndexChanged += new System.EventHandler(this.cmbShortAddress_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "短帧地址";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCommportState});
            this.statusStrip1.Location = new System.Drawing.Point(0, 469);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(786, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblCommportState
            // 
            this.lblCommportState.ForeColor = System.Drawing.Color.Blue;
            this.lblCommportState.Name = "lblCommportState";
            this.lblCommportState.Size = new System.Drawing.Size(0, 17);
            // 
            // comPortComboBox1
            // 
            this.comPortComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comPortComboBox1.FormattingEnabled = true;
            this.comPortComboBox1.Location = new System.Drawing.Point(55, 437);
            this.comPortComboBox1.Name = "comPortComboBox1";
            this.comPortComboBox1.Size = new System.Drawing.Size(121, 20);
            this.comPortComboBox1.TabIndex = 0;
            // 
            // pBody
            // 
            this.pBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBody.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pBody.Location = new System.Drawing.Point(139, 4);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(642, 418);
            this.pBody.TabIndex = 40;
            this.pBody.Resize += new System.EventHandler(this.pBody_Resize);
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(3, 325);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(117, 33);
            this.btnGeneral.TabIndex = 41;
            this.btnGeneral.Text = "主界面";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.btn量程设置);
            this.panel1.Controls.Add(this.btn仪表信息);
            this.panel1.Controls.Add(this.btn过程量监控);
            this.panel1.Controls.Add(this.btn压力微调);
            this.panel1.Controls.Add(this.btn性能参数);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btn电流校准);
            this.panel1.Controls.Add(this.btnGeneral);
            this.panel1.Location = new System.Drawing.Point(10, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 418);
            this.panel1.TabIndex = 43;
            // 
            // btn量程设置
            // 
            this.btn量程设置.Location = new System.Drawing.Point(3, 10);
            this.btn量程设置.Name = "btn量程设置";
            this.btn量程设置.Size = new System.Drawing.Size(117, 33);
            this.btn量程设置.TabIndex = 49;
            this.btn量程设置.Text = "量程设置";
            this.btn量程设置.UseVisualStyleBackColor = true;
            // 
            // btn仪表信息
            // 
            this.btn仪表信息.Location = new System.Drawing.Point(3, 283);
            this.btn仪表信息.Name = "btn仪表信息";
            this.btn仪表信息.Size = new System.Drawing.Size(117, 33);
            this.btn仪表信息.TabIndex = 48;
            this.btn仪表信息.Text = "仪表信息";
            this.btn仪表信息.UseVisualStyleBackColor = true;
            this.btn仪表信息.Click += new System.EventHandler(this.btn仪表信息_Click);
            // 
            // btn过程量监控
            // 
            this.btn过程量监控.Location = new System.Drawing.Point(3, 244);
            this.btn过程量监控.Name = "btn过程量监控";
            this.btn过程量监控.Size = new System.Drawing.Size(117, 33);
            this.btn过程量监控.TabIndex = 47;
            this.btn过程量监控.Text = "过程量监控";
            this.btn过程量监控.UseVisualStyleBackColor = true;
            this.btn过程量监控.Click += new System.EventHandler(this.btn过程量监控_Click);
            // 
            // btn压力微调
            // 
            this.btn压力微调.Location = new System.Drawing.Point(3, 205);
            this.btn压力微调.Name = "btn压力微调";
            this.btn压力微调.Size = new System.Drawing.Size(117, 33);
            this.btn压力微调.TabIndex = 46;
            this.btn压力微调.Text = "压力微调";
            this.btn压力微调.UseVisualStyleBackColor = true;
            this.btn压力微调.Click += new System.EventHandler(this.btn压力微调_Click);
            // 
            // btn性能参数
            // 
            this.btn性能参数.Location = new System.Drawing.Point(3, 166);
            this.btn性能参数.Name = "btn性能参数";
            this.btn性能参数.Size = new System.Drawing.Size(117, 33);
            this.btn性能参数.TabIndex = 45;
            this.btn性能参数.Text = "性能参数";
            this.btn性能参数.UseVisualStyleBackColor = true;
            this.btn性能参数.Click += new System.EventHandler(this.btn性能参数_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 127);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 33);
            this.button3.TabIndex = 44;
            this.button3.Text = "温度补偿";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 33);
            this.button2.TabIndex = 43;
            this.button2.Text = "多点线性化";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn电流校准
            // 
            this.btn电流校准.Location = new System.Drawing.Point(3, 49);
            this.btn电流校准.Name = "btn电流校准";
            this.btn电流校准.Size = new System.Drawing.Size(117, 33);
            this.btn电流校准.TabIndex = 42;
            this.btn电流校准.Text = "电流较准";
            this.btn电流校准.UseVisualStyleBackColor = true;
            this.btn电流校准.Click += new System.EventHandler(this.btn电流校准_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 491);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pBody);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbShortAddress);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comPortComboBox1);
            this.Name = "FrmMain";
            this.Text = "Hart 工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn量程设置;
        private System.Windows.Forms.Button btn仪表信息;
        private System.Windows.Forms.Button btn过程量监控;
        private System.Windows.Forms.Button btn压力微调;
        private System.Windows.Forms.Button btn性能参数;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn电流校准;
    }
}

