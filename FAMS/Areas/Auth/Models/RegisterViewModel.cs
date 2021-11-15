using FADMS.Data.Entity;
using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models;
using FADMS.Data.Models.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.Auth.Models
{
    public class RegisterViewModel
    {
        public string Name { get; set; }//User Name
        public string Email { get; set; }     
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string PhoneNumber { get; set; }

        public int? userTypeId { get; set; }
        public int? licenseTypeId { get; set; }
        public int? dealerId { get; set; }
        public int? thanaId { get; set; }
        public int? districtId { get; set; }
        public int? divisionId { get; set; }

        public IFormFile ImgeUrl { get; set; }

        public string bpNumber { get; set; }


        public string rank { get; set; }

        public string personname { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RememberMe { get; set; }

        public IEnumerable<ApplicationRoleViewModel> userRoles { get; set; }
        public IEnumerable<LicenseType>  licenseTypes { get; set; }
        public IEnumerable<Dealer> dealers { get; set; }
        public IEnumerable<UserType> userTypes { get; set; }
        public IEnumerable<Thana>  thanas { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<vw_getAllDivisionViewModel> vw_divisions { get; set; }
        public IEnumerable<AspNetUsersViewModel> aspNetUsers { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public IEnumerable<SpGetAllThanaViewModel> spGetAllThanaViewModel { get; set; }
    }
}
