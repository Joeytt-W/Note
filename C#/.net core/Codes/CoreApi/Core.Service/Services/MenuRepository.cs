using Core.Entity.DBEntity;
using Core.Service.Data;
using Core.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utility;

namespace Core.Service.Services
{
    public class MenuRepository : IMenuRepository
    {
        private readonly CoreDbContext _context;
        public MenuRepository(CoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task AddMenuAsync(Menu menu, bool save)
        {
            menu.CreateTime = DateTime.Now;
            menu.Spell = CommonUtil.GetPYCode(menu.MenuName);
            await _context.Menus.AddAsync(menu);
            if (save)
                await SaveAsync();
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task DeleteMenu(Guid menuId, bool save)
        {
            _context.Menus.Remove(await _context.Menus.FindAsync(menuId));
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<bool> ExistsAsync(Guid Id)
        {
            return _context.Menus.AnyAsync(m => m.ID == Id);
        }

        /// <summary>
        /// 根据ID查询菜单
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public async Task<Menu> GetMenuById(Guid menuId)
        {
            return await _context.Menus.FindAsync(menuId);
        }

        /// <summary>
        /// 获取菜单集合
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Menu>> GetMenus()
        {
            return await _context.Menus.ToListAsync();
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
        /// 更新菜单
        /// </summary>
        /// <param name="menu"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public async Task UpdateMenuAsync(Menu menu, bool save)
        {
            menu.UpdateTime = DateTime.Now;
            menu.Spell = CommonUtil.GetPYCode(menu.MenuName);
            _context.Menus.Update(menu);
            if (save)
                await SaveAsync();
        }
    }
}
