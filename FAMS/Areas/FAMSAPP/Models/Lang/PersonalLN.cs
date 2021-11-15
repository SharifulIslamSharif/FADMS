using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models.Lang
{
    [NotMapped]
    public class PersonalLN
    {
        public string title { get; set; }
        public string titledetails { get; set; }
        public string photoTitle { get; set; }
        public string NameBangla { get; set; }
        public string NameEnglish { get; set; }
        public string FathersName { get; set; }
        public string FathersOcupation { get; set; }
        public string MothersName { get; set; }
        public string MothersOcupation { get; set; }
        public string WifeHusbendName { get; set; }
        public string WifeHusbendOcupation { get; set; }
        public string nid { get; set; }
        public string dateofbirth { get; set; }
        public string age { get; set; }
        public string birthplace { get; set; }
        public string nationlatity { get; set; }
        public string gender { get; set; }
        public string religion { get; set; }
        public string dropdown { get; set; }



        public string maritalStatus { get; set; }
        public string bloodgroup { get; set; }

        public string passportNo { get; set; }
        public string batch { get; set; }
        public string isnationality { get; set; }

        public string educationalStatus { get; set; }
        public string phoneoffice { get; set; }
        public string phonehome { get; set; }

        public string mobileoffice { get; set; }
        public string mobilePersonal { get; set; }
        public string email { get; set; }
        public string ispolitical { get; set; }
        public string isgovjob { get; set; }
        public string govjobdegention { get; set; }
        public string phisicalStability { get; set; }
        public string organization { get; set; }
        public string yearlyincome { get; set; }
        public string previousrecodearms { get; set; }
        public string previousrecodelicense { get; set; }
        public string reason { get; set; }
        public string armstype { get; set; }
        public string anotherarms { get; set; }
        public string armshended { get; set; }
        public string yes { get; set; }
        public string no { get; set; }
        public string bangladeshi { get; set; }
        public string foreigner { get; set; }
        public string men { get; set; }
        public string women { get; set; }
        public string gother { get; set; }
        public string Islam { get; set; }
        public string Hindu { get; set; }
        public string Boddo { get; set; }
        public string Khristan { get; set; }
        public string rother { get; set; }
        public string pstol { get; set; }
        public string revolber { get; set; }
        public string eknola { get; set; }
        public string duenola { get; set; }
        public string shortgun { get; set; }
        public string Married { get; set; }
        public string Unmarried { get; set; }
        public string Ocupation { get; set; }
        public string Teamname { get; set; }
        public string PartyDesignation { get; set; }
      
    
       






        public string mobileOffice { get; set; }
      
        public string politicalRelation { get; set; }


        public string address { get; set; }
        public string addressTitle { get; set; }
        public string presentAddress { get; set; }
        public string permanentAddress { get; set; }
       
        public string houseNo { get; set; }
        public string block { get; set; }
        public string postCode { get; set; }
        public string postOffice { get; set; }
        public string division { get; set; }
        public string district { get; set; }
        public string thana { get; set; }
        public string union { get; set; }
        public string licenseNo { get; set; }
        public string licenseIssue { get; set; }
        public string qrCode { get; set; }
       


    }
}
