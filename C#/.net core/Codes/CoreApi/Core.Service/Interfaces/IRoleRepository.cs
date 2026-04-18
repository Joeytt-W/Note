using Core.Entity.DBEntity;
using Core.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IRoleRepository:IBase
    {
        Task<Role> GetRoleById(Guid roleId);
        Task<ICollection<Role>> GetRoles();
        Task UpdateRoleAsync(Role role,bool save);
        Task AddRoleAsync(Role role,bool save);
        Task DeleteRoleAsync(Guid roleId,bool save);
    }
}
