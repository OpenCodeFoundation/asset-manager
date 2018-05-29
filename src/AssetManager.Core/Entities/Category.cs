using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Core.Entities
{
    public class Category : Entity
    {
        [Required]
        [Display(Name = ("Catagory Name"))]
        public string Name { get; set; }

        [Display(Name = ("EULA"))]
        public string EulaText { get; set; }

        [Display(Name = ("Use the primary default EULA instead. "))]
        public bool DefaultEula { get; set; }

        [Display(Name = "Category Type")]
        public CatagoryType Type { get; set; }

        [Display(Name = ("Send email to user on checkin."))]
        public bool CheckInEmail { get; set; }

        [Display(Name = ("Image"))]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public virtual ICollection<AssetModels> Models { get; set; }
    }
    public enum CatagoryType
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


