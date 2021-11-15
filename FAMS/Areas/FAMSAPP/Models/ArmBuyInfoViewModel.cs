using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
//using FAMSAPPLICATION.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class ArmBuyInfoViewModel
    {
        public int armsBuyerid { get; set; }
        public string dealerInfo { get; set; }
        public string armType { get; set; }
        public string armsModel { get; set; }
        public string manufactureInfo { get; set; }
        public int quantity { get; set; }
        public string purchaseDate { get; set; }
        public string serialNo { get; set; }
        public string licenseNo { get; set; }
        public string dealerName { get; set; }
        public string salesType { get; set; }
        public string address { get; set; }
        public string ammunition { get; set; }
        public string phone { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expiryDate { get; set; }
        public DateTime salesDate { get; set; }

        //public IEnumerable<ArmType> getArmsType { get; set; }
        //public IEnumerable<ManufactureInfo> getManufactureInfos { get; set; }
        //public IEnumerable<ArmBuyInfo> GetArmBuyInfos { get; set; }
        //public IEnumerable<ArmBuyInfo> GetarmBuyInfobylicenseNo { get; set; }
        //public ArmBuyInfo armBuyInfo { get; set; }
        //public ArmBuyInfoLn armBuyInfoLn { get; set; }
    }
}
