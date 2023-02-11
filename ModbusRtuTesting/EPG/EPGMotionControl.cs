using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;
using Modbus.Extensions.Enron;
using ModbusRtuTesting.PUB;

namespace ModbusRtuTesting.EPG
{
    /// <summary>
    /// EPG控制寄存器
    /// </summary>
    public enum controlRegs : ushort
    {
        ControlSetReg = 0x03E8,     //控制寄存器地址(低字节)、
        NoParamControlReg = 0x03E8, //无参控制指令寄存器（高字节）
        PositionSetReg = 0x03E9,    //位置寄存器（高字节）
        SpeedSetReg = 0x03EA,       //速度寄存器（低字节）
        PowerSetReg = 0x03EA,       //力设置寄存器（高字节）
        EncoderReg = 0x03FB,        //编码器寄存器（低字节）
        Brake = 0x03FC,             //制动寄存器（低字节）
    }

    /// <summary>
    /// EPG状态寄存器
    /// </summary>
    public enum statusRegs : ushort
    {
        FingerStatus = 0x07D0,              //电动夹爪状态寄存器（低字节）
        PositionAndFaultStatus = 0x07D1,    //位置和故障状态寄存器
        PowerAndSpeedStatus = 0x07D2,       //力状态和速度寄存器
        TempAndVoltageStatus = 0x07D3,      //温度和母线电压状态寄存器
        EncoderStatus = 0x07E3,             //编码器状态寄存器（低字节）       
        BrakeStatus = 0x07E4,               //制动状态寄存器（低字节）
        EncoderValue = 0x07E5,              //编码器值寄存器
    }

    /// <summary>
    /// 预设参数寄存器
    /// </summary>
    public enum presetsParamRegs : ushort
    {
        PositionSetReg1 = 0x03EB,            //预设参数1位置设置寄存器
        SpeedSetReg1 = 0x03EB,               //预设参数1速度设置寄存器
        TorqueSetReg1 = 0x3EC,               //预设参数1力矩设置寄存器

        PositionSetReg2 = 0x03ED,            //预设参数2位置设置寄存器
        SpeedSetReg2 = 0x03ED,               //预设参数2速度设置寄存器
        TorqueSetReg2 = 0x3EE,               //预设参数2力矩设置寄存器

        PositionSetReg3 = 0x03EF,            //预设参数3位置设置寄存器
        SpeedSetReg3 = 0x03EF,               //预设参数3速度设置寄存器
        TorqueSetReg3 = 0x3F0,               //预设参数3力矩设置寄存器

        PositionSetReg4 = 0x03F1,            //预设参数4位置设置寄存器
        SpeedSetReg4 = 0x03F1,               //预设参数4速度设置寄存器
        TorqueSetReg4 = 0x3F2,               //预设参数4力矩设置寄存器

        PositionSetReg5 = 0x03F3,            //预设参数5位置设置寄存器
        SpeedSetReg5 = 0x03F3,               //预设参数5速度设置寄存器
        TorqueSetReg5 = 0x3F4,               //预设参数5力矩设置寄存器

        PositionSetReg6 = 0x03F5,            //预设参数6位置设置寄存器
        SpeedSetReg6 = 0x03F5,               //预设参数6速度设置寄存器
        TorqueSetReg6 = 0x3F6,               //预设参数6力矩设置寄存器

        PositionSetReg7 = 0x03F7,            //预设参数7位置设置寄存器
        SpeedSetReg7 = 0x03F7,               //预设参数7速度设置寄存器
        TorqueSetReg7 = 0x3F8,               //预设参数7力矩设置寄存器

        PositionSetReg8 = 0x03F9,            //预设参数8位置设置寄存器
        SpeedSetReg8 = 0x03F9,               //预设参数8速度设置寄存器
        TorqueSetReg8 = 0x3FA,               //预设参数8力矩设置寄存器
    }

