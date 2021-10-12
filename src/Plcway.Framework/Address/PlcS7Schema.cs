namespace Plcway.Communication.Address
{
    /// <summary>
    /// 西门子的地址数据信息
    /// </summary>
    public class PlcS7Schema : PlcSchema
    {
        /// <summary>
        /// 获取或设置等待读取的数据的代码
        /// </summary>
        public byte DataCode { get; set; }

        /// <summary>
        /// 获取或设置PLC的DB块数据信息
        /// </summary>
        public ushort DbBlock { get; set; }
    }
}
