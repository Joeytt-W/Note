using Core.Entity.DBEntity;
using Core.Service.Data;
using Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service.Services
{
    public class RoleUserRepository : IRoleUserRepository
    {
        private readonly CoreDbContext _context;

        public RoleUserRepository(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddRoleUserAsync(RoleUser roleUser,bool save)
        {
            _context.RoleUsers.Add(roleUser);
            if (save)
                await SaveAsync();
        }

        public async Task DeleteRoleUserAsync(ICollection<RoleUser> roleUsers,bool save)
        {
            _context.RoleUsers.RemoveRange(roleUsers);
            if (save)
                await SaveAsync();
        }

        public async Task<ICollection<RoleUser>> GetUserRoleByUserIDAsync(Guid UserID)
        {
            return await _context.RoleUsers.Where(x => x.UserID == UserID).ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid userId)
        {
            return await _context.RoleUsers.AnyAsync(x => x.UserID == userId); 
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
