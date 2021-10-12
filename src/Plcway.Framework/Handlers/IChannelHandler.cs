using System.Threading.Tasks;
using Plcway.Framework.Transport.Channels;

namespace Plcway.Framework.Handlers
{
    /// <summary>
    /// 通道消息处理器
    /// </summary>
    public interface IChannelHandler
    {
        /// <summary>
        /// 处理数据
        /// </summary>
        /// <param name="context">数据上下文</param>
        /// <returns></returns>
        Task ExecuteAsync(ChannelContext context);
    }
}
