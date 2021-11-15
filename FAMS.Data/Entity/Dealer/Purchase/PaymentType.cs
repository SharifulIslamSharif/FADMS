using System.ComponentModel.DataAnnotations.Schema;

namespace FADMS.Data.Entity.Dealer.Purchase
{
    public class PaymentType:Base
    {
        [Column(TypeName = "nvarchar(150)")]
        public string paymentTypeName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string paymentTypeNameBN { get; set; }
    }
}
