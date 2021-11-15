using FADMS.Data.Entity;
using FADMS.Data.Entity.Auth;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models.Auth
{
    public class UserListViewModel
    {
        public IEnumerable<AspNetUsersViewModel> aspNetUsersViewModels { get; set; }
        public IEnumerable<ApplicationRoleViewModel> userRoles { get; set; }
        public IEnumerable<FAMSModule> modules { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Division> divisions { get; set; }
    }
}
