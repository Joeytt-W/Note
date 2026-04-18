using Core.Entity.Enum;
using Core.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utility.LogHelper;

namespace CoreApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var logService = host.Services.GetRequiredService<IWriteLog>();
            try
            {
                using (IServiceScope scope = host.Services.CreateScope())
                {
                    IConfiguration configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                    //获取到appsettings.json中的连接字符串
                    string sqlString = configuration.GetConnectionString("MySqlConnection");
                    //确保NLog.config中连接字符串与appsettings.json中同步
                    NLogUtil.EnsureNlogConfig("NLog.config", sqlString);
                }

                logService.WriteFileInfo("程序启动");
                host.Run();
            }
            catch (Exception ex)
            {
                //使用nlog写到本地日志文件（万一数据库没创建/连接成功）
                string errorMessage = "网站启动初始化数据异常";
                logService.WriteFileLog(NLog.LogLevel.Error, Core.Utility.LogType.Web, errorMessage, new Exception(errorMessage, ex));
                throw;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging => {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                }).UseNLog();
    }
}
