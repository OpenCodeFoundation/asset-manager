
using AssetManager.Core.SharedKernel;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetManager.Core.Entities
{
    public class Accessory: Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int Qty { get; set; }
        public bool Requestable { get; set; }
        public int LocatonId { get; set; }
        public Location Location { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Cost")]
        [DataType(DataType.Currency)]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        [Display(Name = "Min Qty.")]
        public int MinAmt { get; set; }

        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
 
    }
}
