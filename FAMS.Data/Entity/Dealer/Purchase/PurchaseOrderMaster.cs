using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer.Purchase
{
    public class PurchaseOrderMaster:Base
    {
        [Column(TypeName = "nvarchar(150)")]
        public string poNo { get; set; }

        public string billOfEntryNo { get; set; }
        public string chalanNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? poDate { get; set; }
        public DateTime? paymentDate { get; set; }
       
        public int? supplierId { get; set; }
        public Supplier supplier { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public int? paymentTypeId { get; set; }
        public PaymentType paymentType { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string rfqRef { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string remarks { get; set; } // Custom House/Station

        [Column(TypeName = "nvarchar(500)")]
        public string billToLocation { get; set; }

        public int? companyId { get; set; }
        
        [Column(TypeName = "decimal(18,6)")]
        public decimal? taxPercent { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? vatPercent { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? totalAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? taxAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? vatAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? sdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? cdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? atAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? rdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? netTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? vds { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string lcNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? lcDate { get; set; }

        public int? countryId { get; set; }
        public Country country { get; set; }

        public int? purchaseType { get; set; }

        public int? isClose { get; set; }
        public int? isStockClose { get; set; }

        public int? purchaseVatTypeId { get; set; }
        public PurchaseVatType purchaseVatType { get; set; }


        public int? dealerId { get; set; }
        public Dealer dealer { get; set; }
    }
}
