using AssetManager.Core.Entities;
using AssetManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
   public interface ILocationViewModelService
    {
        Task AddLocationAsync(LocationViewModel depreciationVM, string userId);
        Task DeleteLocationAsync(int id);
        Task<LocationViewModel> GetLocationAsync(int id);
        Task UpdateLocationAsync(LocationViewModel locationVM, string userId);
        IEnumerable<Location> GetAllLocation();
        Task<IEnumerable<Location>> GetAllLocationAsync();
    }
}
