using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.DAL.Services.Interfaces;
using FADMS.Data.Entity.Master;
using FADMS.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FADMS.Areas.FAMSAPP.Controllers
{
    [Area("FAMSAPP")]
    public class AddressController : Controller
    {
        private readonly LangGenerate<AddressLN> _lang;
        private readonly IAddressService addressService;

        public AddressController(IHostingEnvironment hostingEnvironment, IAddressService addressService)
        {
            _lang = new LangGenerate<AddressLN>(hostingEnvironment.ContentRootPath);
            this.addressService = addressService;
            //this.employeeInfoService = employeeInfoService;
            //this.personalInfoService = personalInfoService;
            //this.licenseInfoService = licenseInfoService;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region API

        // GET: api/Address/GetDivisions
        [HttpGet]
        public async Task<IEnumerable<Division>> GetDivisions()
        {

            var divisions = await addressService.GetAllDivision();
            return divisions;
        }



        // GET: api/Address/GetAllDistrict

        [HttpGet]
        public async Task<IEnumerable<District>> GetAllDistrict()
        {

            var districts = await addressService.GetAllDistrict();

            return districts;
        }


        // GET: FAMSAPP/Address/GetDsitrictByDivisionId
        [HttpGet]
        public async Task<IEnumerable<District>> GetDistrictByDivisionId(int id)
        {

            var districts = await addressService.GetDistrictsByDivisonId(id);

            return districts;
        }
        // GET: FAMSAPP/Address/GetThanaByDistrictId
        [HttpGet]
        public async Task<IEnumerable<Thana>> GetThanaByDistrictId(int id)
        {
            var thanas = await addressService.GetThanasByDistrictId(id);

            return thanas;
        }
        #endregion

    }
}