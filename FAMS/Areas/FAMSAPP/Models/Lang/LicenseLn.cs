using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class LicenseLn
    {
        [Key]
        public string licenseID { get; set; }
        public string title { get; set; }
        public string licenseTypeId { get; set; }
        public string licenseGunType { get; set; }
        public string licenseNumber { get; set; }
        public string districtI { get; set; }
        public string thanaI { get; set; }
        public string place { get; set; }

        public string reason { get; set; }

        public string source { get; set; }

        public string dateOfIssue { get; set; }
        
        public string dateOfExpair { get; set; }

        public string armsType { get; set; }
        public string quantity { get; set; }
        public string position { get; set; }
      

        public string action { get; set; }
    }
}
