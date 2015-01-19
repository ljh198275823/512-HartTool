namespace HartTool
{
    partial class Frm仪表信息
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
            this.label19 = new System.Windows.Forms.Label();
            this.txtMessage = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDescr
            // 
            this.txtDescr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDescr.Location = new System.Drawing.Point(169, 62);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(208, 21);
            this.txtDescr.TabIndex = 51;
            // 
            // txtTag
            // 
            this.txtTag.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTag.Location = new System.Drawing.Point(169, 24);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(208, 21);
            this.txtTag.TabIndex = 50;
            // 
            // txtDay
            // 
            this.txtDay.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDay.Location = new System.Drawing.Point(324, 99);
            this.txtDay.MaxValue = 2147483647;
            this.txtDay.MinValue = -2147483648;
            this.txtDay.Name = "txtDay";
            this.txtDay.Size = new System.Drawing.Size(43, 21);
            this.txtDay.TabIndex = 49;
            this.txtDay.Text = "0";
            // 
            // txtMonth
            // 
            this.txtMonth.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMonth.Location = new System.Drawing.Point(258, 99);
            this.txtMonth.MaxValue = 2147483647;
            this.txtMonth.MinValue = -2147483648;
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.Size = new System.Drawing.Size(43, 21);
            this.txtMonth.TabIndex = 48;
            this.txtMonth.Text = "0";
            // 
            // txtYear
            // 
            this.txtYear.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtYear.Location = new System.Drawing.Point(169, 99);
            this.txtYear.MaxValue = 2147483647;
            this.txtYear.MinValue = -2147483648;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(65, 21);
            this.txtYear.TabIndex = 47;
            this.txtYear.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(61, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 12);
            this.label15.TabIndex = 41;
            this.label15.Text = "工位号(8位字符)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(370, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 46;
            this.label17.Text = "日";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(67, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "描述(16位字符)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(304, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 45;
            this.label18.Text = "月";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(127, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 43;
            this.label13.Text = "日期";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(235, 103);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 44;
            this.label19.Text = "年";
            // 
            // txtMessage
            // 
            this.txtMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMessage.Location = new System.Drawing.Point(169, 136);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(397, 21);
            this.txtMessage.TabIndex = 53;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(67, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 52;
            this.label12.Text = "信息(32位字符)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(616, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 23);
            this.button1.TabIndex = 54;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Frm仪表信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtDescr);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.txtMonth);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label19);
            this.Name = "Frm仪表信息";
            this.Text = "Frm仪表信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.Label label19;
        private LJH.GeneralLibrary.WinformControl.DBCTextBox txtMessage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}