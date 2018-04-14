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
    public class ComponentsAssets: Entity
    {
        public int UserId { get; set; }
        public int AssignedQty { get; set; }

        [ForeignKey("ComponentId")]
        public int ComponentId { get; set; }
        public virtual Components Component { get; set; }

        [ForeignKey("AssetId")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
