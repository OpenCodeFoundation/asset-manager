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
    public class StatusLabel: Entity
    {
        public string Name { get; set; }
        public StatusType Type { get; set; }
        public string Notes { get; set; }
        public bool ShowInNav { get; set; }
    }

    public enum StatusType
    {
        [Display(Name = "Deployable")]
        Deployable = 0,
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Undeployable")]
        Undeployable = 2,
        [Display(Name = "Archived")]
        Archived = 3
    }
}
