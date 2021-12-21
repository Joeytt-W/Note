using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 工厂模式
{
    public class BenChi : ICar
    {
        public void CreateCar()
        {
            Console.WriteLine("造一辆奔驰车");
        }
    }
}
