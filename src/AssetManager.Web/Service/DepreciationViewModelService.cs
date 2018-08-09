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
    public class DepreciationViewModelService : IDepreciationViewModelService
    {
        private readonly IAsyncRepository<Depreciation> _depreciationRepository;
        private readonly IRepository<Depreciation> _repository;
        public DepreciationViewModelService(IAsyncRepository<Depreciation> depreciationRepository, IRepository<Depreciation> repository)
        {
            this._depreciationRepository = depreciationRepository;
            this._repository = repository;
        }
        public async Task AddDepreciationAsync(DepreciationViewModel depreciationVM, string userId)
        {
            var depreciation = new Depreciation()
            {
                Name = depreciationVM.Name,
                Months = depreciationVM.Months,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };

            await _depreciationRepository.AddAsync(depreciation);
        }

        public async Task DeleteDepreciationAsync(int id)
        {
           var depreciation = await _depreciationRepository.GetByIdAsync(id);
            await _depreciationRepository.DeleteAsync(depreciation);
        }

        public IEnumerable<Depreciation> GetAllDepreciation()
        {
            return _repository.ListAll();
        }

        public async Task<IEnumerable<Depreciation>> GetAllDepreciationAsync()
        {
            return await _depreciationRepository.ListAllAsync();
        }

        public async Task<DepreciationViewModel> GetDepreciationAsync(int id)
        {
            var depreciation = await _depreciationRepository.GetByIdAsync(id);
            DepreciationViewModel depreciationViewModel = new DepreciationViewModel()
            {
               Id = depreciation.Id,
               Name = depreciation.Name,
               Months = depreciation.Months
            };
            return depreciationViewModel;
        }

        public async Task UpdateDepreciationAsync(DepreciationViewModel depreciationVM, string userId)
        {
            var depreciation = new Depreciation()
            {
                Id = depreciationVM.Id,
                Name = depreciationVM.Name,
                Months = depreciationVM.Months,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _depreciationRepository.UpdateAsync(depreciation);
        }
    }
}
