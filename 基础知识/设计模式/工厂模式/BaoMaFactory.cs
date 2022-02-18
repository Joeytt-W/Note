using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class BaoMaFactory : CarFactory
    {
        public override ICar CreateCar()
        {
            return new BaoMa();
        }
    }
}
