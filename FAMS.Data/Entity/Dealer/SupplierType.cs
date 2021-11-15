using System.ComponentModel.DataAnnotations;

namespace FADMS.Data.Entity.Dealer
{
    public class SupplierType : Base
    {
        [MaxLength(250)]
        public string supplierTypeName { get; set; }
       
    }
}
