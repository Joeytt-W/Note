using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;

var builder = WebApplication.CreateBuilder(args);

//添加EntityFrameworkCore的SQLServer支持
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

// 告诉应用程序 如果请求使用HTTP协议 则重定向到HTTPS协议
app.UseHttpsRedirection();

// 将请求映射到控制器
app.MapControllers();

// 路由
// "/shirts"
//app.MapGet("/shirts", () =>
//{
//    return new[] { "Red Shirt", "Blue Shirt", "Green Shirt" };
//});

//app.MapGet("/shirts/{id}", (int id) =>
//{
//    return $"shirt id:{id}";
//});

//app.MapPost("/shirts", () =>
//{
//    return "创建一件衬衫";
//});

//app.MapPut("/shirts/{id}", (int id) =>
//{
//    return $"更新衬衫：{id}";
//});

//app.MapDelete("/shirts/{id}", (int id) =>
//{
//    return $"删除衬衫：{id}";
//});

app.Run();

