using AssetManager.Core.Entities;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
   public interface ILocationViewModelService
    {
        Task AddLocationAsync(LocationViewModel locationVM, string userId);
        Task DeleteLocationAsync(int id);
        Task<LocationViewModel> GetLocationAsync(int id);
        Task UpdateLocationAsync(LocationViewModel locationVM, string userId);
        IEnumerable<LocationViewModel> GetAllLocation();
        Task<IEnumerable<LocationViewModel>> GetAllLocationAsync();
        Task<IEnumerable<SelectListItem>> GetLocation();
    }
}
