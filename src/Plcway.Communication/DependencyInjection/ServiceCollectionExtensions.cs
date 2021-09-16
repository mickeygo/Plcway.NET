using System;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Plcway.Communication.Transport.Channels;

namespace Plcway.Communication.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加 AddPlcway 组件
        /// </summary>
        /// <param name="services">服务</param>
        /// <param name="capacity">管道最大容量，为 null 表示无限制</param>
        /// <returns></returns>
        internal static IServiceCollection AddPlcCore(this IServiceCollection services, Action<Options> actionOptions)
        {
            Contract.Requires(services != null);
            Contract.Requires(actionOptions != null);

            var options = new Options();
            actionOptions(options);

            if (options.Capacity == null)
            {
                services.AddSingleton<IPipelineChannel, DefaultPipelineChannel>();
            }
            else
            {
                services.AddSingleton<IPipelineChannel, DefaultPipelineChannel>(sp => new DefaultPipelineChannel(options.Capacity.Value));
            }

            return services;
        }

        public class Options
        {
            public int? Capacity { get; set; }
        }
    }
}
