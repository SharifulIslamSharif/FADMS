using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  FADMS.Data.Entity.Dealer;

namespace FADMS.Data.Entity.Dealer
{
    public class Contact:Base
    {
       
        public int? supplierId { get; set; }
        public  Supplier supplier { get; set; }
        public int? dealerId { get; set; }
        public  Dealer dealer { get; set; }
        
        public string Department { get; set; }

        public string Designation { get; set; }

        public string personName { get; set; }

        public string phoneNumber { get; set; }

        public string mobileNumber { get; set; }
    }
}
