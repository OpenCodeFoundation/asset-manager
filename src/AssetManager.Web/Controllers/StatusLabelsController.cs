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
    public class StatusLabelsController : Controller
    {
        private readonly IAsyncRepository<StatusLabel> _statusRepository;

        public StatusLabelsController(IAsyncRepository<StatusLabel> repository)
        {
            _statusRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allstatuslabel = await _statusRepository.ListAllAsync();
            return View(allstatuslabel);
        }

        // GET: StatusLabels/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var statusItem = await _statusRepository.GetByIdAsync(id); 

            return View(statusItem);
        }

        // GET: StatusLabels/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusLabels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StatusLabel label)
        {
            
            try
            {

                await _statusRepository.AddAsync(label);
                 return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatusLabels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StatusLabels/Edit/5
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

        // GET: StatusLabels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatusLabels/Delete/5
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