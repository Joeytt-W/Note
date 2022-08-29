

## 一、ASP.NET MVC

![image-20210424100212897](images/image-20210424100212897.png)

ASP.NET MVC：

1.Version：5.2.7.0

2.AssemblyInfo：发布后，项目的dll文件一个总的描述

3.App_Data：数据脚本/数据库文件

4.App_Start包含了程序初始化需要的一个类

5.Content：保存css文件

6.fonts：保存字体文件

7.Scripts：保存JS文件

8.Controller：存控制器，控制业务业务逻辑，选择数据传输。。。。，

9.Models： 存放实体对象

10.Views：表现层：和用户直接交互的界面

11.Global：全局的配置文件，MVC程序的启动是从这里开始的

12.Web.Config：MVC程序的配置文件

### 1.MVC生命周期

![](images\002.png)

### 2.内置对象

### Request

> 服务器接收客户端数据

1. Request.QueryString                 ============》        Get请求

```c#
 	public class HomeController : Controller
    {
        //对应地址:https://localhost:44301/home/index?name=张三
        public ActionResult Index()
        {
            return Content(Request.QueryString["name"]);
            //return View();
        }
    }        
```

![img](images\1.png)

2. Request.Form                        ==========》         Post请求

```c#
		public ActionResult PostData()
        {
            return Content($"{Request.Form["LoginName"]} ==== {Request.Form["Password"]}");
        }
```

3. Request.Files                    =============》          File（文件大小有限制的）

```c#
		public ActionResult FileData()
        {
            //SaveAs方法需要物理路径
            Request.Files["files"].SaveAs(Request.MapPath("~/uploads/"+Request.Files["files"].FileName));
            return Content("ok");
        }
```

```html
	<!--enctype="multipart/form-data 设置上传文件-->
    <form method="post" action="/Home/FileData" enctype="multipart/form-data">
        <input type="file" name="files" value="" />
        <button>提交</button>
    </form>
```

4. Request.Headers          =====》    获取请求头

### Response

1. Response.Write      ===》 向客户端输出内容
2. Response.Redirect   ===》重定向
3. Response.Headers    ===》  设置响应头

### Session

> 数据保存在服务器，只能用来存储少量重要数据，默认存活时间20分钟

```c#
            //设置和读取Session数据
			Session["LoginName"] = Request.Form["LoginName"];
            return Content((string) Session["LoginName"]);

			//Session.Clear();//Ssession.Abandon();//销毁session
```

### Cookie

```c#
 			Response.Cookies.Add(new HttpCookie("token")
            {
                Value = "1651sdfsdf",
                Expires = DateTime.Now.AddDays(7)//设置过期时间
            });


			//获取
			Request.Cookies.Get("token")?.ToString();

			//清除
			Response.Cookies.Add(new HttpCookie("token")
            {
                Value = "1651sdfsdf",
                Expires = DateTime.Now.AddDays(-1)//设置过期时间
            });
```

### Application

```c#
 		//存Application
		public ActionResult ApplicationData()
        { 
            HttpContext.Application["LoginName"] = Request.Form["LoginName"];

            return Content("");
        }

		//取Application
        public ActionResult GetApplicationData()
        {
            return Content((string) HttpContext.Application["LoginName"]);
        }
```

### Server

```c#
			//转发  不能转发外站
            Server.Transfer("/ShowDemo.html");
			//Server.MapPath();虚拟路径传物理路径
			//Server.HtmlDecode();
			//Server.HtmlEncode();
			//Server.UrlDecode();
			//Server.UrllEncode();
```

ASP.NET 开发： WebForm开发

1.aspx文件：涵盖了MVC中三个元素的事儿

## 二、项目发布  IIS发布

1.依赖于Window---依赖IIS---无法跨平台的

2.安装IIS---作为服务器  （本地）

3.启动或关闭Window功能

4.安装Interface Infamation Service  （建议全部安装）

5.Window服务器版  （window云服务器）---通过服务器管理期来增加角色和功能



准备发布：

1.打开IIS

2.添加一个网站。物理路径指向--项目的根目录，设定一个端口号（建议在5000---10000之间）

3.直接访问

发布：

右键鼠标，选择发布按钮---设置一些配置；可以发布了



问题：权限问题；

配置网站所在物理路径的权限：

1.增加账号IUSR ---设置权限为完全控制；

2.增加账号IIS_IUSRS ---设置权限为完全控制；



## 三、开发功能开发-数据传值方式

MVC开发开始，新建控制器，实现数据传递

### ViewData

```c#
//后端   不能跨页面
ViewData["Study"] = "64651";
```

```c#
@*前端*@
@ViewData["Study"]
```

### ViewBag

```c#
//后端   ViewData和ViewBag中的值可以互相访问，因为ViewBag的实现中包含了ViewData
//ViewBag 不再是字典的键值对结构，而是 dynamic 动态类型，它会在程序运行的时候动态解析
ViewBag.Content = "这是Study/Index";
```

```c#
@*前端*@
@ViewBag.Content
```

### Model

```c#
public ActionResult ShowData()
        {
            List<Student> students = new List<Student>();
            for (int i = 0; i < 5; i++)
            {
                students.Add(new Student()
                {
                    Id = i.ToString(),
                    Name = "Names" + i
                });
            }
            return View(new Test()
            {
                Students = students
            });
        }
```

```c#
<table class="table">
@foreach (var student in Model.Students)
{
    <tr>
        <td>@student.Id</td>
        <td>@student.Name</td>
    </tr>    
}
</table>
```

### TempData

```c#
//存储之后只能读取一次，可以跨页面  保存在Session中
TempData["hello"] = "hello";
```

```c#
@TempData["hello"]
```

### Session 

