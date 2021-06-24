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

# CSRF

CSRF（Cross-site request forgery）跨站请求伪造，也被称为“One Click Attack”或者Session Riding，通常缩写为CSRF或者XSRF，是一种对网站的恶意利用

需要在view加上Html.AntiForgeryToken()防止CSRF攻击，还需要在目标action上增加[ValidateAntiForgeryToken]特性*它主要检查*

(1)请求的是否包含一个约定的AntiForgery名的cookie

(2)请求是否有一个Request.Form["约定的AntiForgery名"]，约定的AntiForgery名的cookie和Request.Form值是否匹配
