# ``AutoFac``

​		控制反转背后的想法是，与其将应用程序中的类绑定在一起并让类“更新”它们的依赖项，不如将其切换，以便在类构建期间传递依赖项。

## 多种注册方法

```c#
// 创建用于注册组件/服务的构建器。
var builder = new ContainerBuilder();

// 用实现接口的类型注册..。
builder.RegisterType<ConsoleLogger>().As<ILogger>();

// 用创建的对象实例注册...
var output = new StringWriter();
builder.RegisterInstance(output).As<TextWriter>();

// 注册创建对象的表达式...
builder.Register(c => new ConfigReader("mysection")).As<IConfigReader>();

// 构建容器以完成注册并准备对象解析.
var container = builder.Build();

using(var scope = container.BeginLifetimeScope())
{
  var reader = scope.Resolve<IConfigReader>();
}
```

## 多个构造器

```c#
public class MyComponent
{
    public MyComponent() { /* ... */ }
    public MyComponent(ILogger logger) { /* ... */ }
    public MyComponent(ILogger logger, IConfigReader reader) { /* ... */ }
}
```

在容器中注册这样的组件和服务

```c#
var builder = new ContainerBuilder();
builder.RegisterType<MyComponent>();
builder.RegisterType<ConsoleLogger>().As<ILogger>();
var container = builder.Build();

using(var scope = container.BeginLifetimeScope())
{
  var component = scope.Resolve<MyComponent>();
}
```

``Autofac ``将看到已注册``ILogger``，但没有注册``IConfigReader``。在这种情况下，将选择第二个构造器，因为这是在容器中可以找到的参数最多的构造器

### 指定构造器

```c#
builder.RegisterType<MyComponent>()
       .UsingConstructor(typeof(ILogger), typeof(IConfigReader));
```

## 泛型

```c#
builder.RegisterGeneric(typeof(NHibernateRepository<>))
       .As(typeof(IRepository<>))
       .InstancePerLifetimeScope();


// Autofac will return an NHibernateRepository<Task>
var tasks = container.Resolve<IRepository<Task>>();
```

## 修改默认注册的实例

```c#
builder.RegisterType<ConsoleLogger>().As<ILogger>();
builder.RegisterType<FileLogger>().As<ILogger>();//FileLogger默认
```

```c#
builder.RegisterType<ConsoleLogger>().As<ILogger>();//ConsoleLogger默认
builder.RegisterType<FileLogger>().As<ILogger>().PreserveExistingDefaults();
```

## 需要在注册时传入参数

```c#
public class ConfigReader : IConfigReader
{
  public ConfigReader(string configSectionName)
  {
    // Store config section name
  }

  // ...read configuration based on the section name.
}
```

可以使用lambda表达式的形式注册

```c#
builder.Register(c => new ConfigReader("sectionName")).As<IConfigReader>();
```

或者

```c#
// Using a NAMED parameter:
builder.RegisterType<ConfigReader>()
       .As<IConfigReader>()
       .WithParameter("configSectionName", "sectionName");

// Using a TYPED parameter:
builder.RegisterType<ConfigReader>()
       .As<IConfigReader>()
       .WithParameter(new TypedParameter(typeof(string), "sectionName"));

// Using a RESOLVED parameter:
builder.RegisterType<ConfigReader>()
       .As<IConfigReader>()
       .WithParameter(
         new ResolvedParameter(
           (pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "configSectionName",
           (pi, ctx) => "sectionName"));
```

























官方网站http://autofac.org/

源码下载地址https://github.com/autofac/Autofac

## AutoFac入门

### 将 Autofac.dll，Autofac.Configuration.dll 这两个程序集引用到项目中

### （1）builder.RegisterType<Object>().As<Iobject>()：注册类型及其实例。例如下面就是注册接口IDal的实例SqlDal

```c#
    public interface IDal
    {
        void Insert(string commandText);
    }

    public class OracleDal : IDal
    {
        public void Insert(string commandText)
        {
            Console.WriteLine($"使用OracleDAL添加相关信息:{commandText}");
        }
    }

    public class SqlDal : IDal
    {
        public void Insert(string commandText)
        {
            Console.WriteLine($"使用sqlDAL添加相关信息:{commandText}");
        }
    }

	public class DbManager
    {
        private readonly IDal _dal;

        public DbManager(IDal dal)
        {
            _dal = dal;
        }

        public void Add(string commandText)
        {
            _dal.Insert(commandText);
        }
    }

	class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DbManager>();
            builder.RegisterType<SqlDal>().As<IDal>();

            using (var container = builder.Build())
            {
                var manager = container.Resolve<DbManager>();
                //控制台输出：使用sqlDAL添加相关信息:INSERT INTO Persons VALUES ('Man', '25', 'WangW', 'Shanghai')
                manager.Add("INSERT INTO Persons VALUES ('Man', '25', 'WangW', 'Shanghai')");
            }
            Console.ReadKey();
        }
    }
```

### （2）IContainer.Resolve<Ial>()：解析某个接口的实例。例如上面的最后一行代码就是解析IDal的实例SqlDal

