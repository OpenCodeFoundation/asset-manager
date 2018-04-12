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
    public class Category: Entity
    {


        [Required]
        [Display(Name =("Catagory Name"))]
        public string Name { get; set; }


        // [ForeignKey("UserId")]
        // public int UserId { get; set; }
        //public virtual User User { get; set; }



        [Display(Name =("EULA"))]
        public string EulaText { get; set; }

        [Display(Name =("Use the primary default EULA instead. "))]
        public bool DefaultEula { get; set; }

        //[Display(Name =("Require users to confirm acceptance of assets in this category."))]
        //public bool Acceptance { get; set; }

        /// <summary>
        /// Need to check, how to get class Name
        /// </summary>
        public string CategoryType { get; set; }

        [Display(Name =("Send email to user on checkin."))]
        public bool CheckInEmail { get; set; }

        [Display(Name =("Image"))]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public virtual ICollection<Models> Model { get; set; }

        public virtual ICollection<Components> Component { get; set; }

        public virtual ICollection<Accessory> Accessory { get; set; }

        public virtual ICollection<Consumable> Consumable { get; set; }

    }
}
