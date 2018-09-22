using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.ViewModels
{
    public class LocationViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Location Name")]
        public string Name { get; set; }
        public string Manager { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        public string AddressTwo { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = ("State"))]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Zip Code")]
        public int Zip { get; set; }

        [Display(Name = "Image")]
        public string ImageUri { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Extra { get; set; }
    }
}
