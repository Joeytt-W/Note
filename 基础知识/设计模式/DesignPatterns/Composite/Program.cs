/*
 意图：将对象组合成树形结构以表示“部分-整体”的层次结构。Composite使得用户对单个对象和组合对象的使用具有一致性。

 组合模式实现的最关键的地方是——简单对象和复合对象必须实现相同的接口。这就是组合模式能够将组合对象和简单对象进行一致处理的原因。

 使用场景：
 （1）需要表示一个对象整体或部分的层次结构。

 （2）希望用户忽略组合对象与单个对象的不同，用户将统一地使用组合结构中的所有对象。

 优点：
 （1）组合模式使得客户端代码可以一致地处理对象和对象容器，无需关心处理的是单个对象，还是组合的对象容器。

 （2）将”客户代码与复杂的对象容器结构“解耦。

 （3）可以更容易地往组合对象中加入新的构件。

 缺点：使得设计更加复杂。客户端需要花更多时间理清类之间的层次关系。（这个是几乎所有设计模式所面临的问题）。
 */

Console.Title = "Composite";


var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("toplevel.txt", 100);
var topLevelDirectory1 = new Composite.Directory("topleveldirectory1", 4);
var topLevelDirectory2 = new Composite.Directory("topleveldirectory2", 4);


root.Add(topLevelFile);
root.Add(topLevelDirectory1);
root.Add(topLevelDirectory2);

var subLevelFile1 = new Composite.File("sublevel1.txt", 200);
var subLevelFile2 = new Composite.File("sublevel2.txt", 150);

topLevelDirectory2.Add(subLevelFile1);
topLevelDirectory2.Add(subLevelFile2);

Console.WriteLine($"Size of topLevelDirectory1: {topLevelDirectory1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2: {topLevelDirectory2.GetSize()}");
Console.WriteLine($"Size of root: {root.GetSize()}");

Console.ReadKey();
