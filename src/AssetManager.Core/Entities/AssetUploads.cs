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



        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User Admin { get; set; }

        public string FileName { get; set; }

        [ForeignKey("AssetId")]
        public int AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public string FileNotes { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }
    }
}
