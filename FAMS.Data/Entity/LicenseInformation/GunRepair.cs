using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
    public class GunRepair:Base
    {
        public string referenceNO { get; set; }
        public string reason { get; set; }
        public string licenseNumber { get; set; }
        public string Attachment { get; set; }
        public DateTime? date { get; set; }
        public string GdNumber { get; set; }
        public DateTime? GDdate { get; set; }

        public int? dealerId { get; set; }
        public FADMS.Data.Entity.Dealer.Dealer dealer { get; set; }
        
        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public int? organizationInfoId { get; set; }
        public OrganizationInfo organizationInfo { get; set; }
    }
}
