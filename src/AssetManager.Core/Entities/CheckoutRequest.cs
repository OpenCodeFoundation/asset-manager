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
        public int UserId { get; set; }
        public int RequestableAssetId { get; set; }
        public Asset Asset { get; set; }
        public string RequestableType { get; set; }
        public int Quantity { get; set; }
    }
}
