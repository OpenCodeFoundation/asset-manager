using AssetManager.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.Interfaces
{
    public interface IStatusLabelViewModelService
    {
        Task AddStatusAsync(StatusLabelViewModel statusLabel, string userId);
        Task DeleteStatusAsync(int id);
        Task<StatusLabelViewModel> GetStatusAsync(int id);
        Task UpdateStatusAsync(StatusLabelViewModel statusLabel, string userId);
        Task<IEnumerable<StatusLabelViewModel>> GetAllStatusAsync();
        Task<IEnumerable<SelectListItem>> GetStatus();
    }
}
