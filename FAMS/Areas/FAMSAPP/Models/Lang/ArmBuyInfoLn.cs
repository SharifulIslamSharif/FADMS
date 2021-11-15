using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class ArmBuyInfoLn
    {
        [Key]
        public string DealerId { get; set; }
        public string title { get; set; }
        public string armsType { get; set; }
        public string quantity { get; set; }
        public string position { get; set; }
        public string source { get; set; }
        public string sourceInfo { get; set; }
        public string action { get; set; }
        public string origin { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string isTransported { get; set; }
        public string changedAddress { get; set; }
        public string purchaseDate { get; set; }
        public string armIdNo { get; set; }
        public string dealerName { get; set; }
        public string licenseNo { get; set; }
        public string address { get; set; }
        public string issueDate { get; set; }
        public string expiryDate { get; set; }
        public string phone { get; set; }
    }
}
