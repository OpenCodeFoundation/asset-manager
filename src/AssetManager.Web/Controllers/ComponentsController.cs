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
    public class ComponentsController : Controller
    {
        private readonly IAsyncRepository<Components> _componentRepository; 
        public ComponentsController(IAsyncRepository<Components> componentRepository)
        {
            this._componentRepository = componentRepository;
        }


        [HttpGet]
        public async Task<IActionResult> Index(){

            var componentslist = await _componentRepository.ListAllAsync();
            return View(componentslist);
        }

        
    }



}