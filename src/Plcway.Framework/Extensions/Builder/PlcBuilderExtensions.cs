using Microsoft.Extensions.DependencyInjection;
using Plcway.Communication.Core;

namespace Plcway.Framework.Extensions.Builder
{
    public static partial class PlcBuilderExtensions
    {
        /// <summary>
        /// 应用 Modbus 协议
        /// </summary>
        public static void UseModbus(this IPlcBuilder builder)
        {
        }

        /// <summary>
        /// 应用西门子S7协议
        /// </summary>
        public static void UseSiemensS7(this IPlcBuilder builder)
        {
        }

        /// <summary>
        /// 应用欧姆龙协议
        /// </summary>
        public static void UseOmronFins(this IPlcBuilder builder)
        { 
        }

        /// <summary>
        /// 应用三菱协议
        /// </summary>
        public static void UseMelsec(this IPlcBuilder builder)
        {
        }

        /// <summary>
        /// 应用 AB 协议
        /// </summary>
        public static void UseAllenBradley(this IPlcBuilder builder)
        {

        }
    }
}
