using Core.Entity.DBEntity;
using Core.Entity.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IDepartmentRepository : IBase
    {
        Task<ICollection<Department>> GetDepartments();

        Task AddDepartmentAsync(Department department,bool save);

        Task UpdateDepartmentAsync(Department department, bool save);

        Task DeleteDepartmentAsync(Guid deptId, bool save);

        Task<Department> GetDepartmentById(Guid departmentId);
    }
}
