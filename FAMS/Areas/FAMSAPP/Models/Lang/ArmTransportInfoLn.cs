using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class ArmTransportInfoLn
    {
        [Key]
        public string licenseID { get; set; }
        public string title { get; set; }

        public string originPlace { get; set; }

        public string destinationPlace { get; set; }

        public string FromDate { get; set; }

        public string toDate { get; set; }

        public string reason { get; set; }

        public string action { get; set; }
    }
}
