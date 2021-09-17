using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Plcway.Communication.Handlers;
using Plcway.Communication.Internal;

namespace Plcway.Communication.Transport.Channels
{
    /// <summary>
    /// Handler 分配调度对象
    /// </summary>
    public class ChannelHandlerDispatcher : IChannelHandlerDispatcher
    {
        private readonly CountdownEvent _countdownEvent;

        /// <summary>
        /// 初始化一个新的<see cref="ChannelHandlerDispatcher"/>实例
        /// </summary>
        /// <param name="maxsize">允许的最大任务数</param>
        public ChannelHandlerDispatcher(IOptions<DispatcherOptions> options)
        {
            _countdownEvent = new CountdownEvent(options.Value.MaxCount);
        }

        public int CurrentTaskCount => _countdownEvent.InitialCount - _countdownEvent.CurrentCount;

        public Task DispatchAsync(ChannelContext ctx)
        {
            // 阻塞，直到有可用的任务
            if (_countdownEvent.CurrentCount == 0)
            {
                _countdownEvent.Wait();
            }

            _countdownEvent.Signal();  // 当前可用数量减1

            // 启用另一线程执行任务
            _ = Task.Run(async () =>
            {
                try
                {
                    // 要执行的任务
                    var route = RouteTable.Shared.Routes[ctx.Request.Signal.Tag];
                    var handler = (IChannelHandler)InternalServiceProvider.Shared.ServiceProvider.GetRequiredService(route.HandlerType);  // 思考，如何避免使用 Service Locator 模式？
                    await handler.ExecuteAsync(ctx);
                }
                finally
                {
                    // 执行完后，当前可添加的任务数加1
                    _countdownEvent.AddCount();
                }
            });

            return Task.CompletedTask;
        }
    }
}
