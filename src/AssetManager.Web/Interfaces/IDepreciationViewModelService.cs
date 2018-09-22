using AssetManager.Core.Entities;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
   public interface IDepreciationViewModelService
    {
        Task AddDepreciationAsync(DepreciationViewModel depreciationVM, string userId);
        Task DeleteDepreciationAsync(int id);
        Task<DepreciationViewModel> GetDepreciationAsync(int id);
        Task UpdateDepreciationAsync(DepreciationViewModel depreciationVM, string userId);
        IEnumerable<DepreciationViewModel> GetAllDepreciation();
        Task<IEnumerable<DepreciationViewModel>> GetAllDepreciationAsync();
        Task<IEnumerable<SelectListItem>> GetDepreciations();
    }
}
