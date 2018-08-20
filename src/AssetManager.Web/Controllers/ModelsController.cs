using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManager.Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IAssetModelViewModelService _assetModelViewModelService;
        private readonly IManufacturerViewModelService  _manufacturerViewModelService;
        private readonly ICategoryViewModelService  _categoryViewModelService;
        private readonly IDepreciationViewModelService _depreciationViewModelService;

        public ModelsController(
            IAssetModelViewModelService assetModelViewModelService,
            IManufacturerViewModelService manufacturerViewModelService,
            ICategoryViewModelService categoryViewModelService,
            IDepreciationViewModelService depreciationViewModelService
            )
        {
            this._assetModelViewModelService = assetModelViewModelService;
            this._manufacturerViewModelService = manufacturerViewModelService;
            this._categoryViewModelService = categoryViewModelService;
            this._depreciationViewModelService = depreciationViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allModels = await _assetModelViewModelService.GetAllModelAsync();
            return View(allModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var assetModel = await _assetModelViewModelService.GetAssetModelAsync(id);
            return View(assetModel);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.manufacturer = await _manufacturerViewModelService.GetManufacturers();
            ViewBag.category = await _categoryViewModelService.GetCategories();
            ViewBag.depreciation = await _depreciationViewModelService.GetDepreciations();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetModelViewModel model)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _assetModelViewModelService.AddAssetModelAsync(model, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var model = await _assetModelViewModelService.GetAssetModelAsync(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.manufacturer = await _manufacturerViewModelService.GetManufacturers();
            ViewBag.category = await _categoryViewModelService.GetCategories();
            ViewBag.depreciation = await _depreciationViewModelService.GetDepreciations();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AssetModelViewModel model)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _assetModelViewModelService.UpdateAssetModelAsync(model, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deletemodel = await _assetModelViewModelService.GetAssetModelAsync(id);
            if(deletemodel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(deletemodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, AssetModelViewModel model)
        {
            if (id == model.Id && model != null)
            {
                await _assetModelViewModelService.DeleteAssetModelAsync(model.Id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}