using System;

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
