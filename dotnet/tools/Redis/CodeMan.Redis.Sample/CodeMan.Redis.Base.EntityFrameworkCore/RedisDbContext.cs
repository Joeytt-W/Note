using CodeMan.Redis.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeMan.Redis.Base.EntityFrameworkCore
{
    public class RedisDbContext : DbContext
    {
        public RedisDbContext(DbContextOptions<RedisDbContext> options) : base(options)
        {

        }

        public DbSet<Account> Users { get; set; }
    }
}