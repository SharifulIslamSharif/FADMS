using FADMS.Data.Entity;
using FADMS.Data.Entity.Dealer;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer
{
    public class ItemHsCode : Base
    {
        [MaxLength(10)]
        public string hsCode { get; set; }
        [MaxLength(450)]
        public string hsDescription { get; set; }
        public DateTime? validFrom { get; set; }

        public int? taxYearId { get; set; }
        public TaxYear taxYear { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? CD { get; set; }
        [Column(TypeName = "decimal(18,6)")]

        public decimal? SD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? VAT { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? AIT { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? AT { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? RD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? EXD { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? TTI { get; set; }

        public int? vatCategoryId { get; set; }
        public VatCategory vatCategory { get; set; }

        public int? vatTableId { get; set; }
        public VatTable vatTable { get; set; }

        public int? vATScheduleId { get; set; }
        public VATSchedule vATSchedule { get; set; }
    }
}
