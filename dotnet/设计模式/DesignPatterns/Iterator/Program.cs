using Iterator;
/*
 意图：提供一种方法顺序访问一个聚合对象中的各个元素，而又不暴露该对象的内部表示。

 使用场景：
（1）访问一个聚合对象的内容而无需暴露它的内部表示。

（2）支持对聚合对象的多种遍历。

（3）为遍历不同的聚合结构提供一个统一的接口(即, 支持多态迭代)。

 优点：
（1）迭代器模式使得访问一个聚合对象的内容而无需暴露它的内部表示，即迭代抽象。

（2）迭代器模式为遍历不同的集合结构提供了一个统一的接口，从而支持同样的算法在不同的集合结构上进行操作

缺点：迭代器模式在遍历的同时更改迭代器所在的集合结构会导致出现异常。所以使用foreach语句只能在对集合进行遍历，不能在遍历的同时更改集合中的元素。
 */
Console.Title = "Iterator";


PeopleCollection people =new();

people.Add(new Person("Kevin Dockx","Belgium"));
people.Add(new Person("Gill Cleeren","Belgium"));
people.Add(new Person("Roland Guijt","The NetherLands"));
people.Add(new Person("Thomas Claudius Huber","Germany"));


var peopleIterator = people.CreateIterator();

for (Person person=peopleIterator.First();
     !peopleIterator.IsDone;
     person=peopleIterator.Next())
{
    Console.WriteLine(person?.Name);
}

Console.ReadKey();