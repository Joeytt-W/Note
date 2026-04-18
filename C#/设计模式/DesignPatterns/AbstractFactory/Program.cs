using AbstractFactory;

/*
意图：提供一个创建一系列相关或相互依赖对象的接口，而无需指定它们具体的类。

主要解决：在软件系统中，经常面临着"一系列相互依赖的对象"的创建工作：同时，由于需求的变化，往往存在更多系列对象的创建工作。如何应对这种变化？如何绕过常规的对象创建方法（new)，提供一种"封装机制"来避免客户程序和这种"多系列具体对象创建工作"的紧耦合？

优点：降低了系统的耦合度，对于后期的维护和扩展就更有利

缺点：如果需要添加新产品，此时就必须去修改抽象工厂的接口，这样就涉及到抽象工厂类以及所有子类的改变，这样也就违背了“开发——封闭”原则
 */


Console.Title = "Abstract Factory";

var belgiumShoppingCartPruchaseFactory = new BelgiumShoppingCartPurchaseFactory();
var shoppingCartForBelgium = new ShoppingCart(belgiumShoppingCartPruchaseFactory);
shoppingCartForBelgium.CalculateCosts();

var franceShoppingCartPruchaseFactory = new FranceShoppingCartPurchaseFactory();
var shoppingCartForFrance = new ShoppingCart(franceShoppingCartPruchaseFactory);
shoppingCartForFrance.CalculateCosts();

Console.ReadKey();