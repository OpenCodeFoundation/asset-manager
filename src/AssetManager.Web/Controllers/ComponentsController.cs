using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Web.Controllers
{
    public class ComponentsController : Controller
    {
        private readonly IAsyncRepository<Components> _componentRepository;
        private readonly ICategoryViewModelService _categoryViewModelService;
        private readonly ILocationViewModelService _locationViewModelService;
        public ComponentsController(
            IAsyncRepository<Components> componentRepository,
            ICategoryViewModelService categoryViewModelService,
            ILocationViewModelService locationViewModelService
            )
        {
            this._componentRepository = componentRepository;
            this._categoryViewModelService = categoryViewModelService;
            this._locationViewModelService = locationViewModelService;
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
            ViewBag.Categorylist = await _categoryViewModelService.GetCategories();
            ViewBag.locations = await _locationViewModelService.GetLocation();
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