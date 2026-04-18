using System;
using System.Diagnostics;
using System.Threading;
using CodeMan.Redis.Base.Redis;
using CodeMan.Redis.Entities;
using CodeMan.Redis.Service.Repository;
using CodeMan.Redis.Service.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace CodeMan.Redis.HttpApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly RedisConfig _redis;

        public UserController(IUserService userService, RedisConfig redis)
        {
            _userService = userService;
            _redis = redis;
        }

        [HttpGet("id")]
        public IActionResult GetAllUsers(int id)
        {
            Account account = _userService.GetAllUsers(id);
            return Ok(account);
        }

        [HttpGet]
        public IActionResult Test()
        {
            _redis.Set("hello", "CodeMan");
            string value = _redis.Get("hello");
            return Ok(value);
        }
    }
}
