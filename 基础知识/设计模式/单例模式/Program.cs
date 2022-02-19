using System;
/// <summary>
/// 优点：Singleton 会阻止其他对象实例化其自己的 Singleton 对象的副本，从而确保所有对象都访问唯一实例
///     单例可以继承类，实现接口，而静态类不能
///     因为类控制了实例化过程，所以类可以灵活更改实例化过程
///     单例可以被延迟初始化，静态类一般在第一次加载是初始化
/// 缺点：检查是否存在类的实例，将仍然需要一些开销
///     随程序关闭而释放内存
/// </summary>
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var single = TestSingleton.GetInstance();
            Console.WriteLine("===================");
            single.Write();
            Console.ReadKey();

        }
    }
}