## 四、ASP.NET MVC 集成日志log4net

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <!-- 一. 添加log4net的自定义配置节点-->
  <configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,log4net" />
  </configSections>
  <!--二. log4net的核心配置代码-->
  <log4net>
    <!--1. 输出途径(一) 将日志以回滚文件的形式写到文件中-->

    <!--模式一：全部存放到一个文件夹里-->
    <appender name="log0" type="log4net.Appender.RollingFileAppender">
      <!--1.1 文件夹的位置（也可以写相对路径）-->
      <param name="File"  value="D:\MyLog\" />
      <!--相对路径-->
      <!--<param name="File"  value="Logs/" />-->
      <!--1.2 是否追加到文件-->
      <param name="AppendToFile" value="true" />
      <!--1.3 使用最小锁定模型（minimal locking model），以允许多个进程可以写入同一个文件 -->
      <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
      <!--1.4 配置Unicode编码-->
      <Encoding value="UTF-8" />
      <!--1.5 是否只写到一个文件里-->
      <param name="StaticLogFileName" value="false" />
      <!--1.6 配置按照何种方式产生多个日志文件 （Date：日期、Size：文件大小、Composite：日期和文件大小的混合方式）-->
      <param name="RollingStyle" value="Composite" />
      <!--1.7 介绍多种日志的的命名和存放在磁盘的形式-->
      <!--1.7.1 在根目录下直接以日期命名txt文件 注意"的位置,去空格 -->
      <param name="DatePattern" value="yyyy-MM-dd".log"" />
      <!--1.7.2 在根目录下按日期产生文件夹，文件名固定 test.log  -->
      <!--<param name="DatePattern" value="yyyy-MM-dd/"test.log""  />-->
      <!--1.7.3 在根目录下按日期产生文件夹，这是按日期产生文件夹，并在文件名前也加上日期  -->
      <!--<param name="DatePattern" value="yyyyMMdd/yyyyMMdd"-test.log""  />-->
      <!--1.7.4 在根目录下按日期产生文件夹，这再形成下一级固定的文件夹  -->
      <!--<param name="DatePattern" value="yyyyMMdd/"OrderInfor/test.log""  />-->
      <!--1.8 配置每个日志的大小。【只在1.6 RollingStyle 选择混合方式与文件大小方式下才起作用！！！】可用的单位:KB|MB|GB。不要使用小数,否则会一直写入当前日志，
      超出大小后在所有文件名后自动增加正整数重新命名，数字最大的最早写入。-->
      <param name="maximumFileSize" value="10MB" />
      <!--1.9 最多产生的日志文件个数，超过则保留最新的n个 将value的值设置-1，则不限文件个数 【只在1.6 RollingStyle 选择混合方式与文件大小方式下才起作用！！！】
        与1.8中maximumFileSize文件大小是配合使用的-->
      <param name="MaxSizeRollBackups" value="5" />
      <!--1.10 配置文件文件的布局格式，使用PatternLayout，自定义布局-->
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="记录时间：%date %n线程ID:[%thread] %n日志级别：%-5level %n出错类：%logger property: [%property{NDC}] - %n错误描述：%message%newline %n%newline"/>
      </layout>
    </appender>

    <!--模式二：分文件夹存放-->
    <!--文件夹1-->
    <appender name="log1" type="log4net.Appender.RollingFileAppender">
      <param name="File"  value="D:\MyLog\OneLog\" />
      <param name="AppendToFile" value="true" />
      <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
      <Encoding value="UTF-8" />
      <param name="StaticLogFileName" value="false" />
      <param name="RollingStyle" value="Composite" />
      <param name="DatePattern" value="yyyy-MM-dd".log"" />
      <param name="maximumFileSize" value="10MB" />
      <param name="MaxSizeRollBackups" value="5" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%message%newline" />
      </layout>
      <!--下面是利用过滤器进行分文件夹存放,两种过滤器进行配合-->
      <!--与Logger名称(OneLog)匹配，才记录,-->
      <filter type="log4net.Filter.LoggerMatchFilter">
        <loggerToMatch value="OneLog" />
      </filter>
      <!--阻止所有的日志事件被记录-->
      <filter type="log4net.Filter.DenyAllFilter" />
    </appender>
    <!--文件夹2-->
    <appender name="log2" type="log4net.Appender.RollingFileAppender">
      <param name="File"  value="D:\MyLog\TwoLog\" />
      <param name="AppendToFile" value="true" />
      <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
      <Encoding value="UTF-8" />
      <param name="StaticLogFileName" value="false" />
      <param name="RollingStyle" value="Composite" />
      <param name="DatePattern" value="yyyy-MM-dd".log"" />
      <param name="maximumFileSize" value="10MB" />
      <param name="MaxSizeRollBackups" value="5" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%message%newline" />
      </layout>
      <!--下面是利用过滤器进行分文件夹存放,两种过滤器进行配合-->
      <!--与Logger名称(TwoLog)匹配，才记录,-->
      <filter type="log4net.Filter.LoggerMatchFilter">
        <loggerToMatch value="TwoLog" />
      </filter>
      <!--阻止所有的日志事件被记录-->
      <filter type="log4net.Filter.DenyAllFilter" />
    </appender>


    <!--2. 输出途径(二) 记录日志到数据库-->
    <appender name="AdoNetAppender" type="log4net.Appender.AdoNetAppender">
      <!--2.1 设置缓冲区大小，只有日志记录超设定值才会一块写入到数据库-->
      <param name="BufferSize" value="1" />
      <!--2.2 引用-->
      <connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
      <!--2.3 数据库连接字符串-->
      <connectionString value="data source=localhost;initial catalog=LogDB;integrated security=false;persist security info=True;User ID=sa;Password=123456" />
      <!--2.4 SQL语句插入到指定表-->
      <commandText value="INSERT INTO LogInfor ([threadId],[log_level],[log_name],[log_msg],[log_exception],[log_time]) VALUES (@threadId, @log_level, @log_name, @log_msg, @log_exception,@log_time)" />
      <!--2.5 数据库字段匹配-->
      <!-- 线程号-->
      <parameter>
        <parameterName value="@threadId" />
        <dbType value="String" />
        <size value="100" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%thread" />
        </layout>
      </parameter>
      <!--日志级别-->
      <parameter>
        <parameterName value="@log_level" />
        <dbType value="String" />
        <size value="100" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%level" />
        </layout>
      </parameter>
      <!--日志记录类名称-->
      <parameter>
        <parameterName value="@log_name" />
        <dbType value="String" />
        <size value="100" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%logger" />
        </layout>
      </parameter>
      <!--日志信息-->
      <parameter>
        <parameterName value="@log_msg" />
        <dbType value="String" />
        <size value="5000" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%message" />
        </layout>
      </parameter>
      <!--异常信息  指的是如Infor 方法的第二个参数的值-->
      <parameter>
        <parameterName value="@log_exception" />
        <dbType value="String" />
        <size value="2000" />
        <layout type="log4net.Layout.ExceptionLayout" />
      </parameter>
      <!-- 日志记录时间-->
      <parameter>
        <parameterName value="@log_time" />
        <dbType value="DateTime" />
        <layout type="log4net.Layout.RawTimeStampLayout" />
      </parameter>
    </appender>


    <!--(二). 配置日志的的输出级别和加载日志的输出途径-->
    <root>
      <!--1. level中的value值表示该值及其以上的日志级别才会输出-->
      <!--OFF > FATAL(致命错误) > ERROR（一般错误） > WARN（警告） > INFO（一般信息） > DEBUG（调试信息）  > ALL  -->
      <!--OFF表示所有信息都不写入，ALL表示所有信息都写入-->
      <level value="ALL"></level>
      <!--2. append-ref标签表示要加载前面的日志输出途径代码  通过ref和appender标签的中name属性相关联-->

      <!--<appender-ref ref="AdoNetAppender"></appender-ref>-->
      <appender-ref ref="log0"></appender-ref>
      <appender-ref ref="log1"></appender-ref>
      <appender-ref ref="log2"></appender-ref>
    </root>
  </log4net>

