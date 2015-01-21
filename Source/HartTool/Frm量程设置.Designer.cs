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
            this.cmbSensorMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSensorCode = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtPVLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtPVUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtSensorLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtSensorUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblUnit1 = new System.Windows.Forms.Label();
            this.lblRangeUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbSensorMode
            // 
            this.cmbSensorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorMode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSensorMode.FormattingEnabled = true;
            this.cmbSensorMode.Location = new System.Drawing.Point(131, 35);
            this.cmbSensorMode.Name = "cmbSensorMode";
            this.cmbSensorMode.Size = new System.Drawing.Size(121, 24);
            this.cmbSensorMode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "工作模式";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "传感器代码";
            // 
            // cmbSensorCode
            // 
            this.cmbSensorCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbSensorCode.FormattingEnabled = true;
            this.cmbSensorCode.Location = new System.Drawing.Point(344, 35);
            this.cmbSensorCode.Name = "cmbSensorCode";
            this.cmbSensorCode.Size = new System.Drawing.Size(121, 24);
            this.cmbSensorCode.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(291, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 84;
            this.label3.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 81;
            this.label4.Text = "量程上下限";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(518, 83);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 29);
            this.button3.TabIndex = 85;
            this.button3.Text = "下载";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtPVLower
            // 
            this.txtPVLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPVLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPVLower.Location = new System.Drawing.Point(131, 84);
            this.txtPVLower.Name = "txtPVLower";
            this.txtPVLower.Size = new System.Drawing.Size(121, 26);
            this.txtPVLower.TabIndex = 83;
            // 
            // txtPVUpper
            // 
            this.txtPVUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPVUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPVUpper.Location = new System.Drawing.Point(344, 84);
            this.txtPVUpper.Name = "txtPVUpper";
            this.txtPVUpper.Size = new System.Drawing.Size(121, 26);
            this.txtPVUpper.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(291, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 95;
            this.label5.Text = "--";
            // 
            // txtSensorLower
            // 
            this.txtSensorLower.Enabled = false;
            this.txtSensorLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSensorLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSensorLower.Location = new System.Drawing.Point(131, 130);
            this.txtSensorLower.Name = "txtSensorLower";
            this.txtSensorLower.Size = new System.Drawing.Size(121, 26);
            this.txtSensorLower.TabIndex = 94;
            // 
            // txtSensorUpper
            // 
            this.txtSensorUpper.Enabled = false;
            this.txtSensorUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSensorUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSensorUpper.Location = new System.Drawing.Point(344, 130);
            this.txtSensorUpper.Name = "txtSensorUpper";
            this.txtSensorUpper.Size = new System.Drawing.Size(121, 26);
            this.txtSensorUpper.TabIndex = 93;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 92;
            this.label6.Text = "传感器量程上下限";
            // 
            // lblUnit1
            // 
            this.lblUnit1.AutoSize = true;
            this.lblUnit1.Location = new System.Drawing.Point(471, 137);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Size = new System.Drawing.Size(29, 12);
            this.lblUnit1.TabIndex = 96;
            this.lblUnit1.Text = "单位";
            // 
            // lblRangeUnit
            // 
            this.lblRangeUnit.AutoSize = true;
            this.lblRangeUnit.Location = new System.Drawing.Point(471, 91);
            this.lblRangeUnit.Name = "lblRangeUnit";
            this.lblRangeUnit.Size = new System.Drawing.Size(29, 12);
            this.lblRangeUnit.TabIndex = 97;
            this.lblRangeUnit.Text = "单位";
            // 
            // Frm量程设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 385);
            this.Controls.Add(this.lblRangeUnit);
            this.Controls.Add(this.lblUnit1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSensorLower);
            this.Controls.Add(this.txtSensorUpper);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPVLower);
            this.Controls.Add(this.txtPVUpper);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbSensorCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSensorMode);
            this.Name = "Frm量程设置";
            this.Text = "Frm量程设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSensorMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSensorCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPVLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPVUpper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSensorLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtSensorUpper;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUnit1;
        private System.Windows.Forms.Label lblRangeUnit;

    }
}