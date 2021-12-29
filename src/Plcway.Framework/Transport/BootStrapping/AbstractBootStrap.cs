using System;
using System.Diagnostics.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plcway.Framework.Handlers;
using Plcway.Framework.Transport.Hosting;

namespace Plcway.Framework.Transport.BootStrapping
{
    /// <summary>
    /// 启动项基类
    /// </summary>
    public abstract class AbstractBootStrap
    {
        public IServiceCollection ServiceCollection { get; private set; }

        public AbstractBootStrap()
        {
            
        }

        public AbstractBootStrap CreateBuilder()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();  // 需要显示指定类型
            ServiceCollection = new ServiceCollection()
                                       .AddOptions()
                                       .AddSingleton(configuration);
            return this;
        }

        public AbstractBootStrap UseBuilder(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
            return this;
        }

        public AbstractBootStrap ConfigureAppConfiguration()
        {
            return this;
        }

        public AbstractBootStrap ConfigurServices(Action<IServiceCollection> action)
        {
            Contract.Requires(action != null);
            action(ServiceCollection);

            return this;
        }

        public AbstractBootStrap ConfigureHandler(Action<HandlerEndpoint> action)
        {
            Contract.Requires(action != null);
            action(new HandlerEndpoint());

            return this;
        }

        public IHost Build()
        {
            return default;
        }
    }
}
