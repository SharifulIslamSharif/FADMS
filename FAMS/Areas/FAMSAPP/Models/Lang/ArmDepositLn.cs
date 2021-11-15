using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class ArmDepositLn
    {
        [Key]
        public string licenseID { get; set; }
        public string title { get; set; }

        public string date { get; set; }

        public string reason { get; set; }

        public string Division { get; set; }

        public string District { get; set; }

        public string Upazila { get; set; }
        public string placeofdeposit { get; set; }
        public string depositaddress { get; set;}

        public string action { get; set; }
    }
}
