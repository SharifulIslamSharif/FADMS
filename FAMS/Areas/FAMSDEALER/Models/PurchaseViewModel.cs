using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.AttachmentComment;
using FADMS.Data.Entity.Dealer.Purchase;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class PurchaseViewModel
    {
        public int? purchaseOrderMasterId { get; set; }
        public int? purchaseVatTypeId { get; set; }
        public int? dealerId { get; set; }
        public int? supplierId { get; set; }
        public int? itemSpecificationId { get; set; }
        public string poNo { get; set; }
        public string billOfEntryNo { get; set; }
        public string chalanNo { get; set; }
        public string hsCode { get; set; }
        public DateTime? poDate { get; set; }
        public DateTime? paymentDate { get; set; }
        public int? relSupplierCustomerResourseId { get; set; }
        public DateTime? deliveryDate { get; set; }
        public int? deliveryTypeId { get; set; }

        public int? paymentTypeId { get; set; }
        public string rfqRef { get; set; }
        public string remarks { get; set; }  // Custom House/Station
        public string billToLocation { get; set; }
        public int? saveStatusId { get; set; }

        public decimal? taxPercent { get; set; }
        public decimal? vatPercent { get; set; }
        public decimal? totalAmount { get; set; }
        public decimal? taxAmount { get; set; }
        public decimal? vatAmount { get; set; }
        public decimal? sdAmount { get; set; }
        public decimal? cdAmount { get; set; }
        public decimal? atAmount { get; set; }
        public decimal? rdAmount { get; set; }
        public decimal? netTotal { get; set; }
        public decimal? vds { get; set; }
        public int[] itemId { get; set; }
        public string[] itemSpecification { get; set; }
        public decimal?[] quantity { get; set; }
        public decimal?[] rate { get; set; }
        public decimal?[] vattotal { get; set; }
        public decimal?[] taxtotal { get; set; }
        public decimal?[] cdtotal { get; set; }
        public decimal?[] sdtotal { get; set; }
        public decimal?[] attotal { get; set; }
        public decimal?[] rdtotal { get; set; }
        public decimal?[] vatPercentage { get; set; }
        public decimal?[] taxPercentage { get; set; }


        public decimal?[] cdPercentage { get; set; }
        public decimal?[] rdPercentage { get; set; }
        public decimal?[] sdPercentage { get; set; }
        //public decimal?[] vatPercentage { get; set; }
        //public decimal?[] taxPercentage { get; set; }
        public decimal?[] atPercentage { get; set; }

        //LC
        public string lcNo { get; set; }
        public DateTime? lcDate { get; set; }
        public int? countryId { get; set; }
        public Country country { get; set; }

        public IEnumerable<Country> countries { get; set; }
        public IEnumerable<PurchaseOrderDetail> purchaseOrderDetails { get; set; }
        public IEnumerable<PurchaseOrderMaster> purchaseOrderMasters { get; set; }
        public IEnumerable<SpecificationCategory> specificationCategories { get; set; }

        public PurchaseOrderMaster GetPurchaseOrderMasterById { get; set; }
        public PurchaseReturnMaster GetPurchaseReturnMasterById { get; set; }
        public IEnumerable<PurchaseReturnDetail> purchaseReturnDetails { get; set; }

        public IEnumerable<Comment> comments { get; set; }
        //public Company company { get; set; }

        //Purchase Return
        public IEnumerable<PurchaseVatType> purchaseVatTypes { get; set; }
        public IEnumerable<Dealer> dealers { get; set; }
        public IEnumerable<PurchaseReturnMaster> purchaseReturnMasters { get; set; }
        public string organizationName { get; set; }
        public string mobile { get; set; }
    }
}
