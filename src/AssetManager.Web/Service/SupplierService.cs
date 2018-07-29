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
        public SupplierViewModelService(IAsyncRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public bool AddSupplier(SupplierViewModel supplier, string userId)
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

            _supplierRepository.AddAsync(_supplier);

            return true;
        }

        public async Task DeleteSupplier(int id)
        {
            var supplier = await _supplierRepository.GetByIdAsync(id);
           await _supplierRepository.DeleteAsync(supplier);
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

        public void UpdateSupplier(SupplierViewModel supplier, string userId)
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
            _supplierRepository.UpdateAsync(_supplier);

        }
    }
}
