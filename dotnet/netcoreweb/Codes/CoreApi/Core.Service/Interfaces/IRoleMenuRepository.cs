using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.Dto;
using Core.Entity.Models;

namespace Core.Service.Interfaces
{
    public interface IRoleMenuRepository:IBase
    {
        Task<bool> CreateRoleMenuAsync(RoleMenuAddDto roleMenuAddDto);
    }
}
