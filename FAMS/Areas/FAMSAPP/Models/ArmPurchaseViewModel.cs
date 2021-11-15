using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
//using FAMSAPPLICATION.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class ArmPurchaseViewModel
    {
        public int id { get; set; }
        public string DealerInfo { get; set; }
        public string ArmType { get; set; }
        public string licenseNo { get; set; }
        public string dealerName { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expiryDate { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string ammunition { get; set; }
        public string ArmsModel { get; set; }
        public string ManufactureInfo { get; set; }
        public int quantity { get; set; }
        public string purchaseDate { get; set; }
        public string SerialNo { get; set; }

        //public IEnumerable<ArmType> getArmsType { get; set; }
        //public IEnumerable<ManufactureInfo> getManufactureInfos { get; set; }
        //public IEnumerable<ArmPurchaseInfo> GetArmPurchaseInfos { get; set; }
        //public IEnumerable<ArmPurchaseInfo> GetarmPurchaseInfobydealerId { get; set; }
        //public ArmPurchaseInfo armPurchaseInfo { get; set; } 
        //public ArmPurchaseInfoLn armPurchaseInfoLn { get; set; }

        public IEnumerable<ArmStockViewModel> armStockViewModels { get; set; }
    }
}
