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
    public class AssetModelViewModelService : IAssetModelViewModelService
    {
        private readonly IAsyncRepository<AssetModels>  _asyncRepository;
        private readonly IRepository<AssetModels>  _repository;
        private readonly ILogger<CategoryViewModelService> _logger;
        public AssetModelViewModelService(
            IAsyncRepository<AssetModels> asyncRepository,
            IRepository<AssetModels> repository,
            ILoggerFactory loggerFactory
            )
        {
            this._asyncRepository = asyncRepository;
            this._repository = repository;
            this._logger = loggerFactory.CreateLogger<CategoryViewModelService>();
        }

        public async Task AddAssetModelAsync(AssetModelViewModel assetModelViewModel, string userId)
        {
            _logger.LogInformation("AddAssetModelAsync called.");
            var assetModel = new AssetModels()
            {
                Id = assetModelViewModel.Id,
                Name = assetModelViewModel.Name,
                ManufacturerId = assetModelViewModel.ManufacturerId,
                CategoryId = assetModelViewModel.CategoryId,
                ModelNumber = assetModelViewModel.ModelNumber,
                DepreciationId = assetModelViewModel.DepreciationId,
                Eol = assetModelViewModel.Eol,
                Image = assetModelViewModel.Image,
                DeprecatedMacAdress = assetModelViewModel.DeprecatedMacAdress,
                Notes = assetModelViewModel.Notes,
                Requestable = assetModelViewModel.Requestable,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _asyncRepository.AddAsync(assetModel);
        }

        public async Task DeleteAssetModelAsync(int id)
        {
            _logger.LogInformation("DeleteAssetModelAsync called.");
            var assetModel = await _asyncRepository.GetByIdAsync(id);
            await _asyncRepository.DeleteAsync(assetModel);
        }

        public async Task<IEnumerable<AssetModelViewModel>> GetAllModelAsync()
        {
            _logger.LogInformation("GetAllModelAsync called.");
            var allAssetModel = await _asyncRepository.ListAllAsync();
            var modelViewList = new List<AssetModelViewModel>();
            
            foreach(var model in allAssetModel)
            {
                var modelView = new AssetModelViewModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    ManufacturerId = model.ManufacturerId,
                    CategoryId = model.CategoryId,
                    ModelNumber = model.ModelNumber,
                    DepreciationId = model.DepreciationId,
                    Eol = model.Eol,
                    Image = model.Image,
                    DeprecatedMacAdress = model.DeprecatedMacAdress,
                    Notes = model.Notes,
                    Requestable = model.Requestable
                };
                modelViewList.Add(modelView);
            }
            return modelViewList;
            
        }

        public async Task<AssetModelViewModel> GetAssetModelAsync(int id)
        {
            _logger.LogInformation("GetAssetModelAsync called.");
            var model = await _asyncRepository.GetByIdAsync(id);
            var modelVM = new AssetModelViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                ManufacturerId = model.ManufacturerId,
                CategoryId = model.CategoryId,
                ModelNumber = model.ModelNumber,
                DepreciationId = model.DepreciationId,
                Eol = model.Eol,
                Image = model.Image,
                DeprecatedMacAdress = model.DeprecatedMacAdress,
                Notes = model.Notes,
                Requestable = model.Requestable,
                CreatedAt = model.CreatedAt,
                UpdatedAt = model.UpdatedAt,
                UpdatedBy = model.UpdatedBy
            };
            return modelVM;
        }

        public async Task<IEnumerable<SelectListItem>> GetModels()
        {
            _logger.LogInformation("GetModels called.");
            var allModel = await _asyncRepository.ListAllAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (AssetModels model in allModel)
            {
                items.Add(new SelectListItem() { Value = model.Id.ToString(), Text = model.Name });
            }

            return items;
        }

        public async Task UpdateAssetModelAsync(AssetModelViewModel assetModelViewModel, string userId)
        {
            _logger.LogInformation("UpdateAssetModelAsync called.");
            var model = new AssetModels()
            {
                Id = assetModelViewModel.Id,
                Name = assetModelViewModel.Name,
                ManufacturerId = assetModelViewModel.ManufacturerId,
                CategoryId = assetModelViewModel.CategoryId,
                ModelNumber = assetModelViewModel.ModelNumber,
                DepreciationId = assetModelViewModel.DepreciationId,
                Eol = assetModelViewModel.Eol,
                Image = assetModelViewModel.Image,
                DeprecatedMacAdress = assetModelViewModel.DeprecatedMacAdress,
                Notes = assetModelViewModel.Notes,
                Requestable = assetModelViewModel.Requestable,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _asyncRepository.UpdateAsync(model);
        }
    }
}
