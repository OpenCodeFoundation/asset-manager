using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssetManager.Web.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IAsyncRepository<Company> _companyRepository;

        public CompaniesController(IAsyncRepository<Company> repository)
        {
            this._companyRepository = repository;
        }

        // GET: Companies
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companies = await _companyRepository.ListAllAsync();
            return View(companies);
        }

        // GET: Companies/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Companies/Create

        public  IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            try
            {
                // TODO: Add insert logic here

                await _companyRepository.AddAsync(company);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Companies/Edit/5
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

        // GET: Companies/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Companies/Delete/5
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