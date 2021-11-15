using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FADMS.DAL.AuthService.Interfaces;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FADMS.Data.Models;
using FADMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using static System.Collections.Specialized.BitVector32;

namespace FADMS.Controllers
{
	[Authorize]
	public class HomeController : Controller
	{
        private FADMSDbContext _db;
        private readonly IRepository<Division> _division;
        private readonly IRepository<District> _district;
        private readonly IRepository<Thana> _thana;
        private readonly IRepository<Religion> _religion;
        private readonly IRepository<ArmType> _armType;
        private readonly IRepository<Occupation> _occupation;
        private readonly IRepository<LicenseType> _licenseType;
        private readonly IRepository<PoliticalParty> _politicalParty;    
        private readonly IAddressService addressService;
        //private readonly IDashboardService dashboardService;
        private readonly IUserInfoes  userInfoes;   
        public HomeController(IHostingEnvironment hostingEnvironment,
            IRepository<Division> division,
            IRepository<District> district,
            IRepository<Thana> thana,
            IRepository<Religion> religion,
            IRepository<ArmType> armType,
            IRepository<Occupation> occupation,
            IRepository<LicenseType> licenseType,
            IRepository<PoliticalParty> politicalParty,

            FADMSDbContext db, IAddressService addressService, /*IDashboardService dashboardService,*/ IUserInfoes userInfoes)
            {
                _db = db;
                _division = division;
                _district = district;
                _thana = thana;
                _religion = religion;
                _armType = armType;
                _occupation = occupation;
                _licenseType = licenseType;
                _politicalParty = politicalParty;

                this.addressService = addressService;
                //this.dashboardService = dashboardService;
                this.userInfoes = userInfoes;
         
        }
       
