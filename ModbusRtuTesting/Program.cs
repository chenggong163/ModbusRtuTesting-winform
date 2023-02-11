using Modbus.Device;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Message;
using ModbusRtuTesting.EPG;
using Modbus.Extensions.Enron;
using log4net;

namespace ModbusRtuTesting
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ModbusRtuTestingForm());
        }

        /* static void Main() 
         {
             //log4net.Config.XmlConfigurator.Configure();
             EPGMotionControl epgMotionControl = new EPGMotionControl("com12", 115200);
             Console.WriteLine("扫描ID，结果如下：");
             byte[] idList = epgMotionControl.spanID(1, 10);

             foreach (byte id in idList)
             {
                 //Console.Write(Convert.ToString(id, 16).ToUpper().PadLeft(2, '0') + " ");
                 Console.Write(id + "  ");
             }
             Console.WriteLine();
             epgMotionControl.openDevice(idList[0]);
             Thread.Sleep(4000);
             epgMotionControl.fullPowerAndFullSpeedOpen(idList[0]);
             Thread.Sleep(1500);
             epgMotionControl.fullPowerAndFullSpeedClose(idList[0]);
             Thread.Sleep(3000);
             epgMotionControl.setPresetParam(idList[0], (ushort)presetsParamRegs.PositionSetReg1, 100, 20, 255);
             Thread.Sleep(200);
             epgMotionControl.runPresetParam(idList[0], 8);

             //epgMotionControl.setRunParam(1,100,100,100);
             Thread.Sleep(3000);
             ushort position = epgMotionControl.getPositionStatus(idList[0]);
             ushort speed = epgMotionControl.getSpeedStatus(idList[0]);
             epgMotionControl.getTorqueStatus(idList[0]);
             epgMotionControl.getVoltageStatus(idList[0]);
             epgMotionControl.getTempStatus(idList[0]);
             epgMotionControl.getFaultStatus(idList[0]);
             epgMotionControl.getClawStatus(idList[0]);
             Console.WriteLine(" ",Convert.ToString(position, 16).ToUpper().PadLeft(2, '0') + " ");
             epgMotionControl.closeDevice(idList[0]);
             epgMotionControl.closeSerialPort();
             Thread.Sleep(6000);
         }*/
    }
}
