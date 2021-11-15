//using FADMS.Data.Entity.ArmsInfo;
//using FADMS.Data.Entity.DbQuery_Model;
//using FADMS.Data.Entity.LicenseInformation;
//using FADMS.Data.Entity.Master;
//using FADMS.Data.Entity.Route;
//using FADMS.Data.Models;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace FADMS.DAL.Services.Interfaces
//{
//    public interface IDashboardService
//    {
//        Task<string> checkLegalityInfoByLiNumber(string number);
//        Task<string> checkGunTransferInfoByLiNumber(string number);
//        Task<IEnumerable<GunBuyInfo>> GetAllLegalArms(string identiNumber);
//        Task<IEnumerable<ArmType>> GetAllArmsTypeByName();
//        Task<int> GetGunTravelInfoForThanaTotal(string type, int? id);
//        Task<int?> CheckValidLicenseForDistrict(string number);
//        Task<int> GetAwamiLegueLicenseeForDistrict(int? disId);
//        Task<int> GetBNPLicenseeForDistrict(int? disId);
//        Task<int> GetOthersPoliticalLicenseeForDistrict(int? disId);
//        Task<int> GetTotaInspectionCount(string type, int id);
//        Task<string> CheckUniqueLiByLiNumber(string lino);
//        Task<IEnumerable<LiDetailsVm>> GetDetailsByArmsIdentification(string number);

//        Task<int> GetTotalGDInfoCount();
//        Task<int> GetTotaInspectionCountAll();
//        Task<int> GetTotalTempSusspenCount();
//        Task<int> GetTotalPermanentSuspendedCount();
//        Task<int> GetTotalUsedGunCount();
//        Task<int> GetTotalLostGunCount();
//        Task<int> GetTotalDipositGunCount();
//        Task<int> GetTotalNonDipositGunCount();


//        Task<int> GetGunNotDepositeInfoForDistrictTotal(int? disId);
//        Task<int> GetGunNotDepositeInfoTotal();
//        Task<int> GetGunNotDepositeInfoForThanaTotal(int? thId);



//        Task<int> GetTotalTempSusspenCountByDisDivThaId(string type, int? id);
//        Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhoto(int? ispolitical, int? PartyId);

//        Task<int> GetTotalGDInfoCountByDisDivThaId(string type, int? id);
//        Task<int> GetTotalPermanentSuspendedCountByDisDivThaId(string type, int? id);
//        Task<int> GetTotalUsedGunCountByDisDivThaId(string type, int? id);
//        Task<int> GetTotalLostGunCountByDisDivThaId(string type, int? id);
//        Task<int> GetTotalDipositGunCountByDisDivThaId(string type, int? id);
//        Task<int> GetTotalNonDipositGunCountByDisDivThaId(string type, int? id);

//        IQueryable<ArmsInfoDashboardDivDetail> GetInspectionInfoByThanaId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetInspectionInfoByDistrictId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetInspectionInfoByDivisionId(int id);

//        #region Arms Dashboard
//        Task<int> GetTotalArms();
//        Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsTypeForArmsDash();
//        Task<int> GetPoliticalLicenseeForArmsDash();
//        Task<int> GetNonPoliticalLicenseeForArmsDash();
//        Task<int> GetMaleLicenseeForArmsDash();
//        Task<int> GetWomenLicenseeForArmsDash();
//        #endregion

//        #region Dashboard

//        Task<int> GettotalinheritArms();
//        Task<IEnumerable<Thana>> GetThanasByDistrictId(int id);
//        Task<IEnumerable<Thana>> GetThanasByDivisionId(int id);
//        Task<IEnumerable<District>> GetDistrictByDivisionId(int id);
//        Task<TransctionlLiceVM> GetLicenseInfoBynum(string number);
//        Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsType();
//        Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsTypeBy(int? divId);
//        Task<int> GetTotalLicense();
//        Task<int> GetPoliticalLicensee();
//        Task<int> GetNonPoliticalLicensee();
//        Task<int> GetWomenLicensee();
//        Task<int> GetMaleLicensee();

//        Task<int> GetBNPPoliticalLicensee();
//        Task<int> GetOthersPoliticalLicensee();

//        Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsTypeByDistrictId(int? divId);

//        Task<int> GetawamileguePoliticalLicensee();
//        #endregion

//        #region Dashboard Api
//        Task<string> GetDistrictNameById(int? id);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByLiTypeId(int? id);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeId(int? id);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByDivisionId(int? id);

