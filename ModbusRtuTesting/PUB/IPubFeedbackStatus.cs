using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRtuTesting.PUB
{
    public interface IPubFeedbackStatus
    {
        /// <summary>
        /// 获取使能状态
        /// </summary>
        ushort getEnableStatus(byte id);

        /// <summary>
        /// 获取制动器（抱闸）状态
        /// </summary>
        ushort getBreakStatus(byte id);

        /// <summary>
        /// 获取当前主控板温度
        /// </summary>
        ushort getTempStatus(byte id);

        /// <summary>
        /// 获取当前电压值
        /// </summary>
        ushort getVoltageStatus(byte id);

        /// <summary>
        /// 获取当前位置
        /// </summary>
        ushort getPositionStatus(byte id);

        /// <summary>
        /// 获取当前速度
        /// </summary>
        ushort getSpeedStatus(byte id);

        /// <summary>
        /// 获取当前力
        /// </summary>
        ushort getTorqueStatus(byte id);

        /// <summary>
        /// 获取掉落状态
        /// </summary>
        //bool getFallStatus(byte id);

        /// <summary>
        /// 获取电爪状态
        /// </summary>
        /// <returns>
        /// 0：电爪处于复位或者巡检状态，
        /// 1：正在激活，
        /// 2：未使用，保留，
        /// 3：激活完成
        /// </returns>
        ushort getClawStatus(byte id);

        /// <summary>
        /// 工作模式
        /// </summary>
        /// <returns>true为无输入模式，false为输入预设参数</returns>
        //string workMode(byte id);

        /// <summary>
        /// 运动状态说明
        /// </summary>
        /// <returns>
        /// 0：打开或闭合运动状态
        /// 1：闭合过程在遇到阻碍
        /// 2：打开过程中遇到阻碍
        /// 3：运动到达指定位置
        /// </returns>
        ushort moveStatus(byte id);

        /// <summary>
        /// 返回故障状态
        /// </summary>
        ushort getFaultStatus(byte id);

        /// <summary>
        /// 获取编码器状态
        /// </summary>
        /// <returns>1：编码器对零中 0：编码器已完成</returns>
        ushort getEncoderStatus(byte id);

        /// <summary>
        /// 获取编码器值
        /// </summary>
        ushort getEncoderValue(byte id);
    }
}
