using Facade;
/*
 意图：为子系统中的一组接口提供一个一致的界面，Facade模式定义了一个高层接口，这个接口使得这一子系统更加容易使用。

 组合模式实现的最关键的地方是——简单对象和复合对象必须实现相同的接口。这就是组合模式能够将组合对象和简单对象进行一致处理的原因。

 使用场景：
 （1）为一个复杂的子系统提供一个简单的接口
 
 （2）提供子系统的独立性

 （3）在层次化结构中，可以使用外观模式定义系统中每一层的入口。其中三层架构就是这样的一个例子。

 优点：
 （1）外观模式对客户屏蔽了子系统组件，从而简化了接口，减少了客户处理的对象数目并使子系统的使用更加简单。

 （2）外观模式实现了子系统与客户之间的松耦合关系，而子系统内部的功能组件是紧耦合的。松耦合使得子系统的组件变化不会影响到它的客户。

 缺点：如果增加新的子系统可能需要修改外观类或客户端的源代码，这样就违背了”开闭原则“（不过这点也是不可避免）


Facade很多时候更是一种架构设计模式。

注意区分Facade模式、Adapter模式、Bridge模式与Decorator模式：

Facade模式注重简化接口

Adapter模式注重转换接口

Bridge模式注重分离接口（抽象）与其实现

Decorator模式注重稳定接口的前提下为对象扩展功能
 */


Console.Title = "Facade";

var facede = new DiscountFacade();
Console.WriteLine($"Discount percentage for custoer with id 1: {facede.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount percentage for custoer with id 10: {facede.CalculateDiscountPercentage(10)}");

Console.ReadKey();