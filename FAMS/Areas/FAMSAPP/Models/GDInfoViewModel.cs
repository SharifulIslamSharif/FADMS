using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class GDInfoViewModel
    {


        public int? personalInfoId { get; set; }
        public int? gdId { get; set; }
        public int? gunId { get; set; }
        public int? typeId { get; set; }
        
        public int? organizationInfoId { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public OrganizationInfo organizationInfo { get; set; }
        //public IEnumerable<CrimeInfo> gdInfos { get; set; }
        public IEnumerable<District> Districts { get; set; }
        public IEnumerable<Division> division { get; set; }
        public IEnumerable<Thana> thana { get; set; }
        public int? thanaId { get; set; }
        public int? DistrictId { get; set; }
        public int? divisionId { get; set; }

        //public int? divisionId { get; set; }
        //public int? districtId { get; set; }
        //public int? thanaId { get; set; }
        public string Reason { get; set; }
        public string instituteType { get; set; }
        public string licenseNumber { get; set; }

        public string CaseNo { get; set; }

        public DateTime CaseDate { get; set; }

        public string Result { get; set; }
        public IFormFile[] attachment { get; set; }
        public string[] fileUrl { get; set; }


        public string number { get; set; }
        public string reasion { get; set; }
        public string remarks { get; set; }
        public DateTime caseDate { get; set; }
        public string orgId { get; set; }
        public int? organId { get; set; }
        public int? personalId { get; set; }
        //public int? CrimeInfoId { get; set; }
        //public IEnumerable<CrimeInfo>  crimeInfos { get; set; }
        public GDInfoLn GDLang { get; set; }

        public int? usertype { get; set; } //1=admin user; 2=district user; 3 =thana user
    }
}
