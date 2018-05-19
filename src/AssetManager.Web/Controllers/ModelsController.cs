using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssetManager.Web.Controllers
{
    public class ModelsController : Controller
    {
        private readonly IAsyncRepository<AssetModels> modelsRepository;

        public ModelsController(IAsyncRepository<AssetModels> repository)
        {
            this.modelsRepository = repository;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Models/Create
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