using Modbus.Data;
using Modbus.Device;
using Modbus.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ModbusRtuTesting
{
    public class ModbusRtu
    {

        public const ushort rACT = 0x01;
        public const ushort rMODE = 0x11 << 1;
        public const ushort rGTO = 0x01 << 3;
        public const ushort rATR = 0x01 << 4;
        public const ushort rATD = 0x01 << 5;

        public const ushort gACT = 0x01;
        public const ushort gMODE = 0x01 << 2;
        public const ushort gGTO = 0x01 << 3;
        public const ushort gSTA = 0x11 << 4;
        public const ushort gOBJ = 0x11 << 6;

        public string portNum;
        public int baudRate;
        public Parity parity = Parity.None;
        public int dataBits = 8;
        public StopBits stopBits = StopBits.One;
        public int retries = 5;

        private string LogName = null;
        private string LogPath = null;

        private SerialPort serialPort = new SerialPort();
        private ModbusSerialMaster master = null;

        public ModbusRtu() 
        {
            LogName = DateTime.Now.ToString("f(zh-f)") + ".log";
            LogPath = Directory.GetCurrentDirectory();
        }

        public ModbusRtu(string pn, int br)
        {
            portNum = pn;
            baudRate = br;
            serialPort.PortName = pn;
            serialPort.BaudRate = br;
            serialPort.Parity = parity;
            serialPort.DataBits = dataBits;
            serialPort.StopBits = stopBits;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            try
            {
                serialPort.Open();
                master = ModbusSerialMaster.CreateRtu(serialPort);
                master.Transport.Retries = retries;
                master.Transport.ReadTimeout = 200;
                master.Transport.WriteTimeout = 200;
                //Console.WriteLine("串口连接成功");
            }
            catch (Exception ex)
            {
                //Console.WriteLine("串口连接失败" + ex.Message);
                throw new Exception();
            }
        }
        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="pn">串口号</param>
        /// <param name="br">波特率</param>
        /// <returns></returns>
        public bool openSerialPort(string pn, int br)
        {
            portNum = pn;
            baudRate = br;
            serialPort.PortName = pn;
            serialPort.BaudRate = br;
            serialPort.Parity = parity;
            serialPort.DataBits = dataBits;
            serialPort.StopBits = stopBits;
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
            try
            {
                serialPort.Open();
                master = ModbusSerialMaster.CreateRtu(serialPort);
                master.Transport.Retries = retries;
                master.Transport.ReadTimeout = 200;
                master.Transport.WriteTimeout = 200;
                //Console.WriteLine("串口打开");
                return true;
            }
            catch (Exception ex)
            {
                //Console.WriteLine("串口打开失败" + ex.Message);
                return false;
                throw new Exception();
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <returns></returns>
        public bool closeSerialPort()
        {
            try
            {
                serialPort.Close();
                //Console.WriteLine("串口关闭");
                return true;
            }
            catch
            {
                //Console.WriteLine("串口关闭失败");
                return false;
                throw new Exception();
            }
        }

        /// <summary>
        /// 打开电源
        /// </summary>
        /// <returns></returns>
        public bool openPowerSwitch() 
        {
            ushort[] data = { 0x01ff };
            bool result = false;
            try
            {
                master.WriteMultipleRegisters(0, 0x1F48, data);
                result = true;
                //Console.WriteLine("电源打开成功！");
                
            }
            catch
            {
                result = false;
                //Console.WriteLine("电源打开失败！");
                throw new Exception();
            }
            return result;
        }

        /// <summary>
        /// 关闭电源
        /// </summary>
        /// <returns></returns>
        public bool closePowerSwitch() 
        {
            ushort[] data = { 0x00ff };
            bool result = false;
            try
            {
                master.WriteMultipleRegisters(0,0x1F48,data);
                result = true;
                //Console.WriteLine("电源关闭成功！");
            }
            catch
            { 
                result = false;
                throw new Exception();
                //Console.WriteLine("电源关闭失败！");
            }
            return result;
        }

        /// <summary>
        /// 刷新串口
        /// </summary>
        /// <returns></returns>
        public string[] spanPort()
        {
            string[] ports = null;
            ports = SerialPort.GetPortNames();
            return ports;
        }

        /// <summary>
        /// 读线圈寄存器（01指令）
        /// </summary>
        /// <param name="id">站点号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">寄存器个数</param>
        /// <returns></returns>
        public bool[] readCoils(byte id, ushort startAddress, ushort numberOfPoints)
        {
            bool[] resultList = null;
            try
            {
                resultList = master.ReadCoils(id, startAddress, numberOfPoints);
            }
            catch(TimeoutException ex) 
            {
                //Console.WriteLine(ex.Message);
                resultList = null;
            }
            return resultList;
        }

        /// <summary>
        /// 读保持寄存器（03指令）
        /// </summary>
        /// <param name="id">站点号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">寄存器个数</param>
        /// <returns></returns>
        public ushort[] readHoldingReg(byte id, ushort startAddress, ushort numberOfPoints)
        {
            ushort[] resultList = null;
            try
            {
                resultList = master.ReadHoldingRegisters(id, startAddress, numberOfPoints);
            }
            catch (TimeoutException ex)
            {
                resultList = null;
            }
            return resultList;
        }

        /// <summary>
        /// 读输入寄存器（04指令）
        /// </summary>
        /// <param name="id">站点号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="numberOfPoints">寄存器个数</param>
        /// <returns></returns>
        /// <exception cref="ExceptionMessage"></exception>
        public ushort[] readInputReg(byte id, ushort startAddress, ushort numberOfPoints)
        {
            ushort[] resultList = null;
            try
            {
                resultList = master.ReadInputRegisters(id, startAddress, numberOfPoints);
                
            }
            catch (TimeoutException ex) 
            {
                resultList = null;
            }
            return resultList;
        }
        /// <summary>
        /// 写单个保持寄存器（06指令）
        /// </summary>
        /// <param name="id">站点号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="value">寄存器值</param>
        /// <returns></returns>
        /// <exception cref="ExceptionMessage"></exception>
        public void writeSingerReg(byte id, ushort startAddress, ushort value)
        {
            try
            {
                master.WriteSingleRegister(id, startAddress, value);
            }
            catch (TimeoutException ex) 
            {
                //Console.WriteLine("写单个保持寄存器超时");
                //throw new Exception();
            }
        }

        /// <summary>
        /// 写多个保持寄存器（10指令）
        /// </summary>
        /// <param name="id">站点号</param>
        /// <param name="startAdress">起始地址</param>
        /// <param name="data">写入数据</param>
        /// <returns></returns>
        public void writeMultipleReg(byte id, ushort startAddress, params ushort[] value)
        {
            try
            {
                master.WriteMultipleRegisters(id, startAddress, value);
            }
            catch (TimeoutException ex) 
            {
                //throw new Exception();
            }
        }
       
        /// <summary>
        /// 写多个保持寄存器请求与响应
        /// </summary>
        /// <param name="id">站点号</param>
        /// <param name="startAddress">起始地址</param>
        /// <param name="data">寄存器内容</param>
        public void sendAndReceive(byte id,ushort startAddress, RegisterCollection value)
        {
            for (int i = 0; i < 1; i++)
            {
                WriteMultipleRegistersRequest write = new WriteMultipleRegistersRequest(id, startAddress, value);
                WriteMultipleRegistersResponse send = master.ExecuteCustomMessage<WriteMultipleRegistersResponse>(write);
                var data = send.ProtocolDataUnit;
                Console.WriteLine();
                Console.Write(Convert.ToString(id, 16).ToUpper().PadLeft(2, '0') + " ");
                foreach (byte item in data)
                {
                    Console.Write(Convert.ToString(item, 16).ToUpper().PadLeft(2, '0') + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
