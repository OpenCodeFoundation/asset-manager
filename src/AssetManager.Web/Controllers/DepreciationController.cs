using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Web.Controllers
{
    public class DepreciationController : Controller
    {
        private readonly IDepreciationViewModelService _depreciationViewModelService;
        public DepreciationController(IDepreciationViewModelService depreciationViewModelService)
        {
            this._depreciationViewModelService = depreciationViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var depreciation = await _depreciationViewModelService.GetAllDepreciationAsync();
            return View(depreciation);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(DepreciationViewModel item)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _depreciationViewModelService.AddDepreciationAsync(item, userId);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var dep = await _depreciationViewModelService.GetDepreciationAsync(id);
            if(dep == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(dep);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepreciationViewModel obj)
        {
            string userId = User.Identity.Name;
            if(ModelState.IsValid)
            {
                await _depreciationViewModelService.UpdateDepreciationAsync(obj, userId);
                return RedirectToAction(nameof(Index));
            }
            return View();            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deleteIteam = await _depreciationViewModelService.GetDepreciationAsync(id);
            return View(deleteIteam);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DepreciationViewModel item)
        {
            if(item == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await _depreciationViewModelService.DeleteDepreciationAsync(item.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}