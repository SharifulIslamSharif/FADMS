using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Data.Entity;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.Attachment;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Models
{
    public class GunInfoViewModel
    {
        public int? licenseInfoId { get; set; }
        public int? personalInfoTd { get; set; }
        public int? employeeId { get; set; }
        public int gunbuyId { get; set; }
        public int gunuseId { get; set; }

        public int gunStolenId { get; set; }
        public int? personalInfoId { get; set; }
        public string name { get; set; }
        public string LicenseNo { get; set; }//from licenseinfo
        public IEnumerable<string> LicenseNos { get; set; }
        public IEnumerable<LicenseInfo>  licenseInfos { get; set; }

        public IFormFile[] attachment { get; set; }
        public IFormFile[] formFileArray { get; set; }
        public string[] fileUrl { get; set; }

        public string instituteType { get; set; }
        public string branch { get; set; }
        public string generalManager { get; set; }
        public DateTime? estrabilishedDate { get; set; }
        public int? Organogram { get; set; }
        public string taxId { get; set; }
        public int? ArmTypeId { get; set; }
        public ArmType armType { get; set; }
        public string SourceofBuy { get; set; }
        public string models { get; set; }

        public string gunItentificationNo { get; set; }

        public string GunBarearName { get; set; }
        public string magazine { get; set; } 

        public string BulletQty { get; set; }
        public string BulleteType { get; set; }
        public string BulletColor { get; set; }
        public string BulleteSize { get; set; }

        public string GunuserAddress { get; set; }
        public string dealerName { get; set; }

        public string Gunproduction { get; set; }
        public string dealers { get; set; }
        public String dealerId { get; set; }
        public ApplicationUser dealer { get; set; }

        public int? carQuintity { get; set; }

        public string previousFairArms { get; set; }
        public string purpose { get; set; }
        public string cartridgeNumbers { get; set; }
        public string spot { get; set; }

        public int? certificate { get; set; }

        public int? demandArmsType { get; set; }
        public int? demandArmsQty { get; set; }

        public string presentSecuritySystem { get; set; }
        public string licenseNeed { get; set; }
        public string reason { get; set; }
        public string action { get; set; }
        public string title { get; set; }
        public int? noOfEmployee { get; set; }
        public string ownerName { get; set; }
        public int? blance { get; set; }
        public OrganizationLn fLang { get; set; }
        public MenuLN mLang { get; set; }
        public IEnumerable<ArmType> armTypes { get; set; }
       

        public IEnumerable<Address> addresses { get; set; }
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        public IEnumerable<LicenseSourseType> LicenseSourseTypes { get; set; }
      
        

        public Address address { get; set; }
        public string gunUserAddress { get; set; }
        public string gdNumber { get; set; }
        public string GdNumber { get; set; }
        public DateTime? GdDate { get; set; }
        public string place { get; set; }
        public int? districtId { get; set; }
        public int? divisionId { get; set; }
        public int? thanaId { get; set; }
        
        public string description { get; set; }
        public DateTime? date { get; set; }
        public DateTime? time { get; set; }
    }
}
