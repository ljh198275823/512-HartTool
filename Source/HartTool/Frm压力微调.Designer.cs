namespace HartTool
{
    partial class Frm压力微调
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
            this.btnSetLowerRange = new System.Windows.Forms.Button();
            this.btnSetUpperRange = new System.Windows.Forms.Button();
            this.btnSetPVZero = new System.Windows.Forms.Button();
            this.rdUpper = new System.Windows.Forms.RadioButton();
            this.rdLower = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtReal = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.SuspendLayout();
            // 
            // btnSetLowerRange
            // 
            this.btnSetLowerRange.Enabled = false;
            this.btnSetLowerRange.Location = new System.Drawing.Point(358, 112);
            this.btnSetLowerRange.Name = "btnSetLowerRange";
            this.btnSetLowerRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetLowerRange.TabIndex = 32;
            this.btnSetLowerRange.Text = "低点微调";
            this.btnSetLowerRange.UseVisualStyleBackColor = true;
            this.btnSetLowerRange.Click += new System.EventHandler(this.btnSetLowerRange_Click);
            // 
            // btnSetUpperRange
            // 
            this.btnSetUpperRange.Enabled = false;
            this.btnSetUpperRange.Location = new System.Drawing.Point(358, 156);
            this.btnSetUpperRange.Name = "btnSetUpperRange";
            this.btnSetUpperRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetUpperRange.TabIndex = 31;
            this.btnSetUpperRange.Text = "高点微调";
            this.btnSetUpperRange.UseVisualStyleBackColor = true;
            this.btnSetUpperRange.Click += new System.EventHandler(this.btnSetUpperRange_Click);
            // 
            // btnSetPVZero
            // 
            this.btnSetPVZero.Location = new System.Drawing.Point(59, 34);
            this.btnSetPVZero.Name = "btnSetPVZero";
            this.btnSetPVZero.Size = new System.Drawing.Size(116, 35);
            this.btnSetPVZero.TabIndex = 30;
            this.btnSetPVZero.Text = "零点微调";
            this.btnSetPVZero.UseVisualStyleBackColor = true;
            this.btnSetPVZero.Click += new System.EventHandler(this.btnSetPVZero_Click);
            // 
            // rdUpper
            // 
            this.rdUpper.AutoSize = true;
            this.rdUpper.Location = new System.Drawing.Point(59, 165);
            this.rdUpper.Name = "rdUpper";
            this.rdUpper.Size = new System.Drawing.Size(71, 16);
            this.rdUpper.TabIndex = 33;
            this.rdUpper.TabStop = true;
            this.rdUpper.Text = "高点微调";
            this.rdUpper.UseVisualStyleBackColor = true;
            this.rdUpper.CheckedChanged += new System.EventHandler(this.rdUpper_CheckedChanged);
            // 
            // rdLower
            // 
            this.rdLower.AutoSize = true;
            this.rdLower.Location = new System.Drawing.Point(59, 121);
            this.rdLower.Name = "rdLower";
            this.rdLower.Size = new System.Drawing.Size(71, 16);
            this.rdLower.TabIndex = 34;
            this.rdLower.TabStop = true;
            this.rdLower.Text = "低点微调";
            this.rdLower.UseVisualStyleBackColor = true;
            this.rdLower.CheckedChanged += new System.EventHandler(this.rdLower_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(263, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 35);
            this.button1.TabIndex = 68;
            this.button1.Text = "采集";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(263, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 35);
            this.button2.TabIndex = 67;
            this.button2.Text = "采集";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtReal
            // 
            this.txtReal.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtReal.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtReal.Location = new System.Drawing.Point(136, 228);
            this.txtReal.Name = "txtReal";
            this.txtReal.Size = new System.Drawing.Size(121, 26);
            this.txtReal.TabIndex = 66;
            // 
            // txtUpper
            // 
            this.txtUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpper.Location = new System.Drawing.Point(136, 160);
            this.txtUpper.Name = "txtUpper";
            this.txtUpper.Size = new System.Drawing.Size(121, 26);
            this.txtUpper.TabIndex = 63;
            // 
            // txtLower
            // 
            this.txtLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLower.Location = new System.Drawing.Point(136, 116);
            this.txtLower.Name = "txtLower";
            this.txtLower.Size = new System.Drawing.Size(121, 26);
            this.txtLower.TabIndex = 62;
            // 
            // Frm压力微调
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 343);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtReal);
            this.Controls.Add(this.txtUpper);
            this.Controls.Add(this.txtLower);
            this.Controls.Add(this.rdLower);
            this.Controls.Add(this.rdUpper);
            this.Controls.Add(this.btnSetLowerRange);
            this.Controls.Add(this.btnSetUpperRange);
            this.Controls.Add(this.btnSetPVZero);
            this.Name = "Frm压力微调";
            this.Text = "压力标定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm压力微调_FormClosed);
            this.Load += new System.EventHandler(this.Frm压力微调_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetLowerRange;
        private System.Windows.Forms.Button btnSetUpperRange;
        private System.Windows.Forms.Button btnSetPVZero;
        private System.Windows.Forms.RadioButton rdUpper;
        private System.Windows.Forms.RadioButton rdLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUpper;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtReal;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}