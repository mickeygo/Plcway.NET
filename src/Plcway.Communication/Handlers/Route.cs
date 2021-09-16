using System;

namespace Plcway.Communication.Handlers
{
    /// <summary>
    /// 路由
    /// </summary>
    public class Route
    {
        /// <summary>
        /// 路由处理类型
        /// </summary>
        public Type HandlerType { get; }

        /// <summary>
        /// 是否要回执
        /// </summary>
        public bool Ack { get; }

        public Route(Type handlerType, bool ack = false)
        {
            HandlerType = handlerType;
            Ack = ack;
        }
    }
}
