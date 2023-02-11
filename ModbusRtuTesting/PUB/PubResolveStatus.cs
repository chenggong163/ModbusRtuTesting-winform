using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusRtuTesting.PUB
{
    internal interface PubResolveStatus
    {
        /// <summary>
        /// 获取使能状态
        /// </summary>
        /// <returns>true为使能打开，false为使能关闭</returns>
        bool getEnableStatus();

        /// <summary>
        /// 获取制动器状态
        /// </summary>
        /// <returns>true为打开，false为关闭</returns>
        bool getBreakStatus();

        /// <summary>
        /// 获取当前主控板温度
        /// </summary>
        /// <returns></returns>
        byte[] getTempStatus();

        /// <summary>
        /// 获取当前电压值
        /// </summary>
        /// <returns></returns>
        byte? getVoltageStatus();

        /// <summary>
        /// 获取当前位置
        /// </summary>
        /// <returns></returns>
        byte[] getPositionStatus();

        /// <summary>
        /// 获取当前速度
        /// </summary>
        /// <returns></returns>
        byte[] getSpeedStatus();

        /// <summary>
        /// 获取当前力矩
        /// </summary>
        /// <returns></returns>
        byte[] getTorqueStatus();

        /// <summary>
        /// 获取掉落状态
        /// </summary>
        /// <returns></returns>
        bool getFallStatus();

        /// <summary>
        /// 获取电爪状态
        /// </summary>
        /// <returns>0：电爪处于复位或者巡检状态，1：正在激活，2：未使用，保留，3：激活完成</returns>
        byte getCurrerStatus();


    }
}
