using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class GetNewCar : IGetNewCar
    {
        public ICar GetCar(CarType carType)
        {
            CarFactory carFactory;
            if (carType == CarType.BaoMa)
                carFactory = new BaoMaFactory();
            else if (carType == CarType.BenChi)
                carFactory = new BenChiFactory();
            else
                throw new Exception();
            return carFactory.CreateCar();

        }
    }
}
