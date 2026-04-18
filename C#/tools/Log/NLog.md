# 地址

[配置文件说明地址（github地址）](https://github.com/NLog/NLog/wiki/Tutorial)

## LogLevel

- `Trace` - 非常详细的日志，其可以包括诸如协议有效载荷之类的大容量信息。 此日志级别通常仅在开发期间启用
- `Debug` - 调试信息，比跟踪更少，通常在生产环境中启用
- `Info` - 信息消息，通常在生产环境中启用
- `Warn` - 警告消息，通常用于非关键问题，可以恢复或临时失败
- `Error` - 错误消息 - 大部分时间都是例外情况
- `Fatal` - 非常严重的错误！

## 路由规则

- name - 日志源/记录者的名字 (允许使用通配符*)
- ``minlevel`` - 匹配日志范围的最低级别
- ``maxlevel``- 匹配日志范围的最高级别
- level - 匹配的单一日志级别
- levels - 匹配的一系列日志级别，由逗号分隔。
- ``writeTo`` - 规则匹配时日志应该被写入的一系列目标<target>节点的name属性，由逗号分隔。
- final - 标记当前规则为最后一个规则。其后的规则即时匹配也不会被运行。

## Layout上下文信息

- [${date}](https://github.com/NLog/NLog/wiki/Date-Layout-Renderer) - Current date and time.
- [${longdate}](https://github.com/NLog/NLog/wiki/LongDate-Layout-Renderer) - The date and time in a long, sortable format `yyyy-MM-dd HH:mm:ss.ffff`.
- [${qpc}](https://github.com/NLog/NLog/wiki/QPC-Layout-Renderer) - High precision timer, based on the value returned from QueryPerformanceCounter.
- [${shortdate}](https://github.com/NLog/NLog/wiki/ShortDate-Layout-Renderer) - The short date in a sortable format yyyy-MM-dd.
- [${ticks}](https://github.com/NLog/NLog/wiki/Ticks-Layout-Renderer) - The Ticks value of current date and time.
- [${time}](https://github.com/NLog/NLog/wiki/Time-Layout-Renderer) - The time in a 24-hour, sortable format HH:mm:ss.mmm.
- [${guid}](https://github.com/NLog/NLog/wiki/Guid-Layout-Renderer) - Globally-unique identifier(GUID).
- [${aspnet-mvc-action}](https://github.com/NLog/NLog/wiki/AspNet-MVC-Action-Layout-Renderer)) - ASP.NET MVC action name [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)

- [${aspnet-mvc-controller}](https://github.com/NLog/NLog/wiki/AspNet-MVC-Controller-Layout-Renderer) - ASP.NET MVC controller name [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request}](https://github.com/NLog/NLog/wiki/AspNetRequest-layout-renderer) - ASP.NET Request variable. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-contenttype}](https://github.com/NLog/NLog/wiki/AspNet-Request-ContentType-layout-renderer) - ASP.NET Content-Type header (Ex. application/json) [**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-cookie}](https://github.com/NLog/NLog/wiki/AspNetRequest-Cookie-Layout-Renderer) - ASP.NET Request cookie content. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-form}](https://github.com/NLog/NLog/wiki/AspNetRequest-Form-Layout-Renderer) - ASP.NET Request form content. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-headers}](https://github.com/NLog/NLog/wiki/AspNetRequest-Headers-Layout-Renderer) - ASP.NET Header key/value pairs. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-host}](https://github.com/NLog/NLog/wiki/AspNetRequest-Host-Layout-Renderer) - ASP.NET Request host. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-ip}](https://github.com/NLog/NLog/wiki/AspNet-Request-IP-Layout-Renderer) - Client IP. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-method}](https://github.com/NLog/NLog/wiki/AspNetRequest-Method-Layout-Renderer) - ASP.NET Request method (GET, POST etc). [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-posted-body}](https://github.com/NLog/NLog/wiki/AspNet-Request-posted-body-layout-renderer) - ASP.NET posted body / payload [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-querystring}](https://github.com/NLog/NLog/wiki/AspNetRequest-QueryString-Layout-Renderer) - ASP.NET Request querystring. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-url}](https://github.com/NLog/NLog/wiki/AspNetRequest-Url-Layout-Renderer) - ASP.NET Request URL. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-request-useragent}](https://github.com/NLog/NLog/wiki/AspNetRequest-UserAgent-Layout-Renderer) - ASP.NET Request useragent. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-response-statuscode}](https://github.com/NLog/NLog/wiki/AspNetResponse-StatusCode-Layout-Renderer) - ASP.NET Response status code content. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-session}](https://github.com/NLog/NLog/wiki/AspNetSession-layout-renderer) - ASP.NET Session variable. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-sessionid}](https://github.com/NLog/NLog/wiki/AspNetSessionId-layout-renderer) - ASP.NET Session ID variable. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-traceidentifier}](https://github.com/NLog/NLog/wiki/AspNetTraceIdentifier-Layout-Renderer) - ASP.NET trace identifier [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-user-authtype}](https://github.com/NLog/NLog/wiki/AspNetUserAuthType-layout-renderer) - ASP.NET User auth. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-user-claim}](https://github.com/NLog/NLog/wiki/AspNet-User-Claim-layout-renderer) - ASP.NET User Claims authorization values [**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-user-identity}](https://github.com/NLog/NLog/wiki/AspNetUserIdentity-layout-renderer) - ASP.NET User variable. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-user-isauthenticated}](https://github.com/NLog/NLog/wiki/AspNet-User-isAuthenticated-Layout-Renderer) - ASP.NET User authenticated? [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${aspnet-webrootpath}](https://github.com/NLog/NLog/wiki/AspNet-WebRootPath-layout-renderer) - ASP.NET Web root path (wwwroot) [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)
- [${iis-site-name}](https://github.com/NLog/NLog/wiki/IIS-site-name-Layout-Renderer) - IIS site name. [**NLog.Web**](https://www.nuget.org/packages/NLog.Web)[**NLog.Web.AspNetCore**](https://www.nuget.org/packages/NLog.Web.AspNetCore)

```xml
<?xml version="1.0" encoding="utf-8"?>
<nlog xmlns="http://www.nlog-project.org/schemas/NLog.xsd"
      xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
      throwExceptions="true" internalLogFile="Logs/nlog.txt" internalLogLevel="Debug">
    <!--具体配置可参考官方示例：https://github.com/jkowalski/NLog/tree/master/examples/targets/Configuration%20File -->
    <targets async="true">
        <!--将日志输出到控制台-->
        <target name="console" xsi:type="ColoredConsole"
                layout="${longdate}|${callsite}|${uppercase:${level}}|${message}"/>
        
        <!--将日志输出到文件-->
        <target name="file" xsi:type="File"
                fileName="${basedir}/Logs/${shortdate}/${level}.log"
                layout="日志时间：${longdate}${newline}日志级别：${uppercase:${level}}${newline}
操作账号：${hostname}${newline}
操作者IP：${aspnet-request-ip}${newline}
IP归属地：${aspnet-request-host}${newline}
浏 览 器：${iis-site-name}${newline}
操作模块：${aspnet-mvc-action}${newline}
提示信息：${message}${newline}"/>
        
        <!--将日志输出到邮箱-->
        <target name="mail" xsi:type="Mail"
                smtpServer="test.163.com"
                smtpPort="25"
                smtpAuthentication="Basic"
                smtpUserName="Framework.MainWeb"
                smtpPassword="gaoyang1112"
                enableSsl="true"
                addNewLines="true"
                from="Framework.MainWeb@163.com"
                to="784725567@qq.com"
                subject="[Framework.MainWeb]系统日志报告"
                body="日志时间：${longdate}${newline}
日志级别：${uppercase:${level}}${newline}
操作用户：${event-context:item=Account}${newline}
操作者IP：${event-context:item=IP}${newline}
IP归属地：${event-context:item=IPAddress}${newline}
浏 览 器：${event-context:item=Browser}${newline}
操作模块：${event-context:item=Operation}${newline}
提示信息：${message}${newline}" />
        <!--将日志输出到数据库-->
        <target name="db" xsi:type="Database" connectionString="Data Source=127.0.0.1; Initial Catalog=FrameworkDev;User ID=sa;Password=wang0705">
            <commandText>
                INSERT INTO DevLogs ([CreateTime], [LogLevel], [Message], [StackTrace], [Account], [RealName], [Operation], [IP], [IPAddress], [Browser])
                values(@CreateTime, @LogLevel, @Message, @StackTrace,  @Account, @RealName, @Operation, @IP, @IPAddress, @Browser);
            </commandText>
            <parameter name="@CreateTime" layout="${date}" />
            <parameter name="@LogLevel" layout="${uppercase:${level}}" />
            <parameter name="@Message" layout="${message}" />
            <parameter name="@StackTrace" layout="${stacktrace}" />
            <parameter name="@Account" layout="${hostname} " />
            <parameter name="@RealName" layout="${hostname} " />
            <parameter name="@Operation" layout="${aspnet-mvc-action}" />
            <parameter name="@IP" layout="${aspnet-request-ip}" />
            <parameter name="@IPAddress" layout="${aspnet-request-host} " />
            <parameter name="@Browser" layout="${iis-site-name}" />
        </target>
    </targets>
    <rules>
        <!--<logger name="*" levels="Error,Fatal" writeTo="mail" />-->
        <logger name="ToFileLog" minlevel="Info" writeTo="file" />
        <logger name="ToDBLog" level="Fatal" writeTo="db"/>
        <logger name="ToCwLog" levels="Debug,Trace" writeTo="console"/>
    </rules>
    <extensions>
        <add assembly="NLog.Web"/>
    </extensions>
</nlog>
```

## .net

```c#
    /// <summary>
    /// NLog日志框架辅助类。
    /// </summary>
    public static class LogHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 注册日志配置文件。
        /// </summary>
        public static void RegisterConfig()
        {
            string configPath = AppDomain.CurrentDomain.BaseDirectory + @"\NLog.config";
            LogManager.Configuration = new XmlLoggingConfiguration(configPath);
        }

        /// <summary>
        /// 记录日志。
        /// </summary>
        /// <param name="level">日志级别</param>
        /// <param name="operation">动作</param>
        /// <param name="message">消息</param>
        /// <param name="account">操作者</param>
        /// <param name="realName">真实姓名</param>
        public static void Write(LogLevel level, string operation, string message, string account, string realName)
        {
            logger.Log(LogEventInfoInstance(message, level, account, realName, operation));
        }

        /// <summary>
        /// 最常见的记录信息，一般用于普通输出。
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(string message)
        {
            logger.Trace(message);
        }

        /// <summary>
        /// 同样是记录信息，不过出现的频率要比Trace少一些，一般用来调试程序。
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            logger.Debug(message);
        }

        /// <summary>
        /// 信息类型的消息。
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            logger.Info(message);
        }

        /// <summary>
        /// 警告信息，一般用于比较重要的场合。
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            logger.Warn(message);
        }

        /// <summary>
        /// 错误信息。
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            logger.Error(message);
        }

        /// <summary>
        /// 致命异常信息。一般来讲，发生致命异常之后程序将无法继续执行。
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            logger.Fatal(message);
        }



        private static LogEventInfo LogEventInfoInstance(string message, LogLevel level,string account,string realName)
        {
            LogEventInfo logEvent = new LogEventInfo
            {
                Message = message, 
                Level = level
            };
            logEvent.Properties["Account"] = account;
            logEvent.Properties["RealName"] = realName;
            logEvent.Properties["Browser"] = Net.Browser;
            return logEvent;
        }
    }
```

## .net core

###  program.cs

```c#
using System;
using NLog.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

public static void Main(string[] args)
{
    var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
    try
    {
        logger.Debug("init main");
        CreateHostBuilder(args).Build().Run();
    }
    catch (Exception exception)
    {
        //NLog: catch setup errors
        logger.Error(exception, "Stopped program because of exception");
        throw;
    }
    finally
    {
        // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
        NLog.LogManager.Shutdown();
    }
}

public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .ConfigureWebHostDefaults(webBuilder =>
      {
          webBuilder.UseStartup<Startup>();
      })
      .ConfigureLogging(logging =>
      {
          logging.ClearProviders();
          logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
      })
      .UseNLog();  // NLog: Setup NLog for Dependency injection
```

### 配置appsettings.json

``AppSettings.json``中指定的日志记录配置覆盖了对``SetMinimumLevel``的任何调用。 所以要么删除“默认”：或正确调整到您的需求。

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Trace",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

### 写日志

```c#
using Microsoft.Extensions.Logging;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _logger.LogDebug(1, "NLog injected into HomeController");
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Hello, this is the index!");
        return View();
    }
}
```

