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
    public class Departments: Entity
    {


        [Display(Name = "Department Name")]
        public string Name { get; set; }

        /// <summary>
        /// get user id
        /// </summary>
        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }

        [Display(Name = "Company")]
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }


        [Display(Name = "Location")]
        [ForeignKey("LocationId")]
        public int LocatonId { get; set; }
        public virtual Location Location { get; set; }


        /// <summary>
        /// get Manager of branch
        /// </summary>
        //[ForeignKey("ManagerId")]
        //public int ManagerId { get; set; }
        //public virtual User User { get; set; }

        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        

    }
}
