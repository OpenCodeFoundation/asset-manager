using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CategoriesController(IAsyncRepository<Category> repository)
        {
            this._categoryRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var CategoryList = await _categoryRepository.ListAllAsync();

            return View(CategoryList);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var catdetail = await _categoryRepository.GetByIdAsync(id);
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
        public async Task<IActionResult> Create(Category category)
        {
            if(ModelState.IsValid)
            {
                category.CreatedAt = DateTime.Now;
                
                await _categoryRepository.AddAsync(category);
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

            var obj = await _categoryRepository.GetByIdAsync(id);

            if(obj == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category collection)
        {
            if(id != collection.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
               await _categoryRepository.UpdateAsync(collection); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id <=0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deleteItem = await _categoryRepository.GetByIdAsync(id);
            if(deleteItem == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(deleteItem);
        }

        // POST: Categories/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Category cateItem)
        {
            if(cateItem == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                
               await _categoryRepository.DeleteAsync(cateItem);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}