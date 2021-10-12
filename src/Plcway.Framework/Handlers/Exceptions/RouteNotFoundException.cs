using System;

namespace Plcway.Framework.Handlers.Exceptions
{
    /// <summary>
    /// 没有找到指定路由异常
    /// </summary>
    public class RouteNotFoundException : Exception
    {
        public RouteNotFoundException(string name) : base($"The route '{name}' is not found.")
        {

        }
    }
}
