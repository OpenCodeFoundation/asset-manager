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
    public class Asset: Entity
    {

        [Required]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        
        [Required]
        public string AssetTag { get; set; }
        
        [Required]
        [ForeignKey("Models")]
        public int ModelsId { get; set; }

        [Required]
        [ForeignKey("Status")]
        public int StatusId { get; set; }
       
        [Display(Name = "Serial")]
        public string Serial { get; set; }

        [Display(Name ="Asset Name")]
        public string Name { get; set; }

        [Display(Name ="Purchase Date")]
        public DateTime PurchaseDate { get; set; }


        [Required]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        


        [Display(Name ="Order Number")]
        public string OrderNumber { get; set; }

        [Display(Name ="Purchase Cost")]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Warrenty")]
        public int WarrantyMonths { get; set; }

        [Display(Name = "Note")]
        public string Notes { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        [Display(Name = "Requestable")]
        public bool Requestable { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
        public int AssignedTo { get; set; }
        public int CheckoutTo { get; set; }
    
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [MaxLength(1)]
        public byte Physical { get; set; }

        public DateTime DeletedAt { get; set; }
        public bool Archived { get; set; }

        public bool Depreciate { get; set; }

        public bool Accepted { get; set; }
        public DateTime LastCheckout { get; set; }
        public DateTime ExpectedCheckin { get; set; }
        public string AssignedType { get; set; }
        public DateTime LastAuditDate { get; set; }
        public DateTime NextAuditDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Status Status { get; set; }
        public virtual Models Models { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Location Location { get; set; }

    }
}
