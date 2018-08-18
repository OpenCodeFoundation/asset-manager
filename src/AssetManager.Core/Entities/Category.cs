using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Core.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string EulaText { get; set; }
        public bool DefaultEula { get; set; }
        public CatagoryType Type { get; set; }
        public bool CheckInEmail { get; set; }
        public string Image { get; set; }
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


