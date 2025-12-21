using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Shirt shirt)
        {
            // Implementation for editing a shirt would go here
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await _executer.InvokePost("shirts", shirt);
                    if (response != null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (WebApiException ex)
                {
                    HandleWebApiException(ex);
                }
            }
            return View(shirt);
        }

        public async Task<IActionResult> Update(int shirtId)
        {
            try
            {
                var shirt = await _executer.InvokeGet<Shirt>($"shirts/{shirtId}");
                if (shirt != null)
                {
                    return View(shirt);
                }
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View();
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Update(Shirt shirt)
        {
            // Implementation for editing a shirt would go here
            if (ModelState.IsValid)
            {
                try
                {
                    await _executer.InvokePut($"shirts/{shirt.ShirtId}", shirt);
                    return RedirectToAction(nameof(Index));
                }
                catch (WebApiException ex)
                {
                    HandleWebApiException(ex);
                }        
            }
            return View(shirt);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int shirtId)
        {
            try
            {
                await _executer.InvokeDelete($"shirts/{shirtId}");
                return RedirectToAction(nameof(Index));
            }
            catch (WebApiException ex)
            {
                HandleWebApiException(ex);
                return View(nameof(Index), await _executer.InvokeGet<List<Shirt>>("shirts"));
            }
        }

        private void HandleWebApiException(WebApiException ex)
        {
            if (ex.ErrorResponse != null && ex.ErrorResponse.Errors != null && ex.ErrorResponse.Errors.Count > 0)
            {
                foreach (var err in ex.ErrorResponse.Errors)
                {
                    ModelState.AddModelError(err.Key, string.Join("; ", err.Value));
                }
            }
            else if(ex.ErrorResponse != null)
            {
                ModelState.AddModelError("Error", ex.ErrorResponse.Title);
            }
            else
            {
                ModelState.AddModelError("Error", ex.Message);
            }
        }
    }
}
