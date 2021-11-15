using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class DealerLN
    {
        [Key]
        public string licenseID { get; set; }
        public string name { get; set; }

        public string licenseNo { get; set; }

        public string dealerInfo { get; set; }

        public string dealerInfoList { get; set; }
    }
}
