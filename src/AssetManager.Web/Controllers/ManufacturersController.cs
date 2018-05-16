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
            if(!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Create));
            }
            try
            {
                
                await _manufacturerRepository.AddAsync(manufacturer);
                
                return RedirectToAction(nameof(Index));
                

            }
            catch
            {
                return View();
            }
        }

        // GET: Manufacturers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manufacturers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Manufacturers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manufacturers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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