		public async Task<IActionResult> Index()
        {
            
            var model = new DashBoardVM();
            var userRole = await userInfoes.GetUserRoleByUserName(User.Identity.Name);
            var userRoleId = await userInfoes.GetUserRoleIdByUserName(User.Identity.Name);
            //var armTypes = await dashboardService.GetAllArmsTypeByName();
            //ViewBag.name = armTypes.FirstOrDefault().ArmTypeNameBn;
            //General User
            if (userRoleId == "1d9b6cf4-f90b-4fcc-8849-214fba86b7de")
            {
                var user = await userInfoes.GetUserInfoByUser(User.Identity.Name);
                if (user.userType.userTypeName == "Personal")
                {
                    int id = await userInfoes.GetPersonalIdByUserId(user.Id);
                    if (id != 0)
                    {
                        return RedirectToAction("PersonalMenu", "MenuforPersonal", new { @id = id, area = "FAMSDB" });
                    }
                    else
                    {
                        return RedirectToAction("TermsandConditions", "TermsandConditon", new { Areas = "Auth" });
                    }
                }
                else if (user.userType.userTypeName == "Organization")
                {
                    int id = await userInfoes.GetOrganizationIdByUserId(user.Id);
                    if (id != 0)
                    {
                        return RedirectToAction("MenuOrg", "MenuforOrg", new { @id = id, area = "FAMSDB" });
                    }
                    else
                    {
                        return RedirectToAction("TermsandConditions", "TermsandConditon", new { Areas = "Auth" });
                    }

                }
                else if (user.userType.userTypeName == "FinancialOrganization")
                {
                    int id = await userInfoes.GetOrganizationIdByUserId(user.Id);
                    if (id != 0)
                    {
                        return RedirectToAction("MenuOrg", "MenuforOrg", new { @id = id, area = "FAMSDB" });
                    }
                    else
                    {
                        return RedirectToAction("TermsandConditions", "TermsandConditon", new { Areas = "Auth" });
                    }
                }
            }
            //Dealer
            else if (userRoleId == "9ae09ccf-6fd3-4b36-aabb-95324e13485c")
            {
                return RedirectToAction("IndividualDash", "Dashboard", new { area = "FAMSDEALER" });
            }  
            //Dealer User
            else if (userRoleId == "5774a0e1-f858-4d82-a29a-5b9b0e003afc")
            {
                return RedirectToAction("IndividualDash", "Dashboard", new { area = "FAMSDEALER" });
            }
            //Shooting Club 
            else if (userRoleId == "9f7d3444-a94e-4634-8b44-5bdcf6b31ada")
            {
                return RedirectToAction("ShooterMemberInfo", "ShootingClubInfo", new { area = "SHOOTINGCLUB" });
            }
            //SbAdmin
            else if (userRoleId == "a3b6f86f-f910-4387-b579-041e4b8a1792")
            {
                ViewBag.UserType = "1";
                model.divisions = _division.GetAll(); 
                model.districts = _district.GetAll(); 
                model.thanas = _thana.GetAll(); 
                model.religions = _religion.GetAll(); 
                model.armTypes = _armType.GetAll(); 
                model.occupation = _occupation.GetAll(); 
                model.licenseTypes = _licenseType.GetAll(); 
                model.politicalParties = _politicalParty.GetAll();

                //model.TotalLicense = await dashboardService.GetTotalLicense(); 
                model.armsinfoid = _db.armsInfoWithIdDashboards.FromSql($"SP_GETArmsInformationByDivision");
                model.armsTypeInfo = _db.armsTotalByType.FromSql($"SP_GETArmsInformationByLicenseType");
                model.armsByDivisions = _db.armsInfoDashboards.FromSql($"SP_GETArmsInformationByDivision");
                //model.TotalInheriteArms = await dashboardService.GettotalinheritArms();
                //model.armsByArmsType = await dashboardService.GetTotalArmsByArmsType();
                
                //model.TotalGDInfo = await dashboardService.GetTotalGDInfoCount();
                //model.TotalTemporarySusspen = await dashboardService.GetTotalTempSusspenCount();
                //model.TotalPermanentSusspen = await dashboardService.GetTotalPermanentSuspendedCount();
                //model.TotalUsedGun = await dashboardService.GetTotalUsedGunCount();
                //model.TotalLostGun = await dashboardService.GetTotalLostGunCount();
                //model.TotalGunTravel = await dashboardService.GetTotalGunTravelCount();
                //model.TotalDipositGun = await dashboardService.GetTotalDipositGunCount();
                //model.TotalNonDipositGun = await dashboardService.GetTotalNonDipositGunCount();
                //model.TotalInspectionInfo = await dashboardService.GetTotaInspectionCountAll();



                //model.politicalLilist = await dashboardService.GetPoliticalLicensee();
                //model.bnplist = await dashboardService.GetBNPPoliticalLicensee();
                //model.awamileguelist = await dashboardService.GetawamileguePoliticalLicensee();
                //model.otherslist = await dashboardService.GetOthersPoliticalLicensee();

                //model.nonPoliticalLilist = await dashboardService.GetNonPoliticalLicensee();
                //model.maleLilist = await dashboardService.GetMaleLicensee();
                //model.femaleLilist = await dashboardService.GetWomenLicensee();
                return View(model);
                //return RedirectToAction("Dashboard", "SpecialBrach", new { area = "FAMSDB" });
            }
            //DCAdmin
            else if (userRoleId == "ff3a9674-52d2-49ab-8250-9a372c66c464")
            {
                return RedirectToAction("Dashboard", "DistrictCommissioner", new { area = "FAMSDB" });
            }
            //Home Ministry
            else if (userRoleId == "9f76d74e-789b-4084-b5f4-fe882cc48c10")
            {
                return RedirectToAction("Dashboard", "HomeMinistry", new { area = "FAMSDB" });
            }
            //DistrictSbAdmin
            else if (userRoleId == "809f6aac-93dc-4407-a1f2-93be4f8f01f0")
            {
                return RedirectToAction("DistrictDashboard", "License", new { area = "FAMSAPP" });
            }
            //thana user
            else if (userRoleId == "95f288f0-a648-445a-8eb9-7c734257fab5") 
            {
                return RedirectToAction("ThanaDashboard", "License", new { area = "FAMSAPP" });
            }
            //Admin
            else if (userRoleId == "04AED4C4-EF8F-4704-9EC5-0B38CAAACBEB") 
            {
                ViewBag.UserType = "1";
                model.divisions = _division.GetAll();
                model.districts = _district.GetAll();
                model.thanas = _thana.GetAll();
                model.religions = _religion.GetAll();
                model.armTypes = _armType.GetAll();
                model.licenseTypes = _licenseType.GetAll();
                model.politicalParties = _politicalParty.GetAll();

                //model.TotalLicense = await dashboardService.GetTotalLicense();
                model.armsinfoid = _db.armsInfoWithIdDashboards.FromSql($"SP_GETArmsInformationByDivision");
                model.armsTypeInfo = _db.armsTotalByType.FromSql($"SP_GETArmsInformationByLicenseType");
                model.armsByDivisions = _db.armsInfoDashboards.FromSql($"SP_GETArmsInformationByDivision");
                //model.TotalInheriteArms = await dashboardService.GettotalinheritArms();
                //model.armsByArmsType = await dashboardService.GetTotalArmsByArmsType();
                //model.politicalLilist = await dashboardService.GetPoliticalLicensee();
                //model.nonPoliticalLilist = await dashboardService.GetNonPoliticalLicensee();
                //model.maleLilist = await dashboardService.GetMaleLicensee();
                //model.femaleLilist = await dashboardService.GetWomenLicensee();
                return View(model);
            }
            
            else
            {
                //ViewBag.UserType = "1";
                model.divisions = _division.GetAll();
                model.districts = _district.GetAll();
                model.thanas = _thana.GetAll();
                model.religions = _religion.GetAll();
                model.armTypes = _armType.GetAll();
                model.licenseTypes = _licenseType.GetAll();
                model.politicalParties = _politicalParty.GetAll();

                //model.TotalLicense = await dashboardService.GetTotalLicense();
                model.armsinfoid = _db.armsInfoWithIdDashboards.FromSql($"SP_GETArmsInformationByDivision");
                model.armsTypeInfo = _db.armsTotalByType.FromSql($"SP_GETArmsInformationByLicenseType");
                model.armsByDivisions = _db.armsInfoDashboards.FromSql($"SP_GETArmsInformationByDivision");
                //model.TotalInheriteArms = await dashboardService.GettotalinheritArms();
                //model.armsByArmsType = await dashboardService.GetTotalArmsByArmsType();
                //model.politicalLilist = await dashboardService.GetPoliticalLicensee();
                //model.nonPoliticalLilist = await dashboardService.GetNonPoliticalLicensee();
                //model.maleLilist = await dashboardService.GetMaleLicensee();
                //model.femaleLilist = await dashboardService.GetWomenLicensee();
                return View(model);
            }
            return View(model);
        }

