using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 适配器模式.ObjAdapter
{
    public abstract class ThreeHole
    {
        public virtual void UseThreeHole()
        {
            Console.WriteLine("启用三脚插头...");
        }
    }
}
