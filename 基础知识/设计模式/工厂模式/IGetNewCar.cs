using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public interface IGetNewCar
    {
        public ICar GetCar(CarType carType);
    }
}
