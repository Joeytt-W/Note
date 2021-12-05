using log4net;
using System;

namespace _01_SimpleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger("Main");
            log.Debug("调试信息");
            log.Warn("警告");
            Console.ReadKey();
        }
    }
}
