using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class DepositViewModel
    {
        public int depositId { get; set; }
        public string licenseNo { get; set; }
        public string dealerName { get; set; }
        public DateTime issueDate { get; set; }
        public DateTime expiryDate { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string armType { get; set; }
        public string quantity { get; set; }
        public string manufactureInfo { get; set; }
        public string ammunition { get; set; }
        public string armsModel { get; set; }
        public string armsInfo { get; set; }
        public string serialNo { get; set; }
    }
}
