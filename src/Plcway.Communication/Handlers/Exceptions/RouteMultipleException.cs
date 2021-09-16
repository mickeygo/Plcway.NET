using System;

namespace Plcway.Communication.Handlers.Exceptions
{
    /// <summary>
    /// Handler 路由重复注册异常
    /// </summary>
    public class RouteMultipleException : Exception
    {
        public RouteMultipleException(string name) : base($"The route attribute '{name}' has exist.")
        {

        }
    }
}
