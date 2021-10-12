using System;
using System.Threading;
using System.Threading.Tasks;

namespace Plcway.Framework.Transport.Hosting
{
    /// <summary>
    /// 主机
    /// </summary>
    public interface IHost : IDisposable
    {
        /// <summary>
        /// 主机状态
        /// </summary>
        HostState State { get; }

        /// <summary>
        /// 运行主机。
        /// </summary>
        /// <returns></returns>
        Task RunAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 启动主机。只有在 Stopped 状态下才有效。
        /// </summary>
        void Start();

        /// <summary>
        /// 停止主机。只有在 Runing 状态下才有效。
        /// </summary>
        void Stop();

        /// <summary>
        /// 关闭主机。关闭后主机不可再运行。
        /// </summary>
        void Shutdown();
    }
}
