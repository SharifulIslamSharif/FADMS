using FADMS.Data.Entity.Dealer;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer.Purchase
{
    public class PurchaseOrderDetail:Base
    {
        public int? purchaseId { get; set; }
        public PurchaseOrderMaster purchase { get; set; }

        public int? itemSpecificationId { get; set; }
        public ItemSpecification itemSpecification { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string description { get; set; }
        

        [Column(TypeName = "decimal(18,6)")]
        public decimal? quantity { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? rate { get; set; }

        public int? currencyId { get; set; }
        public Currency currency { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? vatPercent { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? taxPercent { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? cdPercent { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? sdPercent { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? atPercent { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? rdPercent { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? vatAmount { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? taxAmount { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? cdAmount { get; set; }

        [Column(TypeName = "decimal(18,6)")]
        public decimal? sdAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? atAmount { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? rdAmount { get; set; }
    }
}
