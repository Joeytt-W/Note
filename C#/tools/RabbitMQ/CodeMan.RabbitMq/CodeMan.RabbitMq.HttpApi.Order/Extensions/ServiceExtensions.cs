using CodeMan.RabbitMq.Base.RabbitMq.Config;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMan.RabbitMq.HttpApi.Order.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AnyPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
        }

        public static void ConfigureRabbitContext(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("RabbitMQ");
            services.AddSingleton(
                new RabbitConnection(section.Get<RabbitOption>()));
        }
    }
}