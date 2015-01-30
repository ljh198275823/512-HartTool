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
            this.btnSetUpperRange = new System.Windows.Forms.Button();
            this.btnSetLowerRange = new System.Windows.Forms.Button();
            this.btnSetPVZero = new System.Windows.Forms.Button();
            this.rdUpper = new System.Windows.Forms.RadioButton();
            this.rdLower = new System.Windows.Forms.RadioButton();
            this.txtLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSetUpperRange
            // 
            this.btnSetUpperRange.Enabled = false;
            this.btnSetUpperRange.Location = new System.Drawing.Point(313, 112);
            this.btnSetUpperRange.Name = "btnSetUpperRange";
            this.btnSetUpperRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetUpperRange.TabIndex = 32;
            this.btnSetUpperRange.Text = "下载";
            this.btnSetUpperRange.UseVisualStyleBackColor = true;
            this.btnSetUpperRange.Click += new System.EventHandler(this.btnSetLowerRange_Click);
            // 
            // btnSetLowerRange
            // 
            this.btnSetLowerRange.Enabled = false;
            this.btnSetLowerRange.Location = new System.Drawing.Point(313, 156);
            this.btnSetLowerRange.Name = "btnSetLowerRange";
            this.btnSetLowerRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetLowerRange.TabIndex = 31;
            this.btnSetLowerRange.Text = "下载";
            this.btnSetLowerRange.UseVisualStyleBackColor = true;
            this.btnSetLowerRange.Click += new System.EventHandler(this.btnSetUpperRange_Click);
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
            this.rdUpper.Text = "校准上限";
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
            this.rdLower.Text = "校准下限";
            this.rdLower.UseVisualStyleBackColor = true;
            this.rdLower.CheckedChanged += new System.EventHandler(this.rdLower_CheckedChanged);
            // 
            // txtLower
            // 
            this.txtLower.Enabled = false;
            this.txtLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtLower.Location = new System.Drawing.Point(136, 116);
            this.txtLower.Name = "txtLower";
            this.txtLower.Size = new System.Drawing.Size(121, 26);
            this.txtLower.TabIndex = 62;
            // 
            // txtUpper
            // 
            this.txtUpper.Enabled = false;
            this.txtUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtUpper.Location = new System.Drawing.Point(136, 160);
            this.txtUpper.Name = "txtUpper";
            this.txtUpper.Size = new System.Drawing.Size(121, 26);
            this.txtUpper.TabIndex = 63;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "KPa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 65;
            this.label2.Text = "KPa";
            // 
            // Frm压力微调
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 343);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUpper);
            this.Controls.Add(this.txtLower);
            this.Controls.Add(this.rdLower);
            this.Controls.Add(this.rdUpper);
            this.Controls.Add(this.btnSetUpperRange);
            this.Controls.Add(this.btnSetLowerRange);
            this.Controls.Add(this.btnSetPVZero);
            this.Name = "Frm压力微调";
            this.Text = "压力标定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm压力微调_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetUpperRange;
        private System.Windows.Forms.Button btnSetLowerRange;
        private System.Windows.Forms.Button btnSetPVZero;
        private System.Windows.Forms.RadioButton rdUpper;
        private System.Windows.Forms.RadioButton rdLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtUpper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}