using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssetManager.Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IAsyncRepository<AssetModels> modelsRepository;
        private readonly IAsyncRepository<Manufacturer> _menurepository;
        private readonly IAsyncRepository<Category> _caterepository;
        private readonly IAsyncRepository<Depreciation> _depcaterepository;


        public ModelsController(IAsyncRepository<AssetModels> repository, IAsyncRepository<Manufacturer> manufacturer, IAsyncRepository<Category> cateRepo, IAsyncRepository<Depreciation> deprepos)
        {
            this.modelsRepository = repository;
            this._menurepository = manufacturer;
            this._caterepository = cateRepo;
            this._depcaterepository = deprepos;
        }
        public async Task<IActionResult> Index()
        {
            
            var allModels = await modelsRepository.ListAllAsync();
            
            return View(allModels);
        }

        // GET: Models/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Models/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var allmanufecturer = await _menurepository.ListAllAsync();
            
            ViewBag.manufacturer = allmanufecturer;
            ViewBag.category = await _caterepository.ListAllAsync();
            ViewBag.depreciation = await _depcaterepository.ListAllAsync();
            return View();
        }

        

        // POST: Models/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AssetModels model)
        {
            if(ModelState.IsValid)
            {
                await modelsRepository.AddAsync(model);

                return RedirectToAction(nameof(Index));
            }
            
                return View();
            
        }

        // GET: Models/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Models/Edit/5
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

        // GET: Models/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Models/Delete/5
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