### （3）builder.RegisterType<Object>().Named<Iobject>(string name)：为一个接口注册不同的实例。有时候难免会碰到多个类映射同一个接口，比如SqlDAL和OracleDAL都实现了IDAL接口，为了准确获取想要的类型，就必须在注册时起名字。

```c#
builder.RegisterType<SqlDAL>().Named<IDAL>("sql");
builder.RegisterType<OracleDAL>().Named<IDAL>("oracle");
IContainer container = builder.Build();
SqlDAL sqlDAL = (SqlDAL)container.ResolveNamed<IDAL>("sql");
OracleDAL oracleDAL = (OracleDAL)container.ResolveNamed<IDAL>("oracle");
```

### （4）IContainer.ResolveNamed<IDAL>(string name):解析某个接口的“命名实例”。例如上面的最后一行代码就是解析IDal的命名实例OracleDal

### （5）builder.RegisterType<Object>().Keyed<Iobject>(Enum enum)：以枚举的方式为一个接口注册不同的实例。有时候我们会将某一个接口的不同实现用枚举来区分，而不是字符串

```c#
public enum DBType{ Sql, Oracle}
builder.RegisterType<SqlDAL>().Keyed<IDAL>(DBType.Sql);
builder.RegisterType<OracleDAL>().Keyed<IDAL>(DBType.Oracle);
IContainer container = builder.Build();
SqlDAL sqlDAL = (SqlDAL)container.ResolveKeyed<IDAL>(DBType.Sql);
OracleDAL oracleDAL = (OracleDAL)container.ResolveKeyed<IDAL>(DBType.Oracle);
```

### （6）IContainer.ResolveKeyed<IDAL>(Enum enum):根据枚举值解析某个接口的特定实例。例如上面的最后一行代码就是解析IDAL的特定实例OracleDAL

### （7）builder.RegisterType<Worker>().InstancePerDependency()：用于控制对象的生命周期，每次加载实例时都是新建一个实例，默认就是这种方式

### （8）builder.RegisterType<Worker>().SingleInstance()：用于控制对象的生命周期，每次加载实例时都是返回同一个实例

### （9）IContainer.Resolve<T>(NamedParameter namedParameter):在解析实例T时给其赋值

```c#
DBManager manager = container.Resolve<DBManager>(new NamedParameter("name", "SQL"));
public class DBManager 
{   
    IDAL dal;
    public DBManager (string name,IDAL  _dal)
    {
        Name = name;
        dal= _dal;
    }
}
```

### （10）builder.RegisterAssemblyTypes(Assembly assembly):注册程序集下所有类型

```c#
builder.RegisterAssemblyTypes(typeof(Program).Assembly).AsImplementedInterfaces();
//或者  AsImplementedInterfaces表示注册的类型，以接口的方式注册

builder.RegisterAssemblyTypes(typeof(IRepository<>).Assembly).Where(t => t.IsClass && t.Name.EndsWith("Repository")).AsImplementedInterfaces();
```

## 通过配置的方式使用AutoFac

### （1）先配置好配置文件

```xml
   <?xml version="1.0"?>
　　<configuration>
  　　<configSections>
    　　<section name="autofac" type="Autofac.Configuration.SectionHandler, Autofac.Configuration"/>
  　　</configSections>
  　　<autofac defaultAssembly="ConsoleApplication1">
    　　<components>
      　　<component type="ConsoleApplication1.SqlDAL, ConsoleApplication1" service="ConsoleApplication1.IDAL" />
    　　</components>
  　　</autofac>
　　</configuration>
```

### （2）读取配置实现依赖注入（注意引入Autofac.Configuration.dll）

```c#
	static void Main(string[] args)
    {
        ContainerBuilder builder = new ContainerBuilder();
        builder.RegisterType<DBManager>();
        builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
        using (IContainer container = builder.Build())
        {
            DBManager manager = container.Resolve<DBManager>();
            manager.Add("INSERT INTO Persons VALUES ('Man', '25', 'WangW', 'Shanghai')"); 
    } 
```

## ASP.NET MVC与AtuoFac

### 1、首先在函数Application_Start() 注册自己的控制器类，一定要引入Autofac.Integration.Mvc.dll

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using AtuoFacOfMVC4.Models;
using System.Reflection;
using Autofac.Integration.Mvc;


namespace AtuoFacOfMVC4
{
   public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            SetupResolveRules(builder);
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }
        private void SetupResolveRules(ContainerBuilder builder)
        {
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();
        }
    }
}
```

### 2、现在在你的MVC程序中注入依赖代码就ok了

### （1）首先声明一个Student学生类

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AtuoFacOfMVC4.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Graduation { get; set; }
        public string School { get; set; }
        public string Major { get; set; }
    }
}
```

### （2）然后声明仓储接口及其实现

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtuoFacOfMVC4.Models
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        Student Add(Student item);
        bool Update(Student item);
        bool Delete(int id);
    }
}
```

### （3）最后添加控制器StudentController，并注入依赖代码

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtuoFacOfMVC4.Models;

namespace AtuoFacOfMVC4.Controllers
{
    public class StudentController : Controller
    {
        readonly IStudentRepository repository;
        //构造器注入
        public StudentController(IStudentRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            var data = repository.GetAll();
            return View(data);
        }

    }
}
```

