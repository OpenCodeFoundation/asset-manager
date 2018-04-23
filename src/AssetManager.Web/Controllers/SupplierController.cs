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
    public class SupplierController : Controller
    {
        private readonly IAsyncRepository<Supplier> _supplierRepository;
        public SupplierController(IAsyncRepository<Supplier> repository)
        {
            _supplierRepository = repository;
        }

        // GET: Supplier
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companies = await _supplierRepository.ListAllAsync();
            return View(companies);
        }

        // GET: Supplier/Details/5
        public IActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }


            return View();
        }

        // GET: Supplier/Create
        public async Task<IActionResult> Create(Supplier supplier)
        {
            try
            {
               await _supplierRepository.AddAsync(supplier);
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
            
        }

        // POST: Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            return View();
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Supplier/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}