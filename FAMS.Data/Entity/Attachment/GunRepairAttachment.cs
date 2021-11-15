using FADMS.Data.Entity.LicenseInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Attachment
{
    public class GunRepairAttachment:Base
    {
        public string fileUrl { get; set; }
        public string fileName { get; set; }
        public string remarks { get; set; }
        public int? status { get; set; }

        public int? gunRepairId { get; set; }
        public GunRepair  gunRepair { get; set; }

        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public int? organizationInfoId { get; set; }
        public OrganizationInfo organizationInfo { get; set; }
    }
}
