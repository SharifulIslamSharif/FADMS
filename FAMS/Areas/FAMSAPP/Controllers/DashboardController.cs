using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.DAL.AuthService.Interfaces;
using FADMS.DAL.RepositoryService.Interfaces;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data;
using FADMS.Data.Entity.ArmsInfo;
using FADMS.Data.Entity.LicenseInformation;
using FADMS.Data.Entity.Master;
using FADMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FADMS.Areas.FAMSAPP.Controllers
{
    [Authorize]
    [Area("FAMSAPP")]
    public class DashboardController : Controller
    {
        private FADMSDbContext _db;
        private readonly IRepository<Division> _division;
        private readonly IRepository<District> _district;
        private readonly IRepository<Thana> _thana;
        private readonly IRepository<Religion> _religion;
        private readonly IRepository<ArmType> _armType;
        private readonly IRepository<LicenseType> _licenseType;
        private readonly IRepository<PoliticalParty> _politicalParty;

        private readonly IAddressService addressService;
        //private readonly IDashboardService dashboardService;
        private readonly IUserInfoes userInfoes;

        public DashboardController(FADMSDbContext db,
            IRepository<Division> division,
            IRepository<District> district,
            IRepository<Thana> thana,
            IRepository<Religion> religion,
            IRepository<ArmType> armType,
            IRepository<LicenseType> licenseType,
            IRepository<PoliticalParty> politicalParty,
            IAddressService addressService, /*IDashboardService dashboardService,*/ IUserInfoes userInfoes)
        {
            _db = db;
            _division = division;
            _district = district;
            _thana = thana;
            _religion = religion;
            _armType = armType;
            _licenseType = licenseType;
            _politicalParty = politicalParty;
            this.addressService = addressService;
            //this.dashboardService = dashboardService;
            this.userInfoes = userInfoes;
        }

        public async Task<IActionResult> AdminArmsDashboard()
        {
            var model = new DashBoardVM
            {
                divisions = _division.GetAll(),
                districts = _district.GetAll(),
                thanas = _thana.GetAll(),
                religions = _religion.GetAll(),
                armTypes = _armType.GetAll(),
                licenseTypes = _licenseType.GetAll(),
                politicalParties = _politicalParty.GetAll(),

                //TotalLicense = await dashboardService.GetTotalArms(),
                armsinfoid = _db.armsInfoWithIdDashboards.FromSql($"SP_GETArmsInformationByDivisionForArmsDash"),
                armsTypeInfo = _db.armsTotalByType.FromSql($"SP_GETArmsInformationByLicenseTypeForArmsDash"),
                armsByDivisions = _db.armsInfoDashboards.FromSql($"SP_GETArmsInformationByDivisionForArmsDash"),
                //TotalInheriteArms = await dashboardService.GettotalinheritArms(),
                //armsByArmsType = await dashboardService.GetTotalArmsByArmsTypeForArmsDash(),
                //politicalLilist = await dashboardService.GetPoliticalLicenseeForArmsDash(),
                //nonPoliticalLilist = await dashboardService.GetNonPoliticalLicenseeForArmsDash(),
                //maleLilist = await dashboardService.GetMaleLicenseeForArmsDash(),
                //femaleLilist = await dashboardService.GetWomenLicenseeForArmsDash(),

            };
            return View(model);
        }
    }
}