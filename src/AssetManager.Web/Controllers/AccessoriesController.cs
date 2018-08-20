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
    public class AccessoriesController : Controller
    {
        private readonly IAsyncRepository<Accessory> _accessoriesRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;
        private readonly IAsyncRepository<Supplier> _supplierasyncRepository;
        private readonly IAsyncRepository<Location> _locRepository;
        public AccessoriesController(
            IAsyncRepository<Accessory> repository,
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<Manufacturer> manufacturer,
            IAsyncRepository<Supplier> supplierRepository,
            IAsyncRepository<Location> locRepository
            )
        {
            this._accessoriesRepository = repository;
            this._categoryRepository = categoryRepository;
            this._manufacturerRepository = manufacturer;
            this._supplierasyncRepository = supplierRepository;
            this._locRepository = locRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allaccessories = await _accessoriesRepository.ListAllAsync();
            return View(allaccessories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Categorylist = await _categoryRepository.ListAllAsync();
            ViewBag.Manufacturers = await _manufacturerRepository.ListAllAsync();
            ViewBag.Suppliers = await _supplierasyncRepository.ListAllAsync();
            ViewBag.Locations = await _locRepository.ListAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Accessory accessory)
        {
            if (ModelState.IsValid)
            {
                await _accessoriesRepository.AddAsync(accessory);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
