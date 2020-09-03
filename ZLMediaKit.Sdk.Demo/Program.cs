using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Extensions.Hosting;
using System;
using System.IO;
using System.Text;

namespace ZLMediaKit.Sdk.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 支持中文编码
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(LogEventLevel.Debug)
                .Enrich.FromLogContext()
                .WriteTo.Async(c => c.File("Logs/logs.log", rollingInterval: RollingInterval.Day))
                .CreateLogger();
            try
            {
                Log.Information("Start ZLMediaKit.Sdk.Demo");
                var host = new HostBuilder().ConfigureHostConfiguration(configHost =>
                {
                    configHost.SetBasePath(Directory.GetCurrentDirectory());
                    configHost.AddJsonFile("application.json", optional: true).Build();
                    configHost.AddCommandLine(args);
                }).ConfigureAppConfiguration((context, config) => {
                }).ConfigureServices((context, services) => {
                    services.ConfigureServices(context.Configuration);
                }).ConfigureLogging(configureLogging => {
                })
                .UseConsoleLifetime().UseSerilog(Log.Logger).Build();
                var close = false;
                host.RunAsync();
                host.WaitForShutdownAsync().ContinueWith(t => close = true);
                while(!close)
                {
                }
            }
            catch (Exception)
            {

                throw;
            }
            Log.Information("Hello World!");
        }
    }
}
