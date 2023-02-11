using ModbusRtuTesting.EPG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace ModbusRtuTesting
{
    public partial class ModbusRtuTestForm1 : Form
    {
        ModbusRtu mr = new ModbusRtu();
        EPGMotionControl ePGMotionControl = new EPGMotionControl();
        EPGGetFeedbackStatus ePGGetFeedbackStatus = new EPGGetFeedbackStatus();
        FormLogs formLogs = new FormLogs();

        ListItem list = new ListItem();
        public int listRow = 0;
        
        public ModbusRtuTestForm1()
        {
            InitializeComponent();
            InitListView(this.listView1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = mr.spanPort();
            this.serialPortComboBox.DataSource = ports;
            string[] baudRates = list.outBaudRate();
            this.BaudRateComboBox.DataSource = baudRates;
        }

        private void InitListView(ListView listView) 
        {
            ColumnHeader columnHeader0 = new ColumnHeader() { Name = "No", Text = "序号",Width = 30 };
            ColumnHeader columnHeader1 = new ColumnHeader() { Name = "dataTime",Text = "测试时间",Width = 200};
            ColumnHeader columnHeader2 = new ColumnHeader() { Name = "testItem",Text = "测试内容",Width = 200};
            ColumnHeader columnHeader3 = new ColumnHeader() { Name = "testResult",Text = "测试结果",Width = 200};
            listView.Columns.AddRange(new ColumnHeader[] { columnHeader0, columnHeader1, columnHeader2, columnHeader3 });

            listView.HeaderStyle = ColumnHeaderStyle.None;
            listView.HideSelection = false;
        }

        public void writeListItem(string dataTime,string testItem,string testResult) 
        {
            listRow += 1;
            string rowId = Convert.ToString(listRow);

            string[] dataList = new string[] { rowId, dataTime, testItem,testResult};
            ListViewItem listViewItem = new ListViewItem(dataList);
            this.listView1.Items.Add(listViewItem);
        }

        private void refreshPort_Click(object sender, EventArgs e)
        {
            string[] ports = mr.spanPort();
            this.serialPortComboBox.DataSource = ports;
        }

        private void serialPortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public bool getMessage() 
        {
            string serPort = this.serialPortComboBox.SelectedItem.ToString();
            string br = this.BaudRateComboBox.SelectedItem.ToString();

            int baudRate = Convert.ToInt32(br);
            bool isoff = mr.openSerialPort(serPort, baudRate);
            return isoff;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            if (this.portSwitchBtn.Text == "打开串口")
            {
                try
                {
                    getMessage();
                    this.portSwitchBtn.Text = "关闭串口";
                    this.refreshPortBtn.Enabled = false;
                    this.serialPortComboBox.Enabled = false;
                    this.BaudRateComboBox.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("串口打开失败，请重新连接");
                    this.portSwitchBtn.Text = "打开串口";
                }
            }
            else 
            {
                mr.closeSerialPort();
                this.portSwitchBtn.Text = "打开串口";
                this.refreshPortBtn.Enabled = true;
                this.serialPortComboBox.Enabled = true;
                this.BaudRateComboBox.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BaudRateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
