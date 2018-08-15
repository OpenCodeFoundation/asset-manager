using AssetManager.Core.Entities;
using AssetManager.Core.Interfaces;
using AssetManager.Web.Interfaces;
using AssetManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Service
{
    public class LocationViewModelService : ILocationViewModelService
    {
        private readonly IAsyncRepository<Location> _locationRepository;
        private readonly IRepository<Location> _repository;
        public LocationViewModelService(
            IAsyncRepository<Location> locationRepository,
            IRepository<Location> repository
            )
        {
            this._locationRepository = locationRepository;
            this._repository = repository;
        }

        public async Task AddLocationAsync(LocationViewModel locationVM, string userId)
        {
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
            var location = await _locationRepository.GetByIdAsync(id);
            await _locationRepository.DeleteAsync(location);
        }

        public IEnumerable<LocationViewModel> GetAllLocation()
        {
            var locations = _repository.ListAll();
            var locationViewList = new List<LocationViewModel>();
            foreach(var location in locations)
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
    }
}
