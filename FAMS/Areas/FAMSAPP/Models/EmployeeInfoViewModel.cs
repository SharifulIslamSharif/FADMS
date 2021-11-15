using FADMS.Areas.Auth.Models;
using FADMS.Areas.FAMSAPP.Models;
using FADMS.Areas.FAMSAPP.Models.Lang;
//using FADMS.Areas.Routing.Models;
//using FADMS.Areas.Routing.Models.Lang;
//using FADMS.Data.Entity.Employee;
using FADMS.Data.Entity.Master;
//using FADMS.Data.Entity.Routing;
//using FADMS.Data.Entity.Training;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class EmployeeInfoViewModel
    {
        public int licenseId { get; set; }
        
        public int employeeId { get; set; }
        // public EmployeeInfo EmployeeInfo { get; set; }
        public string LicenseTypeName { get; set; }
        public int status { get; set; }
        public string ArmTypeName { get; set; }

        public string employeeCode { get; set; }

        public string nationalID { get; set; }

        public string birthIdentificationNo { get; set; }

        public string govtID { get; set; }

        public string gpfNomineeName { get; set; }

        public string gpfAcNo { get; set; }

        public string nameEnglish { get; set; }

        public string nameBangla { get; set; }

        public string motherNameEnglish { get; set; }

        public string motherNameBangla { get; set; }

        public string fatherNameEnglish { get; set; }

        public string fatherNameBangla { get; set; }

        public string nationality { get; set; }

        public string disability { get; set; }

        public string dateOfBirth { get; set; }

        public string gender { get; set; }

        public string birthPlace { get; set; }

        public string maritalStatus { get; set; }

        public int? religionId { get; set; }
        //public int? status { get; set; }

        public string employeeType { get; set; }

        public string tin { get; set; }

        public string batch { get; set; }

        public string bloodGroup { get; set; }

        public string freedomFighter { get; set; }

        public string freedomFighterNo { get; set; }

        public string telephoneOffice { get; set; }

        public string telephoneResidence { get; set; }

        public string pabx { get; set; }

        public string emailAddress { get; set; }

        public string mobileNumberOffice { get; set; }

        public string mobileNumberPersonal { get; set; }

        public int? ispolitical { get; set; }

        public string party { get; set; }

        public string education { get; set; }

        public string ocupation { get; set; }

        public int? isgovtjob { get; set; }

        public string designation { get; set; }

        public string nameofservice { get; set; }

        public string organization { get; set; }

        public string anualincome { get; set; }

        public string passportNo { get; set; }
        public string motherOccupation { get; set; }
        public string fatherOccupation { get; set; }
        public string spouseOccupation { get; set; }
        public string spouseNameBangla { get; set; }
        public string age { get; set; }
        public string isdutyfreearmBuy { get; set; }
        public string islicenseabort { get; set; }
        public string typeofarmforlicense { get; set; }
        public string typeofabortedlicense { get; set; }
        public string causeofabortedlicense { get; set; }
        public string reason { get; set; }
        public string stamp { get; set; }
        public string notari { get; set; }

        public int licenseTypeId { get; set; }
  
        public int armTypeId { get; set; }
        public int abortedarmTypeId { get; set; }

        public string polPosition { get; set; }

        public string training { get; set; }
        public string liferisk { get; set; }

        public string crimereport { get; set; }
        public string allcertificateapprovedletter { get; set; }
        public string otherinfo { get; set; }
        public int sbApprovedId { get; set; }
        //public SBApproveInfo sBApproveInfo { get; set; }


        public string health { get; set; }
        public string role { get; set; }
   
        public string preservation { get; set; }

        public string jobType { get; set; }

        public string jobIdentificationNo { get; set; }

        public string jobStatus { get; set; }


        public string behave { get; set; }
        public string policreco { get; set; }
        public string megistratreco { get; set; }
        public int dbApprovedId { get; set; }
        public string comments { get; set; }
        //public DBApproveInfo dBApproveInfo { get; set; }
        public SBApproveLN sBApproveLN { get; set; }
        public DBApproveLN dBApproveLN { get; set; }
        public string action { get; set; }

        public EmployeeInfoLn fLang { get; set; }
        public LicenseLn licenseLn { get; set; }
        public TaxInfoLN taxInfoLN{ get; set; }
        //public EmployeeInfo employeeInfo { get; set; }
        //public FinancialOrganization financialOrganization { get; set; }
        //public IEnumerable<EmployeeInfo> allEmployeeInfos { get; set; }
        //public IEnumerable<LicenseInfo> allLicenseInfos { get; set; }
        //public IEnumerable<Religion> religions { get; set; }
        //public IEnumerable<EmployeeInfo> personalInfoById { get; set; }
        //public IEnumerable<Spouse> spouses { get; set; }

        public AddressLN addressLN { get; set; }
        //public Address address { get; set; }
        public CrimeInfoLn crimeInfoLn { get; set; }
        public AddressViewModel addressViewModel { get; set; }
        public DocumentViewModel documentViewModel { get; set; }
        public SpouseLn spouseLn { get; set; }
        //public Spouse spouse { get; set; }
        public SpouseViewModel spouseViewModel { get; set; }
        //public TaxInfoLN taxInfoLN { get; set; }
        public TrainingLn trainingLN { get; set; }
       // public TaxInfo taxInfo { get; set; }
        //public TaxInfoViewModel taxInfoViewModel { get; set; }
        //public Address present { get; set; }
        //public Address permanent { get; set; }
        //public Address Organization { get; set; }
        //public LicenseType licenseType { get; set; }
        //public CrimeInfo crimeInfo { get; set; }
        //public ArmType armType { get; set; }

        //public IEnumerable<TrainingCategory> trainingCategories { get; set; }

        //public AttachmentInfoAll approvalAttachments { get; set; }

        //public IEnumerable<TrainingInstitute> trainingInstitutes { get; set; }

    //    public IEnumerable<TrainingInformation> trainingInformation { get; set; }
        public IEnumerable<LicenseAppVM> armsInfoToplists { get; set; }
        public IEnumerable<LicenseAppVMM> armsInfoToplistsM { get; set; }

        public IEnumerable<LicenseAppVM> armsInfoApplists { get; set; }
        public IEnumerable<LicenseAppVMM> armsInfoApplistsM { get; set; }
       // public IEnumerable<CrimeInfo> GetCrimeInfolicenseId { get; set; }
       // public IEnumerable<TaxInfo> GetTaxInfoByEmpId { get; set; }

       // public RoutingActionViewModel routing { get; set; }
        
        //public RoutingActionVM RoutingActionVM { get; set; }
      //  public RoutingActionInformation information { get; set; }

        //public RoutingLN routingLN { get; set; }
        //public IEnumerable<RoutingPanelViewModel> routingPanels { get; set; }
        //public IEnumerable<AspNetUsersGroupViewModel> aspNetUsersGroupViewModels { get; set; }


      //  public IEnumerable<ArmType> armTypes { get; set; }

        public string activeTab { get; set; }

      //  public IEnumerable<RoutingPanelViewModel> attachments { get; set; }

      //  public IEnumerable<Document> documents { get; set; }


    }
}
