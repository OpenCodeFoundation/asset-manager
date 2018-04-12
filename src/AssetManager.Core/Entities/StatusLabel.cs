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
    public class StatusLabel: Entity
    {


        [Display(Name ="Name")]
        public string Name { get; set; }

        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User Admin { get; set; }



        public bool Deployable { get; set; }

        public bool Pending { get; set; }
        public bool Archived { get; set; }

        public string Notes { get; set; }

        //public string Color { get; set; }

        //public bool ShowInNav { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
