using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
    public interface IAssetModelViewModelService
    {
        Task AddAssetModelAsync(AssetModelViewModel assetModelViewModel, string userId);
        Task DeleteAssetModelAsync(int id);
        Task<AssetModelViewModel> GetAssetModelAsync(int id);
        Task UpdateAssetModelAsync(AssetModelViewModel assetModelViewModel, string userId);
        Task<IEnumerable<AssetModelViewModel>> GetAllModelAsync();
        Task<IEnumerable<SelectListItem>> GetModels();
    }
}
