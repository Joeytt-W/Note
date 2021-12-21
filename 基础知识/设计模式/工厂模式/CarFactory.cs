using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class CarFactory
    {
        public ICar CreateCar(CarType carType)
        {
            if (carType == CarType.BaoMa)
                return new BaoMa();
            else if (carType == CarType.BenChi)
                return new BenChi();
            else
                return null;
        }
    }
}
