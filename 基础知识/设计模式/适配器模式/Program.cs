using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 适配器模式.ClassAdapter;
using 适配器模式.ObjAdapter;

namespace 适配器模式
{
    /// <summary>
    /// 在以下情况下可以考虑使用适配器模式：
    /// 系统需要复用现有类，而该类的接口不符合系统的需求
    /// 想要建立一个可重复使用的类，用于与一些彼此之间没有太大关联的一些类，包括一些可能在将来引进的类一起工作。
    /// 对于对象适配器模式，在设计里需要改变多个已有子类的接口，如果使用类的适配器模式，就要针对每一个子类做一个适配器，而这不太实际。
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            //类适配器
            IThreeHole threeHole = new ThreeHoleAdapter();
            threeHole.UseThreeHole();


            //对象适配器
            ThreeHole three = new ThreeHoleAdapter2();
            three.UseThreeHole();

            Console.ReadKey();
        }
    }
}
