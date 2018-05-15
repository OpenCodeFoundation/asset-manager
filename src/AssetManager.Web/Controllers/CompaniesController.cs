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


        // GET: Companies/Create
        [HttpGet]
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
                company.CreateDate = DateTime.Now;
                company.UpdateDate = DateTime.Now;
                await _companyRepository.AddAsync(company);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            try
            {
                if (id == company.Id)
                {
                    company.UpdateDate = DateTime.Now;
                   await _companyRepository.UpdateAsync(company);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Companies/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (id >= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id >= 0)
            {
                return RedirectToAction(nameof(Index));
            }

            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id, Company company)
        {
           
            try
            {
                
                if (id == company.Id)
                {
                    await _companyRepository.DeleteAsync(company);
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