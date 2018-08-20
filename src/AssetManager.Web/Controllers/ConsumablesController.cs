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
    public class ConsumablesController : Controller
    {
        private readonly IAsyncRepository<Consumable> _consumableRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Location> _locationRepository;
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;

        public ConsumablesController(
            IAsyncRepository<Consumable> repository,
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<Location> locationRepository,
            IAsyncRepository<Manufacturer> manufacturerRepository
            )
        {
            this._consumableRepository = repository;
            this._categoryRepository = categoryRepository;
            this._locationRepository = locationRepository;
            this._manufacturerRepository = manufacturerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allconsuable = await _consumableRepository.ListAllAsync();
            return View(allconsuable);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorylist = await _categoryRepository.ListAllAsync();
            ViewBag.locations = await _locationRepository.ListAllAsync();
            ViewBag.manufacturer = await _manufacturerRepository.ListAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Consumable consumable)
        {
            if (ModelState.IsValid)
            {
                await _consumableRepository.AddAsync(consumable);
                return RedirectToAction(nameof(Index));
            }
            return View(consumable);
        }
    }
}
