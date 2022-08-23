using TemplatePattern;
/*
 
 意图：定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。Template Method使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。

 使用场景：
（1）一次性实现一个算法的不变部分，并将可变的行为留给子类来实现。

（2） 各子类中公共的行为应被提取出来并集中到一个公共父类中以避免代码重复。

（3） 控制子类扩展。模板方法只允许在特定点进行扩展，而模板部分则是稳定的。

 特点：
（1）TemplateMethod模式是一种非常基础性的设计模式，在面向对象系统中大量应用。它用最简洁的机制（基础、多态）为很多应用程序框架提供了灵活的扩展点，是代码复用方面的基本实现结构。

（2）在具体实现方面，被TemplateMethod调用的虚方法可以具有实现，也可以没有任何实现（抽象方法或虚方法）。但一般推荐将它们设置为protected方法使得只有子类可以访问它们。

（3）模板方法模式通过对子类的扩展增加新的行为，符合“开闭原则”。
 */
Console.Title="Template";

ExchangeMailParser exchangeMailParser=new();
Console.WriteLine(exchangeMailParser.ParseMailBody("2E9DB390 - 6373 - 4EAD - A862 - 2CD02F002771"));
Console.WriteLine();

ApacheMailParser apacheMailParser=new();
Console.WriteLine(apacheMailParser.ParseMailBody("C9F9F457-B178-400F-A35B-D0B85BADFEBD"));
Console.WriteLine();

EudoraMailParser eudoraMailParser=new();
Console.WriteLine(exchangeMailParser.ParseMailBody("23A6DECE-A6A2-4E9B-AEA6-859234D3B581"));



Console.ReadKey();