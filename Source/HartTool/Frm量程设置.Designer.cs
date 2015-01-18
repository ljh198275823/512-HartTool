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
            this.label33 = new System.Windows.Forms.Label();
            this.txtWriteRangeValueLower = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtWriteRangeValueUpper = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label32 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(249, 38);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(77, 12);
            this.label33.TabIndex = 58;
            this.label33.Text = "基本量程上限";
            // 
            // txtWriteRangeValueLower
            // 
            this.txtWriteRangeValueLower.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueLower.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueLower.Location = new System.Drawing.Point(108, 31);
            this.txtWriteRangeValueLower.Name = "txtWriteRangeValueLower";
            this.txtWriteRangeValueLower.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueLower.TabIndex = 57;
            // 
            // txtWriteRangeValueUpper
            // 
            this.txtWriteRangeValueUpper.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtWriteRangeValueUpper.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtWriteRangeValueUpper.Location = new System.Drawing.Point(332, 31);
            this.txtWriteRangeValueUpper.Name = "txtWriteRangeValueUpper";
            this.txtWriteRangeValueUpper.Size = new System.Drawing.Size(121, 26);
            this.txtWriteRangeValueUpper.TabIndex = 56;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(25, 38);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 12);
            this.label32.TabIndex = 55;
            this.label32.Text = "基本量程下限";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 35);
            this.button1.TabIndex = 54;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Frm量程设置
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 313);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.txtWriteRangeValueLower);
            this.Controls.Add(this.txtWriteRangeValueUpper);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.button1);
            this.Name = "Frm量程设置";
            this.Text = "Frm量程设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label33;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueLower;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtWriteRangeValueUpper;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button button1;
    }
}