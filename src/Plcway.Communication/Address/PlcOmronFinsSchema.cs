namespace Plcway.Communication.Address
{
    /// <summary>
    /// 欧姆龙的Fins协议的地址类对象
    /// </summary>
    public class PlcOmronFinsSchema : PlcSchema
    {
        /// <summary>
        /// 进行位操作的指令
        /// </summary>
        public byte BitCode { get; set; }

        /// <summary>
        /// 进行字操作的指令
        /// </summary>
        public byte WordCode { get; set; }
    }
}
