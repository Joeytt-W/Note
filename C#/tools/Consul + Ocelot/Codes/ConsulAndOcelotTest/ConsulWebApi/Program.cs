using ConsulWebApi.Extensions;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
    options.AddPolicy("cors",
        p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddSwaggerGen();
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddCommandLine(args)//设置支持命令行参数
    .Build();
//访问地址
builder.WebHost.UseUrls($"http://{builder.Configuration["ip"]}:{builder.Configuration["port"]}");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 允许所有跨域，cors是在ConfigureServices方法中配置的跨域策略名称
app.UseCors("cors");

//app.UseAuthorization();
app.MapControllers();


app.UseConsul(builder.Configuration);
app.Run();
