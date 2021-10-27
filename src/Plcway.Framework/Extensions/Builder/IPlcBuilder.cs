using Microsoft.Extensions.DependencyInjection;

namespace Plcway.Framework.Extensions.Builder
{
    /// <summary>
    /// PLC 构建对象接口
    /// </summary>
    public interface IPlcBuilder
    {
        IServiceCollection Services { get; }
    }
}
