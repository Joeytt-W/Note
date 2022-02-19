using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    public abstract class ComputerBuilder
    {
        public abstract void SetUSBCount();

        public abstract void SetKeyBoard();

        public abstract void SetDisPlay();

        public abstract Computer GetComputer();
    }
}
