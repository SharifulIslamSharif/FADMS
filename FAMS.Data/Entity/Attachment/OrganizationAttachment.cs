using FADMS.Data.Entity.LicenseInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.Attachment
{
    public class OrganizationAttachment:Base
    {
        public string fileUrl { get; set; }
        public string fileName { get; set; }
        public string remarks { get; set; }
        public int? status { get; set; }

        public int? organizationInfoId { get; set; }
        public OrganizationInfo organizationInfo { get; set; }
    }
}