		#region Privacy

		public IActionResult Privacy()
		{
			return View();
		}

        #endregion

        [HttpGet]
        public JsonResult GetArmsInfoByDistrict(int divistionId)
        {
            var record = _db.armsInfoWithIdDashboards.FromSql($"SP_GETArmsInformationForDistrict {divistionId}");
            return Json(record);
        }
        //[HttpGet]
        //public JsonResult GetArmsInfoByThana(int districtId)
        //{
        //    //var record = _db.armsInfoWithIdDashboardsforthana.FromSql($"GetTotalLicenceForThanaByDisId {districtId}");
        //    return Json(record);
        //}
     
        //[HttpGet]
        //public async Task<IActionResult> GetThanaByDivision(int divistionId)
        //{
        //    var record = await dashboardService.GetThanasByDivisionId(divistionId);
        //    return Json(record);
        //}
        //[HttpGet]
        //public async Task<IActionResult> GetDistrictByDivision(int divistionId)
        //{
        //    var record = await dashboardService.GetDistrictByDivisionId(divistionId);
        //    return Json(record);
        //}
        [HttpGet]
        public JsonResult GetTotalApplicantDashBoardMapDivision()
        {
            var record = _db.armsInfoWithIdDashboards.FromSql($"SP_GETArmsInformationByDivision");
            return Json(record);
        }
        
       
        //public async Task<IActionResult> GetArmstypebyDistrict(int? disId)
        //{
        //    var record = await dashboardService.GetTotalArmsTypeByDistrictId(disId);
        //    return Json(record);
        //}

        //public async Task<JsonResult> GetLicenseInfoByArmsTypeIdAndDivId(int? id, int? divId)
        //{
        //    var record = await dashboardService.GetLiDetailsByArmsTypeIdAndDivId(id, divId);
        //    return Json(record);
        //}
        //public async Task<JsonResult> GetLicenseInfoByArmsTypeIdAndDistId(int? id, int? distId)
        //{
        //    var record = await dashboardService.GetLiDetailsByArmsTypeIdAndDisId(id, distId);
        //    return Json(record);
        //}

        //public async Task<JsonResult> GetAllLicenseInfo()
        //{
        //    var record = await dashboardService.GetAllLicenseWithPhoto();
        //    return Json(record);
        //}

        // [HttpGet]
        //public JsonResult GetLicenseInfoOfDistrict(string licenseTypeId)
        //{
        //    var user = HttpContext.User.Identity.Name;
        //    int licenseTypeIdI = Convert.ToInt32(licenseTypeId);
        //   // var record = _db.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseThana {licenseTypeIdI}");
        //    return Json(record);
        //}

        #region Api
        [AllowAnonymous]  
        [HttpGet("global/api/GetThanaByDistrictId/{id}")]
        //public async Task<IEnumerable<Thana>> GetThanaByDistrictId(int id)
        public async Task<IEnumerable<SpGetAllThanaViewModel>> GetThanaByDistrictId(int id)
        {
            //var thanas = await addressService.GetThanasByDistrictId(id);
            var spGetAllThanaViewModel = addressService.SpGetThanasByDistrictId(id);

            return spGetAllThanaViewModel;
        }


        //[HttpGet("global/api/DistrictNameById/{id}")]
        //public async Task<IActionResult> DistrictNameById(int id)
        //{
        //    var thanas = await dashboardService.GetDistrictNameById(id);
        //    return Json(thanas);
        //}
        //  [HttpGet("global/api/ThanaNameById/{id}")]
        //public async Task<IActionResult> ThanaNameById(int id)
        //{
        //    var thanas = await dashboardService.GetThanaNameByThanaId(id);
        //    return Json(thanas);
        //}

