using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IBase
    {
        Task<bool> SaveAsync();

        Task<bool> ExistsAsync(Guid Id);
    }
}
