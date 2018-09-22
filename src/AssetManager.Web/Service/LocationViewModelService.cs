using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Service
{
    /// <summary>
    /// This is a UI-specific service so belongs in UI project. It does not contain any business logic and works
    /// with UI-specific types (view models and SelectListItem types).
    /// </summary>
    public class LocationViewModelService : ILocationViewModelService
    {
        private readonly ILogger<LocationViewModelService> _logger;
        private readonly IAsyncRepository<Location> _locationRepository;
        private readonly IRepository<Location> _repository;
        public LocationViewModelService(
            IAsyncRepository<Location> locationRepository,
            IRepository<Location> repository,
            ILoggerFactory loggerFactory
            )
        {
            this._locationRepository = locationRepository;
            this._repository = repository;
            this._logger = loggerFactory.CreateLogger<LocationViewModelService>();
        }

        public async Task AddLocationAsync(LocationViewModel locationVM, string userId)
        {
            _logger.LogInformation("AddLocationAsync called.");
            var location = new Location()
            {
                Id = locationVM.Id,
                Name = locationVM.Name,
                Manager = locationVM.Manager,
                Address = locationVM.Address,
                AddressTwo = locationVM.AddressTwo,
                City = locationVM.City,
                State = locationVM.State,
                Country = locationVM.Country,
                Zip = locationVM.Zip,
                ImageUri = locationVM.ImageUri,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _locationRepository.AddAsync(location);
        }

        public async Task DeleteLocationAsync(int id)
        {
            _logger.LogInformation("DeleteLocationAsync called.");
            var location = await _locationRepository.GetByIdAsync(id);
            await _locationRepository.DeleteAsync(location);
        }

        public IEnumerable<LocationViewModel> GetAllLocation()
        {
            _logger.LogInformation("GetAllLocation called.");
            var locations = _repository.ListAll();
            var locationViewList = new List<LocationViewModel>();
            foreach (var location in locations)
            {
                var locationView = new LocationViewModel()
                {
                    Id = location.Id,
                    Name = location.Name,
                    Manager = location.Manager,
                    Address = location.Address,
                    AddressTwo = location.AddressTwo,
                    City = location.City,
                    State = location.State,
                    Country = location.Country,
                    Zip = location.Zip,
                    ImageUri = location.ImageUri,
                    CreatedAt = location.CreatedAt,
                    UpdatedAt = location.UpdatedAt,
                    UpdatedBy = location.UpdatedBy,
                    DeletedAt = location.DeletedAt,
                    Extra = location.Extra
                };
                locationViewList.Add(locationView);
            }
            return locationViewList;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAllLocationAsync()
        {
            _logger.LogInformation("GetAllLocationAsync called.");
            var locations = await _locationRepository.ListAllAsync();

            var locationViewList = new List<LocationViewModel>();
            foreach (var location in locations)
            {
                var locationView = new LocationViewModel()
                {
                    Id = location.Id,
                    Name = location.Name,
                    Manager = location.Manager,
                    Address = location.Address,
                    AddressTwo = location.AddressTwo,
                    City = location.City,
                    State = location.State,
                    Country = location.Country,
                    Zip = location.Zip,
                    ImageUri = location.ImageUri,
                    CreatedAt = location.CreatedAt,
                    UpdatedAt = location.UpdatedAt,
                    UpdatedBy = location.UpdatedBy,
                    DeletedAt = location.DeletedAt,
                    Extra = location.Extra
                };
                locationViewList.Add(locationView);
            }
            return locationViewList;
        }

        public async Task<LocationViewModel> GetLocationAsync(int id)
        {
            _logger.LogInformation("GetLocationAsync called.");
            var location = await _locationRepository.GetByIdAsync(id);
            LocationViewModel locationViewModel = new LocationViewModel()
            {
                Id = location.Id,
                Name = location.Name,
                Manager = location.Manager,
                Address = location.Address,
                AddressTwo = location.AddressTwo,
                City = location.City,
                State = location.State,
                Country = location.Country,
                Zip = location.Zip,
                ImageUri = location.ImageUri,
                CreatedAt = location.CreatedAt,
                UpdatedAt = location.UpdatedAt,
                UpdatedBy = location.UpdatedBy,
                DeletedAt = location.DeletedAt,
                Extra = location.Extra
            };

            return locationViewModel;
        }

        public async Task UpdateLocationAsync(LocationViewModel locationVM, string userId)
        {
            _logger.LogInformation("UpdateLocationAsync called.");
            var location = new Location()
            {
                Id = locationVM.Id,
                Name = locationVM.Name,
                Manager = locationVM.Manager,
                Address = locationVM.Address,
                AddressTwo = locationVM.AddressTwo,
                City = locationVM.City,
                State = locationVM.State,
                Country = locationVM.Country,
                Zip = locationVM.Zip,
                ImageUri = locationVM.ImageUri,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _locationRepository.UpdateAsync(location);
        }

        public async Task<IEnumerable<SelectListItem>> GetLocation()
        {
            _logger.LogInformation("GetLocations called.");
            var locations = await _locationRepository.ListAllAsync();

            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (Location location in locations)
            {
                items.Add(new SelectListItem() { Value = location.Id.ToString(), Text = location.Name });
            }

            return items;
        }
    }
}
