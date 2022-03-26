using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 适配器模式.ClassAdapter
{
    public abstract class TowHole
    {
        public void UseTowHole()
        {
            Console.WriteLine("启用两脚插头...");
        }
    }
}
