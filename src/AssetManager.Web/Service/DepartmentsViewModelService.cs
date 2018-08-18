using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Service
{
    /// <summary>
    /// This is a UI-specific service so belongs in UI project. It does not contain any business logic and works
    /// with UI-specific types (view models and SelectListItem types).
    /// </summary>
    public class DepartmentsViewModelService : IDepartmentsViewModelService
    {
        private readonly ILogger<DepartmentsViewModelService> _logger;
        private readonly IAsyncRepository<Departments> _asyncRepository;
        private readonly IRepository<Departments> _repository;
        public DepartmentsViewModelService
            (
            ILoggerFactory loggerFactory,
            IAsyncRepository<Departments> asyncRepository, 
            IRepository<Departments> repository
            )
        {
            this._asyncRepository = asyncRepository;
            this._repository = repository;
            this._logger = loggerFactory.CreateLogger<DepartmentsViewModelService>();
        }

        public async Task AddDepartmentsAsync(DepartmentsViewModel departmentsVM, string userId)
        {
            _logger.LogInformation("AddDepartmentsAsync called.");
            var departments = new Departments()
            {
                Id = departmentsVM.Id,
                Name = departmentsVM.Name,
                LocatonId = departmentsVM.LocatonId,
                ManagerId = departmentsVM.ManagerId,
                Image = departmentsVM.Image,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _asyncRepository.AddAsync(departments);
        }

        public async Task DeleteDepartmentsAsync(int id)
        {
            _logger.LogInformation("DeleteDepartmentsAsync called.");
            var department = await _asyncRepository.GetByIdAsync(id);
            await _asyncRepository.DeleteAsync(department);
        }

        public async Task<IEnumerable<Departments>> GetAllDepartmentsAsync()
        {
            _logger.LogInformation("GetAllDepartmentsAsync called.");

            return await _asyncRepository.ListAllAsync();
        }

        public async Task<DepartmentsViewModel> GetDepartmentsAsync(int id)
        {
            _logger.LogInformation("GetDepartmentsAsync called.");
            var departmentget = await _asyncRepository.GetByIdAsync(id);
            var department = new DepartmentsViewModel()
            {
                Id = departmentget.Id,
                Name = departmentget.Name,
                LocatonId = departmentget.LocatonId,
                ManagerId = departmentget.ManagerId,
                Image = departmentget.Image,
            };

            return department;
        }

        public async Task UpdateDepartmentsAsync(DepartmentsViewModel departmentsVM, string userId)
        {
            _logger.LogInformation("UpdateDepartmentsAsync called.");
            var department = new Departments()
            {
                Id = departmentsVM.Id,
                Name = departmentsVM.Name,
                LocatonId = departmentsVM.LocatonId,
                ManagerId = departmentsVM.ManagerId,
                Image = departmentsVM.Image,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _asyncRepository.UpdateAsync(department);
        }

        /// <summary>
        /// SelectListItem for dropdownlist
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SelectListItem>> GetDepartment()
        {
            _logger.LogInformation("GetLocations called.");
            var departments = await _asyncRepository.ListAllAsync();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (Departments department in departments)
            {
                items.Add(new SelectListItem() { Value = department.Id.ToString(), Text = department.Name });
            }

            return items;
        }
    }
}
