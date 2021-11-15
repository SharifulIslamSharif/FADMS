using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class ArmDepositViewModel
    {
        public int licenseId { get; set; }
        [Key]
        public int depositId { get; set; }

        public string date { get; set; }

        public string reason { get; set; }
        public string placeofdeposit { get; set; }
        public string depositaddress { get; set; }
        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        
        //public ArmDeposit armDeposit { get; set; }
        //public ArmDepositLn fLang { get; set; }
    }
}
