using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Data.Entity.Dealer.Sales
{
    public class SalesReturnInvoiceDetail:Base
    {
      
        public int? salesReturnInvoiceMasterId { get; set; }
        public SalesReturnInvoiceMaster salesReturnInvoiceMaster { get; set; }

        public int? salesInvoiceDetailId { get; set; }
        public SalesInvoiceDetail salesInvoiceDetail { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? quantity { get; set; }

    }
}
