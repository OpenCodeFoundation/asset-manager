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

        public async Task<IActionResult> Index()
        {
            var allManufaturer = await _manufacturerRepository.ListAllAsync();
            return View(allManufaturer);
        }

        // GET: Manufacturers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manufacturers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufacturers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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