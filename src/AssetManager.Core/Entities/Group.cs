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
    public class Group: Entity
    {
        [Display(Name ="Group Name")]
        public string Name { get; set; }
        public string Permissions { get; set; }
    }
}
