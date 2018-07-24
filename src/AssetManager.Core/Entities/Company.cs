using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Core.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
