using System;
using System.Diagnostics.Contracts;

namespace Plcway.Framework.Internal
{
    /// <summary>
    /// Service Local 模式。
    /// 注：仅框架内部使用。
    /// </summary>
    internal sealed class InternalServiceProvider
    {
        private static readonly object _lock = new();

        public IServiceProvider ServiceProvider { get; }

        /// <summary>
        /// 静态共享对象
        /// </summary>
        public static InternalServiceProvider Shared { get; private set; }

        private InternalServiceProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public static void OnceCreate(IServiceProvider provider)
        {
            Contract.Requires(provider != null);

            // 问题：对于 Microsoft.Extensions.DependencyInjection DI 对象，该模式产生的 Transient 对象都会被 IServiceProvider 引用，因此不会被 GC 回收。
            // 双检锁
            if (Shared == null)
            {
                lock (_lock)
                {
                    if (Shared == null)
                    {
                        Shared = new InternalServiceProvider(provider);
                    }
                }
            }
        }
    }
}
