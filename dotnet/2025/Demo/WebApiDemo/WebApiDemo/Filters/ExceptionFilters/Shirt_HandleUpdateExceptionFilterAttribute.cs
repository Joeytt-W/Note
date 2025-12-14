using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Data;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters.ExceptionFilters
{
    /// <summary>
    /// 更新衬衫时处理异常的过滤器
    /// </summary>
    public class Shirt_HandleUpdateExceptionFilterAttribute:ExceptionFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public Shirt_HandleUpdateExceptionFilterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
            var id = context.RouteData.Values["id"] as string;
            if(int.TryParse(id,out int shirtId)) 
            {
                if (_db.Shirts.FirstOrDefault(t => t.ShirtId == shirtId) == null)//若更新时已被删除
                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }                
            }
        }
    }
}
