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
        /// PLC 地址分片集合
        /// </summary>
        public ICollection<PlcSpan> Spans { get; set; }
    }
}
