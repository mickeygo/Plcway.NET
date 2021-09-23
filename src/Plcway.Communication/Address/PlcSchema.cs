namespace Plcway.Communication.Address
{
    /// <summary>
    /// PLC schema，用于描述 PLC 相关信息
    /// </summary>
    public class PlcSchema
    {
        /// <summary>
        /// IP 地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// 站号信息
        /// </summary>
        public string Station { get; set; }
    }
}
