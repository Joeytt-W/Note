using Strategy;
/*
 意图：定义一系列算法，把它们一个个封装起来，并且使它们可互相替换。该模式使得算法可独立于使用它的客户而变化。

 使用场景：
（1）一个系统需要动态地在几种算法中选择一种的情况下。那么这些算法可以包装到一个个具体的算法类里面，并为这些具体的算法类提供一个统一的接口。

（2）如果一个对象有很多的行为，如果不使用合适的模式，这些行为就只好使用多重的if-else语句来实现，此时，可以使用策略模式，把这些行为转移到相应的具体策略类里面，就可以避免使用难以维护的多重条件选择语句（if-else），并体现面向对象的思想。

 优点：
（1）策略类之间可以自由切换。由于策略类都实现同一个接口，所以使它们之间可以自由切换。

（2）易于扩展。增加一个新的策略只需要添加一个具体的策略类即可，基本不需要改变原有的代码。

（3）避免使用多重条件选择语句，充分体现面向对象设计思想。

缺点：客户端必须知道所有的策略类，并自行决定使用哪一个策略类。
这点可以考虑使用IOC容器和依赖注入的方式来解决，关于IOC容器和依赖注入（Dependency Inject）的文章可以参考：IoC 容器和Dependency Injection 模式。
 */
Console.Title="Strategy";

var order = new Order("Marvin Software",5,"Visual Studio License");

order.ExportService = new CSVExportService();
order.Export();

order.ExportService = new JsonExportService();
order.Export();


Console.ReadKey();