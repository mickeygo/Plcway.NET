using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Plcway.Communication.Handlers
{
    /// <summary>
    /// 处理器路由表
    /// </summary>
    internal class RouteTable
    {
        private readonly Dictionary<string, Route> _routeCollection = new();

        /// <summary>
        /// 路由表实例
        /// </summary>
        public static RouteTable Shared = new();

        /// <summary>
        /// 获取已注册的路由
        /// </summary>
        public IReadOnlyDictionary<string, Route> Routes => _routeCollection;

        private RouteTable()
        {
        }

        /// <summary>
        /// 注册相关路由。如果路由已存在，返回 false.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool Register(string name, Route route)
        {
            Contract.Requires(name != null && route != null);

            if (_routeCollection.ContainsKey(name))
            {
                return false;
            }

            _routeCollection[name] = route;
            return true;
        }

        public void Remove(string name)
        {
            _routeCollection.Remove(name);
        }

        public void Clear()
        {
            _routeCollection.Clear();
        }
    }
}
