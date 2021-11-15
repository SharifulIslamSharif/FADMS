using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
//using FAMSAPPLICATION.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class ArmStockViewModel
    {
        public string NameOfOrganization { get; set; }
        public string ArmTypeName { get; set; }
        public int PurchaseQuantity { get; set; }
        public int SaleQuantity { get; set; }
        public int Balance { get; set; }
        public int DealerInfoId { get; set; }
        public int ArmTypeId { get; set; }


    }
}
