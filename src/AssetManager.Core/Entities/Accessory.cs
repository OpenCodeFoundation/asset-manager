
using AssetManager.Core.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManager.Core.Entities
{
    public class Accessory: Entity
    {

        [Display(Name = "Accessory Name")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }


        [Display(Name = "Supplier")]
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Display(Name = "Requestable")]
        public bool Requestable { get; set; }

        [Display(Name = "Location")]
        [ForeignKey("Location")]
        public int LocatonId { get; set; }


        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Cost")]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }


        [Display(Name = "Min Qty.")]
        public int MinAmt { get; set; }

        [Display(Name = "Manufacturer")]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }


        [Display(Name ="Model Number")]
        public string ModelNumber { get; set; }

        [Display(Name ="Image")]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Location Location { get; set; }
        public virtual Company Company { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
    }
}
