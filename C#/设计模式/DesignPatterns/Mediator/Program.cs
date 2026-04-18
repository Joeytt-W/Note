using Mediator;
/*
 意图：定义了一个中介对象来封装一系列对象之间的交互关系。中介者使各个对象之间不需要显式地相互引用，从而使耦合性降低，而且可以独立地改变它们之间的交互行为。

 优点：
（1）松散耦合
中介者模式通过把多个同事对象之间的交互封装到中介对象里面，从而使得对象之间松散耦合，基本上可以做到互不依赖。这样一来，同时对象就可以独立的变化和复用，不再“牵一发动全身”。

（2）集中控制交互
多个同事对象的交互，被封装在中介者对象里面集中管理，使得这些交互行为发生变化的时候，只需要修改中介者就可以了。

（3）多对多变为一对多
== 没有中介者模式的时候，同事对象之间的关系通常是多对多==，引入中介者对象后，中介者和同事对象的关系通常变为双向的一对多，这会让对象的关系更容易理解和实现。

缺点：过度集中化
如果同事对象之间的交互非常多，而且比较复杂，当这些复杂性全都集中到中介者的时候，会导致中介者对象变的十分复杂，而且难于维护和管理。
 */
Console.Title = "Mediator";

TeamChatRoom teamChatRoom = new();

var sven = new Lawyer("Sven");
var keneth = new Lawyer("Keneth");
var ann = new Lawyer("Ann");
var john = new AccountManager("John");
var kylie = new AccountManager("Kylie");


teamChatRoom.Register(sven);
teamChatRoom.Register(keneth);
teamChatRoom.Register(ann);
teamChatRoom.Register(john);
teamChatRoom.Register(kylie);

ann.Send("Hi everyone,can someone have a look at file ABC123? I need a compliance check.");
sven.Send("On it!");
ann.Send("Sven", "Could you join me in a Team Call ?");
sven.Send("Ann", "All good.");
ann.SendTo<AccountManager>("The file was approved");


Console.ReadKey();