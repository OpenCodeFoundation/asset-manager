using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Core.Entities
{
    public class User
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Permissions { get; set; }

        public bool Activated { get; set; }

        public string ActivationCode { get; set; }

        public DateTime ActivatedAt { get; set; }

        public DateTime LastLogin { get; set; }

        public string PersistCode { get; set; }

        public string ResetPasswordCode { get; set; }
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
        public virtual Location Location { get; set; }

        public string Phone { get; set; }

        public string JobTitle { get; set; }

        [ForeignKey("ManagerId")]
        public int ManagerId { get; set; }
        public virtual User Users { get; set; }

        public string UserName { get; set; }

        public string Notes { get; set; }

        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public string RememberToken { get; set; }

        public bool LdapImport { get; set; }

        public string Locale { get; set; }

        public bool ShowInList { get; set; }

        public string TwoFactorSecret { get; set; }

        public bool TwoFactorEnrolled { get; set; }

        public bool TwoFactorOptin { get; set; }

        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public virtual Departments Departments { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

    }
}
