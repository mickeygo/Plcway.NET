using System.Collections.Generic;

namespace Plcway.Communication.Address
{
    /// <summary>
    /// PLC 分组对象
    /// </summary>
    public class PlcGroup<T> where T : PlcSchema
    {
        /// <summary>
        /// 分组唯一名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// PLC schema
        /// </summary>
        public T Schema { get; set; }

        /// <summary>
        /// PLC 地址分片集合。
        /// 为了提升数据扫描的性能，需要将标识为请求的地址按顺序排列。
        /// </summary>
        public ICollection<PlcSpan> Spans { get; set; }
    }
}
