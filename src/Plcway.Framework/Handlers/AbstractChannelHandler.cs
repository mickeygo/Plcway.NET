using System.Threading.Tasks;
using Plcway.Framework.Transport.Channels;

namespace Plcway.Framework.Handlers
{
    /// <summary>
    /// Channel 处理者抽象类
    /// </summary>
    public abstract class AbstractChannelHandler : IChannelHandler
    {
        public abstract Task<int> ExecuteAsync(ChannelContext context);
    }
}
