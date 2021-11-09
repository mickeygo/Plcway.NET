using System.Collections.Generic;

namespace Plcway.Communication.Address
{
    /// <summary>
    /// PLC 地址分片，包含地址头(请求标识)和详细的内容地址。
    /// </summary>
    public class PlcSpan
    {
        /// <summary>
        /// 分片头，用于标识地址发起了一次请求。
        /// </summary>
        public PlcAddress Header { get; set; }

        /// <summary>
        /// 请求中包含的数据内容地址。
        /// </summary>
        public ICollection<PlcAddress> Addresses { get; set; }
    }
}
