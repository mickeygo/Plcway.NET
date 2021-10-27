using System.Threading.Channels;

namespace Plcway.Framework.Transport.Channels
{
    /// <summary>
    /// 管道
    /// </summary>
    public interface IPipelineChannel
    {
        /// <summary>
        /// 数据拉取通道
        /// </summary>
        Channel<ChannelContext> Puller { get; }

        /// <summary>
        /// 数据推送通道
        /// </summary>
        Channel<ChannelContext> Pusher { get; }
    }
}
