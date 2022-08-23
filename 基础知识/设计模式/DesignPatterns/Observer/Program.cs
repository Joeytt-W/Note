using Observer;
/*
 意图：定义对象间的一种一对多的依赖关系，以便当一个对象的状态发生改变时，所有依赖于它的对象都得到通知并自动更新。

 优点：
（1）观察者模式实现了表示层和数据逻辑层的分离，并定义了稳定的更新消息传递机制，并抽象了更新接口，使得可以有各种各样不同的表示层，即观察者。

（2）观察者模式在被观察者和观察者之间建立了一个抽象的耦合，被观察者并不知道任何一个具体的观察者，只是保存着抽象观察者的列表，每个具体观察者都符合一个抽象观察者的接口。

（3）观察者模式支持广播通信。被观察者会向所有的注册过的观察者发出通知。

缺点：
（1）如果一个被观察者有很多直接和间接的观察者时，将所有的观察者都通知到会花费很多时间。

（2）虽然观察者模式可以随时使观察者知道所观察的对象发送了变化，但是观察者模式没有相应的机制使观察者知道所观察的对象是怎样发生变化的。

（3）如果在被观察者之间有循环依赖的话，被观察者会触发它们之间进行循环调用，导致系统崩溃，在使用观察者模式应特别注意这点。
 */
Console.Title="Observer";

TicketStockService ticketStockService = new ();
TicketResellerService ticketResellerService = new ();
OrderService orderService = new OrderService ();


orderService.AddObserver(ticketStockService);
orderService.AddObserver(ticketResellerService);


orderService.CompleteTicketSale(1,2);

Console.WriteLine();

orderService.RemoveObserver(ticketResellerService);

orderService.CompleteTicketSale(2, 4);
Console.ReadKey();