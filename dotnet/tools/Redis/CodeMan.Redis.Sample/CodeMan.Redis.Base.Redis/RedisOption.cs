using System;

namespace CodeMan.Redis.Base.Redis
{
    public class RedisOption
    {
        public string Connection { get; set; }
        public string InstanceName { get; set; }
        public int DefaultDb { get; set; }
    }
}
