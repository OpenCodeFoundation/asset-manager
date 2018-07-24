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
    public class Status: Entity
    {

        [Display(Name =("Name"))]
        public string Name { get; set; }
        public int UserId { get; set; }

        public bool Deployable { get; set; }

        public bool UnDeployable { get; set; }

        public bool Pending { get; set; }

        public bool Archived { get; set; }

        [Display(Name ="Note")]
        public string Notes { get; set; }

        public string Color { get; set; }
    }
}
