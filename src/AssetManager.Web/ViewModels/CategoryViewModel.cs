using System;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Web.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = ("Catagory Name"))]
        public string Name { get; set; }

        [Display(Name = ("EULA"))]
        public string EulaText { get; set; }

        [Display(Name = ("Use the primary default EULA instead. "))]
        public bool DefaultEula { get; set; }

        [Display(Name = "Category Type")]
        public CatagoryTypeVM Type { get; set; }

        [Display(Name = ("Send email to user on checkin."))]
        public bool CheckInEmail { get; set; }

        [Display(Name = ("Image"))]
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }
    public enum CatagoryTypeVM
    {
        [Display(Name = "Asset")]
        Asset,
        [Display(Name = "Component")]
        Component,
        [Display(Name = "Accessory")]
        Accessory,
        [Display(Name = "Consumable")]
        Consumable
    }
}
