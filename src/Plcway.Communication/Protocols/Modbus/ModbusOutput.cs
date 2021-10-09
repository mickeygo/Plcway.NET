namespace Plcway.Communication.Protocols.Modbus
{
    /// <summary>
    /// Modbus 读取数据输出
    /// </summary>
    public class ModbusOutput
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 站号
        /// </summary>
        public byte StationNumber { get; set; }
        /// <summary>
        /// 功能码
        /// </summary>
        public byte FunctionCode { get; set; }

        /// <summary>
        /// 数据读取结果
        /// </summary>
        public object Value { get; set; }
    }
}
