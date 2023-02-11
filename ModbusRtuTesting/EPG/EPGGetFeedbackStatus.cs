using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using ModbusRtuTesting.PUB;

namespace ModbusRtuTesting.EPG
{
    public class EPGGetFeedbackStatus : ModbusRtu, IPubFeedbackStatus
    {
        //public EPGGetFeedbackStatus(){ }
        //public EPGGetFeedbackStatus(string pn, int br) : base(pn, br) { }
        public ushort getBreakStatus(byte id)
        {
            ushort[] result = new ushort[1];
            try
            {
                result = base.readInputReg(id, (ushort)statusRegs.BrakeStatus, 0x0001);
            }
            catch
            {
                throw new Exception();
            }
            int value = (int)(result[0] & 0x0001);
            return result[0];
        }

        public ushort getClawStatus(byte id)
        {
            ushort[] workStatus = new ushort[1];
            try
            {
                workStatus = base.readInputReg(id, (ushort)statusRegs.FingerStatus, 0x0001);
            }
            catch
            {
                throw new Exception();
            }
            ushort moveEn = (byte)(workStatus[0] & 0x0011);
            return moveEn;
        }

        public ushort getEnableStatus(byte id)
        {
            ushort enableStatus = 0;
            try
            {
                ushort[] outStatus = base.readInputReg(id, (ushort)statusRegs.FingerStatus, 0x0001);
                enableStatus = (ushort)(outStatus[0] & 0x0001);
            }
            catch
            {
                throw new Exception();
            }
                return enableStatus;
        }

        public ushort getEncoderStatus(byte id)
        {
            ushort[] result = new ushort[1];
            try
            {
                result = base.readInputReg(id, (ushort)statusRegs.EncoderStatus, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            return result[0];
        }

        public ushort getEncoderValue(byte id)
        {
            ushort[] result = new ushort[1];
            try
            {
                result = base.readInputReg(id, (ushort)statusRegs.EncoderValue, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            return result[0];
        }

        public ushort getFallStatus(byte id)
        {
            ushort[] workStatus = new ushort[1];
            try
            {
                workStatus = base.readInputReg(id, (ushort)statusRegs.FingerStatus, 0x0001);
            }
            catch { throw new Exception(); }
            ushort mode = (ushort)(workStatus[0] >> 6);
            return mode;
        }

        public ushort getFaultStatus(byte id)
        {
            ushort[] data = new ushort[1];
            ushort result = 0;
            try
            {
                data = base.readInputReg(id, (ushort)statusRegs.PositionAndFaultStatus, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            result = (ushort)(data[0] & 0x00ff);
            return (ushort)(result);
        }

        public ushort getPositionStatus(byte id)
        {
            ushort positionStatus;
            ushort[] data = new ushort[1];
            try 
            {
                data = base.readInputReg(id, (ushort)statusRegs.PositionAndFaultStatus, 0x0001);
            }
            catch
            {
                positionStatus= 0;
            }
            positionStatus = (ushort)(data[0] >> 8);
            return positionStatus;
        }

        public ushort getSpeedStatus(byte id)
        {
            ushort[] data = new ushort[1];
            ushort speedStatus = 0;
            try
            {
                data = base.readInputReg(id, (ushort)statusRegs.PowerAndSpeedStatus, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            speedStatus = (ushort)((data[0] & 0X00FF));
            return speedStatus;
        }

        public ushort getTempStatus(byte id)
        {
            ushort[] data = new ushort[1];
            ushort temp = 0;
            try
            {
                data = base.readInputReg(id, (ushort)statusRegs.TempAndVoltageStatus, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            temp = (ushort)(data[0] >> 8);
            return temp;
        }

        public ushort getTorqueStatus(byte id)
        {
            ushort[] data = new ushort[1];
            ushort torqueStatus = 0;
            try 
            {
                data = base.readInputReg(id, (ushort)statusRegs.PowerAndSpeedStatus, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            torqueStatus = (ushort)((data[0] >> 8));
            return torqueStatus;
        }

        public ushort getVoltageStatus(byte id)
        {
            ushort[] data = new ushort[1];
            ushort voltageStatus = 0;
            try 
            {
                data = base.readInputReg(id, (ushort)statusRegs.TempAndVoltageStatus, 0x0001);
            }
            catch 
            {
                throw new Exception();
            }
            voltageStatus = (ushort)(data[0] & 0x00ff);
            return voltageStatus;
        }

        public ushort moveStatus(byte id)
        {
            ushort[] workStatus = new ushort[1];
            ushort mode = 0;
            try
            {
                workStatus = base.readInputReg(id, (ushort)statusRegs.FingerStatus, 0x0001);
            }
            catch { throw new Exception(); }
            
            mode = (ushort)(workStatus[0] >> 4);
            ushort moveEn = (ushort)(mode & 0011);
            return moveEn;
        }

        public ushort workMode(byte id)
        {
            ushort[] workStatus = new ushort[1];
            try
            {
                workStatus = base.readInputReg(id, (ushort)statusRegs.FingerStatus, 0x0001);
            }
            catch { throw new Exception(); }
            ushort mode = (ushort)(workStatus[0] >> 6);
            return mode;
        }

    }
}
