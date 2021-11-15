using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
using System.Linq;
using System.Threading.Tasks;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class LicenseViewModel
    {
        // public string employeeID { get; set; }
        //[Required]
        //[Display(Name = "License Id")]
        public int? licenseId { get; set; }
        
        public int licenseTypeId { get; set; }
        public int armTypeId { get; set; }
        //public int districtI { get; set; }
        //public int thanaI { get; set; }
        public string SourceName { get; set; }
        public string TransportType { get; set; }
        public string LicenseType { get; set; }

        public string licenseNumber { get; set; }
        public string licenseRenew { get; set; }
        public string licenseIssueAthority { get; set; }
        public string licenseRenewYear { get; set; }

        public string place { get; set; }
        public string reason { get; set; }
        public string Lsource { get; set; }
        public string dateOfIssue { get; set; } 
        public string dateOfExpair { get; set; }
        public LicenseLn fLang { get; set; }
        public ArmBuyInfoLn armBuyInfoLn { get; set; }

        //public LicenseInfo licenseInfos { get; set; }
        //public IEnumerable<DrivingLicense> licenses { get; set; }
        //public ArmType armType { get; set; }
        //public LicenseType licenseType { get; set; }
       // public DrivingLicense license { get; set; }
        // public IEnumerable<LicenseInfo> allLicenseInfos { get; set;}
        public int? amrUseId { get; set; }
        public string Reason { get; set; }

        public string GDNo { get; set; }
        //public int? DocumentId { get; set; }
        public string Address { get; set; }

        public int DivisionId { get; set; }
        public int DistrictId { get; set; }
        public int ThanaId { get; set; }
        public string BulletQuantity { get; set; }


       
        public ArmBuyInfoViewModel ArmBuyInfoViewModel { get; set; }
      //  public ArmBuyInfo ArmBuyInfo { get; set; }
        public ArmUseInfoViewModel ArmUseInfoViewModel { get; set; }
        //public ArmUseInfo ArmUseInfo { get; set; }
        public ArmUseInfoLn ArmUseInfoLn { get; set; }
        public BulletInfoViewModel BulletInfoViewModel { get; set; }
       // public BulletInfo bulletInfo { get; set; }
        public ArmDepositViewModel ArmDepositViewModel { get; set; }
       // public ArmDeposit armDeposit { get; set; }
        public ArmWithdrawViewModel ArmWithdrawViewModel { get; set; }
      //  public ArmWithdraw armWithdraw { get; set; }
        public ArmTransportInfoViewModel ArmTransportInfoViewModel { get; set; }
       // public ArmTransportInfo armTransport { get; set; }
        public DealerViewModel DealerViewModel { get; set; } 
     //   public Dealer dealer { get; set; }
        public CrimeInfoViewModel CrimeInfoViewModel { get; set; }
      //  public CrimeInfo crimeInfo { get; set; }
        public BulletInfoLN bulletInfoLN { get; set; }
        public ArmDepositLn armDepositLn { get; set; }
        public ArmTransportInfoLn armTransportInfoLn { get; set; }
        public ArmWithdrawLn armWithdrawLn { get; set; }
        public DealerLN dealerLN { get; set; }
        public CrimeInfoLn crimeInfoLn { get; set; }
        //public IEnumerable<ArmBuyInfo> GetarmBuyInfobylicnsespId { get; set; }
        //public IEnumerable<ArmUseInfo> GetarmUseInfolicenseId { get; set; }
        //public IEnumerable<ArmUseInfo> GetarmUseInfobylicnsespId { get; set; }
        //public IEnumerable<ArmDeposit> GetarmDepositInfobylicnsespId { get; set; }
        //public IEnumerable<DrivingLicense> licenses { get; set; }
        //public IEnumerable<ArmWithdraw> GetArmWithdrawInfolicenseId { get; set; }
        //public IEnumerable<CrimeInfo> GetCrimeInfolicenseId { get; set; }
        

        //public IEnumerable<ArmType> armTypes { get; set; }

    }
}
