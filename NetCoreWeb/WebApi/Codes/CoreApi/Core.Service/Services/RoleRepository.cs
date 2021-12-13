using AutoMapper;
using Core.Entity.DBEntity;
using Core.Entity.Dto;
using Core.Entity.Enum;
using Core.Service.Data;
using Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Services
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CoreDbContext _context;

        public RoleRepository(CoreDbContext context)
        {
            _context = context ??  throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task AddRoleAsync(Role role,bool save)
        {
            role.CreateTime = DateTime.Now;
            _context.Roles.Add(role);
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task DeleteRoleAsync(Guid roleId,bool save)
        {
            _context.Roles.Remove(_context.Roles.Find(roleId));
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(Guid Id)
        {
            return await _context.Roles.AnyAsync(x => x.ID == Id);
        }

        /// <summary>
        /// 按ID查询角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<Role> GetRoleById(Guid roleId)
        {
            return await _context.Roles.FindAsync(roleId);
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="role"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task UpdateRoleAsync(Role role,bool save)
        {
            role.UpdateTime = DateTime.Now;
            _context.Roles.Update(role);
            if (save)
                await SaveAsync();
        }
    }
}
