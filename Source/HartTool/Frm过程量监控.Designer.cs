namespace HartTool
{
    partial class Frm过程量监控
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
            this.txtPercentOfRange = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtCurrent = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtPV = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.btnRealTime = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblPVUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPercentOfRange
            // 
            this.txtPercentOfRange.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPercentOfRange.ForeColor = System.Drawing.Color.Red;
            this.txtPercentOfRange.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPercentOfRange.Location = new System.Drawing.Point(84, 100);
            this.txtPercentOfRange.Name = "txtPercentOfRange";
            this.txtPercentOfRange.Size = new System.Drawing.Size(112, 26);
            this.txtPercentOfRange.TabIndex = 49;
            // 
            // txtCurrent
            // 
            this.txtCurrent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCurrent.ForeColor = System.Drawing.Color.Red;
            this.txtCurrent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtCurrent.Location = new System.Drawing.Point(84, 63);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.Size = new System.Drawing.Size(112, 26);
            this.txtCurrent.TabIndex = 50;
            // 
            // txtPV
            // 
            this.txtPV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPV.ForeColor = System.Drawing.Color.Red;
            this.txtPV.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtPV.Location = new System.Drawing.Point(84, 26);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(112, 26);
            this.txtPV.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(49, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 41;
            this.label9.Text = "电流";
            // 
            // btnRealTime
            // 
            this.btnRealTime.Location = new System.Drawing.Point(279, 27);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(112, 99);
            this.btnRealTime.TabIndex = 47;
            this.btnRealTime.Text = "实时采集";
            this.btnRealTime.UseVisualStyleBackColor = true;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 42;
            this.label8.Text = "压力";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 43;
            this.label10.Text = "百分比值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(208, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "%";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(208, 70);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 46;
            this.label20.Text = "mA";
            // 
            // lblPVUnit
            // 
            this.lblPVUnit.AutoSize = true;
            this.lblPVUnit.Location = new System.Drawing.Point(208, 33);
            this.lblPVUnit.Name = "lblPVUnit";
            this.lblPVUnit.Size = new System.Drawing.Size(29, 12);
            this.lblPVUnit.TabIndex = 45;
            this.lblPVUnit.Text = "单位";
            // 
            // Frm过程量监控
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 372);
            this.Controls.Add(this.txtPercentOfRange);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.txtPV);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnRealTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblPVUnit);
            this.Name = "Frm过程量监控";
            this.Text = "Frm过程量监控";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm过程量监控_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPercentOfRange;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtCurrent;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtPV;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnRealTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblPVUnit;
    }
}