</configuration>
```

```c#
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ypf.Utils
{
    public class LogUtils
    {
        //声明文件夹名称(这里分两个文件夹)
        static string log1Name = "OneLog";
        static string log2Name = "TwoLog";

        //可以声明多个日志对象
        //模式一：不分文件夹
        public static ILog log = LogManager.GetLogger(typeof(LogUtils));

        //模式二：分文件夹
        //如果是要分文件夹存储，这里的名称需要和配置文件中loggerToMatch节点中的value相配合
        //1. OneLog文件夹
        public static ILog log1 = LogManager.GetLogger(log1Name);
        //2. TwoLog文件夹
        public static ILog log2 = LogManager.GetLogger(log2Name);

        #region 01-初始化Log4net的配置
        /// <summary>
        /// 初始化Log4net的配置
        /// xml文件一定要改为嵌入的资源
        /// </summary>
        public static void InitLog4Net()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var xml = assembly.GetManifestResourceStream("Ypf.Utils.log4net.xml");
            log4net.Config.XmlConfigurator.Configure(xml);
        }
        #endregion

        /************************* 五种不同日志级别 *******************************/
        //FATAL(致命错误) > ERROR（一般错误） > WARN（警告） > INFO（一般信息） > DEBUG（调试信息）

        #region 00-将调试的信息输出，可以定位到具体的位置（解决高层封装带来的问题）
        /// <summary>
        /// 将调试的信息输出，可以定位到具体的位置（解决高层封装带来的问题）
        /// </summary>
        /// <returns></returns>
        private static string getDebugInfo()
        {
            StackTrace trace = new StackTrace(true);
            return trace.ToString();
        }
        #endregion

        #region 01-DEBUG（调试信息）
        /// <summary>
        /// DEBUG（调试信息）
        /// </summary>
        /// <param name="msg">日志信息</param>
        ///  <param name="logName">文件夹名称</param>
        public static void Debug(string msg, string logName = "")
        {
            if (logName == "")
            {
                log.Debug(getDebugInfo() + msg);
            }
            else if (logName == log1Name)
            {
                log1.Debug(msg);
            }
            else if (logName == log2Name)
            {
                log2.Debug(msg);
            }
        }
        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="exception">错误信息</param>
        public static void Debug(string msg, Exception exception)
        {
            log.Debug(getDebugInfo() + msg, exception);
        }

        #endregion

        #region 02-INFO（一般信息）
        /// <summary>
        /// INFO（一般信息）
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="logName">文件夹名称</param>
        public static void Info(string msg, string logName = "")
        {
            if (logName == "")
            {
                log.Info(getDebugInfo() + msg);
            }
            else if (logName == log1Name)
            {
                log1.Info(msg);
            }
            else if (logName == log2Name)
            {
                log2.Info(msg);
            }
        }
        /// <summary>
        /// Info
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="exception">错误信息</param>
        public static void Info(string msg, Exception exception)
        {
            log.Info(getDebugInfo() + msg, exception);
        }
        #endregion

        #region 03-WARN（警告）
        /// <summary>
        ///WARN（警告）
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="logName">文件夹名称</param>
        public static void Warn(string msg, string logName = "")
        {
            if (logName == "")
            {
                log.Warn(getDebugInfo() + msg);
            }
            else if (logName == log1Name)
            {
                log1.Warn(msg);
            }
            else if (logName == log2Name)
            {
                log2.Warn(msg);
            }
        }
        /// <summary>
        /// Warn
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="exception">错误信息</param>
        public static void Warn(string msg, Exception exception)
        {
            log.Warn(getDebugInfo() + msg, exception);
        }
        #endregion

        #region 04-ERROR（一般错误）
        /// <summary>
        /// ERROR（一般错误）
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="logName">文件夹名称</param>
        public static void Error(string msg, string logName = "")
        {
            if (logName == "")
            {
                log.Error(getDebugInfo() + msg);
            }
            else if (logName == log1Name)
            {
                log1.Error(msg);
            }
            else if (logName == log2Name)
            {
                log2.Error(msg);
            }
        }
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="exception">错误信息</param>
        public static void Error(string msg, Exception exception)
        {
            log.Error(getDebugInfo() + msg, exception);
        }
        #endregion

        #region 05-FATAL(致命错误)
        /// <summary>
        /// FATAL(致命错误)
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="logName">文件夹名称</param>
        public static void Fatal(string msg, string logName = "")
        {
            if (logName == "")
            {
                log.Fatal(getDebugInfo() + msg);
            }
            else if (logName == log1Name)
            {
                log1.Fatal(msg);
            }
            else if (logName == log2Name)
            {
                log2.Fatal(msg);
            }
        }
        /// <summary>
        /// Fatal
        /// </summary>
        /// <param name="msg">日志信息</param>
        /// <param name="exception">错误信息</param>
        public static void Fatal(string msg, Exception exception)
        {
            log.Fatal(getDebugInfo() + msg, exception);
        }

        #endregion



    }
}
```

## 五、Global   区域

Global.asax：全局文件

是一个文本文件，它提供全局可用代码。这些代码包括应用程序的事件处理程序以及会话事件、方法和静态变量。有时该文件也被称为应用程序文件

MvcApplication：MVC应用程序：

Application_Start，程序的入口，程序启动，从这里开始执行；且每一次启动这里只执行一次；

 

区域：开发的时候，功能模块可能会很多，权限管理，用户管理，。。。。。。如果能够按照每一个模块的划分，进行模块化开发；

每一个模块都可以对应一个MVC基架！  每一个板块的职责就更加清晰；  

组件化---模块化开发；



## 六、路由

```c#
public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
```

一、路由。

生活中的路由---路由器----转发信号

ASP.NET MVC  Route---转发请求---1.客户端发起请求---2.到达IIS---3.转发到程序集---4.经过一个路由匹配----转发到匹配的控制器---匹配的Action中去处理

二、忽略路由

1.路由经过匹配---走找到控制器---找到Action去执行去了；
2.在MVC之前都是使用WebForm---aspx页面；
3.IIS--如何处理---通过后缀来匹配的---aspx---转发到webform处理流程；
4.MVC出现后，MVC没有后缀，IIS如何匹配---IIS打了一个补丁----如果监听到是MVC请求，就给添加一个后缀；
5.再后来，IIS升级后，可以支持MVC了，不需要通过后缀来匹配了；
6.之前的这个补丁---添加后缀----就没有必要；
7.为了兼容之前的版本---来一个忽略，如果遇到以 XXXX.axd结尾的，就忽略掉；

## 七、MVC插件式开发

 一、MVC是固定模式的，自己定义的Controller一定是写在文件夹Controllers下的；

我们写的控制器其实可以在其他的地方；

为什么？

因为网站在启动的时候，需要做初始化--扫描控制器，然后保存控制器；

扫描控制器的规则：看是否继承自Controller父类；    当请求来了，要真的使用这个控制器的实例的是偶，是从存储介质中取出来然后进行初始化的；

可以把控制器的部分（逻辑计算的部分可以独立开，放到一个类库中来）；

把一个大的业务逻辑，做拆分；每一个类库分别处理部分内容；每一块内容当做一个插件来完成；

大项目---模块----独立出来做一个插件；

部署的时候；只要是把所有的插件加载进来，就可以做到多个插件组合成了一个大平台；



二、热插拔---网站没有停止；

如果有新的功能发布，不需要停止服务器；可以把一个新的插件给发布上去；

1.准备好插件

2.触发一个增量初始化的动作----注册路由规则，扫描控制器。。。。

## 九.Razor语法-混编

一、在视图中可以写入各种Html标签

二、CShtml：并不是一个html页，而是一个CS文件---  识别html各种标签

MVC:可以由后台程序员全权完成整个项目开发；

1.CS类型---后台代码的文件

2.cshtml既可以写html，也可以写后台代码---需要增加一个@{}，在{}中可以写后台代码

~~~
@{int i = 3; int m = 4;}
~~~

## 十、Razor扩展

### 一、常用HtmlHepler

```c#
@Html.ActionLink("LinkText","ActionName")
@Html.ActionLink("LinkText", "ActionName","ControllerName")
@Html.ActionLink("LinkText", "ActionName",new {id=1,name="张三"})
@Html.ActionLink("LinkText", "ActionName",new {id=1,name="张三"},new{@class = "active",style="width: 200px;",tt="xxx"})
@Html.TextBox("NameId")
@Html.TextBox("NameId","Value")
@Html.TextBox("NameId", "Value", new { @class = "classText",@style="width:200px" })    
@Html.Hidden("NameId")
@Html.Hidden("NameId", "Value")
@Html.Password("NameId")
@Html.Password("NameId", "Value")
@Html.CheckBox("NameId", true)
@Html.CheckBox("NameId", false)
@* 这些另一种写法 *@
@Html.CheckBoxFor(a =>a.IsVaild, new { @class = "checkBox" })    
@Html.RadioButton("NameId","Value", true) @* true就是被选中 *@
@Html.RadioButton("NameId", "Value", false)
    
    
@*=========================================================================*@
@{
        SelectListItem item;
        List<SelectListItem> list = new List<SelectListItem>();
        for(int i=1;i<5;i++)
        {
            item = new SelectListItem();
            item.Text = "Text" + i;
            item.Value = "Value" + i;
            item.Selected = (i==2);
            list.Add(item);
        }       
}
@*下拉菜单*@
@Html.DropDownList("Id", list)
Html.DropDownListFor(a => a.Text, list, "--Select One--", new { @class = "dropdownlist" })    
@*多选列表框*@   
@Html.ListBox("NameId", list)    
```

### 二、自定义htmlhelper。

​      各种html标签可以通过后台语言来进行生成。

```c#
public static class HtmlExtensions
    {
        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            var builder = new TagBuilder("br");
		   //return new HtmlString(string.Format("<span style='font-weight:bold;'>Hello-{0}-End</span>", value));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt, string title,
            object htmlAttribute, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("Img");
            builder.MergeAttribute("src",src);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("class", defaultClass);
            builder.MergeAttributes<string,object>(new RouteValueDictionary(htmlAttribute));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
```

```c#
@using AspNet.Project.Extensions;

@Html.Br()
```

## 十一、页面布局

新建的项目中，默认的页面展示其实是分为上中下三个板块；

上：header

中：body

下：Footer

请求不同的的页面，其实只是中间的body部分在变化，header和footer部分没有任何变化。

在默认情况下，cshtml页面的加载：都需要需要加载一个ViewStart；ViewStart把cshtml嵌套在内； viewStart 可以删除；

~~~
Layout = "~/Views/Shared/_Layout.cshtml";
~~~

在ViewStart中使用了layout="引入母版页"

母版页：一个页面的布局结构；

母版页提供一个 @RenderBody()      区域占位符；  当我们需要展示页面的时候，把页面嵌套在母版页的 @RenderBody()的位置，形成一个大的页面；组合起来就是我们看到的页面内容；

母版页就是一个公共的区域：如果我们在页面中，每个页面都需要使用到的组件 ---JS   css。。。就可以直接引入到母版页;其他的页面也就都可以使用了‘



### 指定母版与加载机制

我们来看_ViewStart.chhtml页面，它的内容很简单:

```
@{
    Layout = "~/Views/Shared/_Layout.cshtml";
}
```

这句代码指定了默认的母版的位置: 当前应用程序根目录下<"~"的含义>的Views/Shared/_Layout.cshtml

除非特殊情况，比如视图是Partial视图，或显示的在视图中添加以下代码指示不使用母版:

```
@{
    Layout = null;
}
```

## 十二、JS/CSS压缩

App_Start/BundleConfig.cs

```c#
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
```



## 十三、MVC连接数据做数据交互--EF6



## 十四、分层架构

三层架构：

a.UI层           ：MVC

b.业务逻辑层： 暂时没有---已完成

1.一个抽象+一个实现

c.数据访问层：  EF6



## 十五、IOC容器Unity

在分层架构以后，为了做到层和层之间的解耦；需要依赖注入，就必须要使用到IOC容器了。

### 1、Unity初步使用：

准备工作：抽象和细节；

抽象：接口/抽象列

细节：普通类

Unity开始使用；

1.Nuget引入unity程序集

2.实例化IUnityContainer

~~~
IUnityContainer container = new UnityContainer();
~~~

3.注册抽象和细节的关系

~~~
 container.RegisterType<ITestServiceA, TestServiceA>();
~~~

4.获取对象的实例

~~~
ITestServiceA testServiceA= container.Resolve<ITestServiceA>();
~~~

IOC容器的作用：创建对象；---本质就是一个工厂；

### 2、依赖注入

依赖注入：构建某一个对象的时候，如果对象A依赖于对象B，在构建对象A的时候，自动把对象B构建好，传递进来！

三种：构造函数注入+属性注入+方法注入；

构造函数传递：构造函数注入

属性传递：       属性注入，需要在属性上面标记一个特性

~~~
 [Dependency]
 public TestServiceA _TestServiceA { get; set; }
~~~

方法参数传递：

在构造完了对象以后，然后根据需要，去执行某一个方法，也会根据这个方法需要的参数，自动构造出对象，然后传递给方法的参数；

~~~
  [InjectionMethod]
  public void InitService(TestServiceB testServiceB)
  {
       this._TestServiceBNew = testServiceB;
       Console.WriteLine($"{this.GetType().Name}.Show....");
  }
~~~

## 十六、IOC容器整合MVC

如果要获取全套的IOC的技术资源；可以添加Richard老师的微信：MrRichard2020；

一、通过配置文件整合IOC容器到MVC

1.Nuget引入程序集： Unity.Container+Unity.Configuration+Unity.Abstractions

2.增加配置文件+在Unity节点下配置需要的服务，注册抽象和具体之间的关系； 设置为始终复制

3.读取配置文件，把配置文件的信息，注册到UnityContainer容器中

4.就可以获取实例了

使用IOC---现在的情况代码很多；

封装一下.做一个容器单例模式；提高性能；

## 十七、MVC +  IOC支持AOP扩展

AOP面向切面编程：

可以在不修改之前业务逻辑的基础上，动态的增加新的功能；

可以在执行某一个行为之前做点什么事儿？  查询一个用户；  在查询用户之前---检查一下参数+  记录一下日志

一、Unity支持AOP

1.Nuget引入  Unity.Interception.Configuration +Unity.Interception 程序集

2.增加配置文件的节点

~~~~
 <sectionExtension type="Microsoft.Practices.Unity.InterceptionExtension.Configuration.InterceptionConfigurationExtension, Unity.Interception.Configuration"/>
~~~~

3.增加节点：

~~~~
 <extension type="Interception"/>
~~~~

4.增加需要的AOP动作，新增一个类，这个类必须实现IInterceptionBehavior接口

~~~
 public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
  {

            //如果继续往后执行：
            IMethodReturn methodReturn = getNext()(input, getNext);

            return methodReturn;
  }
~~~

5.把Aop扩展增加到配置文件中去

~~~
 <register type="ZhaoXi.Bussiness.Interface.ICompanyService,ZhaoXi.Bussiness.Interface" mapTo="ZhaoXi.Bussiness.Service.CompanyService,ZhaoXi.Bussiness.Service">
            <interceptor type="InterfaceInterceptor"/>
            <!--<interceptionBehavior type="ZhaoXi.ASP.NET.MVC5.Project.Utility.AOP.LogBeforeBehavior, ZhaoXi.ASP.NET.MVC5.Project"/>-->
            <interceptionBehavior type="ZhaoXi.ASP.NET.MVC5.Project.Utility.AOP.LogAfterBehavior, ZhaoXi.ASP.NET.MVC5.Project"/>
        </register>
~~~

## 十八.控制器支持构造函数注入

一.如何做到控制器支持构造函数注入呢？

IOC容器就是用来创建对象的实例的；---依赖注入；

二、调用MVC中的某一个Action(方法)---一定要先实例化控制器的；

如果能够使用IOC容器来创建控制器的实例i---就可以直接通过依赖注入把我们需要的Service给注入进来；

经过源码解读：

三、Mvc的控制器其实是通过一个控制器工厂来创建；

控制器既然是有工厂来创建，如果我们给换一个工厂，就可以自定义工厂如何去创建控制器的实例；

默认获取的控制器工厂是DefaultControllerFactory；

四、如果我们需要换一个工厂，就可以把这个DefaultControllerFactory替换掉，就可以自己定义创建控制器的动作；

让我们自己定义的控制器工厂在框架中生效呢？

做到了自己定义的控制器工厂生效了；

请求来了以后，会先进入到控制器工厂，然后再通过工厂去实例化控制器；



## 十九、ASP.NET MVC对AOP的支持

## Filters

1.Action   对于方法Aop的支持

2.Result   对于结果中共aop的支持

3.AuthorizationFilter    授权对于aop的支持

4.Exception       异常--通过aop来支持

以上四种支持AOP的技术手段：通过特性attribute来支持的；

AOP:  在不修改之前的业务逻辑基础上，动态的增加一些功能；

可以不修改之前的业务逻辑，可以在某一个行为之前、之后做点啥。

### 1、ActionFilter:

a.ActionFilterAttribute是一个抽象类，不能直接使用---用来让我们扩展的

b.IActionFilter   	是一个接口，天生就是让我们来扩展的；

##### 扩展ActionFilterAttribute：

1.新建一个特性，以Attribute结尾，继承ActionFilterAttribute

2.覆写其中的四个方法

3.标记在某一个Action方法中

4.请求来了  ----CustomActionFilter.OnActinExecting---   Action方法---CustomActionFilter.OnActionExected----CustomActionFilter.OnResultExecting----渲染视图-----CustomActionFilter.OnResultExected

##### 扩展IActionFilter   	

1.新建了一个类，以Attribute结尾，继承Attribute，实现了接口IActionFilter

2.实现接口，实现方法

3.标记

4.请求来了以后，----发现并没有进入到扩展的ActionFilter去？

为什么？

框架的内部----不是判断是否是特性，不是一Attribute来判断，而是判断是不是一个FilterAttribute---MvcFilter

### 2、ActionFilter的应用+Filter多种注册

请求进入到Action之前或者是请求经过了Action之后---扩展业务逻辑;

1.记录日志

2.提高性能方面---压缩

压缩：浏览器发起请求到服务器，服务器响应结果给浏览器; 响应的数据肯定存在大小区别；  如果你能够在响应数据上，把数据压缩。  1000---800---数据变小了，性能可以提高；



压缩：需要浏览器和服务器同时要支持；

浏览器发起请求---服务器看浏览器支持哪些压缩格式，服务器根据浏览器支持的压缩格式，做压缩，通知标记给响应结果，告诉浏览器已经使用哪个格式做了压缩。  浏览器就知道使用哪种格式做解压然后展示结果。

### 3、注册方式：

标记在Action上：1.只对当前的Action生效

标记在控制器上： 2.可以让控制器下所有的Action都生效

全局注册：3.全局注册，就对项目中的所有方法都生效

App_Start/FilterConfig.cs

```c#
public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
```

Global.asax

```c#
public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
```

### 4、ResultFilter

结果的Filter：在生成结果之前或者在生成结果之后，可以插入一些自己的业务逻辑；

1. 可以通过ActionFilterAttribute继承扩展---请求来了以后，先进入到OnResultExecuting----视图渲染----OnResultExecuted
2. 可以通过实现IReulstFilter接口来扩展

应用场景：

   跟视图有关，如果想要在视图生成之前或者之后做点什么，就可以考虑使用ResultFilter

### 5、ExceptionFilter

用来处理异常的Filter

#### HandleErrorAttribute 默认实现

```c#
public class MyException: HandleErrorAttribute
     {
         public override void OnException(ExceptionContext filterContext)
         {
             //调用框架本身异常处理器的方法
             base.OnException(filterContext);
 
             //获取异常信息(可以根据实际需要写到本地或数据库中)
             var errorMsg = filterContext.Exception;
 
             //跳转指定的错误页面
             filterContext.Result = new RedirectResult("/error.html");
         }
     }
```

#### IExceptionFilter接口

异常的补充：

#### 在MvcApplication中增加方法：Application_Error

只要响应不是200,就可以被这里捕捉到;

~~~
protected void Application_Error(object sender, EventArgs e)
 {
            Exception excetion = Server.GetLastError();
            Response.Write("System is Error....");
            Server.ClearError(); 
 }
~~~

### 6、AuthorizeAttribute

为了验证权限而存在的；

系统开发中，是必不可少；

1.登录授权---给服务器用户名和密码，服务器验证用户名和密码，把用户信息写入到Session, 在返回的时候，把sesssionID 返回到客户端，写入到Cookie中

```c#
	/// <summary>
    /// 表示一个特性，登录验证。
    /// </summary>
    public class LoginCheckedAttribute : ActionFilterAttribute
    {

        public bool Ignore { get; set; }
        public LoginCheckedAttribute(bool ignore = true)
        {
            Ignore = ignore;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!Ignore)
            {
                return;
            }
            if (OperatorProvider.Instance.Current == null)
            {
                filterContext.HttpContext.Response.Write("<script>top.location.href = '/Account/Login'</script>");
            }
        }
    }
