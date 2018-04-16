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
    public class Location: Entity
    {
        [Display(Name ="Location Name")]
        public string Name { get; set; }

        [Display(Name = ("Parent"))]
        [ForeignKey("Locations")]
        public int LocationsId { get; set; }
        public virtual Location Locations { get; set; }
        public int Manager { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        public string AddressTwo { get; set; }

        [Display(Name ="City")]
        public string City { get; set; }

        [Display(Name =("State"))]
        public string State { get; set; }

        [Display(Name ="Country")]
        public string Country { get; set; }
        public int UserId { get; set; }

        [Display(Name ="Zip Code")]
        public int Zip { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }


        [Display(Name ="Image")]
        public string Image { get; set; }

       

    }
}
