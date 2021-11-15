using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity;
using FADMS.Data.Entity.Attachment;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class GdViewModel
    {
        public int? personalInfoId { get; set; }
        public int gdId { get; set; }

        public int? organizationInfoId { get; set; }

        public string Reason { get; set; }

        public string CaseNo { get; set; }

        public DateTime? CaseDate { get; set; }

        public string Result { get; set; }
        public IFormFile[] attachment { get; set; }
        public string[] fileUrl { get; set; }


        public string number { get; set; }
        public string reasion { get; set; }
        public string remarks { get; set; }
        public DateTime? caseDate { get; set; }
        public string orgId { get; set; }
        public string LicenseNumber { get; set; }
        public IEnumerable<District> Districts { get; set; }
        public IEnumerable<Division> division { get; set; }
        public IEnumerable<Thana> thana { get; set; }
        public int? thanaId { get; set; }
        public int? DistrictId { get; set; }
        public int? divisionId { get; set; }


        //public IEnumerable<GDAttachment> gdAttachments { get; set; }
        //public IEnumerable<CrimeInfo> gdInfos { get; set; }
        public GDInfoLn GDLang { get; set; }
        public ApplicationUser applicationUser  { get; set; }
    }
}
