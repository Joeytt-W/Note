using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TheCodeCamp.Controllers
{
    public class OperationController : ApiController
    {
        [HttpOptions]
        [Route("api/RefreshConfig")]
        public IHttpActionResult RefreshAppSettings()
        {
            try
            {
                ConfigurationManager.RefreshSection("AppSettings");

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
        }
    }
}