using FADMS.Data.Entity.Attachment;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.VM;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class GunRepairViewModel
    {

        public int? gunRepairId { get; set; }
        public string referenceNO { get; set; }
        public string reason { get; set; }
        public string licenseNumber { get; set; }
        public IFormFile Attachment { get; set; }

        public IFormFile[] attachment { get; set; }
        public IFormFile[] formFileArray { get; set; }
        public string[] fileUrl { get; set; }

        public DateTime? date { get; set; }

        public int? dealerId { get; set; }
        public FADMS.Data.Entity.Dealer.Dealer dealer { get; set; }
        
        public int? personalInfoId { get; set; }

        public int? organizationInfoId { get; set; }

        public IEnumerable<string> licenseNos { get; set; }
        public IEnumerable<FADMS.Data.Entity.Dealer.Dealer> dealers { get; set; }
        public IEnumerable<PersonMenuOptionDetailsVM> gunRepairs { get; set; }
        public IEnumerable<GunRepairAttachment> gunRepairAttachments { get; set; }

    }
}
