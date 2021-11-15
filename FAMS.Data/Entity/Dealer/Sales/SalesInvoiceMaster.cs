using FADMS.Data.Entity.Dealer;
using FADMS.Data.Entity.Master;
using FADMS.Data.Entity.LicenseInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace FADMS.Data.Entity.Dealer.Sales
{
    public class SalesInvoiceMaster:Base
    {
        
        public int? licenseInfoId { get; set; }
        public LicenseInfo licenseInfo { get; set; }

        public int? dealerId { get; set; }
        public Dealer dealer { get; set; }


        public int? liInfoId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? invoiceDate { get; set; }
        public DateTime? paymentDate { get; set; }

        public string invoiceNumber { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? totalAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? VATOnTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? DiscountOnTotal { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? TAXOnTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? SDOnTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? CDOnTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? ATOnTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? RDOnTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? NetTotal { get; set; }

        public int? isClose { get; set; } //1=Paid, 0 = have Due
        public int? isStockClose { get; set; } //1 = full stock, 0 = Due
        

        [Column(TypeName = "nvarchar(150)")]
        public string lcNo { get; set; }
        public string shiftTo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? lcDate { get; set; }

        public int? countryId { get; set; }
        public Country country { get; set; }

        public int? salesType { get; set; }
        public int? exportType { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? vds { get; set; }

        public int? salesVatTypeId { get; set; }
        public SalesVatType salesVatType { get; set; }
    }
}
