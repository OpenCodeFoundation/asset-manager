using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Service
{
    public class CategoryViewModelService : ICategoryViewModelService
    {
        private readonly ILogger<CategoryViewModelService> _logger;
        private readonly IAsyncRepository<Category> _asyncRepository;
        private readonly IRepository<Category> _repository;
        public CategoryViewModelService(
            ILoggerFactory loggerFactory,
            IAsyncRepository<Category> asyncRepository,
            IRepository<Category> repository
            )
        {
            this._asyncRepository = asyncRepository;
            this._repository = repository;
            this._logger = loggerFactory.CreateLogger<CategoryViewModelService>();
        }
        public async Task AddCategoryAsync(CategoryViewModel categoryVM, string userId)
        {
            _logger.LogInformation("AddCategoryAsync called.");
            var category = new Category()
            {
                Id = categoryVM.Id,
                Name = categoryVM.Name,
                EulaText = categoryVM.EulaText,
                DefaultEula = categoryVM.DefaultEula,
                Type = TypeChange(categoryVM.Type),
                Image = categoryVM.Image,
                CheckInEmail = categoryVM.CheckInEmail,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
             };
            await _asyncRepository.AddAsync(category);
        }

        /// <summary>
        /// this is for only enum type parse. CategoryType to CategoryTypeVM
        /// </summary>
        /// <param name="TypeChange"></param>
        /// <returns></returns>
        private CatagoryType TypeChange(CatagoryTypeVM catagoryTypeVm)
        {
            _logger.LogInformation("TypeChange called.");
            CatagoryType catagoryTypes = CatagoryType.Asset;
            Enum.TryParse<CatagoryType>(catagoryTypeVm.ToString(), out catagoryTypes);
            return catagoryTypes;
        }

        public async Task DeleteCategoryAsync(int id)
        {
            _logger.LogInformation("DeleteCategoryAsync called.");
            var category = await _asyncRepository.GetByIdAsync(id);
            await _asyncRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoryAsync()
        {
            _logger.LogInformation("GetAllCategoryAsync called.");
            var allcategory = await _asyncRepository.ListAllAsync();
            var categoryViewList = new List<CategoryViewModel>();
            
            foreach(var category in allcategory)
            {
                var categoryView = new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    EulaText = category.EulaText,
                    DefaultEula = category.DefaultEula,
                    Type = TypeChanger(category.Type),
                    Image = category.Image,
                    CheckInEmail = category.CheckInEmail,
                    CreatedAt = category.CreatedAt,
                    UpdatedAt = category.UpdatedAt,
                    UpdatedBy = category.UpdatedBy
                };
                categoryViewList.Add(categoryView);
            }

            return categoryViewList;
        }

        /// <summary>
        /// this is for only enum type parse. CategoryTypeVM to CategoryType
        /// </summary>
        /// <param name="TypeChanger"></param>
        /// <returns></returns>
        private CatagoryTypeVM TypeChanger(CatagoryType catagoryType)
        {
            _logger.LogInformation("TypeChanger called.");
            CatagoryTypeVM catagoryTypeVm = CatagoryTypeVM.Asset;
            Enum.TryParse<CatagoryTypeVM>(catagoryType.ToString(), out catagoryTypeVm);
            return catagoryTypeVm;
        }

        /// <summary>
        /// GetCategories responsible for dropdownlist
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SelectListItem>> GetCategories()
        {
            _logger.LogInformation("GetCategories called.");
            var allCategory = await _asyncRepository.ListAllAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (Category category in allCategory)
            {
                items.Add(new SelectListItem() { Value = category.Id.ToString(), Text = category.Name });
            }

            return items;
        }

        public async Task<CategoryViewModel> GetCategoryAsync(int id)
        {
            _logger.LogInformation("GetCategoryAsync called.");
            var category = await _asyncRepository.GetByIdAsync(id);
            var categoryVm = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name,
                EulaText = category.EulaText,
                DefaultEula = category.DefaultEula,
                Type = TypeChanger(category.Type),
                Image = category.Image,
                CheckInEmail = category.CheckInEmail,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                UpdatedBy = category.UpdatedBy
            };

            return categoryVm;
        }

        public async Task UpdateCategoryAsync(CategoryViewModel categoryVM, string userId)
        {
            _logger.LogInformation("UpdateCategoryAsync called.");
            var category = new Category()
            {
                Id = categoryVM.Id,
                Name = categoryVM.Name,
                EulaText = categoryVM.EulaText,
                DefaultEula = categoryVM.DefaultEula,
                Type = TypeChange(categoryVM.Type),
                Image = categoryVM.Image,
                CheckInEmail = categoryVM.CheckInEmail,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _asyncRepository.UpdateAsync(category);
        }
    }
}
