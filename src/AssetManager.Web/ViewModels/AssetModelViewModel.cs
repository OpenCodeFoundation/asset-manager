using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.ViewModels
{
    public class AssetModelViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Asset Model Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Manufacturer Name")]
        public int ManufacturerId { get; set; }

        [Required]
        [Display(Name = "Catagory Name")]
        public int CategoryId { get; set; }

        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        [Display(Name = "Depreciation")]
        public int DepreciationId { get; set; }

        [Display(Name = "EOL")]
        public int Eol { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public bool DeprecatedMacAdress { get; set; }

        [Display(Name = "Note")]
        public string Notes { get; set; }

        [Display(Name = "Users may request this model")]
        public bool Requestable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
}
