using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class CustomFieldCustomFieldset: Entity
    {

        [ForeignKey("CustomFieldsId")]
        public int CustomFieldsId { get; set; }
        public virtual CustomFields CustomFields { get; set; }

        [ForeignKey("CustomFieldsetId")]
        public int CustomFieldsetId { get; set; }
        public virtual CustomFields CustomFieldSet { get; set; }

        public int Order { get; set; }
        public bool Required { get; set; }
    }
}
