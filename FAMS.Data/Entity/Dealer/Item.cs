using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer
{
    public class Item : Base
    {
        public int? parentId { get; set; }   
        public int? isParent { get; set; }

        public int? unitId { get; set; }
        public Unit unit { get; set; }

        public int? itemHsCodeId { get; set; }
        public ItemHsCode itemHsCode { get; set; }
    
        [MaxLength(250)]
        public string itemName { get; set; }
        [MaxLength(20)]
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public int? accountLedgerId { get; set; }
        public int? reOrderLevel { get; set; }

        public int? productionTypeId { get; set; }
        public ProductionType productionType { get; set; }

        [MaxLength(250)]
        public string costingMethod { get; set; }
        [Column(TypeName = "decimal(18,6)")]
        public decimal? reorderQty { get; set; }
        public string imageUrl { get; set; }

        public int? ArmTypeId { get; set; }
        public ArmType ArmType  { get; set; }

        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
