using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OdeToFood.Web.Handles
{
    public class SampleHandle:IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("<p>This is a custom Handle</p>");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}