using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThreeRazorPage.Services;

namespace ThreeRazorPage.ViewComponents
{
    public class CompanySummaryViewComponent:ViewComponent
    {
        private readonly IDepartmentService _departmentService;

        public CompanySummaryViewComponent(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// 方法名是固定的
        /// </summary>
        /// <returns></returns>
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary = await _departmentService.GetCompanySummary();
            return View(summary);
        }
    }
}