```

2.访问的时候，验证是否有权限---浏览器会自动的带上SessionId，服务器就要找SessionId,如果找到了，就表示登录过；就验证通过了；否则就跳转到登录页；

```c#
/// <summary>
    /// 表示一个特性，该特性用于标识用户是否有访问权限。
    /// </summary>
    public class AuthorizeCheckedAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 是否忽略权限检查。
        /// </summary>
        public bool Ignore { get; set; }

        public AuthorizeCheckedAttribute(bool ignore = false)
        {
            this.Ignore = ignore;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Ignore)
            {
                return;
            };
            var userId = OperatorProvider.Instance.Current.UserId;
            var action = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();
            bool hasPermission = AutoFacConfig.Resolve<IPermissionService>().ActionValidate(userId, action);//这里改为去查询室友有授权的方法
            if (!hasPermission)
            {
                StringBuilder script = new StringBuilder();
                script.Append("<script>alert('对不起，您没有权限访问当前页面。');</script>");
                filterContext.Result = new ContentResult() { Content = script.ToString() };
            }
        }


    }
```



## 二十、ASP.NET MVC管道

### 1、Http请求的全流程

1. 用户浏览器输入地址（域名），
2. DNS解析(域名供应商)：将输入的网址解析成IP+端口
3. 请求到达服务器Server：IP在互联网定位服务器，端口确定进程，端口还可以带有协议信息，用于穿过防火墙。
4. HTTP.SYS服务接收HTTP请求，交给iis
5. IIS将请求发到对应的程序处理
6. 请求包装成HttpWorkerRequest对象
7. 传到AppDomain的HttpRuntime入口
8. 开始管道模型
9. IIS接收返回的数据流，给HTTP.SSY
10. HTTP.SYS将数据给客户端（浏览器）

### 2、Http请求的全流程补充

![](images/03.png)

### 3、ASPNET_ISAPI如何 把请求转交给ASP.NET 管道

HttpContext  ：上下文

HttRunTime: Http运行时

在Asp.net 中，任何一个请求的处理都需要让IHttpHandler来处理

### 4、管道处理模型的核心设计

到HttpApplication；

可能需要经过很多个环节的处理；

1.验证权限

2.缓存的判断

3.异常处理

。。。。。

有多个环节的处理，如果在HttpApplication中直接写死；  请求来了以后，中间任何一个环节都是需要这样处理的；且不能扩展；

如果我们希望能走做到扩展---怎么做呢？

框架：---有固定处理环节，也有不定的处理环节；

使用的是观察者模式；

把固定的操作封装在一起，把不定的处理环节，封装在一个事件中，就可以在初始化的时候，给事件注册动作；请求来了以后，就可以去执行事件+固定的动作；形成一个执行链；   固定的动作是会执行；  事件也会执行；   不定的动作就可以通过注册事件；把需要执行的动作给加入到处理环节中；

给时间中注册的动作是什么呢？---HttpMoudle

### 5、HttpMoudle

在框架中，事件动作的注册究竟是谁来完成呢？

HttpMoudle；----管道

自定义CustomHttpMoudle

1.新建一个CustomHttpMoudle类，实现IHttpMoudle接口

2.实现方法---在方法中，给几个事件注册动作

3.要让CustomHttpMoudle，生效----增加配置文件（本地电脑有一个默认配置文件C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\WebConfig  .NET框架的默认配置，默认情况都是按照这个配置来执行的----慎重修改）

4.可以在我们的项目中的WebConfig中进行配置

~~~
  <system.webServer> 
    <modules>
      <add name="CustomHttpModuleRichard" type="ZhaoXi.ASP.NET.MVC5.Project.Utility.Pipeline.CustomHttpModule,ZhaoXi.ASP.NET.MVC5.Project"/>
    </modules>
  </system.webServer>
~~~

5.任何一次请求来了以后，都会执行我们注册的这个CustomHttpMoudle中的注册动作；

6.这里的这个配置其实是一种请求级的配置扩展；---任何一次请求来都要经过我这里的处理；

HttpMoudle能够给我们带来什么？  httpMoudle可以让我们扩展点什么内容呢？

### 6、HttpMoudle扩展和Global事件

我们可以做一个什么扩展呢？

只要是请求级的处理环节，都可以通过HttpMoudle来扩展；

1.记录日志---同时访问量

2.缓存

3.拦截请求

MVC----MVC其实是ASP.NET 管道中的一个扩展

## JWT算法

### JWT构成

第一部分我们称它为头部（header),第二部分我们称其为载荷（payload, 类似于飞机上承载的物品)，第三部分是签证（signature)。

#### header

jwt的头部承载两部分信息：

- 申明类型：JWT
- 申明加密的算法，通常直接使用 HMAC   HS256

```json
{
    "typ":"JWT",
    "alg":"HS256"
}
```

然后将头部进行base64编码（该编码是可以对称解密的),构成了第一部分.

#### payload

载荷就是存放有效信息的地方。这个名字像是特指飞机上承载的货品，这些有效信息包含三个部分：

-  标准中注册的声明
-  公共的声明
-  私有的声明

**标准中注册的声明** (建议但不强制使用) 

- **iss**: jwt签发者
- **sub**: jwt所面向的用户
- **aud**: 接收jwt的一方
- **exp**: jwt的过期时间，这个过期时间必须要大于签发时间
- **nbf**: 定义在什么时间之前，该jwt都是不可用的.
- **iat**: jwt的签发时间
- **jti**: jwt的唯一身份标识，主要用来作为一次性token,从而回避重放攻击

**公共的声明**

公共的声明可以添加任何的信息，一般添加用户的相关信息或其他业务需要的必要信息.但不建议添加敏感信息，因为该部分在客户端可解密.

**私有的声明**

私有声明是提供者和消费者所共同定义的声明，一般不建议存放敏感信息，因为base64是对称解密的，意味着该部分信息可以归类为明文信息。

```json
{
  "iss":"toptal.com",
  "exp":142642800 ,
  "sub": "1234567890",
  "name": "John Doe",
  "admin": true
}
```

#### Signature

jwt的第三部分是一个签证信息，这个部分需要base64加密后的header和base64加密后的payload使用`.`连接组成的字符串，然后通过header中声明的加密方式进行`secret`组合加密，然后就构成了jwt的第三部分。

- header (base64后的)
- payload (base64后的)
- secretKey

```c#
var encodedString = base64UrlEncode(header) + '.' + base64UrlEncode(payload);

