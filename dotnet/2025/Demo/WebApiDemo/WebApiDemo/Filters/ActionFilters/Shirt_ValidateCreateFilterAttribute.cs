using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Drawing;
using System.Reflection;
using WebApiDemo.Data;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Filters.ActionFilters
{
    /// <summary>
    /// 过滤器
    /// 验证是否有相同属性的资料
    /// </summary>
    public class Shirt_ValidateCreateFilterAttribute: ActionFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public Shirt_ValidateCreateFilterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Shirt? shirt = context.ActionArguments["shirt"] as Shirt;
            if(shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                { 
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingShirt = _db.Shirts.FirstOrDefault(s => !string.IsNullOrWhiteSpace(shirt.Brand) && !string.IsNullOrWhiteSpace(s.Brand) && s.Brand.ToLower()== shirt.Brand.ToLower() &&
                                                                   !string.IsNullOrWhiteSpace(shirt.Gender) && !string.IsNullOrWhiteSpace(s.Gender) && s.Gender.ToLower() == shirt.Gender.ToLower() &&
                                                                   !string.IsNullOrWhiteSpace(shirt.Color) && !string.IsNullOrWhiteSpace(s.Color) && s.Color.ToLower() == shirt.Color.ToLower() &&
                                                                   shirt.Size.HasValue && s.Size.HasValue && s.Size.Value == shirt.Size.Value);

                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("ShirtExists", "相同属性的衬衫已存在");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetails);
                }
            }
        }
    }
}
