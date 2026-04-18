using static ClassAdapter.CityFromExternalSystem;
/*
 意图：将一个类的接口转换成客户希望的另一个接口。Adapter模式使得原本由于接口不兼容而不能一起工作的那些类可以一起工作。

类的适配器
 优点：
 （1）可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”。

 （2）可以重新定义Adaptee(被适配的类)的部分行为，因为在类适配器模式中，Adapter是Adaptee的子类。

 （3）仅仅引入一个对象，并不需要额外的字段来引用Adaptee实例（这个即是优点也是缺点）。

 缺点：
 （1）用一个具体的Adapter类对Adaptee和Target进行匹配，当如果想要匹配一个类以及所有它的子类时，类的适配器模式就不能胜任了。因为类的适配器模式中没有引入Adaptee的实例，光调用this.SpecificRequest方法并不能去调用它对应子类的SpecificRequest方法。

 （2）采用了 “多继承”的实现方式，带来了不良的高耦合。

对象的适配器
 优点：
 （1）可以在不修改原有代码的基础上来复用现有类，很好地符合 “开闭原则”（这点是两种实现方式都具有的）

 （2）采用 “对象组合”的方式，更符合松耦合。

 缺点：使得重定义Adaptee的行为较困难，这就需要生成Adaptee的子类并且使得Adapter引用这个子类而不是引用Adaptee本身。

 使用场景：
 （1）如果一个系统需要在构件的抽象化角色和具体化角色之间添加更多的灵活性，避免在两个层次之间建立静态的联系。

 （2）设计要求实现化角色的任何改变不应当影响客户端，或者实现化角色的改变对客户端是完全透明的。

 （3）需要跨越多个平台的图形和窗口系统上。

 （4）一个类存在两个独立变化的维度，且两个维度都需要进行扩展。
 */
Console.Title = "Adapter";

ICityAdapter adapter = new CityAdapter();
var city = adapter.GetCity();

Console.WriteLine(city.FullName);
Console.WriteLine(city.Inhabitants);

Console.ReadKey();
