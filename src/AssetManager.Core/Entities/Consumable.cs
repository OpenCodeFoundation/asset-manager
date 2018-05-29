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
    public class Consumable: Entity
    {
        [Display(Name = "Consumable Name")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Display(Name = "Location")]
        [ForeignKey("Location")]
        public int LocatonId { get; set; }
        public virtual Location Location { get; set; }
        
        [Display(Name ="Qty")]
        public int Qty { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Cost")]
        [DataType(DataType.Currency)]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Min. QTY")]
        public int MinmumAmt { get; set; }

        [Display(Name = "Model Number")]
        public string ModelNumber { get; set; }


        [Display(Name = "Manufacturer")]
        [ForeignKey("Manufacturer")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [Display(Name = "Item No")]
        public int ItemNo { get; set; }

        [Display(Name ="Image")]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
