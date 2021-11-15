using FADMS.Data.Entity.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models.Auth
{
    public class ApplicationRoleViewModel
    {
        public string RoleId { get; set; }        
        public string PreRoleId { get; set; }
        public string id { get; set; }

        public string[] roleIdList { get; set; }

        public string userId { get; set; }

        public string userName { get; set; }
        public string EuserName { get; set; }
        public string personname { get; set; }
        public string email { get; set; }
        public string bpnumber { get; set; }
        public string rank { get; set; }
        public string phonenumber { get; set; }

        public string RoleName { get; set; }

        public int? moduleId { get; set; }

        public string description { get; set; }

        public string moduleName { get; set; }
        public IEnumerable<FAMSModule> fAMSModules { get; set; }
        public IEnumerable<ApplicationRoleViewModel> roleViewModels { get; set; }
    }
}
