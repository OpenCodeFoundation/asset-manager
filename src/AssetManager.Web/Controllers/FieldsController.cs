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
    public class FieldsController : Controller
    {
        private readonly IAsyncRepository<CustomFields> _customFieldsRepository;

        public FieldsController(IAsyncRepository<CustomFields> fieldsRepository)
        {
            this._customFieldsRepository = fieldsRepository;
        }
        public async Task<IActionResult> Index()
        {
            var allfields = await _customFieldsRepository.ListAllAsync();
            return View(allfields);
        }

        // GET: Fields/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Fields/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fields/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomFields fields)
        {
            if(ModelState.IsValid)
            {
                await _customFieldsRepository.AddAsync(fields);
                return RedirectToAction(nameof(Index));
            }            
            return View();
            
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var fieldCollection = await _customFieldsRepository.GetByIdAsync(id);
            return View(fieldCollection);
        }

        // POST: Fields/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, CustomFields data)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }            
            try
            {
                await _customFieldsRepository.DeleteAsync(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Index));
            }
        }
    }
}