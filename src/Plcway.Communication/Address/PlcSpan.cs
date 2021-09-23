using System.Collections.Generic;

namespace Plcway.Communication.Address
{
    /// <summary>
    /// PLC 地址分片
    /// </summary>
    public class PlcSpan
    {
        /// <summary>
        /// 分片头
        /// </summary>
        public PlcAddress Header { get; set; }

        /// <summary>
        /// 地址集合
        /// </summary>
        public ICollection<PlcAddress> Addresses { get; set; }
    }
}
