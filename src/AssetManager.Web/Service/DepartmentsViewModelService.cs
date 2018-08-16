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

        public Task AddDepartmentsAsync(DepartmentsViewModel departmentsVM, string userId)
        {
            _logger.LogInformation("AddDepartmentsAsync called.");
            throw new NotImplementedException();
        }

        public Task DeleteDepartmentsAsync(int id)
        {
            _logger.LogInformation("DeleteDepartmentsAsync called.");
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentsViewModel> GetAllDepartments()
        {
            _logger.LogInformation("GetAllDepartments called.");
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentsViewModel>> GetAllDepartmentsAsync()
        {
            _logger.LogInformation("GetAllDepartmentsAsync called.");
            throw new NotImplementedException();
        }

        public Task<DepartmentsViewModel> GetDepartmentsAsync(int id)
        {
            _logger.LogInformation("GetDepartmentsAsync called.");
            throw new NotImplementedException();
        }

        public Task UpdateDepartmentsAsync(DepartmentsViewModel departmentsVM, string userId)
        {
            _logger.LogInformation("UpdateDepartmentsAsync called.");
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<SelectListItem>> GetDepartments()
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
