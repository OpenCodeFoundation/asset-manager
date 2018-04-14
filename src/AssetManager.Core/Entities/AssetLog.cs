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
    public class AssetLog: Entity
    {

        public int UserId { get; set; }
        public string ActionType { get; set; }

        [ForeignKey("AssetId")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
   
        [ForeignKey("CheckedoutTo")]
        public int CheckedoutTo { get; set; }
        public virtual User CheckedoutToUser { get; set; }

        [ForeignKey("LocationId")]
        public int LocatonId { get; set; }
        public virtual Location Location { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public string Assetype { get; set; }
        public string Note { get; set; }

        public string FileName { get; set; }

        public DateTime RequestedAt { get; set; }

        public DateTime AcceptedAt { get; set; }

        [ForeignKey("AccessoryId")]
        public int AccessoryId { get; set; }
        public virtual Accessory Accessory { get; set; }

        [ForeignKey("AcceptedId")]
        public int AcceptedId { get; set; }
        public virtual User AcceptedBy { get; set; }

        [ForeignKey("ConsumableId")]
        public int ConsumableId { get; set; }
        public virtual Consumable Consumable { get; set; }

        public DateTime ExpectedCheckin { get; set; }

        [ForeignKey("ComponentId")]
        public int ComponentId { get; set; }
        public virtual Components Component { get; set; }
    }
}
