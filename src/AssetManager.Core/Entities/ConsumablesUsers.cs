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
        public int UserId { get; set; }
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
        public int AssignTo { get; set; }
    }
}
