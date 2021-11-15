using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class GunDepositeViewModel
    {
        public string referenceNO { get; set; }
        public int? gunTempSuspendedId { get; set; }
        public string reason { get; set; }
        public int gunDepoId { get; set; }

        public string place { get; set; }
        public string licenseNumber { get; set; }
        public string GdNumber { get; set; }

        public string Address { get; set; }
        public IFormFile Attachment { get; set; }
        public IFormFile[] attachment { get; set; }
        public string[] fileUrl { get; set; }

        public int? armTypeId { get; set; }
        public int? dealerId { get; set; }

        public int? divisionId { get; set; }
        public Division division { get; set; }

        public int? districtId { get; set; }
        public District district { get; set; }

        public int? thanaId { get; set; }
        public Thana thana { get; set; }

        public DateTime? date { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? GdDate { get; set; }

        public int? personalInfoId { get; set; }

        public int? organizationInfoId { get; set; }

        public IEnumerable<string> licenseNos { get; set; }
        public IEnumerable<LicenseInfo> licenseInfos { get; set; }
        public IEnumerable<Dealer> dealers { get; set; }
        public IEnumerable<ArmType> armTypes { get; set; }
        public IEnumerable<Division> divisions { get; set; }
      
        public IEnumerable<LicenseInfo> getlicensenumber{ get; set; }
        public IEnumerable<LicenseInfo> licensenumber{ get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        //public IEnumerable<GunTravelinfo> guntravelinfos { get; set; }
    }
}
