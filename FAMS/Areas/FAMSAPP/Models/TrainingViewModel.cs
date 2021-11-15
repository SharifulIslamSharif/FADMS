using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity;
using FADMS.Data.Entity.Attachment;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class TrainingViewModel
    {
        public int? trainingInfoId { get; set; }
        public int? personalInfoId { get; set; }

        public int? employeeId { get; set; }

        public int? trainingCategoryId { get; set; }

        public int? trainingInstituteId { get; set; }

        public string trainingDate { get; set; }

        public string heading { get; set; }

        public string remarks { get; set; }

        public string address { get; set; }

        public int licenseId { get; set; }

        public IFormFile[] attachment { get; set; }
        public IFormFile[] formFileArray { get; set; }
        public string[] fileUrl { get; set; }

        public TrainingLn TALang { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
       
       
    }
}
