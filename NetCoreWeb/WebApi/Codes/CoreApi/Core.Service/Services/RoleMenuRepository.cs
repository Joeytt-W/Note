using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Models;
using Core.Service.Data;
using Core.Service.Interfaces;

namespace Core.Service.Services
{
    public class RoleMenuRepository: IRoleMenuRepository
    {
        private readonly CoreDbContext _context;

        public RoleMenuRepository(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="roleMenuAddDto"></param>
        /// <returns></returns>
        public async Task<bool> CreateRoleMenuAsync(RoleMenuAddDto roleMenuAddDto)
        {
            foreach (var menuId in roleMenuAddDto.MenuIds)
            {
                var roleMenu = new RoleMenu()
                {
                    RoleID = roleMenuAddDto.RoleId,
                    MenuID = menuId,
                    CreateTime = DateTime.Now,
                    CreateUser = roleMenuAddDto.CreateUser
                };
                await _context.AddAsync(roleMenu);
            }

            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public Task<bool> ExistsAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
