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
    public class DepreciationViewModelService : IDepreciationViewModelService
    {
        private readonly ILogger<DepreciationViewModelService> _logger;
        private readonly IAsyncRepository<Depreciation> _depreciationRepository;
        private readonly IRepository<Depreciation> _repository;
        public DepreciationViewModelService(
            ILogger<DepreciationViewModelService> logger, 
            IAsyncRepository<Depreciation> depreciationRepository, 
            IRepository<Depreciation> repository)
        {
            this._depreciationRepository = depreciationRepository;
            this._repository = repository;
            this._logger = logger;
        }
        public async Task AddDepreciationAsync(DepreciationViewModel depreciationVM, string userId)
        {
            _logger.LogInformation("AddDepreciationAsync called.");
            var depreciation = new Depreciation()
            {
                Name = depreciationVM.Name,
                Months = depreciationVM.Months,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _depreciationRepository.AddAsync(depreciation);
        }

        public async Task DeleteDepreciationAsync(int id)
        {
            _logger.LogInformation("DeleteDepreciationAsync called.");
            var depreciation = await _depreciationRepository.GetByIdAsync(id);
            await _depreciationRepository.DeleteAsync(depreciation);
        }

        public IEnumerable<DepreciationViewModel> GetAllDepreciation()
        {
            _logger.LogInformation("GetAllDepreciation called.");
            var depreciations =  _repository.ListAll();
            var depreciationList = new List<DepreciationViewModel>();
            foreach(var depreciation in depreciations)
            {
                var depView = new DepreciationViewModel()
                {
                    Id = depreciation.Id,
                    Name = depreciation.Name,
                    Months = depreciation.Months
                };
                depreciationList.Add(depView);                
            }
            return depreciationList;
        }

        public async Task<IEnumerable<DepreciationViewModel>> GetAllDepreciationAsync()
        {
            _logger.LogInformation("GetAllDepreciationAsync called.");
            var depreciations = await _depreciationRepository.ListAllAsync();
            var depreciationList = new List<DepreciationViewModel>();
            foreach (var depreciation in depreciations)
            {
                var depView = new DepreciationViewModel()
                {
                    Id = depreciation.Id,
                    Name = depreciation.Name,
                    Months = depreciation.Months
                };
                depreciationList.Add(depView);
            }
            return depreciationList;
        }

        public async Task<DepreciationViewModel> GetDepreciationAsync(int id)
        {
            _logger.LogInformation("GetDepreciationAsync called.");
            var depreciation = await _depreciationRepository.GetByIdAsync(id);
            DepreciationViewModel depreciationViewModel = new DepreciationViewModel()
            {
               Id = depreciation.Id,
               Name = depreciation.Name,
               Months = depreciation.Months
            };
            return depreciationViewModel;
        }

        public async Task UpdateDepreciationAsync(DepreciationViewModel depreciationVM, string userId)
        {
            _logger.LogInformation("UpdateDepreciationAsync called.");
            var depreciation = new Depreciation()
            {
                Id = depreciationVM.Id,
                Name = depreciationVM.Name,
                Months = depreciationVM.Months,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _depreciationRepository.UpdateAsync(depreciation);
        }

        public async Task<IEnumerable<SelectListItem>> GetDepreciations()
        {
            _logger.LogInformation("GetDepreciations called.");
            var allDepreciation = await _depreciationRepository.ListAllAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (Depreciation depreciation in allDepreciation)
            {
                items.Add(new SelectListItem() { Value = depreciation.Id.ToString(), Text = depreciation.Name });
            }

            return items;
        }
    }
}
