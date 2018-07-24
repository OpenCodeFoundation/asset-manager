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
        public int CustomFieldsId { get; set; }
        public CustomFields CustomFields { get; set; }
        public int CustomFieldsetId { get; set; }
        public int Order { get; set; }
        public bool Required { get; set; }
    }
}
