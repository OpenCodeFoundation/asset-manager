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
    public class HardwareController : Controller
    {
        private readonly IAsyncRepository<Asset> _hardwareRepository;

        public HardwareController(IAsyncRepository<Asset> hardwareRepository)
        {
            this._hardwareRepository = hardwareRepository;
        }
        public async Task<IActionResult> Index()
        {
            var hardwarelist = await _hardwareRepository.ListAllAsync();
            return View(hardwarelist);
        }

        // GET: Hardware/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Hardware/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hardware/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
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

        // GET: Hardware/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hardware/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
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

        // GET: Hardware/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hardware/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
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