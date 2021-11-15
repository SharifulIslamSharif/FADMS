using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Areas.FAMSDB.Models;
using FADMS.DAL.Organization;
using FADMS.Data.Entity;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Attachment;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System;
//using FAMSAPPLICATION.Data.Entity.Employee;
//using FAMSAPPLICATION.Data.Entity.Master;
//using FAMSAPPLICATION.Data.Entity.Training;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
//using Address = FAMSAPPLICATION.Areas.License.Models.Lang.Address;

namespace FADMS.Areas.FAMSAPP.Models
{
    [NotMapped]
    public class PersonalInfoViewModel
    {   
        public int licenseId { get; set; }
        public int personalInfoId { get; set; }
        public int organizationid { get; set; }
        public int photoPersonId { get; set; }
        public int personId { get; set; }
        public int photoid { get; set; }
        public int orgId { get; set; }
        public int organizationId { get; set; }
        public int photoId { get; set; }

        public IFormFile[] attachment { get; set; }
        public IFormFile[] formFileArray { get; set; }
        public string[] fileUrl { get; set; }

        public int? employeeId { get; set; }
        public int? religionId { get; set; }

        public string employeeCode { get; set; }
        public string isforeignGun { get; set; }
        public string partydesignation { get; set; }

        public string nationalID { get; set; }
        public string LicenseNo { get; set; }

        public string birthIdentificationNo { get; set; }

        public string govtID { get; set; }

        public string gpfNomineeName { get; set; }

        public string gpfAcNo { get; set; }

        public string nameEnglish { get; set; }

        public string nameBangla { get; set; }
        public string spouseName { get; set; }
        public string spouseOccupation { get; set; }

        public string motherNameEnglish { get; set; }

        public string motherNameBangla { get; set; }

        public string fatherNameEnglish { get; set; }

        public string fatherNameBangla { get; set; }

        public string nationality { get; set; }

        public string disability { get; set; }

        public string dateOfBirth { get; set; }
        public DateTime dob { get; set; }
        public DateTime doob { get; set; }

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

        public int? ispolitical { get; set; }
        public bool isfreedomfighter { get; set; }
        public int? occupationId { get; set; }
        public int? politicalPartyId { get; set; }

        public string party { get; set; }
        public string licenseNumber { get; set; }

        public string education { get; set; }

        public string ocupation { get; set; }

        public int? isgovtjob { get; set; }

        public string designation { get; set; }

        public string nameofservice { get; set; }

        public string organization { get; set; }

        public string anualincome { get; set; }

        public string passportNo { get; set; }

        public int licenseTypeId { get; set; }
        public string motherOccupation { get; set; }
        public string fatherOccupation { get; set; }
     
        public string age { get; set; }
        public int armTypeId { get; set; }
        public int abortedarmTypeId { get; set; }
        public string islicenseaborted { get; set; }
        public string causeofabortion { get; set; }
        public string reason { get; set; }
        public string comment { get; set; }
        public string isstamp { get; set; }
        public string isnotari { get; set; }
        public string polPosition { get; set; }
        public string jobStatus { get; set; }



        public string dualCitizenship { get; set; }
        public string previousLicenseNo { get; set; }
        public string previousArmsCode { get; set; }
        public string othersArms { get; set; }
        public string endArms { get; set; }





        public string action { get; set; }
        public IFormFile imgUrl { get; set; }

        public IEnumerable<PersonalAttachment> personalAttachments { get; set; }
        public IEnumerable<PersonalInfo> allPerson { get; set; }
        public IEnumerable<PersonalInfo> allNewPersons { get; set; }
        public IEnumerable<Occupation> occupations  { get; set; }
        public IEnumerable<Religion> religions { get; set; }
        public IEnumerable<PoliticalParty> politicalParties { get; set; }
        public PersonalInfo personalInfo { get; set; }

        public PersonalInfo GetPersonalInfo { get; set; }
        public PersonalInfo GetPersonalIn { get; set; }
        public ApplicationUser applicationUser { get; set; }
        public MenuLN fLang { get; set; }

        public AddressLN addLang { get; set; }

        public SpouseLn spoLang { get; set; }
        

        public TrainingLn trainingLN { get; set; }
        public PersonalLN PILang { get; set; }
        public OrganizationInfo organizationInfo { get; set; }
        public Photograph  photograph { get; set; }
        public ApplicationUser user  { get; set; }

        public IEnumerable<ArmType> armTypes { get; set; }
        public IEnumerable<PersonalInfoVM>  personalInfos { get; set; }
        
        public int? photographID { get; set; }
        
    }
}
