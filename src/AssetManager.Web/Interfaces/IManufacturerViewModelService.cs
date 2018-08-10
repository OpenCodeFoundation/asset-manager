using AssetManager.Core.Entities;
using AssetManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
   public interface IManufacturerViewModelService
    {
        Task AddManufacturerAsync(ManufacturerViewModel manufacturerVM, string userId);
        Task DeleteManufacturerAsync(int id);
        Task<ManufacturerViewModel> GetManufacturerAsync(int id);
        Task UpdateManufacturerAsync(ManufacturerViewModel manufacturerVM, string userId);
        IEnumerable<Manufacturer> GetAllManufacturer();
        Task<IEnumerable<Manufacturer>> GetAllManufacturerAsync();
    }
}
