using System;
using System.ComponentModel.DataAnnotations.Schema;
using AssetManager.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace AssetManager.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        public string WebSite { get; set; }

        public string Country { get; set; }

        public string Gravatar { get; set; }

        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string Phone { get; set; }

        public string JobTitle { get; set; }

        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Departments Departments { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

    }
}
