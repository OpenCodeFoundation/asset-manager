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
    public class LocationsController : Controller
    {
        private readonly IAsyncRepository<Location> _asyncRepository;

        public LocationsController(IAsyncRepository<Location> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allLocations = await _asyncRepository.ListAllAsync();
            return View(allLocations);
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var location = await _asyncRepository.GetByIdAsync(id);
            if(location == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.CountryList =  AllCountry.getCountry();
            ViewBag.ParentList = await _asyncRepository.ListAllAsync();
            return View();
        }

        // POST: Locations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location collection)
        {
            if(ModelState.IsValid)
            {
                await _asyncRepository.AddAsync(collection);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountryList = AllCountry.getCountry();
            ViewBag.ParentList = await _asyncRepository.ListAllAsync();
            return View(collection);
            
        }

        // GET: Locations/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Locations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Locations/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Locations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}