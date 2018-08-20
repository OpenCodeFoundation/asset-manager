using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssetManager.Web.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentsViewModelService _departmentsViewModelService;
        private readonly ILocationViewModelService _locationViewModelService;
        public DepartmentsController(
            IDepartmentsViewModelService departmentsViewModelService,
            ILocationViewModelService locationViewModelService)
        {
            this._departmentsViewModelService = departmentsViewModelService;
            this._locationViewModelService = locationViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var departmentall = await _departmentsViewModelService.GetAllDepartmentsAsync();
            return View(departmentall);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var department = await _departmentsViewModelService.GetDepartmentsAsync(id);
            if(department == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            IEnumerable<SelectListItem> LocationList = await _locationViewModelService.GetLocation();
            ViewBag.Locations = LocationList;
            return View();
        }

        // POST: Departments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DepartmentsViewModel departments)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _departmentsViewModelService.AddDepartmentsAsync(departments, userId);
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
            var department = await _departmentsViewModelService.GetDepartmentsAsync(id);
            if (department == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = await _locationViewModelService.GetLocation();
            return View(department);
        }

        // POST: Departments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentsViewModel departments)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _departmentsViewModelService.UpdateDepartmentsAsync(departments, userId);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Locations = await _locationViewModelService.GetLocation();
            return View(departments);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var deleteDept = await _departmentsViewModelService.GetDepartmentsAsync(id);
            if(deleteDept == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(deleteDept);
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DepartmentsViewModel departmentsViewModel)
        {
            if(ModelState.IsValid)
            {
                await _departmentsViewModelService.DeleteDepartmentsAsync(departmentsViewModel.Id);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }
    }
}