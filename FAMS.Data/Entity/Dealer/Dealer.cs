using FADMS.Data.Entity.Dealer;
using System;
using System.ComponentModel.DataAnnotations;

namespace FADMS.Data.Entity.Dealer
{
    public class Dealer : Base
    {
        [MaxLength(250)]
        public string dealerName { get; set; }
        [MaxLength(250)]
        public string dealerNameBn { get; set; }

        public string LicenseNumber { get; set; }
        public string registeredAddress { get; set; }
        public string eTinNumber { get; set; }
        public string binNumber { get; set; }

        public string VATNumber { get; set; }

        public string email { get; set; }

        public string alternativeEmail { get; set; }

        public string mobile { get; set; }

        public string phone { get; set; }

        public int? dealerTypeId { get; set; }
        public DealerType dealerType { get; set; }

        public String ApplicationUserId { get; set; }
        public ApplicationUser  ApplicationUser { get; set; }
        
        public int? isAuthorized { get; set; }
    }
}
