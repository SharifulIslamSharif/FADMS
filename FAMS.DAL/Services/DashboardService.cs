//using FADMS.DAL.Services.Interfaces;
//using FADMS.Data;
//using FADMS.Data.Entity.ArmsInfo;
//using FADMS.Data.Entity.DbQuery_Model;
//using FADMS.Data.Entity.LicenseInformation;
//using FADMS.Data.Entity.Master;
//using FADMS.Data.Entity.Route;
//using FADMS.Data.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FADMS.DAL.Services
//{
//    public class DashboardService : IDashboardService
//    {
//        private readonly FADMSDbContext _context;
//        public DashboardService(FADMSDbContext context)
//        {
//            _context = context;
//        }

//        //public async Task<ArmType> GetArmsTypeName()
//        //{
//        //    return await _context.ArmTypes.AsNoTracking().ToListAsync();
//        //}

//        #region ArmsDashboard
//        public async Task<int> GetTotalArms()
//        {
//            var li = await _context.LicenseInfos.Where(x => x.isDelete == null || x.isDelete != 1).Select(s => s.licenseNumber).AsNoTracking().ToListAsync();
//            var arms= await _context.gunBuyInfos.Where(x => li.Contains(x.licenseNumber)).Select(x => x.Id).CountAsync();
            
//            return arms;
//        }
//        public async Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsTypeForArmsDash()
//        {
//            return _context.armsTotalByType.FromSql($"[SP_GETTotalArmsByArmsTypeForArmsDash]");
//        }
//        public async Task<int> GetPoliticalLicenseeForArmsDash()
//        {
//            var li= await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 &&(x.isDelete==null||x.isDelete!=1)).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            return await _context.gunBuyInfos.Where(x => li.Contains(x.licenseNumber)).CountAsync();
//        }
//        public async Task<int> GetNonPoliticalLicenseeForArmsDash()
//        {
//            var li= await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 0 && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            return await _context.gunBuyInfos.Where(x => li.Contains(x.licenseNumber)).CountAsync();
//        }
//        public async Task<int> GetMaleLicenseeForArmsDash()
//        {
//            var li = await _context.LicenseInfos.Where(x => x.personalInfo.gender == "male" && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            return await _context.gunBuyInfos.Where(x => li.Contains(x.licenseNumber)).CountAsync();
//        }
//        public async Task<int> GetWomenLicenseeForArmsDash()
//        {
//            var li = await _context.LicenseInfos.Where(x => x.personalInfo.gender == "female" && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            return await _context.gunBuyInfos.Where(x => li.Contains(x.licenseNumber)).CountAsync();
//        }
//        #endregion

//        #region Dashboard
//        public async Task<int> GettotalinheritArms()
//        {
//            return await _context.LicenseInfos.Where(x => x.source == "2").Select(x => x.Id).CountAsync();
//        }

//        public async Task<IEnumerable<Thana>> GetThanasByDistrictId(int id)
//        {
//            return await _context.Thanas.Where(x => x.districtId == id).ToListAsync();
//        }

//        public async Task<IEnumerable<Thana>> GetThanasByDivisionId(int id)
//        {
//            return await _context.Thanas.Where(x => x.district.divisionId == id).ToListAsync();
//        }

//        public async Task<IEnumerable<District>> GetDistrictByDivisionId(int id)
//        {
//            return await _context.Districts.Where(x => x.divisionId == id).ToListAsync();
//        }
//        public async Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsType()
//        {
//            return _context.armsTotalByType.FromSql($"[SP_GETTotalArmsByArmsType]");
//        }
//        public async Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsTypeBy(int? divId)
//        {
//            return _context.armsTotalByType.FromSql($"sp_GetArmsTypeTotalBydivId {divId}");
//        }
//        //public async Task<int> GetTotaInspectionCount(string type,int id)
//        //{
//        //    var data = 0;
//        //     if (type=="district")
//        //    {
//        //         data = await (from i in _context.inspectionDetails
//        //                          join l in _context.LicenseInfos
//        //                          on i.licenseNumber equals l.licenseNumber
//        //                          where l.DistrictId == id
//        //                          select i.Id
//        //                          ).CountAsync();
//        //    }
//        //    else if (type=="thana")
//        //    {
//        //         data = await (from i in _context.inspectionDetails
//        //                          join l in _context.LicenseInfos
//        //                          on i.licenseNumber equals l.licenseNumber
//        //                          where l.thanaId == id
//        //                          select i.Id
//        //                         ).CountAsync();
//        //    }
//        //    else
//        //    {
//        //        data = 0;
//        //    }

           
//        //    return data;
//        //}
//        public async Task<int> GetTotaInspectionCount(string type,int id)
//        {
//            var data = 0;
//            if (type=="district")
//            {
//                 data = await (from i in _context.inspectionDetails
//                                  join l in _context.LicenseInfos
//                                  on i.licenseNumber equals l.licenseNumber
//                                  where l.DistrictId == id
                                  
//                                  select i.Id
//                                  ).CountAsync();
//            }
//            else if (type=="thana")
//            {
//                 data = await (from i in _context.inspectionDetails
//                                  join l in _context.LicenseInfos
//                                  on i.licenseNumber equals l.licenseNumber
//                               where l.thanaId == id
//                               //where l.personalInfoId == id
//                               select i.Id
//                                 ).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

           
//            return data;
//        }

//         public async Task<int> GetTotaInspectionCountAll()
//        {
//            var li = await _context.LicenseInfos.Include(x => x.organizationInfo).Include(e => e.personalInfo).Include(e => e.personalInfo).Include(e => e.thana).Include(e => e.District).Include(e => e.division).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var list = await _context.inspectionDetails.Where(s => li.Contains(s.licenseNumber)).CountAsync();
//            return list;
//        }


//         public async Task<int> GetTotalLicense()
//        {
//            return await _context.LicenseInfos.Where(x=>x.isDelete==null||x.isDelete!=1).Select(s => s.Id).CountAsync();
//        }

//        //.Where(x=>x.licenseNumber!=null)
//        public async Task<int> GetTotalGDInfoCount()
//        {
//           return await _context.crimeInfos.Select(s => s.Id).CountAsync();
//        }

//        public async Task<int> GetTotalTempSusspenCount()
//        {
           
//            return await _context.gunTempSuspendedInfos.Select(s => s.Id).CountAsync();
//        }

//        public async Task<int> GetTotalPermanentSuspendedCount()
//        {
           
//            return await _context.gunSuspendedInfos.Select(s => s.Id).CountAsync();
//        }
//        public async Task<int> GetTotalUsedGunCount()
//        {
           
//            return await _context.gunUseInfos.Select(s => s.Id).CountAsync();
//        }

//         public async Task<int> GetTotalLostGunCount()
//        {
           
