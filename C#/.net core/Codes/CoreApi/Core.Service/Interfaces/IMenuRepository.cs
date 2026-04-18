using Core.Entity.DBEntity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IMenuRepository:IBase
    {
        Task<Menu> GetMenuById(Guid menuId);

        Task<ICollection<Menu>> GetMenus();

        Task UpdateMenuAsync(Menu menu, bool save);

        Task AddMenuAsync(Menu menu, bool save);

        Task DeleteMenu(Guid menuId, bool save);
    }
}
