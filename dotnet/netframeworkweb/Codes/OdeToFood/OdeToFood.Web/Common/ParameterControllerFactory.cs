using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using OdeToFood.Web.Controllers;

namespace OdeToFood.Web.Common
{
    public class ParameterControllerFactory:IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (controllerName.Equals("contact"))
            {
                return new ContactController(new Logger());
            }
            else
            {
                return new StudentController();
            }
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            
        }

        public class Logger:ILoggingService
        {
            
        }
    }
}