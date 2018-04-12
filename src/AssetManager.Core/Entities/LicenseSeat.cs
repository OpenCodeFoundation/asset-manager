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

    public class LicenseSeat : Entity
    {



        [ForeignKey("LicenseId")]
        public int LicenseId { get; set; }
        public virtual License License { get; set; }


        [Display(Name = "User")]
        [ForeignKey("AssignTo")]
        public int AssignTo { get; set; }
        public virtual User AssignToUser { get; set; }


        [Display(Name = "Note")]
        public string Note { get; set; }

        
        [Display(Name = "Asset")]
        [ForeignKey("AssetId")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User Admin { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
