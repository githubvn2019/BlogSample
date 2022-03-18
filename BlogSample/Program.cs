using BlogSample.Core.Configs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Json;

namespace BlogSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var webHost = Host.CreateDefaultBuilder(args);

            #region ConfigureAppConfiguration

            webHost = webHost
                    .ConfigureAppConfiguration((context, cnf) =>
                    {
                        AppSettings.Configs = cnf.Build();
                        AppSettings.Instance = AppSettings.Configs.GetSection("AppSettings").Get<AppSettings>();
                    })
                    .UseSerilog();
            #endregion

            webHost = webHost
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls();
                    webBuilder.UseIISIntegration();
                    webBuilder.UseStartup<Startup>();
                });

            return webHost;
        }
    }
}
