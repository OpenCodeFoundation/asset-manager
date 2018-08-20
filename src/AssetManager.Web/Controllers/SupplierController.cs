using System;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ISupplierViewModelService _supplierService;
        public SupplierController(ISupplierViewModelService supplierService)
        {
            this._supplierService = supplierService;
        }

        // GET: Supplier
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var suppliers = await _supplierService.GetAllSupplierAsync();
            return View(suppliers);
        }



        // GET: Supplier/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.CountryList = AllCountry.getCountry();
            return View();            
        }

    
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(SupplierViewModel supplier)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
              await _supplierService.AddSupplier(supplier, userId);
              return RedirectToAction(nameof(Index));
            }
            return View(supplier);            
        }

        // GET: Supplier/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var supplier = await _supplierService.GetSupplier(id);
            if(supplier == null)
            {
                return NotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SupplierViewModel supplier)
        {
            if(ModelState.IsValid)
            {
                string userId = User.Identity.Name;
                await _supplierService.UpdateSupplier(supplier, userId);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var supplierData = await _supplierService.GetSupplier(id);
            if (supplierData == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(supplierData);
        }

     
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var supplier = await _supplierService.GetSupplier(id);
            if (supplier == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, SupplierViewModel supplier)
        {
            try
            {
                if(supplier.Id == id) { 
                await _supplierService.DeleteSupplier(supplier.Id);
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