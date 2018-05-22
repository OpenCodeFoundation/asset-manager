using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Core.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string ImageUrl { get; set; }

        public ICollection<Departments> Departments { get; set; }

    }
}
