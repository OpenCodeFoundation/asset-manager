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
    public class Depreciation: Entity
    {
        [Display(Name = "Depreciation Name")]
        public string Name { get; set; }
   
        [Display(Name = "Number of Months")]
        public int Months { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual ICollection<AssetModels> Models { get; set; }

    }
}