//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdAndDivId(int? id, int? divId);//division
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdAndDisId(int? id, int? distId);//district
//        Task<IEnumerable<string>> GetAllLicenseNumber();
//        Task<IEnumerable<LicenseInfo>> GetAllLicensebyGender(string gender);
//        Task<IEnumerable<LiDetailsVm>> GetAllLicensebyGenderWithPhoto(string gender);
//        Task<IEnumerable<LicenseInfo>> GetAllLicensebyPolitical(int? ispolitical);
//        Task<IEnumerable<LicenseInfo>> GetLibyPartyId(int? partyId);
//        Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhoto(int? partyId);
//        Task<IEnumerable<LiDetailsVm>> GetAllLicensebyPoliticalWithPhoto(int? ispolitical, int? PartyId);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllLicenseWithPhoto();
//        Task<IEnumerable<ArmsInfoVM>> GetTotalLiForAllPolitical();
//        #endregion

//        #region GD Dash
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllGDDetailsListWithPhoto();
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllGDDetailsListWithPhotoForThana(int? thId);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllGDDetailsListWithPhotoForDistrict(int? distId);

//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByLiTypeId(int? id);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByLiTypeIdForThana(int? id, int? thId);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByLiTypeIdForDistrict(int? id, int? distId);

//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByArmsTypeId(int? id);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByArmsTypeForThana(int? id, int? thId);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetGDDetailsByArmsTypeForDistrict(int? id, int? distId);
      
//        #endregion

//        #region Thana dash Api
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdForThana(int? id, int? thId);
//        #endregion
       
//        #region District dash Api
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByArmsTypeIdForDistrict(int? id, int? disId);
//        Task<IEnumerable<ArmsInfoVM>> GetTotalLiForAllPoliticalForDistrict(int? disid);
//        Task<IEnumerable<LiDetailsVm>> GetAllLicensebyPoliticalWithPhotoForDistrict(int? ispolitical, int? DistId,int? PartyId);
//        Task<IEnumerable<LiDetailsVm>> GetAllLicensebyGenderWithPhotoForDistrict(string gender, int? DistId);
//        Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhotoForDistrict(int? partyId, int? DistId);
//        #endregion
      
//        #region Report
//        IQueryable<ArmsInfoDashboardDivDetail> GetDistrictDetailsArmsInfo(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetThanaDetailsArmsInfo(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetDivisionDetailsArmsInfo(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetArmsTypeDetailsArmsInfo(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetLicenseTypeDetailsArmsInfo(int id);
//        Task<string> GetThanaNameByThanaId(int id);
//         Task<string> GetDistrictNameById(int id);
//         Task<string> GetDivisionNameById(int id);
//         Task<string> GetArmsTypeNameById(int id);
//         Task<string> GetLicenseTypeNameById(int id);
//        #endregion

//        #region Arms Report
//        IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfoByThanaId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfoByDistrictId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfoByDiviId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfosByArmsType(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetArmsInfosByLicenseType(int id);
//        #endregion

//        #region GD Report
//        IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByThanaId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByDistrictId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByDivisionId(int id);
//        IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByDate(string fd, string td);
//        IQueryable<ArmsInfoDashboardDivDetail> GetGDInfoByLicenseNo(string liNo);
//        #endregion

//        #region Gun Lost Report
//        IQueryable<GunLostViewModel> GetGunlostInfoByThanaId(int id);
//        IQueryable<GunLostViewModel> GetGunlostInfoByDistrictId(int id);
//        IQueryable<GunLostViewModel> GetGunlostInfoByDivisionId(int id);
//        IQueryable<GunLostViewModel> GetGunlostInfoByArmstype(int id);
//        IQueryable<GunLostViewModel> GetGunlostInfoByLicenseType(int id);
//        #endregion

//        #region Gun Lost Report
//        IQueryable<GunBuyViewModel> GetGunPurchaseInfoByThanaId(int id);
//        IQueryable<GunBuyViewModel> GetGunPurchaseInfoByDistrictId(int id);
//        IQueryable<GunBuyViewModel> GetGunPurchaseInfoByDivisionId(int id);
//        IQueryable<GunBuyViewModel> GetGunPurchaseInfoByArmstype(int id);
//        IQueryable<GunBuyViewModel> GetGunPurchaseInfoByLicenseType(int id);
//        #endregion

