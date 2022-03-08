using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ManterClasseAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var columnOption = new ColumnOptions();
                    columnOption.Store.Remove(StandardColumn.MessageTemplate);
                    columnOption.Store.Remove(StandardColumn.Level);
                    columnOption.Store.Remove(StandardColumn.Exception);
                    columnOption.Store.Remove(StandardColumn.Properties);

                    var configurationRoot = config.Build();

                    Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Warning()
                        .WriteTo.MSSqlServer(configurationRoot.GetConnectionString("ManterClasseAPIContext"),
                            sinkOptions: new MSSqlServerSinkOptions
                            {
                                AutoCreateSqlTable = true,
                                TableName = "LogsQuielManterClasse"
                            },
                            columnOptions: columnOption)
                        .CreateLogger();
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
