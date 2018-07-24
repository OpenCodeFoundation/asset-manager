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
        public int AssetId { get; set; }
        public  Asset Asset { get; set; }
        public int CheckedoutTo { get; set; }
        public int LocationId { get; set; }
        public  Location Location { get; set; }      
        public string Assetype { get; set; }
        public string Note { get; set; }
        public string FileName { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime AcceptedAt { get; set; }
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
        public int AcceptedId { get; set; }
        public int ConsumableId { get; set; }
        public Consumable Consumable { get; set; }
        public DateTime ExpectedCheckin { get; set; }
        public int ComponentsId { get; set; }
        public Components Components { get; set; }
    }
}
