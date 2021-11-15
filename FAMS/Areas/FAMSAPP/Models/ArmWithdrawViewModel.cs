using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;


namespace FAMSAPPLICATION.Areas.License.Models
{
    public class ArmWithdrawViewModel
    {
        public int licenseId { get; set; }
        [Key]
        public int armWithdrawId { get; set; }

        public string date { get; set; }



        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        //public ArmWithdraw armWithdraw { get; set; }
        //public ArmWithdrawLn fLang { get; set; }

    }
}
