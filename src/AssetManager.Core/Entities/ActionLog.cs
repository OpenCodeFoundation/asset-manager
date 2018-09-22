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
    public class ActionLog: Entity
    {
        public int UserId { get; set; }
        public string ActionType { get; set; }
        public int TargetId { get; set; }
        public string TargetType { get; set; }
        public int LocatonId { get; set; }
        public Location Location { get; set; }
        public string Note { get; set; }
        public string FileName { get; set; }
        public string ItemType { get; set; }
        public int ItemId { get; set; }
        public DateTime ExpecteCheckIn { get; set; }
        public int AcceptedId { get; set; }
        public string AcceptSign { get; set; }
        public string LogMeta { get; set; }     
    }
}
