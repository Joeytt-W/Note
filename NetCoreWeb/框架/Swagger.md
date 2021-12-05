## 安装Swashbuckle.AspNetCore

Nuget安装

## 添加并配置 Swagger 中间件

将 Swagger 生成器添加到 `Startup.ConfigureServices` 方法中的服务集合中：

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<TodoContext>(opt =>
        opt.UseInMemoryDatabase("TodoList"));
    services.AddMvc()
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

    // Register the Swagger generator, defining 1 or more Swagger documents
 services.AddSwaggerGen();
}
//在 Startup.Configure 方法中，启用中间件为生成的 JSON 文档和 Swagger UI 提供服务：public void Configure(IApplicationBuilder app)
{
    // Enable middleware to serve generated Swagger as a JSON endpoint.
 app.UseSwagger();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
    // specifying the Swagger JSON endpoint.
 app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
}

```

## 生成方法说明xml和取消警告

Xml文件输出路径为默认（startup.cs同一级）即可

![](images/049.png)

## API 信息和说明

传递给 `AddSwaggerGen` 方法的配置操作会添加诸如作者、许可证和说明的信息：

using Microsoft.OpenApi.Models;

使用 `OpenApiInfo` 类修改 UI 中显示的信息：

```c#
// Register the Swagger generator, defining 1 or more Swagger documents
services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "A simple example ASP.NET Core Web API",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Shayne Boyer",
            Email = string.Empty,
            Url = new Uri("https://twitter.com/spboyer"),
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/license"),
        }
});
// 为 Swagger JSON and UI设置xml文档注释路径
var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);//获取应用程序所在目录(绝对，不受工作目录影响，建议采用此方法获取路径)
var xmlPath = Path.Combine(basePath, "ERP.Api.xml");
c.IncludeXmlComments(xmlPath);
});
```

## 修改默认打开页面

修改launchSetting.json文件

"launchUrl": "swagger/index.html",