        [HttpGet("global/api/GetDistrictDetailsArmsInfo/{id}")]
        public async Task<JsonResult> GetDistrictDetailsArmsInfo(int id)
        {
            var record = _db.armsInfoDashboardDivDetails.FromSql($"sp_GetLicenseThana {id}");
            return Json(record);
        }

        [HttpGet("global/api/GetLicenseInfoByThanaId/{id}")]
        public JsonResult GetLicenseInfoByThanaId(int id)
        {
            var record = _db.armsInfoDashboardDivDetails.FromSql($"sp_GetLicensebyThanaId {id}");
            return Json(record);
        }
        //IQueryable<SpGetAllDistrictViewModel> SpGetDistrictByDivisionId(int? DivisionId)
        [AllowAnonymous]
        [HttpGet("global/api/GetAllDistrictByDivisionId/{id}")]
        //public async Task<IEnumerable<District>> GetAllDistrictByDivisionId(int id)
        public async Task<IEnumerable<SpGetAllDistrictViewModel>> GetAllDistrictByDivisionId(int id)
        {
            //var thanas = await addressService.GetDistrictByDivisionId(id);
            var thanas = addressService.SpGetDistrictByDivisionId(id);
            return thanas;
        }

        //[HttpGet("global/api/GetLicenseInfoByLiTypeId/{id}")]
        //public async Task<JsonResult> GetLicenseInfoByLiTypeId(int? id)
        //{
        //    var record =await dashboardService.GetLiDetailsByLiTypeId(id);
        //    return Json(record);
        //}

        //[HttpGet("global/api/GetLicenseInfoByArmsTypeId/{id}")]
        //public async Task<JsonResult> GetLicenseInfoByArmsTypeId(int? id)
        //{
        //    var record = await dashboardService.GetLiDetailsByArmsTypeId(id);
        //    return Json(record);
        //}



        //[HttpGet("global/api/GetLiDetailsByDistrictId/{id}")]
        //public async Task<JsonResult> GetLiDetailsByDistrictId(int? id)
        //{
        //    var record = await dashboardService.GetLiDetailsByDivisionId(id);
        //    return Json(record);
        //}
        //[HttpGet("global/api/GetAllLicenseNumber")]
        //public async Task<JsonResult> GetAllLicenseNumber()
        //{
        //    var record = await dashboardService.GetAllLicenseNumber();
        //    return Json(record);
        //}
        //[HttpGet("global/api/liInfoBygender/{res}")]
        //public async Task<JsonResult> GetAllLicensebyGender(int res)
        //{
        //    string gender = string.Empty;
        //    if (res == 3)
        //    {
        //        gender = "male";
        //    }
        //    else gender = "female";
        //    var record = await dashboardService.GetAllLicensebyGenderWithPhoto(gender);
        //    return Json(record);
        //}
        //[HttpGet("global/api/liInfoByPolitical/{res}/{PartyId}")]
        //public async Task<JsonResult> GetAllLicensebyPolitical(int res, int? PartyId)
        //{   
        //    var record = await dashboardService.GetAllLicensebyPoliticalWithPhoto(res,PartyId);
        //    return Json(record);
        //}
        //[HttpGet("global/api/GetLibyPartyIdWithPhoto/{PartyId}")]
        //public async Task<JsonResult> GetLibyPartyIdWithPhoto(int? PartyId)
        //{   
        //    var record = await dashboardService.GetLibyPartyIdWithPhoto(1, PartyId);
        //    return Json(record);
        //}
        //[HttpGet("global/api/liInfoByPartyId/{res}")]
        //public async Task<JsonResult> GetliInfoByPartyId(int res)
        //{   
        //    var record = await dashboardService.GetLibyPartyId(res);
        //    return Json(record);
        //}
        //[HttpGet("global/api/liPoliticalParty")]
        //public async Task<JsonResult> liPoliticalParty()
        //{   
        //    var record = await dashboardService.GetTotalLiForAllPolitical();
        //    return Json(record);
        //}
        //[HttpGet("global/api/AllLicenseList")]
        //public async Task<JsonResult> AllLicenseList()
        //{   
        //    var record = await dashboardService.GetAllLicenseWithPhoto();
        //    return Json(record);
        //}
        //[Route("global/api/getLicenseInfoAsQueryAble/{queryString}")]
        //[HttpGet]
        //public async Task<IActionResult> AllLicenseListForQuery(string queryString)
        //{
        //    return Json(await dashboardService.GetLicenseInfoAsQueryAble(queryString));
        //}
        #endregion
    }
}

