using FADMS.Data.Entity.ArmsInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
   public class OrganizationInfo:Base
    {
        public int? licenseTypeId { get; set; } //2 =organization ||3 = financialOrganization

        public string name { get; set; }
        public string OrgCode { get; set; }

        public string type { get; set; }

        public string orgCategory { get; set; }

        public DateTime? establishDate { get; set; }

        public int? noOfEmployee { get; set; }

        public int? noOfVehicle { get; set; }

        public string ownerName { get; set; }

        public string tid { get; set; }

        public string branchName { get; set; }

        public string branchManager { get; set; }

        
        public int? isBBPermit { get; set; }

        public string bbAttachment { get; set; }

        public int? isHomeRentalAgreement { get; set; }

        public string homeRentalAgreementAttachment { get; set; }

        public string securityProtected { get; set; }

        public string reasonOfFireArms { get; set; }

        public int? numberOfFireArms { get; set; }

        public string beforeArms { get; set; }
        public int? status { get; set; }
        public string LicenseNo { get; set; }

        public int? armTypeId { get; set; }
        public ArmType armType { get; set; }
        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
