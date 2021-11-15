using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    [NotMapped]
    public class OrgAddressLN
    {
        public string employeeId { get; set; }
        public string title { get; set; }
        public string Division { get; set; }
        public string District { get; set; }
        public string Upazila { get; set; }
        public string Union { get; set; }
        public string PostOffice { get; set; }
        public string PostCode { get; set; }
        public string BlockSector { get; set; }
        public string HouseVillage { get; set; }
        public string permanent { get; set; }
        public string present { get; set; }
        public string titlelist { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string organization { get; set; }
        public string area { get; set; }
    }
}
