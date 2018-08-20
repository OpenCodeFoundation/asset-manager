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
    public class StatusLabelViewModelService : IStatusLabelViewModelService
    {
        private readonly IAsyncRepository<StatusLabel> _asyncRepository;
        private readonly IRepository<StatusLabel> _repository;
        private readonly ILogger<StatusLabelViewModelService> _logger;
        public StatusLabelViewModelService(
            IAsyncRepository<StatusLabel> asyncRepository,
            IRepository<StatusLabel> repository,
            ILoggerFactory loggerFactory
            )
        {
            this._asyncRepository = asyncRepository;
            this._repository = repository;
            this._logger = loggerFactory.CreateLogger<StatusLabelViewModelService>();
        }
        public async Task AddStatusAsync(StatusLabelViewModel statusLabel, string userId)
        {
            _logger.LogInformation("AddStatusAsync called.");
            var status = new StatusLabel()
            {
                Id = statusLabel.Id,
                Name = statusLabel.Name,
                Type = TypeChange(statusLabel.Type),
                Notes = statusLabel.Notes,
                ShowInNav = statusLabel.ShowInNav,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _asyncRepository.AddAsync(status);
        }

        /// <summary>
        /// this is for only enum type parse. 
        /// </summary>
        /// <param name="TypeChange"></param>
        /// <returns></returns>
        private StatusType TypeChange(StatusTypeVM statusTypeVM)
        {
            _logger.LogInformation("TypeChange called.");
            StatusType statusType = StatusType.Deployable;
            Enum.TryParse<StatusType>(statusTypeVM.ToString(), out statusType);
            return statusType;
        }
        public async Task DeleteStatusAsync(int id)
        {
            _logger.LogInformation("DeleteStatusAsync called.");
            var statusLabel = await _asyncRepository.GetByIdAsync(id);
            await _asyncRepository.DeleteAsync(statusLabel);
        }

        public async Task<IEnumerable<StatusLabelViewModel>> GetAllStatusAsync()
        {
            _logger.LogInformation("GetAllStatusAsync called.");
            var statusLabels = await _asyncRepository.ListAllAsync();
            var statusLabelViewList = new List<StatusLabelViewModel>();

            foreach (var status in statusLabels)
            {
                var statusView = new StatusLabelViewModel()
                {
                    Id = status.Id,
                    Name = status.Name,
                    Type = TypeChanger(status.Type),
                    Notes = status.Notes,
                    ShowInNav = status.ShowInNav
                };
                statusLabelViewList.Add(statusView);
            }
            return statusLabelViewList;
        }

        /// <summary>
        /// this is for only enum type parse.
        /// </summary>
        /// <param name="TypeChanger"></param>
        /// <returns></returns>
        private StatusTypeVM TypeChanger(StatusType statusType)
        {
            _logger.LogInformation("TypeChanger called.");
            StatusTypeVM statusTypeVM = StatusTypeVM.Deployable;
            Enum.TryParse<StatusTypeVM>(statusTypeVM.ToString(), out statusTypeVM);
            return statusTypeVM;
        }

        public async Task<IEnumerable<SelectListItem>> GetStatus()
        {
            _logger.LogInformation("GetStatus called.");
            var allStatus = await _asyncRepository.ListAllAsync();
            var items = new List<SelectListItem>
            {
                new SelectListItem() { Value = null, Text = "All", Selected = true }
            };
            foreach (StatusLabel status in allStatus)
            {
                items.Add(new SelectListItem() { Value = status.Id.ToString(), Text = status.Name });
            }

            return items;
        }

        public async Task<StatusLabelViewModel> GetStatusAsync(int id)
        {
            _logger.LogInformation("GetStatusAsync called.");
            var status = await _asyncRepository.GetByIdAsync(id);
            var statusVM = new StatusLabelViewModel()
            {
                Id = status.Id,
                Name = status.Name,
                Type = TypeChanger(status.Type),
                Notes = status.Notes,
                ShowInNav = status.ShowInNav,
                CreatedAt = status.CreatedAt,
                UpdatedAt = status.UpdatedAt,
                UpdatedBy = status.UpdatedBy
            };
            return statusVM;
        }

        public async Task UpdateStatusAsync(StatusLabelViewModel statusLabel, string userId)
        {
            _logger.LogInformation("UpdateStatusAsync called.");
            var status = new StatusLabel()
            {
                Id = statusLabel.Id,
                Name = statusLabel.Name,
                Type = TypeChange(statusLabel.Type),
                Notes = statusLabel.Notes,
                ShowInNav = statusLabel.ShowInNav,
                UpdatedAt = DateTime.Now,
                UpdatedBy = userId
            };
            await _asyncRepository.UpdateAsync(status);
        }
    }
}
