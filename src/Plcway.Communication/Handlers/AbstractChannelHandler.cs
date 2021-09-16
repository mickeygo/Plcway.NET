using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plcway.Communication.Transport.Channels;

namespace Plcway.Communication.Handlers
{
    /// <summary>
    /// Channel 处理者抽象类
    /// </summary>
    public abstract class AbstractChannelHandler : IChannelHandler
    {
        public IServiceProvider Provider { get; private set; }

        /// <summary>
        /// 配置信息
        /// </summary>
        protected IConfiguration Configuration => GetRequiredService<IConfiguration>();

        /// <summary>
        /// 获取指定的注入服务
        /// </summary>
        /// <returns></returns>
        protected T GetRequiredService<T>() where T : notnull => Provider.GetRequiredService<T>();

        public virtual Task ExecuteAsync(ChannelContext context)
        {
            return Task.CompletedTask;
        }
    }
}
