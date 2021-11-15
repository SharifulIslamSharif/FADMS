using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity;
using FADMS.Data.Entity.LicenseInformation;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace FADMS.Areas.FAMSAPP.Models
{
    [NotMapped]
    public class TaxInfoViewModel
    {
        public string tin { get; set; }
        public int taxId { get; set; }
        public int orgId { get; set; }
        public IFormFile[] attachment { get; set; }
        //public IFormFile[] attachment1 { get; set; }
        public string[] fileUrl { get; set; }

        public int? personalInfoId { get; set; }
        public PersonalInfo personalInfo { get; set; }
        public ApplicationUser applicationUser { get; set; }
        //public IEnumerable<TaxInfo> taxInfos { get; set; }

        //public int? organizationInfoId { get; set; }
        public OrganizationInfo organizationInfo { get; set; }

        public string taxSubmitDate { get; set; }

        public string Amount { get; set; }

        public string description { get; set; }
        public int taxInfoId { get; set; }

        public TaxInfoLN TaxLang { get; set; }
        //public TaxInfo taxInfo { get; set; }
        // public IEnumerable<TaxInfo> taxInfos { get; set; }
    }
}
