using System;

namespace 工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
            CarFactory carFactory = new CarFactory();
            ICar newCar = carFactory.CreateCar(CarType.BaoMa);
            newCar.CreateCar();
            Console.ReadKey();
        }
    }
}
