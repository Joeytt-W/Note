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
                    //��ȡ��appsettings.json�е������ַ���
                    string sqlString = configuration.GetConnectionString("MySqlConnection");
                    //ȷ��NLog.config�������ַ�����appsettings.json��ͬ��
                    NLogUtil.EnsureNlogConfig("NLog.config", sqlString);
                }

                logService.WriteFileInfo("��������");
                host.Run();
            }
            catch (Exception ex)
            {
                //ʹ��nlogд��������־�ļ�����һ���ݿ�û����/���ӳɹ���
                string errorMessage = "��վ������ʼ�������쳣";
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
