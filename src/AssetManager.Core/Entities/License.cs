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
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Purchase Cost")]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }


        [Display(Name = "Seats")]
        public int Seats { get; set; }

        [Display(Name = "Notes")]
        public string Notes { get; set; }


        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }

        [Display(Name = "Depreciation")]
        [ForeignKey("DepreciationId")]
        public int DepreciationId { get; set; }
        public virtual Depreciation Depreciation { get; set; }



        [Display(Name = "Licensed to Name")]
        public string LicenseName { get; set; }

        [Display(Name = "Licensed to Email")]
        public string LicenseEmail { get; set; }

       

        [Display(Name = "Supplier")]
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        [Display(Name = "Expiration Date")]
        public DateTime ExpirationDate { get; set; }

        [Display(Name = "Purchase Order Number")]
        public string PurchaseOrder { get; set; }

        [Display(Name = "Termination Date")]
        public DateTime TerminationDate { get; set; }

        [Display(Name = "Maintained")]
        public bool Maintained { get; set; }

        [Display(Name = "Reassignable")]
        public bool Reassignable { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Display(Name = "Manufacturer")]
        [ForeignKey("ManufacturerId")]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

       // public bool Depreciate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
