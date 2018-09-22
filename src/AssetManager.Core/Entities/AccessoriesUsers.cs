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
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
        public int AssignTo { get; set; }
       
    }
}
