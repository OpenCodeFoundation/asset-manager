using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManager.Web.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Display(Name = "Address")]
        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Display(Name = " ")]
        [MaxLength(100)]
        public string AddressTwo { get; set; }

        [Display(Name = "City")]
        [MaxLength(100)]
        public string City { get; set; }

        [Display(Name = "State")]
        [MaxLength(100)]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        [Display(Name = "Phone")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        [DataType(DataType.Text)]
        public string Fax { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Contact")]
        [DataType(DataType.Text)]
        public string Contact { get; set; }

        [Display(Name = "Note")]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [Display(Name = "Zip")]
        [DataType(DataType.PostalCode)]
        public string Zip { get; set; }

        [Display(Name = "URL")]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Display(Name = "Image")]
        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }
    }
}
