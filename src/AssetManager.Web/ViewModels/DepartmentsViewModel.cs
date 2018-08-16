using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.ViewModels
{
    public class DepartmentsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Department Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]
        public int LocatonId { get; set; }

        public string ManagerId { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}
