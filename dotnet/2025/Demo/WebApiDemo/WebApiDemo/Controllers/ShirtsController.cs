using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Data;
using WebApiDemo.Filters.ActionFilters;
using WebApiDemo.Filters.ExceptionFilters;
using WebApiDemo.Models;
using WebApiDemo.Models.Repositories;

namespace WebApiDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public ShirtsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        //[Route("/Shirts")]
        public IActionResult GetShirts()
        {
            return Ok(_db.Shirts.ToList());
        }

        [HttpGet]
        //[Route("/Shirts/{id}")]
        [Route("{id}")]
        //[Shirt_ValidateShirtIdFilter]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult GetShirtById(int id)
        {
            //if (id <= 0)
            //    return BadRequest();

            //var shirt = ShirtRepository.GetShirtById(id);
            //if (shirt == null)
            //    return NotFound();

            //return Ok(_db.Shirts.First(t => t.ShirtId == id));
            return Ok(HttpContext.Items["shirt"]);
        }

        [HttpPost]
        [TypeFilter(typeof(Shirt_ValidateCreateFilterAttribute))]
        //[Route("/Shirts/{id}")]
        //[Route("{id}")]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            //if(shirt == null)
            //{
            //    return BadRequest();
            //}

            //var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand,shirt.Gender,shirt.Color,shirt.Size);
            //if(existingShirt != null)
            //{
            //    ModelState.AddModelError("ShirtExists", "相同属性的衬衫已存在");
            //    var problemDetails = new ValidationProblemDetails(ModelState)
            //    {
            //        Status = StatusCodes.Status409Conflict
            //    };
            //    return Conflict(problemDetails);
            //}
            //ShirtRepository.AddShirt(shirt);
            _db.Shirts.Add(shirt);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetShirtById), new { id = shirt.ShirtId }, shirt);//返回一个201状态码，并在响应头中包含新创建资源的URI
        }

        [HttpPut("{id}")]
        //[Route("/Shirts/{id}")]
        //[Route("{id}")]
        //[Shirt_ValidateShirtIdFilter]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionFilterAttribute))]
        public IActionResult UpdateShirt(int id,Shirt shirt)
        {
            var shirtToUpdate = HttpContext.Items["shirt"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Price = shirt.Price;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        //[Route("/Shirts/{id}")]
        //[Route("{id}")]
        //[Shirt_ValidateShirtIdFilter]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult DeleteShirt(int id)
        {
            var shirtToDelete = HttpContext.Items["shirt"] as Shirt;

            _db.Shirts.Remove(shirtToDelete);
            _db.SaveChanges();

            return Ok(shirtToDelete);
        }
    }
}
