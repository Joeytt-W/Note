using CodeMan.Redis.Base.EntityFrameworkCore;
using CodeMan.Redis.Base.EntityFrameworkCore.Repository;
using CodeMan.Redis.Base.Redis;
using CodeMan.Redis.Service.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMan.Redis.HttpApi.Extensions
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

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("redisTestDb");
            services.AddDbContext<RedisDbContext>(
                builder => builder.UseMySql(connectionString, ServerVersion.Parse("5.7")));
        }

        public static void ConfigureRedisContext(this IServiceCollection services, IConfiguration config)
        {
            var section = config.GetSection("Redis:Default");
            services.AddSingleton(new RedisConfig(section.Get<RedisOption>()));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