//            return await _context.gunLostInfos.Select(s => s.Id).CountAsync();
//        }
//         public async Task<int> GetTotalGunTravelCount()
//        {
           
//            return await _context.guntravelinfos.Select(s => s.Id).CountAsync();
//        }

//          public async Task<int> GetTotalDipositGunCount()
//        {
           
//            return await _context.gunDepositeInfos.Where(x=>x.licenseNumber!=null && x.WithdrawlStatus != "Withdrawl").Select(s => s.Id).CountAsync();
//        }

//        //.Where(x=>x.licenseNumber!=null)


//        public async Task<int> GetTotalNonDipositGunCount()
//        {
//            var li = await _context.gunDepositeInfos.Include(x => x.organizationInfo).Include(e => e.personalInfo).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var list = await _context.gunBuyInfos.Where(x => !li.Contains(x.licenseNumber)).CountAsync();
//            return list;
//        }


//        public async Task<int> GetPoliticalLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && (x.isDelete == null || x.isDelete != 1) && (x.personalInfo.politicalPartyId !=null)).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetawamileguePoliticalLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && (x.isDelete == null || x.isDelete != 1) && x.personalInfo.politicalPartyId==6).Select(x => x.Id).CountAsync();
//        }
//         public async Task<int> GetBNPPoliticalLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && (x.isDelete == null || x.isDelete != 1) && x.personalInfo.politicalPartyId==7).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetOthersPoliticalLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && (x.isDelete == null || x.isDelete != 1) && (x.personalInfo.politicalPartyId != 6 && x.personalInfo.politicalPartyId != 7 && x.personalInfo.politicalPartyId != null)).Select(x => x.Id).CountAsync();
//        }

//        public async Task<int> GetNonPoliticalLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 0 && (x.isDelete == null || x.isDelete != 1)).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetMaleLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.gender == "male" && (x.isDelete == null || x.isDelete != 1)).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetWomenLicensee()
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.gender == "female" && (x.isDelete == null || x.isDelete != 1)).Select(x => x.Id).CountAsync();
//        }


//        public async Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsTypeByDistrictId(int? divId)
//        {
//            return _context.armsTotalByType.FromSql($"sp_GetArmsTypeTotalByDistrictId {divId}");
//        }
//        #endregion

//        #region Dashboard Api
//        public async Task<string> GetDistrictNameById(int? id)
//        {
//            return await _context.Districts.Where(x => x.Id == id).Select(s => s.districtName).FirstOrDefaultAsync();
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByLiTypeId(int? id)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyLiTypeId {id}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeId(int? id)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyArmsTypeId {id}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdAndDivId(int? id, int? divId)//division
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"[sp_GetLiDetailsbyDivAndArm] {id}, {divId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdAndDisId(int? id, int? distId)//district
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"[sp_GetLiDetailsbyDistAndArm] {id}, {distId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByDivisionId(int? id)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyDistrictId {id}");
//        }
//        public async Task<IEnumerable<string>> GetAllLicenseNumber()
//        {
//            return await _context.LicenseInfos.Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//        }
//        public async Task<IEnumerable<LicenseInfo>> GetAllLicensebyGender(string gender)
//        {
//            return await _context.LicenseInfos.Include(x => x.armType).Include(x => x.licenseType)
//                .Include(x => x.thana).Include(x => x.personalInfo).Where(x => x.personalInfo.gender == gender).AsNoTracking().ToListAsync();
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetAllLicensebyGenderWithPhoto(string gender)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.gender == gender
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            return result;
//        }
//        public async Task<IEnumerable<LicenseInfo>> GetAllLicensebyPolitical(int? ispolitical)
//        {
//            return await _context.LicenseInfos.Include(x => x.armType).Include(x => x.licenseType).Include(x => x.personalInfo.politicalParty)
//                .Include(x => x.thana).Include(x => x.personalInfo).Where(x => x.personalInfo.ispolitical == ispolitical).AsNoTracking().ToListAsync();
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetAllLicensebyPoliticalWithPhoto(int? ispolitical, int? PartyId)
//        {
//            var result = new List<LiDetailsVm>();
//            if (PartyId != 6 && PartyId != 7)
//            {
//                result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == ispolitical && p.politicalPartyId != 6 && p.politicalPartyId != 7 && p.politicalPartyId != null
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameBangla,
//                                    ArmsType = at.ArmTypeNameBn,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.nameBn,
//                                    PoliticalParty = cof.nameBn,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaNameBn,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            }
//            else
//            {
//                result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == ispolitical && p.politicalPartyId == PartyId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameBangla,
//                                    ArmsType = at.ArmTypeNameBn,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.nameBn,
//                                    PoliticalParty = cof.nameBn,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaNameBn,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            }
            
//            return result;
//        }

//        public async Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhoto(int? ispolitical, int? PartyId)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == ispolitical && p.politicalPartyId == PartyId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameBangla,
//                                    ArmsType = at.ArmTypeNameBn,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.nameBn,
//                                    PoliticalParty = cof.nameBn,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaNameBn,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();

//            return result;
//        }

//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllLicenseWithPhoto()
//        {
//            return  _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllLiDetails");
//        }
//        public async Task<IEnumerable<LicenseInfo>> GetLibyPartyId(int? partyId)
//        {
//            return await _context.LicenseInfos.Include(x => x.armType).Include(x => x.licenseType).Include(x => x.personalInfo.politicalParty)
//                .Include(x => x.thana).Include(x => x.personalInfo).Where(x => x.personalInfo.politicalPartyId == partyId).AsNoTracking().ToListAsync();
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhoto(int? partyId)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == 1 && cof.Id==partyId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameBangla,
//                                    ArmsType = at.ArmTypeNameBn,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.nameBn,
//                                    PoliticalParty = cof.nameBn,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaNameBn,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            return result;
//        }
//        public async Task<IEnumerable<ArmsInfoVM>> GetTotalLiForAllPolitical()
//        {
//            return  _context.armsInfoWithIdDashboards.FromSql($"SP_GETLiInfoByParty");
//        }
//        #endregion

//        #region Gd DashBoard      
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllGDDetailsListWithPhoto()
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetails");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllGDDetailsListWithPhotoForThana(int? thId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsForThana {thId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllGDDetailsListWithPhotoForDistrict(int? distId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsForDistrict {distId}");
//        }

//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByLiTypeId(int? id)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetGDDetailsbyLiTypeId {id}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByLiTypeIdForThana(int? id, int? thId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetGDDetailsbyLiTypeIdForThana {id}, {thId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByLiTypeIdForDistrict(int? id, int? distId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyLiTypeIdForThana {id}, {distId}");
//        }

