using FADMS.Areas.FAMSAPP.Models.Lang;
//using FAMSAPPLICATION.Data.Entity.Employee;
//using FAMSAPPLICATION.Data.Entity.Master;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FAMSAPPLICATION.Areas.License.Models
{
    public class EmployeeInfoViewModellicenseId
    {
       
        public int licenseId { get; set; }
        
        public int? employeeId { get; set; }

        
     
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

      

      
        //[Required]
  


        public string tin { get; set; }

 

        public string bloodGroup { get; set; }

    
        public string freedomFighter { get; set; }

  
        public string freedomFighterNo { get; set; }

      
        public string telephoneOffice { get; set; }

      
        public string telephoneResidence { get; set; }


        public string pabx { get; set; }

        public string emailAddress { get; set; }

        public string mobileNumberOffice { get; set; }


        public string mobileNumberPersonal { get; set; }
      
    }
}
