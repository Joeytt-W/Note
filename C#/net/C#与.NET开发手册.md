# C# 与 .NET 开发手册

> 面向 .NET 开发者的综合手册：覆盖 C# 基础语法、.NET Core 与 .NET Framework 的差异，以及 WebAPI、MVC、Razor、SignalR、Blazor 的完整语法、配套工具与实战案例。示例基于 .NET 8 + EF Core + SQL Server 技术栈。

## 目录

### 第一部分：C# 基础语法
1. [语言基础：变量、类型、运算符](#一语言基础变量类型运算符)
2. [流程控制与循环](#二流程控制与循环)
3. [面向对象：类、继承、接口](#三面向对象类继承接口)
4. [集合与泛型](#四集合与泛型)
5. [LINQ 查询](#五linq-查询)
6. [委托、事件与 Lambda](#六委托事件与-lambda)
7. [异步编程 async/await](#七异步编程-asyncawait)
8. [异常处理](#八异常处理)
9. [特性与反射](#九特性与反射)
10. [现代 C# 语法（record、模式匹配等）](#十现代-c-语法)

### 第二部分：.NET 平台
11. [.NET Core vs .NET Framework](#十一net-core-vs-net-framework)
12. [项目结构与入口](#十二项目结构与入口)
13. [依赖注入、配置与日志](#十三依赖注入配置与日志)

### 第三部分：Web 开发
14. [ASP.NET Core 基础与中间件](#十四aspnet-core-基础与中间件)
15. [WebAPI 开发](#十五webapi-开发)
16. [MVC 开发](#十六mvc-开发)
17. [Razor（Razor Pages + Razor 语法）](#十七razorrazor-pages--razor-语法)
18. [SignalR 实时通信](#十八signalr-实时通信)
19. [Blazor（Server + WebAssembly）](#十九blazorserver--webassembly)

### 第四部分：配套工具
20. [dotnet CLI 命令](#二十dotnet-cli-命令)
21. [NuGet 包管理](#二十一nuget-包管理)
22. [EF Core 数据访问](#二十二ef-core-数据访问)
23. [常用第三方库](#二十三常用第三方库)
24. [开发与调试工具](#二十四开发与调试工具)

---

# 第一部分：C# 基础语法

## 一、语言基础：变量、类型、运算符

### 1.1 变量声明

```csharp
// 显式类型
int age = 30;
string name = "张三";
double price = 19.99;
bool isActive = true;

// 类型推断（var）
var count = 100;          // 编译时推断为 int
var message = "Hello";    // 推断为 string

// 常量
const double PI = 3.14159;

// 可空类型
int? nullableInt = null;
string? nullableString = null;   // C# 8+ 可空引用类型
```

### 1.2 常用类型

| 类型 | 说明 | 示例 |
|------|------|------|
| `int` | 32 位整数 | `42` |
| `long` | 64 位整数 | `42L` |
| `double` / `float` | 浮点数 | `3.14` / `3.14f` |
| `decimal` | 高精度小数（金额） | `19.99m` |
| `bool` | 布尔 | `true` |
| `char` | 单字符 | `'A'` |
| `string` | 字符串 | `"hello"` |
| `DateTime` | 日期时间 | `DateTime.Now` |
| `Guid` | 全局唯一标识 | `Guid.NewGuid()` |
| `object` | 所有类型的基类 | — |
| `dynamic` | 动态类型 | — |

> **金额一律用 `decimal`**，不用 `double`（精度问题）。

### 1.3 字符串操作

```csharp
string name = "张三";

// 字符串插值（推荐）
string greeting = $"你好，{name}！今年 {DateTime.Now.Year} 年";

// 拼接
string full = name + "先生";

// 常用方法
name.Length;                    // 长度
name.ToUpper();                 // 转大写
name.Substring(0, 1);           // 截取
name.Contains("张");            // 是否包含
name.Replace("三", "四");       // 替换
string.IsNullOrEmpty(name);     // 空判断
string.Join(",", new[] { "a", "b" });  // 连接
"a,b,c".Split(',');             // 分割

// 原始字符串（C# 11，避免转义）
string path = """C:\Users\Admin\file.txt""";
```

### 1.4 运算符

```csharp
// 算术：+ - * / %（取余）
int mod = 10 % 3;    // 1

// 比较：== != > < >= <=
// 逻辑：&& || !
// 三元运算符
string result = age >= 18 ? "成年" : "未成年";

// null 合并
string name2 = name ?? "匿名";           // name 为 null 时用"匿名"
string name3 = name ??= "匿名";          // 赋值形式

// 空值条件运算符
string? upper = person?.Name?.ToUpper();  // 任一为 null 则整体 null

// is 类型检查
if (obj is string s) { Console.WriteLine(s); }
```

---

## 二、流程控制与循环

```csharp
// if-else
if (score >= 90) { /* A */ }
else if (score >= 80) { /* B */ }
else { /* C */ }

// switch 表达式（C# 8+，简洁推荐）
string grade = score switch
{
    >= 90 => "A",
    >= 80 => "B",
    >= 60 => "C",
    _ => "D"
};

// for 循环
for (int i = 0; i < 10; i++) { }

// foreach 循环（遍历集合）
foreach (var item in list) { }

// while 循环
while (condition) { }

// do-while 循环
do { } while (condition);

// break / continue
```

---

## 三、面向对象：类、继承、接口

### 3.1 类与对象

```csharp
public class Person
{
    // 字段
    private string _name;

    // 属性（自动属性）
    public string Name { get; set; }
    public int Age { get; set; }

    // 只读属性
    public bool IsAdult => Age >= 18;

    // 构造函数
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // 方法
    public string Introduce() => $"我是{Name}，{Age}岁";
}

// 使用
var person = new Person("张三", 30);
Console.WriteLine(person.Introduce());
```

### 3.2 继承与多态

```csharp
// 基类
public abstract class Animal
{
    public string Name { get; set; }
    public abstract void MakeSound();      // 抽象方法
    public virtual void Eat() => Console.WriteLine($"{Name} 在吃东西");
}

// 派生类
public class Dog : Animal
{
    public override void MakeSound() => Console.WriteLine("汪汪");
    public override void Eat() => Console.WriteLine($"{Name} 在吃骨头");
}

// 接口
public interface IRepository<T>
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}

// 接口实现
public class UserRepository : IRepository<User>
{
    public Task<User> GetByIdAsync(int id) => Task.FromResult(new User());
    public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult<IEnumerable<User>>(new List<User>());
}
```

### 3.3 访问修饰符

| 修饰符 | 访问范围 |
|------|------|
| `public` | 任意位置 |
| `private` | 仅类内部 |
| `protected` | 类内部 + 派生类 |
| `internal` | 同一程序集 |
| `protected internal` | 同一程序集 或 派生类 |

---

## 四、集合与泛型

### 4.1 常用集合

```csharp
// List<T>：动态数组（最常用）
var list = new List<string> { "a", "b", "c" };
list.Add("d");
list.Remove("a");
list.Contains("b");
list[0];                       // 索引访问

// Dictionary<TKey, TValue>：键值对
var dict = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
dict.Add("c", 3);
dict["a"];                     // 取值
dict.ContainsKey("a");
dict.TryGetValue("a", out var v);   // 安全取值

// HashSet<T>：去重集合
var set = new HashSet<int> { 1, 2, 2, 3 };   // 实际 1,2,3

// Queue<T> / Stack<T>：队列 / 栈
var queue = new Queue<string>();
queue.Enqueue("a");
var item = queue.Dequeue();

// IEnumerable<T>：只读序列（LINQ 的基石）
IEnumerable<int> nums = new List<int> { 1, 2, 3 };
```

### 4.2 泛型方法

```csharp
// 泛型方法
public T Echo<T>(T value) => value;

// 泛型约束
public T Max<T>(T a, T b) where T : IComparable<T>
    => a.CompareTo(b) >= 0 ? a : b;
```

---

## 五、LINQ 查询

LINQ（Language Integrated Query）是 C# 的核心数据查询能力，可查内存集合、数据库（EF Core）、XML 等。

### 5.1 方法语法（推荐）

```csharp
var users = new List<User>
{
    new() { Id = 1, Name = "张三", Age = 30, City = "北京" },
    new() { Id = 2, Name = "李四", Age = 25, City = "上海" },
    new() { Id = 3, Name = "王五", Age = 35, City = "北京" },
};

// 过滤 Where
var adults = users.Where(u => u.Age >= 18);

// 投影 Select
var names = users.Select(u => u.Name);

// 排序 OrderBy / OrderByDescending
var sorted = users.OrderBy(u => u.Age).ThenBy(u => u.Name);

// 分组 GroupBy
var groups = users.GroupBy(u => u.City);

// 聚合 Count / Sum / Average / Min / Max
var count = users.Count();
var avgAge = users.Average(u => u.Age);

// 首元素 First / FirstOrDefault / Single
var first = users.First(u => u.City == "北京");
var maybe = users.FirstOrDefault(u => u.Age > 100);   // null

// 判断 Any / All
var hasAdult = users.Any(u => u.Age >= 18);
var allAdult = users.All(u => u.Age >= 18);

// 跳过/取（分页）
var page = users.Skip(10).Take(20);

// 连接 Join
var result = users.Join(orders, u => u.Id, o => o.UserId, (u, o) => new { u.Name, o.Total });

// 延迟执行：ToList/ToArray 时才真正执行
var list = users.Where(u => u.Age > 20).ToList();
```

### 5.2 查询语法（SQL 风格）

```csharp
var query = from u in users
            where u.Age >= 18
            orderby u.Age descending
            select new { u.Name, u.Age };
```

> 两者等价，团队内统一用**方法语法**更常见（链式、易与 EF Core 配合）。

---

## 六、委托、事件与 Lambda

### 6.1 Lambda 表达式

```csharp
// 基本形式：(参数) => 表达式
Func<int, int> square = x => x * x;
Func<int, int, int> add = (a, b) => a + b;
Action<string> print = msg => Console.WriteLine(msg);

// 多语句用大括号
Func<int, int> doubleIt = x => { var y = x * 2; return y; };
```

### 6.2 委托

```csharp
// 内置委托
// Action<T>：无返回值
// Func<T, TResult>：有返回值
// Predicate<T>：返回 bool

delegate int Calculate(int a, int b);     // 自定义委托
Calculate calc = (a, b) => a + b;
int sum = calc(3, 4);
```

### 6.3 事件

```csharp
public class Button
{
    // 声明事件
    public event EventHandler? Clicked;

    public void Click()
    {
        Console.WriteLine("按钮被点击");
        Clicked?.Invoke(this, EventArgs.Empty);   // 触发事件
    }
}

// 订阅事件
var btn = new Button();
btn.Clicked += (sender, e) => Console.WriteLine("事件处理器执行");
btn.Click();
```

---

## 七、异步编程 async/await

异步编程是 .NET 现代开发的必备技能，WebAPI 几乎全是异步。

### 7.1 核心语法

```csharp
// 异步方法：async + Task
public async Task<string> GetDataAsync()
{
    // await 等待异步操作完成（不阻塞线程）
    var data = await Task.Run(() => "处理中...");
    return data;
}

// 无返回值的异步方法
public async Task SaveAsync()
{
    await Task.Delay(1000);
}

// 返回值的异步方法
public async Task<int> CalculateAsync()
{
    return await Task.FromResult(42);
}

// 并行等待多个任务
public async Task LoadAllAsync()
{
    var task1 = GetUserAsync();
    var task2 = GetOrderAsync();
    await Task.WhenAll(task1, task2);     // 并行等待
}

// 调用（顶层语句或 async Main）
await GetDataAsync();
```

### 7.2 常见陷阱

```csharp
// ❌ 错误：async void 只能用于事件处理器，无法等待、异常难捕获
// public async void BadMethod() { }

// ✅ 正确：一律返回 Task
public async Task GoodMethod() { }

// ❌ 错误：同步等待异步（死锁风险，尤其在 ASP.NET）
// var result = GetDataAsync().Result;
// var result = GetDataAsync().GetAwaiter().GetResult();

// ✅ 正确：一路 async/await 到底
var result = await GetDataAsync();

// ConfigureAwait(false)：库代码中用，避免捕获上下文
await GetDataAsync().ConfigureAwait(false);
```

### 7.3 CancellationToken（取消）

```csharp
public async Task ProcessAsync(CancellationToken ct = default)
{
    await Task.Delay(5000, ct);     // 支持取消
}

// WebAPI 中自动注入
[HttpGet]
public async Task<IActionResult> Get(CancellationToken ct)
{
    await ProcessAsync(ct);
    return Ok();
}
```

---

## 八、异常处理

```csharp
try
{
    // 可能抛异常的代码
    int result = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"除以零：{ex.Message}");
}
catch (Exception ex)     // 兜底
{
    Console.WriteLine($"其他异常：{ex.Message}");
}
finally
{
    // 无论是否异常都会执行（释放资源）
}

// 抛异常
throw new InvalidOperationException("状态无效");

// 自定义异常
public class BusinessException : Exception
{
    public BusinessException(string message) : base(message) { }
}
```

> **最佳实践**：捕获具体异常而非 `Exception` 兜底；异常用于「真正的异常」，业务校验用返回值/Result 模式。

---

## 九、特性与反射

### 9.1 特性（Attribute）

特性用于给代码添加元数据，是 WebAPI（路由、认证、校验）的基石。

```csharp
// 自定义特性
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PermissionAttribute : Attribute
{
    public string Code { get; }
    public PermissionAttribute(string code) => Code = code;
}

// 使用特性
[Permission("user.create")]
public class UserController
{
    [Permission("user.list")]
    public void List() { }
}
```

### 9.2 反射

```csharp
// 获取类型信息
Type type = typeof(User);
var properties = type.GetProperties();      // 获取所有属性
var methods = type.GetMethods();            // 获取所有方法

// 创建实例
var instance = Activator.CreateInstance(type);

// 读取特性
var attr = type.GetCustomAttributes(typeof(PermissionAttribute), false)
               .Cast<PermissionAttribute>()
               .FirstOrDefault();
```

---

## 十、现代 C# 语法

### 10.1 record（不可变对象，C# 9+）

```csharp
// record：值语义、不可变、适合 DTO
public record UserDto(int Id, string Name, string Email);

var user = new UserDto(1, "张三", "zhangsan@x.com");

// with 表达式：复制并修改
var updated = user with { Email = "new@x.com" };

// 值相等比较（record 自动实现）
var user2 = new UserDto(1, "张三", "zhangsan@x.com");
bool equal = user == user2;    // true（值相等）
```

### 10.2 模式匹配

```csharp
// 类型模式
if (obj is string s) { }

// 属性模式
if (person is { Age: >= 18, Name: "张三" }) { }

// 位置模式（解构）
if (point is (0, 0)) { }
```

### 10.3 其他常用新语法

```csharp
// 目标类型 new（省略类型）
UserDto user = new(1, "张三", "x@x.com");
List<int> list = new() { 1, 2, 3 };

// 解构元组
(int x, int y) = GetPoint();
var (name, age) = ("张三", 30);

// 本地函数
int Add(int a, int b) => a + b;

// 顶层语句（Program.cs 无需 Main 方法）
Console.WriteLine("Hello");
```

---

# 第二部分：.NET 平台

## 十一、.NET Core vs .NET Framework

### 11.1 版本演进

| 名称 | 说明 | 现状 |
|------|------|------|
| **.NET Framework** | 老牌 Windows 专属框架，最后版本 4.8.x | 停止主版本更新，仅维护 |
| **.NET Core** | 跨平台重写版本（1.0~3.1） | 已演进为 .NET 5+ |
| **.NET 5/6/7/8** | .NET Core 的延续，统一命名 | **当前主流（.NET 8 LTS）** |

> 从 .NET Core 3.1 之后统一叫「.NET」，「.NET Core」这个名称已不再用于新版本。你当前用的 **.NET 8 是 LTS（长期支持）**。

### 11.2 核心区别

| 维度 | .NET Framework | .NET Core / .NET 5+ |
|------|------|------|
| 跨平台 | ❌ 仅 Windows | ✅ Windows/Linux/macOS |
| 开源 | 部分 | ✅ 完全开源 |
| 性能 | 一般 | ✅ 显著提升 |
| 部署 | 依赖系统安装 | ✅ 自包含/框架依赖均可 |
| Web 框架 | ASP.NET（MVC/WebForms） | ASP.NET Core |
| 容器 | 差 | ✅ 原生支持（Docker/K8s） |
| 后续更新 | 停滞 | ✅ 持续（每年 11 月发版） |

### 11.3 选型建议

- **新项目**：一律用 .NET 8（LTS）
- **旧项目**：能迁移就迁移，不能就继续 .NET Framework 维护
- **ASP.NET Core 与 ASP.NET（旧）完全不同**：中间件、依赖注入、配置系统都是新的

---

## 十二、项目结构与入口

### 12.1 .csproj 项目文件（SDK 风格）

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
    <PackageReference Include="Swashbuckle.AspNetCore" Version="6.5.0" />
  </ItemGroup>

</Project>
```

### 12.2 Program.cs（入口）

```csharp
var builder = WebApplication.CreateBuilder(args);

// 注册服务（依赖注入）
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 配置中间件管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
```

---

## 十三、依赖注入、配置与日志

### 13.1 依赖注入（DI）

```csharp
// 定义服务接口与实现
public interface IUserService
{
    User GetUser(int id);
}
public class UserService : IUserService
{
    public User GetUser(int id) => new() { Id = id, Name = "张三" };
}

// 注册服务（三种生命周期）
builder.Services.AddSingleton<ICacheService, CacheService>();       // 单例（全局一个）
builder.Services.AddScoped<IUserService, UserService>();            // 作用域（每次请求一个，最常用）
builder.Services.AddTransient<ILogger, Logger>();                   // 瞬时（每次获取新实例）

// 构造函数注入
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
        => _userService = userService;
}
```

### 13.2 配置

```csharp
// 读取 appsettings.json 配置
var config = builder.Configuration;
string conn = config.GetConnectionString("Default");
string setting = config["AppSettings:SomeKey"];

// 强类型配置（推荐）
public class AppSettings { public string ApiKey { get; set; } = ""; }
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// 注入使用
public class MyService
{
    public MyService(IOptions<AppSettings> options)
        => _apiKey = options.Value.ApiKey;
}
```

`appsettings.json`：

```json
{
  "ConnectionStrings": {
    "Default": "Server=localhost;Database=erp;User Id=sa;Password=xxx;"
  },
  "AppSettings": {
    "ApiKey": "sk-xxxx"
  }
}
```

### 13.3 日志

```csharp
// 内置 ILogger
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    public UserController(ILogger<UserController> logger) => _logger = logger;

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("查询用户列表");
        _logger.LogWarning("警告信息");
        _logger.LogError("错误信息");
        return Ok();
    }
}
```

---

# 第三部分：Web 开发

## 十四、ASP.NET Core 基础与中间件

### 14.1 中间件管道

中间件是 ASP.NET Core 处理 HTTP 请求的核心机制，按注册顺序依次执行。

```csharp
var app = builder.Build();

// 自定义中间件
app.Use(async (context, next) =>
{
    Console.WriteLine("请求进入");
    await next();                       // 调用下一个中间件
    Console.WriteLine("响应返回");
});

app.UseRouting();          // 路由
app.UseAuthentication();   // 认证
app.UseAuthorization();    // 授权
app.MapControllers();      // 端点
```

### 14.2 请求管道执行顺序

```
请求 → 日志 → 异常处理 → 静态文件 → 路由 → 认证 → 授权 → 控制器 → 响应
```

---

## 十五、WebAPI 开发

### 15.1 控制器与路由

```csharp
[ApiController]                       // 自动模型验证、行为规范化
[Route("api/[controller]")]           // 路由模板
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service) => _service = service;

    // GET api/users
    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    // GET api/users/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _service.GetById(id);
        return user is null ? NotFound() : Ok(user);
    }

    // POST api/users
    [HttpPost]
    public IActionResult Create([FromBody] CreateUserDto dto)
    {
        var user = _service.Create(dto);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    // PUT api/users/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] UpdateUserDto dto)
        => Ok(_service.Update(id, dto));

    // DELETE api/users/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) => NoContent();
}
```

### 15.2 模型绑定与参数来源

| 特性 | 来源 |
|------|------|
| `[FromBody]` | 请求体（JSON） |
| `[FromQuery]` | 查询字符串 `?id=1` |
| `[FromRoute]` | 路由参数 `{id}` |
| `[FromHeader]` | 请求头 |
| `[FromForm]` | 表单 |

```csharp
[HttpGet("search")]
public IActionResult Search(
    [FromQuery] string keyword,
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
{
    // ?keyword=xx&page=1&pageSize=10
    return Ok(new { keyword, page, pageSize });
}
```

### 15.3 模型验证

```csharp
public class CreateUserDto
{
    [Required(ErrorMessage = "姓名必填")]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; } = "";

    [EmailAddress]
    public string Email { get; set; } = "";

    [Range(1, 150)]
    public int Age { get; set; }
}
```

```csharp
// [ApiController] 自动验证，失败返回 400
[HttpPost]
public IActionResult Create([FromBody] CreateUserDto dto)
{
    // 显式手动验证
    if (!ModelState.IsValid)
        return BadRequest(ModelState);
    return Ok();
}
```

### 15.4 过滤器（Filter）

```csharp
// 动作过滤器（记录日志、统一处理）
public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
        => Console.WriteLine($"执行前：{context.ActionDescriptor.DisplayName}");

    public void OnActionExecuted(ActionExecutedContext context)
        => Console.WriteLine("执行后");
}

// 注册过滤器
builder.Services.AddControllers(options =>
{
    options.Filters.Add<LogActionFilter>();    // 全局
});
```

### 15.5 认证与授权（JWT）

```csharp
// 配置 JWT 认证
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = config["Jwt:Issuer"],
            ValidAudience = config["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config["Jwt:Key"]!))
        };
    });

// 保护接口
[Authorize]                       // 需要登录
public class SecureController : ControllerBase { }

[Authorize(Roles = "Admin")]      // 需要管理员角色
public IActionResult AdminOnly() => Ok();
```

### 15.6 Swagger 文档

```csharp
builder.Services.AddSwaggerGen();
// 访问 /swagger 查看接口文档
```

### 15.7 统一返回结果

```csharp
// 统一响应包装
public record ApiResult<T>(bool Success, string Message, T? Data)
{
    public static ApiResult<T> Ok(T data) => new(true, "成功", data);
    public static ApiResult<T> Fail(string msg) => new(false, msg, default);
};
```

---

## 十六、MVC 开发

MVC（Model-View-Controller）是服务端渲染的传统模式，适合后台管理系统。

### 16.1 控制器返回视图

```csharp
public class HomeController : Controller
{
    // 返回视图
    public IActionResult Index()
    {
        // 传递数据到视图
        ViewBag.Title = "首页";
        ViewData["Message"] = "欢迎";
        return View();
    }

    // 返回带模型的视图
    public IActionResult Users()
    {
        var users = _service.GetAll();
        return View(users);          // 强类型视图
    }

    // 重定向
    public IActionResult Redirect() => RedirectToAction("Index");

    // 返回 JSON
    public IActionResult Api() => Json(new { status = "ok" });
}
```

### 16.2 视图（.cshtml）

```html
@* Users.cshtml，对应 Users 动作 *@
@model IEnumerable<User>

<h1>用户列表</h1>
<table>
    <thead>
        <tr><th>ID</th><th>姓名</th></tr>
    </thead>
    <tbody>
        @foreach (var user in Model)
        {
            <tr>
                <td>@user.Id</td>
                <td>@user.Name</td>
            </tr>
        }
    </tbody>
</table>
```

### 16.3 表单与模型绑定

```html
<form asp-action="Create" method="post">
    <input asp-for="Name" />
    <span asp-validation-for="Name"></span>
    <button type="submit">提交</button>
</form>
```

```csharp
[HttpPost]
public IActionResult Create(User user)
{
    if (ModelState.IsValid)
    {
        _service.Create(user);
        return RedirectToAction("Index");
    }
    return View(user);
}
```

---

## 十七、Razor（Razor Pages + Razor 语法）

### 17.1 Razor 语法

```html
@* 注释 *@

@* 表达式输出 *@
<p>当前时间：@DateTime.Now</p>
<p>姓名：@Model.Name</p>

@* 代码块 *@
@{
    var message = "Hello";
    var count = 10;
}

@* 条件 *@
@if (count > 5)
{
    <span>大于 5</span>
}
else
{
    <span>小于等于 5</span>
}

@* 循环 *@
@foreach (var item in Model.Items)
{
    <li>@item</li>
}

@* 标签助手（Tag Helper） *@
<a asp-controller="Home" asp-action="Index">首页</a>
<form asp-action="Login" method="post">...</form>
```

### 17.2 Razor Pages

Razor Pages 是页面为中心的模式（`.cshtml` + `.cshtml.cs`），适合简单 CRUD 页面。

```csharp
// Index.cshtml.cs（页面模型）
public class IndexModel : PageModel
{
    private readonly IUserService _service;
    public IndexModel(IUserService service) => _service = service;

    public List<User> Users { get; set; } = new();

    public void OnGet()                       // GET 请求
    {
        Users = _service.GetAll();
    }

    public IActionResult OnPost()             // POST 请求
    {
        // 处理表单
        return RedirectToPage("Index");
    }
}
```

```html
@* Index.cshtml（页面视图） *@
@page
@model IndexModel

<h1>用户列表</h1>
@foreach (var user in Model.Users)
{
    <p>@user.Name</p>
}
```

### 17.3 Razor Pages 与 MVC 对比

| 维度 | MVC | Razor Pages |
|------|------|------|
| 组织方式 | 控制器 + 视图分离 | 页面 + 页面模型（就近） |
| 适用场景 | 大型应用、复杂路由 | 简单页面、CRUD |
| 路由 | 手动配置 | 基于文件路径自动路由 |

---

## 十八、SignalR 实时通信

SignalR 用于实时通信（推送消息、在线聊天、实时看板），支持 WebSocket、Server-Sent Events、长轮询自动降级。

### 18.1 服务端 Hub

```csharp
// 定义 Hub
public class ChatHub : Hub
{
    // 客户端可调用的方法
    public async Task SendMessage(string user, string message)
    {
        // 广播给所有客户端
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    // 给指定用户发消息
    public async Task SendToUser(string userId, string message)
        => await Clients.User(userId).SendAsync("ReceiveMessage", message);
}
```

```csharp
// 注册 SignalR
builder.Services.AddSignalR();

app.MapHub<ChatHub>("/chatHub");
```

### 18.2 客户端调用

```html
<!-- JavaScript 客户端 -->
<script src="~/lib/signalr/signalr.js"></script>
<script>
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chatHub")
        .build();

    // 接收服务端推送
    connection.on("ReceiveMessage", (user, message) => {
        console.log(`${user}: ${message}`);
    });

    connection.start().then(() => {
        // 调用服务端方法
        connection.invoke("SendMessage", "张三", "你好");
    });
</script>
```

### 18.3 .NET 客户端（服务间通信）

```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:5001/chatHub")
    .Build();

connection.On<string, string>("ReceiveMessage", (user, msg) =>
{
    Console.WriteLine($"{user}: {msg}");
});

await connection.StartAsync();
await connection.InvokeAsync("SendMessage", "系统", "上线");
```

### 18.4 典型应用场景

| 场景 | 说明 |
|------|------|
| 实时看板 | 推送生产数据到 MES 看板（你的场景） |
| 在线聊天 | 消息实时推送 |
| 通知推送 | 系统消息、告警 |
| 协同编辑 | 多人实时协作 |

---

## 十九、Blazor（Server + WebAssembly）

Blazor 用 C# 替代 JavaScript 编写交互式 Web UI，两种托管模式。

### 19.1 两种模式对比

| 维度 | Blazor Server | Blazor WebAssembly |
|------|------|------|
| 运行位置 | 服务端（SignalR 通信） | 浏览器（WebAssembly） |
| 首屏速度 | 快（服务端渲染） | 慢（需下载运行时） |
| 离线支持 | ❌ | ✅ |
| 服务器负载 | 高（每用户一连接） | 低 |
| 适用 | 内网系统、后台管理 | 公开网站、离线应用 |

### 19.2 组件（Component）

```razor
@* Counter.razor 组件 *@
@page "/counter"          @* 路由 *@

<h1>计数器</h1>
<p>当前计数：@currentCount</p>
<button @onclick="IncrementCount">点击 +1</button>

@code {
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

### 19.3 数据绑定与事件

```razor
@page "/form"

<input @bind="name" />
<input @bind="name" @bind:event="oninput" />   @* 实时绑定 *@
<p>你好，@name</p>

<button @onclick="Save">保存</button>

@code {
    private string name = "";

    private void Save()
    {
        Console.WriteLine($"保存：{name}");
    }
}
```

### 19.4 组件参数与生命周期

```razor
@* 子组件：Child.razor *@
<h3>@Title</h3>
<button @onclick="OnClick">点我</button>

@code {
    [Parameter] public string Title { get; set; } = "";
    [Parameter] public EventCallback OnClick { get; set; }
}
```

```razor
@* 父组件使用 *@
<Child Title="标题" OnClick="HandleClick" />

@code {
    private void HandleClick() => Console.WriteLine("子组件点击");
}
```

### 19.5 依赖注入

```razor
@page "/users"
@inject IUserService UserService

@foreach (var user in users)
{
    <p>@user.Name</p>
}

@code {
    private List<User> users = new();

    protected override async Task OnInitializedAsync()
    {
        users = await UserService.GetAllAsync();
    }
}
```

---

# 第四部分：配套工具

## 二十、dotnet CLI 命令

```bash
# 创建项目
dotnet new webapi -n MyApi              # WebAPI 项目
dotnet new mvc -n MyMvc                # MVC 项目
dotnet new razor -n MyRazor            # Razor Pages 项目
dotnet new blazorserver -n MyBlazor    # Blazor Server
dotnet new blazorwasm -n MyBlazorWasm  # Blazor WebAssembly
dotnet new classlib -n MyLib           # 类库
dotnet new sln -n MySolution           # 解决方案

# 构建与运行
dotnet build                           # 构建
dotnet run                             # 运行
dotnet run --project MyApi             # 指定项目
dotnet watch run                       # 热重载

# 发布
dotnet publish -c Release -o ./publish # 发布
dotnet publish -c Release -r linux-x64 --self-contained true  # 自包含发布

# 测试
dotnet test                            # 运行测试

# 添加包/引用
dotnet add package Newtonsoft.Json     # 添加 NuGet 包
dotnet add reference ../MyLib/MyLib.csproj   # 添加项目引用

# 其他
dotnet --version                       # 版本
dotnet --list-sdks                     # 已安装 SDK
dotnet tool list -g                    # 全局工具
```

---

## 二十一、NuGet 包管理

```bash
# CLI 操作
dotnet add package <包名>              # 添加包（最新版）
dotnet add package <包名> --version 8.0.0  # 指定版本
dotnet remove package <包名>           # 移除包
dotnet list package                    # 列出包
dotnet restore                         # 还原依赖
```

```xml
<!-- 在 .csproj 中手动管理 -->
<ItemGroup>
  <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.0" />
</ItemGroup>
```

> NuGet 源配置在 `NuGet.Config`，国内可用镜像加速（如华为云、腾讯云 NuGet 镜像）。

---

## 二十二、EF Core 数据访问

### 22.1 DbContext 与实体

```csharp
// 实体
public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime CreatedAt { get; set; }
}

// DbContext
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 配置表名、索引等
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("Users");
            e.HasIndex(u => u.Email).IsUnique();
        });
    }
}
```

```csharp
// 注册
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
```

### 22.2 增删改查

```csharp
public class UserRepository
{
    private readonly AppDbContext _db;
    public UserRepository(AppDbContext db) => _db = db;

    // 查询
    public async Task<List<User>> GetAllAsync()
        => await _db.Users.Where(u => u.Id > 0).OrderBy(u => u.Id).ToListAsync();

    public async Task<User?> GetByIdAsync(int id)
        => await _db.Users.FindAsync(id);

    // 新增
    public async Task AddAsync(User user)
    {
        _db.Users.Add(user);
        await _db.SaveChangesAsync();     // 提交
    }

    // 更新
    public async Task UpdateAsync(User user)
    {
        _db.Users.Update(user);
        await _db.SaveChangesAsync();
    }

    // 删除
    public async Task DeleteAsync(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user != null)
        {
            _db.Users.Remove(user);
            await _db.SaveChangesAsync();
        }
    }

    // 分页查询
    public async Task<(List<User>, int)> GetPagedAsync(int page, int pageSize)
    {
        var query = _db.Users.AsNoTracking();
        var total = await query.CountAsync();
        var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        return (items, total);
    }
}
```

### 22.3 迁移（Migration）

```bash
dotnet ef migrations add InitialCreate     # 创建迁移
dotnet ef database update                  # 应用迁移到数据库
dotnet ef migrations remove                # 删除最后一次迁移
```

### 22.4 常用技巧

```csharp
// AsNoTracking：只读查询（性能优化）
_db.Users.AsNoTracking().ToList();

// 事务
using var transaction = await _db.Database.BeginTransactionAsync();
try
{
    await _db.SaveChangesAsync();
    await transaction.CommitAsync();
}
catch
{
    await transaction.RollbackAsync();
}
```

---

## 二十三、常用第三方库

| 库 | 用途 | 安装 |
|------|------|------|
| **Dapper** | 轻量 ORM（高性能 SQL） | `dotnet add package Dapper` |
| **AutoMapper** | 对象映射（DTO 转换） | `dotnet add package AutoMapper` |
| **Serilog** | 结构化日志 | `dotnet add package Serilog.AspNetCore` |
| **Newtonsoft.Json** | JSON 处理 | `dotnet add package Newtonsoft.Json` |
| **FluentValidation** | 校验 | `dotnet add package FluentValidation.AspNetCore` |
| **Swashbuckle** | Swagger 文档 | `dotnet add package Swashbuckle.AspNetCore` |
| **StackExchange.Redis** | Redis 客户端 | `dotnet add package StackExchange.Redis` |
| **RabbitMQ.Client** | RabbitMQ 客户端 | `dotnet add package RabbitMQ.Client` |
| **Minio** | MinIO 对象存储 | `dotnet add package Minio` |
| **Hangfire** | 后台任务/定时任务 | `dotnet add package Hangfire` |
| **SignalR** | 实时通信 | `dotnet add package Microsoft.AspNetCore.SignalR` |

### 23.1 AutoMapper 示例

```csharp
// 配置映射
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();
    }
}

// 使用
var dto = _mapper.Map<UserDto>(user);
var list = _mapper.Map<List<UserDto>>(users);
```

### 23.2 Serilog 示例

```csharp
builder.Host.UseSerilog((ctx, config) =>
    config.ReadFrom.Configuration(ctx.Configuration)
          .Enrich.FromLogContext()
          .WriteTo.Console()
          .WriteTo.File("logs/app.log", rollingInterval: RollingInterval.Day));
```

---

## 二十四、开发与调试工具

| 工具 | 用途 |
|------|------|
| **Visual Studio 2022** | 主力 IDE（Windows） |
| **Visual Studio Code** | 轻量 IDE（跨平台）+ C# Dev Kit 插件 |
| **JetBrains Rider** | 跨平台商业 IDE |
| **Postman** | API 测试 |
| **Swagger UI** | 接口文档与在线调试 |
| **Docker** | 容器化部署 |
| **dotnet watch** | 热重载开发 |
| **dotnet-trace / dotnet-dump** | 性能分析/内存转储 |

### 24.1 调试技巧

```csharp
// 断点调试：F5 启动，F9 打断点，F10 单步，F11 进入
// 条件断点、数据断点、日志断点（VS）

// 输出调试信息
Debug.WriteLine("调试信息");
Console.WriteLine("控制台输出");
```

### 24.2 性能与诊断

```bash
# 性能分析工具
dotnet tool install -g dotnet-trace
dotnet trace collect --process-id <pid>

# 内存分析
dotnet tool install -g dotnet-dump
```

---

## 附：技术栈快速映射

| 需求 | 技术选择 |
|------|------|
| REST API | ASP.NET Core WebAPI |
| 服务端渲染页面 | MVC / Razor Pages |
| 实时看板/推送 | SignalR |
| 交互式 Web 应用（C# 全栈） | Blazor |
| 数据访问 | EF Core（复杂查询）+ Dapper（高性能） |
| 缓存 | Redis（StackExchange.Redis） |
| 消息队列 | RabbitMQ（RabbitMQ.Client） |
| 对象存储 | MinIO（Minio SDK） |
| 日志 | Serilog |
| API 文档 | Swagger |
| 后台任务 | Hangfire |
| 容器部署 | Docker + Kubernetes |
| 微服务编排 | Dapr |

> **开发建议**：你的 ERP/MES 场景，WebAPI（前后端分离）+ SignalR（实时看板）+ EF Core（数据访问）+ Dapr（服务编排）是完整闭环。
