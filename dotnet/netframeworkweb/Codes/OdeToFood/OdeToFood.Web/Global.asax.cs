using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using OdeToFood.Web;
using OdeToFood.Web.Common;
using OdeToFood.Web.Modules;

//before Application_Start
[assembly:PreApplicationStartMethod(typeof(MvcApplication),"Register")]

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        #region MVC Request生命周期
        protected void Application_Start()
        {
            //自定义  ControllerFactory  构造Controller
            //ControllerBuilder.Current.SetControllerFactory(new ParameterControllerFactory());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContainerConfig.RegisterContainer();
        }

        protected void Application_BeginRequest()
        {
            Debug.WriteLine("Application_BeginRequest");
        }

        protected void Application_MapRequestHandler()
        {
            Debug.WriteLine("Application_MapRequestHandler");
        }

        protected void Application_PostMapRequestHandler()
        {
            Debug.WriteLine("Application_PostMapRequestHandler");
        }

        protected void Application_AcquireRequestState()
        {
            Debug.WriteLine("Application_AcquireRequestState");
        }

        protected void Application_PreRequestHandlerExecute()
        {
            Debug.WriteLine("Application_PreRequestHandlerExecute");
        }

        protected void Application_PostRequestHandlerExecute()
        {
            Debug.WriteLine("Application_PostRequestHandlerExecute");
        }

        protected void Application_EndRequest()
        {
            Debug.WriteLine("Application_EndRequest");
        }

        protected void Application_End()
        {
            Debug.WriteLine("Application_End");
        }
        #endregion

        public static void Register()
        {
            HttpApplication.RegisterModule(typeof(TestModule));
            Debug.WriteLine("PreApplicationStart");
        }
    }
}
