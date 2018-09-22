using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.ViewModels
{
    public class DepreciationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Depreciation Name")]
        public string Name { get; set; }
        [Display(Name = "Number of Months")]
        public int Months { get; set; }

    }
}
