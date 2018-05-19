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
    public class ManufacturersController : Controller
    {
        private readonly IAsyncRepository<Manufacturer> _manufacturerRepository;

        public ManufacturersController(IAsyncRepository<Manufacturer> repository)
        {
            _manufacturerRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allManufaturer = await _manufacturerRepository.ListAllAsync();
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

            var item = await _manufacturerRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {

            if(ModelState.IsValid)
            {
                manufacturer.CreatedAt = DateTime.Now;
                manufacturer.UpdatedAt = DateTime.Now;
                await _manufacturerRepository.AddAsync(manufacturer);
                
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

            var manufacturer = await _manufacturerRepository.GetByIdAsync(id);

            if(manufacturer == null)
            {
                return RedirectToAction(nameof(Index));
            
            }


            return View(manufacturer);
        }

        // POST: Manufacturers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Manufacturer data)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
               await _manufacturerRepository.UpdateAsync(data);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Manufacturers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deleteItem = await _manufacturerRepository.GetByIdAsync(id);
            if(deleteItem == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(deleteItem);
        }

        // POST: Manufacturers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Manufacturer dataCollection)
        {
            try
            {

                await _manufacturerRepository.DeleteAsync(dataCollection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}