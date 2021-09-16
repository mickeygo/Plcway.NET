using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Plcway.Communication.Handlers.Exceptions;

namespace Plcway.Communication.Handlers
{
    /// <summary>
    /// 处理器终结点
    /// </summary>
    public class HandlerEndpoint
    {
        /// <summary>
        /// 
        /// </summary>
        public void RegisterAttrubteRoute(Assembly[] assemblies)
        {
            Contract.Requires(assemblies != null);

            // 从程序集中找到有 RouteAttribute 注解并集成了 IChannelHandler 的实体类
            var types = assemblies.SelectMany(s => s.GetTypes()).Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(IChannelHandler)));
            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<RouteAttribute>();
                if (attr == null)
                {
                    continue;
                }

                if (!RouteTable.Shared.Register(attr.Name, new Route(type, attr.Ack)))
                {
                    throw new RouteMultipleException(attr.Name);
                }
            }
        }

        /// <summary>
        /// 映射 name 到指定类型上
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="ack">是否需要回执</param>
        public void Map<T>(string name, bool ack = false) where T : IChannelHandler
        {
            Contract.Requires(name != null);

            if (!RouteTable.Shared.Register(name, new Route(typeof(T), ack)))
            {
                throw new RouteMultipleException(name);
            }
        }
    }
}
