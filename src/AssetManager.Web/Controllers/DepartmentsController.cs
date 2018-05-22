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
    public class DepartmentsController : Controller
    {
        private readonly IAsyncRepository<Departments> _asyncRepository;
        private readonly IAsyncRepository<Location> _locRepository;
        private readonly IAsyncRepository<Company> _companyRepository;
        public DepartmentsController(
            IAsyncRepository<Departments> asyncRepository, 
            IAsyncRepository<Location> locRepository, 
            IAsyncRepository<Company> companyRepository)
        {
            this._asyncRepository = asyncRepository;
            this._companyRepository = companyRepository;
            this._locRepository = locRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departmentall = await _asyncRepository.ListAllAsync();
            return View(departmentall);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var department = await _asyncRepository.GetByIdAsync(id);
            if(department == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            ViewBag.Locations = await _locRepository.ListAllAsync();
            ViewBag.Companies = await _companyRepository.ListAllAsync();
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Departments departments)
        {
            if(ModelState.IsValid)
            {
                await _asyncRepository.AddAsync(departments);

                return RedirectToAction(nameof(Index));
            }
            
                return View(departments);
            
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departments/Edit/5
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

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departments/Delete/5
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