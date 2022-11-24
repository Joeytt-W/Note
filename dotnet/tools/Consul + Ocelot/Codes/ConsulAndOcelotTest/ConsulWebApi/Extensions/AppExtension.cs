using Consul;

namespace ConsulWebApi.Extensions
{
    public static class AppExtension
    {
        //服务注册
        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IConfiguration configuration)
        {
            // 获取主机生命周期管理接口
            var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();

            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            });
            var serviceId = "ConsulApi" + configuration["nameback"];
            //服务注册
            string ip = configuration["ip"]; //优先接收变量的值
            string port = configuration["port"]; //优先接收变量的值

            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = serviceId, //唯一的
                Name = "ConsulWeb", //服务集群名或组名
                Address = ip, //ip地址
                Port = int.Parse(port), //端口
                Tags = new string[] { "api站点" },//标签
                //Check = new AgentServiceCheck()
                //{
                //    Interval = TimeSpan.FromSeconds(10),//多久检查一次心跳
                //    GRPC = $"{httpContext.HttpContext?.Connection.LocalIpAddress}:{httpContext.HttpContext.Connection.LocalPort}", //gRPC注册特有
                //    GRPCUseTLS = false,//支持http
                //    Timeout = TimeSpan.FromSeconds(5),//超时时间
                //    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5) //服务停止多久后注销服务
                //}

            }).Wait();
            //应用程序终止时,注销服务
            lifetime.ApplicationStopping.Register(() =>
            {
                client.Agent.ServiceDeregister(serviceId).Wait();
            });
            return app;
        }
    }
}
