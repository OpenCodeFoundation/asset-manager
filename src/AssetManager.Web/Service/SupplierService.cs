using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Web
{
    public class SupplierService : ISupplierService
    {
        private readonly IAsyncRepository<Supplier> _supplierRepository;
        public SupplierService(IAsyncRepository<Supplier> supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public Supplier AddSupplier(Supplier supplier, string userId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSupplier(int id, string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetAllSupplier()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Supplier> GetAllSupplierAsync()
        {
            throw new NotImplementedException();
        }

        public Supplier GetSupplier(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateSupplier(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