var signature = HMACSHA256(encodedString, 'secretKey');
```

### 如何应用

#### c#加密

Nuget 按装 JWT包

```c#
 //要加密的数据
var payload = new Dictionary<string, object>
{
    {"UserId",123 },
    {"UserName","admin"}
};

string secretKey = "GqOSFaJDOsNOAFJwJETNErGUDF234lcOhstOIUHIu";//秘钥

//进行加密
IJwtAlgorithm jwtAlgorithm = new HMACSHA256Algorithm();//加密算法

IJsonSerializer jsonSerializer = new JsonNetSerializer();//序列化

IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//Base64加密

IJwtEncoder jwtEncoder = new JwtEncoder(jwtAlgorithm, jsonSerializer, urlEncoder);

string token = jwtEncoder.Encode(payload, secretKey);
```

得出加密串：

``eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VySWQiOjEyMywiVXNlck5hbWUiOiJhZG1pbiJ9.Yn39rWis5kgKLBhLeBYeqoQdjnplmlZJrU0lUlJuUJI``

#### 解密

```c#
string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJVc2VySWQiOjEyMywiVXNlck5hbWUiOiJhZG1pbiJ9.Yn39rWis5kgKLBhLeBYeqoQdjnplmlZJrU0lUlJuUJI";
string secretKey = "GqOSFaJDOsNOAFJwJETNErGUDF234lcOhstOIUHIu";//秘钥
string encodeStr = string.Empty;
try
{
    IJwtAlgorithm jwtAlgorithm = new HMACSHA256Algorithm();//加密算法

    IJsonSerializer jsonSerializer = new JsonNetSerializer();//序列化 

    IDateTimeProvider dateTimeProvider = new UtcDateTimeProvider();

    IJwtValidator jwtValidator = new JwtValidator(jsonSerializer, dateTimeProvider);

    IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//Base64加密

    IJwtDecoder jwtDecoder = new JwtDecoder(jsonSerializer, jwtValidator, urlEncoder, jwtAlgorithm);

    encodeStr = jwtDecoder.Decode(token,secretKey,true);//encodeStr:{"UserId":123,"UserName":"admin"}
}
catch
{
	encodeStr = "数据被篡改了";
}
```

一般是在请求头里加入`Authorization`，并加上`Bearer`标注,后台读取header验证：

```bash
fetch('api/user/1', {
  headers: {
    'Authorization': 'Bearer ' + token
  }
})
```

### JWT封装成特性

JWT工具类

```c#
public class JWTTools
    {
        /// <summary>
        /// 加密
        /// </summary>
        private static readonly string _key = "GqOSFaJDOsNOAFJwJETNErGUDF234lcOhstOIUHIu";
        public static string Encode(Dictionary<string,object> payload,string key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                key = _key;
            IJwtAlgorithm jwtAlgorithm = new HMACSHA256Algorithm();//加密算法

            IJsonSerializer jsonSerializer = new JsonNetSerializer();//序列化

            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//Base64加密

            IJwtEncoder jwtEncoder = new JwtEncoder(jwtAlgorithm, jsonSerializer, urlEncoder);

            payload.Add("timeout", DateTime.Now.AddDays(1));//设置超时时间

            string token = jwtEncoder.Encode(payload, key);

            return token;
        }

        /// <summary>
        /// 解析
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Dictionary<string, object> Decode(string token,string key = null)
        {
            if (string.IsNullOrWhiteSpace(key))
                key = _key;
            string encodeStr = string.Empty;
            if (string.IsNullOrWhiteSpace(key))
                key = _key;
            try
            {
                IJwtAlgorithm jwtAlgorithm = new HMACSHA256Algorithm();//加密算法

                IJsonSerializer jsonSerializer = new JsonNetSerializer();//序列化

                IDateTimeProvider dateTimeProvider = new UtcDateTimeProvider();

                IJwtValidator jwtValidator = new JwtValidator(jsonSerializer, dateTimeProvider);

                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//Base64加密

                IJwtDecoder jwtDecoder = new JwtDecoder(jsonSerializer, jwtValidator, urlEncoder, jwtAlgorithm);

                string encodeStr = jwtDecoder.Decode(token, key, true);

                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(encodeStr);

                if ((DateTime)result["timeout"] < DateTime.Now)
                    throw new Exception("超时，请重新登录");
                result.Remove("timeout");

                return result;
            }
            catch
            {
                throw new TokenExpiredException("解析失败");
            }
        }
    }
