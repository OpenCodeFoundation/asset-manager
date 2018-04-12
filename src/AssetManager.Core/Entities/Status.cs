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
    public class Status: Entity
    {


        [Display(Name =("Name"))]
        public string Name { get; set; }

        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }



        public bool Deployable { get; set; }

        public bool UnDeployable { get; set; }

        public bool Pending { get; set; }

        public bool Archived { get; set; }

        [Display(Name ="Note")]
        public string Notes { get; set; }

        ///// <summary>
        ///// get Color code
        ///// </summary>
        //public string Color { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public virtual ICollection<Asset> Asset { get; set; }
    }
}
