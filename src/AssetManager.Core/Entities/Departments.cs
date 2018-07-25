using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class Departments: Entity
    {
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Display(Name = "Location")]
        public int LocatonId { get; set; }
        public Location Location { get; set; }

        public string ManagerId { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
    }
}
