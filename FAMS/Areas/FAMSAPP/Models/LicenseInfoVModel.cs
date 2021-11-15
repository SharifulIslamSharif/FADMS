using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class LicenseInfoVModel
    {
        public int? licenseTypeId { get; set; }
        public int licenseId { get; set; }

        public int? armTypeId { get; set; }
        public int? ArmTypeId { get; set; }
        public int? licenseSourseTypeId { get; set; }
   
        public string licenseNumber { get; set; }
        public int licenseType { get; set; }
        public string licenseTypeName { get; set; }
        public string licenseSourseName { get; set; }
        public string armsTypeName { get; set; }

        public int? thanaId { get; set; }

        public int? DistrictId { get; set; }

        public int? divisionId { get; set; }
        public int? thanaid { get; set; }

        public int? districtid { get; set; }

        public int? divisionid { get; set; }

        public string place { get; set; }
        public string reason { get; set; }
        public string Name { get; set; }
        public string OldName { get; set; }
        public string GdNumber { get; set; }
        public string source { get; set; }

        public DateTime? dateOfIssue { get; set; }
        public DateTime? GdDate { get; set; }
        public IEnumerable<string> licenseNos { get; set; }

        public DateTime? dateOfExpair { get; set; }
        public string remarks { get; set; }

        public int? personalInfoId { get; set; }

        public int? organizationInfoId { get; set; }
        public IEnumerable<LicenseInfo> licenseInfos { get; set; }
      
        public IEnumerable<ArmType> armTypes { get; set; }
        public IEnumerable<Division>  divisions { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
    }
}
