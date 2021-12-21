using SortingUtils;
using System;

namespace TestSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 5, 9, 20, 7, 35, 6, 4, 100 };

            string[] strArr = new string[] { "mmmm", "mlll", "kil", "afds", "csab", "zmmmlg", "pkg" };

            arr.BubbleSorting();
            strArr.BubbleSorting();

            foreach(string i in strArr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
