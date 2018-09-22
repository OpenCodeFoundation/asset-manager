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
    public class AssetModels: Entity
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string ModelNumber { get; set; }
        public int DepreciationId { get; set; }
        public Depreciation Depreciation { get; set; }
        public int Eol { get; set; }
        public string Image { get; set; }
        public bool DeprecatedMacAdress { get; set; }
        public string Notes { get; set; }
        public bool Requestable { get; set; }
    }
}
