/*
 意图：动态地给一个对象增加一些额外的职责。就增加功能而言，Decorator模式比生成子类更为灵活

 优点：
 （1）把抽象接口与其实现解耦。

 （2）抽象和实现可以独立扩展，不会影响到对方。

 （3）实现细节对客户透明，对用户隐藏了具体实现细节。

 缺点：增加了系统的复杂度

 使用场景：
 （1）如果一个系统需要在构件的抽象化角色和具体化角色之间添加更多的灵活性，避免在两个层次之间建立静态的联系。

 （2）设计要求实现化角色的任何改变不应当影响客户端，或者实现化角色的改变对客户端是完全透明的。

 （3）需要跨越多个平台的图形和窗口系统上。

 （4）一个类存在两个独立变化的维度，且两个维度都需要进行扩展。
 */


using Decorator;

Console.Title = "Decorator";

var cloudMainService = new CloudMailService();
cloudMainService.SendMail("Hi there.");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hi there.");


var statisticDecorator = new StatisticsDecorator(cloudMainService);
statisticDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper");

var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremiseMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper,message 1.");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper,message 2.");

foreach (var message in messageDatabaseDecorator.SentMessage)
{
    Console.WriteLine($"Stored message: \"{message} \"");
}

Console.ReadKey();