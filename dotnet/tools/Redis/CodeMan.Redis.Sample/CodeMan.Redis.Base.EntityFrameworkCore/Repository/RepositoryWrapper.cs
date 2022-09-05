using CodeMan.Redis.Service.Repository;

namespace CodeMan.Redis.Base.EntityFrameworkCore.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RedisDbContext _redisDbContext;
        private IUserRepository _user;

        public IUserRepository User
        {
            get { return _user ??= new UserRepository(_redisDbContext); }
        }

        public RepositoryWrapper(RedisDbContext redisDbContext)
        {
            _redisDbContext = redisDbContext;
        }
    }
}