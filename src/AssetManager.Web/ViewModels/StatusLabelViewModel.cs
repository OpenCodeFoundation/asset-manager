using System;
using System.ComponentModel.DataAnnotations;

namespace AssetManager.Web.ViewModels
{
    public class StatusLabelViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public StatusTypeVM Type { get; set; }
        public string Notes { get; set; }
        public bool ShowInNav { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

    public enum StatusTypeVM
    {
        [Display(Name = "Deployable")]
        Deployable = 0,
        [Display(Name = "Pending")]
        Pending = 1,
        [Display(Name = "Undeployable")]
        Undeployable = 2,
        [Display(Name = "Archived")]
        Archived = 3
    }
}
