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
    public class ManufacturerViewModelService : IManufacturerViewModelService
    {
        private readonly ILogger<ManufacturerViewModelService> _logger;
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;
        private readonly IRepository<Manufacturer> _repository;
        public ManufacturerViewModelService(
            IAsyncRepository<Manufacturer> manufacturerRepository, 
            IRepository<Manufacturer> repository,
            ILogger<ManufacturerViewModelService> logger
            )
        {
            this._manufacturerRepository = manufacturerRepository;
            this._repository = repository;
            this._logger = logger;
        }
        public async Task AddManufacturerAsync(ManufacturerViewModel manufacturerVM, string userId)
        {
            _logger.LogInformation("AddManufacturerAsync called.");
            var manufacturer = new Manufacturer()
            {
                Name = manufacturerVM.Name,
                Url = manufacturerVM.Url,
                SupportUrl = manufacturerVM.SupportUrl,
                SupportEmail = manufacturerVM.SupportEmail,
                SupportPhone = manufacturerVM.SupportPhone,
                Image = manufacturerVM.Image,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _manufacturerRepository.AddAsync(manufacturer);
        }

        public async Task DeleteManufacturerAsync(int id)
        {
            _logger.LogInformation("DeleteManufacturerAsync called.");
            var manufacturer = await _manufacturerRepository.GetByIdAsync(id);
            await _manufacturerRepository.DeleteAsync(manufacturer);
        }

        public IEnumerable<ManufacturerViewModel> GetAllManufacturer()
        {
            _logger.LogInformation("GetAllManufacturer called.");
            var manu = _repository.ListAll();
            var manViewList = new List<ManufacturerViewModel>();
            foreach(var manufacturer in manu)
            {
                var manView = new ManufacturerViewModel
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    Url = manufacturer.Url,
                    SupportUrl = manufacturer.SupportUrl,
                    SupportEmail = manufacturer.SupportEmail,
                    SupportPhone = manufacturer.SupportPhone,
                    Image = manufacturer.Image,
                    CreatedAt = manufacturer.CreatedAt,
                    UpdatedAt = manufacturer.UpdatedAt,
                    UpdatedBy = manufacturer.UpdatedBy,
                    DeletedAt = manufacturer.DeletedAt
                };

                manViewList.Add(manView);
            }

            return manViewList;
        }

        public async Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturerAsync()
        {
            _logger.LogInformation("GetAllManufacturerAsync called.");
            var manu = await _manufacturerRepository.ListAllAsync();
            var manViewList = new List<ManufacturerViewModel>();
            foreach (var manufacturer in manu)
            {
                var manView = new ManufacturerViewModel
                {
                    Id = manufacturer.Id,
                    Name = manufacturer.Name,
                    Url = manufacturer.Url,
                    SupportUrl = manufacturer.SupportUrl,
                    SupportEmail = manufacturer.SupportEmail,
                    SupportPhone = manufacturer.SupportPhone,
                    Image = manufacturer.Image,
                    CreatedAt = manufacturer.CreatedAt,
                    UpdatedAt = manufacturer.UpdatedAt,
                    UpdatedBy = manufacturer.UpdatedBy,
                    DeletedAt = manufacturer.DeletedAt
                };

                manViewList.Add(manView);
            }

            return manViewList;
        }

        public async Task<ManufacturerViewModel> GetManufacturerAsync(int id)
        {
            _logger.LogInformation("GetManufacturerAsync called.");
            var manufacturer = await _manufacturerRepository.GetByIdAsync(id);
            ManufacturerViewModel manufacturerViewModel = new ManufacturerViewModel()
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                Url = manufacturer.Url,
                SupportUrl = manufacturer.SupportUrl,
                SupportEmail = manufacturer.SupportEmail,
                SupportPhone = manufacturer.SupportPhone,
                Image = manufacturer.Image,
                CreatedAt = manufacturer.CreatedAt,
                UpdatedAt = manufacturer.UpdatedAt,
                UpdatedBy = manufacturer.UpdatedBy,
                DeletedAt = manufacturer.DeletedAt
            };

            return manufacturerViewModel;
        }

        public async Task UpdateManufacturerAsync(ManufacturerViewModel manufacturerVM, string userId)
        {
            _logger.LogInformation("UpdateManufacturerAsync called.");
            var manufacturer = new Manufacturer()
            {
                Id = manufacturerVM.Id,
                Name = manufacturerVM.Name,
                Url = manufacturerVM.Url,
                SupportEmail = manufacturerVM.SupportEmail,
                SupportPhone = manufacturerVM.SupportPhone,
                SupportUrl = manufacturerVM.SupportUrl,
                Image = manufacturerVM.Image,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _manufacturerRepository.UpdateAsync(manufacturer);
        }
        public async Task<IEnumerable<SelectListItem>> GetManufacturers()
        {
            _logger.LogInformation("GetManufacturers called.");
            var allManufacturer = await _manufacturerRepository.ListAllAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (Manufacturer manufacturer in allManufacturer)
            {
                items.Add(new SelectListItem() { Value = manufacturer.Id.ToString(), Text = manufacturer.Name });
            }

            return items;
        }
    }
}
