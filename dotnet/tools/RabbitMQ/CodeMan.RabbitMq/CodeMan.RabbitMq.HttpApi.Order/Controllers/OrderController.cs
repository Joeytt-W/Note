using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeMan.RabbitMq.Service;

namespace CodeMan.RabbitMq.HttpApi.Order.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Order()
        {
            _orderService.SendOrderMessage();
            return Ok();
        }

        [HttpGet("test")]
        public IActionResult Test(string message)
        {
            _orderService.SendTestMessage(message);
            return Ok();
        }
    }
}
