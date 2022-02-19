using System;
/// <summary>
/// 优点：用户只需要知道所要产品的具体工厂，无须关系具体的创建过程
///      在系统增加新的产品时，我们只需要添加一个具体产品类和对应的实现工厂，无需对原工厂进行任何修改，很好地符合了“开闭原则”
/// 缺点：每次增加一个产品时，都需要增加一个具体类和对象实现工厂，是的系统中类的个数成倍增加，在一定程度上增加了系统的复杂度
/// 使用场景：数据库，日志
/// </summary>
namespace 工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            IGetNewCar getNewCar = new GetNewCar();

            ICar car = getNewCar.GetCar(CarType.BaoMa);
            car.Go();
            Console.ReadKey();
        }
    }
}
