using AssetManager.Core.SharedKernel;
using System;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AssetManager.Core.Entities
{
    public class CustomFieldSet: Entity
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public string Element { get; set; }
        public int UserId { get; set; }
        public string FieldValues { get; set; }
        public bool FieldEncrypted { get; set; }
        public string DbColumn { get; set; }
        public string HelpText { get; set; }
    }
}
