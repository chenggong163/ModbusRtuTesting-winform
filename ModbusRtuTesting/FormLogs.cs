using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ModbusRtuTesting;
using static log4net.Appender.RollingFileAppender;

namespace ModbusRtuTesting
{
    public class FormLogs
    {
        private string testData = null;
        private string testResult = null;

        public delegate bool EPG_MotionControl(byte id);
        public delegate bool EPG_MotionControl_set(byte oldId, ushort setId);
        public delegate bool EPG_MotionControl_setPresetParam(byte id, ushort positionAndSpeedStartAddress, int position = 0, int speed = 0, int power = 0);
        public delegate bool EPG_MotionControl_runPresetParam(byte id, int param);
        public delegate bool EPG_MotionControl_runNotPresetParam(byte id, int position = 0, int speed = 255, int power = 255);
        public delegate byte[] EPG_MotionControl_spanID(int startId, int stopId);
        public string[] addLogs( string testItem, string testResult) 
        {
            string dataTime = DateTime.Now.ToString("YYYY_MM_DD HH:mm:ss").ToString();
            //ModbusRtuTesting.Form1.writeListItem(dataTime, testItem, testResult);
            string[] logInfo = { dataTime, testItem, testResult };
            return logInfo;
        }

        public void Print_EPG_MotionControl(byte id, EPG_MotionControl epg) { }
        public void Print_EPG_MotionControl_set(byte oldId, ushort setId,EPG_MotionControl_set epg) { }
        public void Print_EPG_MotionControl_setPresetParam(EPG_MotionControl_setPresetParam epg,byte id, ushort positionAndSpeedStartAddress, int position = 0, int speed = 0, int power = 0) { }
        public void Print_EPG_MotionControl_runPresetParam(byte id, int param, EPG_MotionControl_runPresetParam epg) { }
        public void Print_EPG_MotionControl_runNotPresetParam(EPG_MotionControl_runNotPresetParam epg,byte id, int position = 0, int speed = 255, int power = 255) { }
        public byte[] Print_EPG_MotionControl_spanID(int startId, int stopId, EPG_MotionControl_spanID epg) 
        {
            return epg(startId, stopId);
        }

    }
}
