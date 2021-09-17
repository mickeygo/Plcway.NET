using System.Collections.Generic;
using System.Linq;

namespace Plcway.Communication.Transport.Channels
{
    /// <summary>
    /// 传输通道上下文对象
    /// </summary>
    public class ChannelContext
    {
        /// <summary>
        /// 事务 Id
        /// </summary>
        public long TransactionId { get; }

        /// <summary>
        /// 请求上下文数据
        /// </summary>
        public RequestContext Request { get; }

        /// <summary>
        /// 响应上下文数据
        /// </summary>
        public ResponseContext Response { get; }

        public ChannelContext(long transactionId, Schema schema, IEnumerable<ChannalData> request)
        {
            TransactionId = transactionId;
            Request = new RequestContext(schema, request);
            Response = new ResponseContext(schema);
        }
    }

    /// <summary>
    /// PLC 数据读取上下文
    /// </summary>
    public class RequestContext
    {
        /// <summary>
        /// Schema
        /// </summary>
        public Schema Schema { get; }

        /// <summary>
        /// 触发请求的标签
        /// </summary>
        public ChannalData Signal { get; }

        /// <summary>
        /// 请求的数据集合
        /// </summary>
        public IReadOnlyList<ChannalData> Values { get; }

        public RequestContext(Schema schema, IEnumerable<ChannalData> values)
        {
            Schema = schema;
            Values = values.ToList();
        }
    }

    /// <summary>
    /// PLC 数据回写上下文
    /// </summary>
    public class ResponseContext
    {
        /// <summary>
        /// Schema
        /// </summary>
        public Schema Schema { get; }

        /// <summary>
        /// 响应回写的数据
        /// </summary>
        public List<ChannalData> Values { get; } = new List<ChannalData>();

        public ResponseContext(Schema schema)
        {
            Schema = schema;
        }
    }
}
