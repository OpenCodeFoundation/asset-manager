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
    public class Departments: Entity
    {
        public string Name { get; set; }
        public int LocatonId { get; set; }
        public Location Location { get; set; }
        public string ManagerId { get; set; }
        public string Note { get; set; }
        public string Image { get; set; }
    }
}
