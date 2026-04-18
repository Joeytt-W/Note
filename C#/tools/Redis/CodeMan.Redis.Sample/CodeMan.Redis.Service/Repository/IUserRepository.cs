using CodeMan.Redis.Entities;

namespace CodeMan.Redis.Service.Repository
{
    public interface IUserRepository : IRepositoryBase<Account>
    {
        Account GetUserById(int id);
    }
}