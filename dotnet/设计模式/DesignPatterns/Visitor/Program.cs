﻿using Visitor;
/*
 意图：表示一个作用于某对象结构中的各个元素的操作。它可以在不改变各元素的类的前提下定义作用于这些元素的新的操作。

 使用场景：
（1）如果系统有比较稳定的数据结构，而又有易于变化的算法时，此时可以考虑使用访问者模式。因为访问者模式使得算法操作的添加比较容易。

（2）如果一组类中，存在着相似的操作，为了避免出现大量重复的代码，可以考虑把重复的操作封装到访问者中。（当然也可以考虑使用抽象类了）

（3）如果一个对象存在着一些与本身对象不相干，或关系比较弱的操作时，为了避免操作污染这个对象，则可以考虑把这些操作封装到访问者对象中。

 优点：
（1）访问者模式使得添加新的操作变得容易。如果一些操作依赖于一个复杂的结构对象的话，那么一般而言，添加新的操作会变得很复杂。而使用访问者模式，增加新的操作就意味着添加一个新的访问者类。因此，使得添加新的操作变得容易。

（2）访问者模式使得有关的行为操作集中到一个访问者对象中，而不是分散到一个个的元素类中。这点类似于”中介者模式”。

（3）访问者模式可以访问属于不同的等级结构的成员对象，而迭代只能访问属于同一个等级结构的成员对象。

缺点：增加新的元素类变得困难。每增加一个新的元素意味着要在抽象访问者角色中增加一个新的抽象操作，并在每一个具体访问者类中添加相应的具体操作。具体来说，Visitor模式的最大缺点在于扩展类层次结构（增添新的Element子类），会导致Visitor类的改变。因此Visitor模式适用于“Element类层次结构稳定，而其中的操作却经常面临频繁改动”。
 */
Console.Title = "Visitor";

var container = new Container();

container.Customers.Add(new Customer("Sophie",500));
container.Customers.Add(new Customer("karen",1000));
container.Customers.Add(new Customer("Sven",800));
container.Employees.Add(new Employee("Kevin",18));
container.Employees.Add(new Employee("Tom",5));


DiscountVisitor discountVisitor = new();

container.Accept(discountVisitor);

Console.WriteLine($"Total discount: {discountVisitor.TotalDiscountGiven}");


Console.ReadKey();
