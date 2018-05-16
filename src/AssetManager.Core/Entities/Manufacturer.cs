﻿using AssetManager.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class Manufacturer: Entity
    {
        [Required]
        [Display(Name =("Manufacturer Name"))]
        public string Name { get; set; }
        
        [Display(Name =("Web Site"))]
        [DataType(DataType.Url)]
        public string Url { get; set; }

        [Display(Name =("Support URL"))]
        [DataType(DataType.Url)]
        public string SupportUrl { get; set; }

        [Display(Name="Support Phone")]
        [DataType(DataType.PhoneNumber)]
        public string SupportPhone { get; set; }

        [Display(Name =("Support Email"))]
        [DataType(DataType.EmailAddress)]
        public string SupportEmail { get; set; }

        [Display(Name ="Image")]
        public string Image { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

    }
}
