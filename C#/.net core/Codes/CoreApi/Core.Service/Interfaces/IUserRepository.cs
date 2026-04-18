using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Models;
using Core.Service.Hepler;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IUserRepository: IBase
    {
        Task<User> GetUserAsyncById(Guid userId);
        Task<ExecuteOutParam<User>> GetUsersAsync(UserQueryParam userQueryParam);
        Task<User> AddUserAsync(User user,bool save);
        Task UpdateUserAsync(User user,bool save);
        Task DeleteUserAsync(Guid userId, bool save);
    }
}
