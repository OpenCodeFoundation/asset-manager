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
    public class Supplier: Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Notes { get; set; }
        public string Zip { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
    }
}
