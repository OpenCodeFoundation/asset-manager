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
        public int LicenseId { get; set; }
        public License License { get; set; }
        public int AssignTo { get; set; }

        [Display(Name = "Note")]
        [DataType(DataType.Text)]
        public string Note { get; set; }

        [Display(Name = "Asset")]
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int UserId { get; set; }
    }
}
