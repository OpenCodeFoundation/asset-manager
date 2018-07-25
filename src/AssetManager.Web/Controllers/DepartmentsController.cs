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
        public DepartmentsController(
            IAsyncRepository<Departments> asyncRepository, 
            IAsyncRepository<Location> locRepository)
        {
            this._asyncRepository = asyncRepository;
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var department = await _asyncRepository.GetByIdAsync(id);
            if (department == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = await _locRepository.ListAllAsync();
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departments collection)
        {
            if (ModelState.IsValid)
            {
                await _asyncRepository.UpdateAsync(collection);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Locations = await _locRepository.ListAllAsync();
            return View(collection);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var deleteDept = await _asyncRepository.GetByIdAsync(id);
            if(deleteDept == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(deleteDept);
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Departments collection)
        {
            if(ModelState.IsValid)
            {
                await _asyncRepository.DeleteAsync(collection);

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));

        }
    }
}