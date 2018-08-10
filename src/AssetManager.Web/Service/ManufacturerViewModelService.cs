using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Service
{
    public class ManufacturerViewModelService : IManufacturerViewModelService
    {
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;
        private readonly IRepository<Manufacturer> _repository;
        public ManufacturerViewModelService(
            IAsyncRepository<Manufacturer> manufacturerRepository, 
            IRepository<Manufacturer> repository
            )
        {
            this._manufacturerRepository = manufacturerRepository;
            this._repository = repository;
        }
        public async Task AddManufacturerAsync(ManufacturerViewModel manufacturerVM, string userId)
        {
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
            var manufacturer = await _manufacturerRepository.GetByIdAsync(id);
            await _manufacturerRepository.DeleteAsync(manufacturer);
        }

        public IEnumerable<Manufacturer> GetAllManufacturer()
        {
            return _repository.ListAll();
        }

        public async Task<IEnumerable<Manufacturer>> GetAllManufacturerAsync()
        {
            return await _manufacturerRepository.ListAllAsync();
        }

        public async Task<ManufacturerViewModel> GetManufacturerAsync(int id)
        {
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
    }
}
