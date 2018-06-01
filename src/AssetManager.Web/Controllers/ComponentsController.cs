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
    public class ComponentsController : Controller
    {
        private readonly IAsyncRepository<Components> _componentRepository;
        private readonly IAsyncRepository<Company> _companyRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IAsyncRepository<Location> _locationRepository;
        public ComponentsController(
            IAsyncRepository<Components> componentRepository,
            IAsyncRepository<Company> companyRepository,
            IAsyncRepository<Category> categoryRepository,
            IAsyncRepository<Location> locationRepository
            )
        {
            this._componentRepository = componentRepository;
            this._companyRepository = companyRepository;
            this._categoryRepository = categoryRepository;
            this._locationRepository = locationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var componentslist = await _componentRepository.ListAllAsync();
            return View(componentslist);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.CompanyList = await _companyRepository.ListAllAsync();
            ViewBag.Categorylist = await _categoryRepository.ListAllAsync();
            ViewBag.locations = await _locationRepository.ListAllAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Components components)
        {
            if (ModelState.IsValid)
            {
                await _componentRepository.AddAsync(components);
                return RedirectToAction(nameof(Index));
            }

            return View(components);
        }
    }



}