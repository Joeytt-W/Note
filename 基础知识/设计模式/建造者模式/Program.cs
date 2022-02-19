using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 建造者模式的优点：
/// （1）、使用建造者模式可以使客户端不必知道产品内部组成的细节。
/// （2）、具体的建造者类之间是相互独立的，容易扩展。
/// （3）、由于具体的建造者是独立的，因此可以对建造过程逐步细化，而不对其他的模块产生任何影响。
/// </summary>
namespace 建造者模式
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerDirector director = new ComputerDirector();
            ComputerBuilder builder = new HuaWeiComputerBuilder("I5处理器", "海力士");
            director.MakeComputer(builder);
            Computer computer = builder.GetComputer();
            Console.WriteLine(computer.ToString());
            Console.ReadKey();
        }
    }
}
