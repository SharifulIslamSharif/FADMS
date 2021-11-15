using FADMS.Data.Entity.LicenseInformation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class UploadExcelViewModel
    {
        public IFormFile file { get; set; }
        public int? personalInfoId { get; set; }
        public int? organizationId { get; set; }
        public int? dealerId { get; set; }
        public int? supplierId { get; set; }
        public int? hsCodeId { get; set; }
        public int? itemId { get; set; }
        public int? shootingclubId { get; set; }
  
        //public IEnumerable<TrainingInformation> trainingInformation { get; set; }
    }
}
