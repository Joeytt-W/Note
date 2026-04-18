using CodeMan.Redis.Entities;

namespace CodeMan.Redis.Service.Service
{
    public interface IUserService
    {
        Account GetAllUsers(int id);
    }
}