```

存到User方便对比

```c#
public class UserIdentity:IIdentity
    {
        public UserIdentity(string name,string UserPwd)
        {
            Name = name;
            Loginpwd = UserPwd;
        }
        public string Name { get; }
        public string Loginpwd { get; }
        public string AuthenticationType { get; }
        public bool IsAuthenticated { get; }
    }

    public class ApplicationUSer:IPrincipal
    {
        public ApplicationUSer(string name,string UserPwd)
        {
            Identity = new UserIdentity(name, UserPwd);
        }
        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity { get; }
    }
```

特性：

```c#
 public class MyAuthAttribute :Attribute, IAuthorizationFilter
    {
        public bool AllowMultiple => throw new NotImplementedException();

        public async Task<HttpResponseMessage> ExecuteAuthorizationFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            //当某个特定的action添加了AllowAnonymous特性时，跳过校验
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count > 0)
                return await continuation();
            
            IEnumerable<string> headers;
            if (actionContext.Request.Headers.TryGetValues("token", out headers))
            {
                var loginName = JWTTools.Decode(headers.First())["LoginName"].ToString();
                var loginpwd = JWTTools.Decode(headers.First())["UserPwd"].ToString();
                ((ApiController) actionContext.ControllerContext.Controller).User = new ApplicationUSer(loginName, loginpwd);
                return await continuation();
            }

            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

    }
