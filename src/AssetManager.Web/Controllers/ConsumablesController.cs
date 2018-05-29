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
        private readonly IAsyncRepository<Consumable> _consumableyRepository;
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Location> _locationRepository;
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;

        public ConsumablesController(
            IAsyncRepository<Consumable> repository, 
            IAsyncRepository<Company> companyRepository,
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<Location> locationRepository,
            IAsyncRepository<Manufacturer> manufacturerRepository
            )
        {
            this._consumableyRepository = repository;
            this._companyRepository = companyRepository;
            this._categoryRepository = categoryRepository;
            this._locationRepository = locationRepository;
            this._manufacturerRepository = manufacturerRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allconsuable = await _consumableyRepository.ListAllAsync();

            return View(allconsuable);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyRepository.ListAllAsync();
            ViewBag.Categorylist = await _categoryRepository.ListAllAsync();
            ViewBag.locations = await _locationRepository.ListAllAsync();
            ViewBag.manufacturer = await _manufacturerRepository.ListAllAsync();
            return View();
        }

       

    }
}
