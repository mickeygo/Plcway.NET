using Microsoft.Extensions.DependencyInjection;

namespace Plcway.Framework.Extensions.Builder
{
    /// <summary>
    /// PLC 构建对象
    /// </summary>
    internal class PlcBuilder : IPlcBuilder
    {
        public IServiceCollection Services { get; set; }
    }
}
