namespace HartTool
{
    partial class Frm电流校准
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
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnFixedCurrent = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn20 = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnFix4 = new System.Windows.Forms.Button();
            this.btnFix20 = new System.Windows.Forms.Button();
            this.txt4 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txt20 = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtFixedCurrent = new LJH.GeneralLibrary.WinformControl.DecimalTextBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.ForeColor = System.Drawing.Color.Red;
            this.label27.Location = new System.Drawing.Point(334, 190);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(161, 12);
            this.label27.TabIndex = 35;
            this.label27.Text = "0 表示退出固定电流输出模式";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(33, 190);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(77, 12);
            this.label26.TabIndex = 33;
            this.label26.Text = "固定电流输出";
            // 
            // btnFixedCurrent
            // 
            this.btnFixedCurrent.Location = new System.Drawing.Point(226, 182);
            this.btnFixedCurrent.Name = "btnFixedCurrent";
            this.btnFixedCurrent.Size = new System.Drawing.Size(94, 29);
            this.btnFixedCurrent.TabIndex = 32;
            this.btnFixedCurrent.Text = "设置";
            this.btnFixedCurrent.UseVisualStyleBackColor = true;
            this.btnFixedCurrent.Click += new System.EventHandler(this.btnFixedCurrent_Click);
            // 
            // btn4
            // 
            this.btn4.Enabled = false;
            this.btn4.Location = new System.Drawing.Point(378, 60);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(75, 35);
            this.btn4.TabIndex = 31;
            this.btn4.Text = "DA调整";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btn4_Click);
            // 
            // btn20
            // 
            this.btn20.Enabled = false;
            this.btn20.Location = new System.Drawing.Point(378, 111);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(75, 35);
            this.btn20.TabIndex = 30;
            this.btn20.Text = "DA调整";
            this.btn20.UseVisualStyleBackColor = true;
            this.btn20.Click += new System.EventHandler(this.btn20_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(55, 122);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 29;
            this.label25.Text = "20mA校准";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(61, 71);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 12);
            this.label24.TabIndex = 28;
            this.label24.Text = "4mA校准";
            // 
            // btnFix4
            // 
            this.btnFix4.Location = new System.Drawing.Point(116, 60);
            this.btnFix4.Name = "btnFix4";
            this.btnFix4.Size = new System.Drawing.Size(128, 35);
            this.btnFix4.TabIndex = 46;
            this.btnFix4.Text = "固定4mA电流输出";
            this.btnFix4.UseVisualStyleBackColor = true;
            this.btnFix4.Click += new System.EventHandler(this.btnFix4_Click);
            // 
            // btnFix20
            // 
            this.btnFix20.Location = new System.Drawing.Point(116, 111);
            this.btnFix20.Name = "btnFix20";
            this.btnFix20.Size = new System.Drawing.Size(128, 35);
            this.btnFix20.TabIndex = 45;
            this.btnFix20.Text = "固定20mA电流输出";
            this.btnFix20.UseVisualStyleBackColor = true;
            this.btnFix20.Click += new System.EventHandler(this.btnFix20_Click);
            // 
            // txt4
            // 
            this.txt4.Enabled = false;
            this.txt4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt4.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt4.Location = new System.Drawing.Point(269, 64);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(100, 26);
            this.txt4.TabIndex = 44;
            this.txt4.Text = "4";
            // 
            // txt20
            // 
            this.txt20.Enabled = false;
            this.txt20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt20.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txt20.Location = new System.Drawing.Point(269, 115);
            this.txt20.Name = "txt20";
            this.txt20.Size = new System.Drawing.Size(100, 26);
            this.txt20.TabIndex = 41;
            this.txt20.Text = "20";
            // 
            // txtFixedCurrent
            // 
            this.txtFixedCurrent.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFixedCurrent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtFixedCurrent.Location = new System.Drawing.Point(116, 183);
            this.txtFixedCurrent.MaxValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            0});
            this.txtFixedCurrent.MinValue = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            this.txtFixedCurrent.Name = "txtFixedCurrent";
            this.txtFixedCurrent.PointCount = -1;
            this.txtFixedCurrent.Size = new System.Drawing.Size(100, 26);
            this.txtFixedCurrent.TabIndex = 34;
            this.txtFixedCurrent.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 47;
            this.label1.Text = "第一步";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 48;
            this.label2.Text = "第二步";
            // 
            // Frm电流校准
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 413);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFix4);
            this.Controls.Add(this.btnFix20);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt20);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtFixedCurrent);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnFixedCurrent);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label24);
            this.Name = "Frm电流校准";
            this.Text = "电流校准";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LJH.GeneralLibrary.WinformControl.DBCTextBox txt4;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txt20;
        private System.Windows.Forms.Label label27;
        private LJH.GeneralLibrary.WinformControl.DecimalTextBox txtFixedCurrent;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnFixedCurrent;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnFix4;
        private System.Windows.Forms.Button btnFix20;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}