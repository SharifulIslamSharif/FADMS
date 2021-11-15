using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.Collections.Generic;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class OrgTaxInfoViewModel
    {
        public int? taxId { get; set; }

        public int financialId { get; set; }
        public int licenseTypeIdT { get; set; }

        public decimal? amount { get; set; }

        public string tin { get; set; }

        public string taxSubmitDate { get; set; }

        public string description { get; set; }

        public OrgTaxInfoLN fLang { get; set; }
        //public OrgTaxInfo orgTaxInfo { get; set; }
        //public IEnumerable<OrgTaxInfo> orgTaxInfos { get; set; }
    }
}
