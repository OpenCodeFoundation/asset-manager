using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class AccessoriesUsers: Entity
    {


        /// <summary>
        /// get current user Id
        /// </summary>
        /// 
        //[ForeignKey("UserId")]
        //public int UserId { get; set; }
        //public virtual User User { get; set; }
        ////Need to add

            
        [ForeignKey("AccessoryId")]
        public int AccessoryId { get; set; }
        public virtual Accessory Accessory { get; set; }

        //Need to add
        //[ForeignKey("AssignTo")]
        //public int AssignTo { get; set; }
        //public virtual User User { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
