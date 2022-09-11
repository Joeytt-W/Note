using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OdeToFood.Web.Common;

namespace OdeToFood.Web.Controllers
{
    public class ContactController : IController
    {
        public ContactController(ILoggingService logging)
        {
            
        }

        public void Execute(RequestContext requestContext)
        {
            HttpContext.Current.Response.Write("This was returned by custom IController class.");
        }
    }
}