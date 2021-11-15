using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
    public class LicenseInfo:Base
    {
        public int? licenseTypeId { get; set; }
        public LicenseType licenseType { get; set; }

        public int? armTypeId { get; set; }
        public ArmType armType { get; set; }

        public int? licenseSourseTypeId { get; set; }
        public LicenseSourseType licenseSourseType { get; set; }
       

        [Column(TypeName = "NVARCHAR(100)")]
        public string licenseNumber { get; set; }

        public int? thanaId { get; set; }
        public Thana thana { get; set; }

        public int? DistrictId { get; set; }
        public District District { get; set; }

        public int? divisionId { get; set; }
        public Division division { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string place { get; set; }
        [Column(TypeName = "NVARCHAR(260)")]
        public string reason { get; set; }
        [Column(TypeName = "NVARCHAR(60)")]
        public string source { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfIssue { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfExpair { get; set; }

        [Column(TypeName = "NVARCHAR(500)")]
        public string remarks { get; set; }

        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public int? organizationInfoId { get; set; }
        public OrganizationInfo organizationInfo { get; set; }
    }
}
