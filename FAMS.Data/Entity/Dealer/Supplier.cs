using FADMS.Data.Entity.Dealer;
using System.ComponentModel.DataAnnotations;

namespace FADMS.Data.Entity.Dealer
{
    public class Supplier : Base
    {
        [MaxLength(250)]
        public string supplierName { get; set; }
        [MaxLength(250)]
        public string supplierNameBn { get; set; }

        public string LicenseNumber { get; set; }
        public string registeredAddress { get; set; }
        public string eTinNumber { get; set; }
        public string binNumber { get; set; }

        public string VATNumber { get; set; }

        public string email { get; set; }

        public string alternativeEmail { get; set; }

        public string mobile { get; set; }

        public string phone { get; set; }

        public int? isAuthorized { get; set; }

        public int? supplierTypeId { get; set; }
        public SupplierType supplierType { get; set; }

        public int? DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
