using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Web
{
    public class SupplierViewModelService : ISupplierViewModelService
    {
        private readonly IAsyncRepository<Supplier> _supplierRepository;
        private readonly IRepository<Supplier> _repository;
        public SupplierViewModelService(IAsyncRepository<Supplier> supplierRepository, IRepository<Supplier> repository)
        {
            _supplierRepository = supplierRepository;
            _repository = repository;
        }
        public async Task AddSupplier(SupplierViewModel supplier, string userId)
        {
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
            var supplier = await _supplierRepository.GetByIdAsync(id);
           await _supplierRepository.DeleteAsync(supplier);
        }

        public IEnumerable<Supplier> GetAllSupplier()
        {
            return _repository.ListAll();
        }

        public async Task<IEnumerable<Supplier>> GetAllSupplierAsync()
        {
            return await _supplierRepository.ListAllAsync();
        }

        public async Task<SupplierViewModel> GetSupplier(int id)
        {
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
                Image = supplier.Image,
            };
          return supplierViewModel;
        }

        public async Task UpdateSupplier(SupplierViewModel supplier, string userId)
        {
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
