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
    public class Supplier: Entity
    {


        [Display(Name ="Name")]
        public string Name { get; set; }

        [Display(Name = "Name")]
        public string Address { get; set; }

        [Display(Name = " ")]
        public string AddressTwo { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        public string Fax { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contact")]
        public string Contact { get; set; }


        [Display(Name = "Note")]
        public string Notes { get; set; }


        [Display(Name = "Zip")]
        public string Zip { get; set; }

        [Display(Name = "URL")]
        public string Url { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }

        public DateTime DeletedAt { get; set; }



        public virtual ICollection<Asset> Asset { get; set; }

        public virtual ICollection<Accessory> Accessory { get; set; }
    }
}
