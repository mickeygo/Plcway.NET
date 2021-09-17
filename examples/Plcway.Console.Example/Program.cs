using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Plcway.Console.Example
{
    class Program
    {
        static Task Main(string[] args)
        {
            using IHost host = CreateHostBuilder(args).Build();

            ExemplifyScoping(host.Services, "Scope 1");
            ExemplifyScoping(host.Services, "Scope 2");

            return host.RunAsync();
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) => { })
               .ConfigureLogging(loggingBuilder => loggingBuilder.AddSerilog());

        static void ExemplifyScoping(IServiceProvider services, string scope)
        {
            using IServiceScope serviceScope = services.CreateScope();
            IServiceProvider provider = serviceScope.ServiceProvider;

            System.Console.WriteLine();
        }
    }

    class Startup
    {
        public Startup()
        {
            string logformat = @"{Timestamp:yyyy-MM-dd HH:mm:ss }[{Level:u3}] {Message:lj}{NewLine}{Exception}";
            Log.Logger = new LoggerConfiguration()
                          .Enrich.FromLogContext()
                          .MinimumLevel.Information()
                          .WriteTo.File("logs\\mlog.log", outputTemplate: logformat, rollingInterval: RollingInterval.Day)
                          .CreateLogger();

            var builder = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();  // 需要显示指定类型

            var serviceCollection = new ServiceCollection()
                                       .AddOptions()
                                       .AddSingleton(configuration)
                                       .AddLogging(loggingBuilder =>
                                                     loggingBuilder.AddSerilog(dispose: true)
                                                     );
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
