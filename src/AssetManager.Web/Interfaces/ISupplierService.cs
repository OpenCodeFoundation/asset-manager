using AssetManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Web
{
    public interface ISupplierService
    {
        Supplier AddSupplier(Supplier supplier, string userId);
        Supplier GetSupplier(int id);
        void DeleteSupplier(int id, string userId);
        void UpdateSupplier(int id, string userId);
        IEnumerable<Supplier> GetAllSupplierAsync();
        IEnumerable<Supplier> GetAllSupplier();
    }
}
