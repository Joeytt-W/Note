using System.Linq;
using CodeMan.Redis.Entities;
using CodeMan.Redis.Service.Repository;

namespace CodeMan.Redis.Base.EntityFrameworkCore.Repository
{
    public class UserRepository : RepositoryBase<Account>, IUserRepository
    {
        public UserRepository(RedisDbContext repositoryContext) : base(repositoryContext) { }

        public Account GetUserById(int id)
        {
            return FindByCondition(user => user.UserId == id)
                .FirstOrDefault();
        }
    }
}