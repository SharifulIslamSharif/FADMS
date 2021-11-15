using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
   public class DealerSalesViewModel
    {
        public int? purchaseMasterId { get; set; }
        public int? purchaseDetailsId { get; set; }
    
        public int? dealerId { get; set; }
        public int? supplierId { get; set; }
        public int? armsTypeId { get; set; }
        public string dealerName { get; set; }
        public string invoiceNumber { get; set; }
        public string licenseNumber { get; set; }
        public string armsType { get; set; }
        public string itemName { get; set; }
        public string ArmTypeName { get; set; }
        public string supplierName { get; set; }
        public string poNo { get; set; }
        public DateTime? invoiceDate { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? lcDate { get; set; }
        public decimal? subTotal { get; set; }
        public decimal? netTotal { get; set; }


        public int? salesmasterId { get; set; }
        public int? salesdetailsId { get; set; }
        public int? personalInfoId { get; set; }
        public int? organizationInfoId { get; set; }
        public int? itemId { get; set; }


  

    }
}
