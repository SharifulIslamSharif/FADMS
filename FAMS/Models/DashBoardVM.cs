using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.DbQuery_Model;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FAMSAPPLICATION.Areas.License.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FADMS.Models
{
    public class DashBoardVM
    {
        public int? TotalLicense { get; set; }
        public int? TotalApplicant { get; set; }
        public int? TotalPublic { get; set; }
        public int? TotalGuard { get; set; }
        public int? TotalDealer { get; set; }
        public int? TotalFinancialOrganization { get; set; }
        public int? TotalOrganization { get; set; }
        public int? TotalInheriteArms { get; set; }
        public int? TotalInspectionInfo { get; set; }

        public int? TotalGDInfo { get; set; }
        public int? TotalTemporarySusspen { get; set; }
        public int? TotalPermanentSusspen { get; set; }
        public int? TotalUsedGun { get; set; }
        public int? TotalLostGun { get; set; }
        public int? TotalDipositGun { get; set; }
        public int? TotalNonDipositGun { get; set; }
        public int? TotalGunTravel { get; set; }
       


        public int? politicalLilist { get; set; }
        public int? nonPoliticalLilist { get; set; }
        public int? awamileguelist { get; set; }
        public int? bnplist { get; set; }
        public int? otherslist { get; set; }
        public int? maleLilist { get; set; }
        public int? femaleLilist { get; set; }

        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Division> divisions { get; set; }
        public IEnumerable<Thana> thanas { get; set; }
        public IEnumerable<ArmType> armTypes { get; set; }
        public IEnumerable<LicenseType> licenseTypes { get; set; }
        public IEnumerable<Religion> religions { get; set; }
        public IEnumerable<Occupation> occupation { get; set; }
        public IEnumerable<PoliticalParty> politicalParties { get; set; }
        
        public IEnumerable<TotalsArmsByType> armsInfoDashboards { get; set; }
        public IEnumerable<ArmsInfoVM> armsinfoid { get; set; }
      
        public IEnumerable<TotalsArmsByTypeWithId> armsTypeInfo { get; set; }
        public IEnumerable<TotalsArmsByType> armsByDivisions { get; set; }
        public IQueryable<TotalsArmsByTypeWithId> armsByArmsType { get; set; }

        public IEnumerable<ArmsInfoToplist> armsInfoToplists { get; set; }
        public IEnumerable<ArmsInfoDashboardDivPivot> GETArmsInformationByDivisionPivot { get; set; }

     
    


    }

    
}
