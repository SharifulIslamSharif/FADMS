using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class LicenseALn
    {
        [Key]
        public string licenseID { get; set; }
        public string title { get; set; }
        public string licenseTypeId { get; set; }
        public string licenseGunType { get; set; }
        public string licenseNumber { get; set; }
        
        public string place { get; set; }

        public string reason { get; set; }

        public string source { get; set; }

        public string dateOfIssue { get; set; }
        
        public string dateOfExpair { get; set; }

        public string armsType { get; set; }
        public string quantity { get; set; }
        public string position { get; set; }
        public string date { get; set; }

       // public string reason { get; set; }

        public string Division { get; set; }

        public string District { get; set; }

        public string Upazila { get; set; }
        //public string title { get; set; }
        //public string armsType { get; set; }
        //public string quantity { get; set; }
        //public string position { get; set; }
        //public string source { get; set; }
        public string originPlace { get; set; }

        public string destinationPlace { get; set; }

        public string FromDate { get; set; }

        public string toDate { get; set; }

        // public string reason { get; set; }

       // public string reason { get; set; }
        public string gdNo { get; set; }
        public string documentSubject { get; set; }
        public string documentDescription { get; set; }
        public string address { get; set; }
        public string thana { get; set; }
        public string bulletQuantity { get; set; }
        public string district { get; set; }
        public string division { get; set; }

        public string armNo { get; set; }
       // public string reason { get; set; }
        public string caseNo { get; set; }


        public string result { get; set; }
        public string name { get; set; }

        public string licenseNo { get; set; }

        public string dealerInfo { get; set; }

        public string dealerInfoList { get; set; }

        public string action { get; set; }
    }
}
