using AssetManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
    public interface IDepartmentsViewModelService
    {
        Task AddDepartmentsAsync(DepartmentsViewModel departmentsVM, string userId);
        Task DeleteDepartmentsAsync(int id);
        Task<DepartmentsViewModel> GetDepartmentsAsync(int id);
        Task UpdateDepartmentsAsync(DepartmentsViewModel departmentsVM, string userId);
        IEnumerable<DepartmentsViewModel> GetAllDepartments();
        Task<IEnumerable<DepartmentsViewModel>> GetAllDepartmentsAsync();
    }
}
