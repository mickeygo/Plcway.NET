namespace Plcway.Communication.Address
{
    /// <summary>
    /// PLC 变量地址（格式统一地址）
    /// </summary>
    public class PlcAddress
    {
        /// <summary>
        /// 唯一标签名
        /// </summary>
        public string Tag { get; set; }

        /// <summary>
        /// 变量地址 (字符串格式)
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 变量长度
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// 变量类型
        /// </summary>
        public PlcVarType VarType { get; set; }

        /// <summary>
        /// 地址描述
        /// </summary>
        public string? Desc { get; set; }

        /// <summary>
        /// 额外标志
        /// </summary>
        public string[]? Flag { get; set; }
    }
}
