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
    }
}
