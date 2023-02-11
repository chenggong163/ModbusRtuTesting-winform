using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRtuTesting.PUB
{
    public interface IPubMotionControl
    {
        /// <summary>
        /// 使能设备
        /// </summary>
        /// <param name="id"></param>
        bool openDevice(byte id);

        /// <summary>
        /// 禁用设备
        /// </summary>
        /// <param name="id"></param>
        bool closeDevice(byte id);

        /// <summary>
        /// 全力全速打开
        /// </summary>
        bool fullPowerAndFullSpeedOpen(byte id);

        /// <summary>
        /// 全力全速关闭
        /// </summary>
        bool fullPowerAndFullSpeedClose(byte id);

        /// <summary>
        /// 半力半速打开
        /// </summary>
        bool halfPowerAndHalfSpeedOpen(byte id);

        /// <summary>
        /// 半力半速关闭
        /// </summary>
        bool halfPowerAndHalfSpeedClose(byte id);

        /// <summary>
        /// 低力低速打开
        /// </summary>
        bool lowPowerAndLowSpeedOpen(byte id);

        /// <summary>
        /// 低力低速关闭
        /// </summary>
        bool lowPowerAndLowSpeedClose(byte id);

        /// <summary>
        /// 设置编码器寄存器
        /// </summary>
        bool setEncoder(byte id, ushort value);

        /// <summary>
        /// 设置制动器
        /// </summary>
        /// <param name="id"></param>
        //void setBrake(byte id);

        /// <summary>
        /// 读取预设参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="paraNumber">读取几个预设参数，默认是8个</param>
        /// <returns></returns>
        //ushort[] readPresetParam(byte id, ushort paraNumber = 7);

        /// <summary>
        /// 设置预设参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position">位置</param>
        /// <param name="speed">速度</param>
        /// <param name="power">力</param>
        /// <param name="paramNumber">预设参数，默认为0</param>
        bool setPresetParam(byte id, ushort positionAndSpeedStartAddress, int position = 0, int speed = 0, int power = 0);

        /// <summary>
        /// 执行预设参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="param">预设参数的序号，不能大于8小于1</param>
        /// <returns></returns>
        bool runPresetParam(byte id, int param);

        /// <summary>
        /// 执行非预设参数，需要手动传入参数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        bool runNotPresetParam(byte id, int position, int speed = 255, int power = 255);

        /// <summary>
        /// 扫描当前ID
        /// </summary>
        /// <returns></returns>
        byte[] spanID(int startId, int stopId);

        /// <summary>
        /// 设置设备ID
        /// </summary>
        /// <param name="id"></param>
        /// <param name="setid">需要设置的ID</param>
        /// <returns></returns>
        bool setID(byte id, ushort setId);

        /// <summary>
        /// 设置设备波特率
        /// </summary>
        /// <param name="id"></param>
        /// <param name="setid">需要设置的波特率</param>
        /// <returns></returns>
        bool setBaudRate(byte id, ushort setPaudRate);

        /// <summary>
        /// 设置IO模式切换
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool setIOModeSwitch(byte id);

        /// <summary>
        /// 设置IO状态切换
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool setIOStateSwitch(byte id);
    }
}
