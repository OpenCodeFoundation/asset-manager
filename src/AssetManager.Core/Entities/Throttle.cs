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
    public class Throttle: Entity
    {
        public int UserId { get; set; }
        public string IpAddress { get; set; }

        public int Attemps { get; set; }

        public bool Suspended { get; set; }

        public bool Banned { get; set; }

        public DateTime LastAttemptAt { get; set; }

        public DateTime SupendedAt { get; set; }

        public DateTime BannedAt { get; set; }
    }
}
