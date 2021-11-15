using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class ArmTransportInfoViewModel
    {
      

        public int licenseId { get; set; }
        [Key]
        public int armTransportInfoId { get; set; }
        public string originPlace { get; set; }

        public string destinationPlace { get; set; }

        public string FromDate { get; set; }

        public string toDate { get; set; }

        public string reason { get; set; }
        //public ArmTransportInfo armTransport { get; set; }
        public ArmTransportInfoLn fLang { get; set; }
    }
}
