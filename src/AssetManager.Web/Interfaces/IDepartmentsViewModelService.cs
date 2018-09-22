using AssetManager.Core.Entities;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        Task<IEnumerable<Departments>> GetAllDepartmentsAsync();
        Task<IEnumerable<SelectListItem>> GetDepartment();
    }
}
