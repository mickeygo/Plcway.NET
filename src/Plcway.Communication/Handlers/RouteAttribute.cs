using System;
using System.Diagnostics.Contracts;

namespace Plcway.Communication.Handlers
{
    /// <summary>
    /// 数据处理路由
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class RouteAttribute : Attribute
    {
        public string Name { get; }

        public bool Ack { get; }

        public RouteAttribute(string name, bool ack = false)
        {
            Contract.Requires(!string.IsNullOrWhiteSpace(name));

            Name = name;
            Ack = ack;
        }
    }
}
