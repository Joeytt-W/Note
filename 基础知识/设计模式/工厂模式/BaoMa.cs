using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class BaoMa : ICar
    {
        public void CreateCar()
        {
            Console.WriteLine("造一辆宝马车");
        }
    }
}
