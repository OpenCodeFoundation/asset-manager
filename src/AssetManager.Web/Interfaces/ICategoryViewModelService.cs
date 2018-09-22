using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
   public interface ICategoryViewModelService
    {
        Task AddCategoryAsync(CategoryViewModel categoryVM, string userId);
        Task DeleteCategoryAsync(int id);
        Task<CategoryViewModel> GetCategoryAsync(int id);
        Task UpdateCategoryAsync(CategoryViewModel categoryVM, string userId);
        Task<IEnumerable<CategoryViewModel>> GetAllCategoryAsync();
        Task<IEnumerable<SelectListItem>> GetCategories();
    }
}
