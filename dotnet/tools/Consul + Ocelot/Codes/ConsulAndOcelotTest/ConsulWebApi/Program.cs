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
    .AddCommandLine(args)//����֧�������в���
    .Build();
//���ʵ�ַ
builder.WebHost.UseUrls($"http://{builder.Configuration["ip"]}:{builder.Configuration["port"]}");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// �������п���cors����ConfigureServices���������õĿ����������
app.UseCors("cors");

//app.UseAuthorization();
app.MapControllers();


app.UseConsul(builder.Configuration);
app.Run();
