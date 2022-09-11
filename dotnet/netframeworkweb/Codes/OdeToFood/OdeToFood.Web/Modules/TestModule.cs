using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Modules
{
    public class TestModule:IHttpModule
    {
        public void Init(HttpApplication context)
        {
            Debug.WriteLine("TestModule Init");
        }

        public void Dispose()
        {
            Debug.WriteLine("TestModule Dispose");
        }
    }
}