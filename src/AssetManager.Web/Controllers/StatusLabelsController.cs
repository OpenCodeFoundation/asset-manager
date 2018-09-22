using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssetManager.Web.Controllers
{
    public class StatusLabelsController : Controller
    {
        private readonly IStatusLabelViewModelService  _statusLabelViewModelService;

        public StatusLabelsController(IStatusLabelViewModelService statusLabelViewModelService)
        {
            this._statusLabelViewModelService = statusLabelViewModelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allstatuslabel = await _statusLabelViewModelService.GetAllStatusAsync();
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
            var statusItem = await _statusLabelViewModelService.GetStatusAsync(id);
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
        public async Task<IActionResult> Create(StatusLabelViewModel label)
        {
            string userId = User.Identity.Name;
            if (ModelState.IsValid)
            {
                await _statusLabelViewModelService.AddStatusAsync(label, userId);
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
            var statusLabel = await _statusLabelViewModelService.GetStatusAsync(id);
            if (statusLabel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(statusLabel);
        }

        // POST: StatusLabels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StatusLabelViewModel label)
        {
            string userId = User.Identity.Name;
            if(ModelState.IsValid)
            {
                await _statusLabelViewModelService.UpdateStatusAsync(label, userId);
                return RedirectToAction(nameof(Index));
            }            
            return View();            
        }

        // GET: StatusLabels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return RedirectToAction(nameof(Index));
            }
            var statuslabel = await _statusLabelViewModelService.GetStatusAsync(id);
            if (statuslabel == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(statuslabel);
        }

        // POST: StatusLabels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, StatusLabelViewModel statusLabel)
        {
            if(statusLabel != null && statusLabel.Id == id)
            {
                await _statusLabelViewModelService.DeleteStatusAsync(statusLabel.Id);            
                return RedirectToAction(nameof(Index));
            }            
            return View();            
        }
    }
}