//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByArmsTypeId(int? id)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetGDDetailsbyArmsTypeId {id}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByArmsTypeForThana(int? id, int? thId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetGDDetailsbyArmsTypeIdForThana {id}, {thId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByArmsTypeForDistrict(int? id, int? distId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetGDDetailsbyArmsTypeIdForDistrict {id}, {distId}");
//        }
//        #endregion
        
//        #region License Report 
//        public IQueryable<ArmsInfoDashboardDivDetail> GetDivisionDetailsArmsInfo(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseByDivisionId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyDistrictId {id}");
//            return record;
//        }

//        public IQueryable<ArmsInfoDashboardDivDetail> GetDistrictDetailsArmsInfo(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseThana {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetThanaDetailsArmsInfo(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicensebyThanaId {id}");
//            return record;
//        }
        
//        public IQueryable<ArmsInfoDashboardDivDetail> GetArmsTypeDetailsArmsInfo(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseByArmsTypeId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyArmsTypeId {id}");
//            return record;
//        }

//        public IQueryable<ArmsInfoDashboardDivDetail> GetLicenseTypeDetailsArmsInfo(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseByLicenseTypeId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyLiTypeId {id}");
//            return record;
//        }
        
//        public async Task<string> GetThanaNameByThanaId(int id)
//        {
//            return await _context.Thanas.Where(x => x.Id == id).Select(x => x.thanaNameBn).FirstOrDefaultAsync();
//        }
//        public async Task<string> GetDistrictNameById(int id)
//        {
//            return await _context.Districts.Where(x => x.Id == id).Select(x => x.districtNameBn).FirstOrDefaultAsync();
//        }       
//        public async Task<string> GetDivisionNameById(int id)
//        {
//            return await _context.Divisions.Where(x => x.Id == id).Select(x => x.divisionNameBn).FirstOrDefaultAsync();
//        }
//        public async Task<string> GetArmsTypeNameById(int id)
//        {
//            return await _context.ArmTypes.Where(x => x.Id == id).Select(x => x.ArmTypeNameBn).FirstOrDefaultAsync();
//        }
//        public async Task<string> GetLicenseTypeNameById(int id)
//        {
//            return await _context.LicenseTypes.Where(x => x.Id == id).Select(x => x.nameBn).FirstOrDefaultAsync();
//        }
//        #endregion

//        #region Arms Report 
        
//        public IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfoByThanaId(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfobyThanaId {id}");
//            return record;
//        }

//        public IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfoByDistrictId(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfosByDistId {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfoByDiviId(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseByDivisionId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfosbyDiviId {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfosByArmsType(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseByArmsTypeId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfosbyArmsTypeId {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfosByLicenseType(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseByLicenseTypeId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfosByLiTypeId {id}");
//            return record;
//        }
//        #endregion

