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
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        [Required]
        public string AssetTag { get; set; }


        [Required]
        [ForeignKey("ModelId")]
        public int ModelId { get; set; }
        public virtual Models Model { get; set; }

        [Required]
        [ForeignKey("StatusId")]
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        [Display(Name = "Serial")]
        public string Serial { get; set; }

        [Display(Name ="Asset Name")]
        public string Name { get; set; }

        [Display(Name ="Purchase Date")]
        public DateTime PurchaseDate { get; set; }


        [Required]
        [ForeignKey("SupplierId")]
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }


        [Display(Name ="Order Number")]
        public string OrderNumber { get; set; }

        [Display(Name ="Purchase Cost")]
        public decimal PurchaseCost { get; set; }

        [Display(Name = "Warrenty")]
        public int WarrantyMonths { get; set; }

        [Display(Name = "Note")]
        public string Notes { get; set; }


        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }


        [Display(Name = "Requestable")]
        public bool Requestable { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

       

        //[Display(Name = "Checkout To")]
        //[ForeignKey("UserId")]
        //public int AssignedTo { get; set; }
        //public virtual User User { get; set; }



            /// <summary>
            /// Checkout to User
            /// </summary>


        // [Display(Name ="Checkout To")]
        // [ForeignKey("UserId")]
        // public int AssignedTo { get; set; }
        //public virtual User User { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [MaxLength(1)]
        public byte Physical { get; set; }

        public DateTime DeletedAt { get; set; }

       

        public bool Archived { get; set; }



        public bool Depreciate { get; set; }

        
        

        //public int RtdLocatonId { get; set; }
        //public string _snipeit_mac_address_1 { get; set; }

        public bool Accepted { get; set; }
        public DateTime LastCheckout { get; set; }

        public DateTime ExpectedCheckin { get; set; }

    
        //should be user class
        public string AssignedType { get; set; }
        public DateTime LastAuditDate { get; set; }
        public DateTime NextAuditDate { get; set; }
















    }
}
