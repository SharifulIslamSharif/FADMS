using System.ComponentModel.DataAnnotations.Schema;
namespace FADMS.Data.Entity.Dealer
{
    public class ProductionType:Base
    {
        [Column(TypeName = "nvarchar(100)")]
        public string productionTypeName { get; set; }
        public int? shortOrder { get; set; }
    }
}
