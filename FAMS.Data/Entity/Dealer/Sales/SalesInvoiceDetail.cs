using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Data.Entity.Dealer.Sales
{
    public class SalesInvoiceDetail:Base
    {
       
        public int? itemSpecificationId { get; set; }
        public ItemSpecification itemSpecification { get; set; }

        public int? salesInvoiceMasterId { get; set; }
        public SalesInvoiceMaster salesInvoiceMaster { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? quantity { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? rate { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? vatAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? taxAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? sdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? cdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? atAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? rdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? lineTotal { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? vatPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? taxPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? sdPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? cdPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? atPercentage { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? rdPercentage { get; set; }
    }
}
