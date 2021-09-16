using System.Threading.Tasks;
using Plcway.Communication.Transport.Channels;

namespace Plcway.Communication.Handlers
{
    /// <summary>
    /// 通道消息处理器
    /// </summary>
    public interface IChannelHandler
    {
        /// <summary>
        /// 执行数据
        /// </summary>
        /// <param name="context">数据上下文</param>
        /// <returns></returns>
        Task ExecuteAsync(ChannelContext context);
    }
}
