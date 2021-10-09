namespace Plcway.Communication.Protocols.Modbus
{
    /// <summary>
    /// Modbus 参数输入
    /// </summary>
    public class ModbusInput
    {
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 数据类型
        /// </summary>
        public DataTypeEnum DataType { get; set; }

        /// <summary>
        /// 站号
        /// </summary>
        public byte StationNumber { get; set; }

        /// <summary>
        /// 功能码
        /// </summary>
        public byte FunctionCode { get; set; }
    }
}
