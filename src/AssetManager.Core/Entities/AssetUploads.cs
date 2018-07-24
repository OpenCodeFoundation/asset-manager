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
    public class AssetUploads: Entity
    {
        public int UserId { get; set; }
        public string FileName { get; set; }
        public int AssetId { get; set; }
        public Asset Asset { get; set; }
        public string FileNotes { get; set; }        
    }
}
