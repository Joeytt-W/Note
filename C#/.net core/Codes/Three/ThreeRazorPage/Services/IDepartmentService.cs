using System.Collections.Generic;
using System.Threading.Tasks;
using ThreeRazorPage.Models;

namespace ThreeRazorPage.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAll();

        Task<Department> GetById(int id);

        Task<CompanySummary> GetCompanySummary();

        Task Add(Department department);
    }
}
