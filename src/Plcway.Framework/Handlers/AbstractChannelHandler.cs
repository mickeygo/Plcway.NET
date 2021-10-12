using System.Threading.Tasks;
using Plcway.Framework.Transport.Channels;

namespace Plcway.Framework.Handlers
{
    /// <summary>
    /// Channel 处理者抽象类
    /// </summary>
    public abstract class AbstractChannelHandler : IChannelHandler
    {
        /// <summary>
        /// 执行上下文任务
        /// </summary>
        /// <param name="context">上下文对象</param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(ChannelContext context);
    }
}
