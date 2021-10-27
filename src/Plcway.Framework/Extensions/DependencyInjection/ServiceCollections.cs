using System;
using Microsoft.Extensions.DependencyInjection;
using Plcway.Framework.Extensions.Builder;

namespace Plcway.Framework.Extensions
{
    public static class ServiceCollections
    {
        /// <summary>
        /// 添加 PLC 服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlc(this IServiceCollection services, Action<IPlcBuilder> action)
        {
            var builder = new PlcBuilder
            {
                Services = services,
            };

            action(builder);

            return services;
        }
    }
}
