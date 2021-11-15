using System.ComponentModel.DataAnnotations;

namespace FADMS.Data.Entity.Dealer
{
    public class DealerType : Base
    {
        [MaxLength(250)]
        public string dealerTypeName { get; set; }
       
    }
}
