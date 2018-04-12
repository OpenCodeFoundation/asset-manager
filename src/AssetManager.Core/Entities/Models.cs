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
    public class Models: Entity
    {



        [Required]
        [StringLength(150)]
        [Display(Name ="Model Name")]
        public string Name { get; set; }


        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        [Required]
        [ForeignKey("ManufacturerId")]
        [Display(Name = "Manufacturer Name")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }


        [Required]
        [ForeignKey("CategoryId")]
        [Display(Name = "Catagory Name")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Depreciation")]
        [ForeignKey("DepreciationId")]
        public int DepreciationId { get; set; }
        public virtual Depreciation Depreciation { get; set; }

        /// <summary>
        /// get user Id
        /// </summary>
        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }


        //EOL stand End of Lease in month

        [Display(Name ="EOL")]
        public int Eol { get; set; }

        [Display(Name ="Image")]
        public string Image { get; set; }

       // public bool DeprecatedMacAdress { get; set; }

        

        /// <summary>
        /// No Need now custom Fieldset. Fieldsets allow you to create groups of custom fields that are frequently re-used used for specific asset model types.
        /// </summary>
        //[Display(Name ="")]
        //[ForeignKey("FieldSetId")]
        //public int FieldSetId { get; set; }
        //public virtual CustomFields CustomFields { get; set; }

        [Display(Name="Note")]
        public string Notes { get; set; }

        [Display(Name = "Requestable")]
        public bool Requestable { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
        public virtual ICollection<Asset> Asset { get; set; }

    }
}
