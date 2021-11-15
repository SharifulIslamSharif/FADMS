using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
  public  class SupplierPurchaseViewmodel
    {

        public int? purchaseMasterId { get; set; }
        public int? purchaseDetailsId { get; set; }
        //public int? dealerId { get; set; }
        public int? armsTypeId { get; set; }
        //public string dealerName { get; set; }
        //public string invoiceNumber { get; set; }
        //public string licenseNumber { get; set; }
        public string armsType { get; set; }
        public string itemName { get; set; }
        public string ArmTypeName { get; set; }
        public string supplierName { get; set; }
        public DateTime? invoiceDate { get; set; }
        public DateTime? createdAt { get; set; }
        public decimal? netTotal { get; set; }











        public int? purchasemasterId { get; set; }
        public int? purchasedetailsId { get; set; }
        //public string itemName { get; set; }
        //public string licenseNumber { get; set; }
        //public string dealerName { get; set; }
        //public string supplierName { get; set; }
        //public string invoiceNumber { get; set; }
        //public DateTime? invoiceDate { get; set; }
        //public string armsType { get; set; }
        public DateTime? lcDate { get; set; }
        public string poNo { get; set; }
        public decimal? subTotal { get; set; }

    }
}