//        #region GD report
//        public IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByThanaId(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfobyThanaId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsForThana {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetInspectionInfoByThanaId(int id)
//        {
//            //var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetArmsInfobyThanaId {id}");
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllInspectionDetailsForThana {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByDistrictId(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsForDistrict {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetInspectionInfoByDistrictId(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllInspectionDetailsForDistrict {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByDivisionId(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsForDivision {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetInspectionInfoByDivisionId(int id)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllInspectionDetailsForDivision {id}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByDate(string fd,string td)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsByDate {fd},{td}");
//            return record;
//        }
//        public IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByLicenseNo(string liNo)
//        {
//            var record = _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllGDDetailsByLicenseNo {liNo}");
//            return record;
//        }
//        #endregion

//        #region Gun Lost Report
//        public IQueryable<GunLostViewModel> GetGunlostInfoByThanaId(int id)
//        {
//            var record = _context.gunLostViewModels.FromSql($"sp_GetAllGunLostInfoForThana {id}");
//            return record;
//        }
//        public IQueryable<GunLostViewModel> GetGunlostInfoByDistrictId(int id)
//        {
//            var record = _context.gunLostViewModels.FromSql($"sp_GetAllGunLostInfoForDistrict {id}");
//            return record;
//        }
//        public IQueryable<GunLostViewModel> GetGunlostInfoByDivisionId(int id)
//        {
//            var record = _context.gunLostViewModels.FromSql($"sp_GetAllGunLostInfoForDivision {id}");
//            return record;
//        }
//        public IQueryable<GunLostViewModel> GetGunlostInfoByArmstype(int id)
//        {
//            var record = _context.gunLostViewModels.FromSql($"sp_GetAllGunLostInfoByArmsType {id}");
//            return record;
//        }public IQueryable<GunLostViewModel> GetGunlostInfoByLicenseType(int id)
//        {
//            var record = _context.gunLostViewModels.FromSql($"sp_GetAllGunLostInfoByLicenseType {id}");
//            return record;
//        }
//        #endregion

//        #region Gun Buy/Purchase Report
//        public IQueryable<GunBuyViewModel> GetGunPurchaseInfoByThanaId(int id)
//        {
//            var record = _context.gunBuyViewModels.FromSql($"sp_GetAllGunBuyInfoForThana {id}");
//            return record;
//        }
//        public IQueryable<GunBuyViewModel> GetGunPurchaseInfoByDistrictId(int id)
//        {
//            var record = _context.gunBuyViewModels.FromSql($"sp_GetAllGunBuyInfoForDistrict {id}");
//            return record;
//        }
//        public IQueryable<GunBuyViewModel> GetGunPurchaseInfoByDivisionId(int id)
//        {
//            var record = _context.gunBuyViewModels.FromSql($"sp_GetAllGunBuyInfoForDivision {id}");
//            return record;
//        }
//        public IQueryable<GunBuyViewModel> GetGunPurchaseInfoByArmstype(int id)
//        {
//            var record = _context.gunBuyViewModels.FromSql($"sp_GetAllGunBuyInfoByArmsType {id}");
//            return record;
//        }
//        public IQueryable<GunBuyViewModel> GetGunPurchaseInfoByLicenseType(int id)
//        {
//            var record = _context.gunBuyViewModels.FromSql($"sp_GetAllGunBuyInfoByLicenseType {id}");
//            return record;
//        }
//        #endregion

//        #region Api
//        public async Task<IEnumerable<ArmType>> GetAllArmsType()
//        {
//            return await _context.ArmTypes.ToListAsync();
//        }

//        public async Task<IEnumerable<ArmType>> GetAllArmsTypeByName()
//        {
//            return await _context.ArmTypes.ToListAsync();
//        }
//        public async Task<IEnumerable<LicenseType>> GetAllLicenseType()
//        {
//            return await _context.LicenseTypes.ToListAsync();
//        }
//        //public async Task<IEnumerable<GunBuyInfo>> GetAllLegalArms(string identiNumber)
//        //{
//        //    return await _context.gunBuyInfos.Include(x => x.armType).Include(x => x.licenseNumber)
//        //        .Include(x => x.licenseInfo).Where(x => x.gunItentificationNumber == identiNumber).AsNoTracking().ToListAsync();
//        //}
//        public async Task<LicenseInfo> GetLicenseInfoByNumber(string number)
//        {
//            return await _context.LicenseInfos.Where(x => x.licenseNumber == number).Include(x => x.personalInfo)
//                .Include(x => x.organizationInfo).Include(x => x.licenseType)
//                .Include(x => x.armType).Include(x => x.thana).Include(x => x.District).Include(x => x.division).FirstOrDefaultAsync();
//        }
       
//        //public async Task<GunLostInfo> GetLicenseInfoByGunLost(string number)
//        //{
//        //    return await _context.gunLostInfos.Where(x => x.licenseNumber == number).Include(x => x.personalInfo)
//        //        .Include(x => x.organizationInfo).Include(x => x.licenseType)
//        //        .Include(x => x.armType).Include(x => x.thana).Include(x => x.District).Include(x => x.division).FirstOrDefaultAsync();
//        //}
//        public async Task<ArmsInfoDashboardDivDetail> GetDetailsByLiNo(string number)
//        {
//            string img = String.Empty;
//            string name = String.Empty;
//            int? id = 0;
//            var li = await _context.LicenseInfos.Where(x => x.licenseNumber == number &&(x.isDelete==null||x.isDelete!=1)).FirstOrDefaultAsync();
            
//            if (li.personalInfoId > 0)
//            {
//                id = li.personalInfoId;
//                img = await _context.Photographs.Where(x => x.personalInfoId == li.personalInfoId).Select(s => s.url).FirstOrDefaultAsync();
//                name = await _context.PersonalInfos.Where(x => x.Id == li.personalInfoId).Select(s => s.nameEnglish).FirstOrDefaultAsync();
//            }
//            else if (li.organizationInfoId > 0)
//            {
//                id = li.organizationInfoId;
//                img = await _context.Photographs.Where(x => x.organizationInfoId == li.organizationInfoId).Select(s => s.url).FirstOrDefaultAsync();
//                name = await _context.organizationInfos.Where(x => x.Id == li.organizationInfoId).Select(s => s.name).FirstOrDefaultAsync();
//            }

//            return new ArmsInfoDashboardDivDetail
//            {
//                ImgUrl = img,
//                licensenumber = li.licenseNumber,
//                LiName = name,
//                ArmTypeName = await _context.ArmTypes.Where(x => x.Id == li.armTypeId).Select(x => x.ArmTypeName).FirstOrDefaultAsync(),
//                LicenseTypeId=li.licenseTypeId,
//                LicenseTypeName= await _context.LicenseTypes.Where(x=>x.Id==li.licenseTypeId).Select(x=>x.name).FirstOrDefaultAsync(),
//                districtName =await _context.Districts.Where(x=>x.Id==li.DistrictId).Select(x => x.districtName).FirstOrDefaultAsync(),
//                thanaName =await _context.Thanas.Where(x=>x.Id==li.thanaId).Select(x => x.thanaName).FirstOrDefaultAsync(),
//                reason =li.reason,
//                LiIdFor=id
//            };
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetDetailsByArmsIdentification(string number)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join g in _context.gunBuyInfos on li.licenseNumber equals g.licenseNumber
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                where g.gunItentificationNumber == number
//                                select new LiDetailsVm
//                                {
//                                    LicenseNO = li.licenseNumber,
//                                    Name = p.nameBangla,
//                                    LicenseDistrict = t.district.districtNameBn,
//                                    ArmsType = at.ArmTypeNameBn,
//                                    Reason = p.mobileNumberPersonal,
//                                    Gender = p.nationalID,
//                                    LicenseThana = t.thanaNameBn,
//                                    PoliticalParty = g.gunItentificationNumber
//                                }).AsNoTracking().ToListAsync();
//            return result;
//            //return await _context.gunBuyInfos.Where(x => x.gunItentificationNumber == number && (x.isDelete == null || x.isDelete != 1))
//            //    .Include(x => x.personalInfo)
//            //    .Include(x => x.armType)
//            //    .Include(x => x.Districts)
//            //    .Include(x => x.division)
//            //    .Include(x => x.thana)
//            //    .ToListAsync();
//        }

//        public async Task<TransctionlLiceVM> GetLicenseInfoBynum(string number)
//        {
//            var model = new TransctionlLiceVM();
//            var name = await _context.LicenseInfos.Where(x => x.licenseNumber == number).Include(x => x.personalInfo).Include(x => x.organizationInfo).FirstOrDefaultAsync();
//            if (name.organizationInfoId != null)
//            {
//                model.isOrg = 1;
//                model.id = name.organizationInfoId;
//                model.Name = name.organizationInfo.name;

//            }
//            else
//            {
//                model.isOrg = 2;
//                model.id = name.personalInfoId;
//                model.Name = name.personalInfo.nameEnglish;
//            }
//            return model;
//        }
        
//        public async Task<TransactionVM> GetLiInfoBynum(string number)
//        {
//            var model = new TransactionVM();
//            var name = await _context.LicenseInfos.Where(x => x.licenseNumber == number).Include(x => x.personalInfo).Include(x => x.organizationInfo).FirstOrDefaultAsync();
//            if (name.organizationInfoId != null)
//            {
//                model.isOrg = 1;
//                model.id = name.organizationInfoId;
//                model.Name = name.organizationInfo.name;
//                model.armsId = name.armTypeId;

//            }
//            else
//            {
//                model.isOrg = 2;
//                model.id = name.personalInfoId;
//                model.Name = name.personalInfo.nameEnglish;
//                model.armsId = name.armTypeId;
//            }
//            return model;
//        }

//        public async Task<string> checkGunInfoByLiNumber(string number)
//        {
            
//            var isValid= await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
//            if (isValid == null)
//            {
//                return "notValid";
//            }

//            var Used= await _context.gunBuyInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
//            if (Used != null)
//            {
//                return "Used";
//            }
//            return "notUsed";
//        }
//           public async Task<string> checkGunTransferInfoByLiNumber(string number)
//        {
            
//            var isValid= await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
//            if (isValid == null)
//            {
//                return "notValid";
//            }

//            var Used= await _context.gunTransferInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
//            if (Used != null)
//            {
//                return "Used";
//            }
//            return "notUsed";
//        }
//             public async Task<string> checkLegalityInfoByLiNumber(string number)
//        {
            
//            //var isValid= await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
//            //if (isValid == null)
//            //{
//            //    return "notValid";
//            //}

//            var Used= await _context.gunBuyInfos.Where(x => x.gunItentificationNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.gunItentificationNumber).FirstOrDefaultAsync();
//            if (Used == null)
//            {
//                return "Used";
//            }
//            return "notUsed";
//        }

//        public async Task<string> CheckValidLicense(string number)
//        {
//            return await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.licenseNumber).FirstOrDefaultAsync();
//        }
//        public async Task<int?> CheckValidLicenseForDistrict(string number)
//        {
//            return await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.DistrictId).FirstOrDefaultAsync();
//        }
//         public async Task<int?> CheckValidLicenseForThana(string number)
//        {
//            return await _context.LicenseInfos.Where(x => x.licenseNumber == number && (x.isDelete == null || x.isDelete != 1)).Select(x => x.thanaId).FirstOrDefaultAsync();
//        }

//        public async Task<IEnumerable<ArmsInfoDashboardDivAdvanceSearchDetail>> GetLicenseInfoAsQueryAble(string queryString)
//        {

//            IQueryable<LicenseInfo> queryData = _context.LicenseInfos;

//            #region Filtering...
//            string[] Tokens = queryString.Split("|");

//            string length = string.Empty;

//            foreach (string token in Tokens)
//            {
//                string[] SepToken = token.Split("=");
//                if (SepToken.Length > 1)
//                {
//                    if (SepToken[0] == "ApplyDistrict") { queryData = queryData.Where(x => x.place == SepToken[1]); }
//                    else if (SepToken[0] == "Division") { queryData = queryData.Where(x => x.divisionId ==Int32.Parse( SepToken[1])); }
//                    else if (SepToken[0] == "District") queryData = queryData.Where(x => x.DistrictId == Int32.Parse(SepToken[1]));
//                    else if (SepToken[0] == "Thana") queryData = queryData.Where(x => x.thanaId == Int32.Parse(SepToken[1]));
//                    else if (SepToken[0] == "LicenseType") queryData = queryData.Where(x => x.licenseTypeId == Int32.Parse(SepToken[1]));
//                    else if (SepToken[0] == "ArmsType") queryData = queryData.Where(x => x.armTypeId == Int32.Parse(SepToken[1]));
//                    else if (SepToken[0] == "Disability")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.disability == SepToken[1]).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "Gender")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.gender == SepToken[1]).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "MaritalStatus")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.maritalStatus == SepToken[1]).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "Religion")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.religionId ==Int32.Parse(SepToken[1])).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "occupation")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.occupationId ==Int32.Parse(SepToken[1])).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "BloodGroup")
//                    {
//                        if (!SepToken[1].Contains("-"))
//                        {
//                            SepToken[1] = SepToken[1] + "+";
//                        }
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.bloodGroup == SepToken[1]).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "FreedomFighter")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.freedomFighter == (SepToken[1] == "Yes" ? true : false)).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
                   
//                    else if (SepToken[0] == "ArmsModel")
//                    {
//                        List<string> GunIds = await _context.gunBuyInfos.Where(x => x.Model == SepToken[1]).AsNoTracking().Select(x => x.licenseNumber).ToListAsync();
//                        queryData = queryData.Where(x => GunIds.Contains(x.licenseNumber));
//                    }
//                    else if (SepToken[0] == "ArmsSerialNo")
//                    {
//                        List<string> GunIds = await _context.gunBuyInfos.Where(x => x.gunItentificationNumber == SepToken[1]).AsNoTracking().Select(x => x.licenseNumber).ToListAsync();
//                        queryData = queryData.Where(x => GunIds.Contains(x.licenseNumber));
//                    }                   
//                    else if (SepToken[0] == "GunBearerName")
//                    {
//                        List<string> GunIds = await _context.gunBuyInfos.Where(x => x.gunBarearName == SepToken[1]).AsNoTracking().Select(x => x.licenseNumber).ToListAsync();
//                        queryData = queryData.Where(x => GunIds.Contains(x.licenseNumber));
//                    }
//                    else if (SepToken[0] == "GunStatus")
//                    {
//                        if (SepToken[1]== "Deposite")
//                        {
//                            List<string> GunIds = await _context.gunDepositeInfos.AsNoTracking().Select(x => x.licenseNumber).ToListAsync();
//                            queryData = queryData.Where(x => GunIds.Contains(x.licenseNumber));
//                        }
//                        else
//                        {
//                            List<string> GunIds = await _context.gunWithdrawInfos.AsNoTracking().Select(x => x.licenseNumber).ToListAsync();
//                            queryData = queryData.Where(x => GunIds.Contains(x.licenseNumber));
//                        }
                        
//                    }
//                    else if (SepToken[0] == "PoliticalParty")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.politicalPartyId ==Int32.Parse(SepToken[1])).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "NID_No")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.nationalID == SepToken[1]).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "searchbyname")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.nameEnglish == SepToken[1]|| x.nameBangla == SepToken[1]).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
                       
//                    }
//                    else if (SepToken[0] == "dateOfBirth")
//                    {
//                        List<int> personalIds = await _context.PersonalInfos.Where(x => x.dateOfBirth >= DateTime.Parse(SepToken[1]) && x.dateOfBirth <= DateTime.Parse(SepToken[2])).AsNoTracking().Select(x => x.Id).ToListAsync();
//                        queryData = queryData.Where(x => personalIds.Contains((int)x.personalInfoId));
//                    }
//                    else if (SepToken[0] == "Issue_Date") { queryData = queryData.Where(x => x.dateOfIssue >= DateTime.Parse(SepToken[1]) && x.dateOfIssue <= DateTime.Parse(SepToken[2])); }
//                    else if (SepToken[0] == "Expire_Date") { queryData = queryData.Where(x => x.dateOfExpair >= DateTime.Parse(SepToken[1]) && x.dateOfExpair <= DateTime.Parse(SepToken[2])); }
                    
//                }
//            }

//            IEnumerable<LicenseInfo> data = await queryData.ToListAsync();
//            List<ArmsInfoDashboardDivAdvanceSearchDetail> filteredData = new List<ArmsInfoDashboardDivAdvanceSearchDetail>();

//            foreach (var li in data)
//            {
//                int? id = 0;
//                var img = "/EmpImages/637546079553437443.png";
//                var name = string.Empty;                
//                var phone = string.Empty;                
//                //var address = string.Empty;                
//                var nid = string.Empty;                
//                var url= string.Empty;
//                if (li.personalInfoId > 0)
//                {
//                    id = li.personalInfoId;
//                     var photo = await _context.Photographs.Where(x => x.personalInfoId == li.personalInfoId).Select(x => x.url).FirstOrDefaultAsync();
//                    if (photo != null) { img = photo; }
//                    name = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.personalInfo.nameBangla).FirstOrDefaultAsync();
//                    //address = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.division?.divisionNameBn).FirstOrDefaultAsync();
//                    phone = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.personalInfo.mobileNumberPersonal).FirstOrDefaultAsync();
//                    nid = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.personalInfo.nationalID).FirstOrDefaultAsync();
//                    url = "/FAMSAPP/PersonalInfo/Menu?id=" + li.personalInfoId  ;
//                }
//                else if(li.organizationInfoId > 0)
//                {
//                    id = li.organizationInfoId;
//                    var photo = await _context.Photographs.Where(x => x.organizationInfoId == li.organizationInfoId).Select(x => x.url).FirstOrDefaultAsync();
//                    if (photo != null) { img = photo; }
//                    name = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.organizationInfo.branchName).FirstOrDefaultAsync();
//                    //phone = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.organizationInfo.).FirstOrDefaultAsync();
//                    //nid = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.organizationInfo.nationalID).FirstOrDefaultAsync();
//                    url = "/FAMSDB/FinancialOrganization/menu/" + li.organizationInfoId;
//                }
//                var printurl = string.Empty;
//                if (li.personalInfoId > 0)
//                {
//                    id = li.personalInfoId;
//                    printurl = "/FAMSAPP/PersonalInfo/AllInformationPrintPdf/" + li.personalInfoId;
//                }
//                else if (li.organizationInfoId > 0)
//                {
//                    id = li.organizationInfoId;
//                    printurl = "/FAMSDB/FinancialOrganization/AllInformationPrintPdf/" + li.organizationInfoId;
//                }
//                //var printurl = "/FAMSDB/FinancialOrganization/menu/" + li.personalInfoId;

//                filteredData.Add(new ArmsInfoDashboardDivAdvanceSearchDetail
//                {
//                    ImgUrl = img,
//                    licensenumber = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.licenseNumber).FirstOrDefaultAsync(),
//                    LiName = name +"</br>"+ await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.District.districtNameBn).FirstOrDefaultAsync()+ "</br>" +
//                    await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.thana.thanaNameBn).FirstOrDefaultAsync(),
//                    LicenseTypeName = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.licenseType.nameBn).FirstOrDefaultAsync(),
//                    ArmTypeName = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.armType.ArmTypeNameBn).FirstOrDefaultAsync(),
//                    districtName = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.District.districtNameBn).FirstOrDefaultAsync(),
//                    thanaName = await _context.LicenseInfos.Where(x => x.Id == li.Id).Select(x => x.thana.thanaNameBn).FirstOrDefaultAsync(),
//                    LiIdFor = id,
//                    phone = phone,
//                    NID = nid,
//                    source= url,//use as menu url
//                    //editUrl = $"<a class='btn btn-info' href='"+url+ "'><i class='fa fa-edit'></i></a> &nbsp; <a class='btn btn-info' href='" + printurl + "'><i class='fa fa-print'></i></a>",
//                    editUrl = $"<a class='btn btn-info' href='" + printurl + "'><i class='fa fa-print'></i></a>",
//                    //print = $"<a class='btn btn-info' href='"+ printurl + "'><i class='fa fa-print'></i></a>"
//                });
//            }
//            #endregion

//            return filteredData;
//        }


//        #endregion
        
//        #region DC Dashboard
//        public async Task<IEnumerable<ApplicationRoute>> GetNewApplicationLicenseByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 1).Where(e => e.districtId == id).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetApprovefromDCByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 2).Where(e => e.districtId == id).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetSBInquireByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 3).Where(e => e.districtId == id).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetLicenseAganistByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 7).Where(e => e.districtId == id).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetDCConfirmeByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 9).Where(e => e.districtId == id).Include(e => e.armType).Where(e => e.armTypeId == 1 || e.armTypeId == 2).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetHomeMinistryConfirmByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 4).Where(e => e.districtId == id).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetRejectListByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 0).Where(e => e.districtId == id).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }
//        public async Task<IEnumerable<ApplicationRoute>> GetReturnfromDCListByStatus(int id)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.status == 6).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).AsNoTracking().ToListAsync();
//            return list;
//        }

//        public async Task<ApplicationRoute> GetNewApplicationLicenseById(int id, int distid)
//        {
//            var list = await _context.applicationRoutes.Where(e => e.Id == id && e.districtId == distid).Include(e => e.armType).Include(e => e.district).Include(e => e.division).Include(e => e.thana).Include(e => e.personalInfo).Include(e => e.organizationInfo).FirstOrDefaultAsync();
//            return list;
//        }

//        public async Task<int> GettotalNewLicenseApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 1).Where(e => e.districtId == id).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GettotalRejectApplication(int id)
//        {
//            var list = await _context.applicationRoutes.Where(x => x.status == 0 && x.districtId == id).Select(x => x.Id).CountAsync();
//            return list;
//        }
//        public async Task<int> GettotalApprovefromDCApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 2 && x.districtId == id).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GettotalReturnfromDCApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 2 && x.districtId == id).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetTotalSBInquireApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 3 || x.status == 9 && x.districtId == id).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetTotalAgainstApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 7 && x.districtId == id).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetTotalDCConfirmedApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 4 && x.districtId == id).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetTotalHomeMinistryConfirmedApplication(int id)
//        {
//            return await _context.applicationRoutes.Where(x => x.status == 5 && x.districtId == id).Select(x => x.Id).CountAsync();
//        }


//        #endregion

//        #region Thana user dash
//        public async Task<int> GetThanaWiseTotalLicense(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x=>x.thanaId==thId && x.isDelete!=1).Select(s => s.Id).CountAsync();
//        }
//        public async Task<IEnumerable<TotalsArmsByTypeWithId>> GetArmsTypeInfoByThanaId(int? thId)
//        {
//            return _context.armsTotalByType.FromSql($"SP_GETArmsInformationByLicenseTypeForThana {thId}");
//        }
//        public async Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsTypeForThana(int? thId)
//        {
//            return _context.armsTotalByType.FromSql($"SP_GETTotalArmsByArmsTypeForThana {thId}");
//        }
//        public async Task<int> GetPoliticalLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.thanaId== thId && x.personalInfo.politicalParty != null).Select(x => x.Id).CountAsync();
//        }

//        public async Task<int> GetOthersPoliticalLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.thanaId == thId && (x.personalInfo.politicalPartyId != 6 && x.personalInfo.politicalPartyId != 7 && x.personalInfo.politicalPartyId != null)).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetAwamiLegueLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.thanaId == thId && x.personalInfo.politicalPartyId == 6).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetBNPLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.thanaId == thId && x.personalInfo.politicalPartyId == 7).Select(x => x.Id).CountAsync();
//        }



//        public async Task<int> GetNonPoliticalLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 0 && x.thanaId == thId).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetMaleLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.gender == "male" && x.thanaId == thId).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetWomenLicenseeForThana(int? thId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.gender == "female" && x.thanaId == thId).Select(x => x.Id).CountAsync();
//        }

//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllLicenseWithPhotoForThana(int? thId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllLiDetailsForThana {thId}");
//        }
//        public IEnumerable<ArmsInfoDashboardDivDetail> GetLiDetailsByLiTypeIdForThana(int? id, int? thId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyLiTypeIdForThana {id}, {thId}");
//            //return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyLiTypeIdForThana @p1,@p2, {id}, {thId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdForThana(int? id, int? thId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyArmsTypeIdForThana {id},{thId}");
//        }
//        public async Task<IEnumerable<ArmsInfoVM>> GetTotalLiForAllPoliticalForThana(int? thanaid)
//        {
//            return _context.armsInfoWithIdDashboards.FromSql($"SP_GETLiInfoByPartyForThana {thanaid}");
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhotoForThana(int? partyId, int? thanaId)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == 1 && cof.Id == partyId && li.thanaId==thanaId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            return result;
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetAllLicensebyPoliticalWithPhotoForThana(int? ispolitical, int? thId, int? PartyId)
//        {
//            var result= new List<LiDetailsVm>();
//            if (PartyId != 6 && PartyId != 7)
//            {
//                result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == ispolitical && li.thanaId == thId && p.politicalPartyId != 6 && p.politicalPartyId != 7 && p.politicalPartyId != null
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            }
//            else
//            {
//                result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == ispolitical && li.thanaId == thId && p.politicalPartyId == PartyId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            }
           
//            return result;
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetAllLicensebyGenderWithPhotoForThana(string gender,int? thId)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.gender == gender && li.thanaId==thId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            return result;
//        }
//        #endregion

//        #region District user Dash

//        //gdTotal
//        public async Task<int> GetTotalGDInfoCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//           if (type== "district")
//            {
//                data= await _context.crimeInfos.Where(x => x.DistrictId == id && x.licenseNumber != null).Select(s => s.Id).CountAsync();
//            }
//            else if (type=="thana")
//            {
//                data= await _context.crimeInfos.Where(x => x.thanaId == id && x.licenseNumber != null).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }
//            return data;
//            //return await _context.crimeInfos.Where(x => x.DistrictId == disId && x.licenseNumber!=null).Select(s => s.Id).CountAsync();
//        }
//        //TotalTemporarySuspended
//        public async Task<int> GetTotalTempSusspenCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//            if (type=="division")
//            {
//                data = await (_context.gunTempSuspendedInfos.Where(x => x.divisionId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else if (type=="district")
//            {
//                data = await (_context.gunTempSuspendedInfos.Where(x => x.districtId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//           else if (type=="thana")
//            {
//                data = await (_context.gunTempSuspendedInfos.Where(x => x.thanaId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//            //return await _context.gunTempSuspendedCancelInfos.Where(x => x.districtId == disId && x.licenseNumber!=null).Select(s => s.Id).CountAsync();
//        }
//         //TotalPermanentSuspended
//        public async Task<int> GetTotalPermanentSuspendedCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//            if (type=="division")
//            {
//                data = await (_context.gunSuspendedInfos.Where(x => x.divisionId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else if (type=="district")
//            {
//                data = await (_context.gunSuspendedInfos.Where(x => x.districtId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//           else if (type=="thana")
//            {
//                data = await (_context.gunSuspendedInfos.Where(x => x.thanaId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//            //return await _context.gunSuspendedInfos.Where(x => x.districtId == disId && x.licenseNumber!=null).Select(s => s.Id).CountAsync();
//        }

//         //TotalUsedGun
//        public async Task<int> GetTotalUsedGunCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//            if (type=="district")
//            {
//                data = await (_context.gunUseInfos.Where(x => x.districtId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else if (type=="thana")
//            {
//                data = await (_context.gunUseInfos.Where(x => x.thanaId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//        }
//         //TotalLostGun
//        public async Task<int> GetTotalLostGunCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//             if (type=="district")
//            {
//                data = await (_context.gunLostInfos.Where(x => x.districtId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//           else if (type=="thana")
//            {
//                data = await (_context.gunLostInfos.Where(x => x.thanaId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//        }
//        //TotalDipositGun
//        public async Task<int> GetTotalDipositGunCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//             if (type=="district")
//            {
//                data = await (_context.gunDepositeInfos.Where(x => x.districtId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else if (type=="thana")
//            {
//                data = await (_context.gunDepositeInfos.Where(x => x.thanaId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//        }
//         //TotalNonDipositGun
//        public async Task<int> GetTotalNonDipositGunCountByDisDivThaId(string type,int? id)
//        {
//            var data = 0;
//            if (type=="district")
//            {
//               data= await (from gb in _context.gunBuyInfos
//                       join gd in _context.gunDepositeInfos
//                       on gb.licenseNumber equals gd.licenseNumber
//                       where gd.districtId == id
//                       select gb.Id
//                        ).CountAsync();
//            }
//           else if (type=="thana")
//            {
//              data=  await (from gb in _context.gunBuyInfos
//                       join gd in _context.gunDepositeInfos
//                       on gb.licenseNumber equals gd.licenseNumber
//                       where gd.thanaId == id
//                       select gb.Id
//                        ).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//        }

//        //public async Task<IEnumerable<GunBuyInfo>> GetGunNotDepositeInfoForDistrict(int? disId)
//        //{
//        //    var lis = await _context.LicenseInfos.Where(x => x.DistrictId == disId).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//        //    var li = await _context.gunDepositeInfos.Include(x => x.organizationInfo).Include(e => e.personalInfo).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//        //    var list = await _context.gunBuyInfos.Where(x => lis.Contains(x.licenseNumber)).Where(x => !li.Contains(x.licenseNumber)).Include(x => x.organizationInfo).Include(e => e.personalInfo).Include(e => e.licenseInfo).Include(e => e.licenseInfo.division).Include(e => e.licenseInfo.District).Include(e => e.licenseInfo.thana).AsNoTracking().ToListAsync();
//        //    return list;
//        //}
//        public async Task<int> GetGunNotDepositeInfoForDistrictTotal(int? disId)
//        {
//            var lis = await _context.LicenseInfos.Where(x => x.DistrictId == disId).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var li = await _context.gunDepositeInfos.Include(x => x.organizationInfo).Include(e => e.personalInfo).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var list = await _context.gunBuyInfos.Where(x => lis.Contains(x.licenseNumber)).Where(x => !li.Contains(x.licenseNumber)).CountAsync();
//            return list;
//        }
//         public async Task<int> GetGunNotDepositeInfoForThanaTotal(int? thId)
//        {
//            var lis = await _context.LicenseInfos.Where(x => x.thanaId == thId).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var li = await _context.gunDepositeInfos.Include(x => x.organizationInfo).Include(e => e.personalInfo).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var list = await _context.gunBuyInfos.Where(x => lis.Contains(x.licenseNumber)).Where(x => !li.Contains(x.licenseNumber)).CountAsync();
//            return list;
//        }
//           public async Task<int> GetGunTravelInfoForThanaTotal(string type, int? id)
//        {
//            var data = 0;
//            if (type == "district")
//            {
//                data = await (_context.guntravelinfos.Where(x => x.districtId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else if (type == "thana")
//            {
//                data = await (_context.guntravelinfos.Where(x => x.thanaId == id && x.licenseNumber != null)).Select(s => s.Id).CountAsync();
//            }
//            else
//            {
//                data = 0;
//            }

//            return data;
//        }

//         public async Task<int> GetGunNotDepositeInfoTotal()
//        {
//            var lis = await _context.LicenseInfos.Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var li = await _context.gunDepositeInfos.Include(x => x.organizationInfo).Include(e => e.personalInfo).Select(x => x.licenseNumber).AsNoTracking().ToListAsync();
//            var list = await _context.gunBuyInfos.Where(x => lis.Contains(x.licenseNumber)).Where(x => !li.Contains(x.licenseNumber)).CountAsync();
//            return list;
//        }



//        public async Task<int> GetDistrictWiseTotalLicense(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.DistrictId == disId && x.isDelete!=1).Select(s => s.Id).CountAsync();
//        }

//        public async Task<IEnumerable<TotalsArmsByTypeWithId>> GetArmsTypeInfoByDistId(int? disId)
//        {
//            return _context.armsTotalByType.FromSql($"SP_GETArmsInformationByLicenseTypeForDistrict {disId}");
//        }
//        public async Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsTypeForDistrict(int? disId)
//        {
//            return _context.armsTotalByType.FromSql($"SP_GETTotalArmsByArmsTypeForDistrict {disId}");
//        }
//        public async Task<int> GetPoliticalLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.DistrictId == disId && x.personalInfo.politicalParty !=null).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetOthersPoliticalLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.DistrictId == disId && (x.personalInfo.politicalPartyId != 6 && x.personalInfo.politicalPartyId != 7 && x.personalInfo.politicalPartyId != null)).Select(x => x.Id).CountAsync();
//        }


//        public async Task<int> GetAwamiLegueLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.DistrictId == disId && x.personalInfo.politicalPartyId==6).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetBNPLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 1 && x.DistrictId == disId && x.personalInfo.politicalPartyId==7).Select(x => x.Id).CountAsync();
//        }

//        public async Task<int> GetNonPoliticalLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.ispolitical == 0 && x.DistrictId == disId).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetMaleLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.gender == "male" && x.DistrictId == disId).Select(x => x.Id).CountAsync();
//        }
//        public async Task<int> GetWomenLicenseeForDistrict(int? disId)
//        {
//            return await _context.LicenseInfos.Where(x => x.personalInfo.gender == "female" && x.DistrictId == disId).Select(x => x.Id).CountAsync();
//        }

//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllLicenseWithPhotoForDistrict(int? disId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetAllLiDetailsForDistrict {disId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByLiTypeIdForDistrict(int? id, int? disId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyLiTypeIdForDistrict {id}, {disId}");
//        }
//        public async Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdForDistrict(int? id, int? disId)
//        {
//            return _context.armsInfoDashboardDivDetails.FromSql($"sp_GetLiDetailsbyArmsTypeIdForDistrict {id},{disId}");
//        }
//        public async Task<IEnumerable<ArmsInfoVM>> GetTotalLiForAllPoliticalForDistrict(int? disid)
//        {
//            return _context.armsInfoWithIdDashboards.FromSql($"SP_GETLiInfoByPartyForDistrict {disid}");
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetAllLicensebyPoliticalWithPhotoForDistrict(int? ispolitical, int? DistId,int? PartyId)
//        {
//            var result = new List<LiDetailsVm>();
//            if (PartyId !=6 && PartyId !=7)
//            {
//                result = await (from li in _context.LicenseInfos
//                                    join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                    join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                    join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                    join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                    from cof in pd.DefaultIfEmpty()
//                                    join t in _context.Districts on li.DistrictId equals t.Id
//                                    join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                    from ph in phl.DefaultIfEmpty()
//                                    where p.ispolitical == ispolitical && li.DistrictId == DistId && p.politicalPartyId != 6 && p.politicalPartyId != 7 && p.politicalPartyId != null
//                                    select new LiDetailsVm
//                                    {
//                                        personId = p.Id,
//                                        Name = p.nameEnglish,
//                                        ArmsType = at.ArmTypeName,
//                                        LicenseNO = li.licenseNumber,
//                                        LicenseType = lt.name,
//                                        PoliticalParty = cof.name,
//                                        Gender = p.gender,
//                                        ImgPath = ph.url,
//                                        LicenseThana = t.districtName,
//                                        Reason = li.reason
//                                    }).AsNoTracking().ToListAsync();
//            }
//            else
//            {
//                result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == ispolitical && li.DistrictId == DistId && p.politicalPartyId == PartyId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            }
            
//            return result;
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetAllLicensebyGenderWithPhotoForDistrict(string gender, int? DistId)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.gender == gender && li.DistrictId == DistId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            return result;
//        }
//        public async Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhotoForDistrict(int? partyId, int? DistId)
//        {
//            var result = await (from li in _context.LicenseInfos
//                                join p in _context.PersonalInfos on li.personalInfoId equals p.Id
//                                join at in _context.ArmTypes on li.armTypeId equals at.Id
//                                join lt in _context.LicenseTypes on li.licenseTypeId equals lt.Id
//                                join pp in _context.PoliticalParties on p.politicalPartyId equals pp.Id into pd
//                                from cof in pd.DefaultIfEmpty()
//                                join t in _context.Thanas on li.thanaId equals t.Id
//                                join pho in _context.Photographs on p.Id equals pho.personalInfoId into phl
//                                from ph in phl.DefaultIfEmpty()
//                                where p.ispolitical == 1 && cof.Id == partyId && li.DistrictId == DistId
//                                select new LiDetailsVm
//                                {
//                                    personId = p.Id,
//                                    Name = p.nameEnglish,
//                                    ArmsType = at.ArmTypeName,
//                                    LicenseNO = li.licenseNumber,
//                                    LicenseType = lt.name,
//                                    PoliticalParty = cof.name,
//                                    Gender = p.gender,
//                                    ImgPath = ph.url,
//                                    LicenseThana = t.thanaName,
//                                    Reason = li.reason
//                                }).AsNoTracking().ToListAsync();
//            return result;
//        }
//        #endregion
//    }
//}
