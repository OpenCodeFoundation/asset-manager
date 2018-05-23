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
    public class DepreciationController : Controller
    {
        private readonly IAsyncRepository<Depreciation> _depreciationRepository;
        public DepreciationController(IAsyncRepository<Depreciation> repository)
        {
            this._depreciationRepository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var depreciation = await _depreciationRepository.ListAllAsync();
            return View(depreciation);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var depIteam = await _depreciationRepository.GetByIdAsync(id);
            if(depIteam == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(depIteam);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Depreciation item)
        {
            if (ModelState.IsValid)
            {
                await _depreciationRepository.AddAsync(item);

                return RedirectToAction(nameof(Index));
            }
                return View();
            
        }

        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var dep = await _depreciationRepository.GetByIdAsync(id);
            if(dep == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(dep);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Depreciation obj)
        {
          
            try
            {
               await _depreciationRepository.UpdateAsync(obj);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var deleteIteam = await _depreciationRepository.GetByIdAsync(id);
            return View(deleteIteam);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Depreciation item)
        {
            if(id != item.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                await _depreciationRepository.DeleteAsync(item);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}