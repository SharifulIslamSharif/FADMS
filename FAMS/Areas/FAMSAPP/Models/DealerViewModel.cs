using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using FADMS.Areas.FAMSAPP.Models.Lang;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class DealerViewModel
    {
        public int licenseId { get; set; }
        [Key]
        public int dealerId { get; set; }



        public string name { get; set; }

        public string licenseNo { get; set; }
        //public Dealer dealer { get; set; }
        public DealerLN fLang { get; set; }
      //  public OrgAddressViewModel orgAddressViewModel { get; set; }

    }
}
