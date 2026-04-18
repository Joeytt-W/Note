using Core.Entity.DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IRoleUserRepository : IBase
    {
        Task<ICollection<RoleUser>> GetUserRoleByUserIDAsync(Guid UserID);
        Task AddRoleUserAsync(RoleUser roleUser,bool save);
        Task DeleteRoleUserAsync(ICollection<RoleUser> roleUsers,bool save);
    }
}
