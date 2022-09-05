using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using System;
using CodeMan.RabbitMq.Base.RabbitMq.Config;
using CodeMan.RabbitMq.Base.RabbitMq.Producer;
using CodeMan.RabbitMq.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMan.RabbitMq.Pay.Timeout
{
    class Program
    {
        static void Main(string[] args)
        {
            var configRabbit = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build()
                .GetSection("RabbitMQ");

            var host = new HostBuilder()
                .ConfigureServices(collection => collection
                    .AddSingleton(new RabbitConnection(configRabbit.Get<RabbitOption>()))
                    .AddSingleton<IHostedService, ProcessPayTimeout>()
                    .AddScoped<IRabbitProducer, RabbitProducer>()
                    .AddScoped<IPayService, PayService>())
                .Build();
            host.Run();
        }
    }
}
