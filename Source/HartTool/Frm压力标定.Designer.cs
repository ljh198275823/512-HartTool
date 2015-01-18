namespace HartTool
{
    partial class Frm压力标定
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
            this.btnSetUpperRange = new System.Windows.Forms.Button();
            this.btnSetLowerRange = new System.Windows.Forms.Button();
            this.btnSetPVZero = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetUpperRange
            // 
            this.btnSetUpperRange.Location = new System.Drawing.Point(59, 158);
            this.btnSetUpperRange.Name = "btnSetUpperRange";
            this.btnSetUpperRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetUpperRange.TabIndex = 32;
            this.btnSetUpperRange.Text = "高点微调";
            this.btnSetUpperRange.UseVisualStyleBackColor = true;
            // 
            // btnSetLowerRange
            // 
            this.btnSetLowerRange.Location = new System.Drawing.Point(59, 94);
            this.btnSetLowerRange.Name = "btnSetLowerRange";
            this.btnSetLowerRange.Size = new System.Drawing.Size(116, 35);
            this.btnSetLowerRange.TabIndex = 31;
            this.btnSetLowerRange.Text = "低点微整";
            this.btnSetLowerRange.UseVisualStyleBackColor = true;
            // 
            // btnSetPVZero
            // 
            this.btnSetPVZero.Location = new System.Drawing.Point(59, 34);
            this.btnSetPVZero.Name = "btnSetPVZero";
            this.btnSetPVZero.Size = new System.Drawing.Size(116, 35);
            this.btnSetPVZero.TabIndex = 30;
            this.btnSetPVZero.Text = "零点微调";
            this.btnSetPVZero.UseVisualStyleBackColor = true;
            // 
            // Frm压力标定
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 343);
            this.Controls.Add(this.btnSetUpperRange);
            this.Controls.Add(this.btnSetLowerRange);
            this.Controls.Add(this.btnSetPVZero);
            this.Name = "Frm压力标定";
            this.Text = "压力标定";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSetUpperRange;
        private System.Windows.Forms.Button btnSetLowerRange;
        private System.Windows.Forms.Button btnSetPVZero;
    }
}