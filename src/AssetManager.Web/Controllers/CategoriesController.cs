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
    public class CategoriesController : Controller
    {
        private readonly ICategoryViewModelService _categoryViewModelService;
        public CategoriesController(ICategoryViewModelService categoryViewModelService)
        {
            this._categoryViewModelService = categoryViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CategoryList = await _categoryViewModelService.GetAllCategoryAsync();
            return View(CategoryList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var catdetail = await _categoryViewModelService.GetCategoryAsync(id);
            if(catdetail == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(catdetail);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel category)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _categoryViewModelService.AddCategoryAsync(category, userId);
                return RedirectToAction(nameof(Index));
            }
            return View(); 
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var obj = await _categoryViewModelService.GetCategoryAsync(id);
            if(obj == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryViewModel category)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _categoryViewModelService.UpdateCategoryAsync(category, userId); 
                return RedirectToAction(nameof(Index));
            }
            return View();

        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <=0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deleteItem = await _categoryViewModelService.GetCategoryAsync(id);
            if (deleteItem == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(deleteItem);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CategoryViewModel cateItem)
        {
            if(cateItem!=null)
            {
                await _categoryViewModelService.DeleteCategoryAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}