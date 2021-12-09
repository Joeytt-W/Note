using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Three.Models;
using Three.Services;

namespace Three.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOptions<DefaultLog> _deOptions;

        public DepartmentController(IDepartmentService departmentService,IOptions<DefaultLog> deOptions)
        {
            this._departmentService = departmentService??throw new ArgumentNullException(nameof(departmentService));
            _deOptions = deOptions;
        }

        public async Task<IActionResult> Index()
        {
            string defaultStr =_deOptions.Value.LogLevel.Default;
            ViewBag.Title = "Department Index";
            var departments =await  _departmentService.GetAll();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if(ModelState.IsValid)
                await _departmentService.Add(department);
            return RedirectToAction(nameof(Index));
        }
    }
}
