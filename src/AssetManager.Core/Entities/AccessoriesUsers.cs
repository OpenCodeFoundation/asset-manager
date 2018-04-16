using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class AccessoriesUsers: Entity
    {
        [ForeignKey("Accessory")]
        public int AccessoryId { get; set; }
        

        public int AssignTo { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Accessory Accessory { get; set; }
    }
}
