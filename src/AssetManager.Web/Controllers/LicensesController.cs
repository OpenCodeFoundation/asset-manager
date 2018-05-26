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
    public class LicensesController : Controller
    {
        private readonly IAsyncRepository<License> _licenseasyncRepository;

        public LicensesController(IAsyncRepository<License> licenseasyncRepository)
        {
            this._licenseasyncRepository = licenseasyncRepository;
        }
        public async Task<IActionResult> Index()
        {
            var licenseslist = await _licenseasyncRepository.ListAllAsync();
            return View(licenseslist);
        }

       
    }
}