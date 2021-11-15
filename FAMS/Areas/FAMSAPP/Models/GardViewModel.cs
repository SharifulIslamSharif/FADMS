using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
//using FAMSAPPLICATION.Data.Entity.Master;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FAMSAPPLICATION.Areas.License.Models
{
    [NotMapped]
    public class GardViewModel
    {
        public int? gardId { get; set; }

        public int licenseTypeId { get; set; }

        public int? sourceId { get; set; }

        public string employeeCode { get; set; }

        public string nationalID { get; set; }

        public string birthIdentificationNo { get; set; }

        public string nameEnglish { get; set; }

        public string nameBangla { get; set; }

        public string motherNameEnglish { get; set; }

        public string motherNameBangla { get; set; }

        public string fatherNameEnglish { get; set; }

        public string fatherNameBangla { get; set; }

        public string nationality { get; set; }

        public string dateOfBirth { get; set; }

        public string gender { get; set; }

        public string birthPlace { get; set; }

        public string maritalStatus { get; set; }

        //public int religionId { get; set; }

        public string bloodGroup { get; set; }

        public string emailAddress { get; set; }

        public string mobileNumberOffice { get; set; }

        public string mobileNumberPersonal { get; set; }

        public int? trained { get; set; }

        public string experience { get; set; }

        public string age { get; set; }

        public string behaviour { get; set; }

        public string action { get; set; }

       // public IEnumerable<Gard> gards { get; set; }

        public GardLN fLang { get; set; }

        //public OrgAddress present { get; set; }

       // public OrgAddress permanent { get; set; }
       // public IEnumerable<OrggardAddress> OrggardAddresslist { get; set; }
        //public OrgAddressLN orgAddLang { get; set; }

        public TrainingLn trainingLN { get; set; }

       // public IEnumerable<TrainingCategory> trainingCategories { get; set; }

      //  public IEnumerable<TrainingInstitute> trainingInstitutes { get; set; }

      //  public IEnumerable<GardTrainingInformation> gardTrainingInformation { get; set; }
    }
}
