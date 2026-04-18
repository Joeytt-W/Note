using Bridge;
/*
 意图：将抽象部分与实现部分分离，使它们都可以独立地变化

桥模式不能只是认为是抽象和实现的分离，它其实并不仅限于此。其实两个都是抽象的部分，更确切的理解，应该是将一个事物中多个维度的变化分离。

 优点：
 （1）把抽象接口与其实现解耦。

 （2）抽象和实现可以独立扩展，不会影响到对方。

 （3）对客户隐藏了具体实现细节。

 缺点：增加了系统的复杂度

 使用场景：
 （1）如果一个系统需要在构件的抽象化角色和具体化角色之间添加更多的灵活性，避免在两个层次之间建立静态的联系。

 （2）设计要求实现化角色的任何改变不应当影响客户端，或者实现化角色的改变对客户端是完全透明的。

 （3）需要跨越多个平台的图形和窗口系统上。

 （4）一个类存在两个独立变化的维度，且两个维度都需要进行扩展。
 */
Console.Title = "bridge";

var noCoupon = new NoCoupon();
var oneEuroCoupon = new OneEuroCoupon();
var twoEuroCoupon = new TwoEuroCoupon();

var meatBasedMenu = new MeatBasedMenu(noCoupon);
Console.WriteLine($"Meat based menu,no coupon: {meatBasedMenu.CalculatePrice()} euro");

meatBasedMenu = new MeatBasedMenu(oneEuroCoupon);
Console.WriteLine($"Meat based menu,one coupon: {meatBasedMenu.CalculatePrice()} euro");

var vegetarianMenu = new VegetarianMenu(noCoupon);
Console.WriteLine($"vegetable based menu,no coupon: {vegetarianMenu.CalculatePrice()} euro");

vegetarianMenu = new VegetarianMenu(twoEuroCoupon);
Console.WriteLine($"vegetable based menu,two coupon: {vegetarianMenu.CalculatePrice()} euro");

Console.ReadKey();