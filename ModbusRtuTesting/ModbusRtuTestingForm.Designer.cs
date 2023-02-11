﻿namespace ModbusRtuTesting
{
    partial class ModbusRtuTestingForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.clawKindComboBox1 = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.refreshPortBtn = new System.Windows.Forms.Button();
            this.portSwitchBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.startTestBtn = new System.Windows.Forms.Button();
            this.BaudRateComboBox = new System.Windows.Forms.ComboBox();
            this.serialPortComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 32;
            this.label4.Text = "夹爪类型：";
            // 
            // clawKindComboBox1
            // 
            this.clawKindComboBox1.FormattingEnabled = true;
            this.clawKindComboBox1.Location = new System.Drawing.Point(194, 101);
            this.clawKindComboBox1.Name = "clawKindComboBox1";
            this.clawKindComboBox1.Size = new System.Drawing.Size(121, 20);
            this.clawKindComboBox1.TabIndex = 31;
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 160);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(624, 172);
            this.listView1.TabIndex = 30;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // refreshPortBtn
            // 
            this.refreshPortBtn.Location = new System.Drawing.Point(12, 49);
            this.refreshPortBtn.Name = "refreshPortBtn";
            this.refreshPortBtn.Size = new System.Drawing.Size(75, 23);
            this.refreshPortBtn.TabIndex = 29;
            this.refreshPortBtn.Text = "刷新串口";
            this.refreshPortBtn.UseVisualStyleBackColor = true;
            this.refreshPortBtn.Click += new System.EventHandler(this.refreshPortBtn_Click);
            // 
            // portSwitchBtn
            // 
            this.portSwitchBtn.Location = new System.Drawing.Point(561, 40);
            this.portSwitchBtn.Name = "portSwitchBtn";
            this.portSwitchBtn.Size = new System.Drawing.Size(75, 23);
            this.portSwitchBtn.TabIndex = 28;
            this.portSwitchBtn.Text = "打开串口";
            this.portSwitchBtn.UseVisualStyleBackColor = true;
            this.portSwitchBtn.Click += new System.EventHandler(this.portSwitchBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(537, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(99, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "导出测试结果";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // startTestBtn
            // 
            this.startTestBtn.Location = new System.Drawing.Point(561, 101);
            this.startTestBtn.Name = "startTestBtn";
            this.startTestBtn.Size = new System.Drawing.Size(75, 23);
            this.startTestBtn.TabIndex = 26;
            this.startTestBtn.Text = "开始测试";
            this.startTestBtn.UseVisualStyleBackColor = true;
            this.startTestBtn.Click += new System.EventHandler(this.startTestBtn_Click);
            // 
            // BaudRateComboBox
            // 
            this.BaudRateComboBox.FormattingEnabled = true;
            this.BaudRateComboBox.Location = new System.Drawing.Point(426, 44);
            this.BaudRateComboBox.Name = "BaudRateComboBox";
            this.BaudRateComboBox.Size = new System.Drawing.Size(121, 20);
            this.BaudRateComboBox.TabIndex = 24;
            this.BaudRateComboBox.SelectedIndexChanged += new System.EventHandler(this.BaudRateComboBox_SelectedIndexChanged);
            // 
            // serialPortComboBox
            // 
            this.serialPortComboBox.FormattingEnabled = true;
            this.serialPortComboBox.Location = new System.Drawing.Point(194, 48);
            this.serialPortComboBox.Name = "serialPortComboBox";
            this.serialPortComboBox.Size = new System.Drawing.Size(121, 20);
            this.serialPortComboBox.TabIndex = 23;
            this.serialPortComboBox.SelectedIndexChanged += new System.EventHandler(this.serialPortComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(568, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(357, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "波特率：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "串口号：";
            // 
            // ModbusRtuTestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 383);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clawKindComboBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.refreshPortBtn);
            this.Controls.Add(this.portSwitchBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.startTestBtn);
            this.Controls.Add(this.BaudRateComboBox);
            this.Controls.Add(this.serialPortComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ModbusRtuTestingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModbusRtuTestingForm";
            this.Load += new System.EventHandler(this.ModbusRtuTestingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox clawKindComboBox1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button refreshPortBtn;
        private System.Windows.Forms.Button portSwitchBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button startTestBtn;
        private System.Windows.Forms.ComboBox BaudRateComboBox;
        private System.Windows.Forms.ComboBox serialPortComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}