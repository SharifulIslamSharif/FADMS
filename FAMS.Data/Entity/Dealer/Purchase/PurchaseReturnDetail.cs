using FADMS.Data.Entity.Dealer;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer.Purchase
{
    public class PurchaseReturnDetail : Base
    {
       
        public int? purchaseReturnMasterId { get; set; }
        public PurchaseReturnMaster purchaseReturnMaster { get; set; }

        public int? purchaseOrderDetailId { get; set; }
        public PurchaseOrderDetail purchaseOrderDetail { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? quantity { get; set; }

    }
}
