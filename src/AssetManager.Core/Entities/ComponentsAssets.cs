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
        public int ComponentsId { get; set; }
        public Components Components { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
    }
}
