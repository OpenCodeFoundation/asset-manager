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
            this._asyncRepository = asyncRepository;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var locations = await _asyncRepository.GetByIdAsync(id);
            if(locations == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CountryList = AllCountry.getCountry();
            ViewBag.ParentList = await _asyncRepository.ListAllAsync();

            return View(locations);
        }

        // POST: Locations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Location location)
        {
            if(ModelState.IsValid)
            {
                await _asyncRepository.UpdateAsync(location);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CountryList = AllCountry.getCountry();
            ViewBag.ParentList = await _asyncRepository.ListAllAsync();
            return View(location);
            
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var dellocation = await _asyncRepository.GetByIdAsync(id);
            if (dellocation == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(dellocation);
        }

        // POST: Locations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Location dellocation)
        {
            if(ModelState.IsValid)
            {
                await _asyncRepository.DeleteAsync(dellocation);

                return RedirectToAction(nameof(Index));
            }
            
                return RedirectToAction(nameof(Index));

        }
    }
}