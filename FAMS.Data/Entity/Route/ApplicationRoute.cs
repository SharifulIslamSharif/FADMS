using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Route
{
    public class ApplicationRoute:Base
    {
        public int? status { get; set; }//0 = REJECT //1=application apply||2=Dc approved||3=sb inquire Submit||4=DC Confirmed||5=Home ministry confirm, ||6= RETURN 
        public string remarks { get; set; }
        public string applicationNo { get; set; }
        public DateTime? date { get; set; }

        public int? divisionId { get; set; }
        public Division  division { get; set; }

        public int? districtId { get; set; }
        public District  district { get; set; }

        public int? thanaId { get; set; }
        public Thana  thana { get; set; }

        public int? armTypeId { get; set; }
        public ArmType armType { get; set; }

        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public int? organizationInfoId { get; set; }
        public OrganizationInfo  organizationInfo { get; set; }
    }
}
