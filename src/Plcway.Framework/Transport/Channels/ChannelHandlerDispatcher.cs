using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Plcway.Framework.Handlers;
using Plcway.Framework.Internal;

namespace Plcway.Framework.Transport.Channels
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
            // 要执行的任务
            // TODO: 记录触发任务

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
                    var route = RouteTable.Shared.Routes[ctx.Request.Signal.Tag];
                    var handler = (IChannelHandler)InternalServiceProvider.Shared.ServiceProvider.GetRequiredService(route.HandlerType);  // 思考，如何避免使用 Service Locator 模式？
                    // TODO: 记录任务执行的开始时间
                    await handler.ExecuteAsync(ctx);
                }
                catch (Exception ex)
                { 
                    // TODO: 捕获异常，并记录
                }
                finally
                {
                    // TODO: 记录任务执行的结束时间

                    // 执行完后，当前可添加的任务数加1
                    _countdownEvent.AddCount();
                }
            });

            return Task.CompletedTask;
        }
    }
}
