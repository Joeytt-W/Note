using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TestSingleton
    {
        private static TestSingleton _single = null;
        private static object singleTonLock = new object();
        private TestSingleton()
        {
            Console.WriteLine("Init SingleTon...");
        }

        public static TestSingleton GetInstance()
        {
            if (_single == null)
            {
                lock (singleTonLock)
                {
                    if (_single == null)
                        _single = new TestSingleton();
                }
            }
                     
            return _single;
        }

        public void Write()
        {
            Console.WriteLine("Method Write...");
        }
    }
}
