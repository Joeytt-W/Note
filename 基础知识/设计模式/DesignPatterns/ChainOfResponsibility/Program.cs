using System.ComponentModel.DataAnnotations;
using ChainOfResponsibility;
/*
 意图：避免请求发送者与接收者耦合在一起，让多个对象都有可能接受请求，将这些对象连接成一条链，并且沿着这条链传递请求，直到有对象处理它为止。

 使用场景：
（1）一个系统的审批需要多个对象才能完成处理的情况下，例如请假系统等。

（2）代码中存在多个if-else语句的情况下，此时可以考虑使用责任链模式来对代码进行重构。

（3）有多个对象可以处理同一个请求，具体哪个对象处理该请求有运行时刻自动确定。客户端只需将请求提交到链上，无须关心请求的处理对象是谁以及它是如何处理的。

（4）不明确指定接受者的情况下，向多个对象中的一个提交一个请求。请求的发送者与请求者解耦，请求将沿着链进行传递，寻求响应的处理者。

（5）可动态指定一组对象处理请求。客户端可以动态创建职责链来处理请求，还可以动态改变链中处理者之间的先后次序。

 优点：
（1）降低耦合度：职责链模式使得一个对象无需知道是其他哪一个对象处理其请求。对象仅需知道该请求会被处理即可，接受者和发送者都没有对方的明确信息，且链中的对象不需要知道链的结构，由客户端负责链的创建。

（2）可简化对象的相互连接：接受者对象仅需维持一个指向其后继者的引用，而不需维持它对所有的候选处理者的引用。

（3）增强给对象指派职责的灵活性：在给对象分派职责时，职责链可以给我们带来更多的灵活性。可以通过在运行时对该链进行动态的增加或修改处理一个请求的职责。

（4）增加新的请求处理类很方便：在系统中增加一个新的请求处理者无需修改原有系统的代码，只需要在客户端重新建链即可，从这一点看来是符合“开闭原则”的。

缺点：
（1）在找到正确的处理对象之前，所有的条件判定都要执行一遍，当责任链过长时，可能会引起性能的问题。

（2）可能导致某个请求不被处理。

（3）客户端需要组装这个链条，耦合了客户端和链条的组成结构，可以把这个在客户端的组合动作提到外面，通过配置来做，会更好点。【可以优化的点！采用外部配置】
 */
Console.Title = "Chain Of Responsibility";

var validDocument = new Document("How to Avoid Java Development",DateTimeOffset.Now, true,true);
var inValidDocument = new Document("How to Avoid Java Development",DateTimeOffset.Now, false,true);



var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain
    .SetSuccessor(new DocumentLastModifiedHandler())
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());


try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document is valid");
    documentHandlerChain.Handle(inValidDocument);
    Console.WriteLine("Invalid document is valid");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}

Console.ReadKey();
