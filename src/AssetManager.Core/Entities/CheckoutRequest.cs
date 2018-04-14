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
    public class CheckoutRequest: Entity
    {

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User Admin { get; set; }

        [ForeignKey("RequestableId")]
        public int RequestableId { get; set; }
        public virtual Asset Asset { get; set; }

        [ForeignKey("RequestableType")]
        public int RequestableType { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
