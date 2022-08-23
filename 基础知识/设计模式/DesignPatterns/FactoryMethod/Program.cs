using FactoryMethod;

/*
意图：定义一个用于创建对象的接口，让子类决定实例化哪一个类。

主要解决：在软件系统的构建过程中，经常面临着“某个对象”的创建工作：由于需求的变化，这个对象（的具体实现）经常面临着剧烈的变化，但是它却拥有比较稳定的接口。

优点：
（1）在工厂方法中，用户只需要知道所要产品的具体工厂，无须关系具体的创建过程，甚至不需要具体产品类的类名。

（2）在系统增加新的产品时，我们只需要添加一个具体产品类和对应的实现工厂，无需对原工厂进行任何修改，很好地符合了“开闭原则”。

缺点：每次增加一个产品时，都需要增加一个具体类和对象实现工厂，系统中类的个数成倍增加，在一定程度上增加了系统的复杂度，同时也增加了系统具体类的依赖。这并不是什么好事。
 */

Console.Title = "Factory Method";

var factories = new List<DiscountFactry>
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE")
};

foreach (var factory in factories)
{
    var discountService = factory.CreateDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} " + $"coming from {discountService}");
}


Console.ReadKey();