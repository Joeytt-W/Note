# Cors

就是跨域资源共享

## 解决跨域访问被限制的问题



### 启用Cors

- Nuget 安装 Microsoft.AspNet.WebApi.Cors 

## 配置Cors服务

- 在 App_Start/WebApiConfig.cs文件中

```c#
//开启跨域资源访问
config.EnableCors();
```

- 具体需要哪个Controller可以跨域访问再具体使用Attribute配置

```c# 
//origins:哪个地址请求的，headers：请求头,methods:请求种类Get,Post
[EnableCors(origins:"*",headers:"*",methods:"*")]
public class StudentController : ApiController
{
    
}    
```

