using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Web
{
    /// <summary>
    /// This is a UI-specific service so belongs in UI project. It does not contain any business logic and works
    /// with UI-specific types (view models and SelectListItem types).
    /// </summary>
    public class SupplierViewModelService : ISupplierViewModelService
    {
        private readonly ILogger<SupplierViewModelService> _logger;
        private readonly IAsyncRepository<Supplier> _supplierRepository;
        private readonly IRepository<Supplier> _repository;
        public SupplierViewModelService(
            IAsyncRepository<Supplier> supplierRepository, 
            IRepository<Supplier> repository,
            ILogger<SupplierViewModelService> logger
            )
        {
            this._supplierRepository = supplierRepository;
            this._repository = repository;
            this._logger = logger;

        }
        public async Task AddSupplier(SupplierViewModel supplier, string userId)
        {
            _logger.LogInformation("AddSupplier called.");
            var _supplier = new Supplier()
            {
                Name = supplier.Name,
                Address = supplier.Address,
                AddressTwo = supplier.AddressTwo,
                City = supplier.City,
                State = supplier.State,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                Country = supplier.Country,
                Contact = supplier.Contact,
                Email = supplier.Email,
                Notes = supplier.Notes,
                Zip = supplier.Zip,
                Url = supplier.Url,
                Image = supplier.Image,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

           await _supplierRepository.AddAsync(_supplier);
            
        }

        public async Task DeleteSupplier(int id)
        {
            _logger.LogInformation("DeleteSupplier called.");
            var supplier = await _supplierRepository.GetByIdAsync(id);
           await _supplierRepository.DeleteAsync(supplier);
        }

        public IEnumerable<SupplierViewModel> GetAllSupplier()
        {
            _logger.LogInformation("GetAllSupplier called.");
            var suppliers =  _repository.ListAll();
            var supplierViewList = new List<SupplierViewModel>();
            foreach(var supplier in suppliers)
            {
                var supplierView = new SupplierViewModel()
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    Address = supplier.Address,
                    AddressTwo = supplier.AddressTwo,
                    City = supplier.City,
                    State = supplier.State,
                    Phone = supplier.Phone,
                    Fax = supplier.Fax,
                    Country = supplier.Country,
                    Contact = supplier.Contact,
                    Email = supplier.Email,
                    Notes = supplier.Notes,
                    Zip = supplier.Zip,
                    Url = supplier.Url,
                    Image = supplier.Image
                };

                supplierViewList.Add(supplierView);
            }
            return supplierViewList;
        }

        public async Task<IEnumerable<SupplierViewModel>> GetAllSupplierAsync()
        {
            _logger.LogInformation("GetAllSupplierAsync called.");
            var suppliers = await _supplierRepository.ListAllAsync();
            var supplierViewList = new List<SupplierViewModel>();
            foreach (var supplier in suppliers)
            {
                var supplierView = new SupplierViewModel()
                {
                    Id = supplier.Id,
                    Name = supplier.Name,
                    Address = supplier.Address,
                    AddressTwo = supplier.AddressTwo,
                    City = supplier.City,
                    State = supplier.State,
                    Phone = supplier.Phone,
                    Fax = supplier.Fax,
                    Country = supplier.Country,
                    Contact = supplier.Contact,
                    Email = supplier.Email,
                    Notes = supplier.Notes,
                    Zip = supplier.Zip,
                    Url = supplier.Url,
                    Image = supplier.Image
                };

                supplierViewList.Add(supplierView);
            }
            return supplierViewList;
        }

        public async Task<SupplierViewModel> GetSupplier(int id)
        {
            _logger.LogInformation("GetSupplier called.");
            var supplier =   await _supplierRepository.GetByIdAsync(id);
            SupplierViewModel supplierViewModel = new SupplierViewModel()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                AddressTwo = supplier.AddressTwo,
                City = supplier.City,
                State = supplier.State,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                Country = supplier.Country,
                Contact = supplier.Contact,
                Email = supplier.Email,
                Notes = supplier.Notes,
                Zip = supplier.Zip,
                Url = supplier.Url,
                Image = supplier.Image
            };
          return supplierViewModel;
        }

        public async Task UpdateSupplier(SupplierViewModel supplier, string userId)
        {
            _logger.LogInformation("UpdateSupplier called.");
            var _supplier = new Supplier()
            {
                Id = supplier.Id,
                Name = supplier.Name,
                Address = supplier.Address,
                AddressTwo = supplier.AddressTwo,
                City = supplier.City,
                State = supplier.State,
                Phone = supplier.Phone,
                Fax = supplier.Fax,
                Country = supplier.Country,
                Contact = supplier.Contact,
                Email = supplier.Email,
                Notes = supplier.Notes,
                Zip = supplier.Zip,
                Url = supplier.Url,
                Image = supplier.Image,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
           await _supplierRepository.UpdateAsync(_supplier);

        }
    }
}
