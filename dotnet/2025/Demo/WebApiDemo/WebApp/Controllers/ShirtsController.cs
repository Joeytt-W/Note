using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Repositories;

namespace WebApp.Controllers
{
    public class ShirtsController : Controller
    {
        private readonly IWebApiExecuter _executer;

        public ShirtsController(IWebApiExecuter executer)
        {
            _executer = executer;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _executer.InvokeGet<List<Shirt>>("shirts"));
        }
    }
}
