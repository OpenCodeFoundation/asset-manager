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
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerViewModelService _manufacturerViewModelService;

        public ManufacturersController(IManufacturerViewModelService manufacturerViewModelService)
        {
            this._manufacturerViewModelService = manufacturerViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allManufaturer = await _manufacturerViewModelService.GetAllManufacturerAsync();
            return View(allManufaturer);
        }

        // GET: Manufacturers/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var item = await _manufacturerViewModelService.GetManufacturerAsync(id);
            return View(item);
        }

        // GET: Manufacturers/Create
        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ManufacturerViewModel manufacturer)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _manufacturerViewModelService.AddManufacturerAsync(manufacturer, userId);                
                return RedirectToAction(nameof(Index));
            }            
            return View();
            
        }

        // GET: Manufacturers/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var manufacturer = await _manufacturerViewModelService.GetManufacturerAsync(id);
            if(manufacturer == null)
            {
                return RedirectToAction(nameof(Index));            
            }
            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ManufacturerViewModel  manufacturerViewModel)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _manufacturerViewModelService.UpdateManufacturerAsync(manufacturerViewModel, userId);
                return RedirectToAction(nameof(Index));
            }
            return View();            
        }

        // GET: Manufacturers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deleteItem = await _manufacturerViewModelService.GetManufacturerAsync(id);
            if(deleteItem == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(deleteItem);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ManufacturerViewModel manufacturerViewModel)
        {
            if(manufacturerViewModel!=null)
            {
                await _manufacturerViewModelService.DeleteManufacturerAsync(id);
                return RedirectToAction(nameof(Index));
            }
            return View();            
        }
    }
}