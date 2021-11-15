using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class InfoViewModel
    {
        
        //public LicenseInfo LicenseInfo { get; set; }
        //public ArmBuyInfo armBuy { get; set; }
        //public IEnumerable<ArmBuyInfo> GetarmBuyInfo { get; set; }
        //public IEnumerable<ArmBuyInfo> GetarmBuyInfobylicnseId { get; set; }
        //public IEnumerable<CrimeInfo> crimeInfoslicenseId { get; set; }
        //public IEnumerable<ArmUseInfo> armUseInfoslicenseId { get; set; }
        //public IEnumerable<BulletInfo> GetBulletInfobylicenseId { get; set; }
        //public IEnumerable<ArmDeposit> GetarmDepositInfobylicenseId { get; set; }
        //public IEnumerable<ArmTransportInfo> armTransportInfos { get; set; }
        //public IEnumerable<ArmWithdraw> armWithdraws { get; set; }
        //public IEnumerable<Dealer> dealers { get; set; }
        //public EmployeeInfo employee { get; set; }
        //public Address addressPresent { get; set; }
        //public Address addressPermanent { get; set; }
        //public IEnumerable<EducationalQualification> educationalQualifications { get; set; }
        //public Spouse spouse { get; set; }
        //public IEnumerable<Children> childrens { get; set; }

        //public IEnumerable<DrivingLicense> drivingLicenses { get; set; }

        //public IEnumerable<PassportDetails> passportDetails { get; set; }

        //public IEnumerable<EmployeeMembership> employeeMemberships { get; set; }

        //public IEnumerable<EmployeeLanguage> employeeLanguages { get; set; }

        //public IEnumerable<EmployeeAward> employeeAwards { get; set; }

        //public IEnumerable<Publication> publications { get; set; }

        //public IEnumerable<TraveInfo> traveInfos { get; set; }

        //public IEnumerable<Promotion> promotions { get; set; }

        //public IEnumerable<AcrInfo> acrInfos { get; set; }

        public LicenseLn fLang { get; set; }
        public ArmBuyInfoLn armBuyInfoLn { get; set; }
        public BulletInfoLN bulletInfoLN { get; set; }
        public ArmDepositLn armDepositLn { get; set; }
        public ArmUseInfoLn ArmUseInfoLn { get; set; }
        public ArmTransportInfoLn armTransportInfoLn { get; set; }
        public ArmWithdrawLn armWithdrawLn { get; set; }
        public DealerLN dealerLN { get; set; }
        public CrimeInfoLn crimeInfoLn { get; set; }
        //public IEnumerable<ArmBuyInfo> GetarmBuyInfobylicnsespId { get; set; }
        //public IEnumerable<ArmUseInfo> GetarmUseInfolicenseId { get; set; }
        //public IEnumerable<ArmUseInfo> GetarmUseInfobylicnsespId { get; set; }
        //public IEnumerable<ArmDeposit> GetarmDepositInfobylicnsespId { get; set; }
      
        //public IEnumerable<ArmWithdraw> GetArmWithdrawInfolicenseId { get; set; }
        //public IEnumerable<CrimeInfo> GetCrimeInfolicenseId { get; set; }

    }
}
