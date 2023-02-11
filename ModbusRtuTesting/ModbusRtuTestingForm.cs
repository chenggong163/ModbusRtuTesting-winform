using ModbusRtuTesting.EPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ModbusRtuTesting
{
    public partial class ModbusRtuTestingForm : Form
    {
        EPGMotionControl epgMotionControl = new EPGMotionControl();
        EPGGetFeedbackStatus epgGetFeedbackStatus = new EPGGetFeedbackStatus();
        FormLogs formLogs = new FormLogs();

        ListItem list = new ListItem();
        public int listRow = 0;
        public ModbusRtuTestingForm()
        {
            InitializeComponent();
        }

        private void ModbusRtuTestingForm_Load(object sender, EventArgs e)
        {
            InitListView(this.listView1);
            string[] ports = epgMotionControl.spanPort();
            this.serialPortComboBox.DataSource = ports;
            string[] baudRates = list.outBaudRate();
            this.BaudRateComboBox.DataSource = baudRates;
            string[] clawKind = list.outClawKind();
            this.clawKindComboBox1.DataSource = clawKind;
        }

        private void InitListView(ListView lv)
        {
            ColumnHeader columnHeader0 = new ColumnHeader() { Name = "No", Text = "序号", Width = 60 ,TextAlign = HorizontalAlignment.Center};
            ColumnHeader columnHeader1 = new ColumnHeader() { Name = "dataTime", Text = "测试时间", Width = 150, TextAlign = HorizontalAlignment.Center };
            ColumnHeader columnHeader2 = new ColumnHeader() { Name = "testItem", Text = "测试内容", Width = 300, TextAlign = HorizontalAlignment.Center };
            ColumnHeader columnHeader3 = new ColumnHeader() { Name = "testResult", Text = "测试结果", Width = 100, TextAlign = HorizontalAlignment.Center };

            lv.View = System.Windows.Forms.View.Details;
            lv.FullRowSelect = true;
            lv.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3 });
            
        }

        public bool getMessage(bool openoff)
        {
            string serPort = this.serialPortComboBox.SelectedItem.ToString();
            string br = this.BaudRateComboBox.SelectedItem.ToString();
            int baudRate = int.Parse(br);
            bool isoff = false; 
            if (openoff == true) 
            {
                isoff = epgMotionControl.openSerialPort(serPort, baudRate);
            }
            else 
            {
                isoff = epgMotionControl.closeSerialPort();
            }
            return isoff;
        }

        public void outListItems(string info,string result) 
        {
            listRow += 1;
            string strList = listRow.ToString();
            ListViewItem listViewItem = new ListViewItem(strList);
            string[] message = { DateTime.Now.ToString(), info, result };
            listViewItem.SubItems.AddRange(message);
            listView1.Items.Add(listViewItem);
        }

        private void refreshPortBtn_Click(object sender, EventArgs e)
        {
            string[] ports = epgMotionControl.spanPort();
            this.serialPortComboBox.DataSource = ports;
            this.outListItems("刷新串口", "True");
        }

        private void serialPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void portSwitchBtn_Click(object sender, EventArgs e)
        {
            bool result = false;
            if (this.portSwitchBtn.Text == "打开串口")
            {
                try
                {
                    result = getMessage(true);
                    this.portSwitchBtn.Text = "关闭串口";
                    this.outListItems("打开串口", result.ToString());
                    this.refreshPortBtn.Enabled = false;
                    this.serialPortComboBox.Enabled = false;
                    this.BaudRateComboBox.Enabled = false;
                }
                catch
                {   
                    result = false; 
                    this.outListItems("串口打开失败，请重新连接", result.ToString());
                    this.portSwitchBtn.Text = "打开串口";
                }
            }
            else
            {
                result = getMessage(false);
                this.portSwitchBtn.Text = "打开串口";
                this.outListItems("关闭串口", result.ToString());
                this.refreshPortBtn.Enabled = true;
                this.serialPortComboBox.Enabled = true;
                this.BaudRateComboBox.Enabled = true;
            }
        }

        private void startTestBtn_Click(object sender, EventArgs e)
        {
            bool result = false;
            this.outListItems("开始测试", "");
            //log4net.Config.XmlConfigurator.Configure();
            byte[] idList = formLogs.Print_EPG_MotionControl_spanID(1,10,epgMotionControl.spanID);
            this.outListItems("扫描站点号","");
            foreach (byte id in idList)
            {
                this.outListItems("获取站点：",id.ToString());
            }
            foreach (byte id in idList) 
            {
                result = epgMotionControl.openDevice(id);
                this.outListItems("使能设备", result.ToString());
                Thread.Sleep(4000);
                result = epgMotionControl.fullPowerAndFullSpeedOpen(id);
                this.outListItems("全力全速打开",result.ToString());
                Thread.Sleep(1500);
                result = epgMotionControl.fullPowerAndFullSpeedClose(id);
                this.outListItems("全力全速关闭",result.ToString());
                Thread.Sleep(3000);
                result =epgMotionControl.setPresetParam(id, (ushort)presetsParamRegs.PositionSetReg1, 100, 20, 255);
                string setPresetParamInfo = "设置预设参数 位置：100 速度：20 力：255";
                outListItems(setPresetParamInfo, result.ToString());
                Thread.Sleep(200);
                result = epgMotionControl.runPresetParam(id, 8);
                outListItems("执行预设参数:8",result.ToString());
                //epgMotionControl.setRunParam(1,100,100,100);
                Thread.Sleep(3000);
                ushort position = epgMotionControl.getPositionStatus(id);
                string positionStr = position.ToString();
                this.outListItems("获取当前位置：", positionStr);

                ushort speed = epgMotionControl.getSpeedStatus(id);
                string speedStr = speed.ToString();
                this.outListItems("获取当前位置：", speedStr);

                ushort torque = epgMotionControl.getTorqueStatus(id);
                string torqueStr = torque.ToString();
                this.outListItems("获取当前力矩：",torqueStr);

                ushort voltage = epgMotionControl.getVoltageStatus(id);
                this.outListItems("获取当前电压：",voltage.ToString());

                ushort temp = epgMotionControl.getTempStatus(id);
                this.outListItems("获取当前温度：",temp.ToString());

                result = epgMotionControl.closeDevice(id);
                this.outListItems("禁用设备",result.ToString());

                result = epgMotionControl.closeSerialPort();
                this.outListItems("关闭串口",result.ToString());

            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BaudRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
