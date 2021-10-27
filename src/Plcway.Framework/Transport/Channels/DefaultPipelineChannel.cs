using System.Threading.Channels;

namespace Plcway.Framework.Transport.Channels
{
    /// <summary>
    /// 内置有缓冲大小的通道对象
    /// </summary>
    internal class DefaultPipelineChannel : IPipelineChannel
    {
        public Channel<ChannelContext> Puller { get; }

        public Channel<ChannelContext> Pusher { get; }

        /// <summary>
        /// 初始化一个新的无限容量的 <see cref="DefaultPipelineChannel"/> 实例
        /// </summary>
        public DefaultPipelineChannel()
        {
            Puller = Channel.CreateUnbounded<ChannelContext>();
            Pusher = Channel.CreateUnbounded<ChannelContext>();
        }

        /// <summary>
        /// 初始化一个新的有固定容量的 <see cref="DefaultPipelineChannel"/> 实例
        /// </summary>
        /// <param name="capacity">channel 容量大小</param>
        public DefaultPipelineChannel(int capacity)
        {
            Puller = Channel.CreateBounded<ChannelContext>(capacity);
            Pusher = Channel.CreateBounded<ChannelContext>(capacity);
        }
    }
}
