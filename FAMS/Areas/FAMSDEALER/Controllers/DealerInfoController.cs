using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FADMS.Areas.FAMSAPP.Models;
using FADMS.Areas.FAMSAPP.Models.Lang;
using FADMS.Helpers;
using FAMSAPPLICATION.Areas.License.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FADMS.Areas.FAMSDEALER.Controllers
{
    [Area("FAMSDEALER")]
    public class DealerInfoController : Controller
    {
        private readonly LangGenerate<AddressLN> _lang;

        public DealerInfoController(IHostingEnvironment hostingEnvironment)
        {
            _lang = new LangGenerate<AddressLN>(hostingEnvironment.ContentRootPath);
        }
        public IActionResult DealerInfo()
        {
            var data = new DealerInfoVIewModel
            {

            };
            return View(data);
        }

        [HttpPost]
        public IActionResult DealerInfo([FromForm]DealerInfoVIewModel model)
        {

            return View();
        }
        public IActionResult Address()
        {
            var data = new AddressViewModel {

                //fLang =_lang.PerseLang("FAMSDEALER/Address/AddressEN.json", "FAMSDEALER/Address/AddressBN.json", Request.Cookies["lang"]),
            };

            return View(data);
        }
        [HttpPost]
        public IActionResult Address([FromForm] AddressViewModel model)
        {
            return View();
        }
       
        public IActionResult LicenseInfo()
        {
            return View();
        }
        [HttpPost]
         public IActionResult LicenseInfo([FromForm] LicenseViewModel model)
        {
            return View();
        }

        public IActionResult ArmPurchase()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ArmPurchase([FromForm] ArmPurchaseViewModel model)
        {
            return View();
        }

        public IActionResult ArmBuyer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ArmBuyer([FromForm] ArmBuyInfoViewModel model)
        {
            return View();
        }
        public IActionResult DepositInfo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepositInfo([FromForm] DepositViewModel model)
        {
            return View();
        }
        public IActionResult Stock()
        {
            return View();
        }
    }
}