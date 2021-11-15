using FADMS.Data.Entity.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FADMS.Data.Entity.LicenseInformation
{
    public class PersonalInfo:Base
    {
        //public int? licenseInfoId { get; set; }
        //public LicenseInfo licenseInfo { get; set; }

        public int? politicalPartyId { get; set; }
        public PoliticalParty politicalParty { get; set; }

        public int? occupationId { get; set; }
        public Occupation occupation { get; set; }

        public int? occupationStatusId { get; set; }
        public OccupationStatus occupationStatus { get; set; }

       

        public int? religionId { get; set; }
        public Religion religion { get; set; }

        public int? organizationInfoId { get; set; }// if guard then insert otherwiseNull
        public OrganizationInfo organizationInfo { get; set; }

        public String ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [MaxLength(50)]
        public string personalInfoCode { get; set; }

        [MaxLength(100)]
        public string nationalID { get; set; }

        [MaxLength(100)]
        public string birthIdentificationNo { get; set; }

        [MaxLength(250)]
        public string govtID { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string gpfNomineeName { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string gpfAcNo { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string nameEnglish { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string nameBangla { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string motherNameBangla { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string motherNameEn { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string fatherNameBangla { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string fatherNameEN { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string nationality { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string disability { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateOfBirth { get; set; }

        public string gender { get; set; }//Male || Female

        [Column(TypeName = "NVARCHAR(260)")]
        public string birthPlace { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string maritalStatus { get; set; }

        

        [Column(TypeName = "NVARCHAR(60)")]
        public string tin { get; set; }

        [Column(TypeName = "NVARCHAR(100)")]
        public string batch { get; set; }

        [Column(TypeName = "NVARCHAR(60)")]
        public string bloodGroup { get; set; }

        public bool freedomFighter { get; set; }

        [Column(TypeName = "NVARCHAR(160)")]
        public string freedomFighterNo { get; set; }

        [Column(TypeName = "NVARCHAR(60)")]
        public string telephoneOffice { get; set; }

        [Column(TypeName = "NVARCHAR(60)")]
        public string telephoneResidence { get; set; }

        [Column(TypeName = "NVARCHAR(60)")]
        public string pabx { get; set; }

        [Column(TypeName = "NVARCHAR(160)")]
        public string emailAddress { get; set; }

        [Column(TypeName = "NVARCHAR(60)")]
        public string mobileNumberOffice { get; set; }

        [Column(TypeName = "NVARCHAR(60)")]
        public string mobileNumberPersonal { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string education { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string designation { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string nameofservice { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string organization { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string anualincome { get; set; }

        [Column(TypeName = "NVARCHAR(260)")]
        public string passportNo { get; set; }

        public string spouseName { get; set; }
        public string spouseNameBangla { get; set; }

        public int? ispolitical { get; set; }//0=not political || 1= political
        public int? isfreedomfighter { get; set; }//0=not freedomfighter || 1= freedomfighter
        public string party { get; set; }
        public string partydesignaion { get; set; }

        public string ocupation { get; set; }

        public string motherOccupation { get; set; }
        public string fatherOccupation { get; set; }
        public string spouseOccupation { get; set; }

        public int? isgovtjob { get; set; }
        public int? licenseTypeId { get; set; }
        public string age { get; set; }
        public string isforeignGun { get; set; }
        public int? armTypeId { get; set; }
        public int? abortedarmTypeId { get; set; }
        public string islicenseaborted { get; set; }
        public string causeofabortion { get; set; }

        public string reason { get; set; }
        public string comment { get; set; }
        public string isstamp { get; set; }
        public string isnotari { get; set; } //use as isTrained yes/no
        public string polPosition { get; set; }

        public string LicenseNo { get; set; }

        public string jobType { get; set; }

        public string jobIdentificationNo { get; set; }

        public string jobStatus { get; set; }
        
        //Status
        public int personType { get; set; }// 1= Person, 2 =Ownar  ,3 = Manager, 4= gurad

        

        public string dualCitizenship { get; set; }
        public string previousLicenseNo { get; set; }
        public string previousArmsCode { get; set; }
        public string othersArms { get; set; }
        public string endArms { get; set; }

    }
}
