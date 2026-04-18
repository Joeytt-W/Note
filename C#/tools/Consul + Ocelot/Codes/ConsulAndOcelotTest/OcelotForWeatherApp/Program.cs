using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("configuration.json", optional: false, reloadOnChange: true);

builder.Services
    .AddOcelot().
    AddConsul();


//∑√Œ µÿ÷∑
builder.WebHost.UseUrls($"http://{builder.Configuration["ip"]}:{builder.Configuration["port"]}");

var app = builder.Build();


app.UseOcelot();//.Wait()


app.MapControllers();

app.Run();
