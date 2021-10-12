using System.Threading.Tasks;

namespace Plcway.Framework.Transport.Channels
{
    /// <summary>
    /// 处理任务派发对象
    /// </summary>
    public interface IChannelHandlerDispatcher
    {
        /// <summary>
        /// 当前正在执行的任务数量
        /// </summary>
        int CurrentTaskCount { get; }

        /// <summary>
        /// 派发任务
        /// </summary>
        /// <param name="ctx">要执行的上下文对象</param>
        Task DispatchAsync(ChannelContext ctx);
    }
}
