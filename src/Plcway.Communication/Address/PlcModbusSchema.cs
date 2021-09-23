namespace Plcway.Communication.Address
{
    /// <summary>
    /// Modbus协议地址格式，可以携带站号，功能码，地址信息
    /// </summary>
    public class PlcModbusSchema : PlcSchema
    {
        /// <summary>
        /// 获取或设置当前地址携带的功能码
        /// </summary>
        public int Function { get; set; }
    }
}
