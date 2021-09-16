using Microsoft.Extensions.DependencyInjection;

namespace Plcway.Communication.Transport.BootStrapping
{
    public static class Extensions
    {
        /// <summary>
        /// 添加 AddPlcway 组件
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPlcway(this IServiceCollection services)
        {
            return services;
        }
    }
}
