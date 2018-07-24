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
    public class Import: Entity
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int FileSize { get; set; }
        public string ImportType { get; set; }
        public string HeaderRow { get; set; }
        public string FirstRow { get; set; }
        public string FieldMap { get; set; }
    }
}
