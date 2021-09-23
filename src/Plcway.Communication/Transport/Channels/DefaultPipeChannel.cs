using System.Threading.Channels;

namespace Plcway.Communication.Transport.Channels
{
    /// <summary>
    /// 内置有缓冲大小的通道对象
    /// </summary>
    internal class DefaultPipeChannel : IPipeChannel
    {
        public Channel<ChannelContext> Puller { get; }

        public Channel<ChannelContext> Pusher { get; }

        /// <summary>
        /// 初始化一个新的无限容量的 <see cref="DefaultPipeChannel"/> 实例
        /// </summary>
        public DefaultPipeChannel()
        {
            Puller = Channel.CreateUnbounded<ChannelContext>();
            Pusher = Channel.CreateUnbounded<ChannelContext>();
        }

        /// <summary>
        /// 初始化一个新的有固定容量的 <see cref="DefaultPipeChannel"/> 实例
        /// </summary>
        /// <param name="capacity">channel 容量大小</param>
        public DefaultPipeChannel(int capacity)
        {
            Puller = Channel.CreateBounded<ChannelContext>(capacity);
            Pusher = Channel.CreateBounded<ChannelContext>(capacity);
        }
    }
}
