using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.ViewModels
{
    public class DepartmentsIndexViewModel
    {
        public IEnumerable<DepartmentsViewModel> Departments { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Managers { get; set; }
        public PaginationInfoViewModel PaginationInfo { get; set; }
    }
}
