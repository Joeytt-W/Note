using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OdeToFood.Data.Services;
using OdeToFood.Web.Extensions;

namespace OdeToFood.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _db;

        public HomeController(IRestaurantData db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            var model = _db.GetAll();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [IsMobile]
        public JsonResult Register()
        {
            return Json("{Message display on Mobile devices}");
        }

        public ActionResult TestJsonNetResult(object data)
        {

            return new JsonNetResult(){ Data = data };
        }
    }
}