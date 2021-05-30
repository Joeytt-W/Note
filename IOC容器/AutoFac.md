# AutoFac

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

