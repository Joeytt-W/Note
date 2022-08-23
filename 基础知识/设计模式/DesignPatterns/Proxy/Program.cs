/*
 代理模式按照使用目的可以分为以下几种：

（1）远程（Remote）代理：为一个位于不同的地址空间的对象提供一个局域代表对象。这个不同的地址空间可以是本电脑中，也可以在另一台电脑中。最典型的例子就是——客户端调用Web服务或WCF服务。

（2）虚拟（Virtual）代理：根据需要创建一个资源消耗较大的对象，使得对象只在需要时才会被真正创建。

（3）Copy-on-Write代理：虚拟代理的一种，把复制（或者叫克隆）拖延到只有在客户端需要时，才真正采取行动。

（4）保护（Protect or Access）代理：控制一个对象的访问，可以给不同的用户提供不同级别的使用权限。

（5）防火墙（Firewall）代理：保护目标不让恶意用户接近。

（6）智能引用（Smart Reference）代理：当一个对象被引用时，提供一些额外的操作，比如将对此对象调用的次数记录下来等。

（7）Cache代理：为某一个目标操作的结果提供临时的存储空间，以便多个客户端可以使用这些结果。

在上面所有种类的代理模式中，虚拟代理、远程代理、智能引用代理和保护代理较为常见的代理模式。


 意图：为其他对象提供一种代理以控制对这个对象的访问

 使用场景：
 （1） 当客户端对象需要访问远程主机中的对象时可以使用远程代理。

 （2）当需要用一个消耗资源较少的对象来代表一个消耗资源较多的对象，从而降低系统开销、缩短运行时间时可以使用虚拟代理，例如一个对象需要很长时间才能完成加载时。

 （3）当需要为某一个被频繁访问的操作结果提供一个临时存储空间，以供多个客户端共享访问这些结果时可以使用缓冲代理。通过使用缓冲代理，系统无须在客户端每一次访问时都重新执行操作，只需直接从临时缓冲区获取操作结果即可。

 （4） 当需要控制对一个对象的访问，为不同用户提供不同级别的访问权限时可以使用保护代理。

 （5）当需要为一个对象的访问（引用）提供一些额外的操作时可以使用智能引用代理。

 优点：
 （1）代理模式能够将调用用于真正被调用的对象隔离，在一定程度上降低了系统的耦合度；

 （2）代理对象在客户端和目标对象之间起到一个中介的作用，这样可以起到对目标对象的保护。代理对象可以在对目标对象发出请求之前进行一个额外的操作，例如权限检查等。

不同类型的代理模式也具有独特的优点，例如：
（1）远程代理为位于两个不同地址空间对象的访问提供了一种实现机制，可以将一些消耗资源较多的对象和操作移至性能更好的计算机上，提高系统的整体运行效率。

（2）虚拟代理通过一个消耗资源较少的对象来代表一个消耗资源较多的对象，可以在一定程度上节省系统的运行开销。

（3）缓冲代理为某一个操作的结果提供临时的缓存存储空间，以便在后续使用中能够共享这些结果，优化系统性能，缩短执行时间。

（4）保护代理可以控制对一个对象的访问权限，为不同用户提供不同级别的使用权限。

 缺点：
（1）由于在客户端和真实主题之间增加了一个代理对象，所以会造成请求的处理速度变慢。

（2）实现代理类也需要额外的工作，从而增加了系统的实现复杂度。
 */


Console.Title = "Proxy";


//without Proxy
Console.WriteLine("Constructing document");
var myDocument = new Proxy.Document("MyDocument.pdf");
Console.WriteLine("Document Constructed");
myDocument.DisplayDocument();


Console.WriteLine();

//with Proxy
Console.WriteLine("Constructing document Proxy");
var myDocumentProxy = new Proxy.DocumentProxy("MyDocument.pdf");
Console.WriteLine("Document Constructed");
myDocumentProxy.DisplayDocument();


Console.WriteLine();

//with chained Proxy
Console.WriteLine("Constructing protected document proxy");
var myProtectedDocumentProxy = new Proxy.ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
Console.WriteLine("Protected document proxy Constructed");
myProtectedDocumentProxy.DisplayDocument();

Console.ReadKey();
