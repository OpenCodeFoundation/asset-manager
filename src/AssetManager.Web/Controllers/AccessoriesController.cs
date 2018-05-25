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
    public class AccessoriesController : Controller
    {
        private readonly IAsyncRepository<Accessory> _accessoriesRepository;

        public AccessoriesController(IAsyncRepository<Accessory> repository)
        {
            this._accessoriesRepository = repository;
        }
    }
}
