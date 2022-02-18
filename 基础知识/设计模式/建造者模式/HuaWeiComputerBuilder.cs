using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    public class HuaWeiComputerBuilder : ComputerBuilder
    {
        private readonly Computer computer;

        public HuaWeiComputerBuilder(string cpu, string ram)
        {
            computer = new Computer(cpu, ram);
        }

        public override Computer GetComputer()
        {
            return computer;
        }

        public override void SetDisPlay()
        {
            computer.setDisplay("京东方屏");
        }

        public override void SetKeyBoard()
        {
            computer.setKeyboard("罗技键盘");
        }

        public override void SetUSBCount()
        {
            computer.setUsbCount(4);
        }
    }
}
