using FADMS.Data.Entity.ArmsInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer
{
    public class ItemSpecification : Base
    {
        public int? itemId { get; set; }
        public Item  Item { get; set; }

        [MaxLength(250)]
        public string specificationName { get; set; }

        [NotMapped]
        public decimal? VAT { get; set; }

        public int? unitId { get; set; }
        public Unit unit { get; set; }

        [MaxLength(20)]
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        
        [MaxLength(250)]
        public string costingMethod { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? reorderQty { get; set; }
        public string imageUrl { get; set; }

        public int? ArmTypeId { get; set; }
        public ArmType ArmType { get; set; }

        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
