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



        // GET: Supplier/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
            
        }

    
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Supplier Supplier)
        {
            if(Supplier == null)
            {
                return RedirectToAction(nameof(Create));
            }
            try
            {

                await _supplierRepository.AddAsync(Supplier);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Supplier/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var supplier = await _supplierRepository.GetByIdAsync(id);
            if(supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Supplier supplier)
        {
            try
            {
                if (id == supplier.Id)
                {
                    supplier.UpdatedAt = DateTime.Now;
                    await _supplierRepository.UpdateAsync(supplier);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var data = await _supplierRepository.GetByIdAsync(id);
            if (data == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(data);
        }

     
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var supplier = await _supplierRepository.GetByIdAsync(id);
            if (supplier == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Supplier supplier)
        {
            try
            {
                if (id == supplier.Id)
                {
                    await _supplierRepository.DeleteAsync(supplier);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}