    /// <summary>
    /// ID、波特率、软件版本寄存器
    /// </summary>
    public enum deviceRegs : ushort
    {
        APPVersionReg = 0x0138C,            //软件版本寄存器
        IDSetReg = 0x138D,                  //设备ID寄存器（低字节）
        BaudSetReg = 0x138E,                //设备通讯配置寄存器（低字节）
    }
    public class EPGMotionControl : EPGGetFeedbackStatus, IPubMotionControl
    {
        //public EPGMotionControl() { }
       // public EPGMotionControl(string pn, int br) : base(pn, br) { }
        public bool closeDevice(byte id)
        {
            bool result = false;
            try
            {
                base.writeSingerReg(id, (ushort)controlRegs.ControlSetReg, 0x0000);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            
            return result;
        }

        public bool fullPowerAndFullSpeedClose(byte id)
        {
            bool result = false;
            ushort[] data = { 0x040B };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool fullPowerAndFullSpeedOpen(byte id)
        {
            bool result = false;
            ushort[] data = { 0x030B };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool halfPowerAndHalfSpeedClose(byte id)
        {
            bool result = false;
            ushort[] data = { 0x020B };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();  
            }
            return result;
        }

        public bool halfPowerAndHalfSpeedOpen(byte id)
        {
            bool result = false;
            ushort[] data = { 0x010B };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool lowPowerAndLowSpeedClose(byte id)
        {
            bool result = false;
            ushort[] data = { 0x060B };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool lowPowerAndLowSpeedOpen(byte id)
        {
            bool result = false;
            ushort[] data = { 0x050B };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
                
            }
            return result;
        }

        public bool openDevice(byte id)
        {
            bool result = false;
            try
            {
                base.writeSingerReg(id, (ushort)controlRegs.ControlSetReg, 0x0001);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool setID(byte oldId, ushort setId)
        {
            bool result = false;
            try
            {
                base.writeSingerReg(oldId, (ushort)deviceRegs.IDSetReg, setId);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool setBaudRate(byte id, ushort setPaudRate)
        {
            bool result = false;
            try
            {
                base.writeSingerReg(id, (ushort)deviceRegs.BaudSetReg, setPaudRate);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool setPresetParam(byte id, ushort positionAndSpeedStartAddress, int position = 0, int speed = 0, int power = 0)
        {
            bool result = false;
            ushort position1 = (ushort)position;
            ushort speed1 = (ushort)speed;
            ushort power1 = (ushort)power;
            ushort[] speedPositionForce = { (ushort)(position1 + (speed1 << 8)), power1 };
            try
            {
                //设置速度/位置/力
                base.writeMultipleReg(id, positionAndSpeedStartAddress, speedPositionForce);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool runPresetParam(byte id, int param = 8)
        {
            bool result = false;
            ushort param1 = (ushort)param;
            ushort data = (ushort)((param1 << 8) + 0x0B);
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch 
            {
                result = false;
                throw new Exception();
            }
            return result;
        }

        public bool runNotPresetParam(byte id, int position = 0, int speed = 255, int power = 255)
        {
            bool result = false;
            ushort position1 = (ushort)position;
            ushort speed1 = (ushort)speed;
            ushort power1 = (ushort)power;
            ushort s = 0x0009;
            ushort second = (ushort)(position1 << 8);
            ushort three = (ushort)((power1 << 8) + speed1);
            ushort[] data = { s, second, three };
            try
            {
                base.writeMultipleReg(id, (ushort)controlRegs.ControlSetReg, data);
                result = true;
            }
            catch
            {
                result = false;
                throw new Exception();  
            }
            return result;
        }

        public byte[] spanID(int startId, int stopId)
        {
            List<byte> idList = new List<byte>();
            ushort[] returnData = { };
            for (int i = startId; i <= stopId; i++)
            {
                try
                {
                    returnData = base.readInputReg((byte)i, (ushort)statusRegs.FingerStatus, 0x0004);
                    if (returnData == null)
                    {

                    }
                    else 
                    {
                        idList.Add((byte)i);
                    }
                }
                catch
                {
                    continue;
                }
            }
            return idList.ToArray();
        }

        public bool setEncoder(byte id, ushort value)
        {
            bool result = false;
            try
            {
                base.writeSingerReg(id, (ushort)statusRegs.EncoderValue, value);
                    result = true;
            }
            catch
            {
                result = false;
                throw new Exception();
            }
                return result;
        }

    public bool setIOModeSwitch(byte id)
    {
        throw new NotImplementedException();
    }

    public bool setIOStateSwitch(byte id)
    {
        throw new NotImplementedException();
    }
}
}
