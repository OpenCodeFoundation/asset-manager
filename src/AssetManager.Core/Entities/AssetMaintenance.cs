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
    public class AssetMaintenance: Entity
    {
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public string AssetMaintanceType { get; set; }
        public string Title { get; set; }
        public bool IsWarranty { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime CompletionDate { get; set; }
        public int AssetMaintanceTime { get; set; }
        [DataType(DataType.Text)]
        public string Note { get; set; }
        [DataType(DataType.Currency)]
        public decimal Cost { get; set; }
        public int UserId { get; set; }
    }
}
