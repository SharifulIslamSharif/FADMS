using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    public class EmployeeInfoLn
    {
        [Key]
        public string licenseID { get; set; }
        public string title { get; set; }
        public string employeeID { get; set; }
        public string nationalID { get; set; }
        public string birthIdentificationNo { get; set; }
        public string govtID { get; set; }
        public string gpfNomineeName { get; set; }
        public string gpfAcNo { get; set; }
        public string name { get; set; }
        public string english { get; set; }
        public string bangla { get; set; }
        public string motherName { get; set; }
        public string fatherName { get; set; }
        public string nationality { get; set; }
        public string disability { get; set; }
        public string dateOfBirth { get; set; }
        public string gender { get; set; }
        public string birthPlace { get; set; }
        public string maritalStatus { get; set; }
        public string religion { get; set; }
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
        public string licenseNumber { get; set; }
        public string education { get; set; }
        public string ocupation { get; set; }
        public string organization { get; set; }
        public string anualincome { get; set; }
        public string ispolitical { get; set; }
        public string party { get; set; }
        public string politicaldesgination { get; set; }
        public string islocalleader { get; set; }
        public string localposition { get; set; }
        public string isgovtjob { get; set; }
        public string nameofservice { get; set; }
        public string designation { get; set; }
        public string passportNo { get; set; }
        public string doublenationality { get; set; }
        public string motherOccupation { get; set; }
        public string fatherOccupation { get; set; }
        public string spouseOccupation { get; set; }
        public string spouseName { get; set; }
        public string age { get; set; }
        public string isdutyfreearmBuy { get; set; }
        public string islicenseabort { get; set; }
        public string typeofabortedlicense { get; set; }
        public string causeofabortedlicense { get; set; }
        public string reason { get; set; }
        public string stamp { get; set; }
        public string notari { get; set; }
        public string typeofarmforlicense { get; set; }
        public string jobType { get; set; }
        public string jobIdentificationNo { get; set; }
        public string jobStatus { get; set; }
        public string action { get; set; }
      
    }
}
