using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 适配器模式.ObjAdapter
{
    public class ThreeHoleAdapter2:ThreeHole
    {
        private readonly TowHole2 _two = new TowHole2();

        public override void UseThreeHole()
        {
            _two.UseTowHole();
        }
    }
}
