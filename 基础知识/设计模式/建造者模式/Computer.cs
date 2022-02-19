using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 建造者模式
{
    public class Computer
    {
        private string cpu;//必须
        private string ram;//必须
        private int usbCount;//可选
        private string keyboard;//可选
        private string display;//可选

        public Computer(string cpu, string ram)
        {
            this.cpu = cpu;
            this.ram = ram;
        }

        public void setUsbCount(int usbCount)
        {
            this.usbCount = usbCount;
        }
        public void setKeyboard(string keyboard)
        {
            this.keyboard = keyboard;
        }
        public void setDisplay(string display)
        {
            this.display = display;
        }

        public override string ToString()
        {
            return "Computer{" +
                    "cpu='" + cpu + '\'' +
                    ", ram='" + ram + '\'' +
                    ", usbCount=" + usbCount +
                    ", keyboard='" + keyboard + '\'' +
                    ", display='" + display + '\'' +
                    '}';
        }
    }
}
