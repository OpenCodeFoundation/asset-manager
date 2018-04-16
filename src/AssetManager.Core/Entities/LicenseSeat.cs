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
        [ForeignKey("License")]
        public int LicenseId { get; set; }
        public virtual License License { get; set; }
        public int AssignTo { get; set; }
        [Display(Name = "Note")]
        public string Note { get; set; }

        [Display(Name = "Asset")]
        [ForeignKey("Asset")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
