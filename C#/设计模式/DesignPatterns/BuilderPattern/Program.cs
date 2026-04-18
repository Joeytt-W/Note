using BuilderPattern;
/*
意图：将一个复杂对象的构建与其表示相分离，使得同样的构建过程可以创建不同的表示

主要解决：一个复杂对象”的创建工作，其通常由各个部分的子对象用一定的算法构成；由于需求的变化，这个复杂对象的各个部分经常面临着剧烈的变化，但是将它们组合在一起的算法却相对稳定。

使用场景：
（1）当创建复杂对象的算法应该独立于该对象的组成部分以及它们的装配方式时。

（2）相同的方法，不同的执行顺序，产生不同的事件结果时。

（3）多个部件或零件,都可以装配到一个对象中，但是产生的运行结果又不相同时。

（4）产品类非常复杂，或者产品类中的调用顺序不同产生了不同的效能。

（5）创建一些复杂的对象时，这些对象的内部组成构件间的建造顺序是稳定的，但是对象的内部组成构件面临着复杂的变化。

优点：
（1）使用建造者模式可以使客户端不必知道产品内部组成的细节。

（2）具体的建造者类之间是相互独立的，容易扩展。

（3）由于具体的建造者是独立的，因此可以对建造过程逐步细化，而不对其他的模块产生任何影响。

缺点：产生多余的Build对象以及Director类。
 */

Console.Title = "Builder Pattern";

var garage = new Garage();

var miniBuilder = new MiniBuilder();
var bmwBuilder = new BMWBuilder();

garage.Construct(miniBuilder);
garage.Show();

garage.Construct(bmwBuilder);
garage.Show();

Console.ReadKey();