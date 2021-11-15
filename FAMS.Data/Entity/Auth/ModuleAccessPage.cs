using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Auth
{
    public class ModuleAccessPage:Base
    {
        public int? eRPModuleId { get; set; }
        public FAMSModule eRPModule { get; set; }
        
        public string applicationRoleId { get; set; }
        public ApplicationRole applicationRole { get; set; }
    }
}
