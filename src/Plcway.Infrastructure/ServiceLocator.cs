using System;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Plcway.Infrastructure
{
    /// <summary>
    /// 服务定位器模式。基于 Microsoft.Extensions.DependencyInjection 框架。
    /// </summary>
    public class ServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly object _lock = new();

        /// <summary>
        /// ServiceLocator 实例。
        /// 对于要立即调用 Dispose() 方法的实例，应使用 CreateScope() 调用其产生的 Dispose() 方法。
        /// </summary>
        public static ServiceLocator ServiceProvider { get; private set; }

        private ServiceLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 创建服务定位器，仅能使用一次。
        /// </summary>
        /// <param name="provider"></param>
        public static void OnceCreate(IServiceProvider provider)
        {
            Contract.Requires(provider != null);

            // 问题：对于 Microsoft.Extensions.DependencyInjection DI 对象，该模式产生的 Transient 对象都会被 IServiceProvider 引用，因此不会被 GC 回收。
            // 双检锁
            if (ServiceProvider == null)
            {
                lock (_lock)
                {
                    if (ServiceProvider == null)
                    {
                        ServiceProvider = new ServiceLocator(provider);
                    }
                }
            }
        }

        public T GetRequiredService<T>() where T : notnull
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        public object GetRequiredService(Type type)
        {
            return _serviceProvider.GetRequiredService(type);
        }

        /// <summary>
        /// 创建 Scope 服务。在 Dispose 时相关的服务也会 Dispose 。
        /// 对于生命周期 Transient 和 Scoped 的实例，会在 ServiceProvider Dispose() 时调用相关实例的 Dispose() 方法。
        /// </summary>
        /// <returns></returns>
        public ServiceLocatorScope CreateScope()
        {
            var scope = _serviceProvider.CreateScope();
            return new ServiceLocatorScope(scope);
        }

        /// <summary>
        /// 基于 Scope 的服务定位器，应该调用 Dispose() 方法。
        /// </summary>
        public class ServiceLocatorScope : IDisposable
        {
            private readonly IServiceScope _scope;

            public ServiceLocatorScope(IServiceScope scope)
            {
                _scope = scope;
            }

            public T GetRequiredService<T>() where T : notnull
            {
                return _scope.ServiceProvider.GetRequiredService<T>();
            }

            public object GetRequiredService(Type type)
            {
                return _scope.ServiceProvider.GetRequiredService(type);
            }

            public void Dispose()
            {
                _scope.Dispose();
            }
        }
    }
}
