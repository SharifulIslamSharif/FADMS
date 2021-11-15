using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class GunwithdrawnViewmodel
    {
        
        public string depositeReference { get; set; }
        public string withdrawReference { get; set; }
        public string place { get; set; }
        public int gunId { get; set; }

        public string address { get; set; }

        public int? divisionId { get; set; }
        public Division division { get; set; }

        public int? districtId { get; set; }
        public District district { get; set; }

        public int? thanaId { get; set; }
        public Thana thana { get; set; }

        public DateTime? date { get; set; }

        public int? personalInfoId { get; set; }

        public int? organizationInfoId { get; set; }

        public int? gunDepositeInfoId { get; set; }
        public int? gunWithdrawInfoId { get; set; }

        public int? armTypeId { get; set; }
        public IFormFile[] attachment { get; set; }
        public string[] fileUrl { get; set; }

        public IEnumerable<ArmType> armTypes { get; set; }
       
        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
    }
}
