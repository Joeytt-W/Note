using CodeMan.Redis.Entities;
using CodeMan.Redis.Service.Repository;

using System.Diagnostics;
using System;
using CodeMan.Redis.Base.Redis;
using Newtonsoft.Json;

namespace CodeMan.Redis.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly RedisConfig _redis;

        public UserService(IRepositoryWrapper repository, RedisConfig redis)
        {
            _repository = repository;
            _redis = redis;
        }

        public Account GetAllUsers(int id)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string key = "user:" + id;
            string result = _redis.Get(key);
            Account users = new Account();
            if (!string.IsNullOrWhiteSpace(result))
            {
                users = JsonConvert.DeserializeObject<Account>(result);
                Console.WriteLine("缓存查询");
            }
            else
            {
                users = _repository.User.GetUserById(id);
                _redis.Set("user:" + id, JsonConvert.SerializeObject(users));
                Console.WriteLine("接口查询");
            }
            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            Console.WriteLine($"用时:{timeSpan.TotalMilliseconds} 毫秒");
            return users;
        }
    }
}