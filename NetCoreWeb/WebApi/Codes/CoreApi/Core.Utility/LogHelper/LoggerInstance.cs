using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utility.LogHelper
{
    public class LoggerInstance
    {
        private LoggerInstance()
        {

        }

        private static ILogger logger = null;
        private static object Singleton_Lock = new object(); //锁同步

        public static ILogger CreateDbLogInstance()
        {
            if(logger == null)
            {
                lock (Singleton_Lock)
                {
                    if (logger == null)
                    {
                        logger = LogManager.GetLogger("logdb");
                    }
                }
            }
            return logger;
        }

        public static ILogger CreateFileLogInstance()
        {
            if (logger == null)
            {
                lock (Singleton_Lock)
                {
                    if (logger == null)
                    {
                        logger = LogManager.GetLogger("logfile");
                    }
                }
            }
            return logger;
        }
    }
}