```

使用

```c#
        // GET api/<controller>/5
        [MyAuth]
        public IHttpActionResult Get(int id)
        {
            return Ok(((UserIdentity)User.Identity).Loginpwd);
        }

        // POST api/<controller>
        [MyAuth]
        public void Post([FromBody] string value)
        {
        }

        [Route("Login")]
        [HttpPost]
        public IHttpActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return Ok(JWTTools.Encode(new Dictionary<string, object>(){
                        {
                            "LoginName",model.UserName
                        }
                    }
                ));
            }
            else
            {
                return BadRequest("登录验证失败");
            }
            

        }

```

## using  NuGet PagedList 分页;

```c#
public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
{
   ViewBag.CurrentSort = sortOrder;
   ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
   ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

   if (searchString != null)
   {
      page = 1;
   }
   else
   {
      searchString = currentFilter;
   }

   ViewBag.CurrentFilter = searchString;

   var students = from s in db.Students
                  select s;
   if (!String.IsNullOrEmpty(searchString))
   {
      students = students.Where(s => s.LastName.Contains(searchString)
                             || s.FirstMidName.Contains(searchString));
   }
   switch (sortOrder)
   {
      case "name_desc":
         students = students.OrderByDescending(s => s.LastName);
         break;
      case "Date":
         students = students.OrderBy(s => s.EnrollmentDate);
         break;
      case "date_desc":
         students = students.OrderByDescending(s => s.EnrollmentDate);
         break;
      default:  // Name ascending 
         students = students.OrderBy(s => s.LastName);
         break;
   }

   int pageSize = 3;
   int pageNumber = (page ?? 1);
   return View(students.ToPagedList(pageNumber, pageSize));
}
```

## 跨域

就是跨域资源共享

### 解决跨域访问被限制的问题

#### 启用Cors

- Nuget 安装 Microsoft.AspNet.WebApi.Cors 

#### 配置Cors服务

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

### CSRF

CSRF（Cross-site request forgery）跨站请求伪造，也被称为“One Click Attack”或者Session Riding，通常缩写为CSRF或者XSRF，是一种对网站的恶意利用

需要在view加上Html.AntiForgeryToken()防止CSRF攻击，还需要在目标action上增加[ValidateAntiForgeryToken]特性*它主要检查*

(1)请求的是否包含一个约定的AntiForgery名的cookie

(2)请求是否有一个Request.Form["约定的AntiForgery名"]，约定的AntiForgery名的cookie和Request.Form值是否匹配





































