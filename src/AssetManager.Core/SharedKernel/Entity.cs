using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManager.Core.SharedKernel
{
    public class Entity 
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime DeletedAt { get; set; }
        public string Extra { get; set; }
    }
}
