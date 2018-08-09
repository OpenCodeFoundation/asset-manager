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
    public class LocationsController : Controller
    {
        private readonly ILocationViewModelService _locationViewModelService;

        public LocationsController(ILocationViewModelService locationViewModelService)
        {
            this._locationViewModelService = locationViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allLocations = await _locationViewModelService.GetAllLocationAsync();
            return View(allLocations);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var location = await _locationViewModelService.GetLocationAsync(id);
            if(location == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Create
        public IActionResult Create()
        {
            ViewBag.CountryList =  AllCountry.getCountry();
            return View();
        }

        // POST: Locations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LocationViewModel locationViewModel)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _locationViewModelService.AddLocationAsync(locationViewModel, userId);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CountryList = AllCountry.getCountry();
            return View(locationViewModel);
            
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var locations = await _locationViewModelService.GetLocationAsync(id);
            if(locations == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CountryList = AllCountry.getCountry();
            return View(locations);
        }

        // POST: Locations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LocationViewModel locationViewModel)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _locationViewModelService.UpdateLocationAsync(locationViewModel, userId);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CountryList = AllCountry.getCountry();
            return View(locationViewModel);
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var getLocation = await _locationViewModelService.GetLocationAsync(id);
            if (getLocation == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(getLocation);
        }

        // POST: Locations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, LocationViewModel locationViewModel)
        {
            if(ModelState.IsValid)
            {
                await _locationViewModelService.DeleteLocationAsync(id);
                return RedirectToAction(nameof(Index));
            }
                return RedirectToAction(nameof(Index));
        }
    }
}