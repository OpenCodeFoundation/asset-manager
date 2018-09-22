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
    public class Manufacturer: Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string SupportUrl { get; set; }
        public string SupportPhone { get; set; }
        public string SupportEmail { get; set; }
        public string Image { get; set; }
    }
}
