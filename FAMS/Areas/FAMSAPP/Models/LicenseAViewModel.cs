using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class LicenseAViewModel
    {
        // public string employeeID { get; set; }
        //[Required]
        //[Display(Name = "License Id")]
        public int? licenseId { get; set; }
        
        public int licenseTypeId { get; set; }
        public int armTypeId { get; set; }

        [Required]
        [Display(Name = "License Number")]
        public string licenseNumber { get; set; }

        [Required]
        [Display(Name = "Place of Issue")]
        public string place { get; set; }

        [Required]
        [Display(Name = "Place of Issue")]
        public string reason { get; set; }

        [Required]
        [Display(Name = "Place of Issue")]
        public string source { get; set; }

        [Display(Name = "Date Of Issue")]
        public string dateOfIssue { get; set; }

        [Required]
        [Display(Name = "Date Of Expair")]
        public string dateOfExpair { get; set; }

        public LicenseALn fLang { get; set; }
       // public ArmBuyInfoLn armBuyInfoLn { get; set; }
        public string Position { get; set; }
        //public LicenseInfo licenseInfos { get; set; }
        //public IEnumerable<DrivingLicense> licenses { get; set; }
        //public ArmType armType { get; set; }
        //public LicenseType licenseType { get; set; }
        //public DrivingLicense license { get; set; }
        //public IEnumerable<LicenseInfo> allLicenseInfos { get; set;}
        public int? armId { get; set; }

        //[Required]
        //public int armTypeId { get; set; }

        [Required]
        public string quantity { get; set; }

        [Required]
        public string position { get; set; }

        //[Required]
        //public string source { get; set; }
        //public ArmType armType { get; set; }
       // public ArmBuyInfo ArmBuyInfo { get; set; }

        public int depositId { get; set; }

        public string date { get; set; }

       // public string reason { get; set; }

        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }

        //public ArmDeposit armDeposit { get; set; }
        // public ArmDepositLn fLang { get; set; }
       // public int licenseId { get; set; }
        public int armTransportInfoId { get; set; }
        public string originPlace { get; set; }

        public string destinationPlace { get; set; }

        public string FromDate { get; set; }

        public string toDate { get; set; }

       // public string reason { get; set; }
        //public ArmTransportInfo armTransport { get; set; }
        public int armWithdrawId { get; set; }

       
        //public ArmWithdraw armWithdraw { get; set; }

        public int bulletId { get; set; }
       
       // public BulletInfo bulletInfo { get; set; }

        public int? crmInfoId { get; set; }
        public string Reason { get; set; }

        public string CaseNo { get; set; }

        public string Result { get; set; }


       // public CrimeInfo crimeInfo { get; set; }
        public int dealerId { get; set; }



        public string name { get; set; }

        public string licenseNo { get; set; }
       // public Dealer dealer { get; set; }

    }
}
