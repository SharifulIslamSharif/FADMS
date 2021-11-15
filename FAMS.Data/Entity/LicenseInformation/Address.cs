using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
   public class Address:Base
    {
        //Foreign Reliation
        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public int? organizationInfoId { get; set; }
        public OrganizationInfo organizationInfo { get; set; }

        public int? countryId { get; set; }
        public Country country { get; set; }

        public int? divisionId { get; set; }
        public Division division { get; set; }

        public int? districtId { get; set; }
        public District district { get; set; }

        public int? thanaId { get; set; }
        public Thana thana { get; set; }

        public string union { get; set; }

        public string roadNo { get; set; }

        public string postOffice { get; set; }

        public string postCode { get; set; }

        public string blockSector { get; set; }

        public string houseVillage { get; set; }

        public string area { get; set; }

        //Type: Permamnent or Present
        [Required]
        public string type { get; set; }
    }
}
