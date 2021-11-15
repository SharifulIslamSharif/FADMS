using FADMS.Areas.FAMSAPP.Models.Lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
   

    public class LicenseApplicationViewModel
    {
        public string licenseTypeId { get; set; }
        public string applyNumber { get; set; }
        public string licenseName { get; set; }
        public string licenseType { get; set; }
        public string armsType { get; set; }


        public string licenseApprover { get; set; }




        public string applyForm { get; set; }
        public string fileName { get; set; }
        public string fileType { get; set; }
        public string comments { get; set; }
        public string docAttchment { get; set; }




        public LicenseApplicationLN fLang { get; set; }
       
    }
}
