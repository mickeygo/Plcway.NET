using System;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Plcway.Communication.Transport.Channels;
using Plcway.Communication.Transport.Channels.QoS;

namespace Plcway.Communication
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加 AddPlcway 组件
        /// </summary>
        /// <param name="services"></param>
        /// <param name="actionOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlcway(this IServiceCollection services, Action<PlcwayOptions> actionOptions)
        {
            return services;
        }

        /// <summary>
        /// 添加 AddPlcway 组件
        /// </summary>
        /// <param name="services">服务</param>
        /// <param name="capacity">管道最大容量，为 null 表示无限制</param>
        /// <returns></returns>
        internal static IServiceCollection AddPlcCore(this IServiceCollection services, Action<PlcwayOptions> actionOptions)
        {
            Contract.Requires(services != null);
            Contract.Requires(actionOptions != null);

            var options = new PlcwayOptions();
            actionOptions(options);

            if (options.QoS.MaxCapacity == 0)
            {
                services.AddSingleton<IPipeChannel, DefaultPipeChannel>();
            }
            else
            {
                services.AddSingleton<IPipeChannel, DefaultPipeChannel>(sp => new DefaultPipeChannel(options.QoS.MaxCapacity));
            }

            return services;
        }

        public class PlcwayOptions
        {
            public QoSOptions QoS { get; set; }
        }
    }
}
