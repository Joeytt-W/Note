using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApiDemo.Models;

namespace WebApiDemo.Filters.ActionFilters
{
    public class Shirt_ValidateUpdateFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            var id = context.ActionArguments["id"] as int?;
            Shirt? shirt = context.ActionArguments["shirt"] as Shirt;
            if(id.HasValue && shirt != null && id != shirt.ShirtId)
            {
                context.ModelState.AddModelError("ShirtId", "id is not the same as ShirtId.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
        }
    }
}
