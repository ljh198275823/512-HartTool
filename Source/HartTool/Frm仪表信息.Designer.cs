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
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDownloadMsg = new System.Windows.Forms.Button();
            this.btnDownloadTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMessage = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtDescr = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtTag = new LJH.GeneralLibrary.WinformControl.DBCTextBox(this.components);
            this.txtDay = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtMonth = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.txtYear = new LJH.GeneralLibrary.WinformControl.IntergerTextBox(this.components);
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 28);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(95, 12);
            this.label15.TabIndex = 41;
            this.label15.Text = "工位号(8位字符)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(336, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 46;
            this.label17.Text = "日";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(33, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 42;
            this.label14.Text = "描述(16位字符)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(270, 103);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 45;
            this.label18.Text = "月";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(93, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 43;
            this.label13.Text = "日期";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(201, 103);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(17, 12);
            this.label19.TabIndex = 44;
            this.label19.Text = "年";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 139);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 52;
            this.label12.Text = "信息(32位字符)";
            // 
            // btnDownloadMsg
            // 
            this.btnDownloadMsg.Location = new System.Drawing.Point(488, 136);
            this.btnDownloadMsg.Name = "btnDownloadMsg";
            this.btnDownloadMsg.Size = new System.Drawing.Size(117, 23);
            this.btnDownloadMsg.TabIndex = 54;
            this.btnDownloadMsg.Text = "下载";
            this.btnDownloadMsg.UseVisualStyleBackColor = true;
            this.btnDownloadMsg.Click += new System.EventHandler(this.btnDownloadMsg_Click);
            // 
            // btnDownloadTag
            // 
            this.btnDownloadTag.Location = new System.Drawing.Point(391, 97);
            this.btnDownloadTag.Name = "btnDownloadTag";
            this.btnDownloadTag.Size = new System.Drawing.Size(117, 23);
            this.btnDownloadTag.TabIndex = 55;
            this.btnDownloadTag.Text = "下载";
            this.btnDownloadTag.UseVisualStyleBackColor = true;
            this.btnDownloadTag.Click += new System.EventHandler(this.btnDownloadTag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(135, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 16);
            this.label1.TabIndex = 56;
            this.label1.Text = "字符串里面只能包含数字和大写字母";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(74, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "注意:";
            // 
            // txtMessage
            // 
            this.txtMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMessage.Location = new System.Drawing.Point(135, 136);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(332, 21);
            this.txtMessage.TabIndex = 53;
            // 
            // txtDescr
            // 
            this.txtDescr.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDescr.Location = new System.Drawing.Point(135, 62);
            this.txtDescr.Name = "txtDescr";
            this.txtDescr.Size = new System.Drawing.Size(208, 21);
            this.txtDescr.TabIndex = 51;
            // 
            // txtTag
            // 
            this.txtTag.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtTag.Location = new System.Drawing.Point(135, 24);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(208, 21);
            this.txtTag.TabIndex = 50;
            // 
            // txtDay
            // 
            this.txtDay.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtDay.Location = new System.Drawing.Point(290, 99);
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
            this.txtMonth.Location = new System.Drawing.Point(224, 99);
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
            this.txtYear.Location = new System.Drawing.Point(135, 99);
            this.txtYear.MaxValue = 2099;
            this.txtYear.MinValue = 0;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(65, 21);
            this.txtYear.TabIndex = 47;
            this.txtYear.Text = "1990";
            // 
            // Frm仪表信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 420);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownloadTag);
            this.Controls.Add(this.btnDownloadMsg);
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
        private System.Windows.Forms.Button btnDownloadMsg;
        private System.Windows.Forms.Button btnDownloadTag;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}