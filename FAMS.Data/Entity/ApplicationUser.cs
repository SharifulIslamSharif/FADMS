using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace FADMS.Data.Entity
{
    public class ApplicationUser: IdentityUser
    {
        
        public int? userTypeId { get; set; }
        public UserType userType { get; set; }
        public int? isActive { get; set; }

        public int? thanaId { get; set; }
        public Thana  thana { get; set; }

        public int? districtId { get; set; }
        public District district { get; set; }

        public int? divisionId { get; set; }
        public Division  division { get; set; }

        public DateTime? createdAt { get; set; }
        [MaxLength(120)]
        public string createdBy { get; set; }

        public DateTime? updatedAt { get; set; }
        [MaxLength(120)]
        public string updatedBy { get; set; }

        public string bpNumbers { get; set; }

        public string ranks { get; set; }


        public string PersonName { get; set; }

        public int isPassChanges { get; set; }

        public DateTime? passChangesDate { get; set; }

    }
}