//        #region DC Dashboard
//        Task<IEnumerable<ApplicationRoute>> GetNewApplicationLicenseByStatus(int id);
//        Task<IEnumerable<ApplicationRoute>> GetApprovefromDCByStatus(int id);
//        Task<IEnumerable<ApplicationRoute>> GetSBInquireByStatus(int id);
//        Task<IEnumerable<ApplicationRoute>> GetDCConfirmeByStatus(int id);
//        Task<IEnumerable<ApplicationRoute>> GetHomeMinistryConfirmByStatus(int id);
//        Task<IEnumerable<ApplicationRoute>> GetRejectListByStatus(int id);
//        Task<IEnumerable<ApplicationRoute>> GetLicenseAganistByStatus(int id);

//        Task<int> GettotalNewLicenseApplication(int id);
//        Task<int> GettotalRejectApplication(int id);
//        Task<int> GettotalApprovefromDCApplication(int id);
//        Task<int> GettotalReturnfromDCApplication(int id);
//        Task<int> GetTotalSBInquireApplication(int id);
//        Task<int> GetTotalDCConfirmedApplication(int id);
//        Task<int> GetTotalHomeMinistryConfirmedApplication(int id);
//        Task<int> GetTotalAgainstApplication(int id);

//        Task<ApplicationRoute> GetNewApplicationLicenseById(int id, int distid);
//        #endregion

//        #region thana user dash
//        Task<int> GetThanaWiseTotalLicense(int? thId);
//        Task<IEnumerable<TotalsArmsByTypeWithId>> GetArmsTypeInfoByThanaId(int? thId);
//        Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsTypeForThana(int? thId);
//        Task<int> GetPoliticalLicenseeForThana(int? thId);
//        Task<int> GetNonPoliticalLicenseeForThana(int? thId);
//        Task<int> GetMaleLicenseeForThana(int? thId);
//        Task<int> GetWomenLicenseeForThana(int? thId);
//        //Task<IEnumerable<ArmsInfoDashboardDivDetail>> GetLicenseInfoAsQueryAble(string queryString);
//        Task<IEnumerable<ArmsInfoDashboardDivAdvanceSearchDetail>> GetLicenseInfoAsQueryAble(string queryString);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllLicenseWithPhotoForThana(int? thId);
//        //Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByLiTypeIdForThana(int? id, int? thId);
//        IEnumerable<ArmsInfoDashboardDivDetail> GetLiDetailsByLiTypeIdForThana(int? id, int? thId);

//        Task<IEnumerable<ArmsInfoVM>> GetTotalLiForAllPoliticalForThana(int? thanaid);
//        Task<IEnumerable<LiDetailsVm>> GetLibyPartyIdWithPhotoForThana(int? partyId, int? thanaId);
//        Task<IEnumerable<LiDetailsVm>> GetAllLicensebyPoliticalWithPhotoForThana(int? ispolitical, int? thId, int? PartyId);
//        Task<IEnumerable<LiDetailsVm>> GetAllLicensebyGenderWithPhotoForThana(string gender, int? thId);

//        Task<int> GetOthersPoliticalLicenseeForThana(int? thId);
//        Task<int> GetAwamiLegueLicenseeForThana(int? thId);
//        Task<int> GetBNPLicenseeForThana(int? thId);

//        #endregion

//        Task<int> GetTotalGunTravelCount();
//        #region District user dash
//        Task<int> GetDistrictWiseTotalLicense(int? disId);
//        Task<IEnumerable<TotalsArmsByTypeWithId>> GetArmsTypeInfoByDistId(int? disId);
//        Task<IQueryable<TotalsArmsByTypeWithId>> GetTotalArmsByArmsTypeForDistrict(int? disId);
//        Task<int> GetPoliticalLicenseeForDistrict(int? disId);
//        Task<int> GetNonPoliticalLicenseeForDistrict(int? disId);
//        Task<int> GetMaleLicenseeForDistrict(int? disId);
//        Task<int> GetWomenLicenseeForDistrict(int? disId);

//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetAllLicenseWithPhotoForDistrict(int? disId);
//        Task<IQueryable<ArmsInfoDashboardDivDetail>> GetLiDetailsByLiTypeIdForDistrict(int? id, int? disId);
//        #endregion

//        #region Api
//        Task<IEnumerable<ArmType>> GetAllArmsType();
//        Task<IEnumerable<LicenseType>> GetAllLicenseType();
//        Task<LicenseInfo> GetLicenseInfoByNumber(string number);
//        //Task<GunLostInfo> GetLicenseInfoByGunLost(string number);
//        Task<ArmsInfoDashboardDivDetail> GetDetailsByLiNo(string number);
//        Task<int?> CheckValidLicenseForThana(string number);

//        Task<string> CheckValidLicense(string number);
//        Task<TransactionVM> GetLiInfoBynum(string number);
//        Task<string> checkGunInfoByLiNumber(string number);
//        #endregion

//    }
//}
