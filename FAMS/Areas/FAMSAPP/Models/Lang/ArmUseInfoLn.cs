using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class ArmUseInfoLn
    {
        [Key]
        public string licenseID { get; set; }
        public string reason { get; set; }
        public string gdNo { get; set; }
        public  string documentSubject { get; set; }
        public string documentDescription { get; set; }
        public string address { get; set; }
        public string thana { get; set; }
        public string bulletQuantity { get; set; }
        public string district { get; set; }
        public string division { get; set; }


    }
}
