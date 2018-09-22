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
    public class License: Entity
    {
        [Display(Name = "Software Name")]
        public string Name { get; set; }

        [Display(Name = "Product Key")]
        public string Serial { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Cost")]
        [DataType(DataType.Currency)]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        
        [Display(Name = "Seats")]
        public int Seats { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Display(Name = "Depreciation")]
        public int DepreciationId { get; set; }
        public Depreciation Depreciation { get; set; }
        public string LicenseName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string LicenseEmail { get; set; }
        public bool Depreciate { get; set; }

        [Display(Name = "Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Purchase Order Number")]
        public string PurchaseOrder { get; set; }

        [Display(Name = "Termination Date")]
        [DataType(DataType.Date)]
        public DateTime TerminationDate { get; set; }

        [Display(Name = "Maintained")]
        public bool Maintained { get; set; }

        [Display(Name = "Reassignable")]
        public bool Reassignable { get; set; }

        [Display(Name = "Manufacturer")]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }

        [Display(Name = "Category Name")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
