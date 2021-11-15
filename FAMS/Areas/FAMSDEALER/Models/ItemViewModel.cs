using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Dealer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSDEALER.Models
{
    public class ItemViewModel
    {
        public int? itemId { get; set; }
        public int? parentId { get; set; }
        public int? isParent { get; set; }

        public int? unitId { get; set; }
        public string itemName { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public int? accountLedgerId { get; set; }
        public int? itemHsCodeId { get; set; }
        public int? reOrderLevel { get; set; }
        public int? productionTypeId { get; set; }
        public string costingMethod { get; set; }//use as item model
        public decimal? reorderQty { get; set; }
        public string imageUrl { get; set; }

        public int? itemSpecificationId { get; set; }
        public string itemspecification { get; set; }
        public int? armsTypeId { get; set; }
        public decimal? VAT { get; set; }

        public string[] itemSpecificationName { get; set; }
        public int?[] specificationCategoryId { get; set; }
        public string[] CategoryValue { get; set; }

        public IEnumerable<ArmType> armTypes { get; set; }

        //public ItemLn fLang { get; set; }
        public IEnumerable<Item> items { get; set; }
        public IEnumerable<ItemSpecification>  itemSpecifications { get; set; }
        public IEnumerable<Unit> units { get; set; }
        public IEnumerable<SpecificationCategory> specificationCategories { get; set; }
        //public string[] speclist { get; set; }
        // public ItemCodeViewModel itemCodeViewModel { get; set; }



        public int? Id { get; set; }
        public string specificationName { get; set; }
        public string specificationCategoryName { get; set; }
        public string value { get; set; }
    }
}
