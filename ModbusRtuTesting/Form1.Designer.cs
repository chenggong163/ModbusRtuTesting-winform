namespace ModbusRtuTesting
{
    partial class ModbusRtuTestForm1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.BaudRateComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.startTestBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.portSwitchBtn = new System.Windows.Forms.Button();
            this.refreshPortBtn = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "波特率：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(569, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 2;
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(195, 31);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(121, 20);
            this.serialPortComboBox.TabIndex = 5;
            this.serialPortComboBox.SelectedIndexChanged += new System.EventHandler(this.serialPortComboBox_SelectedIndexChanged);
            // 
            // BaudRateComboBox
            // 
            this.BaudRateComboBox.FormattingEnabled = true;
            this.BaudRateComboBox.Location = new System.Drawing.Point(427, 27);
            this.BaudRateComboBox.Name = "BaudRateComboBox";
            this.BaudRateComboBox.Size = new System.Drawing.Size(121, 20);
            this.BaudRateComboBox.TabIndex = 6;
            this.BaudRateComboBox.SelectedIndexChanged += new System.EventHandler(this.BaudRateComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "导入指令";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // startTestBtn
            // 
            this.startTestBtn.Location = new System.Drawing.Point(562, 84);
            this.startTestBtn.Name = "startTestBtn";
            this.startTestBtn.Size = new System.Drawing.Size(75, 23);
            this.startTestBtn.TabIndex = 11;
            this.startTestBtn.Text = "开始测试";
            this.startTestBtn.UseVisualStyleBackColor = true;
            this.startTestBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(538, 321);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "导出测试结果";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // portSwitchBtn
            // 
            this.portSwitchBtn.Location = new System.Drawing.Point(562, 23);
            this.portSwitchBtn.Name = "portSwitchBtn";
            this.portSwitchBtn.Size = new System.Drawing.Size(75, 23);
            this.portSwitchBtn.TabIndex = 14;
            this.portSwitchBtn.Text = "打开串口";
            this.portSwitchBtn.UseVisualStyleBackColor = true;
            this.portSwitchBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // refreshPortBtn
            // 
            this.refreshPortBtn.Location = new System.Drawing.Point(13, 32);
            this.refreshPortBtn.Name = "refreshPortBtn";
            this.refreshPortBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshPortBtn.TabIndex = 15;
            this.refreshPortBtn.Text = "刷新串口";
            this.refreshPortBtn.UseVisualStyleBackColor = true;
            this.refreshPortBtn.Click += new System.EventHandler(this.refreshPort_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(13, 143);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(624, 172);
            this.listView1.TabIndex = 16;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(195, 84);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(116, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "夹爪类型：";
            // 
            // ModbusRtuTestForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 387);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.refreshPortBtn);
            this.Controls.Add(this.portSwitchBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.startTestBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BaudRateComboBox);
            this.Controls.Add(this.serialPortComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModbusRtuTestForm1";
            this.Text = "ModbusRtuTest";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox serialPortComboBox;
        private System.Windows.Forms.ComboBox BaudRateComboBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button startTestBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button portSwitchBtn;
        private System.Windows.Forms.Button refreshPortBtn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
    }
}