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
    public class ConsumablesUsers: Entity
    {


        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }

        [ForeignKey("ConsumableId")]
        public int ConsumableId { get; set; }
        public virtual Consumable Consumable { get; set; }

        [ForeignKey("AssignTo")]
        public int AssignTo { get; set; }
        //public virtual User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
