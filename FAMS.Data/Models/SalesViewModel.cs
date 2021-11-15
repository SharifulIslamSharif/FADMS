using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Dealer.AttachmentComment;
using FADMS.Data.Entity.Dealer.Sales;
using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace FADMS.Data.Models
{
  public  class SalesViewModel
    {
        public int? masterId { get; set; }
       
        public int dearId { get; set; }
        public int? customerId { get; set; }
        public int? licenseId { get; set; }
        public int? salesInvoiceDetailId { get; set; }
        public int? salesInvoiceMasterId { get; set; }
        public int? storeId { get; set; }
        public int? exportType { get; set; }
        public int? zeroExportType { get; set; }



        public string dealerName { get; set; }
        public string itemName { get; set; }
        public string licenseNumber { get; set; }
        public string armTypeName { get; set; }
        //public DateTime invoiceDate { get; set; }
       // public decimal netTotal { get; set; }





        public int?[] itemPriceFixingId { get; set; }
        public int?[] itemSpecId { get; set; }
        public decimal?[] rate { get; set; }
        public decimal?[] tblQuantity { get; set; }
        public decimal?[] vattotal { get; set; }
        public decimal?[] taxtotal { get; set; }
        public decimal?[] cdtotal { get; set; }
        public decimal?[] sdtotal { get; set; }
        public decimal?[] attotal { get; set; }
        public decimal?[] rdtotal { get; set; }
        public decimal?[] lineTotal { get; set; }

        public decimal?[] vatPercentage { get; set; }
        public decimal?[] taxPercentage { get; set; }
        public decimal?[] cdPercentage { get; set; }
        public decimal?[] rdPercentage { get; set; }
        public decimal?[] sdPercentage { get; set; }
        public decimal?[] atPercentage { get; set; }

  
        public DateTime? invoiceDate { get; set; }
        public DateTime? paymentDate { get; set; }

        public string salesInvoiceNo { get; set; }
        public int salesVatType { get; set; }

        public decimal? grossTotal { get; set; }
        public decimal? grossVAT { get; set; }
        public decimal? grossTAX { get; set; }
        public decimal? grossSD { get; set; }
        public decimal? grossCD { get; set; }
        public decimal? grossAT { get; set; }
        public decimal? grossRD { get; set; }
        public decimal? grossDiscount { get; set; }
        public decimal? netTotal { get; set; }
        public decimal? vds { get; set; }
        //New Add
        public int salesVatTypeId { get; set; }
        public decimal? vatPercent { get; set; }
        public decimal? taxPercent { get; set; }

        //LC
        public string lcNo { get; set; }
        public DateTime? lcDate { get; set; }
        public int? countryId { get; set; }
        public Country country { get; set; }
        public string shiftTo { get; set; }


        //public IEnumerable<ItemPriceFixing> itemPriceFixings { get; set; }
        //public IEnumerable<ItemPriceFixing> itemAllPriceFixings { get; set; }

        public IEnumerable<SalesInvoiceDetail> salesInvoiceMastersDetails { get; set; }
        public IEnumerable<SalesInvoiceMaster> salesInvoiceMasters { get; set; }
        public IEnumerable<SalesReturnInvoiceMaster> salesReturnInvoiceMasters { get; set; }
        public SalesReturnInvoiceMaster salesReturnInvoiceMaster { get; set; }
        public SalesInvoiceMaster salesInvoiceMaster { get; set; }

        public IEnumerable<SalesInvoiceDetail> salesInvoiceDetails { get; set; }
        public IEnumerable<SalesReturnInvoiceDetail> salesReturnInvoiceDetails { get; set; }

        public IEnumerable<Comment> comments { get; set; }
        //public Company company { get; set; }
        //public IEnumerable<StoreAssign> storeAssigns { get; set; }
        public IEnumerable<SalesVatType> salesVatTypes { get; set; }
        public IEnumerable<Dealer> dealers { get; set; }
    }
}
