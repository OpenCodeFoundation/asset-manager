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
    public class ConsumablesController : Controller
    {
        private readonly IAsyncRepository<Consumable> _consumableyRepository;

        public ConsumablesController(IAsyncRepository<Consumable> repository)
        {
            this._consumableyRepository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var allconsuable = await _consumableyRepository.ListAllAsync();

            return View(allconsuable);
        }

    }
}
